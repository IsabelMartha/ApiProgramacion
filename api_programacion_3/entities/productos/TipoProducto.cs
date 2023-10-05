namespace api_programacion_3.entities.productos;

public class TipoProducto
{

    private string title;

    public string Title
    {
        get
        {
            return this.title;
        }
        set 
        {
            this.title = value;
        }
    }
    
    private string description;

    public string Description 
    {
        get
        {
            return this.description;
        }
        set 
        {
            this.description = value;
        }
    }

    private long price;

    public long Price 
    {
        get
        {
            return this.price;
        }
        set 
        {
            this.price = value;
        }
    }

    private string categoria;

    public string Categoria 
    {
        get
        {
            return this.categoria;
        }
        set 
        {
            this.categoria = value;
        }
    }
}