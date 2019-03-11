using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    interface IChatService
    {
        void sendMessage(string message, string userID, string lobbyID);

        void subscribe(/*listener*/);
    }
}
