namespace AuthService.Domain.Helpers.Email
{
    public class EmailMessage
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? ActionLink { get; set; } = string.Empty;
        public bool IsHtml { get; set; } = true;
        public List<string> Attachments { get; set; } = new();
    }
}
