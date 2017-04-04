using LogMonitoringTool.Common;

namespace LogMonitoringTool.ViewModels.Analysis.List {

	/// <summary>
	/// AnalysisListWindowのViewModel
	/// </summary>
	public class AnalysisListViewModel {

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// 新規ボタン
		/// </summary>
		public string NewCreationButtonContent { get; }

		/// <summary>
		/// 編集ボタン
		/// </summary>
		public string EditButtonContent { get; }

		/// <summary>
		/// 削除ボタン
		/// </summary>
		public string DeleteButtonContent { get; }

		/// <summary>
		/// 閉じるボタン
		/// </summary>
		public string CloseButtonContent { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AnalysisListViewModel() {

			this.TitleText = Const.FixedWording.AnalysisListWindow.Title;
			this.NewCreationButtonContent = Const.FixedWording.AnalysisListWindow.NewCreationButton;
			this.EditButtonContent = Const.FixedWording.AnalysisListWindow.EditButton;
			this.DeleteButtonContent = Const.FixedWording.AnalysisListWindow.DeleteButton;
			this.CloseButtonContent = Const.FixedWording.AnalysisListWindow.CloseButton;

		}

	}

}
