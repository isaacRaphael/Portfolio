using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class EmailService
    {
        private readonly MailjetObj _options;

        public EmailService(IOptions<MailjetObj> options)
        {
            _options = options.Value;
        }

        public async Task SendMail(EmailViewModel model)
        {
            MailjetClient client = new MailjetClient("9323fc6578a0a23e8b69a2a325e9fa3f", "1f36193c27e08acf276c401ac22431a0");
            MailjetRequest request = new MailjetRequest
            {
                Resource = SendV31.Resource,
            }
                .Property(Send.Messages, new JArray {
                new JObject {
                 {"From", new JObject {
                  {"Email", "raphael.isaac@thebulbafrica.institute"},
                  {"Name", "IMagX"}
                  }},
                 {"To", new JArray {
                  new JObject {
                   {"Email", "isaacraphaelchidi@gmail.com"},
                   {"Name", "User"}
                   }
                  }},
                 {"Subject", model.Subject},
                 {"TextPart", "New Request From Portfolio"},
                 {"HTMLPart", $"<h3>From : {model.Name} \n Details: {model.Phone},  {model.Email}  \n Message : {model.Message} </h3>"}
                 }
                });
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }
    }
}


