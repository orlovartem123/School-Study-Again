namespace MobileClient.Models.Medals
{
    public class Medal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public int? ElectiveId { get; set; }

        public string ElectiveName { get; set; }
    }
}
