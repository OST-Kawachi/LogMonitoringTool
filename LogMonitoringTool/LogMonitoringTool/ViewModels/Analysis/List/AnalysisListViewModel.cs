using LogMonitoringTool.BusinessObject.AnalysisData;
using LogMonitoringTool.Commands;
using LogMonitoringTool.Common;
using LogMonitoringTool.Services.Risk;
using LogMonitoringTool.Services.XmlSerialization.AnalysisData;
using LogMonitoringTool.Views.Analysis.Edit;
using System;
using System.Collections.Generic;
using System.Windows;

namespace LogMonitoringTool.ViewModels.Analysis.List {

	/// <summary>
	/// AnalysisListWindowのViewModel
	/// </summary>
	public class AnalysisListViewModel : ViewModelBase {

		#region 固定文言

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

		#endregion

		/// <summary>
		/// 解析項目
		/// </summary>
		public class AnalysisListDataGridItem {

			/// <summary>
			/// ID
			/// </summary>
			public int Id { set; get; }

			/// <summary>
			/// タイトル
			/// </summary>
			public string Title { set; get; }

			/// <summary>
			/// リスク
			/// </summary>
			public string RiskLevel { set; get; }

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
		/// 一覧上で選択しているItem
		/// </summary>
		private AnalysisListDataGridItem selectedAnalysisItem;

		/// <summary>
		/// 一覧上で選択しているItem
		/// </summary>
		public AnalysisListDataGridItem SelectedAnalysisItem {
			set {
				this.SetProperty<AnalysisListDataGridItem>( ref this.selectedAnalysisItem , value , "SelectedAnalysisItem" );
			}
			get {
				return this.selectedAnalysisItem;
			}
		}

		/// <summary>
		/// 一覧のItemsSource
		/// </summary>
		private List<AnalysisListDataGridItem> analysisDataGridItemsSource;
		/// <summary>
		/// 一覧のItemsSource
		/// </summary>
		public List<AnalysisListDataGridItem> AnalysisDataGridItemsSource {
			set {
				this.SetProperty<List<AnalysisListDataGridItem>>( ref this.analysisDataGridItemsSource , value , "AnalysisDataGridItemsSource" );
			}
			get {
				return this.analysisDataGridItemsSource;
			}
		}
		
		/// <summary>
		/// 対になるView
		/// </summary>
		private Window view;
		
		#region 解析項目新規追加コマンドの実装

		/// <summary>
		/// 解析項目新規追加コマンドの実装
		/// </summary>
		private DelegateCommand newCreationAnalysisCommand;
		/// <summary>
		/// 解析項目新規追加コマンドの実装
		/// </summary>
		public DelegateCommand NewCreationAnalysisCommand {
			get {
				if( this.newCreationAnalysisCommand == null )
					this.newCreationAnalysisCommand = new DelegateCommand( this.NewCreationAnalysisExecute );
				return this.newCreationAnalysisCommand;
			}
		}

		/// <summary>
		/// 解析項目新規追加コマンドの実装の実行イベント
		/// </summary>
		private void NewCreationAnalysisExecute() {

			AnalysisEditWindow analysisEditWindow = new AnalysisEditWindow();
			analysisEditWindow.ShowDialog();
			this.ItemsSourceUpdate();

		}

		#endregion

		#region 解析項目編集コマンドの実装

		/// <summary>
		/// 解析項目編集コマンドの実装
		/// </summary>
		private DelegateCommand editAnalysisCommand;
		/// <summary>
		/// 解析項目編集コマンドの実装
		/// </summary>
		public DelegateCommand EditAnalysisCommand {
			get {
				if( this.editAnalysisCommand == null )
					this.editAnalysisCommand = new DelegateCommand( this.EditAnalysisExecute );
				return this.editAnalysisCommand;
			}
		}

		/// <summary>
		/// 解析項目編集コマンドの実装の実行イベント
		/// </summary>
		private void EditAnalysisExecute() {

			if( this.SelectedAnalysisItem == null )
				return;

			RiskService riskService = RiskService.GetInstance();

			AnalysisEditWindow analysisEditWindow = new AnalysisEditWindow( 
				new AnalysisEntity() {
					Id = this.SelectedAnalysisItem.Id ,
					Title = this.SelectedAnalysisItem.Title ,
					Risk = riskService.GetRiskId( this.SelectedAnalysisItem.RiskLevel ) ,
					RegularExpression = this.SelectedAnalysisItem.RegularExpression ,
					Info = this.SelectedAnalysisItem.Detail
				} 
			);
			analysisEditWindow.ShowDialog();
			this.ItemsSourceUpdate();

		}

		#endregion

		#region 解析項目削除コマンドの実装

		/// <summary>
		/// 解析項目削除コマンドの実装
		/// </summary>
		private DelegateCommand deleteAnalysisCommand;
		/// <summary>
		/// 解析項目削除コマンドの実装
		/// </summary>
		public DelegateCommand DeleteAnalysisCommand {
			get {
				if( this.deleteAnalysisCommand == null )
					this.deleteAnalysisCommand = new DelegateCommand( this.DeleteAnalysisExecute );
				return this.deleteAnalysisCommand;
			}
		}

		/// <summary>
		/// 解析項目削除コマンドの実装の実行イベント
		/// </summary>
		private void DeleteAnalysisExecute() {

			if( this.SelectedAnalysisItem == null )
				return;

			AnalysisDataService service = AnalysisDataService.GetInstance();
			List<AnalysisEntity> entities = service.Load();
			for( int i = 0 ; i < entities.Count ; i++ ) {
				if( entities[i].Id == this.SelectedAnalysisItem.Id ) {
					entities.RemoveAt( i );
					break;
				}
			}
			service.Write( entities );

			this.ItemsSourceUpdate();
			
		}

		#endregion
		
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
		/// ItemsSourceを更新する
		/// </summary>
		private void ItemsSourceUpdate() {

			AnalysisDataService analysisDataService = AnalysisDataService.GetInstance();
			RiskService riskService = RiskService.GetInstance();

			List<AnalysisEntity> analysisEntities = analysisDataService.Load();
			List<AnalysisListDataGridItem> list = new List<AnalysisListDataGridItem>();
			if( analysisEntities != null ) {
				foreach( AnalysisEntity item in analysisEntities ) {
					list.Add(
						new AnalysisListDataGridItem() {
							Id = item.Id ,
							Title = item.Title ,
							RiskLevel = riskService.GetRiskEntity( item.Risk )?.Title ?? "" ,
							RegularExpression = item.RegularExpression ,
							Detail = item.Info
						}
					);
				}
			}
			this.AnalysisDataGridItemsSource = list;

		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AnalysisListViewModel( Window view ) {

			#region 固定文言

			this.TitleText = Const.FixedWording.AnalysisListWindow.Title;
			this.TitleHeader = Const.FixedWording.AnalysisListWindow.TitleHeader;
			this.LiskHeader = Const.FixedWording.AnalysisListWindow.LiskHeader;
			this.RegularExpressionHeader = Const.FixedWording.AnalysisListWindow.RegularExpressionHeader;
			this.NewCreationButtonContent = Const.FixedWording.AnalysisListWindow.NewCreationButton;
			this.EditButtonContent = Const.FixedWording.AnalysisListWindow.EditButton;
			this.DeleteButtonContent = Const.FixedWording.AnalysisListWindow.DeleteButton;
			this.CloseButtonContent = Const.FixedWording.AnalysisListWindow.CloseButton;

			#endregion

			this.view = view;

			this.ItemsSourceUpdate();

		}

	}

}
