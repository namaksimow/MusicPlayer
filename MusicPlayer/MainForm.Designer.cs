namespace MusicPlayer;

partial class MainForm : Form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        btnMainFormUpload = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnMainFormUpload
        // 
        btnMainFormUpload.Location = new System.Drawing.Point(118, 101);
        btnMainFormUpload.Name = "btnMainFormUpload";
        btnMainFormUpload.Size = new System.Drawing.Size(96, 98);
        btnMainFormUpload.TabIndex = 0;
        btnMainFormUpload.Text = "Upload";
        btnMainFormUpload.UseVisualStyleBackColor = true;
        btnMainFormUpload.Click += btnMainFormUpload_Click;
        // 
        // MainForm
        // 
        ClientSize = new System.Drawing.Size(284, 261);
        Controls.Add(btnMainFormUpload);
        ResumeLayout(false);
    }
    
    private System.Windows.Forms.Button btnMainFormUpload;

    #endregion
}