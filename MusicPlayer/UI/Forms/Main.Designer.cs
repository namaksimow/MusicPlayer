using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class Main
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
        btnMainUpload = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnMainUpload
        // 
        btnMainUpload.Location = new System.Drawing.Point(168, 131);
        btnMainUpload.Name = "btnMainUpload";
        btnMainUpload.Size = new System.Drawing.Size(149, 90);
        btnMainUpload.TabIndex = 0;
        btnMainUpload.Text = "Upload";
        btnMainUpload.UseVisualStyleBackColor = true;
        btnMainUpload.Click += btnMainUpload_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btnMainUpload);
        Text = "test";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnMainUpload;

    #endregion
}