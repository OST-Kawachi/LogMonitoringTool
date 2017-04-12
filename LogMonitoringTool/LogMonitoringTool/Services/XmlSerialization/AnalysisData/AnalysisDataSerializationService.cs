using LogMonitoringTool.BusinessObject.AnalysisData;
using LogMonitoringTool.Model.XmlSerialization;
using System.Collections.Generic;

namespace LogMonitoringTool.Services.XmlSerialization.AnalysisData {

	/// <summary>
	/// 解析データのXMLファイルの読み書きを行う
	/// </summary>
	public class AnalysisDataSerializationService {

		/// <summary>
		/// ファイルパス
		/// </summary>
		private static string FilePath = @"C:\Project\LogMonitoringTool\LogMonitoringTool\LogMonitoringTool\Data\System\AnalysisData.xml";

		/// <summary>
		/// シングルトンパターンによりインスタンスが1つしかない事を保証する
		/// </summary>
		private static AnalysisDataSerializationService singleton = new AnalysisDataSerializationService();

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
		private AnalysisDataSerializationService() {
			
			this.serializer = new CustomXmlSerializer();

		}

		/// <summary>
		/// Serviceクラスのインスタンスを返す
		/// </summary>
		/// <returns>インスタンス</returns>
		public static AnalysisDataSerializationService GetInstance() {
			return AnalysisDataSerializationService.singleton;
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
			AnalysisDataXmlModel model = this.serializer.Load<AnalysisDataXmlModel>( AnalysisDataSerializationService.FilePath );
			if( model != null ) {
				foreach( AnalysisDataXmlModel.ItemModel item in model.items ) {
					this.analysises.Add(
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
						no = entity.Id ,
						title = entity.Title ,
						risk = entity.Risk ,
						regex = entity.RegularExpression ,
						info = entity.Info
					}
				);
			}
			this.serializer.Write<AnalysisDataXmlModel>( AnalysisDataSerializationService.FilePath , model );

		}

	}

}
