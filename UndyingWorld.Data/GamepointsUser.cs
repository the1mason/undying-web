namespace UndyingWorld.Data
{
    public partial class GamepointsUser
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public long LastOnline { get; set; }
        public string Purchases { get; set; }
        public int Balance { get; set; }
    }
}
