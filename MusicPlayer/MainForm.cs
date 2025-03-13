namespace MusicPlayer;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void btnMainFormUploadFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string saveDirectory = "C:\\notSystem\\vcs\\MusicPlayer\\MusicPlayer\\Tracks";
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string fileName = Path.GetFileName(openFileDialog.FileName);
            Console.WriteLine(fileName);
            string fileSavePath = Path.Combine(saveDirectory, fileName);
            File.Copy(openFileDialog.FileName, fileSavePath);
        }
    }
}