using SmartCart.Repo.Model;
using SmartCart.Repo.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCart.Repo.Repositories
{
    public class OrderManager : BaseManager<Order>
    {
        public OrderManager(OrderStore store) : base(store)
        {
        }
    }
}
