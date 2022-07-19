namespace SampleWebAPI.DTO
{
    public class SwordWithTypeCreateDTO
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SamuraiId { get; set; }
        public TypeSwordReadDTO TypeSwords { get; set; }
    }
}
