using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Models.Users
{
    public class UsersQueryModel
    {
        public UsersQueryModel()
        {
            this.Users = new HashSet<UserViewModel>();
        }
        public string? SearchString { get; set; }

        public ICollection<UserViewModel> Users { get; set; }

        public int UsersCount { get; set; }

        public int AcceptedRequestsCount { get; set; }

        public int MessagesCount { get; set; }

        public int MeetingsCount { get; set; }

    }
}
