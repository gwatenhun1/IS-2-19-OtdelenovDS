using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_2_19_OtdelenovDS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class Komplektuusie<k>
        {
            protected string cena;
            protected string god_vipuska;
            protected string articul;
            public Komplektuusie(string Cena, string God_vipuska, string Articul)
            {
                cena = Cena;
                god_vipuska = God_vipuska;
                articul = Articul;
            }
            public abstract void Display(ListBox listBox1);
        }
        class CP : Komplektuusie<string>
        {
            public string chastota1;
            public string kolvo_yader1;
            public string kolvo_potokov1;
            public CP(string Cena, string God_vipuska, string Articul, string Chastota, string Kolvo_yader, string Kolvo_potokov)
                : base(Cena, God_vipuska, Articul)
            {
                chastota = Chastota;
                kolvo_yader = Kolvo_yader;
                kolvo_potokov = Kolvo_potokov;
            }
            public string chastota
            {
                get { return chastota1; }
                set { chastota1 = value; }
            }
            public string kolvo_yader
            {
                get { return kolvo_yader1; }
                set { kolvo_yader1 = value; }
            }
            public string kolvo_potokov
            {
                get { return kolvo_potokov1; }
                set { kolvo_potokov1 = value; }
            }
            public override void Display(ListBox listBox1)
            {
                listBox1.Items.Add($"Цена - {cena}, год выпуска - {god_vipuska}, частота - {chastota}, кол-во ядер - {kolvo_yader}, кол-во потоков - {kolvo_potokov}, арткуль - {articul}");
            }
        }
        class videocart : Komplektuusie<string>
        {
            public string chastota1;
            public string proizv1;
            public string obiem_pamyati1;
            public videocart(string Cena, string God_vipuska, string Articul, string Obiemm_pammyati, string Proizv, string Chastota)
                : base(Cena, God_vipuska, Articul)
            {
                chastota = Chastota;
                proizv = Proizv;
                obiem_pamyati = Obiemm_pammyati;
            }
            public string chastota
            {
                get {return chastota1;}
                set { chastota1 = value;}
            }
            public string proizv
            {
                get { return proizv1; }
                set { proizv1 = value; }
            }
            public string obiem_pamyati
            {
                get { return obiem_pamyati1; }
                set { obiem_pamyati1 = value; }
            }
            public override void Display(ListBox listBox1)
            {
                listBox1.Items.Add($"Цена - {cena}, год выпуска - {god_vipuska}, частота - {chastota}, производитель - {proizv}, объём памяти - {obiem_pamyati}, арткуль - {articul}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cena = Convert.ToString(textBox1.Text);
            string god_vipuska = Convert.ToString(textBox2.Text);
            string chastota = Convert.ToString(textBox3.Text);
            string kolvo_yader = Convert.ToString(textBox4.Text);
            string kolvo_potokov = Convert.ToString(textBox5.Text);
            string articul = Convert.ToString(textBox6.Text);
            CP cp1 = new CP(cena, god_vipuska, chastota, kolvo_yader, kolvo_potokov, articul);
            cp1.Display(listBox1);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cena = Convert.ToString(textBox1.Text);
            string god_vipuska = Convert.ToString(textBox2.Text);
            string chastota = Convert.ToString(textBox3.Text);
            string pamyat = Convert.ToString(textBox7.Text);
            string proizvod = Convert.ToString(textBox8.Text);
            string articul = Convert.ToString(textBox4.Text);
            videocart video = new videocart(cena, god_vipuska, chastota, pamyat, proizvod, articul);
            video.Display(listBox1);
        }
    }
}
