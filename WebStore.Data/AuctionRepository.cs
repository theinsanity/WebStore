﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.Models;
using WebStore.Data.Contracts.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebStore.Data
{
    public class AuctionRepository : IAuctionRepository
    {

        private readonly string _connectionString;

        public AuctionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }



        public Auction MapTableEnityToObject(IDataRecord record)
        {
            var entity = new Auction
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                Price = (double)record["Price"],
                Seller_Id = (int)record["Seller_Id"],
                
                //Description = (string)record["Description"],
                //Image_Path = (string)record["Image_Path"]

            };
            if(record["Buyer_Id"] == DBNull.Value)
            {
                entity.Buyer_Id = null;
            }
            else
            {
                entity.Buyer_Id = (int)record["Buyer_Id"];
            }
            if (record["Description"] == DBNull.Value)
            {
                entity.Description = null;
            }
            else
            {
                entity.Description = (string)record["Description"];
            }
            if (record["Image_Path"] == DBNull.Value)
            {
                entity.Image_Path = null;
            }
            else
            {
                entity.Image_Path = (string)record["Image_Path"];
            }
            if (record["Date_Added"] == DBNull.Value)
            {
                entity.Date_Added = null;
            }
            else
            {
                entity.Date_Added = (DateTime)record["Date_Added"];
            }
            if (record["Date_Purchased"] == DBNull.Value)
            {
                
                entity.Date_Purchased = null;
            }
            else
            {
                entity.Date_Purchased = (DateTime)record["Date_Purchased"];
            }

            entity.Status = (string)record["Status"];
            
            return entity;
        }

        //Select queries

        //Select all 

        private IEnumerable<Auction> SelectCommand(string queryString,
            string connectionString)
        {
            using (var connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();
                var result = new List<Auction>();
                if (reader.HasRows != true)
                {
                    return result;
                }
                while (reader.Read())
                {
                    var act = MapTableEnityToObject(reader); ;
                    result.Add(act);

                }
                return result;
            }
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            const string query = "Select * from [Auction]";
            return SelectCommand(query, _connectionString);
        }

        //Select all sold

        private List<Auction> GetAllSoldCommand(string connectionString, Auction auction)
        {
            const string queryString = "Select * from [Auction] where Status=@st and Seller_Id= @sl";
            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@st", auction.Status);
                command.Parameters.AddWithValue("@sl", auction.Seller_Id);


                var reader = command.ExecuteReader();

                var result = new List<Auction>();
                if (reader.HasRows != true)
                {
                    return result;
                }
                while (reader.Read())
                {
                    var act = MapTableEnityToObject(reader); ;
                    result.Add(act);

                }
                return result;
            }
        }

        



        public IEnumerable<Auction> GetAllSold(Auction auction)
        {
            
           return GetAllSoldCommand(_connectionString, auction);
            
        }

        //Select all bought

        private IEnumerable<Auction> GetAllBoughtCommand(string connectionString, Auction auction)
        {
            const string queryString = "Select * from [Auction] where Status=@st and Buyer_Id= @sl";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@st", auction.Status);
                command.Parameters.AddWithValue("@sl", auction.Buyer_Id);


                var reader = command.ExecuteReader();

                var result = new List<Auction>();
                if (reader.HasRows != true)
                {
                    return result;
                }
                
                    while (reader.Read())
                    {
                        var act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                
                return result;
            }


        }


        public IEnumerable<Auction> GetAllBought(Auction auction)
        {

            return GetAllBoughtCommand(_connectionString, auction);
        }    
        

        //Insert queries

        private void CreateCommand(
            string connectionString, Auction auction)
        {
            const string queryString = "Insert into [Auction] (Name, Price, Buyer_Id, Seller_Id, Status, Date_Purchased, Date_Added, Description, Image_Path) values(@name,@price,null,@seller,'Pending',null, current_timestamp, @desc, @imgpth)";

            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", auction.Name);
                command.Parameters.AddWithValue("@price", auction.Price);
                command.Parameters.AddWithValue("@seller", auction.Seller_Id);
                command.Parameters.AddWithValue("@desc", auction.Description);
                command.Parameters.AddWithValue("@imgpth", auction.Image_Path);

                command.ExecuteNonQuery();



            }
        }

        public void CreateAuction(Auction auction)
        {
            CreateCommand(_connectionString, auction);
        }

        //Update queries

        private void UpdateCommand(string connectionString, Auction auction)
        {
            const string queryString = "Update [Auction] set Buyer_Id=@buyerid,Status='Sold',date_purchased=current_timestamp where id=@id";
            using (var connection = new SqlConnection(
                     connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@buyerid", auction.Buyer_Id);
                command.Parameters.AddWithValue("@id", auction.Id);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAuction(Auction auction)
        {
            UpdateCommand(_connectionString, auction);
        }
        private Auction FindAuctionCommand(string connectionString,int id)
        {
            const string queryString = "Select * from [Auction] where Id=@id";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);
               


                var reader = command.ExecuteReader();

                var result = new Auction();
                if (reader.HasRows != true)
                {
                    return result;
                }

                while (reader.Read())
                {
                    var act = MapTableEnityToObject(reader);
                    result = act;
                }


                return result;
            }

        }
        public Auction FindAuction(int id)
        {
            return FindAuctionCommand(_connectionString ,id);
        }

        private void DeleteCommand(string connectionString, Auction auction)
        {
            const string queryString = "Delete from [Auction] where Id=@id";
            using (var connection = new SqlConnection(
                     connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", auction.Id);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteAuction(Auction auction)
        {
            DeleteCommand(_connectionString, auction);
        }

       private IEnumerable<Auction> GetAllUsrAuctions(string connectionString, Auction auction)
        {
            const string queryString = "Select * from [Auction] where Status='Pending' and Seller_Id=@ide";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ide", auction.Seller_Id);

                var reader = command.ExecuteReader();

                var result = new List<Auction>();
                if (reader.HasRows != true)
                {
                    return result;
                }

                while (reader.Read())
                {
                    var act = MapTableEnityToObject(reader);
                    result.Add(act);

                }


                return result;
            }
        }

       public  IEnumerable<Auction> GetAllUsersAuctions(Auction auction)
        {
            return GetAllUsrAuctions(_connectionString, auction);
        }



    }
}