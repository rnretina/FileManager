using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace FileManager;

public partial class MainForm : Form
{
    private DirectoryView _leftDirectoryView;
    private DirectoryView _rightDirectoryView;
    private GUI _gui;

    public MainForm()
    {
        KeyPreview = true;

        InitializeComponent();
        var deserializer = new XmlSerializer(typeof(GUI));
        using var reader = new StreamReader(@"D:\fm\gui.xml");
        _gui = (GUI)deserializer.Deserialize(reader);
        ChangeTheme(255, 255, 255);
        SetFonts("Segoe UI");
        comboBoxFont.Items.AddRange(_gui.Fonts);
        comboBoxColor.Items.AddRange(_gui.Themes);

            var drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            listBoxLeft.Items.Add(drive.Name);
            listBoxRight.Items.Add(drive.Name);
        }

        _leftDirectoryView = new DirectoryView(listBoxLeft, labelLeft);
        _rightDirectoryView = new DirectoryView(listBoxRight, labelRight);
    }

    private void SetFonts(string font)
    {
        buttonCopy.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonDelete.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonEdit.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonLeftBack.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonMove.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonView.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonRightBack.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonLeftBack.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        buttonArchiving.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        labelLeft.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        labelRight.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        listBoxRight.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
        listBoxLeft.Font = new Font(font, 9F, FontStyle.Regular, GraphicsUnit.Point);
    }

    private void ChangeForeColor(int red, int green, int blue)
    {
        var color = red + green + blue < 500 ? Color.White : Color.Black;
        buttonCopy.ForeColor = color;
        buttonDelete.ForeColor = color;
        buttonEdit.ForeColor = color;
        buttonLeftBack.ForeColor = color;
        buttonMove.ForeColor = color;
        buttonView.ForeColor = color;
        buttonRightBack.ForeColor = color;
        buttonLeftBack.ForeColor = color;
        buttonArchiving.ForeColor = color;
        labelLeft.ForeColor = color;
        labelRight.ForeColor = color;
        listBoxRight.ForeColor = color;
        listBoxLeft.ForeColor = color;
    }

    private void ChangeTheme(int red, int green, int blue)
    {
        comboBoxColor.BackColor = Color.FromArgb(red - 10, green, blue);
        comboBoxFont.BackColor = Color.FromArgb(red - 10, green, blue);
        BackColor = Color.FromArgb(red, green, blue);
        buttonCopy.BackColor = Color.FromArgb(red - 10, green, blue);
        buttonDelete.BackColor = Color.FromArgb(red - 10, green, blue);
        buttonView.BackColor = Color.FromArgb(red - 10, green, blue);
        buttonMove.BackColor = Color.FromArgb(red - 10, green, blue);
        buttonLeftBack.BackColor = Color.FromArgb(red - 10, green, blue);
        buttonRightBack.BackColor = Color.FromArgb(red - 10, green, blue);
        buttonArchiving.BackColor = Color.FromArgb(red -10, green, blue);
        buttonEdit.BackColor = Color.FromArgb(red - 10, green, blue);
        listBoxRight.BackColor = Color.FromArgb(red- 30, green -10, blue);
        listBoxLeft.BackColor = Color.FromArgb(red - 30, green -10, blue);
    }


private void MainForm_KeyDown_View(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F4)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                _leftDirectoryView.View();
            }
            else if (listBoxRight.SelectedItem != null)
            {
                _rightDirectoryView.View();
            }
        }
    }

    private void MainForm_KeyDown_Delete(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F8)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                _leftDirectoryView.Delete();
            }
            else if (listBoxRight.SelectedItem != null)
            {
                _rightDirectoryView.Delete();
            }
        }
    }

    private void MainForm_KeyDown_Move(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F6)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                _leftDirectoryView.MoveTo(_rightDirectoryView);
            }
            else if (listBoxRight.SelectedItem != null)
            {
                _rightDirectoryView.MoveTo(_leftDirectoryView);
            }
        }
    }

    private void MainForm_KeyDown_Archiving(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F10)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                _leftDirectoryView.Archive();
            }
            else if (listBoxRight.SelectedItem != null)
            {
                _rightDirectoryView.Archive();
            }
        }
    }

    private void MainForm_KeyDown_Rename(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                _leftDirectoryView.Rename();
            }
            else if (listBoxRight.SelectedItem != null)
            {
                _rightDirectoryView.Rename();
            }
        }
    }

    private void MainForm_KeyDown_Copy(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F7)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                _leftDirectoryView.Copy(_rightDirectoryView);
            }
            else if (listBoxRight.SelectedItem != null)
            {
                _rightDirectoryView.Copy(_leftDirectoryView);
            }
        }
    }

    private void buttonLeftBack_Click(object sender, EventArgs e)
    {
        if (_leftDirectoryView.CurrentPath.Length == 3)
        {
            _leftDirectoryView.CurrentPath = string.Empty;
        }
        else if (_leftDirectoryView.CurrentPath.LastIndexOf('\\') == 2)
        {
            _leftDirectoryView.CurrentPath =
                _leftDirectoryView.CurrentPath[..(_leftDirectoryView.CurrentPath.LastIndexOf('\\') + 1)];
        }
        else
        {
            _leftDirectoryView.CurrentPath =
                _leftDirectoryView.CurrentPath[.._leftDirectoryView.CurrentPath.LastIndexOf('\\')];
        }
        _leftDirectoryView.Update();
    }

    private void buttonRightBack_Click(object sender, EventArgs e)
    {
        if (_rightDirectoryView.CurrentPath.Length == 3)
        {
            _rightDirectoryView.CurrentPath = string.Empty;
        }
        else if (_rightDirectoryView.CurrentPath.LastIndexOf('\\') == 2)
        {
            _rightDirectoryView.CurrentPath =
                _rightDirectoryView.CurrentPath[..(_rightDirectoryView.CurrentPath.LastIndexOf('\\')+1)];
        }
        else
        {
            _rightDirectoryView.CurrentPath =
                _rightDirectoryView.CurrentPath[.._rightDirectoryView.CurrentPath.LastIndexOf('\\')];
        }
        _rightDirectoryView.Update();
    }

    private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxColor.SelectedItem.ToString() == "Night Owl")
        {
            ChangeTheme(95, 75, 120);
            ChangeForeColor(95, 75, 120 );
        }
        else if (comboBoxColor.SelectedItem.ToString() == "Material Ocean")
        {
            ChangeTheme(60, 105, 120);
            ChangeForeColor(60, 105, 120);
        }
        else if (comboBoxColor.SelectedItem.ToString() == "White")
        {
            ChangeTheme(255, 255, 255);
            ChangeForeColor(255, 255, 255);
        }
    }

    private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetFonts(comboBoxFont.SelectedItem.ToString());
    }
}