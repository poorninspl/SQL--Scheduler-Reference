using SrqCustomerAlerts.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrqCustomerAlerts
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            string msSQL;
            DataTable dt_datatable;
            dbconn objdbconn = new dbconn();
            cmnfunctions objcmnfunctions = new cmnfunctions();
            try
            {
               

                msSQL = "select * from adm_mst_tcompany";
                dt_datatable = objdbconn.GetDataTable(msSQL);
                //var getmaster_list = new List<master_list>();
                //if (dt_datatable != null && dt_datatable.Rows.Count != 0)
                //{
                //    foreach (DataRow dr_datarow in dt_datatable.Rows)
                //    {
                //        getmaster_list.Add(new master_list
                //        {
                //            baselocation_gid = (dr_datarow["baselocation_gid"].ToString()),
                //            api_code = (dr_datarow["api_code"].ToString()),
                //            baselocation_name = (dr_datarow["baselocation_name"].ToString()),
                //            created_by = (dr_datarow["created_by"].ToString()),
                //            created_date = (dr_datarow["created_date"].ToString()),
                //            status = (dr_datarow["status"].ToString()),
                //        });
                //    }
                //    objmaster.master_list = getmaster_list;
                //}
                //dt_datatable.Dispose();
                //objmaster.status = true;
            }
            catch (Exception ex)
            {
                string logMessage = $"*******Date*****{DateTime.Now.ToString("yyyy - MM - dd HH:mm:ss")} ***********" +
                        $"DataAccess: {System.Reflection.MethodBase.GetCurrentMethod().Name} ***********" +
                       
                        $" {ex.Message.ToString()} ***********";

                //objdbconn.LogForAudit(logMessage, "system");
                ex.StackTrace.ToString();
                
            }
        }
    }
}
