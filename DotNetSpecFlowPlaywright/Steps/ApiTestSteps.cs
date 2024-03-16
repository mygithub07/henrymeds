
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System;
using NUnit.Framework;
using System.Net;

namespace DotNetSpecFlowPlaywright.Steps
{
    [Binding]
    internal class ApiTestSteps
    {

       
        [Given(@"a user sends request to  API")]
        public async Task GivenUserSendsRequestToAPI()
        {

            var options = new RestClientOptions("https://henry-prod.hasura.app");
         

            var client = new RestClient(options);
            RestRequest request = new RestRequest("/v1/graphql", Method.Post);
            JObject jObject = new JObject();
            jObject["operationName"] = "cappedAvailableTimes";
            jObject["variables"] = JObject.Parse("{\"minimumDate\": \"2024-03-19T01:45:07.315Z\", \"maximumDate\": \"2024-03-29T01:45:07.315Z\", \"state\": \"california\",\"treatmentShortId\": \"weightloss\" }");
            jObject["query"] = "query cappedAvailableTimes($state: String!, $treatmentShortId: String!, $minimumDate: timestamptz!, $maximumDate: timestamptz!) {\n  cappedAvailableTimes: appointment_capped_available_appointment_slots(\n    where: {start_time: {_gt: $minimumDate, _lt: $maximumDate}, state: {_eq: $state}, treatment_object: {short_id: {_eq: $treatmentShortId}}, language: {_eq: \"en-US\"}, provider: {_and: {id: {_is_null: false}}}}\n    order_by: {start_time: asc}\n  ) {\n    ...CappedAvailableSlotsFragment\n    __typename\n  }\n}\n\nfragment CappedAvailableSlotsFragment on appointment_capped_available_appointment_slots {\n  startTime: start_time\n  endTime: end_time\n  provider {\n    id\n    displayName: display_name\n    __typename\n  }\n  __typename\n}";
            request.AddBody(jObject.ToString());
            var response =  client.ExecutePost(request);
            var data = System.Text.Json.JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            Console.WriteLine( data);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
           

        }


    }
}
