using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IssueReporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService = null!;

        /// <summary>
        /// Constructor that initializes anything needed by the class controller
        /// </summary>
        /// <param name="applicationService">type service</param>
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Gets Application.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetApplicationByTypeIdAsync([FromRoute]int typeId)
        {
            var result = await _applicationService.GetApplicationsByTypeIdAsync(typeId);
            return Ok(result);
        }

        /// <summary>
        /// Gets Type.
        /// </summary>
        /// <param name="createApplication"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateApplicationRequest request)
        {            
            await _applicationService.CreateApplicationAsync(request);
            return Ok("Application created");
        }

    }
}
