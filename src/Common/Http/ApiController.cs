using Metafar.ATM.Challenge.Common.Http.Response;
using Microsoft.AspNetCore.Mvc;

namespace Metafar.ATM.Challenge.Common.Http
{
    public class ApiController : Controller
    {
        public IActionResult ProcessResult<T>(ApiResponse<T> response)
            where T : class
        {
            if (!response.IsValid)
            {
                return ProcessResultOnError(response);
            }

            return ProcessResultOnSuccess(response);
        }

        private IActionResult ProcessResultOnError<T>(ApiResponse<T> response)
            where T : class
        {
            return new JsonResult(response.Errors)
            {
                StatusCode = (int)response.HttpStatusCode
            };
        }

        private IActionResult ProcessResultOnSuccess<T>(ApiResponse<T> response)
            where T : class
        {
            return new JsonResult(response.Errors)
            {
                StatusCode = (int)response.HttpStatusCode
            };
        }
    }
}
