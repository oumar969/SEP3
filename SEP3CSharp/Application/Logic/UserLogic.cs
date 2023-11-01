using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;
    
    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }


        public async Task<User> CreateAsync(UserCreationDto dto)
        {
            User? existing = await userDao.GetByUserNameAsync(dto.FirstName,dto.LastName,dto.Email, dto.Password);
            if (existing != null)
            
                throw new Exception("User already exists");
            

            ValidateData(dto);
        
        User toCreate = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password            
        };
        
        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

        
        public static void ValidateData(UserCreationDto userCreationDto)
        {
            string firstName = userCreationDto.FirstName;
            string lastName = userCreationDto.LastName;
            string email = userCreationDto.Email;
            string password = userCreationDto.Password;

            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception("First Name is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new Exception("Last Name is required");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (firstName.Length < 3 || lastName.Length < 3)
                throw new Exception("Both First Name and Last Name must be at least 3 characters long");

            if (email.Length < 5 || !IsValidEmail(email))
                throw new Exception("Email is not valid");

            if (password.Length < 8)
                throw new Exception("Password must be at least 8 characters long");
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        
        public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int id, UserUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

}