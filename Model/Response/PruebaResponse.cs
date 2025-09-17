namespace Model.Response
{
	public class SystemParameterGetByReferenceResponse
	{
		public int i_GroupId { get; set; }
		public int i_ParameterId { get; set; }
		public string v_Value { get; set; }
		public string v_OldValue { get; set; }
		public string v_ReferenceId { get; set; }
		public int i_Visible { get; set; }
		public int i_Status { get; set; }
		public int i_Order { get; set; }
		public string v_Description { get; set; }
	}
	public class ObtenerSegurosClienteResponse
	{
		public int ClienteId { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string NumeroPoliza { get; set; }
		public string FechaInicio { get; set; }
		public string FechaFin { get; set; }
		public decimal PrimaTotal { get; set; }
		public string Placa { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public string Anio { get; set; }
		public string NumeroSerie { get; set; }
		public string TieneRenovacion { get; set; }
	}
    
	public class SeguroClienteResponse
    {
        public string Cliente { get; set; }
        public string NumeroDocumento { get; set; }
        public string Agente { get; set; }
        public string TipoPoliza { get; set; }
        public string EstadoPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrimaTotal { get; set; }
    }


}
