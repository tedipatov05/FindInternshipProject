using FindInternship.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Test.Mock
{
    public class DbMock
    {
        public static FindInternshipDbContext Instance
        {
            get
            {
                var options = new DbContextOptionsBuilder<FindInternshipDbContext>()
                    .UseInMemoryDatabase("FindInternshipInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

                return new FindInternshipDbContext(options, false);
            }
        }
    }
}
