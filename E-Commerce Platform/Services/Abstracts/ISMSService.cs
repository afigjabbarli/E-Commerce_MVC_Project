namespace E_Commerce_Platform.Services.Abstracts
{
    public interface ISMSService
    {
        void SendSMS(string RECIPIENT, string MESSAGE_TEXT);
    }
}
