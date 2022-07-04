using NerdShopping.ProdutoAPI.Data.DTO;

namespace NerdShopping.ProdutoAPI.Repositorio
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<ProdutoDTO>> FindAll();
        Task<ProdutoDTO> FindById(long id);
        Task<ProdutoDTO> Create(ProdutoDTO produto);
        Task<ProdutoDTO> Update(ProdutoDTO produto);
        Task<bool> Delete(long id);

    }
}
