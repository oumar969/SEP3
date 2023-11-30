using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;
using Application.DaoInterfaces;
using Application.LogicInterfaces;

namespace Application.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public async Task<User> CreateAsync(UserCreationDto dto)
        {
            var existing = await userDao.GetByEmailAsync(dto.Email);
            if (existing != null) throw new Exception("User already exists");

            UserValidator.ValidateData(dto);

            var toCreate = new User
            {
                UUID = dto.UUID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                IsLibrarian = UserValidator.IsLibrarian(dto.IsLibrarian)
            };

            var created = await userDao.CreateAsync(toCreate);
            return created;
        }

        public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters)
        {
            UserValidator.SearchParametersValidator(searchParameters);
            return userDao.GetAsync(searchParameters);
        }

        public async Task DeleteAsync(string uuid)
        {
            // var user = await userDao.GetByUuidAsync(id);
            // if (user == null) throw new Exception($"Book with UUID {id} was not found!");
            //
            // await userDao.DeleteAsync(id);
        }

        public Task<User> UpdateAsync(string uuid, UserUpdateDto dto)
        {
            var toUpdate = new User
            {
                UUID = uuid,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                Email = dto.Email,
                IsLibrarian = UserValidator.IsLibrarian(dto.IsLibrarian)
            };

            return userDao.UpdateAsync(toUpdate);
        }
    }
}
