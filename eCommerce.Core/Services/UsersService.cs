using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositortyContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return _userRepository.GetUserByEmailAndPassword(email, password);
            
        }

        public async Task<AuthenticationResponse> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user =  await 
            _userRepository.GetUserByEmailAndPassword
            (loginRequest.Email, loginRequest.Password);

            if(user == null) { 
                return null; 
            }

            return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "Token", Success: true);
        }

        public async Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
        {
            //create new applicationUser object from registerRequest

            ApplicationUser user = new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender = registerRequest.Gender.ToString()

            };

            ApplicationUser? registeredUser =  await 
                _userRepository.AddUser(user);

            if (registeredUser == null)
            {
                return null;
            }
            
              return new AuthenticationResponse
                (registeredUser.UserID, registeredUser.Email,
                registeredUser.Password, registeredUser.Gender, 
                "token", true );
        }
    }
}
