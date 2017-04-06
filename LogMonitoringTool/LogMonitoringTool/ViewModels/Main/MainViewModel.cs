using LogMonitoringTool.Commands;
using LogMonitoringTool.Common;
using Microsoft.Win32;
using System;

namespace LogMonitoringTool.ViewModels.Main {

	/// <summary>
	/// MainWindowのViewModel
	/// </summary>
	public class MainViewModel : ViewModelBase {

		#region 固定文言

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

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

		#endregion

		/// <summary>
		/// 選択したログファイル
		/// </summary>
		private string selectedLogFileName;
		/// <summary>
		/// 選択したログファイル
		/// </summary>
		public string SelectedLogFileName {
			set {
				SetProperty( ref this.selectedLogFileName , value , "SelectedLogFileName" );
			}
			get {
				return this.selectedLogFileName;
			}
		}

		#region ファイル選択ダイアログを開くコマンドの実装

		/// <summary>
		/// ファイル選択ダイアログを開くコマンド
		/// </summary>
		private DelegateCommand openFileCommand;
		/// <summary>
		/// ファイル選択ダイアログを開くコマンド
		/// </summary>
		public DelegateCommand OpenFileCommand {
			get {
				if( this.openFileCommand == null )
					this.openFileCommand = new DelegateCommand( OpenFileExecute );
				return this.openFileCommand;
			}
		}
		/// <summary>
		/// ファイル選択ダイアログを開くコマンドの実行イベント
		/// </summary>
		private void OpenFileExecute() {

			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.DefaultExt = "*.*";
			if( openFileDialog.ShowDialog() == true ) {
				this.SelectedLogFileName = openFileDialog.FileName;
			}

		}

		#endregion
	
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainViewModel() {

			#region 固定文言

			this.TitleText = Const.FixedWording.MainWindow.Title;
			this.BrowseLogFileButtonContent = Const.FixedWording.MainWindow.BrowseLogFileButton;
			this.ConfirmLogButtonContent = Const.FixedWording.MainWindow.ConfirmLogButton;
			this.DisplayAnalysisListButtonContent = Const.FixedWording.MainWindow.DisplayAnalysisListButton;
			this.StartLogAnalysisButtonContent = Const.FixedWording.MainWindow.StartLogAnalysisButton;
			this.CloseButtonContent = Const.FixedWording.MainWindow.CloseButton;

			#endregion

			this.SelectedLogFileName = "";
			
		}

	}

}
