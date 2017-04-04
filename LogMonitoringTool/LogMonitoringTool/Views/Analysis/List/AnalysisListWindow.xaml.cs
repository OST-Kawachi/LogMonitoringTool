using LogMonitoringTool.Services.XmlSerialization;
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
