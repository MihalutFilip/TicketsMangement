using System;

namespace Repository.models
{
    [Serializable]
    public class Match : Entity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int PlacesRemaining { get; set; }

        public String ToString()
        {
            return Name + " " + Price.ToString() + " " + PlacesRemaining.ToString();
        }
    }
}
