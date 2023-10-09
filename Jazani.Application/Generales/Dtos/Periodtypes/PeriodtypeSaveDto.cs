namespace Jazani.Application.Generales.Dtos.Periodtypes
{
    public class PeriodtypeSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int Time { get; set; }
    }
}
