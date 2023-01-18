using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IssueReporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService = null!;

        /// <summary>
        /// Constructor that initializes anything needed by the class controller
        /// </summary>
        /// <param name="applicationService">application service</param>
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Gets Application.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpGet("type/{typeId}")]
        [ProducesResponseType(typeof(List<ApplicationMasterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetApplicationByTypeIdAsync([FromRoute]int typeId)
        {
            var result = await _applicationService.GetApplicationsByTypeIdAsync(typeId);
            return Ok(result);
        }

        /// <summary>
        /// Creates application 
        /// </summary>
        /// <param name="createApplication"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateApplicationRequest request)
        {            
            await _applicationService.CreateApplicationAsync(request);
            return Ok("Application created");
        }

        /// <summary>
        ///Updates application
        /// </summary>
        /// <param name="updateApplication"></param>
        /// <returns></returns>
        [HttpPatch("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateApplicationRequest request)
        {            
            //await _applicationService.UpdateApplicationAsync(request);
            return NotFound("Feature in progress.");
        }

    }
}
