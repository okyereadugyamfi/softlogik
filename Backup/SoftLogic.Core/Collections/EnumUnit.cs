using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogik.Miscellaneous
{
    public class EnumUnit<T> 
        where T : struct
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private T _Value;
        public T Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public EnumUnit()
        {
            this._Name = null;
            this._Value = default(T);
        }
        public EnumUnit(string Name, T Value)
        {
            this._Name = Name;
            this._Value = Value;
        }
    }

    public class EnumUnitCollection<T> : List<EnumUnit<T>>
        where T : struct
    {
        public EnumUnitCollection<T> GetEnumUnits()
        {
            EnumUnitCollection<T> enumList = new EnumUnitCollection<T>();

            Array enumValues = Enum.GetValues(typeof(T));
            string[] enumNames = Enum.GetNames(typeof(T));

            for (int i = 0; i < enumValues.Length; i++)
            {
                try
                {
                    EnumUnit<T> newEntry = new EnumUnit<T>(enumNames[i], (T)Convert.ChangeType(enumValues.GetValue(i), typeof(T)));
                    enumList.Add(newEntry);
                }
                catch (OverflowException e)
                {
                    throw new Exception(
                      string.Format("Value could not be added to collection from enum. Value was too large: {0}", Convert.ToUInt64(enumValues.GetValue(i))), e);
                }
            }

            return enumList;
        }
    }
}
