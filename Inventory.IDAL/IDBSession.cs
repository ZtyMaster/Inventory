﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.IDAL
{
   public partial interface IDBSession
    {
       //IUserInfoDal UserInfoDal { get; set;}
       bool SaveChanges();
    }
}
