using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace GetIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ipwhois.app/json/" + textBox1.Text);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string Data = reader.ReadToEnd();
            response.Close();

            dynamic d = JsonConvert.DeserializeObject(Data);
            label1.Text = d.country + ", " + d.city;
        }
    }
}
