
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //construtores
        public Department()
        {
        }

        public Department(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public void RemoveSeller(Seller seller)
        {
            Sellers.Remove(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
