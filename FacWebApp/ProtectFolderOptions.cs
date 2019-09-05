using Microsoft.AspNetCore.Http;

namespace FacWebApp
{
    public class ProtectFolderOptions
    {
        public PathString Path { get; set; }
        public string PolicyName { get; set; }
    }
}
