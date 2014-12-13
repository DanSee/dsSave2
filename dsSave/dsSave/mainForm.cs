using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace dsSave
{
    public partial class mainForm : Form
    {
        private RealSaveManager rSM; 

        public mainForm()
        {
            InitializeComponent();
            rSM = new RealSaveManager();
            rSM.checkForSavePath();
             refreshSavedGames(lstBoxSavedGames);
            createContextMenu();
        }

        private void btnQuickSave_Click(object sender, EventArgs e)
        {
            printLabel("Quick Save", rSM.quickSaveClick());
             refreshSavedGames(lstBoxSavedGames, rSM.dsQuickSaveDir);
            enableDisableButtons();
        }

        private void btnLoadQuickSave_Click(object sender, EventArgs e)
        {
            printLabel( "Quick Load", rSM.loadQuickSaveClick());
             refreshSavedGames(lstBoxSavedGames);
            enableDisableButtons();
        }
        
        private void saveCustom_Click(object sender, EventArgs e)
        {
            if (saveCustomTextBox.Text != "")
            {
                 printLabel("Custom Save", rSM.customSaveClick(saveCustomTextBox.Text));
                 refreshSavedGames(lstBoxSavedGames, rSM.dsCustomSaveDir);
                enableDisableButtons();
            }
            else
            {
                MessageBox.Show("Please enter a name for the game save.");
            }
        }

        private void btnLoadCustom_Click(object sender, EventArgs e)
        {
            string selected = lstBoxSavedGames.GetItemText(lstBoxSavedGames.SelectedItem);
            if (selected != "")
            {
                printLabel("Custom Load", rSM.loadCSClick(selected));
                 refreshSavedGames(lstBoxSavedGames);
                enableDisableButtons();
            }
            else
            {
                MessageBox.Show("Please selecte a file");
            }
            
        }
        
        private void enterSaveDIrectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rSM.firstRun();
             refreshSavedGames(lstBoxSavedGames);

            rSM.checkForSavePath();
        }

        private void lstBoxSavedGames_MouseDown(object sender, MouseEventArgs e)
        {
         if (e.Button == MouseButtons.Right)
            {
                lstBoxSavedGames.SelectedIndex = lstBoxSavedGames.IndexFromPoint(e.X, e.Y);
            }
        }
        private void btnQuickSaves_Click(object sender, EventArgs e)
        {
             refreshSavedGames(lstBoxSavedGames, rSM.dsQuickSaveDir);
        }
        private void btnCustomSaves_Click(object sender, EventArgs e)
        {
             refreshSavedGames(lstBoxSavedGames, rSM.dsCustomSaveDir);

        }
        private void btnAutoSaves_Click(object sender, EventArgs e)
        {
             refreshSavedGames(lstBoxSavedGames, rSM.dsAutoSaveDir);

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
             refreshSavedGames(lstBoxSavedGames);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");

        }
        private void printLabel(string text, bool success)
        {

            lblTimestamp.ForeColor = success ? Color.Lime : Color.Red;
            lblDisplay.Text = text;
            lblTimestamp.Text = Utils.getTimestamp("HH:mm:ss");

        }

        private void enableButtons(bool condition)
        {
            btnQuickSave.Enabled = condition;
            saveCustom.Enabled = condition;
            btnLoadCustom.Enabled = condition;
            btnLoadQuickSave.Enabled = condition;
            btnRefresh.Enabled = condition;
        }

        private void enableDisableButtons()
        {
            enableButtons(false);
            Thread.Sleep(1100);
            enableButtons(true);
        }

        private void createContextMenu()
        {
            MenuItem delete = new MenuItem();
            delete.Click += new EventHandler(deleteSelectedSave);
            delete.Text = "DELETE";

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(delete);
            lstBoxSavedGames.ContextMenu = cm;
        }
        private void deleteSelectedSave(object sender, System.EventArgs e)
        {
            string selected = lstBoxSavedGames.GetItemText(lstBoxSavedGames.SelectedItem);
            rSM.deleteSelectedSave(selected);
             refreshSavedGames(lstBoxSavedGames);
        }


        public void refreshSavedGames(ListBox lstBoxSavedGames, string currentDirectory)
        {
             rSM.getSaveDirRefs();
            lstBoxSavedGames.Items.Clear();

            if (Directory.Exists(currentDirectory))
            {
                DirectoryInfo info = new DirectoryInfo(currentDirectory);
                FileInfo[] files = info.GetFiles();

                foreach (FileInfo f in files)
                {
                    lstBoxSavedGames.Items.Add(f.Name);
                }

                 rSM.setCurrentlyViewedDirectory(currentDirectory);
            }
            else
            {
                lstBoxSavedGames.Items.Add("Nothing to show for this directory.");
            }
        }

        public void refreshSavedGames(ListBox lstBoxSavedGames)
        {
             rSM.getSaveDirRefs();
            lstBoxSavedGames.Items.Clear();

            if (Directory.Exists( rSM.currentlyViewedDirectory))
            {
                DirectoryInfo info = new DirectoryInfo( rSM.currentlyViewedDirectory);
                FileInfo[] files = info.GetFiles();

                foreach (FileInfo f in files)
                {
                    lstBoxSavedGames.Items.Add(f.Name);
                }
            }
            else
            {
                lstBoxSavedGames.Items.Add("Nothing to show for this directory.");
            }
        }
    }
    
}
