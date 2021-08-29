using SmartCart.Repo.Context;
using SmartCart.Repo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCart.Repo.Stores
{
    public class OrderStore : DBStore<Order>
    {
        public OrderStore(SmartCartDBContext context) : base(context)
        {

        }
    }
}
