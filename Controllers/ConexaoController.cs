
using Biblioteca.Data;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/conexao")]
public class ConexaoController : ControllerBase
{
    private readonly ConexaoBanco _conexaoBanco;

    public ConexaoController(ConexaoBanco conexaoBanco)
    {
        _conexaoBanco = conexaoBanco;
    }

    [HttpGet("testar")]
    public async Task<IActionResult> Testar()
    {
        bool conectou = await _conexaoBanco.TestarAsync();

        return Ok(
            new
            {
                mensagem = conectou
                    ? "Conexão com o banco de dados da biblioteca realizada com sucesso."
                    : "Não foi possível conectar ao banco de dados da biblioteca."
            }
        );
    }
}
