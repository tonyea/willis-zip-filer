using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;

namespace WillisZipFiler
{
    public partial class frmZipFiler : Form
    {
        Excel.Application xlApp;
        Excel.Workbook wkbk;
        string claimsXL = "C:\\Claims\\Claims WOL.xlsx";
        string claimsNameOnly = "Claims WOL.xlsx";
        int countClaims;
        Excel.Worksheet sheetOne;

        public frmZipFiler()
        {
            InitializeComponent();
            // setthing the txtLink text box to read only
            this.txtLink.ReadOnly= true;
            this.txtLink.Text = "If it exists, the claim folder link will appear here when you move away from the eGlobal field";
        }

        // creating a variable m_item that will receive the current mail item object from the ribbon
        // when the getMailItem function is called
        private static Outlook.MailItem m_Item;
        public static void getMailItem(Outlook.MailItem currEmail)
        {
            m_Item = currEmail;
        }

        private void txteGlobal_Leave(object sender, EventArgs e)
        {
            string eGlobal;
            string strEGlob;

            eGlobal = txteGlobal.Text.Trim();

            // if wkbk is not set try setting it, if still unable then raise an error and exit the function
            if (wkbk == null)
            {
                try
                {
                    setExcelApp();
                }
                catch
                {
                    MessageBox.Show("Unable to connect to excel sheet, program will not function.");
                    return;
                }
            }

            int i;
            if (eGlobal != "")
            {
                for (i = 2; i < countClaims; i++)
                {
                    if (sheetOne.UsedRange.Cells[i, "H"].Value2 != null)
                    {
                        strEGlob = sheetOne.UsedRange.Cells[i, "H"].Value2.ToString();
                        if ((strEGlob.IndexOf(eGlobal)) >= 0)
                        {
                            break;
                        }
                    }
                }
                strEGlob = sheetOne.UsedRange.Cells[i, "H"].Value2.ToString();
                if ((strEGlob.IndexOf(eGlobal)) >= 0)
                {
                    txtLink.Text = sheetOne.UsedRange.Cells[i, "AV"].Value2;
                }
                else txtLink.Text = "Claim not found";
            }
        }

        private void setExcelApp()
        {
            xlApp = null;
            try
            {
                xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                xlApp = new Excel.Application();
                xlApp.Visible = true;
            }

            // if the claims file is already open then it will be pulled into wkbk, otherwise it will be opened
            wkbk = null;
            foreach (Excel.Workbook WB in xlApp.Workbooks)
            {
                // all this stuff is to isolate the file name of the currently running workbooks.
                string strWB = WB.FullName.ToString();
                int slashPos = strWB.LastIndexOf("\\");
                strWB = strWB.Substring(slashPos + 1);
                if (strWB == claimsNameOnly)
                {
                    wkbk = WB;
                    //MessageBox.Show("Test success");
                }
            }
            if (wkbk == null)
            {
                // in case file is not already open
                wkbk = xlApp.Workbooks.Open(claimsXL);
                // attempting to refresh the excel sheet
                try
                {
                    wkbk.RefreshAll();
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("Program was unable to refresh the excel sheet, please do so manually");
                }
            }

            // activating the workbook for use
            // below code is extended from wkbk.activate due to ambiguity
            ((Excel._Workbook)wkbk).Activate();

            // assigning the worksheet for use
            sheetOne = wkbk.ActiveSheet;

            // counting number of rows for use in another part of program
            countClaims = sheetOne.UsedRange.Rows.Count;
            // for testing purpose: MessageBox.Show(countClaims.ToString());
        }


        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            //to make sure that the program doesnt find the first empty eglobal field and populate
            if (txteGlobal.Text == "")
            {
                txtLink.Text = "Please enter an eGlobal #";
                txteGlobal.Focus();
                return;
            }

            // making sure that the user does not put anything in the description that will invalidate the file name
            if (!validFileName(txtDesc))
            {
                return;
            }

            string claimPath = txtLink.Text.ToString();
            // for testing MessageBox.Show(claimPath + System.IO.Directory.Exists(claimPath).ToString());
            if (!(System.IO.Directory.Exists(claimPath))) 
            {
                MessageBox.Show("Claim link not found or doesn't exist");
                return;            
            }

            if (cmbMailType.Text == "")
            {
                MessageBox.Show("Please enter the Mail Type");
                cmbMailType.Focus();
                return;
            }

            DateTime dt;
            string dtYear, dtMonth, dtDay, dtHour, dtMin;
            
            dt = m_Item.ReceivedTime;
            dtYear = dt.Year.ToString();
            dtYear = dtYear.Substring(2);
            dtMonth = dt.Month.ToString();
            if (dtMonth.Length < 2) 
            {
                dtMonth = "0" + dtMonth;
            }
            dtDay = dt.Day.ToString();
            if (dtDay.Length < 2)
            {
                dtDay = "0" + dtDay;
            }
            dtHour = dt.Hour.ToString();
            if (dtHour.Length < 2)
            {
                dtHour = "0" + dtHour;
            }
            dtMin = dt.Minute.ToString();
            if (dtMin.Length < 2)
            {
                dtMin = "0" + dtMin;
            }

            // when creating the filname there will be a space if there is desc and no space if there is no desc
            string buffer;
            if (txtDesc.Text == "")
            {
                buffer = "";
            }
            else buffer = " ";

            // create the correspondence folder if it doesn't exist
            if (!System.IO.Directory.Exists(claimPath + "\\Correspondence\\"))
            {
                System.IO.Directory.CreateDirectory(claimPath + "\\Correspondence\\");
            }

            string flName = claimPath + "\\Correspondence\\" + dtYear + dtMonth + dtDay +
                            " " + dtHour + dtMin + " " + cmbMailType.Text + buffer + txtDesc.Text +".msg";
            // for testing MessageBox.Show(flName);
            if (System.IO.Directory.Exists(flName))
            {
                MessageBox.Show("File Already Exists");
            }
            else
            {
                m_Item.SaveAs(flName, Outlook.OlSaveAsType.olMSG);
                m_Item.FlagStatus = Outlook.OlFlagStatus.olFlagComplete;
                m_Item.Save();
                MessageBox.Show("Email Saved");

            }

            // unsetting the mail item object
            m_Item = null;
            this.Hide();
        }

        private bool validFileName(TextBox t)
        {
            string s = t.Text;
            string qts = "" + (char)34;
            string[] bad = { "\\", "/", ":", "*", "?", "<", ">", "|", qts };
            foreach (string badS in bad)
            {
                if (s.IndexOf(badS) >= 0)
                {
                    MessageBox.Show("Filename cannot contain following characters: \\/:*?\"|");
                    t.Focus();
                    return false;
                }
            }
            return true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            //if (wkbk != null)
            //{
            //    // save and close the file
            //    wkbk.Close(true, claimsXL, null);
            //}
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(wkbk);
        }

        private void frmZipFiler_Load(object sender, EventArgs e)
        {
            setExcelApp();

            // adding mail type items to the mail type combo
            string[] mType = { "", "EIC", "EOC", "EILA", "EOLA", "EII", "EOI", "EW" };
            cmbMailType.DataSource = mType;
        }

        private void cmbMailType_Leave(object sender, EventArgs e)
        {
            // if anything other than available items are typed the validation will not occur
            if (!(cmbMailType.SelectedIndex > -1))
            {
                cmbMailType.Text = "";
                cmbMailType.Focus();
            }
        }
    }
}
