using LogMonitoringTool.Common;
using System.Collections.Generic;

namespace LogMonitoringTool.ViewModels.Result {

	/// <summary>
	/// ResultWindowのViewModel
	/// </summary>
	public class ResultViewModel {

		#region 固定文言

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// 解析元データラベル
		/// </summary>
		public string BeforeLogLabelContent { get; }

		/// <summary>
		/// 解析後データラベル
		/// </summary>
		public string AfterLogLabelContent { get; }

		/// <summary>
		/// 閉じるボタン
		/// </summary>
		public string CloseButtonContent { get; }

		#endregion

		/// <summary>
		/// 解析結果一覧項目
		/// </summary>
		public class ResultItem {

			/// <summary>
			/// 解析前テキスト
			/// </summary>
			public string BeforeTextLine { set; get; }

			/// <summary>
			/// 解析後テキスト
			/// </summary>
			public string AfterTextLine { set; get; }

		}

		/// <summary>
		/// 解析結果一覧
		/// </summary>
		public List<ResultItem> AnalysisResultItems { set; get; }
				
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		public ResultViewModel( string filePath ) {

			#region 固定文言

			this.TitleText = Const.FixedWording.ResultWindow.Title;
			this.BeforeLogLabelContent = Const.FixedWording.ResultWindow.BeforeLogTitle;
			this.AfterLogLabelContent = Const.FixedWording.ResultWindow.AfterLogTitle;
			this.CloseButtonContent = Const.FixedWording.ResultWindow.CloseButton;

			#endregion

			this.AnalysisResultItems = new List<ResultItem>();
			this.AnalysisResultItems.Add( new ResultItem() { BeforeTextLine = "a" , AfterTextLine = "b" } );
			this.AnalysisResultItems.Add( new ResultItem() { BeforeTextLine = "a" , AfterTextLine = "b" } );
			this.AnalysisResultItems.Add( new ResultItem() { BeforeTextLine = "a" , AfterTextLine = "b" } );
			this.AnalysisResultItems.Add( new ResultItem() { BeforeTextLine = "a" , AfterTextLine = "b" } );
			this.AnalysisResultItems.Add( new ResultItem() { BeforeTextLine = "a" , AfterTextLine = "b" } );
			this.AnalysisResultItems.Add( new ResultItem() { BeforeTextLine = "a" , AfterTextLine = "b" } );

			
		}

	}

}
