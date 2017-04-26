using LogMonitoringTool.BusinessObject.Risk;
using System.Collections.Generic;
using System.Windows.Media;

namespace LogMonitoringTool.Services.Risk {

	/// <summary>
	/// リスクについてのServiceクラス
	/// </summary>
	public class RiskService {

		/// <summary>
		/// シングルトンパターンによりインスタンスが1つしかない事を保証する
		/// </summary>
		private static RiskService singleton = new RiskService();

		/// <summary>
		/// リスク一覧
		/// </summary>
		private List<RiskEntity> riskEntities;

		/// <summary>
		/// コンストラクタ
		/// シングルトンなので外からは呼び出されない
		/// </summary>
		private RiskService() {
			
			this.riskEntities = new List<RiskEntity>() {
				new RiskEntity() { Id = 0 , Title = "指定なし" , RiskColor = Color.FromRgb( 200 , 200 , 200 ) } ,
				new RiskEntity() { Id = 1 , Title = "不明" , RiskColor = Color.FromRgb( 200 , 200 , 255 ) } ,
				new RiskEntity() { Id = 2 , Title = "低" , RiskColor = Color.FromRgb( 200 , 255 , 200 ) } ,
				new RiskEntity() { Id = 3 , Title = "中" , RiskColor = Color.FromRgb( 255 , 255 , 200 ) } ,
				new RiskEntity() { Id = 4 , Title = "高" , RiskColor = Color.FromRgb( 255 , 0 , 0 ) } ,
			};
			
		}

		/// <summary>
		/// Serviceクラスのインスタンスを返す
		/// </summary>
		/// <returns>インスタンス</returns>
		public static RiskService GetInstance() {
			return RiskService.singleton;
		}
		
		/// <summary>
		/// リスク一覧を返す
		/// </summary>
		/// <returns></returns>
		public IEnumerable<RiskEntity> GetRiskEntities() {
			return this.riskEntities;
		}

		/// <summary>
		/// IDからRiskEntityを取得する
		/// </summary>
		/// <param name="id">リスクID</param>
		/// <returns>Entity　当てはまらなければnull</returns>
		public RiskEntity GetRiskEntity( int id ) {

			foreach( RiskEntity entity in this.riskEntities ) {
				if( id == entity.Id )
					return entity;
			}
			return null;

		}
		
		/// <summary>
		/// リスク名からIDを取得する
		/// </summary>
		/// <param name="riskTitle">リスク名</param>
		/// <returns>ID　当てはまらなければ-1</returns>
		public int GetRiskId( string riskTitle ) {

			if( string.IsNullOrEmpty( riskTitle ) )
				return -1;

			foreach( RiskEntity entity in this.riskEntities ) {
				if( entity.Title.Equals( riskTitle ) )
					return entity.Id;
			}

			return -1;

		}

	}

}
