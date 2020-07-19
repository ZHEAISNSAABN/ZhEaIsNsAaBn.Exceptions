using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public static class BaseExtensions
    {
            #region ToString for ExceptionType
            public static string ToString<T>(this IBase<T> id)
            {
                return ToString(id, typeof(T));
            }

            public static string ToString<T>(this IBase<T> id, Type type)
            {
            var fieldes = type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static);
                foreach (var field in fieldes)
                {
                    if ((field.FieldType == typeof(T)) && id.Equals(field.GetValue(null)))
                    {
                        return string.Format("{0}.{1}", type.ToString().Replace('+', '.'), field.Name);
                    }
                }
                var NestedTypes = type.GetNestedTypes();
                foreach (var nestedType in NestedTypes)
                {
                    string asNestedType = ToString(id, nestedType);
                    if (asNestedType != null)
                    {
                        return asNestedType;
                    }
                }

                return null;
            }
            #endregion

            //#region ToString for Severity
            //public static string ToString<T>(this Severity id)
            //{
            //    return ToString(id, typeof(T));
            //}

            //public static string ToString(this Severity id, Type type)
            //{
            //    foreach (var field in type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static))
            //    {
            //        if ((field.FieldType == typeof(Severity)) && id.Equals(field.GetValue(null)))
            //        {
            //            return string.Format("{0}.{1}", type.ToString().Replace('+', '.'), field.Name);
            //        }
            //    }

            //    foreach (var nestedType in type.GetNestedTypes())
            //    {
            //        string asNestedType = ToString(id, nestedType);
            //        if (asNestedType != null)
            //        {
            //            return asNestedType;
            //        }
            //    }

            //    return null;
            //}
            //#endregion

            //#region ToString for Retry
            //public static string ToString<T>(this Retry id)
            //{
            //    return ToString(id, typeof(T));
            //}

            //public static string ToString(this Retry id, Type type)
            //{
            //    foreach (var field in type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static))
            //    {
            //        if ((field.FieldType == typeof(Retry)) && id.Equals(field.GetValue(null)))
            //        {
            //            return string.Format("{0}.{1}", type.ToString().Replace('+', '.'), field.Name);
            //        }
            //    }

            //    foreach (var nestedType in type.GetNestedTypes())
            //    {
            //        string asNestedType = ToString(id, nestedType);
            //        if (asNestedType != null)
            //        {
            //            return asNestedType;
            //        }
            //    }

            //    return null;
            //}
            //#endregion

            //#region ToString for Notify
            //public static string ToString<T>(this Notify id)
            //{
            //    return ToString(id, typeof(T));
            //}

            //public static string ToString(this Notify id, Type type)
            //{
            //    foreach (var field in type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static))
            //    {
            //        if ((field.FieldType == typeof(Notify)) && id.Equals(field.GetValue(null)))
            //        {
            //            return string.Format("{0}.{1}", type.ToString().Replace('+', '.'), field.Name);
            //        }
            //    }

            //    foreach (var nestedType in type.GetNestedTypes())
            //    {
            //        string asNestedType = ToString(id, nestedType);
            //        if (asNestedType != null)
            //        {
            //            return asNestedType;
            //        }
            //    }

            //    return null;
            //}
            //#endregion


        }
    }
