using LogMonitoringTool.BusinessObject.AnalysisData;
using LogMonitoringTool.Common.XmlSerialization;
using LogMonitoringTool.Model.XmlSerialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace LogMonitoringTool.Services.XmlSerialization.AnalysisData {

	/// <summary>
	/// 解析データのXMLファイルの読み書きを行う
	/// </summary>
	public class AnalysisDataService {

		/// <summary>
		/// 相対ファイルパス
		/// </summary>
		private static string RelativeFilePath = @"\Data\System\AnalysisData.xml";

		/// <summary>
		/// シングルトンパターンによりインスタンスが1つしかない事を保証する
		/// </summary>
		private static AnalysisDataService singleton = new AnalysisDataService();

		/// <summary>
		/// 解析一覧
		/// </summary>
		private List<AnalysisEntity> analysises;

		/// <summary>
		/// シリアライザー
		/// </summary>
		private CustomXmlSerializer serializer;

		/// <summary>
		/// コンストラクタ
		/// シングルトンなので外からは呼び出されない
		/// </summary>
		private AnalysisDataService() {

			Console.WriteLine( Directory.GetCurrentDirectory() );
			
			this.serializer = new CustomXmlSerializer();

		}
		
		/// <summary>
		/// Serviceクラスのインスタンスを返す
		/// </summary>
		/// <returns>インスタンス</returns>
		public static AnalysisDataService GetInstance() {
			return AnalysisDataService.singleton;
		}
		
		/// <summary>
		/// 読み込み
		/// 既にデータを読み込んでいた場合は持っているモデルを返す
		/// </summary>
		/// <returns>初回のみ外部ファイルから読み込む</returns>
		public List<AnalysisEntity> Load() {

			if( this.analysises != null )
				return this.analysises;

			this.analysises = new List<AnalysisEntity>();
			AnalysisDataXmlModel model = this.serializer.Load<AnalysisDataXmlModel>( Directory.GetCurrentDirectory() + AnalysisDataService.RelativeFilePath );
			if( model != null ) {
				foreach( AnalysisDataXmlModel.ItemModel item in model.items ) {
					this.analysises.Add(
						new AnalysisEntity() {
							Id = item.id ,
							Title = item.title ,
							Risk = item.risk ,
							RegularExpression = item.regex ,
							Info = item.info
						}	
					);
				}
			}
			return this.analysises;

		}

		/// <summary>
		/// 書き込み
		/// </summary>
		/// <param name="analysises">書き込むモデル</param>
		public void Write( List<AnalysisEntity> analysises ) {

			if( analysises == null )
				return;

			AnalysisDataXmlModel model = new AnalysisDataXmlModel();
			foreach( AnalysisEntity entity in analysises ) {
				model.items.Add(
					new AnalysisDataXmlModel.ItemModel() {
						id = entity.Id ,
						title = entity.Title ,
						risk = entity.Risk ,
						regex = entity.RegularExpression ,
						info = entity.Info
					}
				);
			}
			this.serializer.Write<AnalysisDataXmlModel>( Directory.GetCurrentDirectory() + AnalysisDataService.RelativeFilePath , model );

		}

	}

}
