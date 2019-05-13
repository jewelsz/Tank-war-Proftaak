using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    interface IUserService
    {
        //User Login(string username, string password);
        bool register(string username, string password, string email);
    }
}
