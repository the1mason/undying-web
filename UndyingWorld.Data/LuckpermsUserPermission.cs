using System;
using System.Collections.Generic;

namespace UndyingWorld.Data
{
    public partial class LuckpermsUserPermission
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Permission { get; set; }
        public bool Value { get; set; }
        public string Server { get; set; }
        public string World { get; set; }
        public long Expiry { get; set; }
        public string Contexts { get; set; }
    }
}
