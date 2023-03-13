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
    }
}