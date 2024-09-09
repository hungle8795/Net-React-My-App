using AutoMapper;
using Net_React.Server.Data;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _unitOfWork.Repository<Address>().GetAllAsync();
            return _mapper.Map<List<AddressDTO>>(addresses);
        }
        public async Task<AddressDTO> GetAddressByIdAsync(int id)
        {
            var address = await _unitOfWork.Repository<Address>().GetByIdAsync(id);
            return _mapper.Map<AddressDTO>(address);
        }
        public async Task<IEnumerable<AddressDTO>> GetAllAddressByUserIdAsync(int userId)
        {
            var addressRepository = _unitOfWork.AddressRepository();
            var addresses = await addressRepository.GetAllByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }
        public async Task AddAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _unitOfWork.Repository<Address>().AddAsync(address);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _unitOfWork.Repository<Address>().UpdateAsync(address);
            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteAddressAsync(int id)
        {
            await _unitOfWork.Repository<Address>().DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
