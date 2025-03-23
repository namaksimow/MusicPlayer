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
        btnMainPlay = new System.Windows.Forms.Button();
        btnMainStop = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnMainUpload
        // 
        btnMainUpload.Location = new System.Drawing.Point(659, 12);
        btnMainUpload.Name = "btnMainUpload";
        btnMainUpload.Size = new System.Drawing.Size(129, 49);
        btnMainUpload.TabIndex = 0;
        btnMainUpload.Text = "Upload";
        btnMainUpload.UseVisualStyleBackColor = true;
        btnMainUpload.Click += btnMainUpload_Click;
        // 
        // listBoxMain
        // 
        listBoxMain.FormattingEnabled = true;
        listBoxMain.ItemHeight = 15;
        listBoxMain.Location = new System.Drawing.Point(164, 12);
        listBoxMain.Name = "listBoxMain";
        listBoxMain.Size = new System.Drawing.Size(489, 754);
        listBoxMain.TabIndex = 1;
        listBoxMain.SelectedIndexChanged += listBoxMain_SelectedIndexChanged;
        // 
        // btnMainPlay
        // 
        btnMainPlay.Location = new System.Drawing.Point(354, 772);
        btnMainPlay.Name = "btnMainPlay";
        btnMainPlay.Size = new System.Drawing.Size(129, 49);
        btnMainPlay.TabIndex = 2;
        btnMainPlay.Text = "Play";
        btnMainPlay.UseVisualStyleBackColor = true;
        btnMainPlay.Click += btnMainPlay_Click;
        // 
        // btnMainStop
        // 
        btnMainStop.Location = new System.Drawing.Point(489, 772);
        btnMainStop.Name = "btnMainStop";
        btnMainStop.Size = new System.Drawing.Size(129, 49);
        btnMainStop.TabIndex = 3;
        btnMainStop.Text = "Stop";
        btnMainStop.UseVisualStyleBackColor = true;
        btnMainStop.Click += btnMainStop_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(794, 837);
        Controls.Add(btnMainStop);
        Controls.Add(btnMainPlay);
        Controls.Add(listBoxMain);
        Controls.Add(btnMainUpload);
        Text = "test";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnMainStop;

    private System.Windows.Forms.Button btnMainPlay;

    private System.Windows.Forms.ListBox listBoxMain;

    private System.Windows.Forms.Button btnMainUpload;

    #endregion
}