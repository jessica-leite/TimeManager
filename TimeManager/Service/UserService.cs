using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeManager.Domain;
using TimeManager.Domain.Context;
using TimeManager.DTO;

namespace TimeManager.Service
{
    public class UserService
    {
        private readonly TimeManagerContext _context;
        private readonly IMapper _mapper;

        public UserService(TimeManagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(UserDTO user)
        {
            var userModel = CreateUserModel(user);
            _context.Add(userModel);

            _context.SaveChanges();

            user.Id = userModel.Id;
        }

        private User CreateUserModel(UserDTO user)
        {
            var userModel = _mapper.Map<User>(user);

            userModel.CreationDate = DateTime.Now;

            return userModel;
        }

        public List<UserDTO> GetAll()
        {
            var users = _context.User.ToList();

            var usersDTO = new List<UserDTO>();
            users.ForEach(u => { usersDTO.Add(_mapper.Map<UserDTO>(u)); });

            return usersDTO;
        }

        public UserDTO GetById(int id)
        {
            var user = _context.Find<User>(id);

            return _mapper.Map<UserDTO>(user);
        }
    }
}