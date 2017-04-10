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
		/// <param name="entity">編集時に受け取るデータ</param>
		public AnalysisEditWindow( AnalysisEntity entity = null ) {

			InitializeComponent();

			this.DataContext = new AnalysisEditViewModel( this , entity );

		}
		
	}

}
