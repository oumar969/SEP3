﻿using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookRegistryLogic
{
    Task<Book> CreateAsync(BookRegistryCreationDto dto);
    Task<ICollection<Book>> GetAsync(SearchBookRegistryParametersDto searchRegistryParameters);
    Task UpdateAsync(BookUpdateDto dto);
    Task DeleteAsync(int id);

    Task<BookBasicDto> GetByIdAsync(int id);
}