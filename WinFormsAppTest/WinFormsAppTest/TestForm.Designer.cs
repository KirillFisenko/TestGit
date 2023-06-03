namespace WinFormsAppTest
{
    partial class TestForm
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
            label1 = new Label();
            inputTextBox = new TextBox();
            label2 = new Label();
            outputTextBox = new TextBox();
            button = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(26, 69);
            label1.Name = "label1";
            label1.Size = new Size(130, 21);
            label1.TabIndex = 0;
            label1.Text = "Входные данные";
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(178, 69);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(572, 23);
            inputTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 292);
            label2.Name = "label2";
            label2.Size = new Size(141, 21);
            label2.TabIndex = 2;
            label2.Text = "Выходные данные";
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(178, 292);
            outputTextBox.Multiline = true;
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ScrollBars = ScrollBars.Both;
            outputTextBox.Size = new Size(572, 116);
            outputTextBox.TabIndex = 3;
            // 
            // button
            // 
            button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button.Location = new Point(178, 163);
            button.Name = "button";
            button.Size = new Size(186, 55);
            button.TabIndex = 4;
            button.Text = "Запустить код";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 557);
            Controls.Add(button);
            Controls.Add(outputTextBox);
            Controls.Add(label2);
            Controls.Add(inputTextBox);
            Controls.Add(label1);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox inputTextBox;
        private Label label2;
        private TextBox outputTextBox;
        private Button button;
    }
}