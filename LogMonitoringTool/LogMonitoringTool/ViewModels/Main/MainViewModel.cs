using LogMonitoringTool.Common;

namespace LogMonitoringTool.ViewModels.Main {

	/// <summary>
	/// MainWindowのViewModel
	/// </summary>
	public class MainViewModel : ViewModelBase {

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainViewModel() {

			this.TitleText = Const.FixedWording.MainWindow.Title;

		}

	}

}
