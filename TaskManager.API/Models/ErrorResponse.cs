namespace TaskManager.API.Models
{
    public class ErrorResponse
    {
        public string Route { get; set; }
        public int StatusCode { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public object? RoutesValues { get; set; }
    }
}
