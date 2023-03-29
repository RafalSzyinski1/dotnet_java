namespace Lab1_desktop
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.BoxKnapsack = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BoxNumber = new System.Windows.Forms.TextBox();
            this.BoxSeed = new System.Windows.Forms.TextBox();
            this.BoxBackpack = new System.Windows.Forms.TextBox();
            this.BoxWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoxKnapsack
            // 
            this.BoxKnapsack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BoxKnapsack.Location = new System.Drawing.Point(12, 112);
            this.BoxKnapsack.Multiline = true;
            this.BoxKnapsack.Name = "BoxKnapsack";
            this.BoxKnapsack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BoxKnapsack.Size = new System.Drawing.Size(361, 370);
            this.BoxKnapsack.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Let\'s steal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BoxNumber
            // 
            this.BoxNumber.Location = new System.Drawing.Point(12, 65);
            this.BoxNumber.Name = "BoxNumber";
            this.BoxNumber.Size = new System.Drawing.Size(123, 22);
            this.BoxNumber.TabIndex = 2;
            this.BoxNumber.Text = "0";
            this.BoxNumber.TextChanged += new System.EventHandler(this.BoxNumber_TextChanged);
            // 
            // BoxSeed
            // 
            this.BoxSeed.Location = new System.Drawing.Point(141, 65);
            this.BoxSeed.Name = "BoxSeed";
            this.BoxSeed.Size = new System.Drawing.Size(113, 22);
            this.BoxSeed.TabIndex = 3;
            this.BoxSeed.Text = "0";
            this.BoxSeed.TextChanged += new System.EventHandler(this.BoxSeed_TextChanged);
            // 
            // BoxBackpack
            // 
            this.BoxBackpack.Location = new System.Drawing.Point(395, 28);
            this.BoxBackpack.Multiline = true;
            this.BoxBackpack.Name = "BoxBackpack";
            this.BoxBackpack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BoxBackpack.Size = new System.Drawing.Size(447, 454);
            this.BoxBackpack.TabIndex = 4;
            // 
            // BoxWeight
            // 
            this.BoxWeight.Location = new System.Drawing.Point(260, 65);
            this.BoxWeight.Name = "BoxWeight";
            this.BoxWeight.Size = new System.Drawing.Size(113, 22);
            this.BoxWeight.TabIndex = 5;
            this.BoxWeight.Text = "0";
            this.BoxWeight.TextChanged += new System.EventHandler(this.BoxWeight_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Max weight";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Knapsack";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Backpack";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 494);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoxWeight);
            this.Controls.Add(this.BoxBackpack);
            this.Controls.Add(this.BoxSeed);
            this.Controls.Add(this.BoxNumber);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BoxKnapsack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BoxKnapsack;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox BoxNumber;
        private System.Windows.Forms.TextBox BoxSeed;
        private System.Windows.Forms.TextBox BoxBackpack;
        private System.Windows.Forms.TextBox BoxWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

