using System;
using System.Windows;
using System.Windows.Input;

namespace LogMonitoringTool.Command.ShowWindow {

	/// <summary>
	/// モーダルダイアログを表示するコマンド
	/// </summary>
	public class ShowWindowCommand : ICommand {
		
		/// <summary>
		/// イベント
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// 別ウィンドウ
		/// </summary>
		private Window window;

		/// <summary>
		/// コンストラクタ
		/// 引数より表示させるウィンドウを受け取る
		/// </summary>
		/// <param name="window">表示させる別ウィンドウ</param>
		public ShowWindowCommand( Window window ) {
			this.window = window;
		}

		/// <summary>
		/// 実行可否
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute( object parameter ) {
			return true;
		}

		/// <summary>
		/// 実行
		/// モーダルで別ウィンドウを表示
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute( object parameter ) {
			try {
				this.window.ShowDialog();
			}
			catch( InvalidOperationException ) { }
		}
	}

}
