using LogMonitoringTool.Common;

namespace LogMonitoringTool.ViewModels.Analysis.Edit {

	/// <summary>
	/// AnalysisEditWindowのViewModel
	/// </summary>
	public class AnalysisEditViewModel {

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// タイトルラベル
		/// </summary>
		public string TitleLabel { get; }

		/// <summary>
		/// 危険度ラベル
		/// </summary>
		public string LiskLabel { get; }

		/// <summary>
		/// 正規表現ラベル
		/// </summary>
		public string RegularExpressionLabel { get; }

		/// <summary>
		/// 決定ボタン
		/// </summary>
		public string DecisionButtonContent { get; }

		/// <summary>
		/// キャンセル
		/// </summary>
		public string CancelButtonContent { get; }

		/// <summary>
		/// 説明ラベル
		/// </summary>
		public string DescriptionLabel { get; }

		public AnalysisEditViewModel() {

			this.TitleText = Const.FixedWording.AnalysisEditWindow.TitleWhenNewlyCreated;
			this.TitleLabel = Const.FixedWording.AnalysisEditWindow.TitleLabel;
			this.LiskLabel = Const.FixedWording.AnalysisEditWindow.LiskLabel;
			this.RegularExpressionLabel = Const.FixedWording.AnalysisEditWindow.RegularExpressionLabel;
			this.DescriptionLabel = Const.FixedWording.AnalysisEditWindow.DescriptionLabel;
			this.DecisionButtonContent = Const.FixedWording.AnalysisEditWindow.DecisionWhenNewlyCreatedButton;
			this.CancelButtonContent = Const.FixedWording.AnalysisEditWindow.CancelButton;
			
		}

	}

}
