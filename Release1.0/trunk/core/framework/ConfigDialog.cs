using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using freetrain.world;
using org.kohsuke.directdraw;

namespace freetrain.framework
{
	/// <summary>
	/// ConfigDialog の概要の説明です。
	/// </summary>
	public class ConfigDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioMsgBox;
		private System.Windows.Forms.RadioButton radioStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar msgStatusLength;
		private System.Windows.Forms.CheckBox drawStationNames;
		private System.Windows.Forms.CheckBox showBoundingBox;
		private System.Windows.Forms.CheckBox hideTrees;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ComboBox comboSurfaceAlloc;
        private TabControl optionTabControl;
        private TabPage tabPage1;

		private readonly GlobalOptions opts;
		
		public ConfigDialog() : this(Core.options) {}

		public ConfigDialog( GlobalOptions opts ) {
			this.opts = opts;
			InitializeComponent();

			radioMsgBox.Checked = opts.showErrorMessageBox;
			radioStatus.Checked = !opts.showErrorMessageBox;
			msgStatusLength.Value = opts.messageDisplayTime;
			drawStationNames.Checked = opts.drawStationNames;
			showBoundingBox.Checked = opts.drawBoundingBox;
			hideTrees.Checked = opts.hideTrees;
			comboSurfaceAlloc.SelectedIndex = (int)opts.SurfaceAlloc;
		}

		protected override void Dispose( bool disposing ) {
			if( disposing && components != null)
				components.Dispose();
			base.Dispose( disposing );
		}

		private System.ComponentModel.IContainer components;

		#region Windows Form Designer generated code

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
        this.components = new System.ComponentModel.Container();
        this.buttonOK = new System.Windows.Forms.Button();
        this.buttonCancel = new System.Windows.Forms.Button();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.label1 = new System.Windows.Forms.Label();
        this.msgStatusLength = new System.Windows.Forms.TrackBar();
        this.radioStatus = new System.Windows.Forms.RadioButton();
        this.radioMsgBox = new System.Windows.Forms.RadioButton();
        this.drawStationNames = new System.Windows.Forms.CheckBox();
        this.showBoundingBox = new System.Windows.Forms.CheckBox();
        this.hideTrees = new System.Windows.Forms.CheckBox();
        this.comboSurfaceAlloc = new System.Windows.Forms.ComboBox();
        this.label2 = new System.Windows.Forms.Label();
        this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        this.optionTabControl = new System.Windows.Forms.TabControl();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.msgStatusLength)).BeginInit();
        this.optionTabControl.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.SuspendLayout();
        // 
        // buttonOK
        // 
        this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.buttonOK.Location = new System.Drawing.Point(296,302);
        this.buttonOK.Name = "buttonOK";
        this.buttonOK.Size = new System.Drawing.Size(96,30);
        this.buttonOK.TabIndex = 0;
        this.buttonOK.Text = "&OK";
        this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
        // 
        // buttonCancel
        // 
        this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.buttonCancel.Location = new System.Drawing.Point(398,302);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(96,30);
        this.buttonCancel.TabIndex = 1;
        this.buttonCancel.Text = "ｷｬﾝｾﾙ(&C)";
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Controls.Add(this.msgStatusLength);
        this.groupBox1.Controls.Add(this.radioStatus);
        this.groupBox1.Controls.Add(this.radioMsgBox);
        this.groupBox1.Location = new System.Drawing.Point(6,6);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(470,100);
        this.groupBox1.TabIndex = 2;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "エラーメッセージの表示";
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(192,20);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(115,20);
        this.label1.TabIndex = 3;
        this.label1.Text = "表示時間：";
        // 
        // msgStatusLength
        // 
        this.msgStatusLength.Location = new System.Drawing.Point(192,40);
        this.msgStatusLength.Minimum = 1;
        this.msgStatusLength.Name = "msgStatusLength";
        this.msgStatusLength.Size = new System.Drawing.Size(269,45);
        this.msgStatusLength.TabIndex = 2;
        this.msgStatusLength.Value = 1;
        // 
        // radioStatus
        // 
        this.radioStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioStatus.Location = new System.Drawing.Point(19,60);
        this.radioStatus.Name = "radioStatus";
        this.radioStatus.Size = new System.Drawing.Size(173,20);
        this.radioStatus.TabIndex = 1;
        this.radioStatus.Text = "ステータスバーに表示";
        this.radioStatus.CheckedChanged += new System.EventHandler(this.onRadioMsgStyle);
        // 
        // radioMsgBox
        // 
        this.radioMsgBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioMsgBox.Location = new System.Drawing.Point(19,30);
        this.radioMsgBox.Name = "radioMsgBox";
        this.radioMsgBox.Size = new System.Drawing.Size(173,20);
        this.radioMsgBox.TabIndex = 0;
        this.radioMsgBox.Text = "メッセージボックスを表示";
        this.radioMsgBox.CheckedChanged += new System.EventHandler(this.onRadioMsgStyle);
        // 
        // drawStationNames
        // 
        this.drawStationNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.drawStationNames.Location = new System.Drawing.Point(10,112);
        this.drawStationNames.Name = "drawStationNames";
        this.drawStationNames.Size = new System.Drawing.Size(201,20);
        this.drawStationNames.TabIndex = 3;
        this.drawStationNames.Text = "駅の名前を画面に表示";
        // 
        // showBoundingBox
        // 
        this.showBoundingBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.showBoundingBox.Location = new System.Drawing.Point(10,138);
        this.showBoundingBox.Name = "showBoundingBox";
        this.showBoundingBox.Size = new System.Drawing.Size(201,20);
        this.showBoundingBox.TabIndex = 4;
        this.showBoundingBox.Text = "描画範囲を表示(デバッグ)";
        // 
        // hideTrees
        // 
        this.hideTrees.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.hideTrees.Location = new System.Drawing.Point(10,164);
        this.hideTrees.Name = "hideTrees";
        this.hideTrees.Size = new System.Drawing.Size(201,20);
        this.hideTrees.TabIndex = 4;
        this.hideTrees.Text = "樹木の描画を省略";
        // 
        // comboSurfaceAlloc
        // 
        this.comboSurfaceAlloc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboSurfaceAlloc.Items.AddRange(new object[] {
            "自動的に判断する",
            "ビデオメモリに限定する",
            "システムメモリに限定する"});
        this.comboSurfaceAlloc.Location = new System.Drawing.Point(178,200);
        this.comboSurfaceAlloc.Name = "comboSurfaceAlloc";
        this.comboSurfaceAlloc.Size = new System.Drawing.Size(240,22);
        this.comboSurfaceAlloc.TabIndex = 5;
        this.toolTip.SetToolTip(this.comboSurfaceAlloc,"描画が遅かったりエラーがでるようなら変更してください。");
        // 
        // label2
        // 
        this.label2.Location = new System.Drawing.Point(10,200);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(162,20);
        this.label2.TabIndex = 6;
        this.label2.Text = "オフスクリーンサーフェスの確保：";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.toolTip.SetToolTip(this.label2,"描画が遅かったりエラーがでるようなら変更してください。");
        // 
        // optionTabControl
        // 
        this.optionTabControl.Controls.Add(this.tabPage1);
        this.optionTabControl.Location = new System.Drawing.Point(7,12);
        this.optionTabControl.Name = "optionTabControl";
        this.optionTabControl.SelectedIndex = 0;
        this.optionTabControl.Size = new System.Drawing.Size(491,284);
        this.optionTabControl.TabIndex = 7;
        // 
        // tabPage1
        // 
        this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.tabPage1.Controls.Add(this.groupBox1);
        this.tabPage1.Controls.Add(this.label2);
        this.tabPage1.Controls.Add(this.drawStationNames);
        this.tabPage1.Controls.Add(this.comboSurfaceAlloc);
        this.tabPage1.Controls.Add(this.hideTrees);
        this.tabPage1.Controls.Add(this.showBoundingBox);
        this.tabPage1.Location = new System.Drawing.Point(4,23);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(483,257);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "全般";
        this.tabPage1.UseVisualStyleBackColor = true;
        // 
        // ConfigDialog
        // 
        this.AcceptButton = this.buttonOK;
        this.AutoScaleBaseSize = new System.Drawing.Size(6,15);
        this.CancelButton = this.buttonCancel;
        this.ClientSize = new System.Drawing.Size(505,337);
        this.Controls.Add(this.optionTabControl);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ConfigDialog";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "FreeTrainExの設定";
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.msgStatusLength)).EndInit();
        this.optionTabControl.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.ResumeLayout(false);

		}
		#endregion

		private void onRadioMsgStyle(object sender, EventArgs e) {
			msgStatusLength.Enabled = radioStatus.Checked;
		}

		private void buttonOK_Click(object sender, EventArgs e) {
			opts.showErrorMessageBox = radioMsgBox.Checked;
			opts.messageDisplayTime = msgStatusLength.Value;
			opts.drawStationNames = drawStationNames.Checked;
			opts.drawBoundingBox = showBoundingBox.Checked;
			opts.hideTrees = hideTrees.Checked;
			opts.SurfaceAlloc = (DDSurfaceAllocation)comboSurfaceAlloc.SelectedIndex;
			opts.save();
			Close();
		}


	}
}
