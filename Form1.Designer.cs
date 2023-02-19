namespace BPDT_lab1
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
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.encryptRadioButton = new System.Windows.Forms.RadioButton();
            this.decryptRadioButton = new System.Windows.Forms.RadioButton();
            this.execButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.entropyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hexKeycheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(12, 12);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.PlaceholderText = "Enter cipher key";
            this.keyTextBox.Size = new System.Drawing.Size(274, 27);
            this.keyTextBox.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 75);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.PlaceholderText = "Enter input text";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(274, 338);
            this.inputTextBox.TabIndex = 1;
            // 
            // encryptRadioButton
            // 
            this.encryptRadioButton.AutoSize = true;
            this.encryptRadioButton.Checked = true;
            this.encryptRadioButton.Location = new System.Drawing.Point(301, 13);
            this.encryptRadioButton.Name = "encryptRadioButton";
            this.encryptRadioButton.Size = new System.Drawing.Size(79, 24);
            this.encryptRadioButton.TabIndex = 2;
            this.encryptRadioButton.TabStop = true;
            this.encryptRadioButton.Text = "Encrypt";
            this.encryptRadioButton.UseVisualStyleBackColor = true;
            this.encryptRadioButton.CheckedChanged += new System.EventHandler(this.encryptRadioButton_CheckedChanged);
            // 
            // decryptRadioButton
            // 
            this.decryptRadioButton.AutoSize = true;
            this.decryptRadioButton.Location = new System.Drawing.Point(383, 13);
            this.decryptRadioButton.Name = "decryptRadioButton";
            this.decryptRadioButton.Size = new System.Drawing.Size(82, 24);
            this.decryptRadioButton.TabIndex = 3;
            this.decryptRadioButton.TabStop = true;
            this.decryptRadioButton.Text = "Decrypt";
            this.decryptRadioButton.UseVisualStyleBackColor = true;
            this.decryptRadioButton.CheckedChanged += new System.EventHandler(this.decryptRadioButton_CheckedChanged);
            // 
            // execButton
            // 
            this.execButton.Location = new System.Drawing.Point(481, 10);
            this.execButton.Name = "execButton";
            this.execButton.Size = new System.Drawing.Size(94, 29);
            this.execButton.TabIndex = 4;
            this.execButton.Text = "Execute";
            this.execButton.UseVisualStyleBackColor = true;
            this.execButton.Click += new System.EventHandler(this.execButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(301, 75);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.PlaceholderText = "Output text";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(274, 338);
            this.outputTextBox.TabIndex = 5;
            // 
            // entropyTextBox
            // 
            this.entropyTextBox.Location = new System.Drawing.Point(592, 75);
            this.entropyTextBox.Multiline = true;
            this.entropyTextBox.Name = "entropyTextBox";
            this.entropyTextBox.PlaceholderText = "Rounds...";
            this.entropyTextBox.ReadOnly = true;
            this.entropyTextBox.Size = new System.Drawing.Size(226, 338);
            this.entropyTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(592, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entropy per round:";
            // 
            // hexKeycheckBox
            // 
            this.hexKeycheckBox.AutoSize = true;
            this.hexKeycheckBox.Location = new System.Drawing.Point(12, 45);
            this.hexKeycheckBox.Name = "hexKeycheckBox";
            this.hexKeycheckBox.Size = new System.Drawing.Size(85, 24);
            this.hexKeycheckBox.TabIndex = 8;
            this.hexKeycheckBox.Text = "HEX key";
            this.hexKeycheckBox.UseVisualStyleBackColor = true;
            this.hexKeycheckBox.CheckedChanged += new System.EventHandler(this.hexKeycheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 426);
            this.Controls.Add(this.hexKeycheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entropyTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.execButton);
            this.Controls.Add(this.decryptRadioButton);
            this.Controls.Add(this.encryptRadioButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.RadioButton encryptRadioButton;
        private System.Windows.Forms.RadioButton decryptRadioButton;
        private System.Windows.Forms.Button execButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox entropyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox hexKeycheckBox;
    }
}
