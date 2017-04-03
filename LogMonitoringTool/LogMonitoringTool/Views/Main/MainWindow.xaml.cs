using LogMonitoringTool.Views.Analysis.Confirmation;
using LogMonitoringTool.Views.AnalysisList;
using LogMonitoringTool.Views.Result;
using Microsoft.Win32;
using System;
using System.Windows;

namespace LogMonitoringTool.Views.Main {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindow() {

			InitializeComponent();

		}

		/// <summary>
		/// ログファイル参照ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickBrowseLogFileButton( object sender , RoutedEventArgs e ) {
			
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.DefaultExt = "*.*";
			if( openFileDialog.ShowDialog() == true ) {
				this.LogFileName.Content = openFileDialog.FileName;
			}
			
		}

		/// <summary>
		/// ログ確認ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickConfirmLogButton( object sender , RoutedEventArgs e ) {
			
			if( string.IsNullOrEmpty( this.LogFileName.Content as string ) ) {
				MessageBox.Show( "ログファイル参照から解析するログファイルを選択してください。" , "エラー" , MessageBoxButton.OK , MessageBoxImage.Error );
				return;
			}

			ConfirmationWindow confirmationWindow = new ConfirmationWindow( this.LogFileName.Content as string );
			confirmationWindow.ShowDialog();

		}

		/// <summary>
		/// 解析項目一覧表示ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickDisplayAnalysisListButton( object sender , RoutedEventArgs e ) {

			AnalysisListWindow analysisListWindow = new AnalysisListWindow();
			analysisListWindow.ShowDialog();

		}

		/// <summary>
		/// ログ解析開始ボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickStartLogAnalysisButton( object sender , RoutedEventArgs e ) {

			if( string.IsNullOrEmpty( this.LogFileName.Content as string ) ) {
				MessageBox.Show( "ログファイル参照から解析するログファイルを選択してください。" , "エラー" , MessageBoxButton.OK , MessageBoxImage.Error );
				return;
			}

			ResultWindow resultWindow = new ResultWindow( this.LogFileName.Content as string );
			resultWindow.ShowDialog();

		}

		/// <summary>
		/// 閉じるボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickCloseButton( object sender , RoutedEventArgs e ) {
			Environment.Exit( 0 );
		}

	}

}
