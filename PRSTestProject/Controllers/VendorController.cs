using PRSLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Controllers {
    public class VendorController {

        private readonly PRSDbContext _context;

        public VendorController(PRSDbContext context) {
            this._context = context;
        }
        //Get a list of all vendors
        public IEnumerable<Vendor> GetAll() {
            return _context.Vendors.ToList();
        }
        //find vendor by Id
        public Vendor GetByPk(int id) {
            return _context.Vendors.Find(id);
        }
        //Create a new Vendor
        public Vendor Create(Vendor vendor) {
            if(vendor is null) {
                throw new ArgumentNullException("vendor");
            }
            if (vendor.Id != 0) {
                throw new ArgumentException("Vendor.Id must be zero");
            }
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
            return vendor;
        }
        //Change existing Vendor info
        public void Change(Vendor vendor) {
            _context.SaveChanges();
        }
        //Delete Vendor
        public void Remove(int id) {
            var vendor = _context.Vendors.Find(id);
            if(vendor is null) {
                throw new Exception("Vendor not found!");
            }
            _context.Vendors.Remove(vendor);
            _context.SaveChanges();
        }


    }
}
