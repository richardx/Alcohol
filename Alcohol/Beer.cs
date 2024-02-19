namespace Alcohol
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Abv { get; set; }


        // Copy constructor
        public Beer(Beer other)
        {
            Id = other.Id;
            Name = other.Name;
            Abv = other.Abv;
        }

        // Default constructor
        public Beer()
        {
        }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Abv: {Abv}";
        }
        // Validerer at Abv er mellem 0 og 67
        public void ValidateAbv()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentOutOfRangeException("Abv skal være mellem 0 og 67.");
            }
        }
        // Validerer at Name ikke er null og at det er mindst 3 karaktere
        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("Name må ikke være null.");
            }
            if (Name.Length <= 3)
            {
                throw new ArgumentOutOfRangeException("Name skal være min 3 karaktere");
            }
        }


    }
}
