﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMvc.Models
{
    public class Seller
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecord { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }


        public void AddSales(SalesRecord sale)
        {
            SalesRecord.Add(sale);
        }

        public void RemoveSales(SalesRecord sale)
        {
            SalesRecord.Remove(sale);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecord.Where(sale => sale.Date >= initial && sale.Date <= final).Sum(sale => sale.Amount);
        }


    }
}
