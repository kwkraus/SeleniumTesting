using Bogus;

namespace WebSiteUnderTest.Selenium.Framework.Classes
{
    public class RequestData
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Level { get; set; }

        public static RequestData GenerateRandomRequestData()
        {
            var levels = new[]
            {
                "Low",
                "Medium",
                "High"
            };

            var randomProductData = new Faker<RequestData>()
                    .RuleFor(u => u.Title, f => f.Random.Word())
                    .RuleFor(u => u.Body, f => f.Random.Words())
                    .RuleFor(u => u.Level, f => f.PickRandom(levels));


            return randomProductData.Generate();
        }
    }
}
