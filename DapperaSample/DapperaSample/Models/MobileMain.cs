using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace DapperaSample.Models
{
	public class MobileMain
	{
		#region Instance
		private static MobileMain instance = new MobileMain();
		public static MobileMain Instance
		{
			get { return MobileMain.instance; }
		}
		#endregion

		private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=InfoDataBase;Integrated Security=SSPI";
		SqlConnection con = new SqlConnection();

		private MobileMain()
		{
			con.ConnectionString = this.connectionString;
		}
		public string AddMobiles(TBMobileDetails objMD)
		{
			try
			{
				string query = "insert into Mobile (MobileName,MobileIMEno,MobileMannfactured,Mobileprice) "
						+ "values(@MobileName,@MobileIMEno,@MobileMannfactured,@Mobileprice)";
				con.Execute(query, new { objMD.MobileIMEno, objMD.MobileMannfactured, objMD.MobileName, objMD.Mobileprice });
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
			}
			return "success";
		}

		public IEnumerable<TBMobileDetails> GetAllList()
		{
			string query = "select * from Mobile";
			var res = con.Query<TBMobileDetails>(query);
			return res;
		}

		internal void GetMobileList(string MobileID)
		{
			string query = "select MobileID,MobileName,MobileIMEno,MobileManufactured" +
	",Mobileprice from dbo.Mobiledata where @MobileID =" + MobileID;
			var res = con.Query<TBMobileDetails>(query).Single<TBMobileDetails>();
		}
	}
}