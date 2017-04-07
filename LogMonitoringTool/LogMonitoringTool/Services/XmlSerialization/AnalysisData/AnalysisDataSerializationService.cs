using LogMonitoringTool.BusinessObject.AnalysisData;
using LogMonitoringTool.Model.XmlSerialization;
using System.Collections.Generic;

namespace LogMonitoringTool.Services.XmlSerialization.AnalysisData {

	/// <summary>
	/// 解析データのXMLファイルの読み書きを行う
	/// </summary>
	public class AnalysisDataSerializationService {

		/// <summary>
		/// 解析一覧
		/// </summary>
		private static List<AnalysisEntity> Analysises = null;

		/// <summary>
		/// シリアライザー
		/// </summary>
		private static CustomXmlSerializer Serializer = new CustomXmlSerializer();

		/// <summary>
		/// ファイルパス
		/// </summary>
		private static string FilePath = @"C:\Project\LogMonitoringTool\LogMonitoringTool\LogMonitoringTool\Data\System\AnalysisData.xml";

		/// <summary>
		/// 読み込み
		/// 既にデータを読み込んでいた場合は持っているモデルを返す
		/// </summary>
		/// <returns>初回のみ外部ファイルから読み込む</returns>
		public static List<AnalysisEntity> Load() {

			if( AnalysisDataSerializationService.Analysises != null )
				return AnalysisDataSerializationService.Analysises;
			
			AnalysisDataXmlModel model = AnalysisDataSerializationService.Serializer.Load<AnalysisDataXmlModel>( AnalysisDataSerializationService.FilePath );

			if( model != null ) {
				AnalysisDataSerializationService.Analysises = new List<AnalysisEntity>();
				foreach( AnalysisDataXmlModel.ItemModel item in model.items ) {
					AnalysisDataSerializationService.Analysises.Add(
						new AnalysisEntity() {
							Id = item.no ,
							Title = item.title ,
							Risk = item.risk ,
							RegularExpression = item.regex ,
							Info = item.info
						}
					);
				}
			}

			return AnalysisDataSerializationService.Analysises;

		}

		/// <summary>
		/// 書き込み
		/// </summary>
		/// <param name="analysises">書き込むモデル</param>
		public static void Write( List<AnalysisEntity> analysises ) {

			if( analysises == null )
				return;

			AnalysisDataXmlModel model = new AnalysisDataXmlModel();
			foreach( AnalysisEntity entity in analysises ) {
				model.items.Add(
					new AnalysisDataXmlModel.ItemModel() {
						no = entity.Id ,
						title = entity.Title ,
						risk = entity.Risk ,
						regex = entity.RegularExpression ,
						info = entity.Info
					}
				);
			}
			AnalysisDataSerializationService.Serializer.Write<AnalysisDataXmlModel>( AnalysisDataSerializationService.FilePath , model );

		}

	}

}
