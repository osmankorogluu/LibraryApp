using LibraryApp.Persistence.Result.ComplexTypes;
using LibraryApp.Persistence.Result.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Result.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string messages)
        {
            ResultStatus = resultStatus;
            Message = messages;
        }
        public Result(ResultStatus resultStatus, string messages, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = messages;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public bool Success => throw new NotImplementedException();

        
    }
}
