using Newtonsoft.Json;
using RestSharp;
using Shiny.Jobs;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundJob
{
    public class RepeatedTask : IJob
    {
        
        public async Task<bool> Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            //if cancellation is requested then do nothing
            if (cancelToken.IsCancellationRequested)
            {
                return false;
            }
            var client = new HttpClient();
            var position = new Position();
            position.Lat = 5.2F;
            position.Lon = 3.1F;
            position.DateTime = DateTime.Now;
            position.Model = "GRAPSTO EDW";
            var json = JsonConvert.SerializeObject(position);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://backgroundlocationapi.azurewebsites.net/api/add", content);
            Console.WriteLine("working");           
            return true;
        }
    }
}
