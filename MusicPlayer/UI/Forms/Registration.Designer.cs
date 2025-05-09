using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class Registration
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
        lblRegYourFutureLogin = new System.Windows.Forms.Label();
        lblRegYourFuturePassword = new System.Windows.Forms.Label();
        textBoxRegLogin = new System.Windows.Forms.TextBox();
        textBoxRegPassword = new System.Windows.Forms.TextBox();
        btnRegRegistration = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // lblRegYourFutureLogin
        // 
        lblRegYourFutureLogin.Location = new System.Drawing.Point(15, 100);
        lblRegYourFutureLogin.Name = "lblRegYourFutureLogin";
        lblRegYourFutureLogin.Size = new System.Drawing.Size(148, 25);
        lblRegYourFutureLogin.TabIndex = 0;
        lblRegYourFutureLogin.Text = "Ваш будущий логин";
        lblRegYourFutureLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblRegYourFuturePassword
        // 
        lblRegYourFuturePassword.Location = new System.Drawing.Point(15, 136);
        lblRegYourFuturePassword.Name = "lblRegYourFuturePassword";
        lblRegYourFuturePassword.Size = new System.Drawing.Size(148, 25);
        lblRegYourFuturePassword.TabIndex = 1;
        lblRegYourFuturePassword.Text = "Ваш будущий пароль";
        lblRegYourFuturePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textBoxRegLogin
        // 
        textBoxRegLogin.Location = new System.Drawing.Point(183, 102);
        textBoxRegLogin.Name = "textBoxRegLogin";
        textBoxRegLogin.Size = new System.Drawing.Size(227, 23);
        textBoxRegLogin.TabIndex = 2;
        // 
        // textBoxRegPassword
        // 
        textBoxRegPassword.Location = new System.Drawing.Point(183, 136);
        textBoxRegPassword.Name = "textBoxRegPassword";
        textBoxRegPassword.Size = new System.Drawing.Size(227, 23);
        textBoxRegPassword.TabIndex = 3;
        // 
        // btnRegRegistration
        // 
        btnRegRegistration.Location = new System.Drawing.Point(119, 194);
        btnRegRegistration.Name = "btnRegRegistration";
        btnRegRegistration.Size = new System.Drawing.Size(184, 41);
        btnRegRegistration.TabIndex = 4;
        btnRegRegistration.Text = "Зарегистрироваться";
        btnRegRegistration.UseVisualStyleBackColor = true;
        btnRegRegistration.Click += btnRegRegistration_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 15F);
        label1.Location = new System.Drawing.Point(99, 26);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(226, 56);
        label1.TabIndex = 5;
        label1.Text = "Введите данные";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Registration
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(422, 288);
        Controls.Add(label1);
        Controls.Add(btnRegRegistration);
        Controls.Add(textBoxRegPassword);
        Controls.Add(textBoxRegLogin);
        Controls.Add(lblRegYourFuturePassword);
        Controls.Add(lblRegYourFutureLogin);
        Text = "Registration";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label lblRegYourFuturePassword;
    private System.Windows.Forms.TextBox textBoxRegLogin;
    private System.Windows.Forms.TextBox textBoxRegPassword;
    private System.Windows.Forms.Button btnRegRegistration;

    private System.Windows.Forms.Label lblRegYourFutureLogin;

    #endregion
}