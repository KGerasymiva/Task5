using System;

namespace DAL.Models
{
    public class Plane : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufactured { get; set; }
        public string TimeUsed { get; set; }
    }
}
