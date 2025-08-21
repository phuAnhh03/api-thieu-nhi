namespace api.Dtos.Accounts
{
    public class GetJwtDto
    {
        public string? Id { get; set;}
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}