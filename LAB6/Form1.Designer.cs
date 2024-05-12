namespace LAB6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.tbGraviton = new System.Windows.Forms.TrackBar();
            this.lblGraviton = new System.Windows.Forms.Label();
            this.tbGraviton2 = new System.Windows.Forms.TrackBar();
            this.lblGraviton2 = new System.Windows.Forms.Label();
            this.Text1 = new System.Windows.Forms.Label();
            this.checkBoxTeleport = new System.Windows.Forms.CheckBox();
            this.checkBoxExplosion = new System.Windows.Forms.CheckBox();
            this.checkBoxGravity = new System.Windows.Forms.CheckBox();
            this.checkBoxWand = new System.Windows.Forms.CheckBox();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.tbParticlesPerTick = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblParticlesPerTick = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbParticlesPerTick)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(7, 2);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1170, 350);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(7, 374);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(163, 56);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(176, 388);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(62, 16);
            this.lblDirection.TabIndex = 2;
            this.lblDirection.Text = "Счетчик";
            // 
            // tbGraviton
            // 
            this.tbGraviton.Location = new System.Drawing.Point(511, 418);
            this.tbGraviton.Maximum = 100;
            this.tbGraviton.Name = "tbGraviton";
            this.tbGraviton.Size = new System.Drawing.Size(106, 56);
            this.tbGraviton.TabIndex = 3;
            this.tbGraviton.Scroll += new System.EventHandler(this.tbGraviton_Scroll);
            // 
            // lblGraviton
            // 
            this.lblGraviton.AutoSize = true;
            this.lblGraviton.Location = new System.Drawing.Point(635, 426);
            this.lblGraviton.Name = "lblGraviton";
            this.lblGraviton.Size = new System.Drawing.Size(62, 16);
            this.lblGraviton.TabIndex = 4;
            this.lblGraviton.Text = "Счетчик";
            // 
            // tbGraviton2
            // 
            this.tbGraviton2.Location = new System.Drawing.Point(513, 358);
            this.tbGraviton2.Maximum = 100;
            this.tbGraviton2.Name = "tbGraviton2";
            this.tbGraviton2.Size = new System.Drawing.Size(104, 56);
            this.tbGraviton2.TabIndex = 5;
            this.tbGraviton2.Scroll += new System.EventHandler(this.tbGraviton2_Scroll);
            // 
            // lblGraviton2
            // 
            this.lblGraviton2.AutoSize = true;
            this.lblGraviton2.Location = new System.Drawing.Point(635, 374);
            this.lblGraviton2.Name = "lblGraviton2";
            this.lblGraviton2.Size = new System.Drawing.Size(62, 16);
            this.lblGraviton2.TabIndex = 6;
            this.lblGraviton2.Text = "Счетчик";
            // 
            // Text1
            // 
            this.Text1.AutoSize = true;
            this.Text1.Location = new System.Drawing.Point(32, 355);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(115, 16);
            this.Text1.TabIndex = 7;
            this.Text1.Text = "Изменение угла";
            // 
            // checkBoxTeleport
            // 
            this.checkBoxTeleport.AutoSize = true;
            this.checkBoxTeleport.Location = new System.Drawing.Point(884, 374);
            this.checkBoxTeleport.Name = "checkBoxTeleport";
            this.checkBoxTeleport.Size = new System.Drawing.Size(211, 20);
            this.checkBoxTeleport.TabIndex = 8;
            this.checkBoxTeleport.Text = "Телепорт с политеха домой";
            this.checkBoxTeleport.UseVisualStyleBackColor = true;
            this.checkBoxTeleport.CheckedChanged += new System.EventHandler(this.checkBoxTeleport_CheckedChanged);
            // 
            // checkBoxExplosion
            // 
            this.checkBoxExplosion.AutoSize = true;
            this.checkBoxExplosion.Location = new System.Drawing.Point(884, 400);
            this.checkBoxExplosion.Name = "checkBoxExplosion";
            this.checkBoxExplosion.Size = new System.Drawing.Size(101, 20);
            this.checkBoxExplosion.TabIndex = 9;
            this.checkBoxExplosion.Text = "Поедатель";
            this.checkBoxExplosion.UseVisualStyleBackColor = true;
            this.checkBoxExplosion.CheckedChanged += new System.EventHandler(this.checkBoxExplosion_CheckedChanged);
            // 
            // checkBoxGravity
            // 
            this.checkBoxGravity.AutoSize = true;
            this.checkBoxGravity.Location = new System.Drawing.Point(523, 394);
            this.checkBoxGravity.Name = "checkBoxGravity";
            this.checkBoxGravity.Size = new System.Drawing.Size(71, 20);
            this.checkBoxGravity.TabIndex = 10;
            this.checkBoxGravity.Text = "Gravity";
            this.checkBoxGravity.UseVisualStyleBackColor = true;
            this.checkBoxGravity.CheckedChanged += new System.EventHandler(this.checkBoxGravity_CheckedChanged);
            // 
            // checkBoxWand
            // 
            this.checkBoxWand.AutoSize = true;
            this.checkBoxWand.Location = new System.Drawing.Point(884, 426);
            this.checkBoxWand.Name = "checkBoxWand";
            this.checkBoxWand.Size = new System.Drawing.Size(160, 20);
            this.checkBoxWand.TabIndex = 11;
            this.checkBoxWand.Text = "Волшебная палочка";
            this.checkBoxWand.UseVisualStyleBackColor = true;
            this.checkBoxWand.CheckedChanged += new System.EventHandler(this.checkBoxWand_CheckedChanged);
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(12, 436);
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(148, 56);
            this.tbSpreading.TabIndex = 12;
            this.tbSpreading.Scroll += new System.EventHandler(this.tbSpreading_Scroll);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(266, 364);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(148, 56);
            this.tbSpeed.TabIndex = 13;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // tbParticlesPerTick
            // 
            this.tbParticlesPerTick.Location = new System.Drawing.Point(266, 426);
            this.tbParticlesPerTick.Name = "tbParticlesPerTick";
            this.tbParticlesPerTick.Size = new System.Drawing.Size(148, 56);
            this.tbParticlesPerTick.TabIndex = 14;
            this.tbParticlesPerTick.Scroll += new System.EventHandler(this.tbParticlesPerTick_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Разброс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Скорость";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Количество частиц";
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(176, 436);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(62, 16);
            this.lblSpreading.TabIndex = 18;
            this.lblSpreading.Text = "Счетчик";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(429, 374);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(62, 16);
            this.lblSpeed.TabIndex = 19;
            this.lblSpeed.Text = "Счетчик";
            // 
            // lblParticlesPerTick
            // 
            this.lblParticlesPerTick.AutoSize = true;
            this.lblParticlesPerTick.Location = new System.Drawing.Point(429, 426);
            this.lblParticlesPerTick.Name = "lblParticlesPerTick";
            this.lblParticlesPerTick.Size = new System.Drawing.Size(62, 16);
            this.lblParticlesPerTick.TabIndex = 20;
            this.lblParticlesPerTick.Text = "Счетчик";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 489);
            this.Controls.Add(this.lblParticlesPerTick);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbParticlesPerTick);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.checkBoxWand);
            this.Controls.Add(this.checkBoxGravity);
            this.Controls.Add(this.checkBoxExplosion);
            this.Controls.Add(this.checkBoxTeleport);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.lblGraviton2);
            this.Controls.Add(this.tbGraviton2);
            this.Controls.Add(this.lblGraviton);
            this.Controls.Add(this.tbGraviton);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Частицы";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbParticlesPerTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TrackBar tbGraviton;
        private System.Windows.Forms.Label lblGraviton;
        private System.Windows.Forms.TrackBar tbGraviton2;
        private System.Windows.Forms.Label lblGraviton2;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.CheckBox checkBoxTeleport;
        private System.Windows.Forms.CheckBox checkBoxExplosion;
        private System.Windows.Forms.CheckBox checkBoxGravity;
        private System.Windows.Forms.CheckBox checkBoxWand;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.TrackBar tbParticlesPerTick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblParticlesPerTick;
    }
}

