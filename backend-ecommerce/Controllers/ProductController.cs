using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Interfaces;
using backend_ecommerce.Models;
using backend_ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_ecommerce.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<Product>>GetProductos()
    {
        return await _service.ObtenerProductos();
    }

    [HttpGet("{idProducto:int}")]

    public async Task<ActionResult<Product>> GetProducto(int idProducto)
    {
        try
        {
            var producto = await _service.ObtenerProducto(idProducto);
            return Ok(producto);
        }
        catch (ProductoNotFound ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProducto(Product producto)
    {
        try
        {
            var nuevoProducto = await _service.CrearProducto(producto);
            return CreatedAtAction(nameof(GetProducto), new { idProducto = nuevoProducto.Id }, nuevoProducto);

        }
        catch (ProductoDuplicado ex)
        {
            return Conflict(new { mensaje = ex.Message });
        }
    }
    [HttpPut("{id:int}")]
    public async  Task<ActionResult>PutCustomer(int id,Product producto)
    {
        var updatedProducto = await _service.ActualizarProducto(id, producto);
        return CreatedAtAction(nameof(GetProducto), new { idcustomer = updatedProducto.Id }, updatedProducto);
    }

        
}
