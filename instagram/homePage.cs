using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace instagram
{
    public partial class homePage : Form
    {
        public users loggedUser;
        Lists posts;
        hashTable following;
        hashTable followers;

        public homePage()
        {
            InitializeComponent();

            posts = new Lists();
            following = new hashTable(1000);
            followers = new hashTable(1000);

            XmlDataDocument xmlDoc = new XmlDataDocument();
            XmlNodeList xmlNode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream("C:/XML/FeedData.xml", FileMode.Open, FileAccess.Read);
            xmlDoc.Load(fs);
            xmlNode = xmlDoc.GetElementsByTagName("USER");
            for (i = 0; i <= xmlNode.Count - 1; i++)
            {
                Posts pst = new Posts(xmlNode[i].ChildNodes.Item(0).InnerText.Trim(),
                    xmlNode[i].ChildNodes.Item(1).InnerText.Trim(), xmlNode[i].ChildNodes.Item(2).InnerText.Trim());
                posts.InsertAtLast(pst);
            }
            fs.Close();


            XmlDataDocument xmlDoc2 = new XmlDataDocument();
            XmlNodeList xmlNode2;
            int i2 = 0;
            string str2 = null;
            FileStream fs2 = new FileStream("C:/XML/FollowerFollowingData.xml", FileMode.Open, FileAccess.Read);
            xmlDoc2.Load(fs2);
            xmlNode2 = xmlDoc2.GetElementsByTagName("USER");
            for (i = 0; i <= xmlNode2.Count - 1; i++)
            {
                following_followers pst = new following_followers(xmlNode2[i].ChildNodes.Item(0).InnerText.Trim(),
                    xmlNode2[i].ChildNodes.Item(1).InnerText.Trim());
                following.insertOnhash((new Random().Next(0, 10000)), pst);
            }
            fs.Close();

            XmlDataDocument xmlDoc3 = new XmlDataDocument();
            XmlNodeList xmlNode3;
            int i3 = 0;
            string str3 = null;
            FileStream fs3 = new FileStream("C:/XML/FollowerFollowingData.xml", FileMode.Open, FileAccess.Read);
            xmlDoc3.Load(fs3);
            xmlNode3 = xmlDoc3.GetElementsByTagName("USER");
            for (i = 0; i <= xmlNode3.Count - 1; i++)
            {
                following_followers pst = new following_followers(xmlNode3[i].ChildNodes.Item(0).InnerText.Trim(),
                    xmlNode3[i].ChildNodes.Item(1).InnerText.Trim());
                followers.insertOnhash((new Random().Next(0, 10000)), pst);
            }
            fs.Close();
        }

        private void homePage_Load(object sender, EventArgs e)
        {
            this.Text = loggedUser.fullName;
            textBox1.Text = loggedUser.idusers.ToString();
            textBox2.Text = loggedUser.username;
            textBox3.Text = loggedUser.fullName;
            textBox4.Text = loggedUser.birthDate;
            pictureBox1.ImageLocation = loggedUser.image;

            Lists temp_list = new Lists();

            Posts vPost = (Posts)posts.GetFirst();
            int i = 1;
            TabPage feed = new TabPage();
            feed.Name = "Feed";
            feed.Text = "Feed";
            feed.AutoScroll = true;
            tabControl1.Controls.Add(feed);

            TabPage foll = new TabPage();
            foll.Name = "Following";
            foll.Text = "Following";
            foll.AutoScroll = true;
            tabControl1.Controls.Add(foll);
            int d = 0;
            int found = 0;

            TabPage foll2 = new TabPage();
            foll2.Name = "Followers";
            foll2.Text = "Followers";
            foll2.AutoScroll = true;
            tabControl1.Controls.Add(foll2);
            int d2 = 0;
            int found2 = 0;

            while (d2 < followers.lenght)
            {
                following_followers run = (following_followers)followers.hash_objects[d2];
                if (run != null)
                {
                    XmlDataDocument xmlDoc4 = new XmlDataDocument();
                    XmlNodeList xmlNode4;
                    int c = 0;
                    string str4 = null;
                    FileStream fs4 = new FileStream("C:/XML/UserData.xml", FileMode.Open, FileAccess.Read);
                    xmlDoc4.Load(fs4);
                    xmlNode4 = xmlDoc4.GetElementsByTagName("USER");
                    for (c = 0; c <= xmlNode4.Count - 1; c++)
                    {
                        if (xmlNode4[c].ChildNodes.Item(0).InnerText.Trim() == run.follower && loggedUser.username == run.following)
                        {
                            PictureBox img_following = new PictureBox();
                            Label lbl_following = new Label();
                            img_following.ImageLocation = xmlNode4[c].ChildNodes.Item(2).InnerText.Trim();
                            lbl_following.Text = xmlNode4[c].ChildNodes.Item(1).InnerText.Trim();
                            img_following.Size = new Size(30, 25);
                            img_following.Location = new Point(0, (25 * found2));
                            lbl_following.AutoSize = true;
                            lbl_following.Location = new Point(35, (25 * found2));

                            foll2.Controls.Add(img_following);
                            foll2.Controls.Add(lbl_following);
                            found2++;
                            break;
                        }
                    }
                    fs4.Close();
                }
                d2++;
            }

            while (d < following.lenght)
            {
                following_followers run = (following_followers)following.hash_objects[d];
                if (run != null)
                {
                    XmlDataDocument xmlDoc3 = new XmlDataDocument();
                    XmlNodeList xmlNode3;
                    int c = 0;
                    string str3 = null;
                    FileStream fs3 = new FileStream("C:/XML/UserData.xml", FileMode.Open, FileAccess.Read);
                    xmlDoc3.Load(fs3);
                    xmlNode3 = xmlDoc3.GetElementsByTagName("USER");
                    for (c = 0; c <= xmlNode3.Count - 1; c++)
                    {
                        if (xmlNode3[c].ChildNodes.Item(0).InnerText.Trim() == run.following && run.follower == loggedUser.username)
                        {
                            PictureBox img_following = new PictureBox();
                            Label lbl_following = new Label();
                            img_following.ImageLocation = xmlNode3[c].ChildNodes.Item(2).InnerText.Trim();
                            lbl_following.Text = xmlNode3[c].ChildNodes.Item(1).InnerText.Trim();
                            img_following.Size = new Size(30, 25);
                            img_following.Location = new Point(0, (25 * found));
                            lbl_following.AutoSize = true;
                            lbl_following.Location = new Point(35, (25 * found));

                            foll.Controls.Add(img_following);
                            foll.Controls.Add(lbl_following);
                            found++;
                            break;
                        }
                    }
                    fs3.Close();
                }
                d++;
            }

            while (vPost != null)
            {
                Label post = new Label();
                Label account = new Label();
                PictureBox image_post = new PictureBox();

                image_post.Size = new Size(300, 50);
                image_post.ImageLocation = vPost.multimedia;
                post.Location = new Point(0, (55*i) + ((80+50)*(i-1)));
                post.AutoSize = true;
                post.Height = 23;
                post.Text = vPost.post;
                account.Location = new Point(0, (80*i) + ((50+55)*(i-1)));
                account.AutoSize = true;
                account.Text = vPost.username;

                feed.Controls.Add(image_post);
                feed.Controls.Add(post);
                feed.Controls.Add(account);

                temp_list.InsertAtLast(vPost);
                vPost = (Posts)posts.GetFirst();
                i++;
            }

            vPost = (Posts)temp_list.GetFirst();

            while(vPost != null)
            {
                posts.InsertAtLast(vPost);
                vPost = (Posts)temp_list.GetFirst();
            }

        }
    }
}
