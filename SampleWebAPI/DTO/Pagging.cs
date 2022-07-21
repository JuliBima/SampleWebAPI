namespace SampleWebAPI.DTO
{
    public class Pagging
    {
        public int _maxItemPerPage { get; set; } = 10;
        private int itemPerPage;
        public int Page { get; set; } = 1;
        public int ItemPerPage 
        { 
            get => itemPerPage; 
            set => itemPerPage = value > _maxItemPerPage ? _maxItemPerPage : value;
        }

    }
}
