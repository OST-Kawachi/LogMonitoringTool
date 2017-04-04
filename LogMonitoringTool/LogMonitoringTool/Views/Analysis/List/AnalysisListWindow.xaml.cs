using LogMonitoringTool.Services.XmlSerialization;
using LogMonitoringTool.Views.Analysis.Edit;
using System.Windows;

namespace LogMonitoringTool.Views.AnalysisList {

	/// <summary>
	/// AnalysisListWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class AnalysisListWindow : Window {

		/// <summary>
		/// 解析項目
		/// </summary>
		private class AnalysisListDataGridItem {

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
		/// XML読み書きService
		/// </summary>
		XmlSerializationService service;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AnalysisListWindow() {

			InitializeComponent();

			this.service = XmlSerializationService.GetInstance();

			this.AnalysisListDataGrid.ItemsSource = new[] {
				new AnalysisListDataGridItem() { Title = "タイトル" , LiskLevel = "危険度" , RegularExpression = "正規表現" , Detail = "詳細" } ,
				new AnalysisListDataGridItem() { Title = "タイトル" , LiskLevel = "危険度" , RegularExpression = "正規表現" , Detail = "詳細" } ,
				new AnalysisListDataGridItem() { Title = "タイトル" , LiskLevel = "危険度" , RegularExpression = "正規表現" , Detail = "詳細" } ,
				new AnalysisListDataGridItem() { Title = "タイトル" , LiskLevel = "危険度" , RegularExpression = "正規表現" , Detail = "詳細" } ,
				new AnalysisListDataGridItem() { Title = "タイトル" , LiskLevel = "危険度" , RegularExpression = "正規表現" , Detail = "詳細" }
			};

		}

		/// <summary>
		/// 新規作成ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickNewCreationButton( object sender , RoutedEventArgs e ) {

			AnalysisEditWindow analysisEditWindow = new AnalysisEditWindow();
			analysisEditWindow.ShowDialog();

		}

		/// <summary>
		/// 編集ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickEditButton( object sender , RoutedEventArgs e ) {

			AnalysisEditWindow analysisEditWindow = new AnalysisEditWindow();
			analysisEditWindow.ShowDialog();

		}

		/// <summary>
		/// 削除ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickDeleteButton( object sender , RoutedEventArgs e ) { }

		/// <summary>
		/// 閉じるボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickCloseButton( object sender , RoutedEventArgs e ) { }
		
	}

}
