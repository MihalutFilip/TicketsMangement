using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.models
{
    [Serializable]
    public class Ticket : Entity<Tuple<int, int>>
    {
        public Tuple<int, int> Id { get; set; }
        public int PlacesTaken { get; set; }
    }
}
