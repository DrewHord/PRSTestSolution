using PRSLibrary.Controllers;
using PRSLibrary.Model;
using PRSLibrary.Models;
using PRSTestProject.Model;
using System;
using System.Linq;

namespace TestPRSLibrary {

    class Program {
        static void Main(string[] args) {

            var context = new PRSDbContext();

            var reqCtrl = new RequestController(context);

            var req = reqCtrl.GetByPk(5);

            //reqCtrl.SetReview(req);
            //reqCtrl.SetApproved(req);
            reqCtrl.SetRejected(req);

            req = reqCtrl.GetByPk(5);
            Console.WriteLine($"{req.Description} {req.Status} {req.Total}");




            //static void Print(Product product) {
            //    Console.WriteLine($"{product.Id,-5} {product.PartNbr,-12} {product.Name,-12 } //{product.Price,10:c} {product.Vendor.Name,-15}");
            //    }
            //var userCtrl = new UsersController(context);

            //var user = userCtrl.Login("sa", "sax");

            //if(user is null) {
            //    Console.WriteLine("User not found");
            //} else {
            //    Console.WriteLine(user.Username);
            //}

            //var username = "gdoud";
            //var password = "password";
            //context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            //var user = from u in context.Users
            //        where u.Username == username && u.Password == password
            //        select u;




            //var prodCtrl = new ProductsController(context);
            //var products = prodCtrl.GetAll();

            //foreach(var p in products){
            //    Console.WriteLine($"{p.Id,-5} {p.PartNbr, -12} {p.Name,-12 } {p.Price,10:c} {p.Vendor.Name, -15}");
            //}

            //var product = prodCtrl.GetByPk(2);
            //if(product is not null) {
            //    Console.WriteLine($"{product.Id,-5} {product.PartNbr,-12} {product.Name,-12 } {product.Price,10:c} {product.Vendor.Name,-15}");
            //}














            //var userCtrl = new UsersController(context);

            //var newUser = new User() {
            //    Id = 0, Username = "zz", Password = "xx", Firstname = "User", Lastname = "ZZ",
            //    Phone = "211", Email = "xx@user.com", IsReviewer = false, IsAdmin = false
            //};

            //userCtrl.Create(newUser);

            //var user3 = userCtrl.GetByPk(3);

            //if(user3 is null) {
            //    Console.WriteLine("User not found!");
            //} else {
            //    Console.WriteLine($"User3: {user3.Firstname} {user3.Lastname}");
            //}
            //user3.Lastname = "User3";
            //userCtrl.Change(user3);

            //userCtrl.Remove(2);


            //var users = userCtrl.GetAll();

            //foreach(var user in users) {
            //    Console.WriteLine($"{user.Firstname} {user.Lastname}");
            //}
        }
    }
}
