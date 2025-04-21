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
        SuspendLayout();
        // 
        // textBoxAPLName
        // 
        textBoxAPLName.Location = new System.Drawing.Point(100, 27);
        textBoxAPLName.Name = "textBoxAPLName";
        textBoxAPLName.Size = new System.Drawing.Size(232, 23);
        textBoxAPLName.TabIndex = 0;
        // 
        // labelAPLName
        // 
        labelAPLName.Location = new System.Drawing.Point(7, 15);
        labelAPLName.Name = "labelAPLName";
        labelAPLName.Size = new System.Drawing.Size(87, 44);
        labelAPLName.TabIndex = 1;
        labelAPLName.Text = "Playlist Name";
        labelAPLName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // buttonAPLAdd
        // 
        buttonAPLAdd.Location = new System.Drawing.Point(116, 221);
        buttonAPLAdd.Name = "buttonAPLAdd";
        buttonAPLAdd.Size = new System.Drawing.Size(120, 47);
        buttonAPLAdd.TabIndex = 2;
        buttonAPLAdd.Text = "Add";
        buttonAPLAdd.UseVisualStyleBackColor = true;
        buttonAPLAdd.Click += buttonAPLAdd_Click;
        // 
        // AddPlaylist
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(344, 280);
        Controls.Add(buttonAPLAdd);
        Controls.Add(labelAPLName);
        Controls.Add(textBoxAPLName);
        Text = "AddPlaylist";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button buttonAPLAdd;

    private System.Windows.Forms.TextBox textBoxAPLName;
    private System.Windows.Forms.Label labelAPLName;

    #endregion
}