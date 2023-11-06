﻿using Domain.Models;

namespace Domain.DTOs;

public class BookUpdateDto
{
    public BookUpdateDto(string uuid)
    {
        UUID = uuid;
    }

    public string UUID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Location { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }
    public string Review { get; set; }
    public int? BorrowerId { get; set; }


    public User? Borrower { get; set; } // Brugeren, der har lånt bogen    
}