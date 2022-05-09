using System.Xml.Serialization;

namespace FileManager
{
    public partial class AdmissionForm : Form
    {
        public AdmissionForm()
        {
            KeyPreview = true;
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }

       private void ButtonSubmit(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var gui = new GUI();
                var login = textBoxLogin.Text;
                var serializer = new XmlSerializer(typeof(GUI));
                using var tw = new StreamWriter(@"D:\fm\gui.xml");
                serializer.Serialize(tw, gui);
                Hide();
                tw.Close();
                new MainForm().Show();
            }
        }
    }
}
