using Microsoft.EntityFrameworkCore;
using api_programacion_3.entities.productos;
using api_programacion_3.entities.Commons;

namespace api_programacion_3.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Producto>? Produtos { get; set; }

    public DbSet<TipoProducto>? TipoProducto { get; set; }

    public DbSet<Image>? Images {get; set;}
}
