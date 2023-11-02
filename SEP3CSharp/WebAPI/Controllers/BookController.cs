using Application.LogicInterfaces;
using Domain.Models;
using Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace SEP3CSharp.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IBookLogic bookLogic;

    public BookController(IBookLogic bookLogic)
    {
        this.bookLogic = bookLogic;
    }
    [HttpPost]
    public async Task<ActionResult<Book>> CreateAsync([FromBody]BookCreationDto dto)
    {
        try
        {
            Book created = await bookLogic.CreateAsync(dto);
            return Created($"/books/{created.UUID}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAsync([FromQuery] string? id, [FromQuery] string? title,
        [FromQuery] string? author,[FromQuery] string? isbn,[FromQuery] string? genre,[FromQuery] string? isBorrowed/*, [FromQuery] string? bodyContains*/)
    {
        try
        {
            SearchBookParametersDto parameters =
                new SearchBookParametersDto(id, title, author, isbn, genre, isBorrowed);
            var todos = await bookLogic.GetAsync(parameters);
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
            await bookLogic.UpdateAsync(dto);
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
            await bookLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookBasicDto>> GetById([FromRoute] int id)
    {
        try
        {
            BookBasicDto result = await bookLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}