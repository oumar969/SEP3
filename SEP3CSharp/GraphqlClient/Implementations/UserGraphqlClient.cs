﻿using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserGraphqlClient : IUserService
{
    private readonly HttpClient client;
    private readonly IGraphQLClient graphqlClient;

    public UserGraphqlClient(HttpClient client)
    {
        this.client = client;
        graphqlClient = new GraphQLHttpClient(ClientOptions.serverUrl, new NewtonsoftJsonSerializer());
    }

    public async Task<ICollection<User>> GetUsers()
    {
        var graphQlRequest = new GraphQLRequest
        {
            Query = @"
                    query {
                        allUsers {
                            firstName
                            lastName
                            email
                            uuid
                            isLibrarian
                        }
                    }",
        };

        var response = await graphqlClient.SendQueryAsync<GetUsersDataRespnse>(graphQlRequest);

        if (response.Errors != null && response.Errors.Length > 0)
        {
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        }

        return response.Data?.AllUsers;
    }

    public Task<ICollection<User>> GetUsers(string? usernameContains = null)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDeleteDto> Delete(UserDeleteDto dto)
    {
        var deleteUserMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($uuid: String!) {
                    deleteUser(uuid: $uuid) {
                        isSuccessful
                        errMsg
                    }
                }",
            Variables = new
            {
                dto.UUID
            }
        };

        var response = await graphqlClient.SendMutationAsync<DeleteUserResponse>(deleteUserMutation);

        if (response.Errors != null && response.Errors.Length > 0)
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        return response.Data?.DeleteUser;
    }

    public async Task<User> GetUserByEmailAsync(string _email)
    {
        var getUserDataQuery = new GraphQLRequest
        {
            Query = @"
                    query ($email: String!) {
                        userByEmail(email: $email) {
                            firstName
                            lastName
                            email
                            uuid
                            isLibrarian
                        }
                    }",
            Variables = new
            {
                email = _email
            }
        };

        Console.WriteLine("asddas 10 " + _email);
        Console.WriteLine("asddas 11");
        Console.WriteLine("asddas 12 " + getUserDataQuery.ToString());
        var response = await graphqlClient.SendQueryAsync<GetUserDataResponse>(getUserDataQuery);


        var resultMsg = "ok";

        if (response.Errors != null && response.Errors.Length > 0)
        {
            resultMsg = "Error: " + string.Join(", ", response.Errors.Select(e => e.Message));
            throw new Exception(resultMsg);
        }

        return response.Data?.UserByEmail;
    }


    public async Task<UserCreationDto> Create(UserCreationDto dto)
    {
        var createUserMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($firstName: String!, $lastName: String!, $email: String!, $password: String!, $isLibrarian: Boolean!) {
                   createUser(firstName: $firstName, lastName: $lastName, email: $email, password: $password, isLibrarian: $isLibrarian) {
                         firstName
                         lastName
                         email
                         password
                         isLibrarian
                         isSuccessful
                         errMsg
                      }
                }",
            Variables = new
            {
                firstName = dto.FirstName,
                lastName = dto.LastName,
                email = dto.Email,
                password = dto.Password,
                isLibrarian = dto.IsLibrarian
            }
        };
        Console.WriteLine("gg wp nice vape nation");
        var response = await graphqlClient.SendMutationAsync<CreateUserResponse>(createUserMutation);
        Console.WriteLine("response.Data 1: " + response.Data?.CreateUser.ToString());
        Console.WriteLine("response.Data 2: " + response.Data?.CreateUser.IsSuccessful);

        if (response.Errors != null && response.Errors.Length > 0)
        {
            return new UserCreationDto(
                dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.Password,
                dto.IsLibrarian,
                false,
                "Error creating user: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        }

        ;
        return response.Data?.CreateUser;
    }

    private class CreateUserResponse
    {
        public UserCreationDto CreateUser { get; set; }
    }

    private class DeleteUserResponse
    {
        public UserDeleteDto DeleteUser { get; set; }
    }

    private class GetUserDataResponse
    {
        public User UserByEmail { get; set; }
    }

    private class GetUsersDataRespnse
    {
        public ICollection<User> AllUsers { get; set; }
    }

    public async Task<ICollection<Book>> GetAllLoanerBooks(string loanerUuid)
    {
        var getLoanerBooksQuery = new GraphQLRequest
        {
            Query = @"
            query ($loanerUuid: String!) {
                allLoanerBooks(loanerUuid: $loanerUuid) {
                    uuid
                }
            }",
            Variables = new
            {
                loanerUuid
            }
        };

        var response = await graphqlClient.SendQueryAsync<GetLoanerBooksDataResponse>(getLoanerBooksQuery);

        if (response.Errors != null && response.Errors.Length > 0)
        {
            throw new Exception("Error: " + string.Join(", ", response.Errors.Select(e => e.Message)));
        }

        return response.Data?.allLoanerBooks;
    }

    private class GetLoanerBooksDataResponse
    {
        public ICollection<Book> allLoanerBooks { get; set; }
    }
}