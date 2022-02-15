using Microsoft.EntityFrameworkCore;
using PRSLibrary.Model;
using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Controllers {
    public class RequestController {

    

        private readonly PRSDbContext _context;

        public RequestController(PRSDbContext context) {
            this._context = context;
        }

        //Update Fuction
        public void SetReview(Request request) {
            if(request.Total <= 50) {
                request.Status = "APPROVED";
            } else {
                request.Status = "REVIEW";
            }
            Change(request);
        }

        //SET APPROVED
        public void SetApproved(Request request) {
            request.Status = "APPROVED";
            Change(request);
        }
        
        // SET REJECTED
        public void SetRejected(Request request) {
            request.Status = "REJECTED";
            Change(request);
        }

        public IEnumerable<Request> GetAll() {
            return _context.Requests.ToList();
        }

        public Request GetByPk(int id) {
            return _context.Requests.Include(x => x.User).SingleOrDefault(x => x.Id == id);
        }
        //creating a new request
        public Request Create(Request request) {
            if (request is null) {
                throw new ArgumentNullException("user");
            }
            if (request.Id != 0) {
                throw new ArgumentException("User.Id must be zero!");
            }
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }
        //changing info on a request
        public void Change(Request request) {
            _context.SaveChanges();
        }

        //Delete a request
        public void Remove(int id) {
            var request = _context.Requests.Find(id);
            if (request is null) {
                throw new Exception("User not found!");
            }
            _context.Requests.Remove(request);
            _context.SaveChanges();
        }
    }
}
