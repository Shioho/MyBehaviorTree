using System;
using UnityEngine;

namespace Shioho 
{

    public class Property<T>:IEquatable<T>
    {
        protected T _value;
        public T Value 
        {
            get => _value;
            set => _value = value;
        }

        public Property(T value) 
        {
            Value = value;
        }

        public bool Equals(T other)
        {
            if (other.GetType() != Value.GetType())
            {
                return false;
            }

            var type = typeof(T);
            foreach (var property in type.GetProperties())
            {
                if (property.GetValue(other) != property.GetValue(Value))
                {
                    return false;
                }
            }

            //Debug.Log($"==========>Equals");

            return true;
        }

        private bool CheckObjEquals(object a, object b) 
        {
            if (a.GetType() != b.GetType())
                return false;

            if (a is Array) 
            {
                return a.Equals(b);
            }
            return a.Equals(b);
        }

    }


}