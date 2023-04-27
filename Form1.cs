namespace MemeAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();

            MemoryStream memoryStream = new MemoryStream();

            pictureBox1.Image.Save(memoryStream, pictureBox1.Image.RawFormat);

            string base64 = Convert.ToBase64String(memoryStream.ToArray());

            FormUrlEncodedContent content = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("image", base64)
                }
            );

            HttpResponseMessage httpResponse = httpClient.PostAsync("https://matav.cz/api/saveMeme", content).Result;
            string responseText = httpResponse.Content.ReadAsStringAsync().Result;
            MessageBox.Show(responseText, httpResponse.StatusCode.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemeBrowser memeBrowser = new MemeBrowser();
            memeBrowser.ShowDialog();
        }
    }
}