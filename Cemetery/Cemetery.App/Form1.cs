using Cemetery.BL;
using Cemetery.Models.Request;

namespace Cemetery.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBoxName.Text;
                var address = textBoxAddress.Text;
                var city = textBoxCity.Text;
                var year = int.Parse(textBoxYear.Text);
                var countOfBurial = int.Parse(textBoxCountOfBurial.Text);

                var cemeteryRequest = new CemeteryRequest()
                {
                    Name = name,
                    Address = address,
                    City = city,
                    Year = year,
                    CountOfBurial = countOfBurial,
                };

                CemeteryService.AddCemetery(cemeteryRequest);

                MessageBox.Show($"Кладовище {cemeteryRequest.Name} додано до бази даних");
                textBoxName.Text = "";
                textBoxAddress.Text = "";
                textBoxCity.Text = "";
                textBoxYear.Text = "";
                textBoxCountOfBurial.Text = "";
            }
            catch
            {
                MessageBox.Show("Не вдалось додати кладовище до бази даних");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cemeteries = CemeteryService.GetAllCemeteries();

                var resultString = "";
                foreach (var cemetery in cemeteries)
                {
                    resultString +=
                        $"{cemetery.Id} {cemetery.City} {cemetery.Name} {cemetery.CountOfBurial} {cemetery.Year} {cemetery.Address}\n";
                }

                label7.Text = resultString;
            }
            catch
            {
                MessageBox.Show("Не вдалось отримати кладовища з бази даних");
            }
        }

        private void buttonImg_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog1 = new OpenFileDialog();

                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = openFileDialog1.FileName;
                CemeteryService.AddImage(filePath, Guid.Parse("3B575AFB-9BFE-4B5E-9DF6-181A7240ED10"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}