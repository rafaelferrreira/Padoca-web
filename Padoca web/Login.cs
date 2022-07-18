using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Padoca_web
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //conexão com banco de dados sql server

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-K42C9QU\SQLEXPRESS; integrated security=SSPI;initial Catalog=db_padocaweb");

        SqlCommand cm = new SqlCommand();

        SqlDataReader dt;


        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        private void panelSenha_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureCadeado_Click(object sender, EventArgs e)
        {

        }

        private void pictureCadeado_MouseDown(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = false;
        }

        private void pictureCadeado_MouseUp(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtSenha.Text == "") 
            {
                MessageBox.Show("Obrigatorio preencher os campos login e senha", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    cn.Open();
                    cm.CommandText = "select * from tbl_funcionario where ds_Login= ('" + txtLogin.Text + "') and ds_Senha = ('" + txtSenha.Text + "')";
                    cm.Connection = cn;
                    dt = cm.ExecuteReader();

                    if (dt.HasRows)
                    {
                        frmMenu menu = new frmMenu();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("usuário ou senha invalidos", "Ocorreu um erro!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Clear();
                        txtSenha.Clear();
                        txtLogin.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                    cn.Close();
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}
