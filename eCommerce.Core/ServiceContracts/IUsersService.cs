using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUsersService
    {
        /// <summary>
        /// Handle user Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task <AuthenticationResponse> Login(LoginRequest loginRequest);

        Task<AuthenticationResponse> Register(RegisterRequest registerRequest);

        Task<UserDTO> GetUserByUserID(Guid? UserID);

    }
}
