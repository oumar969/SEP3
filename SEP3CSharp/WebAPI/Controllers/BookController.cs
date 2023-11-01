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
    
}