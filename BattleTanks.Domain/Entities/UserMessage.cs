using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTanks.Domain.Entities
{
    public class UserMessage
    {
        public int UserId { get; set; }
        public string Content { get; set; }

        public UserMessage(int userId, string content)
        {
            UserId = userId;
            Content = content;
        }
    }
}
