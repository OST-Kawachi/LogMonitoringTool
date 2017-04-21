﻿using LogMonitoringTool.BusinessObject.AnalysisData;
using LogMonitoringTool.BusinessObject.Risk;
using LogMonitoringTool.Commands;
using LogMonitoringTool.Common;
using LogMonitoringTool.Services.Risk;
using LogMonitoringTool.Services.XmlSerialization.AnalysisData;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

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

			/// <summary>
			/// 背景色
			/// </summary>
			public string BackgroundColor { set; get; }

		}

		/// <summary>
		/// 解析結果一覧
		/// </summary>
		public List<ResultItem> AnalysisResultItems { set; get; }

		/// <summary>
		/// 対になるView
		/// </summary>
		private Window view;
		
		#region ウィンドウを閉じるコマンドの実装

		/// <summary>
		/// ウィンドウを閉じるコマンドの実装
		/// </summary>
		private DelegateCommand closeWindowCommand;
		/// <summary>
		/// ウィンドウを閉じるコマンドの実装
		/// </summary>
		public DelegateCommand CloseWindowCommand {
			get {
				if( this.closeWindowCommand == null )
					this.closeWindowCommand = new DelegateCommand( this.CloseWindowExecute );
				return this.closeWindowCommand;
			}
		}

		/// <summary>
		/// ウィンドウを閉じるコマンドの実装の実行イベント
		/// </summary>
		private void CloseWindowExecute() {

			this.view?.Close();

		}

		#endregion

		/// <summary>
		/// 受け取ったテキストの1行を解析して返す
		/// </summary>
		/// <param name="line">解析前テキストの1行</param>
		/// <param name="result">解析したテキストの1行</param>
		/// <param name="color">解析したテキストの色</param>
		private void GetResultOfAnalysis( string line , out string result , out string color ) {

			RiskService riskService = RiskService.GetInstance();

			result = line;
			color = "White";

			AnalysisDataService analysisSservice = AnalysisDataService.GetInstance();

			foreach( AnalysisEntity analysisEntity in analysisSservice.Load() ) {
				if( Regex.IsMatch( line , analysisEntity.RegularExpression ) ) {
					result = analysisEntity.Title;
					foreach( RiskEntity riskEntity in riskService.GetRiskEntities() ) {
						if( analysisEntity.Risk.Equals( riskEntity.Title ) ) {
							color = "#00FF44";
							break;
						}
					}
					break;
				}
			}

		}

		/// <summary>
		/// 受け取ったファイル内のテキストを1行ずつ解析して解析前と解析後の一覧を返す
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>解析前と解析後の一覧</returns>
		private List<ResultItem> GetAnalysisResultItems( string filePath ) {

			List<ResultItem> list = new List<ResultItem>();

			string textOfFile = Utils.GetTextOfFile( filePath );
			foreach( string line in textOfFile.Split( '\n' ) ) {
				string result;
				string color;
				this.GetResultOfAnalysis( line , out result , out color );
				list.Add( new ResultItem() { BeforeTextLine = line , AfterTextLine = result , BackgroundColor = color } );
			}

			return list;

		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="view">対になるView</param>
		/// <param name="filePath">ファイルパス</param>
		public ResultViewModel( Window view , string filePath ) {

			#region 固定文言

			this.TitleText = Const.FixedWording.ResultWindow.Title;
			this.BeforeLogLabelContent = Const.FixedWording.ResultWindow.BeforeLogTitle;
			this.AfterLogLabelContent = Const.FixedWording.ResultWindow.AfterLogTitle;
			this.CloseButtonContent = Const.FixedWording.ResultWindow.CloseButton;

			#endregion

			this.view = view;
			this.AnalysisResultItems = this.GetAnalysisResultItems( filePath );
				
		}

	}

}
