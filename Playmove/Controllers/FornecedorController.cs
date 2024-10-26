using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Playmove.Models;

namespace Playmove.Controllers
{
    [ApiController]
    [Route("api")]
    public class FornecedorController(PlaymoveDataContext context) : Controller
    {
        readonly PlaymoveDataContext db = context;

        [HttpGet]
        [Route("fornecedores")]
        public IActionResult GetFornecedores()
        {
            var result = db.Fornecedor;
            if (result.IsNullOrEmpty() )
            {
                return NotFound("nenhum registro de fornecedor encontrado");
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("fornecedores/{id}")]
        public IActionResult GetFornecedorId(int id)
        {
            var result = db.Find<Fornecedor>(id);
            if (result == null)
            {
                return NotFound("registro com id: " + id + " não encontrado");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("fornecedores")]
        public IActionResult PostFornecedor(string name, string email)
        {
            int result;
            try
            {
                db.Add(new Fornecedor() { Nome = name, Email = email });
                result = db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
            if (result <= 0)
            {
                return Problem(detail: "não foi possível adicionar registro ao banco", statusCode: 500);
            }
            return Ok("novo fornecedor: " + name + " foi adicionado ao banco");
        }

        [HttpPut]
        [Route("fornecedores/{id}")]
        public IActionResult PutFornecedor(int id, string name="", string email="")
        {
            int result;
            try
            {
                db.Update(new Fornecedor() { Id = id, Nome = name, Email = email });
                result = db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
            if (result <= 0)
            {
                return Problem(detail: "não foi possível atualizar registro de id: "+id, statusCode: 500);
            }
            return Ok("fornecedor de id "+id+" atualizado");
        }

        [HttpDelete]
        [Route("fornecedores/{id}")]
        public IActionResult DeleteFornecedor(int id)
        {
            int result;
            try
            {
                db.Remove(new Fornecedor() { Id = id, Nome = "", Email = "" });
                result = db.SaveChanges();
            }
            catch (Exception ex) 
            {
                return Problem(detail:ex.Message, statusCode: 500);
            }
            if (result <= 0)
            {
                return Problem(detail: "não foi possível deletar registro de id: " + id, statusCode: 500);
            }
            return Ok("fornecedor de id " + id + " deletado");
        }
    }
}
