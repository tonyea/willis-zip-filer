using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace WillisZipFiler
{
    public partial class rbnFiler
    {
        Outlook.Inspector m_Inspector;
        static Outlook.MailItem m_Item;
        private void rbnFiler_Load(object sender, RibbonUIEventArgs e)
        {
            m_Inspector = (Outlook.Inspector)this.Context;
            m_Item = m_Inspector.CurrentItem as Outlook.MailItem;
        }

        private void cmdZipFiler_Click(object sender, RibbonControlEventArgs e)
        {
            if ((IsMailItem()) && (IsSpecFolder()) && (IsNoFlagComp())) 
            {
                ZipFiler.ShowDialog();
            }
        }

        //Test to see if item is a mail item
        public bool IsMailItem() 
        {
            if (m_Item is Outlook.MailItem)
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                return true;
            }
            return false;
        }

        //Test to see if item is in inbox or sent items
        public bool IsSpecFolder()
        {
            if ((m_Item.Parent.Name == "Inbox") || (m_Item.Parent.Name == "Sent Items")) 
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                return true;
            }
            return false;
        }

        //Test to see if item is already efiled by being marked complete
        public bool IsNoFlagComp()
        {
            if (m_Item.FlagStatus != Outlook.OlFlagStatus.olFlagComplete)
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                return true;
            }
            return false;
        }

        /*
         * The Singleton Pattern
         * 
         * Below lines of code will first create a variable _claims
         * Then we will create a property that will reference a new instance of frmClaims
         * or a previously existing one, this instance will be assigned to the variable _claims
         * We do this because if we use the following code in cmdClaims_click, 
         * then we will get multiple instances of the same form
         *      //frmClaims c = new frmClaims();
         *      c.ShowDialog();//
         * 
         * We should also be able to create a function for the below so that we don't have to copy
         * past the same code for different forms
         * 
         * For some reason, the same form is kept in memory even if we press the close button 
         * instead of the hide button
         */
        private static frmZipFiler _claims;
        public static frmZipFiler ZipFiler
        {
            get
            {
                if (_claims == null)
                {
                    // create new instance of the form since it is currently null
                    _claims = new frmZipFiler();
                }
                // pass the current email item to the form
                frmZipFiler.getMailItem(m_Item);
                // return the form to the caller
                return _claims;
            }
        }

        private void cmdDC_Click(object sender, RibbonControlEventArgs e)
        {
            if ((IsMailItem()) && (IsSpecFolder()) && (IsNoFlagComp()))
            {
                System.Windows.Forms.MessageBox.Show("3Test");
            }
        }

        private void rbnFiler_Close(object sender, EventArgs e)
        {
            // to create destructors, disposers here
        }

    }
}
