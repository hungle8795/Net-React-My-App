using Net_React.Server.Models;

namespace Net_React.Server.Models;

public class Log : BaseModel<long>
{
    public string? UserName { get; set; }
    public string Description { get; set; }
}
