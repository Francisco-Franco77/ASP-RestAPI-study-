using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Playmove.Models;

namespace Playmove.Controllers
{
    /// <summary>
    /// Realiza operações CRUD na tabela dbo.fornecedor
    /// </summary>
    /// <param name="context"></param>
    [ApiController]
    [Route("api")]
    public class FornecedorController(PlaymoveDataContext context) : Controller
    {
        readonly PlaymoveDataContext db = context;

        /// <summary>
        /// Busca todos os fornecedores na tabela dbo.fornecedor
        /// </summary>
        /// <returns>json listando dados de todos os fornecedores</returns>
        /// <response code="200">Fornecedores encontrados</response>
        /// <response code="500">Erro ao acessar o banco de dados</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("fornecedores")]
        public IActionResult GetFornecedores()
        {
            try
            {
                var result = db.Fornecedor;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }

        }

        /// <summary>
        /// Busca um fornecedor na tabela dbo.fornecedor
        /// </summary>
        /// <param name="id">Id do fornecedor, correspondente na tabela</param>
        /// <returns>json contendo dados de um fornecedor</returns>
        /// <response code="200">Fornecedor encontrado</response>
        /// <response code="404">Fornecedor não encontrado</response>
        /// <response code="500">Erro ao acessar o banco de dados</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("fornecedores/{id}")]
        public IActionResult GetFornecedorId(int id)
        {
            try
            {
                var result = db.Find<Fornecedor>(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        /// <summary>
        /// Adiciona um fornecedor à tabela dbo.fornecedor
        /// </summary>
        /// <param name="name">Nome do fornecedor</param>
        /// <param name="email">Email do fornecedor</param>
        /// <returns>Confirmação que um novo fornecedor foi adicionado</returns>
        /// <response code="200">Fornecedor criado</response>
        /// <response code="500">Erro ao acessar o banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Atualiza um fornecedor à tabela dbo.fornecedor
        /// </summary>
        /// <param name="id">Id do fornecedor a ser atualizado</param>
        /// <param name="name">Nome a ser atualizado</param>
        /// <param name="email">Email a ser atualizado</param>
        /// <returns>Confirmação que o fornecedor foi atualizado</returns>
        /// <response code="200">Fornecedor atualizado</response>
        /// <response code="500">Erro ao acessar o banco de dados</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("fornecedores/{id}")]
        public IActionResult PutFornecedor(int id, string name="", string email="")
        {
            int result;
            try
            {
                Fornecedor fornecedor = db.Find<Fornecedor>(id);
                if (!name.IsNullOrEmpty())
                    fornecedor.Nome = name;
                if(!email.IsNullOrEmpty())
                    fornecedor.Email = email;
                db.Update(fornecedor);
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

        /// <summary>
        /// Deleta um fornecedor da tabela dbo.fornecedor
        /// </summary>
        /// <param name="id">Id do fornecedor a ser deletado</param>
        /// <returns>Confirmação de exclusão do fornecedor</returns>
        /// <response code="200">Fornecedor deletado</response>
        /// <response code="500">Erro ao acessar o banco de dados</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
