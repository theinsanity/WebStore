using System;
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

        SqlConnection conn;
        SqlDataAdapter adp;
        DataSet ds;
        SqlCommand sqlc;

        public AuctionRepository()
        {
            conn = new SqlConnection("Data Source=ALUCARD;Initial Catalog=Repository;Integrated Security=True");
        }
        private void OpenCloseConnection()
        {
            conn.Open();
            sqlc.ExecuteNonQuery();
            conn.Close();
        }



        public IEnumerable<Auction> GetAllAuctions()
        {
            adp = new SqlDataAdapter("Select * from [Auction]", conn);
            ds = new DataSet();
            adp.Fill(ds);
            var myData = ds.Tables[0].AsEnumerable().Select(r => new Auction
            {
                Id = r.Field<int>("Id"),
                Name = r.Field<string>("Name"),
                Price = r.Field<double>("Price"),
                Seller = r.Field<string>("Seller"),
                Status = r.Field<string>("Status")
            });
            return myData.ToList();
        }



    }
}
