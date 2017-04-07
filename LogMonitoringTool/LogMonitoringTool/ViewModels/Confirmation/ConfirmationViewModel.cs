using LogMonitoringTool.Common;

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

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ConfirmationViewModel( string filePath ) {

			#region 固定文言

			this.TitleText = Const.FixedWording.ConfirmationWindow.Title;
			this.CloseButtonText = Const.FixedWording.ConfirmationWindow.CloseButton;

			#endregion

			this.FilePath = filePath;
			this.TextOfFile = Utils.GetTextOfFile( filePath );

		}
		
	}

}
