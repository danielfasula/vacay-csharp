namespace vacay_csharp.Models
{
    public class Cruise : Vacation
    {
        public string StartDestination { get; set; }

        public Cruise()
        {
            Category = "Cruise";
        }
    }
}