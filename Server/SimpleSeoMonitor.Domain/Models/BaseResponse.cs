using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSeoMonitor.Domain.Models
{
    public class BaseResponse<TData>
    {
        public bool IsSuccess { get; set; }
        public TData? Data { get; set; }
        public string? ErrorMessages { get; set; }

        public static BaseResponse<TData> Success(TData? data)
        {
            return new BaseResponse<TData>
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static BaseResponse<TData> Fail(string? errorMessages = null)
        {
            return new BaseResponse<TData>
            {
                IsSuccess = false,
                ErrorMessages = errorMessages
            };
        }
    }
}
