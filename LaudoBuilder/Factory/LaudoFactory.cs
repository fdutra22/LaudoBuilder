using LaudoBuilder.BLL;


namespace LaudoBuilder.Factory
{
	public static class LaudoFactory
    {
		private static LaudoBLL _Laudo;

		public static LaudoBLL create()
		{
			if (_Laudo == null)
                _Laudo = new LaudoBLL();
			return _Laudo;
		}
	}
}
