using Microsoft.AspNetCore.Mvc;
using SeriesApi.Application.Interfaces;
using SeriesApi.Domain.Entities;
using SeriesApi.API.DTOs;

namespace SeriesApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeriesController(ISeriesService service) : ControllerBase
{
    private readonly ISeriesService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<SeriesDto>>> GetAll()
    {
        var seriesList = await _service.GetAllAsync();

        var result = seriesList.Select(s => new SeriesDto
        {
            Id = s.Id,
            Title = s.Title,
            Seasons = [.. s.Seasons.Select(se => new SeasonDto
            {
                Id = se.Id,
                Number = se.Number,
                Episodes = [.. se.Episodes.Select(e => new EpisodeDto
                {
                    Id = e.Id,
                    Number = e.Number,
                    Title = e.Title
                })]
            })]
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<SeriesDto>> GetById(Guid id)
    {
        var series = await _service.GetByIdAsync(id);

        if (series == null) return NotFound();

        var dto = new SeriesDto
        {
            Id = series.Id,
            Title = series.Title,
            Seasons = [.. series.Seasons.Select(se => new SeasonDto
            {
                Id = se.Id,
                Number = se.Number,
                Episodes = [.. se.Episodes.Select(e => new EpisodeDto
                {
                    Id = e.Id,
                    Number = e.Number,
                    Title = e.Title
                })]
            })]
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Create(SeriesDto dto)
    {
        var series = new Series
        {
            Title = dto.Title,
            Seasons = [.. dto.Seasons.Select(se => new Season
            {
                Number = se.Number,
                Episodes = [.. se.Episodes.Select(e => new Episode
                {
                    Number = e.Number,
                    Title = e.Title
                })]
            })]
        };

        await _service.CreateAsync(series);
        return CreatedAtAction(nameof(GetById), new { id = series.Id }, dto);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var series = await _service.GetByIdAsync(id);
        if (series == null) return NotFound();

        await _service.DeleteAsync(id);
        return NoContent();
    }
}
