﻿using E_Commerce.Models.OrderFile;
using E_Commerce.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccessDataAccess.Repository.IRepository
{
    public interface IOrderLineRepository:IRepository<OrderLine>
    {
        
        void Update(OrderLine obj);

    }
}
