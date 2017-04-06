using System.Windows;

namespace LogMonitoringTool.Views.Analysis.Edit {

	/// <summary>
	/// AnalysisEditWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class AnalysisEditWindow : Window {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AnalysisEditWindow() {

			InitializeComponent();

		}

		/// <summary>
		/// 決定ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickDecisionButton( object sender , RoutedEventArgs e ) {

			this.Close();

		}

		/// <summary>
		/// キャンセルボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickCancelButton( object sender , RoutedEventArgs e ) {

			this.Close();

		}

	}

}
