namespace SEDC.BurgerApp.DAL.Models
{
    public class Location : BaseEntity
    {
        protected Location() { }

        public Location(string name, string address, DateTime opensAt, DateTime closesAt)
        {
            Name = name;
            Address = address;
            OpensAt = opensAt;
            ClosesAt = closesAt;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime OpensAt { get; set; }
        public DateTime ClosesAt { get; set; }
    }
}
