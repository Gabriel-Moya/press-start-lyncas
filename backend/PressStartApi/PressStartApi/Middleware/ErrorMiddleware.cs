using Newtonsoft.Json;
using PressStartApi.DTO.Response;

namespace PressStartApi.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BadHttpRequestException ex)
            {
                ErrorResponse ExResponse = new ErrorResponse(ex.HResult, ex.Message, ex.StatusCode);
                await HandleExceptionAsync(context, ExResponse);
            }
            catch (Exception ex)
            {
                string message = ex.HResult == -2146233088 ? "Email já cadastrado" : ex.Message;
                ErrorResponse ExReponse = new ErrorResponse(ex.HResult, message);
                await HandleExceptionAsync(context, ExReponse);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, ErrorResponse ex)
        {
            context.Response.StatusCode = ex.Errors[0].StatusCode;

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Errors[0]));
        }
    }
}
