using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudIS.Models.Users;
using StudIS.DAL;
using StudIS.DAL.Repositories;
using StudIS.Services;
using StudIS.Desktop.Controllers;

namespace StudIS.Desktop
{
    public partial class LoginForm : Form
    {
        private readonly LoginFormController _controller;

        public LoginForm(LoginFormController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        public bool LoginResult { get; set; } = false;

        private void submitButton_Click(object sender, EventArgs e)
        {
            var email = this.emailTextBox.Text;
            var password = this.passwordTextBox.Text;

            if (email.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("E-mail adresa i/ili lozinka nisu uneseni", "Unesite podatke za prijavu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var loginResult = _controller.Login(email, password);

            if (loginResult)
            {
                this.LoginResult = true;
                this.Close();
            }
        }

        private void studIsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
