using System.Security.Cryptography;
using System.Text;
using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class Registration : Form
{
    private readonly IUserRepository _userRepository;
    private readonly ISelectionRepository _selectionRepository;
    
    public Registration(IUserRepository userRepository,  ISelectionRepository selectionRepository)
    {
        _userRepository = userRepository;
        _selectionRepository = selectionRepository;
        InitializeComponent();
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


    private void btnRegRegistration_Click(object sender, EventArgs e)
    {
        string login = textBoxRegLogin.Text;
        string password = textBoxRegPassword.Text;

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show(@"Пожалуйста введите логин или пароль");
            return;
        }
        
        bool isExist = _userRepository.GetUser(login);

        if (isExist)
        {
            MessageBox.Show(@"Такой логин занят, попробуйте другой");
            return;
        }
        
        string passwordHash = GetPasswordHash(password);
        
        _userRepository.Add(login, password, passwordHash);
        int userId = _userRepository.GetId(login);
        _selectionRepository.AddSelection("Загруженные", userId);
        Close();
    }   
}