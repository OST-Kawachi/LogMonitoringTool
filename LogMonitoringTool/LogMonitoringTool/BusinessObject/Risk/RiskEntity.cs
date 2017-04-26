using System.Windows.Media;

namespace LogMonitoringTool.BusinessObject.Risk {

	/// <summary>
	/// リスクについてのEntity
	/// </summary>

	public class RiskEntity {

		/// <summary>
		/// ID
		/// </summary>
		public int Id { set; get; }

		/// <summary>
		/// リスク名
		/// </summary>
		public string Title { set; get; }

		/// <summary>
		/// 色
		/// </summary>
		public Color RiskColor { set; get; }

	}

}
