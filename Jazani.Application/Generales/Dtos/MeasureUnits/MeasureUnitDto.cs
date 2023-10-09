namespace Jazani.Application.Generales.Dtos.MeasureUnits
{
    public class MeasureUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
