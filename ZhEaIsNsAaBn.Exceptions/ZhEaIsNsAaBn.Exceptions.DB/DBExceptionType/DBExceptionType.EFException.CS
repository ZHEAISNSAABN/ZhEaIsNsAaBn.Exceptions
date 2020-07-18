using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{

    public partial class DBExceptionType
    {
        /// <summary>
        /// Entity FrameWork Exceptions type.
        /// </summary>
        public static class EFException
        {

            /// <summary>
            /// Exception thrown from System.Data.Entity.DbContext.SaveChanges when validating
            /// entities fails.
            /// </summary>
            public static readonly ExceptionType ValidationException = EF[0];

            /// <summary>
            /// Exception thrown by System.Data.Entity.DbContext when it was expected that SaveChanges
            ///     for an entity would result in a database update but in fact no rows in the database
            ///     were affected. This usually indicates that the database has been concurrently
            ///     updated such that a concurrency token that was expected to match did not actually
            ///     match. Note that state entries referenced by this exception are not serialized
            ///     due to security and accesses to the state entries after serialization will return
            ///     null.
            /// </summary>
            public static readonly ExceptionType ConcurrencyException = EF[1];

            /// <summary>
            /// Exception thrown by System.Data.Entity.DbContext when the saving of changes to
            /// the database fails.
            /// </summary>
            public static readonly ExceptionType UpdateException = EF[2];

            /// <summary>
            /// .
            /// </summary>
            public static readonly ExceptionType CouldNotTruncate = EF[3];
        }
    }
}
