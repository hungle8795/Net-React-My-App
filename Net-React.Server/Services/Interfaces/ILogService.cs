using Net_React.Server.DTOs.Log;
using System.Security.Claims;

namespace Net_React.Server.Interfaces;

public interface ILogService
{
    Task SaveNewLog(string UserName, string Description);
    Task<IEnumerable<GetLogDto>> GetLogsAsync();
    Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User);

}
