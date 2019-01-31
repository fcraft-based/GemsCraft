// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
using System;
using System.Linq;
using System.Xml.Linq;
using GemsCraft.Players;
using JetBrains.Annotations;

//legacy autorank support for fCraft

namespace GemsCraft.AutoRank
{
    public sealed class FCraftCriterion : ICloneable
    {
        public Rank FromRank { get; set; }
        public Rank ToRank { get; set; }
        public ConditionSet Condition { get; set; }

        public FCraftCriterion() { }

        public FCraftCriterion([NotNull] FCraftCriterion other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            FromRank = other.FromRank;
            ToRank = other.ToRank;
            Condition = other.Condition;
        }

        public FCraftCriterion([NotNull] Rank fromRank, [NotNull] Rank toRank, [NotNull] ConditionSet condition)
        {
            FromRank = fromRank ?? throw new ArgumentNullException(nameof(fromRank));
            ToRank = toRank ?? throw new ArgumentNullException(nameof(toRank));
            Condition = condition ?? throw new ArgumentNullException(nameof(condition));
        }

        public FCraftCriterion([NotNull] XElement el)
        {
            if (el == null) throw new ArgumentNullException(nameof(el));

            // ReSharper disable PossibleNullReferenceException
            FromRank = Rank.Parse(el.Attribute("fromRank").Value);
            // ReSharper restore PossibleNullReferenceException
            if (FromRank == null) throw new FormatException("Could not parse \"fromRank\"");

            // ReSharper disable PossibleNullReferenceException
            ToRank = Rank.Parse(el.Attribute("toRank").Value);
            // ReSharper restore PossibleNullReferenceException
            if (ToRank == null) throw new FormatException("Could not parse \"toRank\"");

            Condition = (ConditionSet)AutoRank.FCraftConditions.Parse(el.Elements().First());
        }

        public object Clone()
        {
            return new FCraftCriterion(this);
        }

        public override string ToString()
        {
            return $"Criteria( {(FromRank < ToRank ? "promote" : "demote")} from {FromRank.Name} to {ToRank.Name} )";
        }

        public XElement Serialize()
        {
            XElement el = new XElement("Criterion");
            el.Add(new XAttribute("fromRank", FromRank.FullName));
            el.Add(new XAttribute("toRank", ToRank.FullName));
            if (Condition != null)
            {
                el.Add(Condition.Serialize());
            }
            return el;
        }
    }
}