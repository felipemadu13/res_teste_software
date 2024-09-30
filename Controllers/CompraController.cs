using ecommerce.Services;
using eCommerce.Domain.DTO;
using Ecommerce.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CompraController : ControllerBase
{
    private readonly CompraService _compraService;
    public CompraController(CompraService compraService)
    {
        _compraService = compraService;
    }

    [HttpPost("finalizar")]
    public async Task<ActionResult<CompraDTO>> FinalizarCompra([FromQuery] long carrinhoId, [FromQuery] long clienteId)
    {
        try
        {
            var compraDTO = await _compraService.FinalizarCompraAsync(carrinhoId, clienteId);
            return Ok(compraDTO);
        }
        catch (ArgumentException e)
        {
            return BadRequest(new CompraDTO(false, null, e.Message));
        }
        catch (InvalidOperationException e)
        {
            return Conflict(new CompraDTO(false, null, e.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, new CompraDTO(false, null, "Erro ao processar compra."));
        }
    }




}