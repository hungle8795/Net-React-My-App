using Net_React.Server.DTOs.General;
using Net_React.Server.DTOs.Message;
using System.Security.Claims;

namespace Net_React.Server.Services.Interfaces
{
    public interface IMessageService
    {
        Task<GeneralServiceResponseDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDTO createMessageDto);
        Task<IEnumerable<GetMessageDTO>> GetMessagesAsync();
        Task<IEnumerable<GetMessageDTO>> GetMyMessagesAsync(ClaimsPrincipal User);
    }
}

