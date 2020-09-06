
using MPIS.InventorAgent.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;


namespace MPIS.InventorAgent.APIs
{
    public class DeviceAzureFunctionAPI
    {
        private string UrlBase = "";
        private string x_functions_key = "";
        private HttpClient client;

        public DeviceAzureFunctionAPI(/*string access_token*/)
        {

            UrlBase = Conf.Configuration.GetSection("AzureFunction").Value;//"http://localhost:7071/";//Settings.ConfigurationHelper.Settings.URLFunctionService;/// Environment.GetEnvironmentVariable("URLFunctionService");
            x_functions_key = Conf.Configuration.GetSection("X_Functions_Key").Value; //"rutvNWH5hb5baNe2Gv0Yq6/ZM4QIDAm9SBN4OSL95TxTGLJgqyXLEA==";//Settings.ConfigurationHelper.Settings.X_Function_Key;//Environment.GetEnvironmentVariable("X_Function_Key");
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-functions-key", x_functions_key);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

            // GuidAvailable = Guid.Parse("6383ff38-92f9-4bda-e61a-08d783dd9ba7");
        }

        #region "Private Methods"

        /*public async Task<HttpResponseMessage> SendNotificationSignalR(NotificationSignalR createNotificationRequest)
        {

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd H:mm:ss.fffK",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            var json = JsonConvert.SerializeObject(createNotificationRequest, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(UrlBase + "api/PlaceNotification", content);

            return response;
        }*/

        #endregion
    }
}
