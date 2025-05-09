using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class RegAndAuth
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblRAALogin = new System.Windows.Forms.Label();
        lblRAAPassword = new System.Windows.Forms.Label();
        lblRAAWelcome = new System.Windows.Forms.Label();
        lblRAAEnterYourData = new System.Windows.Forms.Label();
        textBoxRAALogin = new System.Windows.Forms.TextBox();
        textBoxRAAPassword = new System.Windows.Forms.TextBox();
        btnRAAEnter = new System.Windows.Forms.Button();
        btnRAARegistration = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // lblRAALogin
        // 
        lblRAALogin.Location = new System.Drawing.Point(35, 137);
        lblRAALogin.Name = "lblRAALogin";
        lblRAALogin.Size = new System.Drawing.Size(90, 40);
        lblRAALogin.TabIndex = 0;
        lblRAALogin.Text = "Логин";
        lblRAALogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblRAAPassword
        // 
        lblRAAPassword.Location = new System.Drawing.Point(35, 177);
        lblRAAPassword.Name = "lblRAAPassword";
        lblRAAPassword.Size = new System.Drawing.Size(90, 40);
        lblRAAPassword.TabIndex = 1;
        lblRAAPassword.Text = "Пароль";
        lblRAAPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblRAAWelcome
        // 
        lblRAAWelcome.Font = new System.Drawing.Font("Segoe UI", 15F);
        lblRAAWelcome.Location = new System.Drawing.Point(114, 9);
        lblRAAWelcome.Name = "lblRAAWelcome";
        lblRAAWelcome.Size = new System.Drawing.Size(217, 42);
        lblRAAWelcome.TabIndex = 2;
        lblRAAWelcome.Text = "Добро пожаловать ";
        lblRAAWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblRAAEnterYourData
        // 
        lblRAAEnterYourData.Font = new System.Drawing.Font("Segoe UI", 15F);
        lblRAAEnterYourData.Location = new System.Drawing.Point(114, 51);
        lblRAAEnterYourData.Name = "lblRAAEnterYourData";
        lblRAAEnterYourData.Size = new System.Drawing.Size(217, 42);
        lblRAAEnterYourData.TabIndex = 3;
        lblRAAEnterYourData.Text = "Введите свои данные";
        lblRAAEnterYourData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textBoxRAALogin
        // 
        textBoxRAALogin.Location = new System.Drawing.Point(114, 147);
        textBoxRAALogin.Name = "textBoxRAALogin";
        textBoxRAALogin.Size = new System.Drawing.Size(270, 23);
        textBoxRAALogin.TabIndex = 4;
        // 
        // textBoxRAAPassword
        // 
        textBoxRAAPassword.Location = new System.Drawing.Point(114, 187);
        textBoxRAAPassword.Name = "textBoxRAAPassword";
        textBoxRAAPassword.Size = new System.Drawing.Size(270, 23);
        textBoxRAAPassword.TabIndex = 5;
        // 
        // btnRAAEnter
        // 
        btnRAAEnter.Location = new System.Drawing.Point(137, 235);
        btnRAAEnter.Name = "btnRAAEnter";
        btnRAAEnter.Size = new System.Drawing.Size(164, 39);
        btnRAAEnter.TabIndex = 6;
        btnRAAEnter.Text = "Войти";
        btnRAAEnter.UseVisualStyleBackColor = true;
        btnRAAEnter.Click += btnRAAEnter_Click;
        // 
        // btnRAARegistration
        // 
        btnRAARegistration.Location = new System.Drawing.Point(137, 280);
        btnRAARegistration.Name = "btnRAARegistration";
        btnRAARegistration.Size = new System.Drawing.Size(164, 39);
        btnRAARegistration.TabIndex = 7;
        btnRAARegistration.Text = "Зарегистрироваться";
        btnRAARegistration.UseVisualStyleBackColor = true;
        btnRAARegistration.Click += btnRAARegistration_Click;
        // 
        // RegAndAuth
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(440, 345);
        Controls.Add(btnRAARegistration);
        Controls.Add(btnRAAEnter);
        Controls.Add(textBoxRAAPassword);
        Controls.Add(textBoxRAALogin);
        Controls.Add(lblRAAEnterYourData);
        Controls.Add(lblRAAWelcome);
        Controls.Add(lblRAAPassword);
        Controls.Add(lblRAALogin);
        Text = "RegAndAuth";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnRAARegistration;

    private System.Windows.Forms.Label lblRAAEnterYourData;
    private System.Windows.Forms.TextBox textBoxRAALogin;
    private System.Windows.Forms.TextBox textBoxRAAPassword;
    private System.Windows.Forms.Button btnRAAEnter;

    private System.Windows.Forms.Label lblRAAPassword;
    private System.Windows.Forms.Label lblRAAWelcome;

    private System.Windows.Forms.Label lblRAALogin;

    #endregion
}