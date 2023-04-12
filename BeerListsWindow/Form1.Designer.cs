namespace BeerListsWindow
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
            this.gen_button = new System.Windows.Forms.Button();
            this.country_list = new System.Windows.Forms.ComboBox();
            this.show_box = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.beer_list = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gen_button
            // 
            this.gen_button.Location = new System.Drawing.Point(61, 310);
            this.gen_button.Name = "gen_button";
            this.gen_button.Size = new System.Drawing.Size(87, 35);
            this.gen_button.TabIndex = 0;
            this.gen_button.Text = "Generate";
            this.gen_button.UseVisualStyleBackColor = true;
            this.gen_button.Click += new System.EventHandler(this.gen_button_Click);
            // 
            // country_list
            // 
            this.country_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.country_list.FormattingEnabled = true;
            this.country_list.Items.AddRange(new object[] {
            "All",
            "denmark",
            "sweden",
            "belgium",
            "spain",
            "portugal",
            "ireland",
            "luxembourg",
            "norway",
            "finland",
            "switzerland",
            "czech",
            "italy",
            "poland",
            "malta"});
            this.country_list.Location = new System.Drawing.Point(44, 244);
            this.country_list.Name = "country_list";
            this.country_list.Size = new System.Drawing.Size(121, 24);
            this.country_list.TabIndex = 1;
            // 
            // show_box
            // 
            this.show_box.FormattingEnabled = true;
            this.show_box.Items.AddRange(new object[] {
            "Name",
            "Alcohol",
            "Country",
            "Description"});
            this.show_box.Location = new System.Drawing.Point(44, 126);
            this.show_box.Name = "show_box";
            this.show_box.Size = new System.Drawing.Size(104, 72);
            this.show_box.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Show";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Country";
            // 
            // beer_list
            // 
            this.beer_list.FormattingEnabled = true;
            this.beer_list.ItemHeight = 16;
            this.beer_list.Location = new System.Drawing.Point(231, 34);
            this.beer_list.Name = "beer_list";
            this.beer_list.Size = new System.Drawing.Size(557, 404);
            this.beer_list.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "BeerList";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.beer_list);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.show_box);
            this.Controls.Add(this.country_list);
            this.Controls.Add(this.gen_button);
            this.Name = "Form1";
            this.Text = "BeerList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gen_button;
        private System.Windows.Forms.ComboBox country_list;
        private System.Windows.Forms.CheckedListBox show_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox beer_list;
        private System.Windows.Forms.Label label3;
    }
}

