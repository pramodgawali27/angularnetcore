using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch{
                400=>"Bad request you have made.",
                401=>"Unauthorized",
                404=>"Resource not found.",
                500=>"Errors path of the dark side.",
                _=>null
            };
        }

        public int StatusCode{get;set;}
        public string Message{get;set;}
    }
}