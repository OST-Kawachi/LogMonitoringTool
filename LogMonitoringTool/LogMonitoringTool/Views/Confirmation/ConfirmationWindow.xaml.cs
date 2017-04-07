using LogMonitoringTool.ViewModels.Confirmation;
using System.Windows;

namespace LogMonitoringTool.Views.Analysis.Confirmation {

	/// <summary>
	/// ConfirmationWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ConfirmationWindow : Window {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		public ConfirmationWindow( string filePath ) {

			InitializeComponent();

			this.DataContext = new ConfirmationViewModel( filePath );
			
		}

		/// <summary>
		/// 閉じるボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickCloseButton( object sender , RoutedEventArgs e ) {

			this.Close();

		}
		
	}

}
