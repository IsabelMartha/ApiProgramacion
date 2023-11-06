using api_programacion_3.Data;
using api_programacion_3.entities.productos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api_programacion_3.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly DataContext dataContext;

    public ProductoController(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(long id)
    {
        if(this.dataContext != null && this.dataContext.Produtos != null)
        {
            Producto? dbProducto = await this.dataContext.Produtos.FindAsync(id);
            if(dbProducto == null)
            {
                return NotFound("Producto no encontrado");
            }

            return Ok(dbProducto);
        }

        return NotFound();
    }

    [HttpGet("{idType}")]
    public  async Task<ActionResult<List<Producto>>> Get(long idType)
    {
        List<Producto> productos = new List<Producto>();
        
        if(this.dataContext != null && this.dataContext.Produtos != null && this.dataContext.TipoProducto != null)
        {
            TipoProducto? tipoProducto = await this.dataContext.TipoProducto.FindAsync(idType);
            productos = 
                await this.dataContext.Produtos
                    .Where(producto => producto.TipoProducto == tipoProducto)
                    .ToListAsync();
        }

        return Ok(productos);
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> Post([FromBody] Producto producto)
    {
        if(this.dataContext != null && this.dataContext.Produtos != null)
        {
            await this.dataContext.Produtos.AddAsync(producto);

            await this.dataContext.SaveChangesAsync();
        }

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
            dbProducto.Img = producto.Img;
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
    