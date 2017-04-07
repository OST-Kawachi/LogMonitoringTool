using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LogMonitoringTool.Services.XmlSerialization {

	/// <summary>
	/// XML読み書きを行う
	/// </summary>
	public class CustomXmlSerializer {

		/// <summary>
		/// 読み込み
		/// </summary>
		/// <typeparam name="ModelBase">モデルの型</typeparam>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>モデルオブジェクト 読み込み失敗時はnull</returns>
		public ModelType Load<ModelType>( string filePath ) where ModelType : new() {

			if( filePath == null )
				return default( ModelType );

			ModelType model = new ModelType();

			try {

				using( FileStream fileStream = new FileStream( filePath , FileMode.Open ) )
				using( StreamReader streamReader = new StreamReader( fileStream , Encoding.UTF8 ) ) {
					try {
						XmlSerializer serializer = new XmlSerializer( model.GetType() );
						model = (ModelType)serializer.Deserialize( streamReader );
					}
					catch( InvalidOperationException ) {
						model = default( ModelType );
					}
				}

			}
			catch( DirectoryNotFoundException ) {
				return model = default( ModelType );
			}

			return model;

		}

		/// <summary>
		/// XML書き込み
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="model">モデル</param>
		public void Write<ModelType>( string filePath , ModelType model ) where ModelType : new() {

			if( filePath == null || model == null )
				return;

			using( FileStream fileStream = new FileStream( filePath , FileMode.Create ) )
			using( StreamWriter streamWriter = new StreamWriter( fileStream , Encoding.UTF8 ) ) {
				XmlSerializer serializer = new XmlSerializer( model.GetType() );
				serializer.Serialize( streamWriter , model );
			}
			
		}

	}

}
