using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemsCraft.Utils
{
    public class Version
    {
        public string Title;
        public int Major;
        public int Minor;
        public int Revision;
        public int Build;
        public bool ShowTitle;

        public static Version ToVersion(List<string> list)
        {
            return new Version(list[0],
                int.Parse(list[1]),
                int.Parse(list[2]),
                int.Parse(list[3]),
                int.Parse(list[4]),
                true);
        }

        public Version()
        {

        }
        public Version(string title, int major, int minor, int revision, int build, bool show)
        {
            Title = title;
            Major = major;

            Minor = minor;
            Revision = revision;
            Build = build;
            ShowTitle = show;
        }
        public static int Compare(Version version1, Version version2)
        {
            if (version1.Title == version2.Title)
            {
                if (version1.Major < version2.Major) return 1;
                else if (version1.Major > version2.Major) return 0;
                else
                {
                    if (version1.Minor < version2.Minor) return 1;
                    else if (version1.Minor > version2.Minor) return 0;
                    else
                    {
                        if (version1.Revision < version2.Revision) return 1;
                        else if (version1.Revision > version2.Revision) return 0;
                        else
                        {
                            if (version1.Build < version2.Build) return 1;
                            else if (version1.Build > version2.Build) return 0;
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (version1.Title == "Alpha") return 1;
                if (version1.Title == "Beta" && version2.Title == "Alpha") return 0;
                else
                {
                    if (version1.Major < version2.Major) return 1;
                    else if (version1.Major > version2.Major) return 0;
                    else
                    {
                        if (version1.Minor < version2.Minor) return 1;
                        else if (version1.Minor > version2.Minor) return 0;
                        else
                        {
                            if (version1.Revision < version2.Revision) return 1;
                            else if (version1.Revision > version2.Revision) return 0;
                            else
                            {
                                if (version1.Build < version2.Build) return 1;
                                else if (version1.Build > version2.Build) return 0;
                                else
                                {
                                    return -1;
                                }
                            }
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            string finalResult = "";
            if (ShowTitle || Title == "Alpha" || Title == "Beta")
            {
                finalResult = Title + " ";
            }

            finalResult += $"{Major}.{Minor}";
            if (Revision <= -1) return finalResult;
            finalResult += $".{Revision}";
            if (Build > -1)
            {
                finalResult += $".{Build}";
            }

            return finalResult;
        }
    }

}
