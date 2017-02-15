using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Persistence
{
   public class Conexao
    {
        //Atributos
       protected SqlConnection Con;
       protected SqlCommand Cmd;
       protected SqlDataReader Dr;

        #region Abrir-Fechar Conexao
        protected void AbrirConexao()
       {
           try
           {
                Con = new SqlConnection("Data Source=darthvader;Initial Catalog=CrudDal;Persist Security Info=True;User ID=sa;Password=21293175");//Connection String
                Con.Open();
           }
           catch (Exception ex)
           {
                
               throw new Exception(ex.Message);
           }
       }

        protected void FecharConexao()
       {
           try
           {
                Con.Close();
           }
           catch (Exception ex)
           {

                throw new Exception(ex.Message);
            }
       }

        #endregion
    }
}
