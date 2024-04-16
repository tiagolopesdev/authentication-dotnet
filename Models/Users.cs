using fiap_jwt_api.Enums;

namespace fiap_jwt_api.Model
{
    public static class ListUsers
    {
        public static IList<Users> Users { get; set; }
    }
    public class Users
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Permissions> Permissions { get; set; }
    }
}
