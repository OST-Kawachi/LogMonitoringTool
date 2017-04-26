using System.Collections.Generic;
using System.Xml.Serialization;

namespace LogMonitoringTool.Model.XmlSerialization {

	/// <summary>
	/// AnalysisData.xmlのモデル
	/// </summary>
	[ XmlRoot( "root" ) ]
	public class AnalysisDataXmlModel {

		/// <summary>
		/// item
		/// </summary>
		public class ItemModel {

			/// <summary>
			/// 連番
			/// </summary>
			[ XmlAttribute( "no" ) ]
			public int no;

			/// <summary>
			/// タイトル
			/// </summary>
			[ XmlAttribute( "title" ) ]
			public string title;

			/// <summary>
			/// 危険度
			/// </summary>
			[ XmlAttribute( "risk" ) ]
			public int risk;

			/// <summary>
			/// 正規表現
			/// </summary>
			[ XmlAttribute( "regex" ) ]
			public string regex;

			/// <summary>
			/// 詳細
			/// </summary>
			[ XmlAttribute( "info" ) ]
			public string info;

		}

		/// <summary>
		/// 項目一覧
		/// </summary>
		[ XmlArray( "items" ) , XmlArrayItem( "item" ) ]
		public List<ItemModel> items = new List<ItemModel>();
		
	}

}
