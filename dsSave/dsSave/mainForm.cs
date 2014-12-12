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
        private UImanager uiManager;
        private RealSaveManager realSaveManager; 

        public mainForm()
        {
            InitializeComponent();
            uiManager = new UImanager(lblDisplay, lblTimestamp);
            realSaveManager.checkForSavePath();
            uiManager.refreshSavedGames(lstBoxSavedGames);
            createContextMenu();
        }

        private void btnQuickSave_Click(object sender, EventArgs e)
        {
            realSaveManager.quickSaveClick();
            uiManager.refreshSavedGames(lstBoxSavedGames, realSaveManager.dsQuickSaveDir);
            enableDisableButtons();
        }

        private void btnLoadQuickSave_Click(object sender, EventArgs e)
        {
            realSaveManager.loadQuickSaveClick();
            uiManager.refreshSavedGames(lstBoxSavedGames);
            enableDisableButtons();
        }
        
        private void saveCustom_Click(object sender, EventArgs e)
        {
            
            if (saveCustomTextBox.Text != "")
            {
                realSaveManager.customSaveClick(saveCustomTextBox.Text);
                uiManager.refreshSavedGames(lstBoxSavedGames, realSaveManager.dsCustomSaveDir);
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
                realSaveManager.loadCustomSaveClick(selected);
                uiManager.refreshSavedGames(lstBoxSavedGames);
                enableDisableButtons();
            }
            else
            {
                MessageBox.Show("Please selecte a file");
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
             uiManager.refreshSavedGames(lstBoxSavedGames);
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
            realSaveManager.deleteSelectedSave(selected);
            uiManager.refreshSavedGames(lstBoxSavedGames);
        }

        private void enterSaveDIrectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realSaveManager.firstRun();
            uiManager.refreshSavedGames(lstBoxSavedGames);

            realSaveManager.checkForSavePath();
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
            uiManager.refreshSavedGames(lstBoxSavedGames, realSaveManager.dsQuickSaveDir);
        }

        private void btnCustomSaves_Click(object sender, EventArgs e)
        {
            uiManager.refreshSavedGames(lstBoxSavedGames, realSaveManager.dsCustomSaveDir);

        }

        private void btnAutoSaves_Click(object sender, EventArgs e)
        {
            uiManager.refreshSavedGames(lstBoxSavedGames, realSaveManager.dsAutoSaveDir);

        }

 
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


    }
    
}
