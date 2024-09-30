﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccessDataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        void Save();
    }
}
