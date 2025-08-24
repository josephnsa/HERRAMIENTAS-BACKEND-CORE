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
}
