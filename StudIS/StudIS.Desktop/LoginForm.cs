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

        private void submitButton_Click(object sender, EventArgs e)
        {
            var email = this.emailTextBox.Text;
            var password = this.passwordTextBox.Text;

            var loginResult = _controller.Login(email, password);
        }
    }
}
