using SmartCart.Repo.Model;
using SmartCart.Repo.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCart.Repo.Repositories
{
    public class OrderItemManager : BaseManager<OrderItems>
    {
        public OrderItemManager(OrderItemStore store) : base(store)
        {
        }
    }
}
