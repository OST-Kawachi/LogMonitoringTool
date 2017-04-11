using LogMonitoringTool.ViewModels.Result;
using System.Windows;

namespace LogMonitoringTool.Views.Result {

	/// <summary>
	/// ResultWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ResultWindow : Window {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		public ResultWindow( string filePath ) {

			InitializeComponent();

			this.DataContext = new ResultViewModel( this , filePath );

		}

	}

}
