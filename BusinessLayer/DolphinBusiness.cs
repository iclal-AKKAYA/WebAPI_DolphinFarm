using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DolphinBusiness
    {
        public void AddDolphin(DolphinData dolphinData)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            databaseConnection.OpenConnection();
            SqlCommand command = databaseConnection.CreateCommand("INSERT INTO Dolphins (Name, Age, BornDate, IsItForRent, RentalPrice) VALUES (@Name, @Age, @BornDate, @IsItForRent, @RentalPrice)");


            command.Parameters.AddWithValue("@Name", dolphinData.Name);
            command.Parameters.AddWithValue("@Age", dolphinData.Age);
            command.Parameters.AddWithValue("@BornDate", dolphinData.BornDate);
            command.Parameters.AddWithValue("@IsItForRent", dolphinData.IsItForRent);
            command.Parameters.AddWithValue("@RentalPrice", dolphinData.RentalPrice);
            command.ExecuteNonQuery();
        }

        public List<DolphinData> GetData()
        {
            List<DolphinData> listDolphinData = new List<DolphinData>();
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection sqlConnection = dbConnection.OpenConnection();
            string query = "SELECT * FROM Dolphins";
            SqlCommand command = dbConnection.CreateCommand(query);
            SqlDataReader read = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (read.Read())
            {
                DolphinData dolphinData = new DolphinData(

                    (int)read["DolphinId"],
                    read["Name"].ToString(),
                    (int)read["Age"],
                    (DateTime)read["BornDate"],
                    (bool)read["IsItForRent"],
                    (int)read["RentalPrice"]
                    );

                listDolphinData.Add(dolphinData);



            }
            return listDolphinData;

        }

        public bool DeleteDolphin(int DolphinId)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection sqlConnection = dbConnection.OpenConnection();
            string query = "DELETE FROM Dolphins WHERE DolphinId = @DolphinId";
            SqlCommand command = dbConnection.CreateCommand(query);

            command.Parameters.AddWithValue("@DolphinId", DolphinId);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0) return true;

            else return false;
        }

        public void UpdateDolphin(DolphinData dolphinData, int DolphinId)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection sqlConnection = dbConnection.OpenConnection();
            string query = "UPDATE Dolphins  SET Name = @Name, Age = @Age, BornDate = @BornDate, IsItForRent = @IsItForRent, RentalPrice = @RentalPrice WHERE DolphinId = @DolphinId";
            SqlCommand command = dbConnection.CreateCommand(query);

            command.Parameters.AddWithValue("@DolphinId", DolphinId);
            command.Parameters.AddWithValue("@Name", dolphinData.Name);
            command.Parameters.AddWithValue("@Age", dolphinData.Age);
            command.Parameters.AddWithValue("@BornDate", dolphinData.BornDate);
            command.Parameters.AddWithValue("@IsItForRent", dolphinData.IsItForRent);
            command.Parameters.AddWithValue("@RentalPrice", dolphinData.RentalPrice);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 0) return;
        }

    }
}
