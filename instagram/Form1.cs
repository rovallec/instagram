using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace instagram
{
    public partial class frmLogin : Form
    {
        avlTree users_tree;
        loggedUser logUser;
        public frmLogin()
        {
            InitializeComponent();
            users_tree = new avlTree();
            logUser = new loggedUser();

            XmlDataDocument xmlDoc = new XmlDataDocument();
            XmlNodeList xmlNode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream("C:/XML/UserData.xml", FileMode.Open, FileAccess.Read);
            xmlDoc.Load(fs);
            xmlNode = xmlDoc.GetElementsByTagName("USER");
            for(i = 0; i <= xmlNode.Count - 1; i++)
            {
                users usr = new users(Int64.Parse(xmlNode[i].Attributes[0].Value), xmlNode[i].ChildNodes.Item(0).InnerText.Trim(),
                    xmlNode[i].ChildNodes.Item(1).InnerText.Trim(), xmlNode[i].ChildNodes.Item(2).InnerText.Trim(), xmlNode[i].ChildNodes.Item(3).InnerText.Trim());
                users_tree.insertar(usr);
            }
            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            users usr = new users();
            try
            {
                usr.idusers = Int64.Parse(txtUser.Text);
            }
            catch (Exception)
            {
                usr.username = txtUser.Text;
            }
            objNode lgUser = users_tree.buscar(usr);
            if(lgUser == null)
            {
                MessageBox.Show("El id de usuario ingresado no fue encontrado");
            }
            else
            {
                users usr_logged = (users)lgUser.valorNodo();
                logUser.setUser(usr_logged);
                homePage hmPage = new homePage();
                hmPage.loggedUser = logUser.getloggedUser();
                hmPage.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            newUser nw = new newUser();

            nw.Show();
            this.Hide();
        }
    }
}
