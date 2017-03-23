using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LogMonitoringTool.ViewModels {

	/// <summary>
	/// INotifyPropertyChanged実装クラス
	/// 全てのViewModelはこのクラスを継承すること
	/// </summary>
	public class ViewModelBase : INotifyPropertyChanged {

		/// <summary>
		/// プロパティ変化イベント
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		protected ViewModelBase() { }

		/// <summary>
		/// プロパティの変更を通知
		/// この通知メソッドを受けてView側の値が変化する
		/// </summary>
		/// <param name="propertyName">プロパティ名</param>
		protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null ) {
			this.PropertyChanged?.Invoke( this , new PropertyChangedEventArgs( propertyName ) );
		}

		/// <summary>
		/// プロパティ値設定
		/// 
		/// ViewModelのプロパティにおいて、
		/// setterの中で値を代入する場合には
		/// 代わりにこのメソッドを呼ぶ
		/// 
		/// 値が代入された場合、既に代入されている値と比較して、同じでない場合はOnPropertyChangedメソッドを呼ぶ
		/// </summary>
		/// <typeparam name="T">フィールドの型</typeparam>
		/// <param name="field">変更するフィールド</param>
		/// <param name="value">設定する値</param>
		/// <param name="propertyName">プロパティ名</param>
		/// <returns>プロパティに設定できたかどうかの判定</returns>
		protected virtual bool SetProperty<T>( ref T field , T value , [CallerMemberName] string propertyName = null ) {

			if( object.Equals( field , value ) )
				return false;

			field = value;
			this.OnPropertyChanged( propertyName );
			return true;

		}

	}

}
