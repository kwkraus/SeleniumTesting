using System.Collections.Generic;
using System.Threading.Tasks;
using WebSiteUnderTest.Models;

namespace WebSiteUnderTest.Repos
{
    public interface IRequestRepository
    {
        Request GetRequest(int? id);

        Task<Request> GetRequestAsync(int? id);

        List<Request> GetRequests();

        Task<List<Request>> GetRequestsAsync();

        void UpdateRequest(Request request);

        void CreateRequest(Request request);

        void DeleteRequest(int id);

        void DeleteRequestAsync(int id);
    }
}
