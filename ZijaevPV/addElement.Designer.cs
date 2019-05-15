namespace ZijaevPV
{
    partial class addElement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.name_TB = new System.Windows.Forms.TextBox();
            this.cost_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.importance_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.add_B = new System.Windows.Forms.Button();
            this.close_B = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование:";
            // 
            // name_TB
            // 
            this.name_TB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_TB.Location = new System.Drawing.Point(12, 25);
            this.name_TB.Name = "name_TB";
            this.name_TB.Size = new System.Drawing.Size(419, 20);
            this.name_TB.TabIndex = 1;
            // 
            // cost_TB
            // 
            this.cost_TB.Location = new System.Drawing.Point(71, 51);
            this.cost_TB.Name = "cost_TB";
            this.cost_TB.Size = new System.Drawing.Size(100, 20);
            this.cost_TB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Цена:";
            // 
            // importance_TB
            // 
            this.importance_TB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importance_TB.Location = new System.Drawing.Point(297, 51);
            this.importance_TB.Name = "importance_TB";
            this.importance_TB.Size = new System.Drawing.Size(134, 20);
            this.importance_TB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Какая-то штука";
            // 
            // add_B
            // 
            this.add_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add_B.Location = new System.Drawing.Point(275, 77);
            this.add_B.Name = "add_B";
            this.add_B.Size = new System.Drawing.Size(75, 23);
            this.add_B.TabIndex = 6;
            this.add_B.Text = "Добавить";
            this.add_B.UseVisualStyleBackColor = true;
            this.add_B.Click += new System.EventHandler(this.add_B_Click);
            // 
            // close_B
            // 
            this.close_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_B.Location = new System.Drawing.Point(356, 77);
            this.close_B.Name = "close_B";
            this.close_B.Size = new System.Drawing.Size(75, 23);
            this.close_B.TabIndex = 7;
            this.close_B.Text = "Закрыть";
            this.close_B.UseVisualStyleBackColor = true;
            this.close_B.Click += new System.EventHandler(this.close_B_Click);
            // 
            // addElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 110);
            this.Controls.Add(this.close_B);
            this.Controls.Add(this.add_B);
            this.Controls.Add(this.importance_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cost_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name_TB);
            this.Controls.Add(this.label1);
            this.Name = "addElement";
            this.Text = "Добавление элемента сети";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name_TB;
        private System.Windows.Forms.TextBox cost_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox importance_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button add_B;
        private System.Windows.Forms.Button close_B;
    }
}