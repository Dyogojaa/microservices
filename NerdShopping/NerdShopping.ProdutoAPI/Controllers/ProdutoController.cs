using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerdShopping.ProdutoAPI.Data.DTO;
using NerdShopping.ProdutoAPI.Repositorio;

namespace NerdShopping.ProdutoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoController(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio ??  
                throw new ArgumentException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> FindAll()
        {
            var produto = await _repositorio.FindAll();
            if (produto == null)  return NotFound();
            return Ok(produto);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> FindById(long id)
        {
            var produto = await _repositorio.FindById(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }


        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Create(ProdutoDTO produto)
        {

            if (produto == null) return BadRequest();
            var prod = await _repositorio.Create(produto);            
            return Ok(prod);
        }


        [HttpPut]
        public async Task<ActionResult<ProdutoDTO>> Update(ProdutoDTO produto)
        {

            if (produto == null) return BadRequest();
            var prod = await _repositorio.Update(produto);
            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(long id)
        {
            var status = await _repositorio.Delete(id);
            if (!status)
                return BadRequest();
            else
                return Ok(status);

        }
    }
}
