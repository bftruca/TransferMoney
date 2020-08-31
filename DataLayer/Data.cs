using MoneyTransfer.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MoneyTransfer.DataLayer
{
    public sealed class Data
    {
        private static Data instance = null;

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        private readonly SqlConnection con = new SqlConnection(connectionString);

        private Data()
        {

        }

        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }
                return instance;
            }
        }

        public DataTable GetCurrencies()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetCurrencies", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                return dt;
            }
            catch(Exception ex)
            {
                Logger.log(string.Format("Data.GetCurrencies(): {0}", ex.Message));
                throw ex;
            }
        }

        public DataTable GetCurrencyById(int id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetCurrencyById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.GetCurrencyById(): {0}", ex.Message));
                throw ex;
            }
        }

        public DataTable GetUserPassword(string userName)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetUserPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", SqlDbType.NVarChar).Value = userName.Trim();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.GetUserPassword(): {0}", ex.Message));
                throw ex;
            }
        }

        public DataTable GetTransactionsByCNPAndToken(string CNP, string Token)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetTransactionsByCNPAndToken", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CNP", SqlDbType.NChar).Value = CNP.Trim();
                cmd.Parameters.AddWithValue("@Token", SqlDbType.NChar).Value = Token.Trim();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.GetTransactionsByCNPAndToken(): {0}", ex.Message));
                throw ex;
            }
        }

        public DataTable GetTransactionsByUserName(string userName)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetTransactionsByUserName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", SqlDbType.NVarChar).Value = userName.Trim();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.GetTransactionsByCNPAndToken(): {0}", ex.Message));
                throw ex;
            }
        }

        public bool RenewToken(int id, int offset)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RenewToken", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@offsetDate", SqlDbType.Int).Value = offset;
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteReader();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.RenewToken(): {0}", ex.Message));
                throw ex;
            }
        }

        public bool ChangeStatus(int id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ChangeStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTransfer", SqlDbType.Int).Value = id;
                cmd.ExecuteReader();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.ChangeStatus(): {0}", ex.Message));
                throw ex;
            }
        }

        public bool AddTransaction(string userName, int offsetDate, string CNP, string IBAN, decimal Amount, int CurrencyId, decimal AmountReceived, int CurrencyReceived_Id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", SqlDbType.NVarChar).Value = userName;
                cmd.Parameters.AddWithValue("@offsetDate", SqlDbType.Int).Value = offsetDate;
                cmd.Parameters.AddWithValue("@CNP", SqlDbType.NChar).Value = CNP;
                cmd.Parameters.AddWithValue("@IBAN", SqlDbType.NChar).Value = IBAN;
                cmd.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Amount;
                cmd.Parameters.AddWithValue("@CurrencyId", SqlDbType.Int).Value = CurrencyId;
                cmd.Parameters.AddWithValue("@AmountReceived", SqlDbType.Decimal).Value = AmountReceived;
                cmd.Parameters.AddWithValue("@CurrencyReceived_Id", SqlDbType.Int).Value = CurrencyReceived_Id;
                cmd.ExecuteReader();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.ChangeStatus(): {0}", ex.Message));
                throw ex;
            }
        }

        public DataTable CheckCountry(string Abbr)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CheckCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Abbr", SqlDbType.NVarChar).Value = Abbr.Trim();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Data.CheckCountry(): {0}", ex.Message));
                throw ex;
            }
        }
    }
}