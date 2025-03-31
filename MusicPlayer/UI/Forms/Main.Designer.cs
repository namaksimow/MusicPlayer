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
        listBoxMain = new System.Windows.Forms.ListBox();
        trackBarMain = new System.Windows.Forms.TrackBar();
        ((System.ComponentModel.ISupportInitialize)trackBarMain).BeginInit();
        SuspendLayout();
        // 
        // btnMainUpload
        // 
        btnMainUpload.Location = new System.Drawing.Point(653, 21);
        btnMainUpload.Name = "btnMainUpload";
        btnMainUpload.Size = new System.Drawing.Size(129, 54);
        btnMainUpload.TabIndex = 7;
        btnMainUpload.Text = "Upload";
        btnMainUpload.UseVisualStyleBackColor = true;
        btnMainUpload.Click += btnMainUpload_Click;
        // 
        // listBoxMain
        // 
        listBoxMain.FormattingEnabled = true;
        listBoxMain.ItemHeight = 15;
        listBoxMain.Location = new System.Drawing.Point(104, 21);
        listBoxMain.Name = "listBoxMain";
        listBoxMain.Size = new System.Drawing.Size(543, 634);
        listBoxMain.TabIndex = 8;
        listBoxMain.MouseDown += listBoxMain_MouseDown;
        // 
        // trackBarMain
        // 
        trackBarMain.Location = new System.Drawing.Point(668, 610);
        trackBarMain.Name = "trackBarMain";
        trackBarMain.Size = new System.Drawing.Size(114, 45);
        trackBarMain.TabIndex = 9;
        trackBarMain.Scroll += trackBarMain_Scroll;
        // 
        // Main
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(794, 786);
        Controls.Add(trackBarMain);
        Controls.Add(listBoxMain);
        Controls.Add(btnMainUpload);
        Location = new System.Drawing.Point(15, 15);
        ((System.ComponentModel.ISupportInitialize)trackBarMain).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TrackBar trackBarMain;

    private System.Windows.Forms.ListBox listBoxMain;

    private System.Windows.Forms.Button btnMainUpload;

    #endregion
}