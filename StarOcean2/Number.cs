using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarOcean2
{
	internal class Number
	{
		private readonly uint mAddress;
		private readonly uint mSize;
		private readonly uint mMin;
		private readonly uint mMax;

		public Number(uint address, uint size, uint min, uint max)
		{
			mAddress = address;
			mSize = size;
			mMin = min;
			mMax = max;
		}

		public String Name { get; set; } = "";

		public uint Value
		{
			get => SaveData.Instance().ReadNumber(mAddress, mSize);
			set => Util.WriteNumber(mAddress, mSize, value, mMin, mMax);
		}
	}
}
