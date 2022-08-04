namespace UndyingWorld.Data
{
    public partial class Authme
    {
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Realname { get; set; }
        public string Password { get; set; }
        public string Ip { get; set; }
        public long? Lastlogin { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string World { get; set; }
        public long Regdate { get; set; }
        public string Regip { get; set; }
        public float? Yaw { get; set; }
        public float? Pitch { get; set; }
        public string Email { get; set; }
        public short IsLogged { get; set; }
        public short HasSession { get; set; }
        public string Totp { get; set; }
    }
}
