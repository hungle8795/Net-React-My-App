using Net_React.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using backend_dotnet7.Core.Entities;
using Net_React.Server.Interfaces;
using backend.Data;
using Net_React.Server.DTOs.Log;

namespace backend_dotnet7.Core.Services;

public class LogService : ILogService
{
    #region Constructor & DI
    private readonly DataContext _context;

    public LogService(DataContext context)
    {
        _context = context;
    }
    #endregion

    #region SaveNewLog
    public async Task SaveNewLog(string UserName, string Description)
    {
        var newLog = new Log()
        {
            UserName = UserName,
            Description = Description
        };

        await _context.Logs.AddAsync(newLog);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region GetLogsAsync
    public async Task<IEnumerable<GetLogDto>> GetLogsAsync()
    {
        var logs = await _context.Logs
             .Select(q => new GetLogDto
             {
                 CreatedAt = q.CreatedAt,
                 Description = q.Description,
                 UserName = q.UserName,
             })
             .OrderByDescending(q => q.CreatedAt)
             .ToListAsync();
        return logs;
    }
    #endregion

    #region GetMyLogsAsync
    public async Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User)
    {
        var logs = await _context.Logs
            .Where(q => q.UserName == User.Identity.Name)
           .Select(q => new GetLogDto
           {
               CreatedAt = q.CreatedAt,
               Description = q.Description,
               UserName = q.UserName,
           })
           .OrderByDescending(q => q.CreatedAt)
           .ToListAsync();
        return logs;
    }
    #endregion

}
