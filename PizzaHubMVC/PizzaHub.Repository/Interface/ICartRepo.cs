﻿using PizzaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Repository.Interface
{
    public interface ICartRepo
    {
        string AddItemotCart(int productId, Guid cartId);
        List<ProductModel> GetProductsByCartId(Guid cartid);
    }
}