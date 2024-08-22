using AutoMapper;
using backend.Data;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AddressService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        //{
        //    var addresses = await _context.Repository<Address>().GetAllAsync();
        //    return _mapper.Map<List<AddressDTO>>(addresses);
        //}
        //public async Task<AddressDTO> GetAddressByIdAsync(int id)
        //{
        //    var address = await _context.Repository<Address>().GetByIdAsync(id);
        //    return _mapper.Map<AddressDTO>(address);
        //}
        //public async Task<AddressDTO> GetAddressByUserIdAsync(int userId)
        //{
        //    var addressRepository = _context.AddressRepository() as IAddressRepository;
        //    var address = await addressRepository.GetByUserIdAsync(userId);
        //    return _mapper.Map<AddressDTO>(address);
        //}
        //public async Task AddAddressAsync(AddressDTO addressDto)
        //{
        //    var address = _mapper.Map<Address>(addressDto);
        //    await _context.Repository<Address>().AddAsync(address);
        //    await _context.CompleteAsync();
        //}
        //public async Task UpdateAddressAsync(AddressDTO addressDto)
        //{
        //    var address = _mapper.Map<Address>(addressDto);
        //    await _unitOfWork.Repository<Address>().UpdateAsync(address);
        //    await _unitOfWork.CompleteAsync();
        //}
        //public async Task DeleteAddressAsync(int id)
        //{
        //    await _unitOfWork.Repository<Address>().DeleteAsync(id);
        //    await _unitOfWork.CompleteAsync();
        //}
    }
}
