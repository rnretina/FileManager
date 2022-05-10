namespace FileManager;

public partial class RenameForm : Form
{
    private DirectoryView _directoryView;
    private string _selectedFile;

    public RenameForm(DirectoryView directoryView, string selectedFile)
    {
        _selectedFile = selectedFile;
        _directoryView = directoryView;
        KeyPreview = true;
        InitializeComponent();
    }

    private void RenameForm_Submit(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            var newPath = Path.Combine(_directoryView.CurrentPath, textBox1.Text + Path.GetExtension(_selectedFile));
            if (File.Exists(newPath))
            {
                File.Move(_selectedFile, newPath);
            }
            else
            {
                Directory.Move(_selectedFile, newPath);
            }
            _directoryView.Update();
            Close();
        }
    }
}
