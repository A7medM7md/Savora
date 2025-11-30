namespace Savora.Domain.Results
{
    public class EmailMessage
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public bool IsHtml { get; set; } = true;
        public List<string> Attachments { get; set; } = new();
    }
}
