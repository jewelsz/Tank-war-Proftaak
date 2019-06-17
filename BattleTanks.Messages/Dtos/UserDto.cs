using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace BattleTanks.Messages.Dtos
{
    public struct UserDto
    {
        [YamlMember(Alias = "userId")]
        public int Id { get; set; }
        [YamlMember(Alias = "name")]
        public string Name { get; set; }
        [YamlMember(Alias = "wins")]
        public int Wins { get; set; }
        [YamlMember(Alias = "losses")]
        public int Losses { get; set; }
        [YamlIgnore, JsonIgnore]
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
