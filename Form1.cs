using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLinqHW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dataClasses1DataContext = new DataClasses1DataContext();
            var orderShipper = from shipperCity in dataClasses1DataContext.Orders
                               where shipperCity.ShipCity == "Seattle" || shipperCity.ShipCity == "Portland" 
                               orderby shipperCity.ShipCity
                               select new
                               {
                                   shipperCity.ShipCity,
                                   shipperCity.OrderDate,
                                   shipperCity.Shipper.CompanyName,
                                   shipperName = shipperCity.ShipName

                               };
            dataGridView1.DataSource = orderShipper.ToList();
        }
    }
}
