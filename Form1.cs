using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UkrPochtaParser
{
    public partial class Form1 : Form
    {
        Source source = null;
        Countries countries = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b;
            var c = Convert.ToDouble(textBox2.Text);

            if (radioButton1.Checked)
            {
                a = Convert.ToDouble(countries.List[listBox1.SelectedIndex].Tariffs[0]);

                if (radioButton3.Checked)
                {
                    b = Convert.ToDouble(countries.List[listBox1.SelectedIndex].Tariffs[1]);
                }
                else
                {
                    b = Convert.ToDouble(countries.List[listBox1.SelectedIndex].Tariffs[2]);
                }
            }
            else
            {
                a = Convert.ToDouble(countries.List[listBox1.SelectedIndex].Tariffs[3]);

                if (radioButton3.Checked)
                {
                    b = Convert.ToDouble(countries.List[listBox1.SelectedIndex].Tariffs[4]);
                }
                else
                {
                    b = Convert.ToDouble(countries.List[listBox1.SelectedIndex].Tariffs[5]);
                }
            }

            textBox3.Text = Calc.GetShippingCost(a, b, c).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            source = new Source("https://www.ukrposhta.ua/ru/taryfy-mizhnarodni-vidpravlennia-posylky");
            countries = new Countries();

            countries.ParseSourceStringToList(source.GetInnerText());

            listBox1.DataSource = countries.ListBoxContent;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = $"Ориентировочная стоимость доставки Укрпочтой по направлению Украина — {listBox1.SelectedItem.ToString()} составит: " +
                $"{countries.List[listBox1.SelectedIndex].Tariffs[0]}$ за единицу отправления + {countries.List[listBox1.SelectedIndex].Tariffs[1]}$ " +
                $"за каждый кг веса (включая упаковку). Указанные тарифы актуальны для посылок массой менее 10 кг без объявленной ценности. Доставка " +
                $"осуществляется авиатранспортом (наиболее быстрый способ).";

            textBox3.Clear();
        }
    }
}
