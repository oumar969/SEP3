// See https://aka.ms/new-console-template for more information


using Domain.Models;
using JavaPersistenceClient.DAOs;

Console.WriteLine("Hello, World! Testing here...");

BookRegistryDao bookRegistryDao = new();
await bookRegistryDao.CreateAsync(new BookRegistry(
    "UNITtests Title v3.0",
    "UNITtests Author huhu",
    "UNITtests Genre",
    "UNITtests Isbn vvv2",
    "UNITtests DescriptionaaA",
    "UNITtests Review"
));