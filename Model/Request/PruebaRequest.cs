namespace Model.Request
{
	internal class PruebaRequest
	{
	}
    public class ObtenerSegurosClienteRequest
        {
            public string TipoDocumento { get; set; }
            public string NumeroDocumento { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
        }
}
