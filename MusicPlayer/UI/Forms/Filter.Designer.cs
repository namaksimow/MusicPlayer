using System.ComponentModel;

namespace MusicPlayer.UI.Forms;

partial class Filter
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
        lblFilterGenre = new System.Windows.Forms.Label();
        lblFilterPerformer = new System.Windows.Forms.Label();
        lblFilterDuration = new System.Windows.Forms.Label();
        lblFilterAdditionalOptions = new System.Windows.Forms.Label();
        lblFilterStandartOptions = new System.Windows.Forms.Label();
        lblFilterBySongNameAscendic = new System.Windows.Forms.Label();
        lblFilterBySongNameDescending = new System.Windows.Forms.Label();
        lblFilterClearFilter = new System.Windows.Forms.Label();
        lblFilterByPerformerAscending = new System.Windows.Forms.Label();
        lblFilterByPerformerDescending = new System.Windows.Forms.Label();
        lblFilterByDurationAscending = new System.Windows.Forms.Label();
        lblFilterByDurationDescending = new System.Windows.Forms.Label();
        listBoxFilterPickGenre = new System.Windows.Forms.ListBox();
        listBoxFilterPickedGenre = new System.Windows.Forms.ListBox();
        label1 = new System.Windows.Forms.Label();
        listBoxFilterPickPerformer = new System.Windows.Forms.ListBox();
        listBoxFilterPickedPerformer = new System.Windows.Forms.ListBox();
        label2 = new System.Windows.Forms.Label();
        textBoxFilterDurationFrom = new System.Windows.Forms.TextBox();
        textBoxFilterDurationTo = new System.Windows.Forms.TextBox();
        btnFilterFilter = new System.Windows.Forms.Button();
        lblFilterDurationFrom = new System.Windows.Forms.Label();
        lblFilterDurationTo = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // lblFilterGenre
        // 
        lblFilterGenre.Font = new System.Drawing.Font("Segoe UI", 15F);
        lblFilterGenre.Location = new System.Drawing.Point(66, 72);
        lblFilterGenre.Name = "lblFilterGenre";
        lblFilterGenre.Size = new System.Drawing.Size(179, 77);
        lblFilterGenre.TabIndex = 0;
        lblFilterGenre.Text = "По музыкальному жанру";
        lblFilterGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblFilterPerformer
        // 
        lblFilterPerformer.Font = new System.Drawing.Font("Segoe UI", 15F);
        lblFilterPerformer.Location = new System.Drawing.Point(269, 72);
        lblFilterPerformer.Name = "lblFilterPerformer";
        lblFilterPerformer.Size = new System.Drawing.Size(179, 77);
        lblFilterPerformer.TabIndex = 1;
        lblFilterPerformer.Text = "По исполнителю";
        lblFilterPerformer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblFilterDuration
        // 
        lblFilterDuration.Font = new System.Drawing.Font("Segoe UI", 15F);
        lblFilterDuration.Location = new System.Drawing.Point(464, 72);
        lblFilterDuration.Name = "lblFilterDuration";
        lblFilterDuration.Size = new System.Drawing.Size(179, 77);
        lblFilterDuration.TabIndex = 2;
        lblFilterDuration.Text = "По длительности";
        lblFilterDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblFilterAdditionalOptions
        // 
        lblFilterAdditionalOptions.Font = new System.Drawing.Font("Segoe UI", 25F);
        lblFilterAdditionalOptions.Location = new System.Drawing.Point(151, 10);
        lblFilterAdditionalOptions.Name = "lblFilterAdditionalOptions";
        lblFilterAdditionalOptions.Size = new System.Drawing.Size(423, 62);
        lblFilterAdditionalOptions.TabIndex = 3;
        lblFilterAdditionalOptions.Text = "Расширенные настройки";
        lblFilterAdditionalOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblFilterStandartOptions
        // 
        lblFilterStandartOptions.Font = new System.Drawing.Font("Segoe UI", 25F);
        lblFilterStandartOptions.Location = new System.Drawing.Point(151, 549);
        lblFilterStandartOptions.Name = "lblFilterStandartOptions";
        lblFilterStandartOptions.Size = new System.Drawing.Size(423, 62);
        lblFilterStandartOptions.TabIndex = 4;
        lblFilterStandartOptions.Text = "Обычные настройки";
        lblFilterStandartOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblFilterBySongNameAscendic
        // 
        lblFilterBySongNameAscendic.Location = new System.Drawing.Point(45, 621);
        lblFilterBySongNameAscendic.Name = "lblFilterBySongNameAscendic";
        lblFilterBySongNameAscendic.Size = new System.Drawing.Size(127, 45);
        lblFilterBySongNameAscendic.TabIndex = 5;
        lblFilterBySongNameAscendic.Text = "По названию песни в алфавитном порядке";
        lblFilterBySongNameAscendic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lblFilterBySongNameAscendic.Click += lblFilterBySongNameAscending_Click;
        // 
        // lblFilterBySongNameDescending
        // 
        lblFilterBySongNameDescending.Location = new System.Drawing.Point(12, 676);
        lblFilterBySongNameDescending.Name = "lblFilterBySongNameDescending";
        lblFilterBySongNameDescending.Size = new System.Drawing.Size(186, 81);
        lblFilterBySongNameDescending.TabIndex = 6;
        lblFilterBySongNameDescending.Text = "По названию песни в обратном алфавитном порядке";
        lblFilterBySongNameDescending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lblFilterBySongNameDescending.Click += lblFilterBySongNameDescending_Click;
        // 
        // lblFilterClearFilter
        // 
        lblFilterClearFilter.Location = new System.Drawing.Point(295, 746);
        lblFilterClearFilter.Name = "lblFilterClearFilter";
        lblFilterClearFilter.Size = new System.Drawing.Size(127, 45);
        lblFilterClearFilter.TabIndex = 7;
        lblFilterClearFilter.Text = "Сбросить фильтры";
        lblFilterClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lblFilterClearFilter.Click += lblFilterClearFilter_Click;
        // 
        // lblFilterByPerformerAscending
        // 
        lblFilterByPerformerAscending.Location = new System.Drawing.Point(269, 611);
        lblFilterByPerformerAscending.Name = "lblFilterByPerformerAscending";
        lblFilterByPerformerAscending.Size = new System.Drawing.Size(190, 74);
        lblFilterByPerformerAscending.TabIndex = 8;
        lblFilterByPerformerAscending.Text = "По исполнителью в алфавитном порядку";
        lblFilterByPerformerAscending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lblFilterByPerformerAscending.Click += lblFilterByPerformerAscending_Click;
        // 
        // lblFilterByPerformerDescending
        // 
        lblFilterByPerformerDescending.Location = new System.Drawing.Point(269, 676);
        lblFilterByPerformerDescending.Name = "lblFilterByPerformerDescending";
        lblFilterByPerformerDescending.Size = new System.Drawing.Size(190, 74);
        lblFilterByPerformerDescending.TabIndex = 9;
        lblFilterByPerformerDescending.Text = "По исполнителью в обратном алфавитном порядку";
        lblFilterByPerformerDescending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lblFilterByPerformerDescending.Click += lblFilterByPerformerDescending_Click;
        // 
        // lblFilterByDurationAscending
        // 
        lblFilterByDurationAscending.Location = new System.Drawing.Point(517, 604);
        lblFilterByDurationAscending.Name = "lblFilterByDurationAscending";
        lblFilterByDurationAscending.Size = new System.Drawing.Size(126, 79);
        lblFilterByDurationAscending.TabIndex = 10;
        lblFilterByDurationAscending.Text = "По длительности по возрастанию";
        lblFilterByDurationAscending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lblFilterByDurationAscending.Click += lblFilterByDurationAscending_Click;
        // 
        // lblFilterByDurationDescending
        // 
        lblFilterByDurationDescending.Location = new System.Drawing.Point(517, 677);
        lblFilterByDurationDescending.Name = "lblFilterByDurationDescending";
        lblFilterByDurationDescending.Size = new System.Drawing.Size(126, 79);
        lblFilterByDurationDescending.TabIndex = 11;
        lblFilterByDurationDescending.Text = "По длительности по убыванию";
        lblFilterByDurationDescending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lblFilterByDurationDescending.Click += lblFilterByDurationDescending_Click;
        // 
        // listBoxFilterPickGenre
        // 
        listBoxFilterPickGenre.FormattingEnabled = true;
        listBoxFilterPickGenre.ItemHeight = 15;
        listBoxFilterPickGenre.Location = new System.Drawing.Point(66, 152);
        listBoxFilterPickGenre.Name = "listBoxFilterPickGenre";
        listBoxFilterPickGenre.Size = new System.Drawing.Size(176, 124);
        listBoxFilterPickGenre.TabIndex = 12;
        listBoxFilterPickGenre.MouseDown += listBoxFilterPickGenre_MouseDown;
        // 
        // listBoxFilterPickedGenre
        // 
        listBoxFilterPickedGenre.FormattingEnabled = true;
        listBoxFilterPickedGenre.ItemHeight = 15;
        listBoxFilterPickedGenre.Location = new System.Drawing.Point(66, 336);
        listBoxFilterPickedGenre.Name = "listBoxFilterPickedGenre";
        listBoxFilterPickedGenre.Size = new System.Drawing.Size(176, 124);
        listBoxFilterPickedGenre.TabIndex = 13;
        listBoxFilterPickedGenre.MouseDown += listBoxFilterPickedGenre_MouseDown;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(66, 305);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(176, 28);
        label1.TabIndex = 14;
        label1.Text = "Выбранные жанры";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // listBoxFilterPickPerformer
        // 
        listBoxFilterPickPerformer.FormattingEnabled = true;
        listBoxFilterPickPerformer.ItemHeight = 15;
        listBoxFilterPickPerformer.Location = new System.Drawing.Point(269, 152);
        listBoxFilterPickPerformer.Name = "listBoxFilterPickPerformer";
        listBoxFilterPickPerformer.Size = new System.Drawing.Size(176, 124);
        listBoxFilterPickPerformer.TabIndex = 15;
        listBoxFilterPickPerformer.MouseDown += listBoxFilterPickPerformer_MouseDown;
        // 
        // listBoxFilterPickedPerformer
        // 
        listBoxFilterPickedPerformer.FormattingEnabled = true;
        listBoxFilterPickedPerformer.ItemHeight = 15;
        listBoxFilterPickedPerformer.Location = new System.Drawing.Point(269, 336);
        listBoxFilterPickedPerformer.Name = "listBoxFilterPickedPerformer";
        listBoxFilterPickedPerformer.Size = new System.Drawing.Size(176, 124);
        listBoxFilterPickedPerformer.TabIndex = 16;
        listBoxFilterPickedPerformer.MouseDown += listBoxFilterPickedPerformer_MouseDown;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(269, 305);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(176, 28);
        label2.TabIndex = 17;
        label2.Text = "Выбранные исполнители";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textBoxFilterDurationFrom
        // 
        textBoxFilterDurationFrom.Location = new System.Drawing.Point(481, 182);
        textBoxFilterDurationFrom.Name = "textBoxFilterDurationFrom";
        textBoxFilterDurationFrom.Size = new System.Drawing.Size(71, 23);
        textBoxFilterDurationFrom.TabIndex = 18;
        // 
        // textBoxFilterDurationTo
        // 
        textBoxFilterDurationTo.Location = new System.Drawing.Point(572, 182);
        textBoxFilterDurationTo.Name = "textBoxFilterDurationTo";
        textBoxFilterDurationTo.Size = new System.Drawing.Size(71, 23);
        textBoxFilterDurationTo.TabIndex = 19;
        // 
        // btnFilterFilter
        // 
        btnFilterFilter.Location = new System.Drawing.Point(269, 486);
        btnFilterFilter.Name = "btnFilterFilter";
        btnFilterFilter.Size = new System.Drawing.Size(176, 39);
        btnFilterFilter.TabIndex = 20;
        btnFilterFilter.Text = "Отфильтровать";
        btnFilterFilter.UseVisualStyleBackColor = true;
        btnFilterFilter.Click += btnFilterFilter_Click;
        // 
        // lblFilterDurationFrom
        // 
        lblFilterDurationFrom.Location = new System.Drawing.Point(495, 151);
        lblFilterDurationFrom.Name = "lblFilterDurationFrom";
        lblFilterDurationFrom.Size = new System.Drawing.Size(44, 20);
        lblFilterDurationFrom.TabIndex = 21;
        lblFilterDurationFrom.Text = "От";
        lblFilterDurationFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblFilterDurationTo
        // 
        lblFilterDurationTo.Location = new System.Drawing.Point(586, 152);
        lblFilterDurationTo.Name = "lblFilterDurationTo";
        lblFilterDurationTo.Size = new System.Drawing.Size(44, 20);
        lblFilterDurationTo.TabIndex = 22;
        lblFilterDurationTo.Text = "До";
        lblFilterDurationTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Filter
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(703, 813);
        Controls.Add(lblFilterDurationTo);
        Controls.Add(lblFilterDurationFrom);
        Controls.Add(btnFilterFilter);
        Controls.Add(textBoxFilterDurationTo);
        Controls.Add(textBoxFilterDurationFrom);
        Controls.Add(label2);
        Controls.Add(listBoxFilterPickedPerformer);
        Controls.Add(listBoxFilterPickPerformer);
        Controls.Add(label1);
        Controls.Add(listBoxFilterPickedGenre);
        Controls.Add(listBoxFilterPickGenre);
        Controls.Add(lblFilterByDurationDescending);
        Controls.Add(lblFilterByDurationAscending);
        Controls.Add(lblFilterByPerformerDescending);
        Controls.Add(lblFilterByPerformerAscending);
        Controls.Add(lblFilterClearFilter);
        Controls.Add(lblFilterBySongNameDescending);
        Controls.Add(lblFilterBySongNameAscendic);
        Controls.Add(lblFilterStandartOptions);
        Controls.Add(lblFilterAdditionalOptions);
        Controls.Add(lblFilterDuration);
        Controls.Add(lblFilterPerformer);
        Controls.Add(lblFilterGenre);
        Text = "Filter";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblFilterDurationTo;

    private System.Windows.Forms.Label lblFilterDurationFrom;

    private System.Windows.Forms.TextBox textBoxFilterDurationFrom;
    private System.Windows.Forms.TextBox textBoxFilterDurationTo;
    private System.Windows.Forms.Button btnFilterFilter;

    private System.Windows.Forms.ListBox listBoxFilterPickPerformer;
    private System.Windows.Forms.ListBox listBoxFilterPickedPerformer;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ListBox listBoxFilterPickGenre;
    private System.Windows.Forms.ListBox listBoxFilterPickedGenre;

    private System.Windows.Forms.Label lblFilterByDurationAscending;
    private System.Windows.Forms.Label lblFilterByDurationDescending;

    private System.Windows.Forms.Label lblFilterByPerformerAscending;
    private System.Windows.Forms.Label lblFilterByPerformerDescending;

    private System.Windows.Forms.Label lblFilterClearFilter;

    private System.Windows.Forms.Label lblFilterBySongNameDescending;

    private System.Windows.Forms.Label lblFilterBySongNameAscendic;

    private System.Windows.Forms.Label lblFilterAdditionalOptions;

    private System.Windows.Forms.Label lblFilterStandartOptions;

    private System.Windows.Forms.Label lblFilterGenre;
    private System.Windows.Forms.Label lblFilterDuration;

    private System.Windows.Forms.Label lblFilterPerformer;

    #endregion
}