using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string conexaoString = "server=localhost;user=root;password=;database=db_quiz_p;";
            string valor = "";
            long ultimoID = 0;

            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                conexao.Open();
                string scriptInsert = "INSERT INTO tb_perguntas (coluna) VALUE (@valor)";

                using (MySqlCommand comando = new MySqlCommand(scriptInsert, conexao))
                {
                    //substitui os parametros para os valores reais
                    comando.Parameters.AddWithValue("@valor", valor);

                    comando.ExecuteNonQuery();

                    ultimoID = comando.LastInsertedId;
                }
            }
        }
    }
}
