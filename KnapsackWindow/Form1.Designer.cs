namespace KnapsackWindow
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
            this.num_of_items_label = new System.Windows.Forms.Label();
            this.seed_label = new System.Windows.Forms.Label();
            this.volume_label = new System.Windows.Forms.Label();
            this.output_box = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.knapsack_box = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gen_button = new System.Windows.Forms.Button();
            this.num_of_items_numeric = new System.Windows.Forms.NumericUpDown();
            this.seed_numeric = new System.Windows.Forms.NumericUpDown();
            this.volume_numeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_of_items_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seed_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // num_of_items_label
            // 
            this.num_of_items_label.AutoSize = true;
            this.num_of_items_label.Location = new System.Drawing.Point(45, 30);
            this.num_of_items_label.Name = "num_of_items_label";
            this.num_of_items_label.Size = new System.Drawing.Size(90, 16);
            this.num_of_items_label.TabIndex = 4;
            this.num_of_items_label.Text = "Num of items: ";
            // 
            // seed_label
            // 
            this.seed_label.AutoSize = true;
            this.seed_label.Location = new System.Drawing.Point(45, 58);
            this.seed_label.Name = "seed_label";
            this.seed_label.Size = new System.Drawing.Size(46, 16);
            this.seed_label.TabIndex = 5;
            this.seed_label.Text = "Seed: ";
            // 
            // volume_label
            // 
            this.volume_label.AutoSize = true;
            this.volume_label.Location = new System.Drawing.Point(45, 90);
            this.volume_label.Name = "volume_label";
            this.volume_label.Size = new System.Drawing.Size(116, 16);
            this.volume_label.TabIndex = 6;
            this.volume_label.Text = "Knapsnck volume:";
            // 
            // output_box
            // 
            this.output_box.Location = new System.Drawing.Point(411, 49);
            this.output_box.Name = "output_box";
            this.output_box.ReadOnly = true;
            this.output_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.output_box.Size = new System.Drawing.Size(377, 389);
            this.output_box.TabIndex = 7;
            this.output_box.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "output";
            // 
            // knapsack_box
            // 
            this.knapsack_box.Location = new System.Drawing.Point(48, 178);
            this.knapsack_box.Name = "knapsack_box";
            this.knapsack_box.ReadOnly = true;
            this.knapsack_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.knapsack_box.Size = new System.Drawing.Size(313, 260);
            this.knapsack_box.TabIndex = 9;
            this.knapsack_box.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "knapsack";
            // 
            // gen_button
            // 
            this.gen_button.Location = new System.Drawing.Point(309, 49);
            this.gen_button.Name = "gen_button";
            this.gen_button.Size = new System.Drawing.Size(75, 39);
            this.gen_button.TabIndex = 0;
            this.gen_button.Text = "generate";
            this.gen_button.UseVisualStyleBackColor = true;
            this.gen_button.Click += new System.EventHandler(this.gen_button_Click);
            // 
            // num_of_items_numeric
            // 
            this.num_of_items_numeric.Location = new System.Drawing.Point(173, 24);
            this.num_of_items_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_of_items_numeric.Name = "num_of_items_numeric";
            this.num_of_items_numeric.Size = new System.Drawing.Size(120, 22);
            this.num_of_items_numeric.TabIndex = 11;
            this.num_of_items_numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // seed_numeric
            // 
            this.seed_numeric.Location = new System.Drawing.Point(173, 56);
            this.seed_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seed_numeric.Name = "seed_numeric";
            this.seed_numeric.Size = new System.Drawing.Size(120, 22);
            this.seed_numeric.TabIndex = 12;
            this.seed_numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // volume_numeric
            // 
            this.volume_numeric.Location = new System.Drawing.Point(173, 90);
            this.volume_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.volume_numeric.Name = "volume_numeric";
            this.volume_numeric.Size = new System.Drawing.Size(120, 22);
            this.volume_numeric.TabIndex = 13;
            this.volume_numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.volume_numeric);
            this.Controls.Add(this.seed_numeric);
            this.Controls.Add(this.num_of_items_numeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.knapsack_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.output_box);
            this.Controls.Add(this.volume_label);
            this.Controls.Add(this.seed_label);
            this.Controls.Add(this.num_of_items_label);
            this.Controls.Add(this.gen_button);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.num_of_items_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seed_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label num_of_items_label;
        private System.Windows.Forms.Label seed_label;
        private System.Windows.Forms.Label volume_label;
        private System.Windows.Forms.RichTextBox output_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox knapsack_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button gen_button;
        private System.Windows.Forms.NumericUpDown num_of_items_numeric;
        private System.Windows.Forms.NumericUpDown seed_numeric;
        private System.Windows.Forms.NumericUpDown volume_numeric;
    }
}

