using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    using System.Collections;
    using System.Reflection;

    public class ExceptionData
    {
        #region My description for the error
        /// <summary>
        /// Represent what is the exception
        /// </summary>
        
        public IBase ExceptionType { get; internal set; }

        /// <summary>
        /// Represent the severity level of the error
        /// </summary>
        
        public Severity SeverityLevel { get; internal set; }

        /// <summary>
        /// Represent if it's a common errer and if u retry it will be solve 
        /// or it's conniction error & it's just slow conniction etc.....
        /// </summary>
        
        public Retry CanRetry { get; internal set; }

        /// <summary>
        /// Represent the defult retrys u can do
        /// </summary>
        
        public int DefultTryNum { get; internal set; }

        /// <summary>
        /// Represent the methood caused throw
        /// </summary>

        public string Caller { get; internal set; }


        #endregion

        #region the defualt description for the error
        /// <summary>
        /// Retern the default error message
        /// </summary>

        public string SystemMessage { get; internal set; }

        /// <summary>
        ///     An object that describes the error that caused the current exception. The System.Exception.InnerException
        ///     property returns the same value as was passed into the System.Exception.#ctor(System.String,System.Exception)
        ///     constructor, or null if the inner exception value was not supplied to the constructor.
        ///     This property is read-only.
        /// </summary>
        
        public Exception InnerException { get; internal set; }

        /// <summary>
        ///     Represent the component default exception
        /// </summary>
        
        public Exception DefaultException { get; internal set; }

        /// <summary>
        ///     Represents  a link to the help file associated with this exception. 
        /// </summary>
        
        public string HelpLink { get; internal set; }

        /// <summary>
        ///     Gets a string representation of the immediate frames on the call stack.
        /// </summary>
        
        public string StackTrace { get; internal set; }

        /// <summary>
        ///     Gets the method that throws the current exception.
        /// </summary>
        
        public MethodBase TargetSite { get; internal set; }

        public List<Tuple<string, object>> AdditionalData { get; internal set; }

        ///// <summary>
        /////    Gets the line number within the Transact-SQL command batch or stored procedure
        /////    that generated the error.
        /////   =>Note: u will get it only if its sql exception 
        ///// </summary>

        //public int LineNumber { get; internal set; }

        ///// <summary>
        /////     Gets the name of the stored procedure or remote procedure call (RPC) that generated
        /////     the error.
        /////   =>Note: u will get it only if its sql exception 
        ///// </summary>

        //public string Procedure { get; internal set; }

        ///// <summary>
        /////     Gets System.Data.Entity.Infrastructure.DbEntityEntry objects that represents
        /////     the entities that could not be saved to the database.
        /////   =>Note: u will get it only if its DbUpdateException in Entity FrameWork
        ///// </summary>

        //public IEnumerable DbEntity { get; internal set; }

        ///// <summary>
        /////     Gets Validation results.
        /////     =>Note: u will get it only if its DbEntityValidationException in Entity FrameWork
        ///// </summary>

        //public IEnumerable EntityValidationErrors { get; internal set; }

        #endregion
    }
}
