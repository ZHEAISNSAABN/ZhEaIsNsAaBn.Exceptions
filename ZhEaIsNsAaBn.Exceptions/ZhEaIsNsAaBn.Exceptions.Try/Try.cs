using System;

namespace ZhEaIsNsAaBn.Exceptions
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using ZhEaIsNsAaBn.Exceptions.Models;

    public interface ITry
    {
        /// <summary>
        /// Executes the specified operation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="operation">The operation.</param>
        /// <param name="maxRetries">How many time u want retry the operation until it work.</param>
        Return<TResult> Execute<TResult>(Func<TResult> operation, int maxRetries = -1, [CallerMemberName] string Caller = null);

        /// <summary>
        /// Executes the specified asynchronous operation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="operation">The asynchronous operation.</param>
        /// <param name="maxRetries">How many time u want retry the operation until it work.</param>
        Task<Return<TResult>> ExecuteAsync<TResult>(Func<Task<TResult>> operation, int maxRetries = -1, [CallerMemberName] string Caller = null);
    }

    /// <summary>
    /// Execute ADO commands and retry transient errors
    /// </summary>
    public partial class Try : ITry
    {
        private readonly IExceptionHandler exceptionHandler;

        public Try(IExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }
        /// <summary>
        /// Executes the specified operation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="operation">The operation.</param>
        /// <param name="maxRetries">How many time u want retry the operation until it work.</param>
        public Return<TResult> Execute<TResult>(Func<TResult> operation, int maxRetries = -1, [CallerMemberName] string Caller = null)
        {
            List<ExceptionData> exceptionData = new List<ExceptionData>();
            int _maxRetries = maxRetries;
            var retry = 0;
            for (; ; )
            {
                retry++;

                try
                {
                    return new Return<TResult> { Result = operation(), ExceptionData = exceptionData, Worked = true, Retries = retry };
                }
                catch (Exception exception)
                {
                    exceptionData.Add(exceptionHandler.Handle(exception));
                    if (maxRetries == -1)
                    {
                        _maxRetries = exceptionData.Last().DefultTryNum + 1;
                    }
                    if (retry == _maxRetries || exceptionData.Last().CanRetry == Retry.CanRetry.No
                            || exceptionData.Count != 2 || exceptionData.Last().ExceptionType == exceptionData[exceptionData.Count - 2].ExceptionType)
                    {
                        return new Return<TResult> { ExceptionData = exceptionData, Worked = false, Retries = retry };
                    }
                    Trace.TraceWarning("Will retry deadlock " + exceptionData);
                }
                System.Threading.Thread.Sleep(500);
            }
        }


        /// <summary>
        /// Executes the specified asynchronous operation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="operation">The asynchronous operation.</param>
        /// <param name="maxRetries">How many time u want retry the operation until it work.</param>
        public async Task<Return<TResult>> ExecuteAsync<TResult>(Func<Task<TResult>> operation, int maxRetries = -1, [CallerMemberName] string Caller = null)
        {
            List<ExceptionData> exceptionData = new List<ExceptionData>();
            int _maxRetries = maxRetries;
            var retry = 0;
            for (; ; )
            {
                retry++;

                try
                {
                    var Result = await operation();
                    return new Return<TResult> { Result = Result, ExceptionData = exceptionData, Worked = true, Retries = retry };
                }
                catch (Exception exception)
                {
                    exceptionData.Add(exceptionHandler.Handle(exception));
                    if (maxRetries == -1)
                    {
                        _maxRetries = exceptionData.Last().DefultTryNum + 1;
                    }
                    if (retry == _maxRetries || exceptionData.Last().CanRetry == Retry.CanRetry.No)
                    {
                        return new Return<TResult> { ExceptionData = exceptionData, Worked = false, Retries = retry };
                    }
                    await Task.Delay(500);
                }
            }
        }

    }
}
