using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project_ERP.Responses;

namespace Project_ERP.Filters
{
    public class ApiResponseWrapperFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // No implementation needed for this filter
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
                return;

            if (context.Result is ObjectResult objectResult)
            {
                
                if (objectResult.Value is ApiResponse<object> || objectResult.Value?.GetType().Name.StartsWith("ApiResponse") == true)
                    return;

                var response = new ApiResponse<object>
                {
                    Data = objectResult.Value,
                    Messages = new List<string> { "OK" },
                    Succeeded = objectResult.StatusCode < 400,
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = objectResult.StatusCode
                };
            }

        }
    }
    
    
}
