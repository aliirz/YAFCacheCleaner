using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows;
using System.Diagnostics;

namespace YAFCacheCleaner
{
    class YAFDB
    {
        private SqlConnection _connection;
        

        public bool ClearCache()
        {
            bool retval = false;

            try
            {
                
                _connection =  new SqlConnection("Put your connection string here");
                _connection.Open();
                retval = true;

                SqlCommand _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "yaf_activeaccess_reset";




                if (_command.ExecuteNonQuery() > 0)
                {

                    retval = true;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                
            }

            return retval;
        }
    }
}
