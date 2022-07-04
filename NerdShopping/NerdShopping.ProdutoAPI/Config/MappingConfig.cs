using AutoMapper;
using NerdShopping.ProdutoAPI.Data.DTO;
using NerdShopping.ProdutoAPI.Model;

namespace NerdShopping.ProdutoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapping =  new MapperConfiguration(config => {
                config.CreateMap<ProdutoDTO, Produto>();
                config.CreateMap<Produto, ProdutoDTO>();
            });

            return mapping;
        }
    }
}
