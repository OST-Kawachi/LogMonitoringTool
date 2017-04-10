using LogMonitoringTool.BusinessObject.AnalysisData;
using LogMonitoringTool.BusinessObject.Risk;
using LogMonitoringTool.Commands;
using LogMonitoringTool.Common;
using LogMonitoringTool.Services.Risk;
using System.Collections.Generic;
using System.Windows;

namespace LogMonitoringTool.ViewModels.Analysis.Edit {

	/// <summary>
	/// AnalysisEditWindowのViewModel
	/// </summary>
	public class AnalysisEditViewModel : ViewModelBase {

		#region 固定文言

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
		/// 決定ボタン
		/// </summary>
		public string DecisionButtonContent { get; }

		/// <summary>
		/// キャンセル
		/// </summary>
		public string CancelButtonContent { get; }

		#endregion

		/// <summary>
		/// 危険度コンボボックスについてのService
		/// </summary>
		private RiskService riskService;

		#region コンボボックス定義

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
		/// コンボボックスのアイテム一覧を返す
		/// </summary>
		private IEnumerable<ComboItem> GetComboBoxItems() {

			List<ComboItem> list = new List<ComboItem>();
			if( this.riskService != null ) {
				foreach( RiskEntity entity in riskService.GetRiskEntities() ) {
					list.Add( new ComboItem() { Id = entity.Id , Display = entity.Title } );
				}
			}

			return list;

		}

		#endregion

		/// <summary>
		/// 対になるView
		/// </summary>
		private Window view;

		#region 入力項目

		/// <summary>
		/// タイトルテキスト
		/// </summary>
		public string AnalysisTitleText { set; get; }

		/// <summary>
		/// 危険度コンボボックスのIndex
		/// </summary>
		public int AnalysisRiskIndex { set; get; }

		/// <summary>
		/// 正規表現テキスト
		/// </summary>
		public string AnalysisRegularExpressionText { set; get; }

		/// <summary>
		/// 説明テキスト
		/// </summary>
		public string AnalysisDescriptionText { set; get; }

		/// <summary>
		/// 入力項目の初期表示
		/// </summary>
		/// <param name="editedEntity"></param>
		private void InitInputData( AnalysisEntity editedEntity ) {

			this.AnalysisTitleText = editedEntity?.Title ?? "";

			if( editedEntity != null && editedEntity.Risk != null ) {
				IEnumerable<RiskEntity> riskList = this.riskService.GetRiskEntities();
				foreach( RiskEntity entity in riskList ) {
					if( editedEntity.Risk.Equals( entity.Title ) )
						this.AnalysisRiskIndex = entity.Id;
				}
			}
			else
				this.AnalysisRiskIndex = 0;

			this.AnalysisRegularExpressionText = editedEntity?.RegularExpression ?? "";
			this.AnalysisDescriptionText = editedEntity?.Info ?? "";

		}

		#endregion

		#region 決定コマンドの実装

		/// <summary>
		/// 決定コマンドの実装
		/// </summary>
		private DelegateCommand decisionCommand;
		/// <summary>
		/// 決定コマンドの実装
		/// </summary>
		public DelegateCommand DecisionCommand {
			get {
				if( this.decisionCommand == null )
					this.decisionCommand = new DelegateCommand( this.DecisionExecute );
				return this.decisionCommand;
			}
		}

		/// <summary>
		/// 決定コマンドの実装の実行イベント
		/// </summary>
		private void DecisionExecute() {

			this.view?.Close();

		}

		#endregion

		#region キャンセルコマンドの実装

		/// <summary>
		/// キャンセルコマンドの実装
		/// </summary>
		private DelegateCommand cancelCommand;
		/// <summary>
		/// キャンセルコマンドの実装
		/// </summary>
		public DelegateCommand CancelCommand {
			get {
				if( this.cancelCommand == null )
					this.cancelCommand = new DelegateCommand( this.CancelExecute );
				return this.cancelCommand;
			}
		}

		/// <summary>
		/// キャンセルコマンドの実装の実行イベント
		/// </summary>
		private void CancelExecute() {

			this.view?.Close();

		}

		#endregion
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="view">対になるView</param>
		public AnalysisEditViewModel( Window view , AnalysisEntity editedEntity = null ) {

			#region 固定文言

			this.TitleText = Const.FixedWording.AnalysisEditWindow.TitleWhenNewlyCreated;
			this.TitleLabel = Const.FixedWording.AnalysisEditWindow.TitleLabel;
			this.LiskLabel = Const.FixedWording.AnalysisEditWindow.LiskLabel;
			this.RegularExpressionLabel = Const.FixedWording.AnalysisEditWindow.RegularExpressionLabel;
			this.DescriptionLabel = Const.FixedWording.AnalysisEditWindow.DescriptionLabel;
			this.DecisionButtonContent = Const.FixedWording.AnalysisEditWindow.DecisionWhenNewlyCreatedButton;
			this.CancelButtonContent = Const.FixedWording.AnalysisEditWindow.CancelButton;

			#endregion

			this.view = view;
			this.riskService = new RiskService();
			this.LiskItemsSource = this.GetComboBoxItems();
			this.InitInputData( editedEntity );

		}

	}

}
