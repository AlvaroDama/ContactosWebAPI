namespace ContactosWebAPI.Models
{
    public partial class Mensaje
    {
        public virtual Usuario Origen { get; set; }
        public virtual Usuario Destino { get; set; }
    }
}
