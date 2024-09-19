using AutoMapper;
using Net_React.Server.Data;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var Users = await _unitOfWork.Repository<User>().GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(Users);
        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var User = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            return _mapper.Map<UserDTO>(User);
        }
        public async Task<IEnumerable<UserDTO>> GetByUserNameAsync(string UserName)
        {
            var UserRepository = _unitOfWork.UserRepository();
            var Users = await UserRepository.GetByUserNameAsync(UserName);
            return _mapper.Map<IEnumerable<UserDTO>>(Users);
        }
        public async Task AddUserAsync(UserDTO UserDTO)
        {
            var User = _mapper.Map<User>(UserDTO);
            await _unitOfWork.Repository<User>().AddAsync(User);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateUserAsync(UserDTO UserDTO)
        {
            var User = _mapper.Map<User>(UserDTO);
            await _unitOfWork.Repository<User>().UpdateAsync(User);
            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            await _unitOfWork.Repository<User>().DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
