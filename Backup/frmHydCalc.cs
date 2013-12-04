using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using HydraulicCalc.Converters;
using HydraulicCalc.Common;
using System.Runtime.InteropServices;

namespace HydraulicCalc
{	
	/// <summary>
	/// Main form for Hydraulic Calculator.
	/// </summary>
	public class frmHydCalc : System.Windows.Forms.Form
	{
		/// <summary>
		/// current version of software
		/// </summary>
		public string _version = Application.ProductVersion;
		/// <summary>
		/// today
		/// </summary>
		public string _today = "July 2, 2012";

		private System.Windows.Forms.Label lblFlow;
		private System.Windows.Forms.TextBox txtFlow;
		private System.Windows.Forms.ComboBox cboFlowUnit;
		private System.Windows.Forms.ComboBox cboDepthUnit;
		private System.Windows.Forms.TextBox txtDepth;
		private System.Windows.Forms.Label lblDepth;
		private System.Windows.Forms.ComboBox cboDiameterUnit;
		private System.Windows.Forms.TextBox txtDiameter;
		private System.Windows.Forms.Label lblDiameter;
		private System.Windows.Forms.ComboBox cboSlopeUnit;
		private System.Windows.Forms.TextBox txtSlope;
		private System.Windows.Forms.Label lblSlope;
		private System.Windows.Forms.TextBox txtNValue;
		private System.Windows.Forms.Label lblNValue;
		private System.Windows.Forms.ComboBox cboVelocityUnit;
		private System.Windows.Forms.TextBox txtVelocity;
		private System.Windows.Forms.Label lblVelocity;
		private System.Windows.Forms.Button cmdCalculate;
		private System.Windows.Forms.GroupBox grpCalculate;
		private System.Windows.Forms.RadioButton rdoFlow;
		private System.Windows.Forms.RadioButton rdoDepth;
		private System.Windows.Forms.RadioButton rdoQVA;
		private System.Windows.Forms.RadioButton rdoVQA;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem itmExit;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem itmAbout;
		private System.Windows.Forms.MenuItem itmSave;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolTip toolTip;

		private System.ComponentModel.IContainer components;

		public frmHydCalc()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			rdoFlow.Checked = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHydCalc));
            this.lblFlow = new System.Windows.Forms.Label();
            this.txtFlow = new System.Windows.Forms.TextBox();
            this.cboFlowUnit = new System.Windows.Forms.ComboBox();
            this.cboDepthUnit = new System.Windows.Forms.ComboBox();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.lblDepth = new System.Windows.Forms.Label();
            this.cboDiameterUnit = new System.Windows.Forms.ComboBox();
            this.txtDiameter = new System.Windows.Forms.TextBox();
            this.lblDiameter = new System.Windows.Forms.Label();
            this.cboSlopeUnit = new System.Windows.Forms.ComboBox();
            this.txtSlope = new System.Windows.Forms.TextBox();
            this.lblSlope = new System.Windows.Forms.Label();
            this.txtNValue = new System.Windows.Forms.TextBox();
            this.lblNValue = new System.Windows.Forms.Label();
            this.cboVelocityUnit = new System.Windows.Forms.ComboBox();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.cmdCalculate = new System.Windows.Forms.Button();
            this.grpCalculate = new System.Windows.Forms.GroupBox();
            this.rdoVQA = new System.Windows.Forms.RadioButton();
            this.rdoDepth = new System.Windows.Forms.RadioButton();
            this.rdoFlow = new System.Windows.Forms.RadioButton();
            this.rdoQVA = new System.Windows.Forms.RadioButton();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.itmSave = new System.Windows.Forms.MenuItem();
            this.itmExit = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.itmAbout = new System.Windows.Forms.MenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpCalculate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFlow
            // 
            this.lblFlow.Location = new System.Drawing.Point(15, 60);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(40, 20);
            this.lblFlow.TabIndex = 0;
            this.lblFlow.Text = "Flow :";
            // 
            // txtFlow
            // 
            this.txtFlow.Enabled = false;
            this.txtFlow.Location = new System.Drawing.Point(65, 60);
            this.txtFlow.MaxLength = 10;
            this.txtFlow.Name = "txtFlow";
            this.txtFlow.Size = new System.Drawing.Size(100, 20);
            this.txtFlow.TabIndex = 1;
            this.txtFlow.Text = "0.0";
            this.toolTip.SetToolTip(this.txtFlow, "Flow");
            this.txtFlow.TextChanged += new System.EventHandler(this.txtFlow_TextChanged);
            // 
            // cboFlowUnit
            // 
            this.cboFlowUnit.Items.AddRange(new object[] {
            "mgd",
            "gpm",
            "gpd",
            "cfs",
            "cms",
            "lps"});
            this.cboFlowUnit.Location = new System.Drawing.Point(170, 60);
            this.cboFlowUnit.Name = "cboFlowUnit";
            this.cboFlowUnit.Size = new System.Drawing.Size(70, 21);
            this.cboFlowUnit.TabIndex = 2;
            this.cboFlowUnit.Text = "mgd";
            this.toolTip.SetToolTip(this.cboFlowUnit, "Units for Flow");
            this.cboFlowUnit.SelectedValueChanged += new System.EventHandler(this.cboFlowUnit_SelectedValueChanged);
            // 
            // cboDepthUnit
            // 
            this.cboDepthUnit.Items.AddRange(new object[] {
            "inch",
            "ft",
            "m",
            "cm",
            "mm"});
            this.cboDepthUnit.Location = new System.Drawing.Point(170, 90);
            this.cboDepthUnit.Name = "cboDepthUnit";
            this.cboDepthUnit.Size = new System.Drawing.Size(70, 21);
            this.cboDepthUnit.TabIndex = 5;
            this.cboDepthUnit.Text = "inch";
            this.toolTip.SetToolTip(this.cboDepthUnit, "Units for Depth");
            this.cboDepthUnit.SelectedValueChanged += new System.EventHandler(this.cboDepthUnit_SelectedValueChanged);
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(65, 90);
            this.txtDepth.MaxLength = 10;
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(100, 20);
            this.txtDepth.TabIndex = 4;
            this.toolTip.SetToolTip(this.txtDepth, "Depth");
            this.txtDepth.TextChanged += new System.EventHandler(this.txtDepth_TextChanged);
            // 
            // lblDepth
            // 
            this.lblDepth.Location = new System.Drawing.Point(15, 90);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(46, 20);
            this.lblDepth.TabIndex = 3;
            this.lblDepth.Text = "Depth :";
            // 
            // cboDiameterUnit
            // 
            this.cboDiameterUnit.Items.AddRange(new object[] {
            "inch",
            "ft",
            "m",
            "cm",
            "mm"});
            this.cboDiameterUnit.Location = new System.Drawing.Point(170, 150);
            this.cboDiameterUnit.Name = "cboDiameterUnit";
            this.cboDiameterUnit.Size = new System.Drawing.Size(70, 21);
            this.cboDiameterUnit.TabIndex = 11;
            this.cboDiameterUnit.Text = "inch";
            this.toolTip.SetToolTip(this.cboDiameterUnit, "Units for Diameter");
            this.cboDiameterUnit.SelectedValueChanged += new System.EventHandler(this.cboDiameterUnit_SelectedValueChanged);
            // 
            // txtDiameter
            // 
            this.txtDiameter.Location = new System.Drawing.Point(65, 150);
            this.txtDiameter.MaxLength = 10;
            this.txtDiameter.Name = "txtDiameter";
            this.txtDiameter.Size = new System.Drawing.Size(100, 20);
            this.txtDiameter.TabIndex = 10;
            this.toolTip.SetToolTip(this.txtDiameter, "Pipe Diameter");
            this.txtDiameter.TextChanged += new System.EventHandler(this.txtDiameter_TextChanged);
            // 
            // lblDiameter
            // 
            this.lblDiameter.Location = new System.Drawing.Point(15, 150);
            this.lblDiameter.Name = "lblDiameter";
            this.lblDiameter.Size = new System.Drawing.Size(57, 20);
            this.lblDiameter.TabIndex = 9;
            this.lblDiameter.Text = "Diameter :";
            // 
            // cboSlopeUnit
            // 
            this.cboSlopeUnit.Items.AddRange(new object[] {
            "ft/ft",
            "%",
            "m/m"});
            this.cboSlopeUnit.Location = new System.Drawing.Point(170, 180);
            this.cboSlopeUnit.Name = "cboSlopeUnit";
            this.cboSlopeUnit.Size = new System.Drawing.Size(70, 21);
            this.cboSlopeUnit.TabIndex = 14;
            this.cboSlopeUnit.Text = "ft/ft";
            this.toolTip.SetToolTip(this.cboSlopeUnit, "Units for Slope");
            this.cboSlopeUnit.SelectedValueChanged += new System.EventHandler(this.cboSlopeUnit_SelectedValueChanged);
            // 
            // txtSlope
            // 
            this.txtSlope.Location = new System.Drawing.Point(65, 180);
            this.txtSlope.MaxLength = 10;
            this.txtSlope.Name = "txtSlope";
            this.txtSlope.Size = new System.Drawing.Size(100, 20);
            this.txtSlope.TabIndex = 13;
            this.toolTip.SetToolTip(this.txtSlope, "Slope");
            this.txtSlope.TextChanged += new System.EventHandler(this.txtSlope_TextChanged);
            // 
            // lblSlope
            // 
            this.lblSlope.Location = new System.Drawing.Point(15, 180);
            this.lblSlope.Name = "lblSlope";
            this.lblSlope.Size = new System.Drawing.Size(40, 23);
            this.lblSlope.TabIndex = 12;
            this.lblSlope.Text = "Slope :";
            // 
            // txtNValue
            // 
            this.txtNValue.Location = new System.Drawing.Point(65, 210);
            this.txtNValue.MaxLength = 6;
            this.txtNValue.Name = "txtNValue";
            this.txtNValue.Size = new System.Drawing.Size(100, 20);
            this.txtNValue.TabIndex = 16;
            this.txtNValue.Text = "0.013";
            this.toolTip.SetToolTip(this.txtNValue, "Manning\'s N-Value");
            this.txtNValue.TextChanged += new System.EventHandler(this.txtNValue_TextChanged);
            // 
            // lblNValue
            // 
            this.lblNValue.Location = new System.Drawing.Point(15, 210);
            this.lblNValue.Name = "lblNValue";
            this.lblNValue.Size = new System.Drawing.Size(57, 20);
            this.lblNValue.TabIndex = 15;
            this.lblNValue.Text = "N Value :";
            // 
            // cboVelocityUnit
            // 
            this.cboVelocityUnit.Items.AddRange(new object[] {
            "fps",
            "mps"});
            this.cboVelocityUnit.Location = new System.Drawing.Point(170, 120);
            this.cboVelocityUnit.Name = "cboVelocityUnit";
            this.cboVelocityUnit.Size = new System.Drawing.Size(70, 21);
            this.cboVelocityUnit.TabIndex = 8;
            this.cboVelocityUnit.Text = "fps";
            this.toolTip.SetToolTip(this.cboVelocityUnit, "Units for Velocity");
            this.cboVelocityUnit.SelectedValueChanged += new System.EventHandler(this.cboVelocityUnit_SelectedValueChanged);
            // 
            // txtVelocity
            // 
            this.txtVelocity.Enabled = false;
            this.txtVelocity.Location = new System.Drawing.Point(65, 120);
            this.txtVelocity.MaxLength = 10;
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(100, 20);
            this.txtVelocity.TabIndex = 7;
            this.txtVelocity.Text = "0.0";
            this.toolTip.SetToolTip(this.txtVelocity, "Velocity");
            this.txtVelocity.TextChanged += new System.EventHandler(this.txtVelocity_TextChanged);
            // 
            // lblVelocity
            // 
            this.lblVelocity.Location = new System.Drawing.Point(15, 120);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(56, 20);
            this.lblVelocity.TabIndex = 6;
            this.lblVelocity.Text = "Velocity :";
            // 
            // cmdCalculate
            // 
            this.cmdCalculate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCalculate.Location = new System.Drawing.Point(93, 241);
            this.cmdCalculate.Name = "cmdCalculate";
            this.cmdCalculate.Size = new System.Drawing.Size(75, 23);
            this.cmdCalculate.TabIndex = 17;
            this.cmdCalculate.Text = "Calculate";
            this.toolTip.SetToolTip(this.cmdCalculate, "Calculate Required Values");
            this.cmdCalculate.Click += new System.EventHandler(this.cmdCalculate_Click);
            // 
            // grpCalculate
            // 
            this.grpCalculate.Controls.Add(this.rdoVQA);
            this.grpCalculate.Controls.Add(this.rdoDepth);
            this.grpCalculate.Controls.Add(this.rdoFlow);
            this.grpCalculate.Controls.Add(this.rdoQVA);
            this.grpCalculate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCalculate.Location = new System.Drawing.Point(5, 1);
            this.grpCalculate.Name = "grpCalculate";
            this.grpCalculate.Size = new System.Drawing.Size(245, 50);
            this.grpCalculate.TabIndex = 0;
            this.grpCalculate.TabStop = false;
            this.grpCalculate.Text = "Calculate";
            // 
            // rdoVQA
            // 
            this.rdoVQA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoVQA.Location = new System.Drawing.Point(122, 19);
            this.rdoVQA.Name = "rdoVQA";
            this.rdoVQA.Size = new System.Drawing.Size(53, 24);
            this.rdoVQA.TabIndex = 3;
            this.rdoVQA.TabStop = true;
            this.rdoVQA.Text = "V=Q/A";
            this.toolTip.SetToolTip(this.rdoVQA, "Velocity = Flow / Area");
            this.rdoVQA.CheckedChanged += new System.EventHandler(this.rdoVQA_CheckedChanged);
            // 
            // rdoDepth
            // 
            this.rdoDepth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoDepth.Location = new System.Drawing.Point(183, 19);
            this.rdoDepth.Name = "rdoDepth";
            this.rdoDepth.Size = new System.Drawing.Size(52, 24);
            this.rdoDepth.TabIndex = 2;
            this.rdoDepth.Text = "Depth";
            this.toolTip.SetToolTip(this.rdoDepth, "Use Manning\'s Eq to Calculate Depth");
            this.rdoDepth.CheckedChanged += new System.EventHandler(this.rdoDepth_CheckedChanged);
            // 
            // rdoFlow
            // 
            this.rdoFlow.Checked = true;
            this.rdoFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoFlow.Location = new System.Drawing.Point(10, 19);
            this.rdoFlow.Name = "rdoFlow";
            this.rdoFlow.Size = new System.Drawing.Size(46, 24);
            this.rdoFlow.TabIndex = 0;
            this.rdoFlow.TabStop = true;
            this.rdoFlow.Text = "Flow";
            this.toolTip.SetToolTip(this.rdoFlow, "Use Manning\'s Eq to Calculate Flow");
            this.rdoFlow.CheckedChanged += new System.EventHandler(this.rdoFlow_CheckedChanged);
            // 
            // rdoQVA
            // 
            this.rdoQVA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoQVA.Location = new System.Drawing.Point(62, 19);
            this.rdoQVA.Name = "rdoQVA";
            this.rdoQVA.Size = new System.Drawing.Size(54, 24);
            this.rdoQVA.TabIndex = 1;
            this.rdoQVA.TabStop = true;
            this.rdoQVA.Text = "Q=V*A";
            this.toolTip.SetToolTip(this.rdoQVA, "Flow = Velocity x Area");
            this.rdoQVA.CheckedChanged += new System.EventHandler(this.rdoQVA_CheckedChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 238);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar.Size = new System.Drawing.Size(255, 24);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 18;
            this.statusBar.Text = "Calc: Flow & Vel - Given: Depth, Diam, Slope, & N";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.statusBarPanel1.Text = "statusBarPanel1";
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmSave,
            this.itmExit});
            this.mnuFile.Text = "&File";
            // 
            // itmSave
            // 
            this.itmSave.Index = 0;
            this.itmSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.itmSave.Text = "&Save";
            this.itmSave.Click += new System.EventHandler(this.itmSave_Click);
            // 
            // itmExit
            // 
            this.itmExit.Index = 1;
            this.itmExit.Text = "E&xit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 1;
            this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmAbout});
            this.mnuHelp.Text = "&Help";
            // 
            // itmAbout
            // 
            this.itmAbout.Index = 0;
            this.itmAbout.Text = "About Hydraulic Calculator...";
            this.itmAbout.Click += new System.EventHandler(this.itmAbout_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            this.saveFileDialog.FileName = "ManningCalc.csv";
            this.saveFileDialog.Filter = "CSV Text File (*.csv)|*.csv";
            this.saveFileDialog.Title = "Save data to CSV";
            // 
            // frmHydCalc
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(255, 262);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.grpCalculate);
            this.Controls.Add(this.cmdCalculate);
            this.Controls.Add(this.cboVelocityUnit);
            this.Controls.Add(this.txtVelocity);
            this.Controls.Add(this.txtNValue);
            this.Controls.Add(this.txtSlope);
            this.Controls.Add(this.txtDiameter);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.txtFlow);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.lblNValue);
            this.Controls.Add(this.cboSlopeUnit);
            this.Controls.Add(this.lblSlope);
            this.Controls.Add(this.cboDiameterUnit);
            this.Controls.Add(this.lblDiameter);
            this.Controls.Add(this.cboDepthUnit);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.cboFlowUnit);
            this.Controls.Add(this.lblFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHydCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hydraulic Calculator";
            this.DoubleClick += new System.EventHandler(this.frmHydCalc_DoubleClick);
            this.grpCalculate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new frmHydCalc());
		}

		///<summary>
		///Uses Mannings equation to calculate required field
		///</summary>
		///<remarks>
		///Depending on radio buttons and inputed 
		///information will calculate required fields
		///in the requested units.
		///</remarks>
		private void cmdCalculate_Click(object sender, System.EventArgs e)
		{
            Calculate();
        }
        public void Calculate()
        {
			Pipe newPipe = new Pipe();
			HydConversion conversion = new HydConversion();

			try
			{
				this.Cursor = Cursors.WaitCursor;

				//Save values from form
				newPipe.Flow = double.Parse(txtFlow.Text);
				newPipe.Depth = double.Parse(txtDepth.Text);
				newPipe.Diameter = double.Parse(txtDiameter.Text);
				newPipe.Velocity = double.Parse(txtVelocity.Text);
				newPipe.Slope = double.Parse(txtSlope.Text);
				newPipe.Nvalue = double.Parse(txtNValue.Text);

				//Convert units to cfs, feet, fps, and ft/ft as needed
				newPipe.Flow = newPipe.Flow * conversion.GetFactor(cboFlowUnit.Text, "cfs");
				newPipe.Depth = newPipe.Depth * conversion.GetFactor(cboDepthUnit.Text, "ft");
				newPipe.Diameter = newPipe.Diameter * conversion.GetFactor(cboDiameterUnit.Text, "ft");
				newPipe.Velocity = newPipe.Velocity * conversion.GetFactor(cboVelocityUnit.Text, "fps");

				if (cboSlopeUnit.Text == "%")
					newPipe.Slope = newPipe.Slope / 100;

				//Determine which fuction to run and convert units as needed
				statusBar.Text = "Calculating...";
				if (rdoFlow.Checked)           //Calculate Flow
				{
					newPipe.QManning();

					//Convert units as needed
					newPipe.Flow = newPipe.Flow * conversion.GetFactor("cfs", cboFlowUnit.Text);
					newPipe.Velocity = newPipe.Velocity * conversion.GetFactor("fps",cboVelocityUnit.Text);
					
					//Update form
					txtFlow.Text = newPipe.Flow.ToString("#,##0.000000");
					txtVelocity.Text = newPipe.Velocity.ToString("#,##0.000000");
				}
				else if (rdoQVA.Checked)
				{
					newPipe.QVA();

					//Convert units as needed
					newPipe.Flow = newPipe.Flow * conversion.GetFactor("cfs", cboFlowUnit.Text);
					
					//Update form
					txtFlow.Text = newPipe.Flow.ToString("#,##0.000000");
				}
				else if (rdoDepth.Checked)       //Calculate Depth
				{
					statusBar.Text = "Calculating... This could take awhile.";

					newPipe.DManning();		

					//Convert units as needed
					newPipe.Depth = newPipe.Depth * conversion.GetFactor("ft", cboDepthUnit.Text);
					newPipe.Velocity = newPipe.Velocity * conversion.GetFactor("fps",cboVelocityUnit.Text);
					
					//Update form
					txtDepth.Text = newPipe.Depth.ToString("#,##0.000000");
					txtVelocity.Text = newPipe.Velocity.ToString("#,##0.000000");
				}
				else if (rdoVQA.Checked)          //Calculate velocity
				{
					newPipe.VQA();

					//Convert units as needed
					newPipe.Velocity = newPipe.Velocity * conversion.GetFactor("fps", cboVelocityUnit.Text);
					
					//Update form
					txtVelocity.Text = newPipe.Velocity.ToString("#,##0.000000");
				}
				this.Cursor = Cursors.Default;
				statusBar.Text = "Completed!";
			}
			catch
			{
				statusBar.Text = " - * -  ERROR  - * -";
				this.Cursor = Cursors.Default;
			}
            newPipe = null;
            conversion = null;
		}

        /// <summary>
        /// Remind user to recalculate if changing units.
        /// </summary>
        /// <remarks>
        /// If value was recently calculated updates status bar to remind 
        /// user to recalculate results.
        /// </remarks> 
        private void cboFlowUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.statusBar.Text == "Completed!")
                this.statusBar.Text = "Please Recalculate";
            Calculate();
        }

        /// <summary>
        /// Remind user to recalculate if changing units.
        /// </summary>
        /// <remarks>
        /// If value was recently calculated updates status bar to remind 
        /// user to recalculate results.
        /// </remarks> 
        private void cboDepthUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.statusBar.Text == "Completed!")
                this.statusBar.Text = "Please Recalculate";
            Calculate();
        }

        /// <summary>
        /// Remind user to recalculate if changing units.
        /// </summary>
        /// <remarks>
        /// If value was recently calculated updates status bar to remind 
        /// user to recalculate results.
        /// </remarks> 
        private void cboVelocityUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.statusBar.Text == "Completed!")
                this.statusBar.Text = "Please Recalculate";
            Calculate();
        }

        /// <summary>
        /// Remind user to recalculate if changing units.
        /// </summary>
        /// <remarks>
        /// If value was recently calculated updates status bar to remind 
        /// user to recalculate results.
        /// </remarks> 
        private void cboDiameterUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.statusBar.Text == "Completed!")
                this.statusBar.Text = "Please Recalculate";
            Calculate();
        }

        /// <summary>
        /// Remind user to recalculate if changing units.
        /// </summary>
        /// <remarks>
        /// If value was recently calculated updates status bar to remind 
        /// user to recalculate results.
        /// </remarks> 
        private void cboSlopeUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.statusBar.Text == "Completed!")
                this.statusBar.Text = "Please Recalculate";
            Calculate();
        }

		/// <summary>
		/// Grey out Depth field and clear up Flow field
		/// </summary>
		/// <remarks>
		/// Allows user to input data into Flow field and
		/// Keeps the user from inputing data into the Depth
		/// or Velocity fields, which will be calculated.
		/// </remarks> 
		private void rdoDepth_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdoDepth.Checked)
			{
				txtDepth.Enabled = false;
				txtDepth.Text = "0.0";
				txtVelocity.Enabled = false;
				txtVelocity.Text = "0.0";
				txtFlow.Enabled = true;
				txtSlope.Enabled = true;
				txtNValue.Enabled = true;
				statusBar.Text = "Calc: Depth & Vel - Given: Flow, Diam, Slope, & N";
                Calculate();
			}
		}

		/// <summary>
		/// Grey out Flow field and clear up Depth field
		/// </summary>
		/// <remarks>
		/// Allows user to input data into Depth field and
		/// Keeps the user from inputing data into the Flow
		/// or Velocity fields, which will be calculated.
		/// </remarks>
		private void rdoFlow_CheckedChanged(object sender, System.EventArgs e)
		{		
			if (rdoFlow.Checked)
			{
				txtFlow.Enabled = false;
				txtFlow.Text = "0.0";
				txtVelocity.Enabled = false;
				txtVelocity.Text = "0.0";
				txtDepth.Enabled = true;
				txtSlope.Enabled = true;
				txtNValue.Enabled = true;
				statusBar.Text = "Calc: Flow & Vel - Given: Depth, Diam, Slope, & N";
                Calculate();
			}
		}

        /// <summary>
		/// Grey out Flow field and clear up Depth field
		/// </summary>
		/// <remarks>
		/// Allows user to input data into Velocity field and Depth field and
		/// Keeps the user from inputing data into the Flow,
		/// Slopw, NValue, or Velocity fields, which will be calculated.
		/// </remarks>
		private void rdoQVA_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdoQVA.Checked)
			{
				txtFlow.Enabled = false;
				txtFlow.Text = "0.0";
				txtSlope.Enabled = false;
				txtSlope.Text = "0.0";
				txtNValue.Enabled = false;
				txtNValue.Text = "0.013";
				txtVelocity.Enabled = true;
				txtDepth.Enabled = true;
				statusBar.Text = "Calc: Flow - Given: Depth, Vel, & Diam";
                Calculate();
			}
		}

        /// <summary>
		/// Grey out Velocity field and clear up Depth and Flow field
		/// </summary>
		/// <remarks>
		/// Allows user to input data into Flow and Depth field and
		/// Keeps the user from inputing data into the Velocity,
		/// Slopw, or NValue fields, which will be calculated.
		/// </remarks>
        private void rdoVQA_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoVQA.Checked)
			{
				txtFlow.Enabled = true;
				txtSlope.Enabled = false;
				txtSlope.Text = "0.0";
				txtNValue.Enabled = false;
				txtNValue.Text = "0.013";
				txtVelocity.Enabled = false;
				txtVelocity.Text = "0.0";
				txtDepth.Enabled = true;
				statusBar.Text = "Calc: Vel - Given: Flow, Depth, & Diam";
                Calculate();
			}
		}

        /// <summary>
		/// Adds Main Menu to form.
		/// </summary>
		/// <remarks>
		/// Allows user to save data to csv file or see the about box.
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmHydCalc_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.Menu == null)
			{
				this.Menu = this.mnuMain;
				this.Height = this.Height + 20;
				}
			else
			{
				this.Menu = null;
				this.Height = this.Height - 20;
			}
		}
		
		#region Menu Code
		/// <summary>
		/// Exit form and code
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void itmExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// About message box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void itmAbout_Click(object sender, System.EventArgs e)
		{
			string SoftwareVersion = _version;
			string SoftwareDate = _today;

			MessageBox.Show(" Hydraulic Calculator  v" + SoftwareVersion + 
				"\n\n Created by: Matthew J. Wedeking\n\n           " + SoftwareDate,	
				"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Save message box
		/// </summary>
		/// <remarks>
		/// Saves data in form to a CSV file
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void itmSave_Click(object sender, System.EventArgs e)
		{
			string outputFile;

			// Display the openFile dialog.
			DialogResult result = saveFileDialog.ShowDialog();

			// OK button was pressed.
			if(result == DialogResult.OK) 
			{
				outputFile = saveFileDialog.FileName;
				StreamWriter output = new StreamWriter(outputFile);
				output.Write(GetHeader());
				output.Write("\r\n");
				output.Write(GetData());
				output.Close();

				statusBar.Text = "Saved";
			}

				// Cancel button was pressed.
			else if(result == DialogResult.Cancel) 
			{
				statusBar.Text = "";
				return;
			}
		}

		/// <summary>
		/// Creates Header row for CSV export.
		/// </summary>
		/// <returns></returns>
		private string GetHeader()
		{
			string header;

			header = "Flow " + cboFlowUnit.Text + ", ";
			header = header + "Depth " + cboDepthUnit.Text + ", ";
			header = header + "Velocity " + cboVelocityUnit.Text + ", ";
			header = header + "Diameter " + cboDiameterUnit.Text + ", ";
			header = header + "Slope " + cboSlopeUnit.Text + ", ";
			header = header + "NValue";

			return header;
		}

		/// <summary>
		/// Creates Data row for CSV export.
		/// </summary>
		/// <returns></returns>
		private string GetData()
		{
			string data;
			data = txtFlow.Text + ", ";
			data = data + txtDepth.Text + ", ";
			data = data + txtVelocity.Text + ", ";
			data = data + txtDiameter.Text + ", ";
			data = data + txtSlope.Text + ", ";
			data = data + txtNValue.Text;

			return data;
		}
		#endregion

        private void txtFlow_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtDepth_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtVelocity_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtDiameter_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSlope_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtNValue_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
	}
}