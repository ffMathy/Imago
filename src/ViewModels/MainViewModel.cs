using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Imago.Models;
using Imago.Services.Interfaces;

namespace Imago.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly IHistoryService historyService;
		public ObservableCollection<CapturedMedia> CapturedMediaHistory { get; } = new ObservableCollection<CapturedMedia>();

		public MainViewModel(IHistoryService historyService)
		{
			this.historyService = historyService;

			FillCaptureHistory();
		}

		private async void FillCaptureHistory() =>
			(await historyService.GetHistory()).ToList().ForEach(CapturedMediaHistory.Add);
	}
}
