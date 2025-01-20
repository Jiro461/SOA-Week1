using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientSOA.ServiceRefSOA;

namespace ClientSOA
{
    public partial class Form1 : Form
    {
        public MyServicesSoapClient myService;
        public Form1()
        {
            InitializeComponent();
            myService = new MyServicesSoapClient();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InvokeService<T>(Func<T> serviceCall)
        {
            try
            {
                // Gọi service và lấy kết quả
                var result = serviceCall();

                // Cập nhật DataGridView
                if (result != null)
                {
                    resultDataGridView.DataSource = null;
                    resultDataGridView.DataSource = result;
                }
                else
                {
                    MessageBox.Show("Service returned no data.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show($"Error: {ex.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void serviceButton1_Click(object sender, EventArgs e)
        {
            InvokeService(() => myService.getAllCountry());
        }

        private void serviceButton6_Click(object sender, EventArgs e)
        {
            decimal GNP;
            if (decimal.TryParse(service6TextBox.Text, out GNP))
            {
                MessageBox.Show("Nhap Lai");
                return;
            };
            InvokeService(() => myService.getAllCountryByGNP(GNP));
        }

        private void serviceButton2_Click(object sender, EventArgs e)
        {
            string code = service2TextBox.Text; 
            InvokeService(() => myService.getCountryByCode(code));
        }

        private void serviceButton3_Click(object sender, EventArgs e)
        {
            string name = service3TextBox.Text;
            InvokeService(() => myService.getCityByName(name));
        }

        private void serviceButton4_Click(object sender, EventArgs e)
        {
            string country = service4TextBox.Text;
            InvokeService(() => myService.getCityBySpecificCountry(country));
        }

        private void serviceButton5_Click(object sender, EventArgs e)
        {
            int population;
            if(int.TryParse(service5TextBox.Text, out population))
            {
                MessageBox.Show("Nhap Lai");
                return;
            }
            InvokeService(() => myService.getAllCountryByPopulation(population));
        }
        private void serviceButton7_Click(object sender, EventArgs e)
        {
            string countryName = service7TextBox.Text;
            InvokeService(() => myService.getOfficialLanguageByCountryName(countryName));
        }

        private void resultDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
