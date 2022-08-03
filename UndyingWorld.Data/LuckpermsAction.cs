using System;
using System.Collections.Generic;

namespace UndyingWorld.Data
{
    public partial class LuckpermsAction
    {
        public int Id { get; set; }
        public long Time { get; set; }
        public string ActorUuid { get; set; }
        public string ActorName { get; set; }
        public string Type { get; set; }
        public string ActedUuid { get; set; }
        public string ActedName { get; set; }
        public string Action { get; set; }
    }
}
