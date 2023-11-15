﻿namespace Domain.Models;

public class User
{
    public int UUID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLibrarian { get; set; }
    
    public User(string firstName, string lastName, string email, string password, bool isLibrarian)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsLibrarian = isLibrarian;
    }

    public User()
    {
        
    }
}