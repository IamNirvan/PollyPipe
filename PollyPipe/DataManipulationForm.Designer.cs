namespace PollyPipe
{
    partial class DataManipulationForm
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
            this.dataPanel = new System.Windows.Forms.Panel();
            this.insertBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.enableInsertRadioBtn = new System.Windows.Forms.RadioButton();
            this.enableUpdateRadioBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataPanel.Location = new System.Drawing.Point(0, 0);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(684, 315);
            this.dataPanel.TabIndex = 2;
            // 
            // insertBtn
            // 
            this.insertBtn.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertBtn.Location = new System.Drawing.Point(5, 367);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(135, 43);
            this.insertBtn.TabIndex = 3;
            this.insertBtn.TabStop = false;
            this.insertBtn.Text = "Insert";
            this.insertBtn.UseVisualStyleBackColor = true;
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(146, 367);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(135, 43);
            this.updateBtn.TabIndex = 4;
            this.updateBtn.TabStop = false;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(542, 367);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(135, 43);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.TabStop = false;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // enableInsertRadioBtn
            // 
            this.enableInsertRadioBtn.AutoSize = true;
            this.enableInsertRadioBtn.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableInsertRadioBtn.Location = new System.Drawing.Point(5, 332);
            this.enableInsertRadioBtn.Name = "enableInsertRadioBtn";
            this.enableInsertRadioBtn.Size = new System.Drawing.Size(93, 19);
            this.enableInsertRadioBtn.TabIndex = 6;
            this.enableInsertRadioBtn.Text = "Enable insert";
            this.enableInsertRadioBtn.UseVisualStyleBackColor = true;
            // 
            // enableUpdateRadioBtn
            // 
            this.enableUpdateRadioBtn.AutoSize = true;
            this.enableUpdateRadioBtn.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableUpdateRadioBtn.Location = new System.Drawing.Point(146, 332);
            this.enableUpdateRadioBtn.Name = "enableUpdateRadioBtn";
            this.enableUpdateRadioBtn.Size = new System.Drawing.Size(100, 19);
            this.enableUpdateRadioBtn.TabIndex = 7;
            this.enableUpdateRadioBtn.Text = "Enable update";
            this.enableUpdateRadioBtn.UseVisualStyleBackColor = true;
            // 
            // DataManipulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 416);
            this.Controls.Add(this.enableUpdateRadioBtn);
            this.Controls.Add(this.enableInsertRadioBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.dataPanel);
            this.Font = new System.Drawing.Font("Carlito", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DataManipulationForm";
            this.Text = "DataManipulationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.RadioButton enableInsertRadioBtn;
        private System.Windows.Forms.RadioButton enableUpdateRadioBtn;
    }
}