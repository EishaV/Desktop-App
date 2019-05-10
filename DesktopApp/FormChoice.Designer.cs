namespace DesktopApp {
  partial class FormChoice {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.button = new System.Windows.Forms.Button();
      this.panel = new System.Windows.Forms.Panel();
      this.listView = new System.Windows.Forms.ListView();
      this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chMac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel.SuspendLayout();
      this.SuspendLayout();
      // 
      // button
      // 
      this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button.Location = new System.Drawing.Point(181, 5);
      this.button.Name = "button";
      this.button.Size = new System.Drawing.Size(60, 23);
      this.button.TabIndex = 1;
      this.button.Text = "OK";
      this.button.UseVisualStyleBackColor = true;
      // 
      // panel
      // 
      this.panel.AutoSize = true;
      this.panel.Controls.Add(this.button);
      this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel.Location = new System.Drawing.Point(0, 90);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(244, 31);
      this.panel.TabIndex = 2;
      // 
      // listView
      // 
      this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chMac});
      this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView.FullRowSelect = true;
      this.listView.HideSelection = false;
      this.listView.Location = new System.Drawing.Point(0, 0);
      this.listView.MultiSelect = false;
      this.listView.Name = "listView";
      this.listView.Size = new System.Drawing.Size(244, 90);
      this.listView.TabIndex = 3;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = System.Windows.Forms.View.Details;
      // 
      // chName
      // 
      this.chName.Text = "Name";
      // 
      // chMac
      // 
      this.chMac.Text = "MAC-Adresse";
      // 
      // FormChoice
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(244, 121);
      this.Controls.Add(this.listView);
      this.Controls.Add(this.panel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormChoice";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Landroid-S auswählen";
      this.panel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button button;
    private System.Windows.Forms.Panel panel;
    private System.Windows.Forms.ListView listView;
    private System.Windows.Forms.ColumnHeader chName;
    private System.Windows.Forms.ColumnHeader chMac;
  }
}