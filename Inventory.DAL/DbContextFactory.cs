﻿using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL
{
   public class DbContextFactory
    {
       /// <summary>
       /// 保证EF上下文实例是线程内唯一。
       /// </summary>
       /// <returns></returns>
       public static DbContext CreateDbContext()
       {
           DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
           if (dbContext == null)
           {
               dbContext = new Entities();
               CallContext.SetData("dbContext", dbContext);
           }
           return dbContext;
       }
    }
}
