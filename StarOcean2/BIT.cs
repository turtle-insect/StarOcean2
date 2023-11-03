using System;

namespace StarOcean2
{
	class BIT
    {
		private readonly uint mAddress;
		private readonly uint mIndex;

		public BIT(uint address, uint index, String name)
		{
			mAddress = address;
			mIndex = index;
			Name = name;
		}

		public String Name { get; private set; }

		public bool Value
		{
			get => SaveData.Instance().ReadBit(mAddress, mIndex);
			set => SaveData.Instance().WriteBit(mAddress, mIndex, value);
		}
	}
}
