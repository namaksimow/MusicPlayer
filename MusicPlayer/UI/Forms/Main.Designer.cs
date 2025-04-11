﻿using System.ComponentModel;

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
        components = new System.ComponentModel.Container();
        btnMainUpload = new System.Windows.Forms.Button();
        listBoxMainTracks = new System.Windows.Forms.ListBox();
        contextMenuStripMainSongEdit = new System.Windows.Forms.ContextMenuStrip(components);
        toolStripMenuSongDelete = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItemPlaylistDelete = new System.Windows.Forms.ToolStripMenuItem();
        trackBarMainVolume = new System.Windows.Forms.TrackBar();
        trackBarMainRewind = new System.Windows.Forms.TrackBar();
        btnMainPlayPause = new System.Windows.Forms.Button();
        btnMainNext = new System.Windows.Forms.Button();
        btnMainPrev = new System.Windows.Forms.Button();
        textBoxMainLyrics = new System.Windows.Forms.TextBox();
        panelMainHideSlider = new System.Windows.Forms.Panel();
        panelMainHideVolume = new System.Windows.Forms.Panel();
        listBoxMainPlaylists = new System.Windows.Forms.ListBox();
        btnMainAddPlaylist = new System.Windows.Forms.Button();
        contextMenuStripMainPlaylistEdit = new System.Windows.Forms.ContextMenuStrip(components);
        contextMenuStripMainSongEdit.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarMainVolume).BeginInit();
        ((System.ComponentModel.ISupportInitialize)trackBarMainRewind).BeginInit();
        SuspendLayout();
        // 
        // btnMainUpload
        // 
        btnMainUpload.Location = new System.Drawing.Point(632, 21);
        btnMainUpload.Name = "btnMainUpload";
        btnMainUpload.Size = new System.Drawing.Size(76, 71);
        btnMainUpload.TabIndex = 7;
        btnMainUpload.Text = "Upload Track";
        btnMainUpload.UseVisualStyleBackColor = true;
        btnMainUpload.Click += btnMainUpload_Click;
        // 
        // listBoxMainTracks
        // 
        listBoxMainTracks.Anchor = System.Windows.Forms.AnchorStyles.Top;
        listBoxMainTracks.ContextMenuStrip = contextMenuStripMainSongEdit;
        listBoxMainTracks.FormattingEnabled = true;
        listBoxMainTracks.HorizontalScrollbar = true;
        listBoxMainTracks.ItemHeight = 15;
        listBoxMainTracks.Location = new System.Drawing.Point(286, 21);
        listBoxMainTracks.Name = "listBoxMainTracks";
        listBoxMainTracks.Size = new System.Drawing.Size(329, 619);
        listBoxMainTracks.TabIndex = 8;
        listBoxMainTracks.MouseDown += listBoxTracks_MouseDown;
        // 
        // contextMenuStripMainSongEdit
        // 
        contextMenuStripMainSongEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuSongDelete });
        contextMenuStripMainSongEdit.Name = "contextMenuStripMainSongEdit";
        contextMenuStripMainSongEdit.Size = new System.Drawing.Size(108, 26);
        // 
        // toolStripMenuDelete
        // 
        toolStripMenuSongDelete.Name = "toolStripMenuSongDelete";
        toolStripMenuSongDelete.Size = new System.Drawing.Size(107, 22);
        toolStripMenuSongDelete.Text = "Delete";
        toolStripMenuSongDelete.Click += ToolStripMenuSongDeleteClick;
        // 
        // trackBarMainVolume
        // 
        trackBarMainVolume.Location = new System.Drawing.Point(632, 655);
        trackBarMainVolume.Name = "trackBarMainVolume";
        trackBarMainVolume.Size = new System.Drawing.Size(265, 45);
        trackBarMainVolume.TabIndex = 9;
        trackBarMainVolume.Scroll += trackBarMainVolume_Scroll;
        // 
        // trackBarMainRewind
        // 
        trackBarMainRewind.Location = new System.Drawing.Point(288, 716);
        trackBarMainRewind.Maximum = 1000;
        trackBarMainRewind.Name = "trackBarMainRewind";
        trackBarMainRewind.Size = new System.Drawing.Size(329, 45);
        trackBarMainRewind.TabIndex = 10;
        trackBarMainRewind.Scroll += trackBarMainRewind_Scroll;
        // 
        // btnMainPlayPause
        // 
        btnMainPlayPause.Location = new System.Drawing.Point(414, 655);
        btnMainPlayPause.Name = "btnMainPlayPause";
        btnMainPlayPause.Size = new System.Drawing.Size(79, 55);
        btnMainPlayPause.TabIndex = 11;
        btnMainPlayPause.Text = "Pause";
        btnMainPlayPause.UseVisualStyleBackColor = true;
        btnMainPlayPause.Click += btnMainPlayPause_Click;
        // 
        // btnMainNext
        // 
        btnMainNext.Location = new System.Drawing.Point(538, 655);
        btnMainNext.Name = "btnMainNext";
        btnMainNext.Size = new System.Drawing.Size(79, 55);
        btnMainNext.TabIndex = 12;
        btnMainNext.Text = "Next";
        btnMainNext.UseVisualStyleBackColor = true;
        btnMainNext.Click += btnMainNext_Click;
        // 
        // btnMainPrev
        // 
        btnMainPrev.Location = new System.Drawing.Point(288, 655);
        btnMainPrev.Name = "btnMainPrev";
        btnMainPrev.Size = new System.Drawing.Size(79, 55);
        btnMainPrev.TabIndex = 13;
        btnMainPrev.Text = "Prev";
        btnMainPrev.UseVisualStyleBackColor = true;
        btnMainPrev.Click += btnMainPrev_Click;
        // 
        // textBoxMainLyrics
        // 
        textBoxMainLyrics.Location = new System.Drawing.Point(632, 98);
        textBoxMainLyrics.Multiline = true;
        textBoxMainLyrics.Name = "textBoxMainLyrics";
        textBoxMainLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBoxMainLyrics.Size = new System.Drawing.Size(265, 542);
        textBoxMainLyrics.TabIndex = 14;
        // 
        // panelMainHideSlider
        // 
        panelMainHideSlider.BackColor = System.Drawing.SystemColors.Control;
        panelMainHideSlider.Location = new System.Drawing.Point(288, 738);
        panelMainHideSlider.Name = "panelMainHideSlider";
        panelMainHideSlider.Size = new System.Drawing.Size(329, 12);
        panelMainHideSlider.TabIndex = 15;
        // 
        // panelMainHideVolume
        // 
        panelMainHideVolume.BackColor = System.Drawing.SystemColors.Control;
        panelMainHideVolume.Location = new System.Drawing.Point(632, 677);
        panelMainHideVolume.Name = "panelMainHideVolume";
        panelMainHideVolume.Size = new System.Drawing.Size(265, 10);
        panelMainHideVolume.TabIndex = 16;
        // 
        // listBoxMainPlaylists
        // 
        listBoxMainPlaylists.ContextMenuStrip = contextMenuStripMainPlaylistEdit;
        listBoxMainPlaylists.FormattingEnabled = true;
        listBoxMainPlaylists.HorizontalScrollbar = true;
        listBoxMainPlaylists.ItemHeight = 15;
        listBoxMainPlaylists.Location = new System.Drawing.Point(6, 96);
        listBoxMainPlaylists.Name = "listBoxMainPlaylists";
        listBoxMainPlaylists.Size = new System.Drawing.Size(267, 544);
        listBoxMainPlaylists.TabIndex = 18;
        listBoxMainPlaylists.MouseDown += listBoxMainPlaylists_MouseDown;
        // 
        // btnMainAddPlaylist
        // 
        btnMainAddPlaylist.Location = new System.Drawing.Point(6, 19);
        btnMainAddPlaylist.Name = "btnMainAddPlaylist";
        btnMainAddPlaylist.Size = new System.Drawing.Size(76, 71);
        btnMainAddPlaylist.TabIndex = 19;
        btnMainAddPlaylist.Text = "Add Playlist";
        btnMainAddPlaylist.UseVisualStyleBackColor = true;
        btnMainAddPlaylist.Click += btnMainAddPlaylist_Click;
        //
        // toolStripMenuItemPlaylistDelete
        //
        toolStripMenuItemPlaylistDelete.Name = "toolStripMenuItemPlaylistDelete";
        toolStripMenuItemPlaylistDelete.Size = new System.Drawing.Size(107, 22);
        toolStripMenuItemPlaylistDelete.Text = "Delete";
        toolStripMenuItemPlaylistDelete.Click += ToolStripMenuPlaylistDeleteClick;
        // 
        // contextMenuStripMainPlaylistEdit
        // 
        contextMenuStripMainPlaylistEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemPlaylistDelete });
        contextMenuStripMainPlaylistEdit.Name = "contextMenuStripMainPlaylistEdit";
        contextMenuStripMainPlaylistEdit.Size = new System.Drawing.Size(61, 4);
        // 
        // Main
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(909, 786);
        Controls.Add(btnMainAddPlaylist);
        Controls.Add(listBoxMainPlaylists);
        Controls.Add(panelMainHideVolume);
        Controls.Add(panelMainHideSlider);
        Controls.Add(textBoxMainLyrics);
        Controls.Add(btnMainPrev);
        Controls.Add(btnMainNext);
        Controls.Add(btnMainPlayPause);
        Controls.Add(trackBarMainRewind);
        Controls.Add(trackBarMainVolume);
        Controls.Add(listBoxMainTracks);
        Controls.Add(btnMainUpload);
        Location = new System.Drawing.Point(15, 15);
        contextMenuStripMainSongEdit.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)trackBarMainVolume).EndInit();
        ((System.ComponentModel.ISupportInitialize)trackBarMainRewind).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ContextMenuStrip contextMenuStripMainPlaylistEdit;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlaylistDelete;
    
    private System.Windows.Forms.Button btnMainAddPlaylist;

    private System.Windows.Forms.ListBox listBoxMainPlaylists;

    private System.Windows.Forms.Panel panelMainHideSlider;

    private System.Windows.Forms.Panel panelMainHideVolume;

    private System.Windows.Forms.TextBox textBoxMainLyrics;

    private System.Windows.Forms.ContextMenuStrip contextMenuStripMainSongEdit;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuSongDelete;

    private System.Windows.Forms.Button btnMainNext;
    private System.Windows.Forms.Button btnMainPrev;

    private System.Windows.Forms.Button btnMainPlayPause;

    private System.Windows.Forms.TrackBar trackBarMainRewind;

    private System.Windows.Forms.TrackBar trackBarMainVolume;

    private System.Windows.Forms.ListBox listBoxMainTracks;

    private System.Windows.Forms.Button btnMainUpload;

    #endregion
}