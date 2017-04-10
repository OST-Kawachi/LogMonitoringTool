using LogMonitoringTool.BusinessObject.AnalysisData;
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

			this.DataContext = new AnalysisEditViewModel( this , 
				new AnalysisEntity() { Id = 0 , Title = "aaaa" , Risk = "高" , RegularExpression = "aweofiij" , Info = "234234" } );

		}
				
	}

}
