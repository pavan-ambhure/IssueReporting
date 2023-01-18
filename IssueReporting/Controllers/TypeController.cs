using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IssueReporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService = null!;

        /// <summary>
        /// Constructor that initializes anything needed by the class controller
        /// </summary>
        /// <param name="typeService">type service</param>
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        /// <summary>
        /// Gets Type.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(TypeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _typeService.GetTypeAsync();
            return Ok(result);
        }

        /// <summary>
        /// Gets Type.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TypeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] String typeName)
        {            
            await _typeService.CreateTypeAsync(typeName);
            return Ok("Type created");
        }

    }
}
