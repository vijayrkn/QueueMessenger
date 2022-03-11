using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MessageModels
{
    public class Order
    {
        [Key]
        [JsonPropertyName("TrackingId")]
        public Guid TrackingId { get; set; }

        [JsonPropertyName("MessageDetails")]
        public string? MessageDetails { get; set; }

        [JsonPropertyName("MessageReceivedTime")]
        public string? MessageReceivedTime { get; set; }

        [JsonPropertyName("ReviewAssignedTo")]
        public string? ReviewAssignedTo { get; set; }
    }
}