using LogMonitoringTool.Command.AppManipulation;
using LogMonitoringTool.Command.ShowWindow;
using LogMonitoringTool.Common;
using LogMonitoringTool.Views.Analysis.Confirmation;
using LogMonitoringTool.Views.AnalysisList;
using System.Windows.Input;

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
		/// 選択したログファイル
		/// </summary>
		public string SelectedLogFileName { set; get; }

		/// <summary>
		/// ログファイル参照ボタン表示文字
		/// </summary>
		public string BrowseLogFileButtonContent { get; }

		/// <summary>
		/// ログ内容確認ボタン表示文字
		/// </summary>
		public string ConfirmLogButtonContent { get; }

		/// <summary>
		/// 解析項目一覧表示ボタン表示文字
		/// </summary>
		public string DisplayAnalysisListButtonContent { get; }

		/// <summary>
		/// ログ解析開始ボタン
		/// </summary>
		public string StartLogAnalysisButtonContent { get; }

		/// <summary>
		/// 閉じるボタン
		/// </summary>
		public string CloseButtonContent { get; }

		/// <summary>
		/// ログ内容確認ウィンドウ表示コマンド
		/// </summary>
		public ShowWindowCommand ShowConfirmLogWindowCommand { get; }

		/// <summary>
		/// 解析項目一覧ウィンドウ表示コマンド
		/// </summary>
		public ShowWindowCommand ShowAnalysisListWindowCommand { get; }
		
		/// <summary>
		/// アプリ終了コマンド
		/// </summary>
		public ApplicationCloseCommand ApplicationCloseCommand { get; }
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainViewModel() {

			this.TitleText = Const.FixedWording.MainWindow.Title;
			this.SelectedLogFileName = "";
			this.BrowseLogFileButtonContent = Const.FixedWording.MainWindow.BrowseLogFileButton;
			this.ConfirmLogButtonContent = Const.FixedWording.MainWindow.ConfirmLogButton;
			this.DisplayAnalysisListButtonContent = Const.FixedWording.MainWindow.DisplayAnalysisListButton;
			this.StartLogAnalysisButtonContent = Const.FixedWording.MainWindow.StartLogAnalysisButton;
			this.CloseButtonContent = Const.FixedWording.MainWindow.CloseButton;

			this.ShowConfirmLogWindowCommand = new ShowWindowCommand( new ConfirmationWindow() );
			this.ShowAnalysisListWindowCommand = new ShowWindowCommand( new AnalysisListWindow() );

			this.ApplicationCloseCommand = new ApplicationCloseCommand();

		}

	}

}
