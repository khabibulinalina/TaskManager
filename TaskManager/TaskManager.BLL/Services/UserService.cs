using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BLL.DTO;
using TaskManager.BLL.Helpers;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Interfaces;


namespace TaskManager.BLL.Services
{
   public class UserService
    {
        private IRepository<User> repo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserService(IRepository<User> userRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            repo = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        public IEnumerable<UserDTO> GetAllUser()
        {
            var temp = repo.GetAll();

            return temp.Select(t => new UserDTO(t));
        }

        public async Task<OperationResult<User, IdentityResult>> CreateUser(RegisterDTO model)
        {
           User user = new User { UserName = model.Name, PhoneNumber = model.PhoneNumber, Email = model.Email, Position = model.Position};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);

                return new OperationResult<User, IdentityResult> { Data = user, Result = result};
        }

       public async Task<SignInResult> Login(LoginViewModel model)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
            
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
            return result;
        }

        public UserDTO GetUserById(String id)
        {
            return repo.Get(id).Convert();
        }

    }
}