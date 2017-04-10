using LogMonitoringTool.BusinessObject.AnalysisData;
using LogMonitoringTool.Commands;
using LogMonitoringTool.Common;
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

			AnalysisEditWindow analysisEditWindow = new AnalysisEditWindow( 
				new AnalysisEntity() { Id = 0 , Title = "aaaa" , Risk = "高" , RegularExpression = "aweofiij" , Info = "234234" } );
			analysisEditWindow.ShowDialog();

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

			Console.WriteLine( "delete" );

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

			List<AnalysisEntity> analysisEntities = AnalysisDataSerializationService.Load();
			List<AnalysisListDataGridItem> list = new List<AnalysisListDataGridItem>();
			if( analysisEntities != null ) {
				foreach( AnalysisEntity item in analysisEntities ) {
					list.Add( 
						new AnalysisListDataGridItem() {
							Title = item.Title ,
							LiskLevel = item.Risk ,
							RegularExpression = item.RegularExpression ,
							Detail = item.Info
						}
					);
				}
			}
			this.AnalysisDataGridItemsSource = list;

		}

	}

}
