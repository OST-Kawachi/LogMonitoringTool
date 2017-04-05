using LogMonitoringTool.BusinessObject.Risk;
using System.Collections.Generic;

namespace LogMonitoringTool.Services.Risk {

	/// <summary>
	/// リスクについてのServiceクラス
	/// </summary>
	public class RiskService {
		
		/// <summary>
		/// リスク一覧を返す
		/// </summary>
		/// <returns></returns>
		public IEnumerable<RiskEntity> GetRiskEntities() {

			return new List<RiskEntity>() {
				new RiskEntity() { Id = 0 , Title = "低" } ,
				new RiskEntity() { Id = 1 , Title = "中" } ,
				new RiskEntity() { Id = 2 , Title = "高" }
			};

		}

	}

}
