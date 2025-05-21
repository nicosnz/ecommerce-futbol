using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Interfaces;
using backend_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository repository)
        {
            productRepository = repository;
        }
        public async Task<List<Product>> ObtenerProductos()
        {
            return await productRepository.ObtenerProductos();

        }
        public async Task<ActionResult<Product>> ObtenerProducto(int idProducto)
        {
            var existeProducto = await productRepository.ObtenerProducto(idProducto);
            if (existeProducto == null)
            {
                throw new ProductoNotFound(idProducto);
            }
            return existeProducto;

        }
        public async Task<Product> CrearProducto(Product producto)
        {
            var existeProducto = productRepository.ObtenerProductoPorNombre(producto.Nombre);
            if (existeProducto != null)
            {
                throw new ProductoDuplicado(producto.Nombre);
            }
            return await productRepository.CrearProducto(producto);

        }
        public async Task<Product?> ActualizarProducto(int id, Product productoActualizado)
        {
            
            var existeProducto = await productRepository.ObtenerProducto(id);
            if(existeProducto == null)
            {
                throw new ProductoNotFound(id);
            }


            existeProducto.Nombre = productoActualizado.Nombre;
            existeProducto.Descripcion = productoActualizado.Descripcion;
            existeProducto.Precio = productoActualizado.Precio;
            existeProducto.Stock = productoActualizado.Stock;
            return await productRepository.ActualizarProducto(existeProducto);

        }

    }
}