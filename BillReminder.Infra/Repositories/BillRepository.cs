using BillReminder.Domain.Entities;
using BillReminder.Domain.Repositories;
using BillReminder.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillReminder.Infra.Repositories
{
    public class BillRepository : IRepository<Bill>
    {
        private readonly DataContext _context;

        public BillRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Bill item)
        {
            _context.Bills.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<Bill> GetAll()
        {
            return _context.Bills;
        }

        public Bill GetById(Guid id)
        {
            return _context.Bills.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Bill> GetByPeriod(DateTime date)
        {
            return _context.Bills.AsNoTracking().Where(x => x.DueDate == date).ToList();
        }

        public void Update(Guid id, Bill bill)
        {
            var item = _context.Bills.FirstOrDefault(x => x.Id == id);
            if(item != null)
                _context.Entry(bill).State = EntityState.Modified;
            _context.SaveChanges();
            
        }
    }
}
