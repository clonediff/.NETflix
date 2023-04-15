namespace DtoLibrary
{
    public class UserAdminDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public DateTime? BannedUntil { get; set; }
        public string RoleId { get; set; }
    }
}
