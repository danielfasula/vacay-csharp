namespace vacay_csharp.Models
{
    public class Trip : Vacation
    {
        public string EndDestination { get; set; }
        public Trip()
        {
            Category = "Trip";
        }
    }
}