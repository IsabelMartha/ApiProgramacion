namespace api_programacion_3.entities.productos;

public class Producto 
{
    private string img;

    public string Img 
    {
        get
        {
            return this.img;
        }
        set 
        {
            this.img = value;
        }
    }

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

    private TipoProducto tipoproducto; 

    public TipoProducto TipoProducto
    {
        get 
        {
            return this.tipoproducto;
        }

        set 
        {
            this.tipoproducto = value;
        }
    }


}