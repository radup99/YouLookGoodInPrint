using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouLookGoodInPrint.Server.Data;

namespace YouLookGoodInPrint.Tests.Server
{
    class FakeDatabase : Database
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(@"fakedatabase");
        }
    }
}
