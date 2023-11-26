using api_programacion_3.entities.Commons;
namespace api_programacion_3.entities.productos;

public class Producto 
{   
     public long Id { get; set; } = 0;

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public long Price { get; set; } = 0;

    public TipoProducto? TipoProducto { get; set; } = null;

    public Image? Image { get; set; } = null;

    
}