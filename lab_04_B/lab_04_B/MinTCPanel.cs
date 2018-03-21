using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab_04_B
{
    public partial class MinTCPanel : UserControl
    {
        public event Action<MinTCPanel> LoadDrivers;
        public MinTCPanel()
        {
            InitializeComponent();
        }
        readonly DriveInfo[] complete = DriveInfo.GetDrives().Where(drive => drive.IsReady).ToArray();

        public string CurrentPath
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        
        public string[] Dir
        {
           
                set
                 {
                    listBox1.Items.Clear();
                    foreach (string item in value)
                    {
                        listBox1.Items.Add(item);
                    }
                }
           

        
        }
        public string[] File
        {
            set
            {
               
                foreach (string item in value)
                {
                    listBox1.Items.Add("   "+item);
                }
            }
        }


        private void SetDr()
        {
            try
            {
                Dir = Directory.GetDirectories(CurrentPath);
                File = Directory.GetFiles(CurrentPath);
            }
            catch
            {
            
            }
            }

        private void ChangePath(string path)
        {
            CurrentPath = path;
            SetDr();
        }

      private void DriversCh(object sender, EventArgs e)
        {
            var drive = Path.GetPathRoot(comboBox1.SelectedItem.ToString());
            if (Directory.Exists(drive))
            {
                CurrentPath = comboBox1.SelectedItem.ToString();
                ChangePath(CurrentPath);
            }
            else
            {
                textBox1.Text = "Napęd nie jest gotowy!";
                listBox1.Items.Clear();
            }

        }




      private void comboBox1_DropDown(object sender, EventArgs e)
        {
             comboBox1.DataSource = complete;
        }

        private void Select(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ChangePath(listBox1.SelectedItem.ToString());
                
            }
        }




    }
   

       

    



}

