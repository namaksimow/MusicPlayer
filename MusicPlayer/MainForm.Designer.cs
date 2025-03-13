namespace MusicPlayer;

partial class MainForm
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
        btnMainFormUploadFile = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnMainFormUploadFile
        // 
        btnMainFormUploadFile.Location = new System.Drawing.Point(190, 456);
        btnMainFormUploadFile.Name = "btnMainFormUploadFile";
        btnMainFormUploadFile.Size = new System.Drawing.Size(149, 59);
        btnMainFormUploadFile.TabIndex = 0;
        btnMainFormUploadFile.Text = "Upload file";
        btnMainFormUploadFile.UseVisualStyleBackColor = true;
        btnMainFormUploadFile.Click += btnMainFormUploadFile_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(630, 597);
        Controls.Add(btnMainFormUploadFile);
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnMainFormUploadFile;

    #endregion
}