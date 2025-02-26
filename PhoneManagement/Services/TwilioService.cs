using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Configuration;

namespace PhoneManagement.Services
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _messagingServiceSid;

        public TwilioService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _messagingServiceSid = configuration["Twilio:MessagingServiceSid"];

            TwilioClient.Init(_accountSid, _authToken);
        }

        public string SendSms(string to, string messageBody)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber(to))
            {
                MessagingServiceSid = _messagingServiceSid,
                Body = messageBody
            };

            var message = MessageResource.Create(messageOptions);
            return message.Sid; // Trả về Message SID để kiểm tra trạng thái gửi SMS
        }
    }
}