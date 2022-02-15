using Microsoft.EntityFrameworkCore;
using PRSLibrary.Model;
using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Controllers {
    public class RequestLineController {
        private readonly PRSDbContext _context;

        public RequestLineController(PRSDbContext context) {
            this._context = context;
        }
        //recalculates total property when an inset, update, or delete occurs
        private void RecalculateRequestTotal(int requestId) {
            var request = _context.Requests.Find(requestId);

            request.Total = (from rl in _context.RequestLines
                             join p in _context.Products
                             on rl.ProductId equals p.Id
                             where rl.RequestId == requestId
                             select new {
                                 LineTotal = rl.Quantity * p.Price
                             }).Sum(x => x.LineTotal);
            _context.SaveChanges();
        }

        //List all
        public IEnumerable<RequestLine> GetAll() {
            return _context.RequestLines.Include(x => x.Product)
                                        .Include(x => x.Request).ToList();

        }
        //find by ID
        public RequestLine GetByPk(int id) {
            return _context.RequestLines.Include(x => x.Product)
                                        .Include(x => x.Request)
                                        .SingleOrDefault(x => x.Id == id);
        }
        //creating a new request
        public RequestLine Create(RequestLine requestline) {
            if (requestline is null) {
                throw new ArgumentNullException("user");
            }
            if (requestline.Id != 0) {
                throw new ArgumentException("User.Id must be zero!");
            }
            _context.RequestLines.Add(requestline);
            _context.SaveChanges();
            return requestline;
        }
        //changing info on a request
        public void Change(RequestLine requestline) {
            _context.SaveChanges();
        }

        //Delete a request
        public void Remove(int id) {
            var requestline = _context.RequestLines.Find(id);
            if (requestline is null) {
                throw new Exception("RequestLine not found!");
            }
            _context.RequestLines.Remove(requestline);
            _context.SaveChanges();
        }

    }
}

