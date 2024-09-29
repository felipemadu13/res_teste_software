using System.Collections.Generic;
using Ecommerce.Entity;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Product A", Price = 10.0m },
        new Product { Id = 2, Name = "Product B", Price = 20.0m }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(Products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = Products.Find(p => p.Id == id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult Add(Product product)
    {
        Products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}
