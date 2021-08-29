using SmartCart.Repo.Model;
using SmartCart.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartCart.UnitTest
{
    public class OrderManagerTest
    {
        public FakeOrderManager orderManager { get; set; }
        public OrderManagerTest()
        {
            orderManager = new FakeOrderManager(new FakeDBStore<Order>());
        }

        [Fact]
        public async Task TestInsert()
        {
            var insert = await orderManager.Insert(new Order() { Id = 1, OrderDate = DateTime.UtcNow,  TotalCost = 100 });
            var element = (await orderManager.GetAll()).Where(x => x.Id == 1).FirstOrDefault();
            Assert.NotNull(element);

        }

    }
}
