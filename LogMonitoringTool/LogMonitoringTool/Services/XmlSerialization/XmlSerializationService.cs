using LogMonitoringTool.Model.XmlSerialization;
using System;
using System.IO;
using System.Xml.Serialization;

namespace LogMonitoringTool.Services.XmlSerialization {

	/// <summary>
	/// XMLの読み書きを行うServiceクラス
	/// </summary>
	public class XmlSerializationService {

		/// <summary>
		/// XML Model
		/// </summary>
		public AnalysisDataXmlModel model;

		/// <summary>
		/// シングルトン
		/// </summary>
		private static XmlSerializationService singleton = new XmlSerializationService();

		/// <summary>
		/// ファイルパス
		/// </summary>
		private const string FileName = @"C:\Project\LogMonitoringTool\LogMonitoringTool\LogMonitoringTool\Data\AnalysisFile\AnalysisData.xml";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private XmlSerializationService() {

			try {
				using( FileStream fileStream = new FileStream( FileName , FileMode.Open ) ) {
					XmlSerializer serializer = new XmlSerializer( typeof( AnalysisDataXmlModel ) );
					this.model = (AnalysisDataXmlModel)serializer.Deserialize( fileStream );
				}
			}
			catch( Exception ) { }

		}

		/// <summary>
		/// インスタンスを返す
		/// </summary>
		/// <returns></returns>
		public static XmlSerializationService GetInstance() {
			return singleton;
		}

		/// <summary>
		/// 今のXML ModelをXMLファイルに書き込む
		/// </summary>
		public void Write() {

			using( FileStream fileStream = new FileStream( FileName , FileMode.Create ) ) {
				XmlSerializer serializer = new XmlSerializer( typeof( AnalysisDataXmlModel ) );
				serializer.Serialize( fileStream , this.model );
			}

		}

	}

}
