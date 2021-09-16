namespace Attribute_KILLER__WINDOWS_FORMS_APP_
{
	// Token: 0x0200001A RID: 26
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00009C74 File Offset: 0x00007E74
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			bool flag2 = flag;
			if (flag2)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00009CB0 File Offset: 0x00007EB0
		private void InitializeComponent()
		{
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox7 = new global::System.Windows.Forms.CheckBox();
			this.checkBox8 = new global::System.Windows.Forms.CheckBox();
			this.checkBox9 = new global::System.Windows.Forms.CheckBox();
			this.checkBox10 = new global::System.Windows.Forms.CheckBox();
			this.checkBox11 = new global::System.Windows.Forms.CheckBox();
			this.checkBox12 = new global::System.Windows.Forms.CheckBox();
			this.checkBox13 = new global::System.Windows.Forms.CheckBox();
			this.checkBox14 = new global::System.Windows.Forms.CheckBox();
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.checkBox15 = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.textBox1.AllowDrop = true;
			this.textBox1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox1.Location = new global::System.Drawing.Point(21, 372);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(344, 22);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new global::System.EventHandler(this.TextBox1_TextChanged);
			this.textBox1.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.TextBox1_DragDrop);
			this.textBox1.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.TextBox1_DragEnter);
			this.button1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.Location = new global::System.Drawing.Point(257, 400);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(108, 37);
			this.button1.TabIndex = 1;
			this.button1.Text = "UNPACK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.Button1_Click);
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox1.Location = new global::System.Drawing.Point(21, 26);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(120, 17);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Remove Attributes";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox2.AutoSize = true;
			this.checkBox2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox2.Location = new global::System.Drawing.Point(21, 48);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(133, 17);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Text = "Anti Tamper Remover";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox3.AutoSize = true;
			this.checkBox3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox3.Location = new global::System.Drawing.Point(21, 70);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(219, 17);
			this.checkBox3.TabIndex = 5;
			this.checkBox3.Text = "Static Packer Remover [COMPRESSOR]";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox4.AutoSize = true;
			this.checkBox4.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox4.Location = new global::System.Drawing.Point(21, 92);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new global::System.Drawing.Size(106, 17);
			this.checkBox4.TabIndex = 6;
			this.checkBox4.Text = "Packer Remover";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox5.AutoSize = true;
			this.checkBox5.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox5.Location = new global::System.Drawing.Point(21, 114);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new global::System.Drawing.Size(149, 17);
			this.checkBox5.TabIndex = 7;
			this.checkBox5.Text = "Anti Debugger Remover";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox6.AutoSize = true;
			this.checkBox6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox6.Location = new global::System.Drawing.Point(21, 158);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new global::System.Drawing.Size(137, 17);
			this.checkBox6.TabIndex = 8;
			this.checkBox6.Text = "ControlFlow Remover";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox7.AutoSize = true;
			this.checkBox7.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox7.Location = new global::System.Drawing.Point(21, 180);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new global::System.Drawing.Size(122, 17);
			this.checkBox7.TabIndex = 9;
			this.checkBox7.Text = "Proxy Call Remover";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox8.AutoSize = true;
			this.checkBox8.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox8.Location = new global::System.Drawing.Point(21, 202);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new global::System.Drawing.Size(137, 17);
			this.checkBox8.TabIndex = 10;
			this.checkBox8.Text = "Math Equation Solver";
			this.checkBox8.UseVisualStyleBackColor = true;
			this.checkBox9.AutoSize = true;
			this.checkBox9.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox9.Location = new global::System.Drawing.Point(21, 224);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new global::System.Drawing.Size(102, 17);
			this.checkBox9.TabIndex = 11;
			this.checkBox9.Text = "SizeOfResolver";
			this.checkBox9.UseVisualStyleBackColor = true;
			this.checkBox10.AutoSize = true;
			this.checkBox10.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox10.Location = new global::System.Drawing.Point(21, 270);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new global::System.Drawing.Size(135, 17);
			this.checkBox10.TabIndex = 12;
			this.checkBox10.Text = "Static String Remover";
			this.checkBox10.UseVisualStyleBackColor = true;
			this.checkBox11.AutoSize = true;
			this.checkBox11.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox11.Location = new global::System.Drawing.Point(21, 292);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new global::System.Drawing.Size(219, 17);
			this.checkBox11.TabIndex = 13;
			this.checkBox11.Text = "Dynamic String Remover [CONSTANTS]";
			this.checkBox11.UseVisualStyleBackColor = true;
			this.checkBox12.AutoSize = true;
			this.checkBox12.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox12.Location = new global::System.Drawing.Point(21, 314);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new global::System.Drawing.Size(120, 17);
			this.checkBox12.TabIndex = 14;
			this.checkBox12.Text = "Decrypt Resources";
			this.checkBox12.UseVisualStyleBackColor = true;
			this.checkBox13.AutoSize = true;
			this.checkBox13.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox13.Location = new global::System.Drawing.Point(21, 136);
			this.checkBox13.Name = "checkBox13";
			this.checkBox13.Size = new global::System.Drawing.Size(138, 17);
			this.checkBox13.TabIndex = 15;
			this.checkBox13.Text = "Anti Dumper Remover";
			this.checkBox13.UseVisualStyleBackColor = true;
			this.checkBox14.AutoSize = true;
			this.checkBox14.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox14.Location = new global::System.Drawing.Point(21, 247);
			this.checkBox14.Name = "checkBox14";
			this.checkBox14.Size = new global::System.Drawing.Size(137, 17);
			this.checkBox14.TabIndex = 16;
			this.checkBox14.Text = "InvokeSizeOfRemover";
			this.checkBox14.UseVisualStyleBackColor = true;
			this.richTextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.richTextBox1.ForeColor = global::System.Drawing.Color.Blue;
			this.richTextBox1.Location = new global::System.Drawing.Point(444, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new global::System.Drawing.Size(329, 425);
			this.richTextBox1.TabIndex = 17;
			this.richTextBox1.Text = "";
			this.checkBox15.AutoSize = true;
			this.checkBox15.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox15.Location = new global::System.Drawing.Point(282, 349);
			this.checkBox15.Name = "checkBox15";
			this.checkBox15.Size = new global::System.Drawing.Size(83, 17);
			this.checkBox15.TabIndex = 18;
			this.checkBox15.Text = "CHECK ALL ";
			this.checkBox15.UseVisualStyleBackColor = true;
			this.checkBox15.CheckedChanged += new global::System.EventHandler(this.CheckBox15_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Controls.Add(this.checkBox15);
			base.Controls.Add(this.richTextBox1);
			base.Controls.Add(this.checkBox14);
			base.Controls.Add(this.checkBox13);
			base.Controls.Add(this.checkBox12);
			base.Controls.Add(this.checkBox11);
			base.Controls.Add(this.checkBox10);
			base.Controls.Add(this.checkBox9);
			base.Controls.Add(this.checkBox8);
			base.Controls.Add(this.checkBox7);
			base.Controls.Add(this.checkBox6);
			base.Controls.Add(this.checkBox5);
			base.Controls.Add(this.checkBox4);
			base.Controls.Add(this.checkBox3);
			base.Controls.Add(this.checkBox2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox1);
			base.Name = "Form1";
			this.Text = "Form1";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400005C RID: 92
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.CheckBox checkBox3;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.CheckBox checkBox4;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.CheckBox checkBox5;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.CheckBox checkBox6;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.CheckBox checkBox7;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.CheckBox checkBox8;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.CheckBox checkBox9;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.CheckBox checkBox10;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.CheckBox checkBox11;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.CheckBox checkBox12;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.CheckBox checkBox13;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.CheckBox checkBox14;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.RichTextBox richTextBox1;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.CheckBox checkBox15;
	}
}
