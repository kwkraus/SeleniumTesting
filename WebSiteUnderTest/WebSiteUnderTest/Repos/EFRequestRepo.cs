using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebSiteUnderTest.Data;
using WebSiteUnderTest.Models;

namespace WebSiteUnderTest.Repos
{
    public class EFRequestRepo : IRequestRepository
    {
        private ApplicationDbContext _context;
        private ILogger _logger;

        public EFRequestRepo(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<EFRequestRepo>();
        }

        public void CreateRequest(Request request)
        {
            request.Created = DateTime.Now;
            _context.Add(request);
            _context.SaveChanges();
        }

        public void DeleteRequest(int id)
        {
            var request = _context.Request.SingleOrDefault(m => m.Id == id);
            _context.Request.Remove(request);
            _context.SaveChanges();
        }

        public async void DeleteRequestAsync(int id)
        {
            var request = await _context.Request.SingleOrDefaultAsync(m => m.Id == id);
            _context.Request.Remove(request);
            _context.SaveChanges();
        }


        public Request GetRequest(int? id)
        {
            return _context.Request.SingleOrDefault(m => m.Id == id);
        }

        public async Task<Request> GetRequestAsync(int? id)
        {
            return await _context.Request.SingleOrDefaultAsync(m => m.Id == id);
        }

        public List<Request> GetRequests()
        {
            return _context.Request.ToList();
        }

        public async Task<List<Request>> GetRequestsAsync()
        {
            return await _context.Request.ToListAsync();
        }


        public void UpdateRequest(Request request)
        {
            _context.Update(request);
            _context.SaveChanges();
        }

        private void DisplaySqlErrors(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                _logger.LogError($"Index #{i}{Environment.NewLine}Error: {exception.Errors[i].Message}{Environment.NewLine} Number: {exception.Errors[i].Number}{Environment.NewLine} Server: {exception.Errors[i].Server}");
            }
        }

    }
}
