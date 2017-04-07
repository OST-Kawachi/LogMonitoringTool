using LogMonitoringTool.Model.XmlSerialization;

namespace LogMonitoringTool.Services.XmlSerialization.AnalysisData {

	/// <summary>
	/// 解析データのXMLファイルの読み書きを行う
	/// </summary>
	public class AnalysisDataSerializationService {

		/// <summary>
		/// モデル
		/// </summary>
		private static AnalysisDataXmlModel Model = null;

		/// <summary>
		/// シリアライザー
		/// </summary>
		private static CustomXmlSerializer Serializer = new CustomXmlSerializer();

		/// <summary>
		/// ファイルパス
		/// </summary>
		private static string FilePath = @"C:\Project\LogMonitoringTool\LogMonitoringTool\LogMonitoringTool\Data\AnalysisFile\AnalysisData.xml";

		/// <summary>
		/// 読み込み
		/// 既にデータを読み込んでいた場合は持っているモデルを返す
		/// </summary>
		/// <returns>初回のみ外部ファイルから読み込む</returns>
		public static AnalysisDataXmlModel Load() {

			if( AnalysisDataSerializationService.Model != null )
				return AnalysisDataSerializationService.Model;
			
			AnalysisDataSerializationService.Model = AnalysisDataSerializationService.Serializer.Load<AnalysisDataXmlModel>( AnalysisDataSerializationService.FilePath );
			return AnalysisDataSerializationService.Model;

		}

		/// <summary>
		/// 書き込み
		/// </summary>
		/// <param name="model">書き込むモデル</param>
		public static void Write( AnalysisDataXmlModel model ) {
			
			AnalysisDataSerializationService.Model = model;
			AnalysisDataSerializationService.Serializer.Write<AnalysisDataXmlModel>( AnalysisDataSerializationService.FilePath , AnalysisDataSerializationService.Model );

		}

	}

}
