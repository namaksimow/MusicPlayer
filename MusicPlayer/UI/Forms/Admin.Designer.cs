using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class Admin
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
        dgvAdmin = new System.Windows.Forms.DataGridView();
        listBoxAdminUsers = new System.Windows.Forms.ListBox();
        btnLoadUsersData = new System.Windows.Forms.Button();
        contextMenuStripUserEdit  = new System.Windows.Forms.ContextMenuStrip();
        toolStripMenuItemDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)dgvAdmin).BeginInit();
        SuspendLayout();
        // 
        // dgvAdmin
        // 
        dgvAdmin.Location = new System.Drawing.Point(26, 14);
        dgvAdmin.Name = "dgvAdmin";
        dgvAdmin.Size = new System.Drawing.Size(544, 385);
        dgvAdmin.TabIndex = 0;
        // 
        // listBoxAdminUsers
        // 
        listBoxAdminUsers.FormattingEnabled = true;
        listBoxAdminUsers.ItemHeight = 15;
        listBoxAdminUsers.Location = new System.Drawing.Point(588, 20);
        listBoxAdminUsers.Name = "listBoxAdminUsers";
        listBoxAdminUsers.Size = new System.Drawing.Size(200, 259);
        listBoxAdminUsers.TabIndex = 1;
        listBoxAdminUsers.MouseDown += listBoxAdminUsers_MouseDown;
        // 
        // btnLoadUsersData
        // 
        btnLoadUsersData.Location = new System.Drawing.Point(604, 310);
        btnLoadUsersData.Name = "btnLoadUsersData";
        btnLoadUsersData.Size = new System.Drawing.Size(168, 89);
        btnLoadUsersData.TabIndex = 2;
        btnLoadUsersData.Text = "Выгрузить статистику";
        btnLoadUsersData.UseVisualStyleBackColor = true;
        btnLoadUsersData.Click += btnLoadUsersData_Click;
        //
        // contextMenuStripUserEdit
        //
        contextMenuStripUserEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemDeleteUser });
        contextMenuStripUserEdit.Name = "contextMenuStripMainSongEdit";
        contextMenuStripUserEdit.Size = new System.Drawing.Size(152, 48);
        //
        //
        //
        toolStripMenuItemDeleteUser.Name = "toolStripMenuSongDelete";
        toolStripMenuItemDeleteUser.Size = new System.Drawing.Size(151, 22);
        toolStripMenuItemDeleteUser.Text = "Удалить";
        toolStripMenuItemDeleteUser.Click += toolStripMenuItemDeleteUser_Click;
        // 
        // Admin
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btnLoadUsersData);
        Controls.Add(listBoxAdminUsers);
        Controls.Add(dgvAdmin);
        Text = "Admin";
        ((System.ComponentModel.ISupportInitialize)dgvAdmin).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBoxAdminUsers;
    private System.Windows.Forms.Button btnLoadUsersData;

    private System.Windows.Forms.DataGridView dgvAdmin;
    
    private System.Windows.Forms.ContextMenuStrip contextMenuStripUserEdit;
    
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteUser;

    #endregion
}