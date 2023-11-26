namespace api_programacion_3.entities.Commons;

public class Image
{
    public long Id {get; set;} = 0;

    public string Path {get; set;} = "";

    public string Url {get; set;} = "";

    public DateTime? UploadDate {get; set;} = null;
}