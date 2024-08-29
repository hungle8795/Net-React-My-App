using Net_React.Server.Models;

namespace backend_dotnet7.Core.Entities;

public class Log : BaseModel<long>
{
    public string? UserName { get; set; }
    public string Description { get; set; }
}
