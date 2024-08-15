namespace UrlShorteningService.Configurations;

    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, string type, string title, string detail, string instance,
            string customField ="")
        {
            StatusCode = statusCode;
            Type = type;
            Title = title;
            Detail = detail;
            Instance = instance;
            CustomField = customField;
        }

        public int StatusCode { get; }
        public string Type { get; }
        public string Title { get; }
        public string Detail { get; }
        public string Instance { get; }
        public string CustomField { get; }
    }


