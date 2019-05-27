using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankWar.Messages.Dtos
{
    [Serializable]
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int WinPercentage => Wins == 0 ? 0 : Losses == 0 ? Wins : Wins / (Wins + Losses);
        public UserDto(int id, string name, int wins, int losses)
        {
            Id = id;
            Name = name;
            Wins = wins;
            Losses = losses;
        }
    }
}

