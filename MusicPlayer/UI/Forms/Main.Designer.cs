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
        trackBarMainVolume = new System.Windows.Forms.TrackBar();
        trackBarMainRewind = new System.Windows.Forms.TrackBar();
        btnMainPlayPause = new System.Windows.Forms.Button();
        btnMainNext = new System.Windows.Forms.Button();
        btnMainPrev = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)trackBarMainVolume).BeginInit();
        ((System.ComponentModel.ISupportInitialize)trackBarMainRewind).BeginInit();
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
        listBoxMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
        listBoxMain.FormattingEnabled = true;
        listBoxMain.HorizontalScrollbar = true;
        listBoxMain.ItemHeight = 15;
        listBoxMain.Location = new System.Drawing.Point(231, 21);
        listBoxMain.Name = "listBoxMain";
        listBoxMain.Size = new System.Drawing.Size(329, 619);
        listBoxMain.TabIndex = 8;
        listBoxMain.MouseDown += listBoxMain_MouseDown;
        // 
        // trackBarMainVolume
        // 
        trackBarMainVolume.Location = new System.Drawing.Point(668, 716);
        trackBarMainVolume.Name = "trackBarMainVolume";
        trackBarMainVolume.Size = new System.Drawing.Size(114, 45);
        trackBarMainVolume.TabIndex = 9;
        trackBarMainVolume.Scroll += trackBarMainVolume_Scroll;
        // 
        // trackBarMainRewind
        // 
        trackBarMainRewind.Location = new System.Drawing.Point(231, 716);
        trackBarMainRewind.Name = "trackBarMainRewind";
        trackBarMainRewind.Size = new System.Drawing.Size(329, 45);
        trackBarMainRewind.TabIndex = 10;
        trackBarMainRewind.Scroll += trackBarMainRewind_Scroll;
        // 
        // btnMainPlayPause
        // 
        btnMainPlayPause.Location = new System.Drawing.Point(356, 655);
        btnMainPlayPause.Name = "btnMainPlayPause";
        btnMainPlayPause.Size = new System.Drawing.Size(79, 55);
        btnMainPlayPause.TabIndex = 11;
        btnMainPlayPause.Text = "Pause";
        btnMainPlayPause.UseVisualStyleBackColor = true;
        btnMainPlayPause.Click += btnMainPlayPause_Click;
        // 
        // btnMainNext
        // 
        btnMainNext.Location = new System.Drawing.Point(481, 655);
        btnMainNext.Name = "btnMainNext";
        btnMainNext.Size = new System.Drawing.Size(79, 55);
        btnMainNext.TabIndex = 12;
        btnMainNext.Text = "Next";
        btnMainNext.UseVisualStyleBackColor = true;
        btnMainNext.Click += btnMainNext_Click;
        // 
        // btnMainPrev
        // 
        btnMainPrev.Location = new System.Drawing.Point(231, 655);
        btnMainPrev.Name = "btnMainPrev";
        btnMainPrev.Size = new System.Drawing.Size(79, 55);
        btnMainPrev.TabIndex = 13;
        btnMainPrev.Text = "Prev";
        btnMainPrev.UseVisualStyleBackColor = true;
        btnMainPrev.Click += btnMainPrev_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(794, 786);
        Controls.Add(btnMainPrev);
        Controls.Add(btnMainNext);
        Controls.Add(btnMainPlayPause);
        Controls.Add(trackBarMainRewind);
        Controls.Add(trackBarMainVolume);
        Controls.Add(listBoxMain);
        Controls.Add(btnMainUpload);
        Location = new System.Drawing.Point(15, 15);
        ((System.ComponentModel.ISupportInitialize)trackBarMainVolume).EndInit();
        ((System.ComponentModel.ISupportInitialize)trackBarMainRewind).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnMainNext;
    private System.Windows.Forms.Button btnMainPrev;

    private System.Windows.Forms.Button btnMainPlayPause;

    private System.Windows.Forms.TrackBar trackBarMainRewind;

    private System.Windows.Forms.TrackBar trackBarMainVolume;

    private System.Windows.Forms.ListBox listBoxMain;

    private System.Windows.Forms.Button btnMainUpload;

    #endregion
}