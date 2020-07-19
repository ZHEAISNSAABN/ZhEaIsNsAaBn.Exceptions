using System;
using System.Reflection;

namespace ZhEaIsNsAaBn.Exceptions
{
    public abstract class Base<T> : IBase<T> where T : Base<T>, new()
    {
        private T none;

        protected abstract int Key { get; }

        public T this[long childID] => ThisChild(childID);

        protected T ThisChild(long childID) => NewInstance((mID << Key) | (ulong)childID);

        public T super => NewInstance(mID >> Key);

        public bool isa(T super) => (this != null) && ((this.super == super)) || (this.super.isa(super));

        public static implicit operator Base<T>(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new T().NewInstance((ulong)id);
        }

        protected abstract T NewInstance(ulong id);

        public static bool operator ==(Base<T> a, Base<T> b)
        {
            if ((object)a == null || (object)b == null) return false;

            if (((object)a != null && (object)b == null) || ((object)a == null && (object)b != null)) return false;

            return a.mID == b.mID;
        }

        public static bool operator !=(Base<T> a, Base<T> b)
        {
            if ((object)a == null && (object)b == null) return false;

            if (((object)a != null && (object)b == null) || ((object)a == null && (object)b != null)) return true;

            return a.mID != b.mID;
        }

        public override bool Equals(object obj)
        {
            if (obj is T)
                return ((T)obj).mID == mID;
            else
                return false;
        }

        public override int GetHashCode() => (int)mID;

        protected Base(ulong id) => mID = id;
        protected Base() { }

        protected Base(ulong id, int key) => mID = id;

        private readonly ulong mID;

        public override string ToString()
        {
            return this.ToString<T>();
        }
    }
    //internal static class IDExtensions
    //{
    //    internal static string ToString<T>(this IBase<T> id)
    //    {
    //        return ToString(id, typeof(IBase<T>));
    //    }

    //    internal static string ToString<T>(this IBase<T> id, Type type)
    //    {
    //        foreach (var field in type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static))
    //        {
    //            if ((field.FieldType == typeof(ExceptionType)) && id.Equals(field.GetValue(null)))
    //            {
    //                return string.Format("{0}.{1}", type.ToString().Replace('+', '.'), field.Name);
    //            }
    //        }

    //        foreach (var nestedType in type.GetNestedTypes())
    //        {
    //            string asNestedType = ToString(id, nestedType);
    //            if (asNestedType != null)
    //            {
    //                return asNestedType;
    //            }
    //        }

    //        return null;
    //    }
    //}
}
