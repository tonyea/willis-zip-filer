namespace WillisZipFiler
{
    partial class rbnFiler : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public rbnFiler()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbFiler = this.Factory.CreateRibbonTab();
            this.grpFilers = this.Factory.CreateRibbonGroup();
            this.cmdZipFiler = this.Factory.CreateRibbonButton();
            this.cmdDC = this.Factory.CreateRibbonButton();
            this.tbFiler.SuspendLayout();
            this.grpFilers.SuspendLayout();
            // 
            // tbFiler
            // 
            this.tbFiler.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tbFiler.Groups.Add(this.grpFilers);
            this.tbFiler.Label = "Willis eFiler";
            this.tbFiler.Name = "tbFiler";
            // 
            // grpFilers
            // 
            this.grpFilers.Items.Add(this.cmdZipFiler);
            this.grpFilers.Items.Add(this.cmdDC);
            this.grpFilers.KeyTip = "Z";
            this.grpFilers.Label = "Filer";
            this.grpFilers.Name = "grpFilers";
            // 
            // cmdZipFiler
            // 
            this.cmdZipFiler.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.cmdZipFiler.Image = global::WillisZipFiler.Properties.Resources.ZipFiler;
            this.cmdZipFiler.Label = "ZipFiler";
            this.cmdZipFiler.Name = "cmdZipFiler";
            this.cmdZipFiler.ShowImage = true;
            this.cmdZipFiler.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cmdZipFiler_Click);
            // 
            // cmdDC
            // 
            this.cmdDC.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.cmdDC.Image = global::WillisZipFiler.Properties.Resources.DC;
            this.cmdDC.Label = "DC";
            this.cmdDC.Name = "cmdDC";
            this.cmdDC.ShowImage = true;
            this.cmdDC.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cmdDC_Click);
            // 
            // rbnFiler
            // 
            this.Name = "rbnFiler";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tbFiler);
            this.Close += new System.EventHandler(this.rbnFiler_Close);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.rbnFiler_Load);
            this.tbFiler.ResumeLayout(false);
            this.tbFiler.PerformLayout();
            this.grpFilers.ResumeLayout(false);
            this.grpFilers.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tbFiler;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpFilers;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton cmdZipFiler;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton cmdDC;
    }

    partial class ThisRibbonCollection
    {
        internal rbnFiler Ribbon1
        {
            get { return this.GetRibbon<rbnFiler>(); }
        }
    }
}
