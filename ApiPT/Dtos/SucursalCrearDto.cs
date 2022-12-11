namespace ApiPT.Dtos
{
    public class SucursalCrearDto
    {
        public string Calle { get; set; } = null!;
        public int Numero { get; set; }
        public string Localidad { get; set; } = null!;
        public int IdProvincia { get; set; }
    }
}
