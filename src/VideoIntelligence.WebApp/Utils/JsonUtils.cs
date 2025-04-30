using System.Text.Json;
using System.Text.Json.Serialization;

namespace VideoIntelligence.WebApp.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonUtils
    {
        /// <summary>
        /// The generic deserialization method
        /// </summary>
        /// <param name="stringToDeserialize"></param>
        /// <returns></returns>
        public static T? Deserialize<T>(string stringToDeserialize)
        {
            // Configure the serializer options
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                // Make the property matching case-insensitive
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },

                // This converts property names to camelCase (e.g., "Description" becomes "description").
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<T?>(stringToDeserialize, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T? GetJsonContent<T>(string fileName)
        {
            string fileContent = "";
            // Construct the relative path to the Data folder
            string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleData");
            string filePath = Path.Combine(dataFolder, fileName);

            // Read the file content
            if (File.Exists(filePath))
            {
                fileContent = File.ReadAllText(filePath);
            }
            return Deserialize<T?>(fileContent);

        }

    }
}
