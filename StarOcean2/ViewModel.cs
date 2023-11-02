using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StarOcean2
{
	internal class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;


		public Basic Basic { get; set; } = new Basic();
		public ObservableCollection<Character> Party { get; set; } = new ObservableCollection<Character>();
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

		public CommandAction OpenFileCommand { get; set; }
		public CommandAction SaveFileCommand { get; set; }
		public CommandAction AllItemCountMaxCommand { get; set; }

		public ViewModel()
		{
			OpenFileCommand = new CommandAction(OpenFile);
			SaveFileCommand = new CommandAction(SaveFile);
			AllItemCountMaxCommand = new CommandAction(AllItemCountMax);
		}

		private void Load()
		{
			Party.Clear();
			for (uint i = 0; i < 1; i++)
			{
				Party.Add(new Character(0x988 + i * 500));
			}
			Items.Clear();
			for (uint i = 0; i < 0x37E0; i++)
			{
				var item = new Item(0x3FD4 + i * 24);
				if (item.ID == 0) continue;
				Items.Add(item);
			}
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Basic)));
		}

		private void OpenFile(Object? obj)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "savedata*|savedata*";
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Open(dlg.FileName);
			Load();
		}

		private void SaveFile(Object? obj)
		{
			SaveData.Instance().Save();
		}

		private void AllItemCountMax(Object? obj)
		{
			for (uint i = 0; i < 0x37E0; i++)
			{
				uint address = 0x3FD4 + i * 24;
				SaveData.Instance().WriteNumber(address + 2, 2, i);
				SaveData.Instance().WriteNumber(address + 4, 1, 99);
				SaveData.Instance().WriteNumber(address + 16, 1, 1);
				SaveData.Instance().WriteNumber(address + 17, 1, 1);
			}
			Load();
		}
	}
}
