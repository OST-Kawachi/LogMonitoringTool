using LogMonitoringTool.Common;
using LogMonitoringTool.Model.XmlSerialization;
using LogMonitoringTool.Services.XmlSerialization;
using System.Collections.Generic;

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
		/// 一覧ヘッダー部のタイトル
		/// </summary>
		public string TitleHeader { get; }

		/// <summary>
		/// 一覧ヘッダー部の危険度
		/// </summary>
		public string LiskHeader { get; }

		/// <summary>
		/// 一覧ヘッダー部の正規表現
		/// </summary>
		public string RegularExpressionHeader { get; }

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
		/// 解析項目
		/// </summary>
		public class AnalysisListDataGridItem {

			/// <summary>
			/// タイトル
			/// </summary>
			public string Title { set; get; }

			/// <summary>
			/// リスク
			/// </summary>
			public string LiskLevel { set; get; }

			/// <summary>
			/// 正規表現
			/// </summary>
			public string RegularExpression { set; get; }

			/// <summary>
			/// 詳細
			/// </summary>
			public string Detail { set; get; }

		}

		/// <summary>
		/// 一覧のItemsSource
		/// </summary>
		public List<AnalysisListDataGridItem> AnalysisDataGridItemsSource { set; get; }

		/// <summary>
		/// XML読み書きService
		/// </summary>
		private XmlSerializationService xmlSerializationService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AnalysisListViewModel() {

			this.TitleText = Const.FixedWording.AnalysisListWindow.Title;
			this.TitleHeader = Const.FixedWording.AnalysisListWindow.TitleHeader;
			this.LiskHeader = Const.FixedWording.AnalysisListWindow.LiskHeader;
			this.RegularExpressionHeader = Const.FixedWording.AnalysisListWindow.RegularExpressionHeader;
			this.NewCreationButtonContent = Const.FixedWording.AnalysisListWindow.NewCreationButton;
			this.EditButtonContent = Const.FixedWording.AnalysisListWindow.EditButton;
			this.DeleteButtonContent = Const.FixedWording.AnalysisListWindow.DeleteButton;
			this.CloseButtonContent = Const.FixedWording.AnalysisListWindow.CloseButton;

			this.xmlSerializationService = XmlSerializationService.GetInstance();

			List<AnalysisListDataGridItem> list = new List<AnalysisListDataGridItem>();
			if( this.xmlSerializationService?.model?.items != null ) {
				foreach( AnalysisDataXmlModel.ItemModel item in this.xmlSerializationService.model.items ) {
					list.Add( 
						new AnalysisListDataGridItem() {
							Title = item.title ,
							LiskLevel = item.risk ,
							RegularExpression = item.regex ,
							Detail = item.info
						}
					);
				}
			}
			this.AnalysisDataGridItemsSource = list;

		}

	}

}
