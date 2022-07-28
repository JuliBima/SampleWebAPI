using AutoMapper;
using EcommerceWebAPI.Domain;
using EcommerceWebAPI.DTO;

namespace EcommerceWebAPI.Profiles
{
    public class EcommerceProfile : Profile
    {
        public EcommerceProfile()
        {
            CreateMap<ProdukReadDTO, Produk>();
            CreateMap<Produk, ProdukReadDTO>();

            CreateMap<ProdukTypeKatalogReadDTO, Produk>();
            CreateMap<Produk, ProdukTypeKatalogReadDTO>();
            

            CreateMap<KatalogCreateDTO, Katalog>();
            CreateMap<Katalog, KatalogCreateDTO>();

            CreateMap<KatalogReadDTO, Katalog>();
            CreateMap<Katalog, KatalogReadDTO>();

            CreateMap<TypeCreateDTO, TypeProduk>();
            CreateMap<TypeProduk, TypeCreateDTO>();

            CreateMap<TypeReadDTO, TypeProduk>();
            CreateMap<TypeProduk, TypeReadDTO>();


            CreateMap<ProdukWithTypeDTO, Produk>();
            CreateMap<Produk, ProdukWithTypeDTO>();

            CreateMap<ProdukWithTypeDTO, TypeProduk>();
            CreateMap<TypeProduk, ProdukWithTypeDTO>();

            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserCreateDTO>();

            CreateMap<UserReadDTO, User>();
            CreateMap<User, UserReadDTO>();

            CreateMap<UserUpdeteDTO, User>();
            CreateMap<User, UserUpdeteDTO>();

            CreateMap<KeranjangDTO, Keranjang>();
            CreateMap<Keranjang, KeranjangDTO>();

            CreateMap<JumlahItemDTO, Keranjang>();
            CreateMap<Keranjang, JumlahItemDTO>();

            CreateMap<HargaProukDTO, Produk>();
            CreateMap<Produk, HargaProukDTO>();



        }
    }
}
