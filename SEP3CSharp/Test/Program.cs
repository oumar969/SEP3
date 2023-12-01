// See https://aka.ms/new-console-template for more information


using Domain.Models;
using JavaPersistenceClient.DAOs;

Console.WriteLine("Hello, World! Testing here...");

// BookRegistryDao bookRegistryDao = new();
// await bookRegistryDao.CreateAsync(new BookRegistry(
//     "Test Title v3.0",
//     "Test Author huhu",
//     "Test Genre",
//     "Test Isbn vvv2",
//     "Test DescriptionaaA",
//     "Test Review"
// ));


UserDao user = new();
await user.CreateAsync(new User(
    "Oumar",
    "Ammar",
    "Oumar@via.dk",
    "123456789",
    true
    ));