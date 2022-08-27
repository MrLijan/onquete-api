using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnqueteApi.Models;
using OnqueteApi.Data;
using OnqueteApi.Types;

namespace OnqueteApi.Services;

public class SurveyService
{
    // Const
    private readonly DataContext _ctx;
    private readonly ILogger<SurveyService> _logger;
    private readonly QuestionService _question;

    // Constructor
    public SurveyService(DataContext dataContext, ILogger<SurveyService> logger, QuestionService question)
    {
        _ctx = dataContext;
        _logger = logger;
        _question = question;
    }

    //Methods
    public async Task<List<Survey>> ListAll()
    {
        return await _ctx.surveys.ToListAsync();
    }

    public async Task<Survey?> GetByUuid(Guid uuid)
    {
        return await _ctx.surveys.FirstOrDefaultAsync(s => s.Uuid == uuid);
    }

    public async Task<Survey?> Create(CreateSurveyRequest survey)
    {
        Survey newSurvey = new Survey()
        {
            Uuid = this.newGuid(),
            Title = survey.Title,
            Description = survey.Description,
            AuthorId = survey.AuthorId,
        };
        
        var action = _ctx.surveys.Add(newSurvey);
        await _ctx.SaveChangesAsync();

        newSurvey = await this.GetByUuid(newSurvey.Uuid);

        foreach (var question in survey.Questions)
        {
            question.SurveyId = newSurvey.Id;
            this._question.Create(question);
        }



        return newSurvey;
    }

    private Guid newGuid()
    {
        return Guid.NewGuid();
    }
}