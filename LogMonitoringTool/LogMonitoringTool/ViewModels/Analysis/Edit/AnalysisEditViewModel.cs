using LogMonitoringTool.BusinessObject.Risk;
using LogMonitoringTool.Common;
using LogMonitoringTool.Services.Risk;
using System.Collections.Generic;

namespace LogMonitoringTool.ViewModels.Analysis.Edit {

	/// <summary>
	/// AnalysisEditWindowのViewModel
	/// </summary>
	public class AnalysisEditViewModel : ViewModelBase {

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
		/// 説明ラベル
		/// </summary>
		public string DescriptionLabel { get; }

		/// <summary>
		/// コンボボックスのアイテム
		/// </summary>
		public class ComboItem {

			/// <summary>
			/// Id
			/// </summary>
			public int Id { set; get; }

			/// <summary>
			/// 表示項目
			/// </summary>
			public string Display { set; get; }

		}

		/// <summary>
		/// コンボボックスの一覧
		/// </summary>
		private IEnumerable<ComboItem> liskItemsSource;
		/// <summary>
		/// コンボボックスの一覧
		/// </summary>
		public IEnumerable<ComboItem> LiskItemsSource {
			set { SetProperty<IEnumerable<ComboItem>>( ref this.liskItemsSource , value , "LiskItemsSource" ); }
			get { return liskItemsSource; }
		}
		
		/// <summary>
		/// 決定ボタン
		/// </summary>
		public string DecisionButtonContent { get; }

		/// <summary>
		/// キャンセル
		/// </summary>
		public string CancelButtonContent { get; }

		public AnalysisEditViewModel() {

			this.TitleText = Const.FixedWording.AnalysisEditWindow.TitleWhenNewlyCreated;
			this.TitleLabel = Const.FixedWording.AnalysisEditWindow.TitleLabel;
			this.LiskLabel = Const.FixedWording.AnalysisEditWindow.LiskLabel;
			this.RegularExpressionLabel = Const.FixedWording.AnalysisEditWindow.RegularExpressionLabel;
			this.DescriptionLabel = Const.FixedWording.AnalysisEditWindow.DescriptionLabel;
			this.DecisionButtonContent = Const.FixedWording.AnalysisEditWindow.DecisionWhenNewlyCreatedButton;
			this.CancelButtonContent = Const.FixedWording.AnalysisEditWindow.CancelButton;

			RiskService riskService = new RiskService();
			List<ComboItem> list = new List<ComboItem>();
			foreach( RiskEntity entity in riskService.GetRiskEntities() ) {
				list.Add( new ComboItem() { Id = entity.Id , Display = entity.Title } );
			}
			this.LiskItemsSource = list;

		}

	}

}
