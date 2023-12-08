using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.DTOs;
using Domain.Models;
using JavaPersistenceClient.DAOs;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private readonly UserDao userDao = new();
    private readonly IConfiguration config;
    private ICollection<User> users = new List<User>();

    public AuthService(IConfiguration config)
    {
        this.config = config;
    }

    public async Task<UserLoginDto> LoginAsync(string email, string password)
    {
        try
        {
            Console.WriteLine("login auth service 1");
            var user = await ValidateUser(email, password);
            Console.WriteLine("login auth service 2");
            var token = GenerateJwt(user);
            Console.WriteLine("token: " + token);
            return new UserLoginDto(email, password, token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new UserLoginDto(email, password, null, false);
        }
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> ValidateUser(string email, string password)
    {
        try
        {
            users = userDao.GetAllAsync().Result;
            Console.WriteLine("users: " + users);
            var existingUser = users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (existingUser == null) throw new Exception("Bruger ikke fundet");

            if (!existingUser.Password.Equals(password)) throw new Exception("Forkert kodeord");
            Console.WriteLine("existingUser: " + existingUser);
            return Task.FromResult(existingUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public Task<User> RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Email)) throw new ValidationException("Email mangler");

        if (string.IsNullOrEmpty(user.Password)) throw new ValidationException("Password mangler");

        return (Task<User>)Task.CompletedTask;
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        throw new NotImplementedException();
    }

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    private List<Claim> GenerateClaims(User user)
    {
        Console.WriteLine("generate claims 0");
        Console.WriteLine("user : " + user);
        Console.WriteLine("Subject: " + config["Jwt:Subject"]);
        Console.WriteLine("Issuer: " + config["Jwt:Issuer"]);
        Console.WriteLine("Audience: " + config["Jwt:Audience"]);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Iss, config["Jwt:Issuer"]),
            new Claim(JwtRegisteredClaimNames.Aud, config["Jwt:Audience"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim("FirstName", user.FirstName),
            new Claim("LastName", user.LastName),
            new Claim(ClaimTypes.Role, user.IsLibrarian ? "Librarian" : "User")
        };
        Console.WriteLine("generate claims 1");
        return claims.ToList();
    }

    private string GenerateJwt(User user)
    {
        Console.WriteLine("generate jwt 0");
        var claims = GenerateClaims(user);
        Console.WriteLine("generate jwt 1.5");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var header = new JwtHeader(signIn);
        Console.WriteLine("generate jwt 1");
        var payload = new JwtPayload(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            null,
            DateTime.UtcNow.AddMinutes(60));
        Console.WriteLine("generate jwt 2");
        var token = new JwtSecurityToken(header, payload);

        var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return serializedToken;
    }
}
