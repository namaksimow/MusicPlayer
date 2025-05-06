using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class AddPlaylist
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
        textBoxAPLName = new System.Windows.Forms.TextBox();
        labelAPLName = new System.Windows.Forms.Label();
        buttonAPLAdd = new System.Windows.Forms.Button();
        lblAPByMusicGenre = new System.Windows.Forms.Label();
        lblAPByPerformer = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        listBoxAPPickGenre = new System.Windows.Forms.ListBox();
        listBoxAPPickedGenre = new System.Windows.Forms.ListBox();
        listBoxAPPickPerformer = new System.Windows.Forms.ListBox();
        listBoxAPPickedPerformer = new System.Windows.Forms.ListBox();
        lblAPPickedGenre = new System.Windows.Forms.Label();
        lblAPPickedPerformer = new System.Windows.Forms.Label();
        textBoxAPDurationFrom = new System.Windows.Forms.TextBox();
        textBoxAPDurationTo = new System.Windows.Forms.TextBox();
        lblAPDurationFrom = new System.Windows.Forms.Label();
        lblAPDurationTo = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // textBoxAPLName
        // 
        textBoxAPLName.Location = new System.Drawing.Point(209, 40);
        textBoxAPLName.Name = "textBoxAPLName";
        textBoxAPLName.Size = new System.Drawing.Size(232, 23);
        textBoxAPLName.TabIndex = 0;
        // 
        // labelAPLName
        // 
        labelAPLName.Location = new System.Drawing.Point(263, 9);
        labelAPLName.Name = "labelAPLName";
        labelAPLName.Size = new System.Drawing.Size(131, 28);
        labelAPLName.TabIndex = 1;
        labelAPLName.Text = "Название плейлиста";
        labelAPLName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // buttonAPLAdd
        // 
        buttonAPLAdd.Location = new System.Drawing.Point(289, 547);
        buttonAPLAdd.Name = "buttonAPLAdd";
        buttonAPLAdd.Size = new System.Drawing.Size(120, 47);
        buttonAPLAdd.TabIndex = 2;
        buttonAPLAdd.Text = "Добавить";
        buttonAPLAdd.UseVisualStyleBackColor = true;
        buttonAPLAdd.Click += buttonAPLAdd_Click;
        // 
        // lblAPByMusicGenre
        // 
        lblAPByMusicGenre.Font = new System.Drawing.Font("Segoe UI", 15F);
        lblAPByMusicGenre.Location = new System.Drawing.Point(15, 86);
        lblAPByMusicGenre.Name = "lblAPByMusicGenre";
        lblAPByMusicGenre.Size = new System.Drawing.Size(185, 61);
        lblAPByMusicGenre.TabIndex = 3;
        lblAPByMusicGenre.Text = "По музыкальному жанру";
        lblAPByMusicGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblAPByPerformer
        // 
        lblAPByPerformer.Font = new System.Drawing.Font("Segoe UI", 15F);
        lblAPByPerformer.Location = new System.Drawing.Point(236, 86);
        lblAPByPerformer.Name = "lblAPByPerformer";
        lblAPByPerformer.Size = new System.Drawing.Size(185, 61);
        lblAPByPerformer.TabIndex = 4;
        lblAPByPerformer.Text = "По исполнителю";
        lblAPByPerformer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 15F);
        label1.Location = new System.Drawing.Point(450, 86);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(185, 61);
        label1.TabIndex = 5;
        label1.Text = "По длительности";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // listBoxAPPickGenre
        // 
        listBoxAPPickGenre.FormattingEnabled = true;
        listBoxAPPickGenre.ItemHeight = 15;
        listBoxAPPickGenre.Location = new System.Drawing.Point(26, 166);
        listBoxAPPickGenre.Name = "listBoxAPPickGenre";
        listBoxAPPickGenre.Size = new System.Drawing.Size(173, 154);
        listBoxAPPickGenre.TabIndex = 6;
        listBoxAPPickGenre.MouseDown += listBoxAPPickGenre_MouseDown;
        // 
        // listBoxAPPickedGenre
        // 
        listBoxAPPickedGenre.FormattingEnabled = true;
        listBoxAPPickedGenre.ItemHeight = 15;
        listBoxAPPickedGenre.Location = new System.Drawing.Point(26, 370);
        listBoxAPPickedGenre.Name = "listBoxAPPickedGenre";
        listBoxAPPickedGenre.Size = new System.Drawing.Size(173, 154);
        listBoxAPPickedGenre.TabIndex = 7;
        listBoxAPPickedGenre.MouseDown += listBoxAPPickedGenre_MouseDown;
        // 
        // listBoxAPPickPerformer
        // 
        listBoxAPPickPerformer.FormattingEnabled = true;
        listBoxAPPickPerformer.ItemHeight = 15;
        listBoxAPPickPerformer.Location = new System.Drawing.Point(236, 166);
        listBoxAPPickPerformer.Name = "listBoxAPPickPerformer";
        listBoxAPPickPerformer.Size = new System.Drawing.Size(173, 154);
        listBoxAPPickPerformer.TabIndex = 8;
        listBoxAPPickPerformer.MouseDown += listBoxAPPickPerformer_MouseDown;
        // 
        // listBoxAPPickedPerformer
        // 
        listBoxAPPickedPerformer.FormattingEnabled = true;
        listBoxAPPickedPerformer.ItemHeight = 15;
        listBoxAPPickedPerformer.Location = new System.Drawing.Point(236, 370);
        listBoxAPPickedPerformer.Name = "listBoxAPPickedPerformer";
        listBoxAPPickedPerformer.Size = new System.Drawing.Size(173, 154);
        listBoxAPPickedPerformer.TabIndex = 9;
        listBoxAPPickedPerformer.MouseDown += listBoxAPPickedPerformer_MouseDown;
        // 
        // lblAPPickedGenre
        // 
        lblAPPickedGenre.Location = new System.Drawing.Point(26, 336);
        lblAPPickedGenre.Name = "lblAPPickedGenre";
        lblAPPickedGenre.Size = new System.Drawing.Size(172, 22);
        lblAPPickedGenre.TabIndex = 10;
        lblAPPickedGenre.Text = "Выбранные жанры";
        lblAPPickedGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblAPPickedPerformer
        // 
        lblAPPickedPerformer.Location = new System.Drawing.Point(236, 336);
        lblAPPickedPerformer.Name = "lblAPPickedPerformer";
        lblAPPickedPerformer.Size = new System.Drawing.Size(173, 22);
        lblAPPickedPerformer.TabIndex = 11;
        lblAPPickedPerformer.Text = "Выбранные исполнители";
        lblAPPickedPerformer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textBoxAPDurationFrom
        // 
        textBoxAPDurationFrom.Location = new System.Drawing.Point(450, 190);
        textBoxAPDurationFrom.Name = "textBoxAPDurationFrom";
        textBoxAPDurationFrom.Size = new System.Drawing.Size(67, 23);
        textBoxAPDurationFrom.TabIndex = 12;
        // 
        // textBoxAPDurationTo
        // 
        textBoxAPDurationTo.Location = new System.Drawing.Point(568, 190);
        textBoxAPDurationTo.Name = "textBoxAPDurationTo";
        textBoxAPDurationTo.Size = new System.Drawing.Size(67, 23);
        textBoxAPDurationTo.TabIndex = 13;
        // 
        // lblAPDurationFrom
        // 
        lblAPDurationFrom.Location = new System.Drawing.Point(450, 166);
        lblAPDurationFrom.Name = "lblAPDurationFrom";
        lblAPDurationFrom.Size = new System.Drawing.Size(67, 21);
        lblAPDurationFrom.TabIndex = 14;
        lblAPDurationFrom.Text = "От";
        lblAPDurationFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblAPDurationTo
        // 
        lblAPDurationTo.Location = new System.Drawing.Point(568, 166);
        lblAPDurationTo.Name = "lblAPDurationTo";
        lblAPDurationTo.Size = new System.Drawing.Size(67, 21);
        lblAPDurationTo.TabIndex = 15;
        lblAPDurationTo.Text = "До";
        lblAPDurationTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // AddPlaylist
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(656, 606);
        Controls.Add(lblAPDurationTo);
        Controls.Add(lblAPDurationFrom);
        Controls.Add(textBoxAPDurationTo);
        Controls.Add(textBoxAPDurationFrom);
        Controls.Add(lblAPPickedPerformer);
        Controls.Add(lblAPPickedGenre);
        Controls.Add(listBoxAPPickedPerformer);
        Controls.Add(listBoxAPPickPerformer);
        Controls.Add(listBoxAPPickedGenre);
        Controls.Add(listBoxAPPickGenre);
        Controls.Add(label1);
        Controls.Add(lblAPByPerformer);
        Controls.Add(lblAPByMusicGenre);
        Controls.Add(buttonAPLAdd);
        Controls.Add(labelAPLName);
        Controls.Add(textBoxAPLName);
        Text = "AddPlaylist";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblAPDurationTo;

    private System.Windows.Forms.TextBox textBoxAPDurationTo;
    private System.Windows.Forms.Label lblAPDurationFrom;

    private System.Windows.Forms.TextBox textBoxAPDurationFrom;

    private System.Windows.Forms.Label lblAPPickedPerformer;

    private System.Windows.Forms.Label lblAPPickedGenre;

    private System.Windows.Forms.ListBox listBoxAPPickedGenre;
    private System.Windows.Forms.ListBox listBoxAPPickPerformer;
    private System.Windows.Forms.ListBox listBoxAPPickGenre;
    private System.Windows.Forms.ListBox listBoxAPPickedPerformer;

    private System.Windows.Forms.Label lblAPByPerformer;
    private System.Windows.Forms.Label lblAPByMusicGenre;
    
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button buttonAPLAdd;

    private System.Windows.Forms.TextBox textBoxAPLName;
    private System.Windows.Forms.Label labelAPLName;

    #endregion
}