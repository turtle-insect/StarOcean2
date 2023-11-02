namespace StarOcean2
{
	internal class Item
	{
		private readonly uint mAddress;

		public Item(uint address)
		{
			mAddress = address;
		}

		public uint Index
		{
			get => SaveData.Instance().ReadNumber(mAddress, 2);
			set => SaveData.Instance().WriteNumber(mAddress, 2, value);
		}

		public uint ID
		{
			get => SaveData.Instance().ReadNumber(mAddress + 2, 2);
			set => SaveData.Instance().WriteNumber(mAddress + 2, 2, value);
		}

		public uint Count
		{
			get => SaveData.Instance().ReadNumber(mAddress + 4, 1);
			set => Util.WriteNumber(mAddress + 4, 1, value, 0, 99);
		}
	}
}
