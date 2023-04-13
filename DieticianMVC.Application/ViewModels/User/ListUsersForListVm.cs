using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieticianMVC.Application.ViewModels.User
{
    public class ListUsersForListVm
    {
        public List<UserForListVm> Users { get; set; }
        public int Count { get; set; }
    }
}
