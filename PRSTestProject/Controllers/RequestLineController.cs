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

        public IEnumerable<RequestLine> GetAll() {
            return _context.RequestLines.Include(x => x.Product)
                                        .Include(x => x.Request).ToList();

        }

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

