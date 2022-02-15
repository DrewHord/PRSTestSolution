using PRSLibrary.Model;
using PRSTestProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Controllers {
   public class UsersController {

        private  readonly PRSDbContext _context;

        public UsersController(PRSDbContext context) {
            this._context = context; 
        }

        //Adding Username and Password authentication 
        public User Login(string username, string password) {
            return _context.Users
                            .SingleOrDefault(x => x.Username == username
                                             && x.Password == password);
        }
        //List all users
        public IEnumerable<User> GetAll() {
           return  _context.Users.ToList();
        }
        //find user by id
        public User GetByPk(int id) {
            return _context.Users.Find(id);
        }
        //creating a new user
        public User Create(User user) {
            if(user is null) {
                throw new ArgumentNullException("user");
            }
            if(user.Id != 0) {
                throw new ArgumentException("User.Id must be zero!");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        //changing an existing users info
        public void Change(User user) {
            _context.SaveChanges();
        }

        //Delete a user
        public void Remove(int id) {
            var user = _context.Users.Find(id);
            if(user is null) {
                throw new Exception("User not found!");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
                
   }
}
