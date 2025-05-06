using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class AddSongToPlaylist
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
        listBoxASTPPlaylistPick = new System.Windows.Forms.ListBox();
        listBoxASTPPlaylistChosen = new System.Windows.Forms.ListBox();
        label1 = new System.Windows.Forms.Label();
        buttonASTPAdd = new System.Windows.Forms.Button();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // listBoxASTPPlaylistPick
        // 
        listBoxASTPPlaylistPick.FormattingEnabled = true;
        listBoxASTPPlaylistPick.ItemHeight = 15;
        listBoxASTPPlaylistPick.Location = new System.Drawing.Point(22, 108);
        listBoxASTPPlaylistPick.Name = "listBoxASTPPlaylistPick";
        listBoxASTPPlaylistPick.Size = new System.Drawing.Size(189, 304);
        listBoxASTPPlaylistPick.TabIndex = 0;
        listBoxASTPPlaylistPick.MouseDown += listBoxASTPPlaylistPick_MouseDown;
        // 
        // listBoxASTPPlaylistChosen
        // 
        listBoxASTPPlaylistChosen.FormattingEnabled = true;
        listBoxASTPPlaylistChosen.ItemHeight = 15;
        listBoxASTPPlaylistChosen.Location = new System.Drawing.Point(243, 108);
        listBoxASTPPlaylistChosen.Name = "listBoxASTPPlaylistChosen";
        listBoxASTPPlaylistChosen.Size = new System.Drawing.Size(189, 304);
        listBoxASTPPlaylistChosen.TabIndex = 1;
        listBoxASTPPlaylistChosen.MouseDown += listBoxASTPPlaylistChosen_MouseDown;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 15F);
        label1.Location = new System.Drawing.Point(22, 6);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(410, 27);
        label1.TabIndex = 2;
        label1.Text = "Pick playlist to add";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // buttonASTPAdd
        // 
        buttonASTPAdd.Location = new System.Drawing.Point(172, 434);
        buttonASTPAdd.Name = "buttonASTPAdd";
        buttonASTPAdd.Size = new System.Drawing.Size(101, 52);
        buttonASTPAdd.TabIndex = 3;
        buttonASTPAdd.Text = "Add";
        buttonASTPAdd.UseVisualStyleBackColor = true;
        buttonASTPAdd.Click += buttonASTPAdd_Click;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 15F);
        label2.Location = new System.Drawing.Point(30, 51);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(181, 37);
        label2.TabIndex = 4;
        label2.Text = "Playlists";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 15F);
        label3.Location = new System.Drawing.Point(243, 51);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(189, 37);
        label3.TabIndex = 5;
        label3.Text = "Chosen playlists";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // AddSongToPlaylist
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(451, 498);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(buttonASTPAdd);
        Controls.Add(label1);
        Controls.Add(listBoxASTPPlaylistChosen);
        Controls.Add(listBoxASTPPlaylistPick);
        Text = "AddSongToPlaylist";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Button buttonASTPAdd;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ListBox listBoxASTPPlaylistPick;
    private System.Windows.Forms.ListBox listBoxASTPPlaylistChosen;

    #endregion
}