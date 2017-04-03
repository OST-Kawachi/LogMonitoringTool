using System;
using System.IO;
using System.Text;
using System.Windows;

namespace LogMonitoringTool.Common {

	/// <summary>
	/// 共通処理
	/// </summary>
	class Utils {

		/// <summary>
		/// ファイルパスからファイル内のテキストを取得する
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>ファイル内のテキスト</returns>
		public static string GetTextOfFile( string filePath ) {

			string resultText = "";

			try {

				//ファイルを開く
				using( StreamReader sr = new StreamReader( filePath , Encoding.GetEncoding( "Shift_JIS" ) ) ) {

					string text = "";
					string line;
					while( ( line = sr.ReadLine() ) != null ) {
						text += line + Environment.NewLine;
					}
					resultText = text;

				}

			}
			catch( Exception ) {
				MessageBox.Show( "ログファイルが開けませんでした。\nShiftJISのtxtファイルとして保存しなおし、再度確認してください。" , "エラー" , MessageBoxButton.OK , MessageBoxImage.Error );
			}

			return resultText;

		}

	}

}
