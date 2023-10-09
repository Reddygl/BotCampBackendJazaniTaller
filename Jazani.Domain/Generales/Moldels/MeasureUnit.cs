namespace Jazani.Domain.Generales.Moldels
{
    public class MeasureUnit
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
