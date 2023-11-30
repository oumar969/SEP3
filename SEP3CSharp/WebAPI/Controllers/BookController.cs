using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BookRegistry = Domain.DTOs.BookRegistry;

namespace SEP3CSharp.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookController(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateAsync([FromBody] BookRegistryCreationDto dto)
    {
        try
        {
            var created = await _bookRegistryLogic.CreateAsync(dto);
            return Created($"/books/{created.UUID}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Book>>> GetAsync([FromQuery] string? id, [FromQuery] string? title,
        [FromQuery] string? author, [FromQuery] string? isbn, [FromQuery] string? genre,
        [FromQuery] string? isBorrowed)
    {
        try
        {
            var parameters =
                new SearchBookRegistryParametersDto(id, title, author, isbn, genre, isBorrowed);
            var todos = await _bookRegistryLogic.GetAsync(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] BookUpdateDto dto)
    {
        try
        {
            await _bookRegistryLogic.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _bookRegistryLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookRegistry>> GetById([FromRoute] int id)
    {
        try
        {
            var result = await _bookRegistryLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}