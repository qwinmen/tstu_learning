namespace Пристрелка
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.zedGraph_tx = new ZedGraph.ZedGraphControl();
            this.zedGraph_ty = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.doubleInput_step = new DevComponents.Editors.DoubleInput();
            this.doubleInput_epsilon = new DevComponents.Editors.DoubleInput();
            this.doubleInput_z = new DevComponents.Editors.DoubleInput();
            this.doubleInput_u = new DevComponents.Editors.DoubleInput();
            this.styleManager2 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_step)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_epsilon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_u)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // zedGraph_tx
            // 
            this.zedGraph_tx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_tx.Location = new System.Drawing.Point(3, 3);
            this.zedGraph_tx.Name = "zedGraph_tx";
            this.zedGraph_tx.ScrollGrace = 0;
            this.zedGraph_tx.ScrollMaxX = 0;
            this.zedGraph_tx.ScrollMaxY = 0;
            this.zedGraph_tx.ScrollMaxY2 = 0;
            this.zedGraph_tx.ScrollMinX = 0;
            this.zedGraph_tx.ScrollMinY = 0;
            this.zedGraph_tx.ScrollMinY2 = 0;
            this.zedGraph_tx.Size = new System.Drawing.Size(358, 315);
            this.zedGraph_tx.TabIndex = 0;
            // 
            // zedGraph_ty
            // 
            this.zedGraph_ty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_ty.Location = new System.Drawing.Point(367, 3);
            this.zedGraph_ty.Name = "zedGraph_ty";
            this.zedGraph_ty.ScrollGrace = 0;
            this.zedGraph_ty.ScrollMaxX = 0;
            this.zedGraph_ty.ScrollMaxY = 0;
            this.zedGraph_ty.ScrollMaxY2 = 0;
            this.zedGraph_ty.ScrollMinX = 0;
            this.zedGraph_ty.ScrollMinY = 0;
            this.zedGraph_ty.ScrollMinY2 = 0;
            this.zedGraph_ty.Size = new System.Drawing.Size(359, 315);
            this.zedGraph_ty.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.zedGraph_ty, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.zedGraph_tx, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 321);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel1.Controls.Add(this.doubleInput_step);
            this.flowLayoutPanel1.Controls.Add(this.doubleInput_epsilon);
            this.flowLayoutPanel1.Controls.Add(this.doubleInput_z);
            this.flowLayoutPanel1.Controls.Add(this.doubleInput_u);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(729, 26);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // doubleInput_step
            // 
            // 
            // 
            // 
            this.doubleInput_step.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_step.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_step.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_step.ButtonFreeText.Text = "шаг";
            this.doubleInput_step.ButtonFreeText.Visible = true;
            this.doubleInput_step.Increment = 0.04;
            this.doubleInput_step.Location = new System.Drawing.Point(3, 3);
            this.doubleInput_step.MaxValue = 10;
            this.doubleInput_step.MinValue = 1E-05;
            this.doubleInput_step.Name = "doubleInput_step";
            this.doubleInput_step.Size = new System.Drawing.Size(94, 20);
            this.doubleInput_step.TabIndex = 0;
            this.doubleInput_step.Value = 0.01;
            this.doubleInput_step.WatermarkText = "△t";
            this.doubleInput_step.ButtonFreeTextClick += new System.ComponentModel.CancelEventHandler(this.doubleInput_step_ButtonFreeTextClick);
            // 
            // doubleInput_epsilon
            // 
            // 
            // 
            // 
            this.doubleInput_epsilon.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_epsilon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_epsilon.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_epsilon.ButtonFreeText.Text = "eps";
            this.doubleInput_epsilon.ButtonFreeText.Visible = true;
            this.doubleInput_epsilon.Increment = 0.04;
            this.doubleInput_epsilon.Location = new System.Drawing.Point(103, 3);
            this.doubleInput_epsilon.MaxValue = 10;
            this.doubleInput_epsilon.MinValue = 1E-05;
            this.doubleInput_epsilon.Name = "doubleInput_epsilon";
            this.doubleInput_epsilon.Size = new System.Drawing.Size(94, 20);
            this.doubleInput_epsilon.TabIndex = 0;
            this.doubleInput_epsilon.Value = 0.01;
            this.doubleInput_epsilon.WatermarkText = "e";
            this.doubleInput_epsilon.ButtonFreeTextClick += new System.ComponentModel.CancelEventHandler(this.doubleInput_z_ButtonFreeTextClick);
            // 
            // doubleInput_z
            // 
            // 
            // 
            // 
            this.doubleInput_z.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_z.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_z.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_z.ButtonFreeText.Text = "z";
            this.doubleInput_z.ButtonFreeText.Visible = true;
            this.doubleInput_z.Increment = 1;
            this.doubleInput_z.Location = new System.Drawing.Point(203, 3);
            this.doubleInput_z.MaxValue = 15;
            this.doubleInput_z.MinValue = -15;
            this.doubleInput_z.Name = "doubleInput_z";
            this.doubleInput_z.ShowUpDown = true;
            this.doubleInput_z.Size = new System.Drawing.Size(158, 20);
            this.doubleInput_z.TabIndex = 1;
            this.doubleInput_z.Value = 1;
            this.doubleInput_z.WatermarkText = "z";
            this.doubleInput_z.ButtonFreeTextClick += new System.ComponentModel.CancelEventHandler(this.doubleInput_z_ButtonFreeTextClick);
            // 
            // doubleInput_u
            // 
            // 
            // 
            // 
            this.doubleInput_u.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_u.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_u.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_u.ButtonFreeText.Text = "u";
            this.doubleInput_u.ButtonFreeText.Visible = true;
            this.doubleInput_u.Increment = 1;
            this.doubleInput_u.Location = new System.Drawing.Point(367, 3);
            this.doubleInput_u.MaxValue = 15;
            this.doubleInput_u.MinValue = -15;
            this.doubleInput_u.Name = "doubleInput_u";
            this.doubleInput_u.ShowUpDown = true;
            this.doubleInput_u.Size = new System.Drawing.Size(158, 20);
            this.doubleInput_u.TabIndex = 2;
            this.doubleInput_u.Value = 1;
            this.doubleInput_u.WatermarkText = "u";
            this.doubleInput_u.ButtonFreeTextClick += new System.ComponentModel.CancelEventHandler(this.doubleInput_z_ButtonFreeTextClick);
            // 
            // styleManager2
            // 
            this.styleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            this.styleManager2.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 347);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Метод пристрелки";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_step)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_epsilon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_u)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private ZedGraph.ZedGraphControl zedGraph_tx;
        private ZedGraph.ZedGraphControl zedGraph_ty;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevComponents.Editors.DoubleInput doubleInput_step;
        private DevComponents.Editors.DoubleInput doubleInput_z;
        private DevComponents.Editors.DoubleInput doubleInput_u;
        private DevComponents.DotNetBar.StyleManager styleManager2;
        private DevComponents.Editors.DoubleInput doubleInput_epsilon;
    }
}

