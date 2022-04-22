using AutoMapper;
using FM.BLL.Interfaces;
using FM.BLL.Models;
using FM.DAL.Entities;
using FM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL
{
    public class UserService : IUserService
    {
        IDataGenericRepository<User> _userRepo;
        Mapper _userMapper;


        public UserService(IDataGenericRepository<User> userRepo,Mapper userMapper)
        {
            _userRepo = userRepo;
            _userMapper = userMapper;
        }


        public void CreateUser(UserDTO userDTO)
        {
            User user = _userMapper.Map<User>(userDTO); // Check here pls, if correct - delete this message
            
            _userRepo.Create(user);
        }

        public void DeleteUser(UserDTO user)
        {
            _userRepo.Delete(user.Id);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            IEnumerable<User> users = _userRepo.GetAll("Users"); // mabe doesn`t correct, pls Check!!!
            return _userMapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
