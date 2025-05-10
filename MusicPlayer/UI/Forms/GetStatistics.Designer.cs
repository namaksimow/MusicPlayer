using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class GetStatistics
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
        dgvGetStatistics = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvGetStatistics).BeginInit();
        SuspendLayout();
        // 
        // dgvGetStatistics
        // 
        dgvGetStatistics.Location = new System.Drawing.Point(71, 23);
        dgvGetStatistics.Name = "dgvGetStatistics";
        dgvGetStatistics.Size = new System.Drawing.Size(435, 398);
        dgvGetStatistics.TabIndex = 0;
        // 
        // GetStatistics
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(dgvGetStatistics);
        Text = "GetStatistics";
        ((System.ComponentModel.ISupportInitialize)dgvGetStatistics).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridView dgvGetStatistics;

    #endregion
}