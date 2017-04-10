using LogMonitoringTool.Common;

namespace LogMonitoringTool.ViewModels.Result {

	/// <summary>
	/// ResultWindowのViewModel
	/// </summary>
	public class ResultViewModel {

		#region 固定文言

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// 解析元データラベル
		/// </summary>
		public string BeforeLogLabelContent { get; }

		/// <summary>
		/// 解析後データラベル
		/// </summary>
		public string AfterLogLabelContent { get; }

		/// <summary>
		/// 閉じるボタン
		/// </summary>
		public string CloseButtonContent { get; }

		#endregion

		public ResultViewModel() {

			#region 固定文言

			this.TitleText = Const.FixedWording.ResultWindow.Title;
			this.BeforeLogLabelContent = Const.FixedWording.ResultWindow.BeforeLogTitle;
			this.AfterLogLabelContent = Const.FixedWording.ResultWindow.AfterLogTitle;
			this.CloseButtonContent = Const.FixedWording.ResultWindow.CloseButton;

			#endregion
		}

	}

}
