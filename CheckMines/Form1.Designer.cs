namespace MakeButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Menus = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TwentyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThirtyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMarked = new System.Windows.Forms.Label();
            this.Menus.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menus
            // 
            this.Menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OptionsMenuItem});
            this.Menus.Location = new System.Drawing.Point(0, 0);
            this.Menus.Name = "Menus";
            this.Menus.Size = new System.Drawing.Size(244, 24);
            this.Menus.TabIndex = 0;
            this.Menus.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.ExitMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.Size = new System.Drawing.Size(98, 22);
            this.NewMenuItem.Text = "New";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(98, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TenMenuItem,
            this.TwentyMenuItem,
            this.ThirtyMenuItem});
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OptionsMenuItem.Text = "Options";
            // 
            // TenMenuItem
            // 
            this.TenMenuItem.Name = "TenMenuItem";
            this.TenMenuItem.Size = new System.Drawing.Size(105, 22);
            this.TenMenuItem.Text = "10X10";
            this.TenMenuItem.Click += new System.EventHandler(this.TenMenuItem_Click);
            // 
            // TwentyMenuItem
            // 
            this.TwentyMenuItem.Name = "TwentyMenuItem";
            this.TwentyMenuItem.Size = new System.Drawing.Size(105, 22);
            this.TwentyMenuItem.Text = "20X20";
            this.TwentyMenuItem.Click += new System.EventHandler(this.TwentyMenuItem_Click);
            // 
            // ThirtyMenuItem
            // 
            this.ThirtyMenuItem.Name = "ThirtyMenuItem";
            this.ThirtyMenuItem.Size = new System.Drawing.Size(105, 22);
            this.ThirtyMenuItem.Text = "30X30";
            this.ThirtyMenuItem.Click += new System.EventHandler(this.ThirtyMenuItem_Click);
            // 
            // lblMarked
            // 
            this.lblMarked.AutoSize = true;
            this.lblMarked.Location = new System.Drawing.Point(10, 25);
            this.lblMarked.Name = "lblMarked";
            this.lblMarked.Size = new System.Drawing.Size(19, 13);
            this.lblMarked.TabIndex = 1;
            this.lblMarked.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 262);
            this.Controls.Add(this.lblMarked);
            this.Controls.Add(this.Menus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menus;
            this.Name = "Form1";
            this.Text = "Mines Field";
            this.Menus.ResumeLayout(false);
            this.Menus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menus;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TwentyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThirtyMenuItem;
        private System.Windows.Forms.Label lblMarked;







    }
}

