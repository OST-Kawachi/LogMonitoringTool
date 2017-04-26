namespace LogMonitoringTool.BusinessObject.AnalysisData {

	/// <summary>
	/// 解析項目についてのEntity
	/// </summary>
	public class AnalysisEntity {

		/// <summary>
		/// ID
		/// </summary>
		public int Id { set; get; }
		
		/// <summary>
		/// タイトル
		/// </summary>
		public string Title { set; get; }

		/// <summary>
		/// 危険度
		/// </summary>
		public int Risk { set; get; }

		/// <summary>
		/// 正規表現
		/// </summary>
		public string RegularExpression { set; get; }

		/// <summary>
		/// 詳細
		/// </summary>
		public string Info { set; get; }
		
	}

}
