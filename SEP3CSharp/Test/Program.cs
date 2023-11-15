// See https://aka.ms/new-console-template for more information


using Domain.Models;
using JavaPersistenceClient.DAOs;

Console.WriteLine("Hello, World! Testing here...");

BookRegistryDao bookRegistryDao = new();
await bookRegistryDao.CreateAsync(new BookRegistry(
    "Omars book of Magic Spells",
    "Omar",
    "Fantasy",
    "Test Isbn vvv22323232",
    "Test DescriptionaaA",
    "Test Review"
));