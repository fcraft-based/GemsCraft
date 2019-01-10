// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Text;
using System.Management;
using System.Windows.Forms;
using GemsCraft.Events;
using GemsCraft.fSystem;
using GemsCraft.fSystem.Config;
using GemsCraft.Players;
using GemsCraft.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;

#if DEBUG_EVENTS
using System.Reflection.Emit;
#endif

namespace GemsCraft.fSystem
{

    /// <summary> Central logging class. Logs to file, relays messages to the frontend, submits crash reports. </summary>
    public static class Logger
    {

        //it's actually this hard to get the name of the OS
        public static string GetOS()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (var o in searcher.Get())
            {
                var os = (ManagementObject) o;
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }
        
        private static readonly object LogLock = new object();
        public static bool Enabled { get; set; }
        public static readonly bool[] ConsoleOptions;
        public static readonly bool[] LogFileOptions;

        private const string DefaultLogFileName = "GemsCraft.log",
                     LongDateFormat = "yyyy'-'MM'-'dd'_'HH'-'mm'-'ss",
                     ShortDateFormat = "yyyy'-'MM'-'dd";
        private static readonly Uri CrashReportUri = new Uri("http://gemz.christplay.x10host.com/crash.php");
        public static LogSplittingType SplittingType = LogSplittingType.OneFile;
        private static readonly string SessionStart = DateTime.Now.ToString(LongDateFormat); // localized
        private static readonly Queue<string> RecentMessages = new Queue<string>();
        private const int MaxRecentMessages = 25;

        public static string CurrentLogFileName
        {
            get
            {
                switch (SplittingType)
                {
                    case LogSplittingType.SplitBySession:
                        return SessionStart + ".log";
                    case LogSplittingType.SplitByDay:
                        return DateTime.Now.ToString(ShortDateFormat) + ".log"; // localized
                    default:
                        return DefaultLogFileName;
                }
            }
        }


        static Logger()
        {
            Enabled = true;
            int typeCount = Enum.GetNames(typeof(LogType)).Length;
            ConsoleOptions = new bool[typeCount];
            LogFileOptions = new bool[typeCount];
            for (int i = 0; i < typeCount; i++)
            {
                ConsoleOptions[i] = true;
                LogFileOptions[i] = true;
            }
        }


        internal static void MarkLogStart()
        {
            // Mark start of logging
            Log(LogType.SystemActivity,
                $"------ Log Starts {DateTime.Now.ToLongDateString()} ({DateTime.Now.ToShortDateString()}) ------");
        }

        public static void LogToConsole([NotNull] string message)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (message.Contains('\n'))
            {
                foreach (string line in message.Split('\n'))
                {
                    LogToConsole(line);
                }
                return;
            }
            string processedMessage = "# ";
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == '&') i++;
                else processedMessage += message[i];
            }
            Log(LogType.ConsoleOutput, processedMessage);
        }


        [DebuggerStepThrough]
        [StringFormatMethod("message")]
        public static void Log(LogType type, [NotNull] string message, [NotNull] params object[] values)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (values == null) throw new ArgumentNullException("values");
            Log(type, string.Format(message, values));
        }


        [DebuggerStepThrough]
        public static void Log(LogType type, [NotNull] string message)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (!Enabled) return;
            string line = DateTime.Now.ToLongTimeString() + " > " + GetPrefix(type) + message; // localized
            Network.Remote.Server.Logs.Add(line);
            lock (LogLock)
            {
                RaiseLoggedEvent(message, line, type);

                RecentMessages.Enqueue(line);
                while (RecentMessages.Count > MaxRecentMessages)
                {
                    RecentMessages.Dequeue();
                }

                if (!LogFileOptions[(int) type]) return;
                try
                {
                    File.AppendAllText(Path.Combine(Paths.LogPath, CurrentLogFileName), line + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    string errorMessage = "Logger.Log: " + ex.Message;
                    RaiseLoggedEvent(errorMessage,
                        DateTime.Now.ToLongTimeString() + " > " + GetPrefix(LogType.Error) + errorMessage, // localized
                        LogType.Error);
                }
            }
        }


        [DebuggerStepThrough]
        public static string GetPrefix(LogType level)
        {
            switch (level)
            {
                case LogType.SeriousError:
                case LogType.Error:
                    return "ERROR: ";
                case LogType.Warning:
                    return "Warning: ";
                case LogType.IRC:
                    return "IRC: ";
                default:
                    return string.Empty;
            }
        }


        #region Crash Handling

        static readonly object CrashReportLock = new object(); // mutex to prevent simultaneous reports (messes up the timers/requests)
        static DateTime lastCrashReport = DateTime.MinValue;
        const int MinCrashReportInterval = 61; // minimum interval between submitting crash reports, in seconds

        private struct CrashReportData
        {
            public string SoftwareVersion;
            public string Error;
            public string OperatingSystem;
            public string Runtime;
            public string ServerName;
            public string Exception;
            public string Config;
            public string Logs;
            public string Date;
            public string Time;
            public string Assembly;
            public bool ShutdownImminent;
        }

        private static void SaveReport(DateTime n, CrashReportData data)
        {
            string folder = "Crash Reports/";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            
            string file = $"{folder}crash_report.{ReportDateTime(n)}";
            var writer = File.CreateText(file);
            writer.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            writer.Flush();
            writer.Close();
        }

        private static string ReportDateTime(DateTime n)
        {
            return $"{n.ToLongDateString()}.{n.ToLongTimeString()}.txt".Replace(",", "_").Replace(":", "-");
        }
        public static void LogAndReportCrash([CanBeNull] string message, [CanBeNull] string assembly,
                                             [CanBeNull] Exception exception, bool shutdownImminent)
        {
            DateTime n = DateTime.Now;
            string file = $"crash{ReportDateTime(n)}";
            
            if (message == null) message = "(null)";
            if (assembly == null) assembly = "(null)";
            if (exception == null) exception = new Exception("(null)");

            Log(LogType.SeriousError, "{0}: {1}", message, exception);

            bool submitCrashReport = ConfigKey.SubmitCrashReports.Enabled();
            bool isCommon = CheckForCommonErrors(exception);

            // ReSharper disable EmptyGeneralCatchClause
            try
            {
                var eventArgs = new CrashedEventArgs(message,
                                                      assembly,
                                                      exception,
                                                      submitCrashReport && !isCommon,
                                                      isCommon,
                                                      shutdownImminent);
                RaiseCrashedEvent(eventArgs);
                isCommon = eventArgs.IsCommonProblem;
            }
            catch { }
            // ReSharper restore EmptyGeneralCatchClause

            if (!submitCrashReport || isCommon)
            {
                return;
            }

            lock (CrashReportLock)
            {
                if (DateTime.UtcNow.Subtract(lastCrashReport).TotalSeconds < MinCrashReportInterval)
                {
                    Log(LogType.Warning, "Logger.SubmitCrashReport: Could not submit crash report, reports too frequent.");
                    return;
                }
                lastCrashReport = DateTime.UtcNow;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    CrashReportData data = new CrashReportData
                    {
                        SoftwareVersion = Updater.LatestStable.ToString(),
                        Error = message
                    };
                    

                    if (MonoCompat.IsMono)
                    {
                        data.OperatingSystem = Environment.OSVersion.VersionString;
                        data.Runtime = "Mono " + MonoCompat.MonoVersionString;
                    }
                    else
                    {
                        data.OperatingSystem = GetOS() + Environment.OSVersion.ServicePack;
                        data.Runtime =
                            $".Net {".Net " + Environment.Version.Major + "." + Environment.Version.MajorRevision + "." + Environment.Version.Build}";
                    }
                    data.ServerName = ConfigKey.ServerName.GetString();
                

                    if (exception is TargetInvocationException)
                    {
                        exception = (exception).InnerException;
                    }
                    else if (exception is TypeInitializationException)
                    {
                        exception = (exception).InnerException;
                    }

                    if (exception != null)
                        data.Exception = exception.GetType() + ": " + exception.Message + ", Stack: " +
                                         exception.StackTrace;

                    data.Config = File.Exists(Paths.ConfigFileName) ? Paths.ConfigFileName : "config.json not found";

                    string[] lastFewLines;
                    lock (LogLock)
                    {
                        lastFewLines = RecentMessages.ToArray();
                    }

                    data.Logs = string.Join(Environment.NewLine, lastFewLines);
                    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    string postData = $"?json={Uri.EscapeDataString(json)}";
                    byte[] formData = Encoding.UTF8.GetBytes(postData);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CrashReportUri);
                    request.Method = "POST";
                    request.Timeout = 15000; // 15s timeout
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    request.ContentLength = formData.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(formData, 0, formData.Length);
                        requestStream.Flush();
                    }

                    string responseString;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            // ReSharper disable AssignNullToNotNullAttribute
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                // ReSharper restore AssignNullToNotNullAttribute
                                responseString = reader.ReadLine();
                            }
                        }
                    }
                    request.Abort();

                    if (responseString != null && responseString.StartsWith("ERROR"))
                    {
                        Log(LogType.Error, "Crash report could not be processed by gemscraft.net.");
                    }
                    else
                    {
                        if (responseString != null && int.TryParse(responseString, out var referenceNumber))
                        {
                            Log(LogType.SystemActivity, "Crash report submitted (Reference #{0})", referenceNumber);
                        }
                        else
                        {
                            Log(LogType.SystemActivity, "Crash report submitted.");
                        }
                    }


                }
                catch (Exception ex)
                {
                    Log(LogType.Warning, "Logger.SubmitCrashReport: {0}", ex.Message);
                }
            }
        }


        // Called by the Logger in case of serious errors to print troubleshooting advice.
        // Returns true if this type of error is common, and crash report should NOT be submitted.
        public static bool CheckForCommonErrors([CanBeNull] Exception ex)
        {
            if (ex == null) throw new ArgumentNullException("ex");
            string message = null;
            try
            {
                if (ex is FileNotFoundException && ex.Message.Contains("Version=3.5"))
                {
                    message = "Your crash was likely caused by using a wrong version of .NET or Mono runtime. " +
                              "Please update to Microsoft .NET Framework 3.5 (Windows) OR Mono 2.6.4+ (Linux, Unix, Mac OS X).";
                    return true;

                }
                else if (ex.Message.Contains("libMonoPosixHelper") ||
                         ex is EntryPointNotFoundException && ex.Message.Contains("CreateZStream"))
                {
                    message = "800Craft could not locate Mono's compression functionality. " +
                              "Please make sure that you have zlib (sometimes called \"libz\" or just \"z\") installed. " +
                              "Some versions of Mono may also require \"libmono-posix-2.0-cil\" package to be installed.";
                    return true;

                }
                else if (ex is MissingMemberException || ex is TypeLoadException)
                {
                    message = "Something is incompatible with the current revision of 800Craft. " +
                              "If you installed third-party modifications, " +
                              "make sure to use the correct revision (as specified by mod developers). " +
                              "If your own modifications stopped working, your may need to make some updates.";
                    return true;

                }
                else if (ex is UnauthorizedAccessException)
                {
                    message = "800Craft was blocked from accessing a file or resource. " +
                              "Make sure that correct permissions are set for the 800Craft files, folders, and processes.";
                    return true;

                }
                else if (ex is OutOfMemoryException)
                {
                    message = "800Craft ran out of memory. Make sure there is enough RAM to run.";
                    return true;

                }
                else if (ex is SystemException && ex.Message == "Can't find current process")
                {
                    // Ignore Mono-specific bug in MonitorProcessorUsage()
                    return true;

                }
                else if (ex is InvalidOperationException && ex.StackTrace.Contains("MD5CryptoServiceProvider"))
                {
                    message = "Some Windows settings are preventing 800Craft from doing player name verification. " +
                              "See http://support.microsoft.com/kb/811833";
                    return true;

                }
                else if (ex.StackTrace.Contains("__Error.WinIOError"))
                {
                    message = "A filesystem-related error has occured. Make sure that only one instance of 800Craft is running, " +
                              "and that no other processes are using server's files or directories.";
                    return true;

                }
                else if (ex.Message.Contains("UNSTABLE"))
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (message != null)
                {
                    Log(LogType.Warning, message);
                }
            }
        }

        #endregion


        #region Event Tracing
#if DEBUG_EVENTS

        // list of events in this assembly
        static readonly Dictionary<int, EventInfo> eventsMap = new Dictionary<int, EventInfo>();


        static List<string> eventWhitelist = new List<string>();
        static List<string> eventBlacklist = new List<string>();
        const string TraceWhitelistFile = "traceonly.txt",
                     TraceBlacklistFile = "notrace.txt";
        static bool useEventWhitelist, useEventBlacklist;

        static void LoadTracingSettings() {
            if( File.Exists( TraceWhitelistFile ) ) {
                useEventWhitelist = true;
                eventWhitelist.AddRange( File.ReadAllLines( TraceWhitelistFile ) );
            } else if( File.Exists( TraceBlacklistFile ) ) {
                useEventBlacklist = true;
                eventBlacklist.AddRange( File.ReadAllLines( TraceBlacklistFile ) );
            }
        }


        // adds hooks to all compliant events in current assembly
        internal static void PrepareEventTracing() {

            LoadTracingSettings();

            // create a dynamic type to hold our handler methods
            AppDomain myDomain = AppDomain.CurrentDomain;
            var asmName = new AssemblyName( "fCraftEventTracing" );
            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly( asmName, AssemblyBuilderAccess.RunAndSave );
            ModuleBuilder myModule = myAsmBuilder.DefineDynamicModule( "DynamicHandlersModule" );
            TypeBuilder typeBuilder = myModule.DefineType( "EventHandlersContainer", TypeAttributes.Public );

            int eventIndex = 0;
            Assembly asm = Assembly.GetExecutingAssembly();
            List<EventInfo> eventList = new List<EventInfo>();

            // find all events in current assembly, and create a handler for each one
            foreach( Type type in asm.GetTypes() ) {
                foreach( EventInfo eventInfo in type.GetEvents() ) {
                    // Skip non-static events
                    if( (eventInfo.GetAddMethod().Attributes & MethodAttributes.Static) != MethodAttributes.Static ) {
                        continue;
                    }
                    if( eventInfo.EventHandlerType.FullName.StartsWith( typeof( EventHandler<> ).FullName ) ||
                        eventInfo.EventHandlerType.FullName.StartsWith( typeof( EventHandler ).FullName ) ) {

                        if( useEventWhitelist && !eventWhitelist.Contains( type.Name + "." + eventInfo.Name, StringComparer.OrdinalIgnoreCase ) ||
                            useEventBlacklist && eventBlacklist.Contains( type.Name + "." + eventInfo.Name, StringComparer.OrdinalIgnoreCase ) ) continue;

                        MethodInfo method = eventInfo.EventHandlerType.GetMethod( "Invoke" );
                        var parameterTypes = method.GetParameters().Select( info => info.ParameterType ).ToArray();
                        AddEventHook( typeBuilder, parameterTypes, method.ReturnType, eventIndex );
                        eventList.Add( eventInfo );
                        eventsMap.Add( eventIndex, eventInfo );
                        eventIndex++;
                    }
                }
            }

            // hook up the handlers
            Type handlerType = typeBuilder.CreateType();
            for( int i = 0; i < eventList.Count; i++ ) {
                MethodInfo notifier = handlerType.GetMethod( "EventHook" + i );
                var handlerDelegate = Delegate.CreateDelegate( eventList[i].EventHandlerType, notifier );
                try {
                    eventList[i].AddEventHandler( null, handlerDelegate );
                } catch( TargetException ) {
                    // There's no way to tell if an event is static until you
                    // try adding a handler with target=null.
                    // If it wasn't static, TargetException is thrown
                }
            }
        }


        // create a static handler method that matches the given signature, and calls EventTraceNotifier
        static void AddEventHook( TypeBuilder typeBuilder, Type[] methodParams, Type returnType, int eventIndex ) {
            string methodName = "EventHook" + eventIndex;
            MethodBuilder methodBuilder = typeBuilder.DefineMethod( methodName,
                                                                    MethodAttributes.Public | MethodAttributes.Static,
                                                                    returnType,
                                                                    methodParams );

            ILGenerator generator = methodBuilder.GetILGenerator();
            generator.Emit( OpCodes.Ldc_I4, eventIndex );
            generator.Emit( OpCodes.Ldarg_1 );
            MethodInfo min = typeof( Logger ).GetMethod( "EventTraceNotifier" );
            generator.EmitCall( OpCodes.Call, min, null );
            generator.Emit( OpCodes.Ret );
        }


        // Invoked when events fire
        public static void EventTraceNotifier( int eventIndex, EventArgs e ) {
            if( (e is LogEventArgs) && ((LogEventArgs)e).MessageType == LogType.Trace ) return;
            var eventInfo = eventsMap[eventIndex];

            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach( var prop in e.GetType().GetProperties() ) {
                if( !first ) sb.Append( ", " );
                if( prop.Name != prop.PropertyType.Name ) {
                    sb.Append( prop.Name ).Append( '=' );
                }
                object val = prop.GetValue( e, null );
                if( val == null ) {
                    sb.Append( "null" );
                } else if( val is string ) {
                    sb.AppendFormat( "\"{0}\"", val );
                } else {
                    sb.Append( val );
                }
                first = false;
            }

            Log( LogType.Trace,
                 "TraceEvent: {0}.{1}( {2} )",
                 eventInfo.DeclaringType.Name, eventInfo.Name, sb.ToString() );

        }

#endif
        #endregion


        #region Events

        /// <summary> Occurs after a message has been logged. </summary>
        public static event EventHandler<LogEventArgs> Logged;


        /// <summary> Occurs when the server "crashes" (has an unhandled exception).
        /// Note that such occurences will not always cause shutdowns - check ShutdownImminent property.
        /// Reporting of the crash may be suppressed. </summary>
        public static event EventHandler<CrashedEventArgs> Crashed;


        [DebuggerStepThrough]
        static void RaiseLoggedEvent([NotNull] string rawMessage, [NotNull] string line, LogType logType)
        {
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");
            if (line == null) throw new ArgumentNullException("line");
            var h = Logged;
            h?.Invoke(null, new LogEventArgs(rawMessage,
                line,
                logType,
                LogFileOptions[(int)logType],
                ConsoleOptions[(int)logType]));
        }


        static void RaiseCrashedEvent(CrashedEventArgs e)
        {
            var h = Crashed;
            h?.Invoke(null, e);
        }

        #endregion
    }


    #region Enums

    /// <summary> Category of a log event. </summary>
    public enum LogType
    {
        /// <summary> System activity (loading/saving of data, shutdown and startup events, etc). </summary>
        SystemActivity,

        ChangedWorld,

        /// <summary> Warnings (missing files, config discrepancies, minor recoverable errors, etc). </summary>
        Warning,

        /// <summary> Recoverable errors (loading/saving problems, connection problems, etc). </summary>
        Error,

        /// <summary> Critical non-recoverable errors and crashes. </summary>
        SeriousError,

        /// <summary> Routine user activity (command results, kicks, bans, etc). </summary>
        UserActivity,

        /// <summary> Raw commands entered by the player. </summary>
        UserCommand,

        /// <summary> Permission and hack related activity (name verification failures, banned players logging in, detected hacks, etc). </summary>
        SuspiciousActivity,

        /// <summary> Normal (white) chat written by the players. </summary>
        GlobalChat,

        /// <summary> Private messages exchanged by players. </summary>
        PrivateChat,

        /// <summary> Rank chat messages. </summary>
        RankChat,

        /// <summary> Messages and commands entered from console. </summary>
        ConsoleInput,

        /// <summary> Messages printed to the console (typically as the result of commands called from console). </summary>
        ConsoleOutput,

        /// <summary> Messages related to IRC activity.
        /// Does not include all messages relayed to/from IRC channels. </summary>
        IRC,

        /// <summary> Information useful for debugging (error details, routine events, system information). </summary>
        Debug,

        /// <summary> Special-purpose messages related to event tracing (never logged). </summary>
        Trace
    }


    /// <summary> Log splitting type. </summary>
    public enum LogSplittingType
    {
        /// <summary> All logs are written to one file. </summary>
        OneFile,

        /// <summary> A new timestamped logfile is made every time the server is started. </summary>
        SplitBySession,

        /// <summary> A new timestamped logfile is created every 24 hours. </summary>
        SplitByDay
    }

    #endregion
}


namespace GemsCraft.Events
{
    public sealed class LogEventArgs : EventArgs
    {
        [DebuggerStepThrough]
        internal LogEventArgs(string rawMessage, string message, LogType messageType, bool writeToFile, bool writeToConsole)
        {
            RawMessage = rawMessage;
            Message = message;
            MessageType = messageType;
            WriteToFile = writeToFile;
            WriteToConsole = writeToConsole;
        }
        public string RawMessage { get; private set; }
        public string Message { get; private set; }
        public LogType MessageType { get; private set; }
        public bool WriteToFile { get; private set; }
        public bool WriteToConsole { get; private set; }
    }


    public sealed class CrashedEventArgs : EventArgs
    {
        internal CrashedEventArgs(string message, string location, Exception exception, bool submitCrashReport, bool isCommonProblem, bool shutdownImminent)
        {
            Message = message;
            Location = location;
            Exception = exception;
            SubmitCrashReport = submitCrashReport;
            IsCommonProblem = isCommonProblem;
            ShutdownImminent = shutdownImminent;
        }
        public string Message { get; private set; }
        public string Location { get; private set; }
        public Exception Exception { get; private set; }
        public bool SubmitCrashReport { get; set; }
        public bool IsCommonProblem { get; private set; }
        public bool ShutdownImminent { get; private set; }
    }
}