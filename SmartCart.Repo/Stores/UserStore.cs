using SmartCart.Repo.Context;
using SmartCart.Repo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCart.Repo.Stores
{
    public class UserStore : DBStore<User>
    {
        public UserStore(SmartCartDBContext context) : base(context)
        {

        }
    }
}
