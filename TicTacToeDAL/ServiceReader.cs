using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeCommon;
using TicTacToeCommon.Interfaces;

namespace TicTacToeDAL
{
    public class ServiceReader : IUserReader
    {
        // fields and properties

        private readonly string DbConnection;


        // constructors
        public ServiceReader() 
        {
            this.DbConnection = System.Configuration.ConfigurationManager.
            ConnectionStrings["conn"].ConnectionString;
        }

        public void AddUser(Player inPlayerDAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnection))
                {
                    using (SqlCommand command = new SqlCommand("sp_insert_player", conn))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 45;
                        conn.Open();

                        // all my parameters
                        command.Parameters.AddWithValue("@parm_firstname", SqlDbType.VarChar).Value = inPlayerDAL.FirstName;
                        command.Parameters.AddWithValue("@parm_lastname", SqlDbType.VarChar).Value = inPlayerDAL.LastName;
                        //command.Parameters.AddWithValue("@parm_birthdate", SqlDbType.DateTime2).Value = inPlayerDAL.Birthdate; /*   MM/dd/yyyy  */
                        command.Parameters.Add("@parm_birthdate", SqlDbType.DateTime2).Value = inPlayerDAL.Birthdate;

                        if (inPlayerDAL.Gender == ' ')
                        {
                            command.Parameters.AddWithValue("@parm_gender", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@parm_gender", SqlDbType.VarChar).Value = inPlayerDAL.Gender.ToString();
                        }

                        // this runs the  stored procedure against the db
                        command.ExecuteNonQuery();

                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteUser(int inPlayerId)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetAllUsers(int inPlayerId)
        {
            throw new NotImplementedException();
        }
    }
}
