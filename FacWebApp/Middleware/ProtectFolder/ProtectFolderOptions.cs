using Microsoft.AspNetCore.Http;

namespace FacWebApp.Middleware.ProtectFolder
{
    public class ProtectFolderOptions
    {
        public PathString Path { get; set; }
        public string PolicyName { get; set; }
    }
}
