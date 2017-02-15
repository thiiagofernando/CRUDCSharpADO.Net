using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Model;

//Regras de Negocios  - Consultas , Select,UPDATE, Insert,Delete,ObterPorID

namespace DAL.Persistence
{
    public class PessoaDAL : Conexao
    {
        #region gravar dados
        public void Gravar(Pessoa p)
        {
            try
            {
                //Abrir Conexao
                AbrirConexao();
                Cmd = new SqlCommand("insert into Pessoa(Nome,Endereco,Email) values(@v1,@v2,@v3)", Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.Endereco);
                Cmd.Parameters.AddWithValue("@v3", p.Email);

                Cmd.ExecuteNonQuery();//executar metodo
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Gravar Cliente" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion

        #region AtualizarDados

        public void AtualizarDados(Pessoa p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("update Pessoa set Nome=@v1, Endereco=@v2,Email=@v3 where Codigo=@v4", Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.Endereco);
                Cmd.Parameters.AddWithValue("@v3", p.Email);
                Cmd.Parameters.AddWithValue("@v4", p.Codigo);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao Atualizar Cliente" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion

        #region ExcluirDados

        public void Excluir(int Codigo)
        {
            try
            {
                AbrirConexao();
                Cmd =new SqlCommand("delete from Pessoa where Codigo=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", Codigo);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao Excluir Cliente" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion

        #region ConsultarPorCodigo

        public Pessoa PesquisarPorCodigo(int Codigo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Pessoa where Codigo=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", Codigo);

                Pessoa p = null; // Criando um espaço de memoria : ponteiro

                if (Dr.Read())
                {
                    p = new Pessoa();
                    p.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.Endereco = Convert.ToString(Dr["Endereco"]);
                    p.Email = Convert.ToString(Dr["Email"]);
                }
                return p;
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao Consultar Cliente" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        #endregion

        #region ListaClienteCadastrados

        public List<Pessoa> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("Select * from Pessoa", Con);
                Dr = Cmd.ExecuteReader();

                List<Pessoa> lista = new List<Pessoa>();// lista vazia

                while (Dr.Read())
                {
                    Pessoa p = new Pessoa();
                    p.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.Endereco = Convert.ToString(Dr["Endereco"]);
                    p.Email = Convert.ToString(Dr["Email"]);

                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao Listar Clientes " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        } 
        #endregion


    }
}
