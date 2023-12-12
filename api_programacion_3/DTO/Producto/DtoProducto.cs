namespace api_programacion_3.DTO.Producto;

public class DtoProducto
{   
     public long id { get; set; } = 0;

    public string title { get; set; } = "";

    public string description { get; set; } = "";

    public long price { get; set; } = 0;

    public string url { get; set;} = "";

    public long idTipoProducto { get; set; }

    public IFormFile? file {get; set;}

    
}