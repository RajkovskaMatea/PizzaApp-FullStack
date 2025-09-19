namespace PizzaApp.Services.Implementations
{
    using Microsoft.IdentityModel.Tokens;
    using PizzaApp.DataAccess.Implementations;
    using PizzaApp.DataAccess.Interfaces;
    using PizzaApp.Domain.Entities;
    using PizzaApp.DTOs.UserDTOs;
    using PizzaApp.Mappers;
    using PizzaApp.Services.Interfaces;
    using PizzaApp.Shared.CustomExceptions;
    using System.IdentityModel.Tokens.Jwt;
    using System.Runtime.InteropServices;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<UserListDTO>> GetAllUsers()
        {
            var result = await userRepository.GetAll();

            var resultConverted = result.Select(x => x.ToUserListDTO()).ToList();

            return resultConverted;
        }

        public async Task<UserDTO?> Authenticate(string username, string password)
        {
            // Hash the incoming password using the same hashing algorithm
            var matchedUser = await userRepository.GetByUsername(username);

            if (matchedUser == null)
            {
                return null;
            }

            byte[] storedSalt = Convert.FromBase64String(matchedUser.Password).Take(16).ToArray();
            var hashedPassword = HashPassword(password, storedSalt); // use same PBKDF2 or whatever you used in register

            // Find user by username + hashed password

            if (hashedPassword != matchedUser.Password)
            {
                return null;
            }

            // Create JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this-is-a-very-long-secret-key-12345");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, matchedUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{matchedUser.FirstName} {matchedUser.LastName}")
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            //create mapper
            return new UserDTO
            {
                Id = matchedUser.Id,
                FirstName = matchedUser.FirstName,
                LastName = matchedUser.LastName,
                Username = matchedUser.Username,
                Password = string.Empty,
                PhoneNumber = matchedUser.PhoneNumber,
                Address = matchedUser.Address,
                Token = tokenString
            };
        }

        public async Task Register(RegisterUserDTO model)
        {
            // Validations
            if (string.IsNullOrWhiteSpace(model.FirstName))
            { 
                throw new UserException(null, model.Username, "First name is required");
            }

            if (string.IsNullOrWhiteSpace(model.LastName))
            {
                throw new UserException(null, model.Username, "Last name is required");
            }

            if (await ValidUsername(model.Username))
            {
                throw new UserException(null, model.Username, "Username already exists");
            }

            if (!ValidPassword(model.Password))
            {
                throw new UserException(null, model.Username, "Password is too weak");
            }

            if (model.Password != model.ConfirmPassword)
            {
                throw new UserException(null, model.Username, "Passwords did not match!");
            }

            // Hash the password before storing
            var hashedPassword = HashPassword(model.Password);

            // Create UserDTO
            var userDTO = new UserDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = hashedPassword,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };

            var user = userDTO.ToUser(hashedPassword);

            // Add user via repository
            await userRepository.Create(user);
        }

        private string HashPassword(string password, byte[]? salt = null)
        {
            if (salt == null)
            {
                using var rng = new RNGCryptoServiceProvider();
                salt = new byte[16];
                rng.GetBytes(salt);
            }

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        // Username validation
        private async Task<bool> ValidUsername(string username)
        {
            return await userRepository.ValidateUsername(username);
        }

        // Password validation (improved)
        private static bool ValidPassword(string password)
        {
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{12,20}$");
            return passwordRegex.IsMatch(password);
        }
    }
}
