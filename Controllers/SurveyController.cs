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

        // methods
        [HttpGet]
        public async Task<ActionResult<List<Survey>>> index()
        {
            var surveys = await _service.ListAll();

            return Ok(surveys);
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Survey>> Find([FromRoute] Guid uuid)
        {
            var survey = await _service.GetByUuid(uuid);

            if (survey is null)
                return NotFound("Survey not found, try another UUID");

            return Ok(survey);
        }

        /// <summary>
        /// Create new survey
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<AppResponse<object>>> Create([FromBody] NewSurvey survey)
        {
            var newSurvey = await _service.Create(survey);

            if (newSurvey is null)
                return BadRequest("Something went wrong");

            return Success("Survey created successfully", new { Uuid = newSurvey.Uuid });
        }
    }
}