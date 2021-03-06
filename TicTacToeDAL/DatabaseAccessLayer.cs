﻿namespace TicTacToeDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data;
    using TicTacToeCommon;

    public class DatabaseAccessLayer
    {

        public string DbConnection = System.Configuration.ConfigurationManager.
            ConnectionStrings["conn"].ConnectionString;

        public void AddPlayer(Player inPlayerDAL)
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
                        command.Parameters.AddWithValue("@parm_firstname", SqlDbType.VarChar).Value = inPlayerDAL.PlayerFirstName;
                        command.Parameters.AddWithValue("@parm_lastname", SqlDbType.VarChar).Value = inPlayerDAL.PlayerLastName;
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

        public List<Player> GetAllPlayers(int inPlayerId) 
        {
            // starts out empty
            List<Player> _returnList = new List<Player>();            
            try
            {
              
                // establish a db connnection
                using (SqlConnection conn = new SqlConnection(DbConnection))
                {
                    // create a command
                    using (SqlCommand command = new SqlCommand("sp_select_all_players", conn)) 
                    {
                        command.Parameters.AddWithValue("@parm_playerid", SqlDbType.Int).Value = inPlayerId;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 45;

                        // open the connection
                        conn.Open();

                        // reader loop

                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read())
                            {
                                // get each row and each cell of data from db
                                Player _player = new Player();
                                _player.PlayerType = PlayerType.Human; // default type is human
                                _player.PlayerID = Convert.ToInt32(reader["PlayerID"]);
                                _player.PlayerFirstName = reader["FirstName"].ToString();
                                _player.PlayerLastName = reader["LastName"].ToString();

                                // if it's null, make the date min value for date, otherwise take the date
                                // called a tertary , same as if..else
                                //playerDAL.Birthdate = reader["BirthDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["BirthDate"]); 

                                if (reader["BirthDate"] == DBNull.Value)
                                {
                                   // “1 / 1 / 0001 12:00:00 AM”.
                                    _player.Birthdate = DateTime.MinValue;
                                }
                                else 
                                {
                                    Convert.ToDateTime(reader["BirthDate"]);
                                }

                                //playerDAL.Gender = reader["Gender"] == DBNull.Value ? 'N' : Convert.ToChar(reader["Gender"]);

                                if (reader["Gender"] == DBNull.Value)
                                {
                                    _player.Gender = ' ';
                                }
                                else
                                {
                                    _player.Gender = Convert.ToChar(reader["Gender"]);

                                }

                                // add to list
                                _returnList.Add(_player);
                            }                         
                        }
                        // close connection
                        conn.Close();
                    }                             
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _returnList;
        }

        public void DeletePlayer(int inPlayerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnection))
                {
                    using (SqlCommand command = new SqlCommand("sp_delete_player", conn))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 45;
                        conn.Open();

                        // all my parameters
                        command.Parameters.AddWithValue("@parm_playerid", SqlDbType.Int).Value = 
                            inPlayerId;
                    
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

      
    }
}
