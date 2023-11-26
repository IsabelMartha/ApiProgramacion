namespace api_programacion_3.DTO.Producto;

public class DtoProducto
{   
     public long Id { get; set; } = 0;

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public long Price { get; set; } = 0;

    public string Url { get; set;} = "";

    public long IdTipoProducto { get; set; }

    public IFormFile? File {get; set;}

    
}