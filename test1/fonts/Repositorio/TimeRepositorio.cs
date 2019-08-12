using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using test1.Models;
using System.Data;

namespace test1.fonts.Repositorio
{
    public class TimeRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(constr);
        }


        ///adicionar um time

        public bool AdicionarTime(Times TimeObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Time", TimeObj.Time);
                command.Parameters.AddWithValue("@Estado", TimeObj.Estado);
                command.Parameters.AddWithValue("@Cores", TimeObj.Cores);


                _con.Open();

                i = command.ExecuteNonQuery();

            }

            _con.Close();

            return i >= 1;
        }

        //obter todos os times
        public List<Times> ObterTimes()
        {
            Connection();
            List<Times> TimesList = new List<Times>();

            using (SqlCommand command = new SqlCommand("ObterTimes", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Times times = new Times()
                    {
                        TimeId = Convert.ToInt32(reader["TimeId"]),
                        Time = Convert.ToString(reader["Time"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        Cores = Convert.ToString(reader["Cores"]),
                    };

                    TimesList.Add(times);

                }
                _con.Close();

                return TimesList;
            }

        }

        //atualizar Time
        public bool AtualizarTime(Times TimeObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", TimeObj.TimeId);
                command.Parameters.AddWithValue("@Time", TimeObj.Time);
                command.Parameters.AddWithValue("@Estado", TimeObj.Estado);
                command.Parameters.AddWithValue("@Cores", TimeObj.Cores);


                _con.Open();

                i = command.ExecuteNonQuery();

            }

            _con.Close();

            return i >= 1;
        }

        //Excluir time

        public bool ExcluirTime(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirTimePorId", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", id);



                _con.Open();

                i = command.ExecuteNonQuery();

            }

            _con.Close();

            if (i >= 1)
            {
                return true;
            }
         
                return false;
    

        }
    }
}







