namespace SinemaOtomasyonu
{
    public partial class GirisForm1 : Form
    {
        public KullaniciGirisi.Program.LinkedList userList = KullaniciGirisi.Program.DefaultSystem();
        public GirisForm1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciGirisi.Program.Node temp = userList.head;
            while (temp != null)
            {
                if (txtboxKullaniciAdi.Text == temp.username)
                {
                    if (txtboxSifre.Text == temp.password)
                    {
                        if (txtboxKullaniciAdi.Text == "admin")
                        {
                            AdminForm form = new AdminForm();
                            form.Show();
                            break;
                        }
                        else
                        {
                            MusteriForm form = new MusteriForm();
                            form.Show();
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hatalý þifre");
                        goto BURAYA;

                    }

                }
                else
                    temp = temp.after;
            }
            if (temp == null)
                MessageBox.Show("Böyle bir kullanýcý bulunmamaktadýr.");
            BURAYA:;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            userList.AddLast(userList, txtboxKullanici.Text, txtboxSifr.Text);
            MessageBox.Show($"Ekleme iþlemi baþarýlý !");
            txtboxKullanici.Text = txtboxSifr.Text = "";
        }
    }
}