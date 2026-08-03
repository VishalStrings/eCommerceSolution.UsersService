using AutoMapper;
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
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public readonly IMapper _mapper;

        public UsersService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            _mapper = mapper;
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

            //as AuthenticationResponse is of record type we can with, to reinitialize the proprty  
            return _mapper.Map<AuthenticationResponse>(user) with { 
            Success = true, Token = "token"
            };
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

            //as AuthenticationResponse is of record type we can with, to reinitialize the proprty
            //
            return _mapper.Map<AuthenticationResponse>(registeredUser) with
            {
                Success = true,
                Token = "token"
            };
        }

        public async Task<ApplicationUser> GetUserByUserID(Guid? UserID)
        {
            ApplicationUser? user = await _userRepository.GetUserByUserID(UserID.Value);
            _mapper.Map<UserDTO>(user);

            if (UserID == null)
            {
                return null;
            }

            return user;
        }


}
}
