using LogMonitoringTool.ViewModels.Analysis.Edit;
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

			this.DataContext = new AnalysisEditViewModel( this );

		}
				
	}

}
