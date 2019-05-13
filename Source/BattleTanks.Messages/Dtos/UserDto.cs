using MessagePack;

namespace BattleTanks.Messages.Dtos
{
    [MessagePackObject]
    public readonly struct UserDto
    {
        [Key(0)]
        public string Name { get; }
        [Key(1)]
        public int Wins { get; }
        [Key(2)]
        public int Losses { get; }
        [IgnoreMember]
        public int WinPercentage => Wins == 0 ? 0 : Losses == 0 ? Wins : Wins / (Wins + Losses);

        public UserDto(string name, int wins, int losses)
        {
            Name = name;
            Wins = wins;
            Losses = losses;
        }
    }
}
