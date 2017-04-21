﻿using LogMonitoringTool.Commands;
using LogMonitoringTool.Common;
using LogMonitoringTool.Views.Analysis.Confirmation;
using LogMonitoringTool.Views.AnalysisList;
using LogMonitoringTool.Views.Result;
using Microsoft.Win32;
using System;
using System.Windows;

namespace LogMonitoringTool.ViewModels.Main {

	/// <summary>
	/// MainWindowのViewModel
	/// </summary>
	public class MainViewModel : ViewModelBase {

		#region 固定文言

		/// <summary>
		/// タイトル
		/// </summary>
		public string TitleText { get; }

		/// <summary>
		/// ログファイル参照ボタン表示文字
		/// </summary>
		public string OpenFileDialogButtonContent { get; }

		/// <summary>
		/// ログ内容確認ボタン表示文字
		/// </summary>
		public string ConfirmLogButtonContent { get; }

		/// <summary>
		/// 解析項目一覧表示ボタン表示文字
		/// </summary>
		public string DisplayAnalysisListButtonContent { get; }

		/// <summary>
		/// ログ解析開始ボタン
		/// </summary>
		public string StartLogAnalysisButtonContent { get; }

		/// <summary>
		/// 閉じるボタン
		/// </summary>
		public string CloseButtonContent { get; }

		#endregion

		/// <summary>
		/// 選択したログファイル
		/// </summary>
		private string selectedLogFileName;
		/// <summary>
		/// 選択したログファイル
		/// </summary>
		public string SelectedLogFileName {
			set {
				SetProperty( ref this.selectedLogFileName , value , "SelectedLogFileName" );
			}
			get {
				return this.selectedLogFileName;
			}
		}

		#region ファイル選択ダイアログを開くコマンドの実装

		/// <summary>
		/// ファイル選択ダイアログを開くコマンド
		/// </summary>
		private DelegateCommand openFileDialogCommand;
		/// <summary>
		/// ファイル選択ダイアログを開くコマンド
		/// </summary>
		public DelegateCommand OpenFileDialogCommand {
			get {
				if( this.openFileDialogCommand == null )
					this.openFileDialogCommand = new DelegateCommand( this.OpenFileDialogExecute );
				return this.openFileDialogCommand;
			}
		}

		/// <summary>
		/// ファイル選択ダイアログを開くコマンドの実行イベント
		/// 選択したファイルの絶対パスを<see cref="SelectedLogFileName" />に渡す 
		/// </summary>
		private void OpenFileDialogExecute() {

			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.DefaultExt = "*.*";
			if( openFileDialog.ShowDialog() == true ) {
				this.SelectedLogFileName = openFileDialog.FileName;
			}

		}

		#endregion

		#region ログ確認ダイアログを開くコマンドの実装

		/// <summary>
		/// ログ確認ダイアログを開くコマンド
		/// </summary>
		private DelegateCommand showConfirmationDialogCommand;
		/// <summary>
		/// ログ確認ダイアログを開くコマンド
		/// </summary>
		public DelegateCommand ShowConfirmationDialogCommand {
			get {
				if( this.showConfirmationDialogCommand == null )
					this.showConfirmationDialogCommand = new DelegateCommand( this.ShowConfirmationDialogExecute );
				return this.showConfirmationDialogCommand;
			}
		}

		/// <summary>
		/// ログ確認ダイアログを開くコマンドの実行イベント
		/// <see cref="SelectedLogFileName"/>にパスが入っていない場合はエラーダイアログを表示する
		/// </summary>
		private void ShowConfirmationDialogExecute() {

			if( string.IsNullOrEmpty( this.SelectedLogFileName ) ) {
				MessageBox.Show( Const.ErrorDialogMessage.NoSelectedLogFileMessage , Const.ErrorDialogMessage.NoSelectedLogFileTitle , MessageBoxButton.OK , MessageBoxImage.Error );
				return;
			}

			ConfirmationWindow confirmationWindow = new ConfirmationWindow( this.SelectedLogFileName );
			confirmationWindow.ShowDialog();

		}

		#endregion

		#region 解析項目一覧ダイアログを開くコマンドの実装

		/// <summary>
		/// 解析項目一覧ダイアログを開くコマンド
		/// </summary>
		private DelegateCommand showAnalysisListDialogCommand;
		/// <summary>
		/// 解析項目一覧ダイアログを開くコマンド
		/// </summary>
		public DelegateCommand ShowAnalysisListDialogCommand {
			get {
				if( this.showAnalysisListDialogCommand == null )
					this.showAnalysisListDialogCommand = new DelegateCommand( this.ShowAnalysisListDialogExecute );
				return this.showAnalysisListDialogCommand;
			}
		}

		/// <summary>
		/// 解析項目一覧ダイアログを開くコマンドの実行イベント
		/// </summary>
		private void ShowAnalysisListDialogExecute() {

			AnalysisListWindow analysisListWindow = new AnalysisListWindow();
			analysisListWindow.ShowDialog();

		}

		#endregion

		#region 解析を開始して、解析結果ダイアログを開くコマンドの実装

		/// <summary>
		/// 解析結果ダイアログを開くコマンドの実装
		/// </summary>
		private DelegateCommand showResultDialogCommand;
		/// <summary>
		/// 解析結果ダイアログを開くコマンドの実装
		/// </summary>
		public DelegateCommand ShowResultDialogCommand {
			get {
				if( this.showResultDialogCommand == null )
					this.showResultDialogCommand = new DelegateCommand( this.ShowResultDialogExecute );
				return this.showResultDialogCommand;
			}
		}

		/// <summary>
		/// 解析結果ダイアログを開くコマンドの実装の実行イベント
		/// <see cref="SelectedLogFileName"/>にパスが入っていない場合はエラーダイアログを表示する
		/// </summary>
		private void ShowResultDialogExecute() {

			if( string.IsNullOrEmpty( this.selectedLogFileName ) ) {
				MessageBox.Show( Const.ErrorDialogMessage.NoSelectedLogFileMessage , Const.ErrorDialogMessage.NoSelectedLogFileTitle , MessageBoxButton.OK , MessageBoxImage.Error );
				return;
			}
				
			ResultWindow resultWindow = new ResultWindow( this.selectedLogFileName );
			resultWindow.ShowDialog();

		}

		#endregion

		#region アプリを終了するコマンドの実装

		/// <summary>
		/// アプリを終了するコマンドの実装
		/// </summary>
		private DelegateCommand exitAppCommand;
		/// <summary>
		/// アプリを終了するコマンドの実装
		/// </summary>
		public DelegateCommand ExitAppCommand {
			get {
				if( this.exitAppCommand == null )
					this.exitAppCommand = new DelegateCommand( this.ExitAppExecute );
				return this.exitAppCommand;
			}
		}

		/// <summary>
		/// アプリを終了するコマンドの実装の実行イベント
		/// </summary>
		private void ExitAppExecute() {

			Environment.Exit( 0 );

		}

		#endregion
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainViewModel() {

			#region 固定文言

			this.TitleText = Const.FixedWording.MainWindow.Title;
			this.OpenFileDialogButtonContent = Const.FixedWording.MainWindow.BrowseLogFileButton;
			this.ConfirmLogButtonContent = Const.FixedWording.MainWindow.ConfirmLogButton;
			this.DisplayAnalysisListButtonContent = Const.FixedWording.MainWindow.DisplayAnalysisListButton;
			this.StartLogAnalysisButtonContent = Const.FixedWording.MainWindow.StartLogAnalysisButton;
			this.CloseButtonContent = Const.FixedWording.MainWindow.CloseButton;

			#endregion

			this.SelectedLogFileName = "";
			
		}

	}

}
