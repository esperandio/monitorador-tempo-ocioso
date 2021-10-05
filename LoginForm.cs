using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoramentoTempoOcioso
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals(""))
            {
                MessageBox.Show("É necessário informar o usuário");
                txtUser.Focus();
                return;
            }

            if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("É necessário informar a senha");
                txtPassword.Focus();
                return;
            }

            _ = AuthenticateAsync(txtUser.Text, txtPassword.Text);
        }

        private async Task AuthenticateAsync(string userName, string password)
        {
            try
            {
                btnLogin.Enabled = false;

                AuthenticatedUser user = await AuthenticatedUser.AuthenticateAsync(userName, password);

                MessageBox.Show(user.Identifier());

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
