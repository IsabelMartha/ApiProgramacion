using System.Diagnostics.CodeAnalysis;
using api_programacion_3.Data;
using System.Net;
using api_programacion_3.entities.productos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_programacion_3.DTO.Producto;
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
    public async Task<ActionResult<Producto>> Post(
        [FromForm] DtoProducto dtoProducto)
    {
        if (dtoProducto.File == null)
        {
            return BadRequest("Archivo no valido");
        }

        string path = await SaveFile(dtoProducto);

        Producto producto = await CreateProducto(dtoProducto, path);

        await SaveProductoDB(producto);

        return Ok();
    }

    private async Task SaveProductoDB(Producto producto)
    {
        await this.dataContext.Produtos.AddAsync(producto);

        await this.dataContext.SaveChangesAsync();
    }

    private async Task<Producto> CreateProducto(DtoProducto dtoProducto, string path)
    {   TipoProducto? tipoProducto = 
    await this.dataContext
    .TipoProducto.FindAsync(dtoProducto.IdTipoProducto);
        return new Producto
        {
            Description = dtoProducto.Description,
            Image = new entities.Commons.Image
            {
                Path = path,
                UploadDate = DateTime.Now,
                Url = ""
            },
            Title = dtoProducto.Title,
            Price = dtoProducto.Price,
            TipoProducto = tipoProducto

        };
    }

    private static async Task<string> SaveFile(DtoProducto dtoProducto)
    {
        string path = Path.Combine
                (Directory.GetCurrentDirectory(),
                "Archivos",
                dtoProducto.File.FileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await dtoProducto.File.CopyToAsync(stream);
        }

        return path;
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
    