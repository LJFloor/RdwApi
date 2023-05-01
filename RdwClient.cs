using RdwApi.Converters;
using RdwApi.Models;
using System.Text.Json;

namespace RdwApi
{
    public class RdwClient
    {
        private readonly HttpClient _httpClient;
        const string BaseUrl = "https://opendata.rdw.nl/resource/";

        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
        {
            Converters =
                {
                    new FloatInStringConverter(),
                    new IntegerInStringConverter(),
                    new RdwBooleanConverter(),
                    new NullableStringConverter(),
                }
        };

        public RdwClient()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Get a car's info by its license plate asynchronously
        /// </summary>
        /// <param name="licensePlate">The license plate of the car</param>
        /// <returns></returns>
        public async Task<Car?> GetCarAsync(string licensePlate) =>
            (await GetAsync<Car>($"m9d7-ebf2.json?kenteken={licensePlate.Replace("-", "")}"))?.WithClient(this);

        /// <summary>
        /// Get a car's info by its license plate
        /// </summary>
        /// <param name="licensePlate">The license plate of the car</param>
        /// <returns></returns>
        public Car GetCar(string licensePlate) => GetCarAsync(licensePlate).GetAwaiter().GetResult();

        /// <summary>
        /// Get the fuel info of a car asynchronously
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        public async Task<FuelInfo?> GetFuelInfoAsync(string licensePlate) =>
            await GetAsync<FuelInfo>($"8ys7-d773.json?kenteken={licensePlate.Replace("-", "")}");

        /// <summary>
        /// Get the fuel info of a car
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        public FuelInfo? GetFuelInfo(string licensePlate) => GetFuelInfoAsync(licensePlate).GetAwaiter().GetResult();

        protected async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(BaseUrl + endpoint);

            if (response == null || !response.IsSuccessStatusCode)
            {
                throw new NullReferenceException("Request failed");
            }

            return JsonSerializer.Deserialize<IEnumerable<T>>(await response.Content.ReadAsStringAsync(), _serializerOptions)!.FirstOrDefault();
        }
    }
}
