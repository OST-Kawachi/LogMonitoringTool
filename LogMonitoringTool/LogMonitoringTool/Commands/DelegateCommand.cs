using System;
using System.Windows.Input;

namespace LogMonitoringTool.Commands {

	/// <summary>
	/// delegateを受け取るICommandの実装
	/// </summary>
	public class DelegateCommand : ICommand {

		/// <summary>
		/// イベントハンドラ
		/// CanExecuteの結果の変化を通知
		/// </summary>
		public event EventHandler CanExecuteChanged {
			add {
				CommandManager.RequerySuggested += value;
			}
			remove {
				CommandManager.RequerySuggested -= value;
			}
		}

		/// <summary>
		/// 実行可否
		/// </summary>
		private Func<bool> canExecute;

		/// <summary>
		/// 実行イベント
		/// </summary>
		private Action execute;

		/// <summary>
		/// コンストラクタ
		/// 
		/// 実行可否の指定が無い場合はtrueを設定
		/// </summary>
		/// <param name="execute">実行イベント</param>
		public DelegateCommand( Action execute ) : this( execute , () => true ) { }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="execute">実行イベント</param>
		/// <param name="canExecute">実行可否</param>
		public DelegateCommand( Action execute , Func<bool> canExecute ) {

			if( execute == null ) {
				throw new ArgumentNullException( "execute" );
			}
			if( canExecute == null ) {
				throw new ArgumentNullException( "canExecute" );
			}

			this.execute = execute;
			this.canExecute = canExecute;

		}
		
		/// <summary>
		/// 実行可否
		/// </summary>
		/// <returns>実行可否</returns>
		public bool CanExecute() {
			return this.canExecute();
		}

		/// <summary>
		/// 実行イベント
		/// </summary>
		public void Execute() {
			this.execute();
		}

		/// <summary>
		/// ICommand.CanExecuteの明示的な実装
		/// CanExecuteメソッドに処理を委譲
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>実行可否</returns>
		bool ICommand.CanExecute(object parameter ) {
			return this.CanExecute();
		}
		
		/// <summary>
		/// ICommand.Executeの明示的な実装
		/// Executeメソッドに処理を委譲
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		void ICommand.Execute(object parameter ) {
			this.Execute();
		}
		
	}

}
