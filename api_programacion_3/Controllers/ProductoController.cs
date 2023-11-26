using System.Diagnostics.CodeAnalysis;
using api_programacion_3.Data;
using System.Net;
using api_programacion_3.entities.productos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api_programacion_3.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{

    [NotNull]
    private readonly DataContext dataContext;

    public ProductoController(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

   [HttpGet("{id}")] 
   public async Task<ActionResult<Producto>> GetProducto(long id)
   {
        
        Producto? dbProducto = await this.dataContext.Produtos.FindAsync(id);
        if(dbProducto == null)
        {
            return NotFound("Producto no encontrado");
        }
        return Ok(dbProducto);

   }

    [HttpGet("type/{id}")]
    public  async Task<ActionResult<List<Producto>>> Get(long id)
    {
        List<Producto> produtos = new List<Producto>();
        
    
            TipoProducto? tipoProducto = await this.dataContext.TipoProducto.FindAsync(id);
            produtos = 
                await this.dataContext.Produtos
                    .Where(producto => producto.TipoProducto == tipoProducto)
                    .ToListAsync();
        

        return Ok(produtos);
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> Post([FromBody] Producto producto)
    {
        
            await this.dataContext.Produtos.AddAsync(producto);

            await this.dataContext.SaveChangesAsync();


        return Ok(producto);
    }

[HttpPut("{id}")]
    public async Task<ActionResult<Producto>> Put(
        [FromRoute]long id, 
        [FromBody] Producto producto)
    {
        if(this.dataContext != null && this.dataContext.Produtos != null)
        {
            Producto? dbProducto = await this.dataContext.Produtos.FindAsync(id);
            if(dbProducto == null)
            {
                return NotFound("Producto no encontrado");
            }

            dbProducto.Title = producto.Title;
            dbProducto.Description = producto.Description;
            dbProducto.Price = producto.Price;
            dbProducto.Image = producto.Image;
            dbProducto.TipoProducto = producto.TipoProducto;

            await this.dataContext.SaveChangesAsync();

            return Ok(dbProducto);
        }

        return BadRequest("Error");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        if(this.dataContext != null && this.dataContext.Produtos != null)
        {
            Producto? dbProducto = await this.dataContext.Produtos.FindAsync(id);
            if(dbProducto == null)
            {
                return NotFound("Producto no encontrado");
            }

            dataContext.Produtos.Remove(dbProducto);

            await this.dataContext.SaveChangesAsync();
        }

        return Ok();
    }

    
}
    