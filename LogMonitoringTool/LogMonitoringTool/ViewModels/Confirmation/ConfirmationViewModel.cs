using LogMonitoringTool.Commands;
using LogMonitoringTool.Common;
using System.Windows;

namespace LogMonitoringTool.ViewModels.Confirmation {

	/// <summary>
	/// ConfirmationWindowのViewModel
	/// </summary>
	public class ConfirmationViewModel : ViewModelBase {

		#region 固定文言

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// 閉じるボタンテキスト
		/// </summary>
		public string CloseButtonText { get; }

		#endregion

		/// <summary>
		/// ファイルパス
		/// </summary>
		public string filePath;
		/// <summary>
		/// ファイルパス
		/// </summary>
		public string FilePath {
			set {
				SetProperty( ref this.filePath , value , "FilePath" );
			}
			get {
				return this.filePath;
			}
		}

		/// <summary>
		/// 対になるView
		/// </summary>
		private Window view;

		/// <summary>
		/// ファイル内のテキスト
		/// </summary>
		public string textOfFile;
		/// <summary>
		/// ファイル内のテキスト
		/// </summary>
		public string TextOfFile {
			set {
				SetProperty( ref this.textOfFile , value , "TextOfFile" );
			}
			get {
				return this.textOfFile;
			}
		}

		#region ウィンドウを閉じるコマンドの実装

		/// <summary>
		/// ウィンドウを閉じるコマンドの実装
		/// </summary>
		private DelegateCommand closeWindowCommand;
		/// <summary>
		/// ウィンドウを閉じるコマンドの実装
		/// </summary>
		public DelegateCommand CloseWindowCommand {
			get {
				if( this.closeWindowCommand == null )
					this.closeWindowCommand = new DelegateCommand( this.CloseWindowExecute );
				return this.closeWindowCommand;
			}
		}

		/// <summary>
		/// ウィンドウを閉じるコマンドの実装の実行イベント
		/// </summary>
		private void CloseWindowExecute() {

			this.view?.Close();

		}

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="view">対になるView</param>
		public ConfirmationViewModel( string filePath , Window view ) {

			#region 固定文言

			this.TitleText = Const.FixedWording.ConfirmationWindow.Title;
			this.CloseButtonText = Const.FixedWording.ConfirmationWindow.CloseButton;

			#endregion

			this.FilePath = filePath;
			this.view = view;

			this.TextOfFile = Utils.GetTextOfFile( filePath );

		}
		
	}

}
