using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel_Management.Models
{
    public class CustomerModel
    {
        public int cust_id {get; set;}
        public string cust_name  { get; set; }
        public string cust_identity { get; set; }
        public string cust_gender { get; set; }
        public string cust_identity_type { get; set; }
        public string cust_address { get; set; }
        public int? room_id { get; set; }
        public int? room_no { get; set; }
    }

    public class DBHandle 
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HAS4FO7;Initial Catalog=HotelManagement;Integrated Security=True");

        public List<CustomerModel> GetCustomer()
        {
            List<CustomerModel> lstcst = new List<CustomerModel>();
            SqlCommand cmd = new SqlCommand("udp_getCustomer",con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustomerModel cst = new CustomerModel();
                cst.cust_id = Convert.ToInt32(dr["cust_id"]);
                cst.cust_name = Convert.ToString(dr["cust_name"]);
                cst.cust_identity = Convert.ToString(dr["cust_identity"]);
                cst.cust_gender = Convert.ToString(dr["cust_gender"]);
                cst.cust_address = Convert.ToString(dr["cust_address"]);
                cst.cust_identity_type = Convert.ToString(dr["cust_identity_type"]);
                cst.room_id = Convert.ToInt32(dr["room_id"]);
                lstcst.Add(cst);
            }
            return lstcst;
        }

        public int AddCustomer(CustomerModel cst)
        {
            SqlCommand cmd = new SqlCommand("udp_addCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("cust_name", cst.cust_name);
            cmd.Parameters.AddWithValue("cust_identity", cst.cust_identity);
            cmd.Parameters.AddWithValue("cust_gender", cst.cust_gender);
            cmd.Parameters.AddWithValue("cust_identity_type", cst.cust_identity_type);
            cmd.Parameters.AddWithValue("cust_address", cst.cust_address);
            cmd.Parameters.AddWithValue("room_id", cst.room_id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int DeleteCustomer(int ? id)
        {
            SqlCommand cmd = new SqlCommand("udp_deleteCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@cust_id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdateCustomer(CustomerModel cst)
        {
            SqlCommand cmd = new SqlCommand("udp_updateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("cust_id", cst.cust_id);
            cmd.Parameters.AddWithValue("cust_name", cst.cust_name);
            cmd.Parameters.AddWithValue("cust_identity", cst.cust_identity);
            cmd.Parameters.AddWithValue("cust_gender", cst.cust_gender);
            cmd.Parameters.AddWithValue("cust_identity_type", cst.cust_identity_type);
            cmd.Parameters.AddWithValue("cust_address", cst.cust_address);
            cmd.Parameters.AddWithValue("room_id", cst.room_id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public CustomerModel GetCustomerById(int ? id)
        {
            SqlCommand cmd = new SqlCommand("udp_getCustomerById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("cust_id", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            CustomerModel cst = new CustomerModel();
            foreach (DataRow dr in dt.Rows)
            {
                
                cst.cust_id = Convert.ToInt32(dr["cust_id"]);
                cst.cust_name = Convert.ToString(dr["cust_name"]);
                cst.cust_identity = Convert.ToString(dr["cust_identity"]);
                cst.cust_gender = Convert.ToString(dr["cust_gender"]);
                cst.cust_address = Convert.ToString(dr["cust_address"]);
                cst.cust_identity_type = Convert.ToString(dr["cust_identity_type"]);
                cst.room_id = Convert.ToInt32(dr["room_id"]);
            }
            return cst;
        }


    }

}