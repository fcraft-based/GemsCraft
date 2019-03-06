// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GemsCraft.Players;
using JetBrains.Annotations;

//legacy autorank support for fCraft

namespace GemsCraft.AutoRank
{

    /// <summary> Base class for all AutoRank conditions. </summary>
    public abstract class FCraftConditions
    {
        public abstract bool Eval(PlayerInfo info);

        public static FCraftConditions Parse(XElement el)
        {
            switch (el.Name.ToString())
            {
                case "AND":
                    return new ConditionAND(el);
                case "OR":
                    return new ConditionOR(el);
                case "NOR":
                    return new ConditionNOR(el);
                case "NAND":
                    return new ConditionNAND(el);
                case "ConditionIntRange":
                    return new ConditionIntRange(el);
                case "ConditionRankChangeType":
                    return new ConditionRankChangeType(el);
                case "ConditionPreviousRank":
                    return new ConditionPreviousRank(el);
                default:
                    throw new FormatException();
            }
        }

        public abstract XElement Serialize();
    }


    /// <summary> Class for checking ranges of countable PlayerInfo fields (see ConditionField enum). </summary>
    public sealed class ConditionIntRange : FCraftConditions
    {
        public ConditionField Field { get; set; }
        public ComparisonOp Comparison { get; set; }
        public int Value { get; set; }

        public ConditionIntRange()
        {
            Comparison = ComparisonOp.Eq;
        }

        public ConditionIntRange([NotNull] XElement el) : this()
        {
            // ReSharper disable PossibleNullReferenceException
            if (el == null) throw new ArgumentNullException(nameof(el));
            Field = (ConditionField)Enum.Parse(typeof(ConditionField), el.Attribute("field").Value, true);
            Value = int.Parse(el.Attribute("val").Value);
            if (el.Attribute("op") != null)
            {
                Comparison = (ComparisonOp)Enum.Parse(typeof(ComparisonOp), el.Attribute("op").Value, true);
            }
            // ReSharper restore PossibleNullReferenceException
        }

        public override bool Eval([NotNull] PlayerInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            long givenValue;
            switch (Field)
            {
                case ConditionField.TimeSinceFirstLogin:
                    givenValue = (int)info.TimeSinceFirstLogin.TotalSeconds;
                    break;
                case ConditionField.TimeSinceLastLogin:
                    givenValue = (int)info.TimeSinceLastLogin.TotalSeconds;
                    break;
                case ConditionField.LastSeen:
                    givenValue = (int)info.TimeSinceLastSeen.TotalSeconds;
                    break;
                case ConditionField.BlocksBuilt:
                    givenValue = info.BlocksBuilt;
                    break;
                case ConditionField.BlocksDeleted:
                    givenValue = info.BlocksDeleted;
                    break;
                case ConditionField.BlocksChanged:
                    givenValue = info.BlocksBuilt + info.BlocksDeleted;
                    break;
                case ConditionField.BlocksDrawn:
                    givenValue = info.BlocksDrawn;
                    break;
                case ConditionField.TimesVisited:
                    givenValue = info.TimesVisited;
                    break;
                case ConditionField.MessagesWritten:
                    givenValue = info.MessagesWritten;
                    break;
                case ConditionField.TimesKicked:
                    givenValue = info.TimesKicked;
                    break;
                case ConditionField.TotalTime:
                    givenValue = (int)info.TotalTime.TotalSeconds;
                    break;
                case ConditionField.TimeSinceRankChange:
                    givenValue = (int)info.TimeSinceRankChange.TotalSeconds;
                    break;
                case ConditionField.TimeSinceLastKick:
                    givenValue = (int)info.TimeSinceLastKick.TotalSeconds;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (Comparison)
            {
                case ComparisonOp.Lt:
                    return (givenValue < Value);
                case ComparisonOp.Lte:
                    return (givenValue <= Value);
                case ComparisonOp.Gte:
                    return (givenValue >= Value);
                case ComparisonOp.Gt:
                    return (givenValue > Value);
                case ComparisonOp.Eq:
                    return (givenValue == Value);
                case ComparisonOp.Neq:
                    return (givenValue != Value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override XElement Serialize()
        {
            XElement el = new XElement("ConditionIntRange");
            el.Add(new XAttribute("field", Field));
            el.Add(new XAttribute("val", Value));
            el.Add(new XAttribute("op", Comparison));
            return el;
        }

        public override string ToString()
        {
            return $"ConditionIntRange( {Field} {Comparison} {Value} )";
        }
    }


    /// <inheritdoc />
    /// <summary> Checks what caused player's last rank change (see RankChangeType enum). </summary>
    public sealed class ConditionRankChangeType : FCraftConditions
    {
        public RankChangeType Type { get; set; }

        public ConditionRankChangeType([NotNull] XElement el)
        {
            if (el == null) throw new ArgumentNullException(nameof(el));
            // ReSharper disable PossibleNullReferenceException
            Type = (RankChangeType)Enum.Parse(typeof(RankChangeType), el.Attribute("val").Value, true);
            // ReSharper restore PossibleNullReferenceException
        }

        public override bool Eval([NotNull] PlayerInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            return (info.RankChangeType == Type);
        }

        public override XElement Serialize()
        {
            XElement el = new XElement("ConditionRankChangeType");
            el.Add(new XAttribute("val", Type.ToString()));
            return el;
        }
    }


    /// <inheritdoc />
    /// <summary> Checks what rank the player held previously. </summary>
    public sealed class ConditionPreviousRank : FCraftConditions
    {
        public Rank Rank { get; set; }
        public ComparisonOp Comparison { get; set; }

        public ConditionPreviousRank([NotNull] XElement el)
        {
            // ReSharper disable PossibleNullReferenceException
            if (el == null) throw new ArgumentNullException(nameof(el));
            Rank = Rank.Parse(el.Attribute("val").Value);
            Comparison = (ComparisonOp)Enum.Parse(typeof(ComparisonOp), el.Attribute("op").Value, true);
            // ReSharper restore PossibleNullReferenceException
        }

        public override bool Eval([NotNull] PlayerInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            Rank prevRank = info.PreviousRank ?? info.Rank;
            switch (Comparison)
            {
                case ComparisonOp.Lt:
                    return (prevRank < Rank);
                case ComparisonOp.Lte:
                    return (prevRank <= Rank);
                case ComparisonOp.Gte:
                    return (prevRank >= Rank);
                case ComparisonOp.Gt:
                    return (prevRank > Rank);
                case ComparisonOp.Eq:
                    return (prevRank == Rank);
                case ComparisonOp.Neq:
                    return (prevRank != Rank);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override XElement Serialize()
        {
            XElement el = new XElement("ConditionPreviousRank");
            el.Add(new XAttribute("val", Rank.FullName));
            el.Add(new XAttribute("op", Comparison.ToString()));
            return el;
        }
    }


    #region Condition Sets

    /// <inheritdoc />
    /// <summary> Base class for condition sets/combinations. </summary>
    public class ConditionSet : FCraftConditions
    {
        protected ConditionSet()
        {
            Conditions = new List<FCraftConditions>();
        }

        public List<FCraftConditions> Conditions { get; }

        protected ConditionSet([NotNull] IEnumerable<FCraftConditions> conditions)
        {
            if (conditions == null) throw new ArgumentNullException(nameof(conditions));
            Conditions = conditions.ToList();
        }

        protected ConditionSet([NotNull] XContainer el) : this()
        {
            if (el == null) throw new ArgumentNullException(nameof(el));
            foreach (XElement cel in el.Elements())
            {
                Add(Parse(cel));
            }
        }

        public override bool Eval(PlayerInfo info)
        {
            throw new NotImplementedException();
        }

        public void Add([NotNull] FCraftConditions condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            Conditions.Add(condition);
        }

        public override XElement Serialize()
        {
            throw new NotImplementedException();
        }
    }


    /// <summary> Logical AND - true if ALL conditions are true. </summary>
    public sealed class ConditionAND : ConditionSet
    {
        public ConditionAND() { }
        public ConditionAND(IEnumerable<FCraftConditions> conditions) : base(conditions) { }
        public ConditionAND(XContainer el) : base(el) { }

        public override bool Eval(PlayerInfo info)
        {
            return Conditions == null || Conditions.All(t => t.Eval(info));
        }


        public override XElement Serialize()
        {
            XElement el = new XElement("AND");
            foreach (FCraftConditions cond in Conditions)
            {
                el.Add(cond.Serialize());
            }
            return el;
        }
    }


    /// <summary> Logical AND - true if NOT ALL of the conditions are true. </summary>
    public sealed class ConditionNAND : ConditionSet
    {
        public ConditionNAND() { }
        public ConditionNAND(IEnumerable<FCraftConditions> conditions) : base(conditions) { }
        public ConditionNAND(XContainer el) : base(el) { }

        public override bool Eval([NotNull] PlayerInfo info)
        {
            if (info == null) throw new ArgumentNullException("info");
            return Conditions == null || Conditions.Any(t => !t.Eval(info));
        }


        public override XElement Serialize()
        {
            XElement el = new XElement("NAND");
            foreach (FCraftConditions cond in Conditions)
            {
                el.Add(cond.Serialize());
            }
            return el;
        }
    }


    /// <summary> Logical AND - true if ANY of the conditions are true. </summary>
    public sealed class ConditionOR : ConditionSet
    {
        public ConditionOR() { }
        public ConditionOR(IEnumerable<FCraftConditions> conditions) : base(conditions) { }
        public ConditionOR(XContainer el) : base(el) { }

        public override bool Eval([NotNull] PlayerInfo info)
        {
            if (info == null) throw new ArgumentNullException("info");
            return Conditions == null || Conditions.Any(t => t.Eval(info));
        }


        public override XElement Serialize()
        {
            XElement el = new XElement("OR");
            foreach (FCraftConditions cond in Conditions)
            {
                el.Add(cond.Serialize());
            }
            return el;
        }
    }


    /// <summary> Logical AND - true if NONE of the conditions are true. </summary>
    public sealed class ConditionNOR : ConditionSet
    {
        public ConditionNOR() { }
        public ConditionNOR(IEnumerable<FCraftConditions> conditions) : base(conditions) { }
        public ConditionNOR(XContainer el) : base(el) { }

        public override bool Eval([NotNull] PlayerInfo info)
        {
            if (info == null) throw new ArgumentNullException("info");
            return Conditions == null || Conditions.All(t => !t.Eval(info));
        }


        public override XElement Serialize()
        {
            XElement el = new XElement("NOR");
            foreach (FCraftConditions cond in Conditions)
            {
                el.Add(cond.Serialize());
            }
            return el;
        }
    }

    #endregion
}