using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace instagram
{
    public partial class newUser : Form
    {
        public newUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = "C:/XML/UserData.xml";
            var xmlDoc = XDocument.Load(filePath);
            var parentElement = new XElement("USER");
            var idUser = new XElement("ID", textBox1.Text);
            var username = new XElement("USERNAME", textBox2.Text);
            var fullName = new XElement("FULLNAME", textBox3.Text);
            var image = new XElement("PROFILEIMAGE", textBox4.Text);
            var birthDate = new XElement("BIRTHDATE", textBox5.Text);

            parentElement.SetAttributeValue("ID", textBox1.Text);
            parentElement.Add(username);
            parentElement.Add(fullName);
            parentElement.Add(image);
            parentElement.Add(birthDate);

            var rootElement = xmlDoc.Element("USERDATA");
            rootElement?.Add(parentElement);
            xmlDoc.Save(filePath);
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }
    }
}
