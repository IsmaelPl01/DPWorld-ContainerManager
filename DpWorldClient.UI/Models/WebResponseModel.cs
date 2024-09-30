using System.Text.Json.Serialization;
namespace DpWorldClient.UI.Models;


public class WebResponse<T>
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("statusCode")]
    public string StatusCode { get; set; }

    [JsonPropertyName("body")]
    public T Body { get; set; }
}
