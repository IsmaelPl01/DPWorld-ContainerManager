using System.Text.Json.Serialization;

namespace DpWorldClient.UI.Models
{
    public class UnitChargeModel
    {
        [JsonPropertyName("ContainerGKEY")]
        public string ContainerGKEY { get; set; }

        [JsonPropertyName("Container")]
        public string Container { get; set; }

        [JsonPropertyName("LineDescription")]
        public string LineDescription { get; set; }

        [JsonPropertyName("BillableQty")]
        public double BillableQty { get; set; }

        [JsonPropertyName("UnitPrice")]
        public double UnitPrice { get; set; }

        [JsonPropertyName("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("ConversionFactor")]
        public double ConversionFactor { get; set; }

        [JsonPropertyName("TotalAmount")]
        public double TotalAmount { get; set; }

        [JsonPropertyName("TaxAmount")]
        public double TaxAmount { get; set; }

        [JsonPropertyName("NetAmount")]
        public double NetAmount { get; set; }
    }
}