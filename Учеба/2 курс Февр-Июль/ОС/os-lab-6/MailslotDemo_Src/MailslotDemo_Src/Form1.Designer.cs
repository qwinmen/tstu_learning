namespace MailslotDemo_Src
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
      this.txtMessages = new System.Windows.Forms.TextBox();
      this.btnSend = new System.Windows.Forms.Button();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.csMailSlot1 = new csMailSlot.vMailslot();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtMessages
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.txtMessages, 2);
      this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtMessages.Location = new System.Drawing.Point(3, 3);
      this.txtMessages.Multiline = true;
      this.txtMessages.Name = "txtMessages";
      this.txtMessages.Size = new System.Drawing.Size(437, 248);
      this.txtMessages.TabIndex = 1;
      // 
      // btnSend
      // 
      this.btnSend.Location = new System.Drawing.Point(368, 257);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(72, 20);
      this.btnSend.TabIndex = 2;
      this.btnSend.Text = "Send";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // txtInput
      // 
      this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtInput.Location = new System.Drawing.Point(3, 257);
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new System.Drawing.Size(359, 20);
      this.txtInput.TabIndex = 3;
      this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.41206F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.58794F));
      this.tableLayoutPanel1.Controls.Add(this.txtMessages, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.txtInput, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.btnSend, 1, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(443, 280);
      this.tableLayoutPanel1.TabIndex = 4;
      // 
      // csMailSlot1
      // 
      this.csMailSlot1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("csMailSlot1.BackgroundImage")));
      this.csMailSlot1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.csMailSlot1.Location = new System.Drawing.Point(4, 5);
      this.csMailSlot1.MaximumSize = new System.Drawing.Size(49, 38);
      this.csMailSlot1.MinimumSize = new System.Drawing.Size(49, 38);
      this.csMailSlot1.Name = "csMailSlot1";
      this.csMailSlot1.Size = new System.Drawing.Size(49, 38);
      this.csMailSlot1.SlotName = "MySlot";
      this.csMailSlot1.TabIndex = 0;
      this.csMailSlot1.Visible = false;
      this.csMailSlot1.OnReceivedData += new csMailSlot.vMailslot.ReceivedDataHandler(this.csMailSlot1_OnReceivedData);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(443, 280);
      this.Controls.Add(this.csMailSlot1);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private csMailSlot.vMailslot csMailSlot1;
    private System.Windows.Forms.TextBox txtMessages;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.TextBox txtInput;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}

