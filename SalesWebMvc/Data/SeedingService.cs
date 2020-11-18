using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers", "email@email.com");
            Department d2 = new Department(2, "Eletronics", "email@email.com");
            Department d3 = new Department(3, "Fashion", "email@email.com");
            Department d4 = new Department(4, "Books", "email@email.com");

            Seller s1 = new Seller(1, "Bob Brown"   , "bob@gmail.com", new DateTime(1998, 6, 1)  , 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green" , "bob@gmail.com", new DateTime(1978, 5, 2) , 1100.0, d2);
            Seller s3 = new Seller(3, "Alex Gry"    , "bob@gmail.com", new DateTime(1995, 12, 21), 1500.0, d3);
            Seller s4 = new Seller(4, "Martha Red"  , "bob@gmail.com", new DateTime(1990, 11, 12), 5000.0, d4);
            Seller s5 = new Seller(5, "Alex Pink"   , "bob@gmail.com", new DateTime(1992, 5, 26) , 1030.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed,s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 04), 1000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 13), 10000.0, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 01), 500.0, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 05), 650.0, SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 08), 5650.0, SaleStatus.Billed, s5);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6);

            _context.SaveChanges();
        }
    }
}
