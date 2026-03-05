namespace AuthService.Application.Dtos
{
    public class LeadDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SourceName { get; set; }
        public string StatusName { get; set; }
        public string AssignedToUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
    }

}
