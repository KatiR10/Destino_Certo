using System;
using MySqlConnector;
using System.Collections.Generic;

namespace DestinoCerto.Models
{
    public class PacotesTuristicosRepository
    {
        private const string DadosConexao = "Database = DestinoCerto;Data Source = localhost; User Id=root;";


        public List<PacotesTuristicos> listar()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM PacotesTuristicos";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<PacotesTuristicos> Lista = new List<PacotesTuristicos>();

            while (Reader.Read())
            {
                PacotesTuristicos PacotesEncontrado = new PacotesTuristicos();
                PacotesEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                PacotesEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                PacotesEncontrado.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                PacotesEncontrado.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                PacotesEncontrado.Atrativos = Reader.GetString("Atrativos");


                PacotesEncontrado.Saida = Reader.GetDateTime("Saida");
                PacotesEncontrado.Retorno = Reader.GetDateTime("Retorno");
                PacotesEncontrado.Usuario = Reader.GetInt32("Usuario");

                Lista.Add(PacotesEncontrado);

            }

            Conexao.Close();
            return Lista;
        }
        public void inserir(PacotesTuristicos pacotes)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "INSERT INTO PacotesTuristicos (Nome, Origem, Destino, Atrativos, Saida, Retorno, Usuario) VALUES (@Nome, @Origem, @Destino, @Atrativos, @Saida, @Retorno, @Usuario)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", pacotes.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacotes.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacotes.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacotes.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacotes.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacotes.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacotes.Usuario);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }



        public void editar(PacotesTuristicos pacotes)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "UPDATE PacotesTuristicos SET Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);


            Comando.Parameters.AddWithValue("@Id", pacotes.Id);
            Comando.Parameters.AddWithValue("@Nome", pacotes.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacotes.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacotes.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacotes.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacotes.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacotes.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacotes.Usuario);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }

        public void remover(PacotesTuristicos pacotes)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "DELETE FROM PacotesTuristicos WHERE Id = @Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", pacotes.Id);
            Comando.ExecuteNonQuery();


            Conexao.Close();

        }
         public PacotesTuristicos buscarPorId(int Id)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM PacotesTuristicos WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();
             PacotesTuristicos PacotesEncontrado = new PacotesTuristicos();

             if (Reader.Read()){

             
                PacotesEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                PacotesEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                PacotesEncontrado.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                PacotesEncontrado.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                PacotesEncontrado.Atrativos = Reader.GetString("Atrativos");


                PacotesEncontrado.Saida = Reader.GetDateTime("Saida");
                PacotesEncontrado.Retorno = Reader.GetDateTime("Retorno");
                PacotesEncontrado.Usuario = Reader.GetInt32("Usuario");

             }


            Conexao.Close();
            return PacotesEncontrado;
        }


    }
}
