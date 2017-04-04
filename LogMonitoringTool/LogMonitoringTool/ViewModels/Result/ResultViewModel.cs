using LogMonitoringTool.Common;

namespace LogMonitoringTool.ViewModels.Result {

	/// <summary>
	/// ResultWindowのViewModel
	/// </summary>
	public class ResultViewModel {

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// 閉じるボタン
		/// </summary>
		public string CloseButtonContent { get; }

		public ResultViewModel() {

			this.TitleText = Const.FixedWording.ResultWindow.Title;
			this.CloseButtonContent = Const.FixedWording.ResultWindow.CloseButton;

		}

	}

}
