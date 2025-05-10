using System.Security.Cryptography;
using System.Text;
using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;

namespace MusicPlayer.UI.Forms;

public partial class RegAndAuth : Form
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly ISelectionRepository _selectionRepository;

    public int Role;
    
    public RegAndAuth(IUserRepository userRepository,  IUserService userService,  ISelectionRepository selectionRepository)
    {
        _userRepository = userRepository;
        _userService = userService;
        _selectionRepository = selectionRepository;
        InitializeComponent();
    }

    private void btnRAARegistration_Click(object sender, EventArgs e)
    {
        Registration form = new Registration(_userRepository, _selectionRepository);
        form.Show();
    }
    
    private string GetPasswordHash(string password)
    {
        using (SHA1 sha1Hash = SHA1.Create())
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hash;
        }
    }
    
    private void btnRAAEnter_Click(object sender, EventArgs e)
    {
        string login = textBoxRAALogin.Text;
        string password = textBoxRAAPassword.Text;
        
        if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
        {
            MessageBox.Show(@"Пожалуйста, введите логин или пароль");
            return;
        }
        
        string passwordHash = GetPasswordHash(password);
        bool isExist = _userRepository.GetUser(login);
        
        if (!isExist)
        {
            MessageBox.Show(@"Неверный логин или пароль");
            return;
        }

        string hashByLogin = _userRepository.GetPasswordByLogin(login);
        if (hashByLogin != passwordHash)
        {
            MessageBox.Show(@"Неверный логин или пароль");
            return;
        }

        int userRole = _userRepository.GetUserRole(login);
        int userId = _userRepository.GetId(login);
        _userService.SetId(userId);
        Role = userRole;
        
        DialogResult = DialogResult.OK;
        Close();
    }
}