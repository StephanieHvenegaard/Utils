using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHUtils.HelperObjects
{
    public class SmallInfoList : SmallInfo, IEnumerable, IEquatable<SmallInfoList>
    {
        List<SmallInfo> _InfoList;
        public SmallInfoList(string titel, string description)
            : base(titel, description)
        {
            _InfoList = new List<SmallInfo>();
        }
        public SmallInfo[] GetInfoList()
        {
            return _InfoList.ToArray();
        }
        public void Add(SmallInfo smallInfo)
        {
            _InfoList.Add(smallInfo);
        }
        public void AddRange(SmallInfo[] smallInfoRange)
        {
            _InfoList.AddRange(smallInfoRange);
        }
        public void Remove(int index)
        {
            _InfoList.RemoveAt(index);
        }
        public void Remove(SmallInfo smallInfo)
        {
            _InfoList.Remove(smallInfo);
        }
        public SmallInfo[] GetList()
        {
            return _InfoList.ToArray();
        }
        public IEnumerator GetEnumerator()
        {
            return _InfoList.GetEnumerator();
        }
        public SmallInfoList Sort()
        {
            SmallInfoList returned = this;
            returned._InfoList.Sort();
            return returned;
        }
        public bool Equals(SmallInfoList other)
        {
            if (this.Titel != other.Titel) return false;
            if (this.Description != other.Description) return false;
           // if (this._InfoList != other._InfoList) return false;
            return true;
        }
    }
}
