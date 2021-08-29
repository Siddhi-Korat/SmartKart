using SmartCart.Repo.Model;
using SmartCart.Repo.Repositories;
using SmartCart.Repo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCart.UnitTest
{
    public class FakeOrderManager : BaseManager<Order> 
    {
        public FakeOrderManager(FakeDBStore<Order> store) : base(store)
        {

        }
    }
}
