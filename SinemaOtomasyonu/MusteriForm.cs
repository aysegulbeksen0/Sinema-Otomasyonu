using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyonu
{
    public partial class MusteriForm : Form
    {
        public FilmBilgileri.Program.LinkedList filmDatas = FilmBilgileri.Program.DefaultSystem();
        public OtomasyonAgaci.Program.Tree tree = OtomasyonAgaci.Program.DefaultSystem();
        public OzetPaneliBilgileri.Program.Queue queue = new OzetPaneliBilgileri.Program.Queue();
        public AdminForm form = new AdminForm();
        FilmBilgileri.Program.Node filmNode;

        public MusteriForm()
        {
            InitializeComponent();
        }

        private void MusteriForm_Load(object sender, EventArgs e)
        {
            filmNode = filmDatas.head;
            lblFilm.Text = FilmBilgileriniYazdir(filmNode);
            btnSeansSec.Enabled = btnKoltukSec.Enabled = btnGunSec.Enabled = false;
            SituationTheSeats(false);
        }

        //Film geri butonu
        private void button26_Click(object sender, EventArgs e)
        {
            lblFilm.Text = FilmBilgileriniYazdir(filmNode.before);
        }

        //Film ileri butobnu
        private void button28_Click(object sender, EventArgs e)
        {
            lblFilm.Text = FilmBilgileriniYazdir(filmNode.after);
        }
        public string FilmBilgileriniYazdir(FilmBilgileri.Program.Node node)
        {
            string text = "";
            filmNode = node;
            text = $"İsim : {node.name}\n\n" +
                $"IMDB : {node.puan}\n\n" +
                $"Tür : {node.kind}\n\n" +
                $"Tanıtım Yazısı :\n\n{node.promotion}";

            txtboxFilm.Text = node.name;

            return text;
        }

        //Filmi seçen buton
        private void button1_Click(object sender, EventArgs e)
        {
            form.BilgiCek(tree.root, "film", "gün", txtboxFilm.Text, lblGun, false);
            btnGunSec.Enabled = true;
            queue.EnQueue(queue, txtboxFilm.Text);
        }

        //gün seçen buton
        private void button2_Click(object sender, EventArgs e)
        {
            if (form.BilgiCek(tree.IsExist(tree.root, txtboxFilm.Text), "gün", "seans", txtboxGun.Text, lblSeans, false) == 1)
            {
                btnSeansSec.Enabled = true;
                queue.EnQueue(queue, txtboxGun.Text);
            }
        }

        //seans seçen buton
        private void button3_Click(object sender, EventArgs e)
        {
            Button[] seats = new Button[20] { btnKoltuk1, btnKoltuk2, btnKoltuk3, btnKoltuk4, btnKoltuk5, btnKoltuk6, btnKoltuk7, btnKoltuk8, btnKoltuk9, btnKoltuk10, btnKoltuk11, btnKoltuk12, btnKoltuk13, btnKoltuk14, btnKoltuk15, btnKoltuk16, btnKoltuk17, btnKoltuk18, btnKoltuk19, btnKoltuk20 };
            bool[] situations = new bool[20];
            int index = 0;

            if (txtboxSeans.Text == "")
                MessageBox.Show("Seans seçiniz");
            else
            {
                if (tree.IsExist(tree.IsExist(tree.IsExist(tree.root, txtboxFilm.Text), txtboxGun.Text), txtboxSeans.Text) == null)
                    MessageBox.Show("Bu isme sahip bir seans bulunmamaktadır.");
                else
                {
                    situations = (bool[])tree.IsExist(tree.IsExist(tree.IsExist(tree.root, txtboxFilm.Text), txtboxGun.Text), txtboxSeans.Text).data.Get()[1];
                    SituationTheSeats(true);

                    foreach (bool a in situations)
                    {
                        if (a == false)
                        {
                            seats[index].BackColor = Color.Green;
                            index++;
                        }
                        else
                        {
                            seats[index].Enabled = false;
                            seats[index].BackColor = Color.Red;
                            index++;
                        }
                    }
                    btnKoltukSec.Enabled = true;
                    queue.EnQueue(queue, txtboxSeans.Text);
                }
            }
        }
        public void SituationTheSeats(bool a)
        {
            btnKoltuk1.Enabled = btnKoltuk2.Enabled = btnKoltuk3.Enabled = btnKoltuk4.Enabled =
                btnKoltuk5.Enabled = btnKoltuk6.Enabled = btnKoltuk7.Enabled = btnKoltuk8.Enabled =
                btnKoltuk9.Enabled = btnKoltuk10.Enabled = btnKoltuk11.Enabled = btnKoltuk12.Enabled =
                btnKoltuk13.Enabled = btnKoltuk14.Enabled = btnKoltuk15.Enabled = btnKoltuk16.Enabled =
                btnKoltuk17.Enabled = btnKoltuk18.Enabled = btnKoltuk19.Enabled = btnKoltuk20.Enabled = a;

            if (a == false)
            {
                btnKoltuk1.BackColor = btnKoltuk2.BackColor = btnKoltuk3.BackColor = btnKoltuk4.BackColor =
                btnKoltuk5.BackColor = btnKoltuk6.BackColor = btnKoltuk7.BackColor = btnKoltuk8.BackColor =
                btnKoltuk9.BackColor = btnKoltuk10.BackColor = btnKoltuk11.BackColor = btnKoltuk12.BackColor =
                btnKoltuk13.BackColor = btnKoltuk14.BackColor = btnKoltuk15.BackColor = btnKoltuk16.BackColor =
                btnKoltuk17.BackColor = btnKoltuk18.BackColor = btnKoltuk19.BackColor = btnKoltuk20.BackColor = Color.White;
            }
        }
        private void btnKoltuk1_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "1";
        }
        private void btnKoltuk2_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "2";
        }
        private void btnKoltuk3_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "3";
        }
        private void btnKoltuk4_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "4";
        }
        private void btnKoltuk5_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "5";
        }
        private void btnKoltuk6_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "6";
        }
        private void btnKoltuk7_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "7";
        }
        private void btnKoltuk8_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "8";
        }
        private void btnKoltuk9_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "9";
        }
        private void btnKoltuk10_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "10";
        }
        private void btnKoltuk11_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "11";
        }
        private void btnKoltuk12_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "12";
        }
        private void btnKoltuk13_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "13";
        }
        private void btnKoltuk14_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "14";
        }
        private void btnKoltuk15_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "15";
        }
        private void btnKoltuk16_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "16";
        }
        private void btnKoltuk17_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "17";
        }
        private void btnKoltuk18_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "18";
        }
        private void btnKoltuk19_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "19";
        }
        private void btnKoltuk20_Click(object sender, EventArgs e)
        {
            txtboxKoltuk.Text = "20";
        }

        //koltuk seçen buton
        private void btnKoltukSec_Click(object sender, EventArgs e)
        {
            if (txtboxKoltuk.Text == "")
                MessageBox.Show("Koltuk seçiniz");
            else
            {
                queue.EnQueue(queue, txtboxKoltuk.Text);
                pnlOzet.Visible = true;
                lblFilmOzet.Text = queue.DeQueue(queue);
                lblGunOzet.Text = queue.DeQueue(queue);
                lblSeansOzet.Text = queue.DeQueue(queue);
                lblKoltukOzet.Text = queue.DeQueue(queue);
            }
        }

        //Özet panelini kapayan buton
        private void button2_Click_1(object sender, EventArgs e)
        {
            pnlOzet.Visible = false;
            lblFilmOzet.Text = lblGunOzet.Text = lblSeansOzet.Text = lblKoltukOzet.Text = "";
            txtboxGun.Text = txtboxSeans.Text = txtboxKoltuk.Text = "";
            lblGun.Text = lblSeans.Text = "";
            btnGunSec.Enabled = btnSeansSec.Enabled = btnKoltukSec.Enabled = false;
            SituationTheSeats(false);
        }

        //bilet satın al butonu
        private void button1_Click_1(object sender, EventArgs e)
        {
            bool[] situations = new bool[20];
            situations = (bool[])tree.IsExist(tree.IsExist(tree.IsExist(tree.root, txtboxFilm.Text), txtboxGun.Text), txtboxSeans.Text).data.Get()[1];
            situations[Convert.ToInt32(txtboxKoltuk.Text) - 1] = true;
            tree.IsExist(tree.IsExist(tree.IsExist(tree.root, txtboxFilm.Text), txtboxGun.Text), txtboxSeans.Text).data.Get()[1] = situations;
            pnlOzet.Visible = false;
            lblFilmOzet.Text = lblGunOzet.Text = lblSeansOzet.Text = lblKoltukOzet.Text = "";
            txtboxGun.Text = txtboxSeans.Text = txtboxKoltuk.Text = "";
            lblGun.Text = lblSeans.Text = "";
            btnGunSec.Enabled = btnSeansSec.Enabled = btnKoltukSec.Enabled = false;
            SituationTheSeats(false);
            MessageBox.Show("Bilet alma işlemi başarılı!");
        }
    }
}
