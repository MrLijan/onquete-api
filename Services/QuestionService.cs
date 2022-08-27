using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnqueteApi.Models;
using OnqueteApi.Data;
using OnqueteApi.Types;

namespace OnqueteApi.Services;

public class QuestionService
{
    // Const
    private readonly DataContext _ctx;
    private readonly ILogger<QuestionService> _logger;

    // Constructor
    public QuestionService(DataContext dataContext, ILogger<QuestionService> logger)
    {
        _ctx = dataContext;
        _logger = logger;
    }

    //Methods
    public async Task<List<Question>> ListAll()
    {
        return await _ctx.questions.ToListAsync();
    }

    public async Task<Question?> GetByUuid(Guid uuid)
    {
        return await _ctx.questions.FirstOrDefaultAsync(s => s.Uuid == uuid);
    }

    public async Task<Question?> Create(Question question)
    {
        Question newQuestion = new Question()
        {
            Uuid = this.newGuid(),
            Title = question.Title,
            Description = question.Description,
            QuestionType = question.QuestionType,
            SurveyId = question.SurveyId
        };

        var action = _ctx.questions.Add(newQuestion);
        await _ctx.SaveChangesAsync();

        return await this.GetByUuid(newQuestion.Uuid);
    }

    private Guid newGuid()
    {
        return Guid.NewGuid();
    }
}