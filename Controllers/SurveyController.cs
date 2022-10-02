using Microsoft.AspNetCore.Mvc;
using OnqueteApi.Services;
using OnqueteApi.Models;
using OnqueteApi.Types;

namespace OnqueteApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : AppController
    {
        // consts
        private readonly SurveyService _service;

        // constructor
        public SurveyController(SurveyService surveyService)
        {
            _service = surveyService;
        }

        /// <summary>
        /// List all surveys
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<AppResponse<List<Survey>>>> index()
        {
            var surveys = await _service.ListAll();

            return Success<List<Survey>>("Surveys fetched successfully", surveys);
        }

        /// <summary>
        /// Find survey by ID
        /// </summary>
        [HttpGet("{uuid}")]
        public async Task<ActionResult<AppResponse<Survey>>> Find([FromRoute] Guid uuid)
        {
            var survey = await _service.GetByUuid(uuid);

            if (survey is null)
                return NotFound("Survey not found, try another UUID");

            return Success<Survey>("Survey fetched successfully", survey);
        }

        /// <summary>
        /// Create new Survey 
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<AppResponse<object>>> Create([FromBody] NewSurvey survey)
        {
            var newSurvey = await _service.Create(survey);

            if (newSurvey is null)
                return BadRequest("Something went wrong");

            return Success<object>("Survey created successfully", new { Uuid = newSurvey.Uuid });
        }
    }
}