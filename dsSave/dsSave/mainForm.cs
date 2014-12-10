using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsSave
{
    public partial class mainForm : Form
    {
        private SaveMgr saveMan;
        private string currentDirectory;

        /// <summary>
        /// //////////////
        /// </summary>
        private RealSaveManager realSaveManager; 

        public mainForm()
        {
            InitializeComponent();
            saveMan = new SaveMgr(lblDisplay, lblTimestamp);
            saveMan.checkForSavePath();
            //TODO Set a cookie so that on program load it will always remember what directory you were last viewing
            saveMan.refreshSavedGames(lstBoxSavedGames);
            createContextMenu();
        }

        private void btnQuickSave_Click(object sender, EventArgs e)
        {
            saveMan.quickSaveClick();
            saveMan.refreshSavedGames(lstBoxSavedGames, saveMan.dsQuickSaveDir);
            enableDisableButtons();
        }

        private void btnLoadQuickSave_Click(object sender, EventArgs e)
        {
            saveMan.loadQuicksaveClick();
            saveMan.refreshSavedGames(lstBoxSavedGames);
            enableDisableButtons();
        }
        
        private void saveCustom_Click(object sender, EventArgs e)
        {
            
            if (saveCustomTextBox.Text != "")
            {
                saveMan.saveCustom(saveCustomTextBox.Text);
                saveMan.refreshSavedGames(lstBoxSavedGames, saveMan.dsCustomSaveDir);
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
                saveMan.loadCustomClick(selected);
                saveMan.refreshSavedGames(lstBoxSavedGames);
                enableDisableButtons();
            }
            else
            {
                MessageBox.Show("Please selecte a file");
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
             saveMan.refreshSavedGames(lstBoxSavedGames);
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
            Thread.Sleep(1500);
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
            saveMan.deleteSelectedSave(selected);
            saveMan.refreshSavedGames(lstBoxSavedGames);
        }

        private void enterSaveDIrectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveMan.firstRun();
            saveMan.checkForSavePath();
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
            saveMan.refreshSavedGames(lstBoxSavedGames, saveMan.dsQuickSaveDir);
        }

        private void btnCustomSaves_Click(object sender, EventArgs e)
        {
            saveMan.refreshSavedGames(lstBoxSavedGames, saveMan.dsCustomSaveDir);

        }

        private void btnAutoSaves_Click(object sender, EventArgs e)
        {
            saveMan.refreshSavedGames(lstBoxSavedGames, saveMan.dsAutoSaveDir);

        }

        private void setCurrentDir(string currentDir)
        {
            currentDirectory = currentDir;
        }

 
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    
}
