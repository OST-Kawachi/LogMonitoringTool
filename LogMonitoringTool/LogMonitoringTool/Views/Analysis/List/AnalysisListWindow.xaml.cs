using LogMonitoringTool.ViewModels.Analysis.List;
using LogMonitoringTool.Views.Analysis.Edit;
using System.Windows;

namespace LogMonitoringTool.Views.AnalysisList {

	/// <summary>
	/// AnalysisListWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class AnalysisListWindow : Window {
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AnalysisListWindow() {

			InitializeComponent();

			this.DataContext = new AnalysisListViewModel( this );

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
				
	}

}
