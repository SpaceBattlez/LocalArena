namespace SpaceBattlez.Dto
{
    public class BotDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BotDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}