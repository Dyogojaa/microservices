using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NerdShopping.ProdutoAPI.Data.DTO;
using NerdShopping.ProdutoAPI.Model;
using NerdShopping.ProdutoAPI.Model.Context;

namespace NerdShopping.ProdutoAPI.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly MySQLContext _context;
        private readonly IMapper _mapper;


        public ProdutoRepositorio(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> FindAll()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutoDTO>>(produtos);

        }

        public async Task<ProdutoDTO> FindById(long id)
        {
            Produto produto = await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<ProdutoDTO> Create(ProdutoDTO produto)
        {
            Produto prod = _mapper.Map<Produto>(produto);    

            _context.Produtos.Add(prod);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoDTO>(prod);
        }

        public async Task<ProdutoDTO> Update(ProdutoDTO produto)
        {
            Produto prod = _mapper.Map<Produto>(produto);

            _context.Produtos.Update(prod);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoDTO>(prod);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Produto produto = await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (produto != null)
                {
                    _context.Produtos.Remove(produto);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
