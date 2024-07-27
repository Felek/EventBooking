using EventBooking.Api.V1.Dto;

namespace EventBooking.Api.Utils
{
    public static class LinksGenerator
    {
        private static string BaseUri = "https://blabla.com/api/v1/events";

        public static IReadOnlyCollection<LinkedResource> CreateLinks(string resourceName, int? id = null)
        {
            return new List<LinkedResource>
            {
                new LinkedResource
                {
                    Rel = $"delete-{resourceName}", Href = $"{BaseUri}/{id}"
                },
                new LinkedResource
                {
                    Rel = $"add-{resourceName}", Href = $"{BaseUri}"
                },
                new LinkedResource
                {
                    Rel = $"self", Href = $"{BaseUri}/{id}"
                }
            };
        }
    }
}
