using Microsoft.AspNetCore.Mvc;
using api_programacion_3.entities.productos;
namespace api_programacion_3.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ILogger<ProductoController> _logger;

    public ProductoController(ILogger<ProductoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducto")]
    public IEnumerable<Producto> Get()
    {
        
            List<Producto> productos = new List<Producto>();

            TipoProducto categoria = new TipoProducto
        {
            Categoria = "Perro"
        };

            productos.Add(new Producto 
            {   
                Id = 1
                Title = "Piloto",
                Description = "Proteje a tu perro con la mejor capa",
                Price = 3000
                
            });

            return productos;
}
}
