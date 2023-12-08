﻿using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookService
{
    Task<BookCreationDto> CreateAsync(BookCreationDto dto);

    Task<ICollection<Book>> GetAsync(
        string? userName,
        int? userId,
        string? titleContains,
        string? authorContains,
        string? isbnContains,
        string? genreContains,
        string? descriptionContains
    );

    Task UpdateAsync(BookUpdateDto dto);

    Task<BookRegistry> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task<IEnumerable<Book>> GetAllBooksAsync(string isbn);
}