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

    [HttpGet("{idType}")]
    public async Task<ActionResult<List<Producto>>> Get(long idType)
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

    
}
    