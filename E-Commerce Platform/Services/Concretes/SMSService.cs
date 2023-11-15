using E_Commerce_Platform.Services.Abstracts;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Org.BouncyCastle.Asn1.Ocsp;

namespace E_Commerce_Platform.Services.Concretes
{
    public class SMSService : ISMSService
    {
        private readonly IConfiguration _configuration;
        public SMSService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendSMS(string RECIPIENT, string MESSAGE_TEXT)
        {
            var configuration = new Configuration()
            {
                BasePath = _configuration.GetValue<string>("SMSsettings:BASE_URL"),
                ApiKeyPrefix = _configuration.GetValue<string>("SMSsettings:ApiKeyPrefix"),
                ApiKey = _configuration.GetValue<string>("SMSsettings:API_KEY")
            };
            var sendSmsApi = new SendSmsApi(configuration);
            var smsMessage = new SmsTextualMessage()
            {
                From = _configuration.GetValue<string>("SMSsettings:Electro ECommerce Online Shopping"),
                Destinations = new List<SmsDestination>()
                {
                    new SmsDestination(to: RECIPIENT)
                },
                Text = MESSAGE_TEXT 
            };
            var smsRequest = new SmsAdvancedTextualRequest()
            {
                Messages = new List<SmsTextualMessage>() { smsMessage }
            };
            SendSmsMessage(sendSmsApi, smsRequest);
        }
        private void SendSmsMessage(SendSmsApi sendSmsApi, SmsAdvancedTextualRequest smsRequest)
        {
            try
            {
                var smsResponse = sendSmsApi.SendSmsMessage(smsRequest);

                Console.WriteLine("Response: " + smsResponse.Messages.FirstOrDefault());
            }
            catch (ApiException apiException)
            {
                Console.WriteLine("Error occurred! \n\tMessage: {0}\n\tError content", apiException.ErrorContent);
            }
        }
    }
}
