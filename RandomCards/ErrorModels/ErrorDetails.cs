using System.Text.Json;

namespace RandomCards.ErrorModels
{
    /// <summary>
    /// The model for the customized global error handling.
    /// </summary>
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
