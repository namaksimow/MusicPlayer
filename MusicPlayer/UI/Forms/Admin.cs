using ClosedXML.Excel;
using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;

namespace MusicPlayer.UI.Forms;

public partial class Admin : Form
{
    private readonly IJoinRepository _joinRepository;
    private readonly IUserRepository _userRepository;
        
    private readonly string FilePath = "C:\\notSystem\\vcs\\MusicPlayer\\MusicPlayer";
    private readonly string FileName = "Statistics.xlsx";
    
    public Admin(IJoinRepository joinRepository,  IUserRepository userRepository)
    {
        _joinRepository = joinRepository;
        _userRepository = userRepository;
        InitializeComponent();
        LoadUsersData();
        LoadUsers();
    }

    private void LoadUsers()
    {
        List<string> data = _userRepository.GetUsersName();
        listBoxAdminUsers.Items.AddRange(data.ToArray());
    }
    
    private void LoadUsersData()
    {
        var data = _joinRepository.GetStatistics();
        dgvAdmin.DataSource = data.ToList();
    }

    private void btnLoadUsersData_Click(object sender, EventArgs e)
    {
        List<SongDate> result = _joinRepository.GetStatistics();
        
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Статистика песен");

            worksheet.Cell(1, 1).Value = "Название песни";
            worksheet.Cell(1, 2).Value = "Исполнитель";
            worksheet.Cell(1, 3).Value = "Плейлист";
            worksheet.Cell(1, 4).Value = "Дата";
            worksheet.Cell(1, 5).Value = "Пользователь";
            
            for (int i = 0; i < result.Count; i++)
            {
                var item = result[i];
                worksheet.Cell(i + 2, 1).Value = item.SongTitle;
                worksheet.Cell(i + 2, 2).Value = item.PerformerName;
                worksheet.Cell(i + 2, 3).Value = item.PlaylistName;
                worksheet.Cell(i + 2, 4).Value = item.Date;
                worksheet.Cell(i + 2, 5).Value = item.UserName;
            }
            
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(Path.Combine(FilePath, FileName));
        }

    }

    private void listBoxAdminUsers_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            listBoxAdminUsers.ContextMenuStrip = contextMenuStripUserEdit;
        }

        else
        {
            listBoxAdminUsers.ContextMenuStrip = null;
        }
    }

    private void toolStripMenuItemDeleteUser_Click(object sender, EventArgs e)
    {
        int index = listBoxAdminUsers.SelectedIndex;
        if (index != -1)
        {
            string user = listBoxAdminUsers.Items[index].ToString()!;
               
        }
    }
}