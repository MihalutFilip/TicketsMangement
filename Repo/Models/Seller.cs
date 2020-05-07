using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.models
{
    [Serializable]
    public class Seller : Entity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
