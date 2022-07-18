namespace SampleWebAPI.DTO
{
    public class SwordTypeElementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

        public TypeSwordDTO TypeSwords { get; set; }

        public List<ElementDTO> Elements { get; set; }
    }
}
