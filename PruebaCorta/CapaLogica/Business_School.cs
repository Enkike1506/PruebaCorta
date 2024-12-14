using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml.Linq;

namespace PruebaCorta.CapaLogica
{
    public class Business_School
    {
        public static int AddSchool(string name, string description, string address, string phone, string postCode, string postAddress)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AddSchool", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@description", description));
                    cmd.Parameters.Add(new SqlParameter("@address", address));
                    cmd.Parameters.Add(new SqlParameter("@phone", phone));
                    cmd.Parameters.Add(new SqlParameter("@postCode", postCode));
                    cmd.Parameters.Add(new SqlParameter("@postAddress", postAddress));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int EditSchool(int id, string name, string description, string address, string phone, string postCode, string postAddress)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EditSchool", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@description", description));
                    cmd.Parameters.Add(new SqlParameter("@address", address));
                    cmd.Parameters.Add(new SqlParameter("@phone", phone));
                    cmd.Parameters.Add(new SqlParameter("@postCode", postCode));
                    cmd.Parameters.Add(new SqlParameter("@postAddress", postAddress));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int DeleteSchool(int id)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("DeleteSchool", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}