﻿using System.Net;

namespace DynamicFormBuilder.Core.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Status = HttpStatusCode.OK;
            Message = "Basarili";
        }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; } 
        public T Data { get; set; }
    }
}