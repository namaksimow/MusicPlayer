using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class GetStatistics : Form
{
    private readonly IJoinRepository _joinRepository;
    
    private readonly int _userId;
    
    public GetStatistics(int userId, IJoinRepository joinRepository)
    {
        _joinRepository = joinRepository;
        _userId = userId;
        InitializeComponent();
        LoadStatistics();
    }

    private void LoadStatistics()
    {
        var data = _joinRepository.GetStatisticsByUserId(_userId);
        dgvGetStatistics.DataSource = data.ToList();
    }
}