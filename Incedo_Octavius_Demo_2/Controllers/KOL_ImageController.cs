using Incedo_Octavius_Demo_2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incedo_Octavius_Demo_2.Controllers
{
    public class KOL_ImageController : Controller
    {
        // GET: KOL_Image
        public ActionResult Index()
        {
            List<KOL_Image> kolNameImageList = new List<KOL_Image>();
            string constr = ConfigurationManager.ConnectionStrings["Incedo_Octavius_Demo_2_kol_table_Context"].ConnectionString;
            // Stored Procedures
            using (MySqlConnection dbConnection = new MySqlConnection(constr))
            {
                try
                {
                    dbConnection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "KOL_Name_Image";

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet dataSetObject = new DataSet();
                    dataAdapter.Fill(dataSetObject);

                    if (dataSetObject.Tables[0].Rows.Count > 0)
                    {
                        for (int iCout = 0; iCout < dataSetObject.Tables[0].Rows.Count; iCout++)
                        {
                            KOL_Image kolImage= new KOL_Image();
                            kolImage.First_Name = dataSetObject.Tables[0].Rows[iCout]["First_Name"].ToString();
                            kolImage.Last_Name = dataSetObject.Tables[0].Rows[iCout]["Last_Name"].ToString();
                            kolImage.Image_URL = dataSetObject.Tables[0].Rows[iCout]["Image_Link"].ToString();

                            kolNameImageList.Add(kolImage);
                        }
                    }
                }
                catch (Exception Ex)
                {

                    Console.WriteLine("Error : " + Ex.Message);
                }

            }

            return View(kolNameImageList);
        }
    }
}