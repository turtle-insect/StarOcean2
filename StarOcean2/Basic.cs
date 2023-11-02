namespace StarOcean2
{
	internal class Basic
	{
		public uint Money
		{
			get => SaveData.Instance().ReadNumber(0x4A4, 4);
			set => Util.WriteNumber(0x4A4, 4, value, 0, 99999999);
		}
	}
}
