using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult> UpdateAsync([FromBody] BookRegistryUpdateDto dto)
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
    public async Task<ActionResult> DeleteAsync([FromRoute] string id)
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


}