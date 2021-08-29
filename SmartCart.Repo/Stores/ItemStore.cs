using SmartCart.Repo.Context;
using SmartCart.Repo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCart.Repo.Stores
{
    public class ItemStore : DBStore<Item>
    {
        public ItemStore(SmartCartDBContext context) : base(context)
        {

        }
    }
}
