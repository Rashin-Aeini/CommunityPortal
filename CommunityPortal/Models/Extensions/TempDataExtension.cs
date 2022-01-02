using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace CommunityPortal.Models.Extensions
{
    public static class TempDataExtension
    {
        private static string Field
        {
            get
            {
                return "Message";
            }
        }

        public static void Message(
            this ITempDataDictionary tempData,
            string user,
            string message)
        {
            IDictionary<string, List<string>> messages;

            if (tempData.ContainsKey(Field))
            {
                messages = JsonConvert
                    .DeserializeObject<IDictionary<string, List<string>>>(
                        (string)tempData[Field]
                        );
            }
            else
            {
                messages = new Dictionary<string, List<string>>();
            }

            if (!messages.ContainsKey(user))
            {
                messages.Add(user, new List<string>());
            }

            messages[user].Add(message);

            tempData[Field] = JsonConvert.SerializeObject(messages);

        }

        public static IDictionary<string, List<string>> Message(
            this ITempDataDictionary tempData)
        {
            IDictionary<string, List<string>> messages;

            if (tempData.ContainsKey(Field))
            {
                messages = JsonConvert
                    .DeserializeObject<IDictionary<string, List<string>>>(
                        (string)tempData[Field]
                    );
            }
            else
            {
                messages = new Dictionary<string, List<string>>();
            }

            tempData[Field] = JsonConvert.SerializeObject(
                new Dictionary<string, List<string>>());

            return messages;
        }
    }
}
