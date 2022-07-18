namespace SampleWebAPI.DTO
{
    public class SamuraiWithSwordDTO
    {
        public SamuraiCreateDTO Samurai { get; set; }
        public List<SwordCreateDTO> Swords { get; set; }
    }
}
