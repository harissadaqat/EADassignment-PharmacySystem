using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Project.Controllers
{
    public class Model
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='E:\8 SEMESTER\EAD Assignment-3\Pharmacy management system\Project\App_Data\Store.mdf';Integrated Security=True");
        public SqlCommand cmd;
        public String currentUser, currentPassword, currentEmail,currentRole;
        List<String> cartMedicine = new List<String>();
        List<int> cartQty = new List<int>();
        List<int> indexes = new List<int>();

        public void signup(String user,String password,String email)
        {
            String sql = "insert into UserRegistration(userName,Password,email,role) values('" + user + "','" + password + "','" + email + "','user');";
            conn.Open();
            cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool login(String email, String password)
        {
            String sql = "select * from UserRegistration";
            bool check = false;
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String uname = reader.GetString(1);
                String userPass = reader.GetString(2);
                String mail = reader.GetString(3);
                String role = reader.GetString(4);
                if ((email.Equals(mail)) && (password.Equals(userPass)))
                {
                    this.currentUser = uname;
                    this.currentPassword = userPass;
                    this.currentEmail = mail;
                    this.currentRole = role;
                    check = true;
                    break;
                }
            }
            conn.Close();
            if (check)
            {
                return true;
            }
            else
                return false;
        }

        public void updateStock(String name,int add,int sub,String price){
            String getQty = "select Quantity from Stock where Medicine = '" + name + "';";
            conn.Open();
            cmd = new SqlCommand(getQty,conn);
            SqlDataReader rs = cmd.ExecuteReader();
            String qty = "";
            if(rs.ToString() == null)
                    return;
            while(rs.Read())
            {
                qty = rs.GetString(0);
            }
            int qt = int.Parse(qty);
            int total = (qt + add) - sub;
            rs.Close();
            String sql = "UPDATE Stock SET Quantity='" + total + "' WHERE Medicine='"+name+"';";
            cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            sql = "UPDATE Stock SET Price='" + price + "' WHERE Medicine='"+name+"';";
            cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void addMedicine(String name,String qty,String price,String img){
            String sql = "insert into Stock(Medicine,Quantity,Image,Price) values('" + name + "','" + qty + "','" + img + "','" + price + "');";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void removeMedicine(String name){
            String sql = "delete from Stock where Medicine = '"+ name +"'";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void insertItems(String email,int qty,String medicine){
            String sql = "insert into UserCart(userID,medicine,qty) values('" + email + "','" + medicine + "','" + qty.ToString() + "');";
            conn.Open();
            cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateItem(int qty,String medicine){
            String sql = "UPDATE Stock SET Quantity='" + qty + "' WHERE Medicine='"+medicine+"';";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void prepareRemovingItems(String email)
        {
            this.currentEmail = email;
            String cartItems = "select * from UserCart";
            conn.Open();
            cmd = new SqlCommand(cartItems, conn);
            SqlDataReader rss = cmd.ExecuteReader();
            while (rss.Read())
            {
                if (rss.GetString(1).Equals(email))
                {
                    cartMedicine.Add(rss.GetString(2));
                    cartQty.Add(int.Parse(rss.GetString(3)));
                }
            }
            conn.Close();
        }

        public void removeItems(int index){
            String medicineName = cartMedicine.ElementAt(index);
            String query = "delete from UserCart where userID = '"+ this.currentEmail +"' and medicine = '"+medicineName+"'";
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void removeAllItems(){
            String query = "delete from UserCart where userID = '"+ this.currentEmail +"'";
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public String getUser()
        {
            return this.currentUser;
        }
        public String getRole()
        {
            return this.currentRole;
        }
    }
}