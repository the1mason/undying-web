using System;
using System.Collections.Generic;

namespace UndyingWorld.Data
{
    public partial class PunishmentHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uuid { get; set; }
        public string Reason { get; set; }
        public string Operator { get; set; }
        public string PunishmentType { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Calculation { get; set; }
    }
}
