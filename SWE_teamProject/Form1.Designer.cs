
namespace SWE_teamProject
{
    partial class Form1
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
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.GroupBox();
            this.voter = new System.Windows.Forms.RadioButton();
            this.candidate = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(607, 53);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(75, 23);
            this.load.TabIndex = 0;
            this.load.Text = "load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(664, 388);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(101, 50);
            this.save.TabIndex = 1;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // options
            // 
            this.options.Controls.Add(this.candidate);
            this.options.Controls.Add(this.voter);
            this.options.Location = new System.Drawing.Point(276, 12);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(200, 100);
            this.options.TabIndex = 2;
            this.options.TabStop = false;
            this.options.Text = "options";
            // 
            // voter
            // 
            this.voter.AutoSize = true;
            this.voter.Location = new System.Drawing.Point(29, 32);
            this.voter.Name = "voter";
            this.voter.Size = new System.Drawing.Size(51, 17);
            this.voter.TabIndex = 0;
            this.voter.TabStop = true;
            this.voter.Text = "voter";
            this.voter.UseMnemonic = false;
            this.voter.UseVisualStyleBackColor = true;
            // 
            // candidate
            // 
            this.candidate.AutoSize = true;
            this.candidate.Location = new System.Drawing.Point(29, 68);
            this.candidate.Name = "candidate";
            this.candidate.Size = new System.Drawing.Size(72, 17);
            this.candidate.TabIndex = 1;
            this.candidate.TabStop = true;
            this.candidate.Text = "candidate";
            this.candidate.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(70, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(669, 213);
            this.dataGridView1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.options);
            this.Controls.Add(this.save);
            this.Controls.Add(this.load);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.options.ResumeLayout(false);
            this.options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.GroupBox options;
        private System.Windows.Forms.RadioButton candidate;
        private System.Windows.Forms.RadioButton voter;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

