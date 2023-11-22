using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace SEP3CSharp.Controllers;

[ApiController] // vi bruger ApiController, fordi vi skal bruge http requests.
[Route("user")] // vi bruger Route, fordi vi skal bruge en route til vores http requests.
public class UserController : ControllerBase
{
    private readonly IUserLogic userLogic; //readonly betyder, at vi ikke kan ændre på den.

    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto)
    {
        try
        {
            if (dto.UUID == null) dto.UUID = Guid.NewGuid().ToString();
            var user = await userLogic.CreateAsync(dto);
            return Created($"/user/{user.UUID}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<User>>> GetAsync([FromQuery] string? username)
    {
        try
        {
            SearchUserParametersDto parameters = new(username);
            var users = await userLogic.GetAsync(parameters);
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch("{uuid}")]
    public async Task<ActionResult<User>> UpdateAsync(string uuid, UserUpdateDto dto)
    {
        try
        {
            var user = await userLogic.UpdateAsync(uuid, dto);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{uuid}")]
    public async Task<ActionResult> DeleteAsync(string uuid)
    {
        try
        {
            await userLogic.DeleteAsync(uuid);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}