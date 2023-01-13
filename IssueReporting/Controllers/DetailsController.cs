using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IssueReporting.Api.Controllers
{
    [Route("api/Ticket")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsService _detailsService = null!;

        /// <summary>
        /// Constructor that initializes anything needed by the class controller
        /// </summary>
        /// <param name="detailsService">details service</param>
        public DetailsController(IDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        /// <summary>
        /// Get all ticket details.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTicketDetailsAsync()
        {
            var result = await _detailsService.GetIssuesDetailsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get all ticket details.
        /// </summary>
        /// <param name="gets ticket details"></param>
        /// <returns></returns>
        [HttpGet("ticketId/{ticketId}")]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIssueDetailByTicketIdAsync([FromRoute] int ticketId)
        {
            var result = await _detailsService.GetIssueDetailByTicketIdAsync(ticketId);
            return Ok(result);
        }

        /// <summary>
        /// Get all ticket details by user id.
        /// </summary>
        /// <param name="gets ticket details"></param>
        /// <returns></returns>
        [HttpGet("userId/{userId}")]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIssuesDetailsByUserIdAsync([FromRoute] int userId)
        {
            var result = await _detailsService.GetIssuesDetailsByUserIdAsync(userId);
            return Ok(result);
        }

        /// <summary>update ticket      /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateIssueDetails([FromBody] UpdateIssueDetailsRequest req)
        {
            //await _detailsService.UpdateIssueDetails(req);
            //return Ok("Ticket updated.");
            return NotFound("Feature inprogress")
        }

        /// <summary>Create ticket      /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(IssueDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTicketAsync([FromBody] CreateTicketRequest req)
        {
            await _detailsService.CreateTicketAsync(req);
            return Ok("Ticket Created.");
        }
    }
}
