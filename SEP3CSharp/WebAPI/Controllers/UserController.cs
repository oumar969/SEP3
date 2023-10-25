﻿using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SEP3CSharp.Controllers;
[ApiController]// vi bruger ApiController, fordi vi skal bruge http requests.
[Route("[controller]")]// vi bruger Route, fordi vi skal bruge en route til vores http requests.
public class UserController :ControllerBase
{
    private readonly IUserLogic userLogic;//readonly betyder, at vi ikke kan ændre på den.

    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    [HttpPost] 
    public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto) 
    {
        try
        {
            User user = await userLogic.CreateAsync(dto);
            return Created($"/users/{user.UUID}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
}