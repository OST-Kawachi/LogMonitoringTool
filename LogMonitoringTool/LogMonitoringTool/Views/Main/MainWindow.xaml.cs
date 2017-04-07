﻿using System;
using System.Windows;

namespace LogMonitoringTool.Views.Main {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindow() {

			InitializeComponent();

		}
		
		/// <summary>
		/// 閉じるボタン押下時イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickCloseButton( object sender , RoutedEventArgs e ) {
			Environment.Exit( 0 );
		}

	}

}
