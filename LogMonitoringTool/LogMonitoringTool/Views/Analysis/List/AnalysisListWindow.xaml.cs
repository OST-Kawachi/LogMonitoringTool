using LogMonitoringTool.ViewModels.Analysis.List;
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
						
	}

}
