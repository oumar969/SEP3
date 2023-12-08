﻿using System.Text;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using FileData;
using Newtonsoft.Json;

namespace JavaPersistenceClient.DAOs;

public class BookRegistryDao : IBookRegistryDao
{
    private readonly HttpClient _httpClient;

    public BookRegistryDao()
    {
        _httpClient = new HttpClient();
    }

    public async Task<BookRegistryCreationDto> CreateAsync(BookRegistryCreationDto dto)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(dto));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync("http://localhost:7777/book-registry/create", jsonContent);
        Console.WriteLine("response: " + response);
        if (response.IsSuccessStatusCode)
        {
            BookRegistry bookRegistry =
                JsonConvert.DeserializeObject<BookRegistry>(await response.Content.ReadAsStringAsync());
            return new BookRegistryCreationDto(bookRegistry.Title, bookRegistry.Author, bookRegistry.Genre,
                bookRegistry.Isbn, bookRegistry.Description, bookRegistry.Reviews, true,
                "Bog registreret blev oprettet");
        }
        else
        {
            return new BookRegistryCreationDto(dto.Title, dto.Author, dto.Genre,
                dto.Isbn, dto.Description, dto.Reviews, false, "Bog registreret blev ikke oprettet");
        }
    }

    public Task<BookRegistry> UpdateAsync(BookRegistryUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookRegistry>> GetAllAsync()
    {
        var url = $"{ServerOptions.serverUrl}/book-registry/get/all";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<List<BookRegistry>>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting all book registries. Status code: {response.StatusCode}");
    }

    public Task<IEnumerable<BookRegistry>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> UpdateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }

    public async Task<BookRegistry> DeleteAsync(string isbn)
    {
        var url = $"{ServerOptions.serverUrl}/book-registry/delete/{isbn}";

        var response = await _httpClient.DeleteAsync(url);

        Console.WriteLine($"DELETE request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");

        if (response.IsSuccessStatusCode)
        {
            return null; // or return any relevant data depending on your requirements
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error deleting book registry. Status code: {response.StatusCode}");
    }


    public async Task<BookRegistry> GetByBookTitleAsync(string title)
    {
        var url = $"{ServerOptions.serverUrl}/book-registry/getByTitle/{title}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<BookRegistry>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by UUID. Status code: {response.StatusCode}");
    }

    public async Task<BookRegistry> GetByIsbnAsync(string isbn)
    {
        Console.WriteLine("get by isbn");
        var url = $"{ServerOptions.serverUrl}/book-registry/getByIsbn/{isbn}";

        var response = await _httpClient.GetAsync(url);

        Console.WriteLine($"GET request to {url}");
        Console.WriteLine($"Response status code: {response.StatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"JSON Response: {jsonResponse}");

            return JsonConvert.DeserializeObject<BookRegistry>(jsonResponse);
        }

        var errorResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error Response: {errorResponse}");

        throw new Exception($"Error getting user by UUID. Status code: {response.StatusCode}");
    }

    public Task<Book?> GetByIdAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookRegistry>> GetAllBookRegistriesAsync()
    {
        throw new NotImplementedException();
    }

    private async Task<BookRegistry> CreateAsync(BookRegistry entity)
    {
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        Console.WriteLine("JSON: " + JsonConvert.SerializeObject(entity));
        Console.WriteLine("jsonContent11: " + jsonContent);
        var response = await _httpClient.PostAsync("http://localhost:7777/book_registry/register", jsonContent);
        Console.WriteLine("response: " + response);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error creating bookRegistry: {JsonConvert.SerializeObject(response)}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
        return JsonConvert.DeserializeObject<BookRegistry>(jsonResponse);
    }
}