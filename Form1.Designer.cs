namespace dllinjector1
{
    partial class form1
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
            txtProcessId = new TextBox();
            txtDllPath = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnInject = new Button();
            btnBrowse = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtProcessId
            // 
            txtProcessId.Location = new Point(159, 118);
            txtProcessId.Name = "txtProcessId";
            txtProcessId.Size = new Size(146, 23);
            txtProcessId.TabIndex = 0;
            // 
            // txtDllPath
            // 
            txtDllPath.Location = new Point(155, 147);
            txtDllPath.Name = "txtDllPath";
            txtDllPath.Size = new Size(153, 23);
            txtDllPath.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 121);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 3;
            label2.Text = "pid";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 150);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "dll fle";
            // 
            // btnInject
            // 
            btnInject.Location = new Point(163, 188);
            btnInject.Name = "btnInject";
            btnInject.Size = new Size(123, 39);
            btnInject.TabIndex = 5;
            btnInject.Text = "inject dat shit";
            btnInject.UseVisualStyleBackColor = true;
            btnInject.Click += btnInject_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(314, 143);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(73, 28);
            btnBrowse.TabIndex = 6;
            btnBrowse.Text = "browse file";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 7;
            label1.Text = "this is a joke but it works bro";
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(461, 314);
            Controls.Add(label1);
            Controls.Add(btnBrowse);
            Controls.Add(btnInject);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtDllPath);
            Controls.Add(txtProcessId);
            Name = "form1";
            Text = "Shitty ass fucking dll injector made by ciadotgov";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProcessId;
        private TextBox txtDllPath;
        private Label label2;
        private Label label3;
        private Button btnInject;
        private Button btnBrowse;
        private Label label1;
    }
}
