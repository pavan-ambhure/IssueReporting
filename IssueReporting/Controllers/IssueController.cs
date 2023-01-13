using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IssueReporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IissueService _issueService = null!;

        /// <summary>
        /// Constructor that initializes anything needed by the class controller
        /// </summary>
        /// <param name="IissueService">issue service</param>
        public IssueController(IissueService issueService)
        {
            _issueService = issueService;
        }

        /// <summary>
        /// Get all issue details by app id
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpGet("appId/{appId}")]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIssuesByAppId([FromRoute] int appId)
        {
            var result = await _issueService.GetIssuesByAppId(appId);
            return Ok(result);
        }

        /// <summary>
        /// Create issue.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateIssueAsync([FromBody] CreateIssueMasterRequest req)
        {
            await _issueService.CreateIssueAsync(req);
            return Ok("Issue added.");
        }

        /// <summary>
        /// Update issue.
        /// </summary>
        /// <param name="updateIssue"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateIssueAsync([FromBody] UpdateIssueMasterRequest req)
        {
            //await _issueService.UpdateIssueAsync(req);
            return NotFound("Feature in progress.");
        }
    }
}
