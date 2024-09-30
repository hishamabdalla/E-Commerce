using E_Commerce.DataAccess.Data;
using E_Commerce.DataAccessDataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccessDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;

        public IProductRepository productRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            productRepository = new ProductRepository(db);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
