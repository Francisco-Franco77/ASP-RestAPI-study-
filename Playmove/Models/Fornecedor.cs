namespace Playmove.Models
{
    /// <summary>
    /// Modelo referente à tabela dbo.fornecedor
    /// </summary>
    public class Fornecedor
    {
        /// <summary>
        /// Id (chave primária) do fornecedor
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do fornecedor
        /// </summary>
        public required string Nome { get; set; }
        /// <summary>
        /// Email do fornecedor
        /// </summary>
        public required string Email { get; set; }
    }
}
