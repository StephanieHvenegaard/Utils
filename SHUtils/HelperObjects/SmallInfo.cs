using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHUtils.HelperObjects
{
    public class SmallInfo : IComparable, IEquatable<SmallInfo>

    {
        public SmallInfo(string titel, string description)
        {
            Titel = titel;
            Description = description;
        }
        public string Titel { get; set; }
        public string Description { get; set; }
        int IComparable.CompareTo(object obj)
        {
            SmallInfo c = (SmallInfo)obj;
            return String.Compare(this.Titel, c.Titel);
        }

        public bool Equals(SmallInfo other)
        {
            if (this.Titel != other.Titel) return false;
            if (this.Description != other.Description) return false;
            return true;
        }
    }
}
