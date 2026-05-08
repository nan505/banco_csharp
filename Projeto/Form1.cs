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
using MySqlConnector;

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
            string campoNome = txtNome.Text;
            int controleLinhasAfetadas = 0;

            string dadosConexao = 
                "server=localhost;user=root;password=;database=projeto_banco_csharp";
            using (MySqlConnection conn = new MySqlConnection(dadosConexao) )
            {// utilizo das informações
                conn.Open();
                string scriptInsert = "INSERT INTO tb_cadastro (nome) VALUE (@nome)";

                using (MySqlCommand comando = new MySqlCommand(scriptInsert,conn))
                {
                    comando.Parameters.AddWithValue("@nome", campoNome);

                    controleLinhasAfetadas = comando.ExecuteNonQuery();
                }
                conn.Close();
            }//MysqlConnection

            if (controleLinhasAfetadas > 0)
            {
                MessageBox.Show("Dados salvo com sucesso!");
            } else
            {
                MessageBox.Show("Ops. Algo deu errado!!!");
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarLista_Click(object sender, EventArgs e)
        {
            
        }
    }
}
