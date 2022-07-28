namespace EcommerceWebAPI.DTO
{
    public class ProdukTypeKatalogReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Harga { get; set; }
        public int Berat { get; set; }
        public string Deskripsi { get; set; }

        public TypeReadDTO TypeProduk { get; set; }

        public List<KatalogReadDTO> Katalogs { get; set; }
    }
}
