using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MessageModels;

namespace FunctionApp156
{
    public static class MessageAssignment
    {
        public static async Task AssignOrder(
            Order order)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, @$"{APIConfiguration.BaseAPI}/Employees");
            var response = await APIConfiguration.HttpClient.SendAsync(request);
            var employeeResult = JsonSerializer.Deserialize<Employee[]>(await response.Content.ReadAsStringAsync(), APIConfiguration.JsonOptions);
            // Pick a random employee
            if (employeeResult.Length != 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(employeeResult.Length);
                var selectedEmployee = employeeResult[index];
                order.ReviewAssignedTo = @$"{selectedEmployee.FirstName} {selectedEmployee.LastName}";
                string updatedJson = JsonSerializer.Serialize<Order>(order);
                var employeeUpdateRequest = new HttpRequestMessage(HttpMethod.Put, @$"{APIConfiguration.BaseAPI}/Orders/{order.TrackingId}")
                {
                    Content = new StringContent(updatedJson, Encoding.UTF8, "application/json")
                };
                response = await APIConfiguration.HttpClient.SendAsync(employeeUpdateRequest);
            }
        }
    }
}
