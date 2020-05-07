using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.models
{
    [Serializable]
    public class Client : Entity<int>
    {
        public int Id { get ; set; }
        public string Name { get; set; }
    }
}
