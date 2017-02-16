using SQLite;
namespace LaudoBuilder.Model
{
	[Table("preferencia")]
	public class PreferenciaInfo
	{
		    [PrimaryKey]
			public string Preferencia { get; set; }
			public string Valor { get; set; }

            public bool ValorBool { get; set; }
            public string Titulo { get; set; }
	}
}
