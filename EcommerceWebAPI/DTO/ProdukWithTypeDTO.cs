namespace EcommerceWebAPI.DTO
{
    public class ProdukWithTypeDTO
    {
        public string Name { get; set; }
        public int Harga { get; set; }
        public int Berat { get; set; }
        public string Deskripsi { get; set; }

        public TypeCreateDTO TypeProduk { get; set; }

        //public List<KatalogCreateDTO> Katalog { get; set; }


    }
}
