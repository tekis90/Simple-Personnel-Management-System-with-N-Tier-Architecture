using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
    public class DALPerson
    {
        public static List<EntityPerson> PersonList()
        {
            try
            {

                List<EntityPerson> person = new List<EntityLayer.EntityPerson>();

                SqlCommand sqlCommand = new SqlCommand("Select * From Tbl_Bilgi", Connection.cnt);

                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }


                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    EntityPerson entityPerson = new EntityPerson();
                    entityPerson.Id = int.Parse(sqlDataReader["Id"].ToString());
                    entityPerson.Name = sqlDataReader["Ad"].ToString();
                    entityPerson.Surname = sqlDataReader["Soyad"].ToString();
                    entityPerson.City = sqlDataReader["Sehir"].ToString();
                    entityPerson.Job = sqlDataReader["Gorev"].ToString();
                    entityPerson.Salary = short.Parse(sqlDataReader["Maas"].ToString());
                    person.Add(entityPerson);
                }

                sqlDataReader.Close();

                return person;
            }
            catch (Exception)
            {
                return null;

            }

        }
        public static int personAdd(EntityPerson p)
        {
            try
            {
                string quary = "Insert into Tbl_Bilgi ( Ad , Soyad ,Sehir,Gorev,Maas) Values (@p2,@p3,@p4,@p5,@p6)";
                SqlCommand sqlCommand = new SqlCommand(quary, Connection.cnt);

                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }


                sqlCommand.Parameters.AddWithValue("@p2", p.Name);
                sqlCommand.Parameters.AddWithValue("@p3", p.Surname);
                sqlCommand.Parameters.AddWithValue("@p4", p.City);
                sqlCommand.Parameters.AddWithValue("@p5", p.Job);
                sqlCommand.Parameters.AddWithValue("@p6", p.Salary);

                return sqlCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return -1;

            }

         
        }
        public static bool personDelete(int id)
        {

            try
            {
                string quary = "Delete from Tbl_Bilgi where Id=@p1";
                SqlCommand sqlCommand = new SqlCommand(quary, Connection.cnt);

                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }


                sqlCommand.Parameters.AddWithValue("@p1", id);

                return sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

                return false;
            }

            

        }
        public static int personupdate(EntityPerson p)
        {


            try
            {
                string query = "UPDATE Tbl_Bilgi SET Ad=@p2, Soyad=@p3, Sehir=@p4, Gorev=@p5, Maas=@p6 WHERE Id=@p1";
                SqlCommand sqlCommand = new SqlCommand(query, Connection.cnt);

                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }

                sqlCommand.Parameters.AddWithValue("@p1", p.Id);
                sqlCommand.Parameters.AddWithValue("@p2", p.Name);
                sqlCommand.Parameters.AddWithValue("@p3", p.Surname);
                sqlCommand.Parameters.AddWithValue("@p4", p.City);
                sqlCommand.Parameters.AddWithValue("@p5", p.Job);
                sqlCommand.Parameters.AddWithValue("@p6", p.Salary);

                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
               
            }

            

        }
    }
}
