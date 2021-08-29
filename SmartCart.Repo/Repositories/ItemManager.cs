using SmartCart.Repo.Model;
using SmartCart.Repo.Repositories.Interfaces;
using SmartCart.Repo.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCart.Repo.Repositories
{
    public class ItemManager : BaseManager<Item>
    {
        public ItemManager(ItemStore store) : base(store)
        {
        }

        //Add Items specific operations here
    }
}
