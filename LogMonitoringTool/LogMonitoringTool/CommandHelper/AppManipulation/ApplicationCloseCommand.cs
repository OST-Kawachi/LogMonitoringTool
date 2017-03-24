using System;
using System.Windows;
using System.Windows.Input;

namespace LogMonitoringTool.Command.AppManipulation {

	/// <summary>
	/// アプリ終了コマンド
	/// </summary>
	public class ApplicationCloseCommand : ICommand {

		/// <summary>
		/// イベント
		/// </summary>
		public event EventHandler CanExecuteChanged;

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
		/// アプリを終了する
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute( object parameter ) {

			try {

				Application.Current.MainWindow.Close();

			}
			catch( InvalidOperationException ) { }

		}

	}

}
