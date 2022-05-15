﻿using System.Text.Json;
using System.Xml.Serialization;

namespace FileManager
{
    public partial class AdmissionForm : Form
    {
        private AuthorizationFields _authorizationFields;
        private string? _login, _password;
        public AdmissionForm()
        {
            KeyPreview = true;
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            using var fs = new FileStream("authorization.json", FileMode.OpenOrCreate);
            _authorizationFields = JsonSerializer.Deserialize<AuthorizationFields>(fs);
        }

       private void ButtonSubmit(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxLogin.Text == _authorizationFields.Login &&
                    textBoxPassword.Text == _authorizationFields.Password)
                {
                    Hide();
                    new MainForm().Show();
                }
            }
        }
    }
}
