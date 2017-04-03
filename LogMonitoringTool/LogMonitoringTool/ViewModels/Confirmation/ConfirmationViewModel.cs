using LogMonitoringTool.Common;

namespace LogMonitoringTool.ViewModels.Confirmation {

	/// <summary>
	/// ConfirmationWindowのViewModel
	/// </summary>
	public class ConfirmationViewModel {

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// 閉じるボタンテキスト
		/// </summary>
		public string CloseButtonText { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ConfirmationViewModel() {

			this.TitleText = Const.FixedWording.ConfirmationWindow.Title;
			this.CloseButtonText = Const.FixedWording.ConfirmationWindow.CloseButton;

		}
		
	}

}
