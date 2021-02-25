
namespace CablesTechModeWindowsFormsApp
{
    partial class MainForm
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
            this.cablesNamesListBox = new System.Windows.Forms.ListBox();
            this.wireSquareListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cablesNamesListBox
            // 
            this.cablesNamesListBox.FormattingEnabled = true;
            this.cablesNamesListBox.Location = new System.Drawing.Point(13, 13);
            this.cablesNamesListBox.Name = "cablesNamesListBox";
            this.cablesNamesListBox.Size = new System.Drawing.Size(121, 199);
            this.cablesNamesListBox.TabIndex = 0;
            // 
            // wireSquareListBox
            // 
            this.wireSquareListBox.FormattingEnabled = true;
            this.wireSquareListBox.Location = new System.Drawing.Point(141, 13);
            this.wireSquareListBox.Name = "wireSquareListBox";
            this.wireSquareListBox.Size = new System.Drawing.Size(120, 199);
            this.wireSquareListBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wireSquareListBox);
            this.Controls.Add(this.cablesNamesListBox);
            this.Name = "MainForm";
            this.Text = "Cables tech modes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox cablesNamesListBox;
        private System.Windows.Forms.ListBox wireSquareListBox;
    }
}

