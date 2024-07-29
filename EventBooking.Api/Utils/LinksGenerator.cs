using EventBooking.Api.V1.Dto;

namespace EventBooking.Api.Utils
{
    public static class LinksGenerator
    {
        private static string BaseUri = "/api/v1/events";

        public static IReadOnlyCollection<LinkedResource> CreateLinks(string host, string resourceName, int? id = null)
        {
            return new List<LinkedResource>
            {
                new LinkedResource
                {
                    Rel = $"register", Href = $"{host}{BaseUri}/{id}/register"
                },
                new LinkedResource
                {
                    Rel = $"self", Href = $"{host}{BaseUri}/{id}"
                }
            };
        }
    }
}
