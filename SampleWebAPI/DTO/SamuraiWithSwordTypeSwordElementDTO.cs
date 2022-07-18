namespace SampleWebAPI.DTO
{
    public class SamuraiWithSwordTypeSwordElementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<SwordTypeElementDTO> Swords { get; set; }
        //public TypeSwordDTO TypeSwords { get; set; } = new TypeSwordDTO();
        
        //public List<ElementDTO> Elements { get; set; } = new List<ElementDTO>();

    }
}
