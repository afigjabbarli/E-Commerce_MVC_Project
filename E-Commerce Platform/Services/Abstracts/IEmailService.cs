namespace E_Commerce_Platform.Services.Abstracts
{
    public interface IEmailService
    {
        Task SendMessageAsync(string[] Recipients, string From, string Subject, string Body, string DisplayName, string Password, bool IsHtml);
        Task SendMessageAsync(string Recipient, string From, string Subject, string Body, string DisplayName, string Password, bool IsHtml);
    }
}
