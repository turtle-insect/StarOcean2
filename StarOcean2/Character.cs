namespace StarOcean2
{
	internal class Character
	{
		private readonly uint mAddress;

		public Character(uint address)
		{
			mAddress = address;
		}

		public uint Lv
		{
			get => SaveData.Instance().ReadNumber(mAddress, 1);
			set => Util.WriteNumber(mAddress, 1, value, 1, 99);
		}
	}
}
