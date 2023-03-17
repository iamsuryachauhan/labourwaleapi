using DataAccessLayer.Models;
//using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace RepoLayer
{
    public class AddingLabourInfo
    {
        //private readonly IAppSetting _appSetting;

        //public AddingLabourInfo(IAppSetting appSetting)
        //{
        //    this._appSetting = appSetting;
        //}
        public void addingInfo(M_LabourInfo m_LabourInfo)
        {
            try
            {
                string sQuery = "";
                var connString = "";
                //connString = _appSetting.ConnectionString;


                sQuery = "Insert into LabourInfo (LabourCode,LabourName,DOB,Location,PhoneNo,Image,Gender)" +
                    "values(" +
                    "'" + m_LabourInfo.LabourCode + "','" + m_LabourInfo.LabourName + "','" + m_LabourInfo.DOB + "'" +
                    "'" + m_LabourInfo.Location + "','" + m_LabourInfo.PhoneNo + "','" + m_LabourInfo.PhoneNo + "'" +
                    "'" + m_LabourInfo.Image + "','" + m_LabourInfo.Gender + "'" +
                    ")";

                SqlDataReader Reader;
                DataTable dt = new DataTable();
                using (SqlConnection mycon = new SqlConnection(connString))
                {
                    mycon.Open();
                    using (SqlCommand command = new SqlCommand(sQuery, mycon))
                    {
                        Reader = command.ExecuteReader();
                        dt.Load(Reader);

                        Reader.Close();
                        mycon.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                throw;
            }
        }
        public DataTable fGetLabourInfo()
        {
            try
            {
                string sQuery = "";
                DataTable dtGetData = new DataTable();
                //var connString = _appSetting.ConnectionString;
                var connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=labourProj;persist security info=True;Integrated Security=true";
                sQuery = "select LabourCode,LabourName,DOB,Location,PhoneNo,Image,Gender from LabourInfo";
                SqlDataReader Reader;
                using (SqlConnection mycon = new SqlConnection(connString))
                {
                    mycon.Open();
                    using (SqlCommand command = new SqlCommand(sQuery, mycon))
                    {
                        Reader = command.ExecuteReader();
                        dtGetData.Load(Reader);
                        Reader.Close();
                        mycon.Close();
                    }
                }
                return dtGetData;
            }
            catch (Exception ex)
            {
                var excep = ex.Message;
                throw;
            }
        }
    }
}