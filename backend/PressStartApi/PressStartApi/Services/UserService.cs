using AutoMapper;
using PressStartApi.DTO;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Interfaces;
using PressStartApi.Models;
using System.Text.RegularExpressions;
using PressStartApi.Functions;

namespace PressStartApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseDTO>> Get()
        {
            IEnumerable<User> users = await _userRepository.Get();
            if(users == null)
            {
                throw new BadHttpRequestException("Nenhum usuário cadastrado", 204);
            }

            List<UserResponseDTO> usersResponse = _mapper.Map<List<UserResponseDTO>>(users);
            return usersResponse;
        }

        public async Task<User> GetByEmail(string email)
        {
            User? user = await _userRepository.GetByEmail(email);

            if (user is null)
                throw new BadHttpRequestException("Não autorizado", 401);

            return user;
        }

        public async Task<UserResponseDTO> GetById(int id)
        {
            User user = await _userRepository.GetById(id);
            UserResponseDTO userResponse = _mapper.Map<UserResponseDTO>(user);

            if (userResponse == null)
                throw new BadHttpRequestException("Usuário não encontrado", 404);

            return userResponse;
        }

        public async Task<UserResponseDTO> AddUser(InsertUserDTO user)
        {
            string phoneReplaced = Regex.Replace(user.Phone, @"\D", "");
            user.Phone = phoneReplaced;
            user.Password = HashPassword.HashingPassword(user.Password);

            User _user = _mapper.Map<User>(user);

            await _userRepository.AddUser(_user);
            return _mapper.Map<UserResponseDTO>(_user);
        }

        public async Task<UserResponseDTO> UpdateUser(int id, UpdateUserDTO user)
        {
            User dbUser = await _userRepository.GetById(id);

            if (dbUser == null)
                throw new BadHttpRequestException("Usuário não encontrado.", 404);

            if (user.Password == null || user.Password == "")
            {
                user.Password = dbUser.Authentication.Password;
            }

            if (user.Password != null && user.Password != "")
            {
                user.Password = HashPassword.HashingPassword(user.Password);
            }

            string phoneReplaced = Regex.Replace(user.Phone, @"\D", "");
            user.Phone = phoneReplaced;

            _mapper.Map(user, dbUser);

            await _userRepository.UpdateUser(dbUser);

            return _mapper.Map<UserResponseDTO>(dbUser);
        }

        public async Task DeleteUser(int id)
        {

            User dbUser = await _userRepository.GetById(id);
            if (dbUser == null)
                throw new BadHttpRequestException("Usuário não encontrado", 404);

            await _userRepository.DeleteUser(dbUser);
        }
    }
}
