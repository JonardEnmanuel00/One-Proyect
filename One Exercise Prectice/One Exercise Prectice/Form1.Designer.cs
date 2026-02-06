namespace One_Exercise_Prectice
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Etiqueta = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // Etiqueta
            // 
            Etiqueta.AutoSize = true;
            Etiqueta.Location = new Point(28, 25);
            Etiqueta.Name = "Etiqueta";
            Etiqueta.Size = new Size(49, 20);
            Etiqueta.TabIndex = 0;
            Etiqueta.Text = "Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(28, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(168, 46);
            button1.Name = "button1";
            button1.Size = new Size(248, 102);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(Etiqueta);
            Cursor = Cursors.IBeam;
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "One Exercise";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Etiqueta;
        private TextBox textBox1;
        private Button button1;
    }
}
