namespace EnergomerWebApp.Domain.Entity
{
    public class Field
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public Locations Locations { get; set; }
    }
}
