namespace StarOcean2
{
	internal class Util
	{
		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value > max) value = max;
			if (value < min) value = min;
			SaveData.Instance().WriteNumber(address, size, value);
		}
	}
}
