using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SinemaOtomasyonu
{
    public partial class AdminForm : Form
    {
        public KullaniciGirisi.Program.LinkedList userList = KullaniciGirisi.Program.DefaultSystem();
        public OtomasyonAgaci.Program.Tree tree = OtomasyonAgaci.Program.DefaultSystem();
        public AdminForm()
        {
            InitializeComponent();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            VerileriGüncelleme();
            pnlFilmAyarlari.Visible = pnlSeans.Visible = pnlGun.Visible = false;
            pnlKullanici.Visible = true;
            button15.Enabled = button24.Enabled = button25.Enabled = button27.Enabled = button41.Enabled =
                button35.Enabled = button32.Enabled = button33.Enabled = button30.Enabled = button43.Enabled = false;
        }

        //Kullanıcı verileri butonu
        private void button1_Click(object sender, EventArgs e)
        {
            pnlKullanici.Visible = true;
            pnlFilmAyarlari.Visible = pnlGun.Visible = pnlSeans.Visible = false;
            pnlFilmBilgileri.Visible = pnlFilmEkle.Visible = pnlFilmSil.Visible = false;
            pnlGunEkle.Visible = pnlGunGuncelle.Visible = pnlGunSil.Visible = false;
            pnlSeansDegis.Visible = pnlSeansEkle.Visible = pnlSeansSil.Visible = false;
        }

        //Kullanıcı ekleme butonu
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtboxEklemeKullanici.Text == "" || txtboxEklemeSifre.Text == "")
                MessageBox.Show("Lütfen eklemek istediğiniz kullanıcı adını ve şifreyi giriniz");
            else
            {
                userList.AddLast(userList, txtboxEklemeKullanici.Text, txtboxEklemeSifre.Text);
                MessageBox.Show("Ekleme işlemi başarılı !");
                txtboxEklemeKullanici.Text = txtboxEklemeSifre.Text = "";
                VerileriGüncelleme();
            }
        }

        //Kullanıcı silme butonu
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtboxSilmeKullanici.Text == "")
                MessageBox.Show("Silmek istediğiniz kullanıcı adını giriniz");
            else
            {
                if (userList.Delete(userList, txtboxSilmeKullanici.Text) == -1)
                    MessageBox.Show("Böyle birisi bulunmamaktadır.");
                else
                {
                    MessageBox.Show("Silme işlemi başarılı !");
                    txtboxSilmeKullanici.Text = "";
                    VerileriGüncelleme();
                }
            }
        }

        //Film ekle panelini açan buton
        private void button6_Click(object sender, EventArgs e)
        {
            pnlFilmEkle.Visible = true;
            pnlFilmSil.Visible = false;
            pnlFilmBilgileri.Visible = false;
        }

        //Film ayarları butonu
        private void button4_Click_1(object sender, EventArgs e)
        {
            pnlFilmAyarlari.Visible = true;
            pnlKullanici.Visible = pnlGun.Visible = pnlSeans.Visible = false;
            pnlGunEkle.Visible = pnlGunGuncelle.Visible = pnlGunSil.Visible = false;
            pnlSeansDegis.Visible = pnlSeansEkle.Visible = pnlSeansSil.Visible = false;
        }

        //Film ekle ekranını kapama butonu
        private void button10_Click(object sender, EventArgs e)
        {
            pnlFilmEkle.Visible = false;
            txtboxFilmAdi.Text = txtboxFilmPuani.Text = txtboxFilmTanitimi.Text = txtboxFilmTuru.Text = "";
        }

        //Film ekleme butonu
        private void button9_Click(object sender, EventArgs e)
        {
            if (txtboxFilmAdi.Text == "" || txtboxFilmPuani.Text == "" || txtboxFilmTanitimi.Text == "" || txtboxFilmTuru.Text == "")
                MessageBox.Show("Lütfen tüm bilgileri girin");
            else
            {
                string filmName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtboxFilmAdi.Text);
                tree.AddNode(tree.root, filmName, OtomasyonAgaci.Program.DataType.Film, txtboxFilmPuani.Text,
                    txtboxFilmTuru.Text, txtboxFilmTanitimi.Text);
                VerileriGüncelleme();
                MessageBox.Show("Film ekleme işlemi başarılı!");
            }
        }

        //Film sil ekranını kapama butonu
        private void button11_Click(object sender, EventArgs e)
        {
            pnlFilmSil.Visible = false;
            txtboxSilinenFilm.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            pnlFilmSil.Visible = true;
            pnlKullanici.Visible = false;
            pnlFilmEkle.Visible = false;
            pnlFilmBilgileri.Visible = false;
            VerileriGüncelleme();
        }

        //Film silme butonu
        private void button12_Click(object sender, EventArgs e)
        {
            if (txtboxSilinenFilm.Text == "")
                MessageBox.Show("Lütfen silmek istediğiniz filmin ismini giriniz.");
            else
            {
                if (tree.Remove(tree.root, txtboxSilinenFilm.Text) == -1)
                    MessageBox.Show("Böyle bir film bulunmamaktadır.");
                else
                {
                    MessageBox.Show("Silme işlemi başarılı");
                    txtboxSilinenFilm.Text = "";
                }
                VerileriGüncelleme();
            }
        }
        public void VerileriGüncelleme()
        {
            lblVeriler.Text = userList.PrintList(userList);

            lblFilmler.Text = "";
            foreach (OtomasyonAgaci.Program.Node a in tree.root.children)
                lblFilmler.Text += $"{a.data.Get()[0]}\n";
        }

        //Bilgi güncelleme ekranını kapama butonu
        private void button13_Click(object sender, EventArgs e)
        {
            pnlFilmBilgileri.Visible = false;
            txtboxGuncelAd.Text = txtboxGuncelPuan.Text = txtboxGuncelTanitim.Text = txtboxGuncelTur.Text = txtboxBilgiGetir.Text = "";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            pnlFilmBilgileri.Visible = true;
            pnlKullanici.Visible = false;
            pnlFilmSil.Visible = false;
            pnlFilmEkle.Visible = false;
            VerileriGüncelleme();
        }

        //Film bilgilerini çekme butonu
        private void button14_Click(object sender, EventArgs e)
        {
            if (txtboxBilgiGetir.Text == "")
                MessageBox.Show("Lütfen bilgisini çekmek istediğiniz filmin ismini girin.");
            else
            {
                if (tree.IsExist(tree.root, txtboxBilgiGetir.Text) == null)
                    MessageBox.Show("Bu isme sahip bir film bulunmamaktadır.");
                else
                {
                    ArrayList list = tree.IsExist(tree.root, txtboxBilgiGetir.Text).data.Get();
                    txtboxGuncelAd.Text = list[0].ToString();
                    txtboxGuncelPuan.Text = list[1].ToString();
                    txtboxGuncelTur.Text = list[2].ToString();
                    txtboxGuncelTanitim.Text = list[3].ToString();
                    button15.Enabled = true;
                }
            }
        }

        //Film bilgilerini güncelleme butonu
        private void button15_Click(object sender, EventArgs e)
        {
            ArrayList list = tree.IsExist(tree.root, txtboxBilgiGetir.Text).data.Get();
            string filmName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtboxGuncelAd.Text);
            list[0] = filmName;
            list[1] = txtboxGuncelPuan.Text;
            list[2] = txtboxGuncelTur.Text;
            list[3] = txtboxGuncelTanitim.Text;
            VerileriGüncelleme();
            MessageBox.Show("Güncelleme işlemi başarılı !");
        }

        //Gün ayarları panel butonu
        private void button16_Click(object sender, EventArgs e)
        {
            pnlGun.Visible = true;
            pnlKullanici.Visible = pnlFilmAyarlari.Visible = pnlSeans.Visible = false;
            pnlFilmBilgileri.Visible = pnlFilmEkle.Visible = pnlFilmSil.Visible = false;
            pnlSeansDegis.Visible = pnlSeansEkle.Visible = pnlSeansSil.Visible = false;
        }

        //Gün ekle panelini kapatan buton
        private void button21_Click(object sender, EventArgs e)
        {
            pnlGunEkle.Visible = false;
            txtboxGunCekme.Text = txtboxEklenenGun.Text = lblGunBilgisi.Text = "";
        }

        //Gün sil panelini kapatan buton
        private void button22_Click(object sender, EventArgs e)
        {
            pnlGunSil.Visible = false;
            txtboxGunCekmeSil.Text = txtboxSilinenGun.Text = lblGunBilgisiSil.Text = "";
        }

        //Gün güncelle panelini kapatan buton
        private void button23_Click(object sender, EventArgs e)
        {
            pnlGunGuncelle.Visible = false;
            txtboxYeniGunİsmi.Text = txtboxEskiGunİsmi.Text = txtboxGunCekmeDegis.Text = "";
        }

        //Gün ekle panelini açan buton
        private void button18_Click(object sender, EventArgs e)
        {
            pnlGunEkle.Visible = true;
            pnlGunGuncelle.Visible = pnlGunSil.Visible = false;
        }

        //Gün sil panelini açan buton
        private void button19_Click(object sender, EventArgs e)
        {
            pnlGunSil.Visible = true;
            pnlGunEkle.Visible = pnlGunGuncelle.Visible = false;
        }

        //Gün güncelle panelini açan buton
        private void button20_Click(object sender, EventArgs e)
        {
            pnlGunGuncelle.Visible = true;
            pnlGunEkle.Visible = pnlGunSil.Visible = false;
        }

        //Gün ekle kısmında filmin gün bilgilerini çeken buton
        private void button5_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.root, "film", "gün", txtboxGunCekme.Text, lblGunBilgisi, true) != -1)
                button24.Enabled = true;
        }
        public List<string> GunleriSirala(OtomasyonAgaci.Program.Node film)
        {
            List<string> karmasikListe = new List<string>();
            List<string> siraliListe = new List<string>();
            Dictionary<string, int> aylar = new Dictionary<string, int>();
            aylar.Add("ocak", 1); aylar.Add("şubat", 2); aylar.Add("mart", 3); aylar.Add("nisan", 4); aylar.Add("mayıs", 5);
            aylar.Add("haziran", 6); aylar.Add("temmuz", 7); aylar.Add("ağustos", 8); aylar.Add("eylül", 9); aylar.Add("ekim", 10);
            aylar.Add("kasım", 11); aylar.Add("aralık", 12);

            foreach (OtomasyonAgaci.Program.Node a in film.children)
                karmasikListe.Add(a.data.Get()[0].ToString());

            if (karmasikListe.Count == 0)
                return null;

            while (karmasikListe.Count != 0)
            {
                string onceGelen = "";
                foreach (string s in karmasikListe)
                {
                    if (onceGelen == "")
                        onceGelen = s;
                    else if (aylar[s.Split(' ')[1].ToLower()] < aylar[onceGelen.Split(' ')[1].ToLower()])
                    {
                        onceGelen = s;
                    }
                    else if (aylar[s.Split(' ')[1].ToLower()] == aylar[onceGelen.Split(' ')[1].ToLower()])
                    {
                        if (Convert.ToInt32(s.Split(' ')[0]) < Convert.ToInt32(onceGelen.Split(' ')[0]))
                            onceGelen = s;
                    }
                }
                siraliListe.Add(onceGelen);
                karmasikListe.Remove(onceGelen);
            }
            return siraliListe;
        }
        public List<string> SeanslariSirala(OtomasyonAgaci.Program.Node gun)
        {
            List<string> karmasikListe = new List<string>();
            List<string> siraliListe = new List<string>();

            foreach (OtomasyonAgaci.Program.Node a in gun.children)
                karmasikListe.Add(a.data.Get()[0].ToString());

            if (karmasikListe.Count == 0)
                return null;

            while (karmasikListe.Count != 0)
            {
                string onceGelen = "";
                foreach (string s in karmasikListe)
                {
                    if (onceGelen == "")
                        onceGelen = s;
                    else if (Convert.ToInt32(s.Split('.')[0]) < Convert.ToInt32(onceGelen.Split('.')[0]))
                    {
                        onceGelen = s;
                    }
                    else if (Convert.ToInt32(s.Split('.')[0]) == Convert.ToInt32(onceGelen.Split('.')[0]))
                    {
                        if (Convert.ToInt32(s.Split('.')[1]) < Convert.ToInt32(onceGelen.Split('.')[1]))
                            onceGelen = s;
                    }
                }
                siraliListe.Add(onceGelen);
                karmasikListe.Remove(onceGelen);
            }
            return siraliListe;
        }

        //Gün ekleme butonu
        private void button24_Click(object sender, EventArgs e)
        {
            if (txtboxEklenenGun.Text == "")
                MessageBox.Show("Gün ismi giriniz");
            else
            {
                if (txtboxEklenenGun.Text.Split(" ").Length < 2 || txtboxEklenenGun.Text.Split(" ").Length > 2)
                    MessageBox.Show("Eklenecek günü GÜN SAYISI ve AY İSMİ cinsinden giriniz.");
                else if (!Regex.IsMatch(txtboxEklenenGun.Text.Split(" ")[0], "^[0-9]*$") || !Regex.IsMatch(txtboxEklenenGun.Text.Split(" ")[1], "^[a-zA-Z]*$"))
                    MessageBox.Show("Eklenecek günü GÜN SAYISI ve AY İSMİ cinsinden giriniz.");
                else
                {
                    string dayName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtboxEklenenGun.Text);
                    tree.AddNode(tree.IsExist(tree.root, txtboxGunCekme.Text), dayName, OtomasyonAgaci.Program.DataType.Day);
                    lblGunBilgisi.Text = "";
                    foreach (string a in GunleriSirala(tree.IsExist(tree.root, txtboxGunCekme.Text)))
                        lblGunBilgisi.Text += $"{a}\n";
                    MessageBox.Show("Gün ekleme işlemi başarılı!");
                }
            }
        }

        //Gün sil kısmında filmin günlerini çeken buton
        private void button26_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.root, "film", "gün", txtboxGunCekmeSil.Text, lblGunBilgisiSil, true) != -1)
                button25.Enabled = true;
        }

        //Gün silme butonu
        private void button25_Click(object sender, EventArgs e)
        {
            if (txtboxGunCekmeSil.Text == "")
                MessageBox.Show("Gün ismi giriniz.");
            else
            {
                if (tree.IsExist(tree.IsExist(tree.root, txtboxGunCekmeSil.Text), txtboxSilinenGun.Text) == null)
                    MessageBox.Show("Böyle bir gün bulunmamaktadır");
                else
                {
                    tree.Remove(tree.IsExist(tree.root, txtboxGunCekmeSil.Text), txtboxSilinenGun.Text);
                    lblGunBilgisiSil.Text = "";
                    foreach (string a in GunleriSirala(tree.IsExist(tree.root, txtboxGunCekmeSil.Text)))
                        lblGunBilgisiSil.Text += $"{a}\n";
                    MessageBox.Show("Gün silme işlemi başarılı!");
                }
            }
        }

        //Gün değiştir kısmında filmin günlerini çeken buton
        private void button29_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.root, "film", "gün", txtboxGunCekmeDegis.Text, lblGunBilgisiDegis, true) != -1)
                button27.Enabled = true;
        }

        //Gün değiştirme butonu
        private void button27_Click(object sender, EventArgs e)
        {
            if (txtboxEskiGunİsmi.Text == "" || txtboxYeniGunİsmi.Text == "")
                MessageBox.Show("Gün isimlerini giriniz.");
            else
            {
                if (tree.IsExist(tree.IsExist(tree.root, txtboxGunCekmeDegis.Text), txtboxEskiGunİsmi.Text) == null)
                    MessageBox.Show("Filmde böyle bir gün bulunmamaktadır.");
                else
                {
                    if (txtboxYeniGunİsmi.Text.Split(" ").Length < 2 || txtboxYeniGunİsmi.Text.Split(" ").Length > 2)
                        MessageBox.Show("Eklenecek günü GÜN SAYISI ve AY İSMİ cinsinden giriniz.");
                    else if (!Regex.IsMatch(txtboxYeniGunİsmi.Text.Split(" ")[0], "^[0-9]*$") || !Regex.IsMatch(txtboxYeniGunİsmi.Text.Split(" ")[1], "^[a-zA-Z]*$"))
                        MessageBox.Show("Eklenecek günü GÜN SAYISI ve AY İSMİ cinsinden giriniz.");
                    else
                    {
                        string dayName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtboxYeniGunİsmi.Text);
                        ArrayList list = tree.IsExist(tree.IsExist(tree.root, txtboxGunCekmeDegis.Text), txtboxEskiGunİsmi.Text).data.Get();
                        list[0] = dayName;

                        lblGunBilgisiDegis.Text = "";
                        foreach (string a in GunleriSirala(tree.IsExist(tree.root, txtboxGunCekmeDegis.Text)))
                            lblGunBilgisiDegis.Text += $"{a}\n";

                        MessageBox.Show("Gün değiştirme işlemi başarılı !");
                    }
                }
            }
        }

        //Seans ayarları panelini açan buton
        private void button17_Click(object sender, EventArgs e)
        {
            pnlSeans.Visible = true;
            pnlKullanici.Visible = pnlFilmAyarlari.Visible = pnlGun.Visible = false;
            pnlFilmBilgileri.Visible = pnlFilmEkle.Visible = pnlFilmSil.Visible = false;
            pnlGunEkle.Visible = pnlGunGuncelle.Visible = pnlGunSil.Visible = false;
        }

        //Seans Ekle panelini kapatan buton
        private void button37_Click(object sender, EventArgs e)
        {
            pnlSeansEkle.Visible = false;
            txtboxSeansEkleFilm.Text = txtboxSeansEkleGun.Text = txtboxEklenecekSeans.Text = "";
            lblSeansBilgi.Text = lblSeansGün.Text = "";
        }

        //Seans ekle'de film bilgilerini çeken buton
        private void button36_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.root, "film", "gün", txtboxSeansEkleFilm.Text, lblSeansGün, true) != -1)
                button41.Enabled = true;
        }

        //Seans ekle panelini açan buton
        private void button38_Click(object sender, EventArgs e)
        {
            pnlSeansEkle.Visible = true;
            pnlSeansSil.Visible = pnlSeansDegis.Visible = false;
        }

        //Seans ekle'de günün seans bilgilerini çeken buton
        private void button41_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.IsExist(tree.root, txtboxSeansEkleFilm.Text), "gün", "seans", txtboxSeansEkleGun.Text, lblSeansBilgi, true) != -1)
                button35.Enabled = true;
        }
        public int BilgiCek(OtomasyonAgaci.Program.Node grandParent, string parentTypeTurkish, string infoTypeTurkish, string parentName, Label infoText, bool isVertical)
        {
            parentTypeTurkish = parentTypeTurkish.ToLower();
            if (parentName == "")
            {
                parentTypeTurkish = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parentTypeTurkish);
                MessageBox.Show($"{parentTypeTurkish} ismi giriniz.");
                return -1;
            }
            else
            {
                if (tree.IsExist(grandParent, parentName) == null)
                {
                    MessageBox.Show($"Bu isme sahip bir {parentTypeTurkish} bulunmamaktadır.");
                    return -1;
                }
                else
                {
                    infoText.Text = "";
                    if (infoTypeTurkish == "gün")
                    {
                        if (GunleriSirala(tree.IsExist(grandParent, parentName)) == null)
                        {
                            infoText.Text = $"{infoTypeTurkish} bulunmamaktadır.";
                            return -1;
                        }
                        else
                        {
                            if (isVertical == true)
                            {
                                foreach (string a in GunleriSirala(tree.IsExist(grandParent, parentName)))
                                    infoText.Text += $"{a}\n";
                                return 1;
                            }
                            else
                            {
                                foreach (string a in GunleriSirala(tree.IsExist(grandParent, parentName)))
                                    infoText.Text += $"{a}  |  ";
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        if (SeanslariSirala(tree.IsExist(grandParent, parentName)) == null)
                        {
                            infoText.Text = $"{infoTypeTurkish} bulunmamaktadır.";
                            return -1;
                        }
                        else
                        {
                            if (isVertical == true)
                            {
                                foreach (string a in SeanslariSirala(tree.IsExist(grandParent, parentName)))
                                    infoText.Text += $"{a}\n";
                                return 1;
                            }
                            else
                            {
                                foreach (string a in SeanslariSirala(tree.IsExist(grandParent, parentName)))
                                    infoText.Text += $"{a}  |  ";
                                return 1;
                            }
                        }
                    }
                }
            }
        }

        //Seans ekleme butonu
        private void button35_Click(object sender, EventArgs e)
        {
            if (txtboxEklenecekSeans.Text == "")
                MessageBox.Show("Seans giriniz");
            else
            {
                if (!Regex.IsMatch(txtboxEklenecekSeans.Text.Split(".")[0], "^[0-9]*$") || !Regex.IsMatch(txtboxEklenecekSeans.Text.Split(".")[1], "^[0-9]*$"))
                    MessageBox.Show("Ekleyeceğiniz seansı sayı kullanarak SAAT . DAKİKA cinsinden giriniz");
                else if (txtboxEklenecekSeans.Text.Split(".").Length < 2 || txtboxEklenecekSeans.Text.Split(".").Length > 2)
                    MessageBox.Show("Ekleyeceğiniz seansı sayı kullanarak SAAT . DAKİKA cinsinden giriniz");
                else
                {
                    tree.AddNode(tree.IsExist(tree.IsExist(tree.root, txtboxSeansEkleFilm.Text), txtboxSeansEkleGun.Text), txtboxEklenecekSeans.Text, OtomasyonAgaci.Program.DataType.Seans);
                    lblSeansBilgi.Text = "";
                    foreach (string a in SeanslariSirala(tree.IsExist(tree.IsExist(tree.root, txtboxSeansEkleFilm.Text), txtboxSeansEkleGun.Text)))
                        lblSeansBilgi.Text += $"{a}\n";
                    MessageBox.Show("Seans ekleme işlemi başarılı!");
                }

            }
        }

        //seans sil panelini açan buton
        private void button39_Click(object sender, EventArgs e)
        {
            pnlSeansSil.Visible = true;
            pnlSeansEkle.Visible = pnlSeansDegis.Visible = false;
        }

        //seans değiştirme panelini açan buton
        private void button40_Click(object sender, EventArgs e)
        {
            pnlSeansDegis.Visible = true;
            pnlSeansEkle.Visible = pnlSeansSil.Visible = false;
        }

        //Seans sil'de filmin gün bilgilerini çeken buton
        private void button34_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.root, "film", "gün", txtboxSeansSilFilm.Text, lblSeansSilGunler, true) != -1)
                button32.Enabled = true;
        }

        //seans sil'de günün seans bilgilerini çeken buton
        private void button32_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.IsExist(tree.root, txtboxSeansSilFilm.Text), "gün", "seans", txtboxSeansSilGun.Text, lblSeansSilSeans, true) != -1)
                button33.Enabled = true;
        }

        //Seans silen buton
        private void button33_Click(object sender, EventArgs e)
        {
            if (txtboxSilinecekSeans.Text == "")
                MessageBox.Show("Seans giriniz.");
            else
            {
                if (tree.IsExist(tree.IsExist(tree.IsExist(tree.root, txtboxSeansSilFilm.Text), txtboxSeansSilGun.Text), txtboxSilinecekSeans.Text) == null)
                    MessageBox.Show("Böyle bir seans bulunmamaktadır");
                else
                {
                    tree.Remove(tree.IsExist(tree.IsExist(tree.root, txtboxSeansSilFilm.Text), txtboxSeansSilGun.Text), txtboxSilinecekSeans.Text);
                    lblSeansSilSeans.Text = "";
                    foreach (string a in SeanslariSirala(tree.IsExist(tree.IsExist(tree.root, txtboxSeansSilFilm.Text), txtboxSeansSilGun.Text)))
                        lblSeansSilSeans.Text += $"{a}\n";
                    MessageBox.Show("Seans silme işlemi başarılı!");
                }
            }
        }

        //seans sil panelini kapatan buton
        private void button42_Click(object sender, EventArgs e)
        {
            pnlSeansSil.Visible = false;
            txtboxSilinecekSeans.Text = txtboxSeansSilGun.Text = txtboxSeansSilFilm.Text = "";
            lblSeansSilSeans.Text = lblSeansSilGunler.Text = "";
        }

        //seans değiştirme panelini kapatan buton
        private void button28_Click(object sender, EventArgs e)
        {
            pnlSeansDegis.Visible = false;
            txtboxSeansDegisFilm.Text = txtboxSeansDegisGun.Text = txtboxEskiSeans.Text = txtboxYeniSeans.Text = "";
            lblSeansDegisGun.Text = lblSeansDegisSeans.Text = "";
        }

        //seans değiştirme'de filmin gün bilgilerini çeken buton
        private void button31_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.root, "film", "gün", txtboxSeansDegisFilm.Text, lblSeansDegisGun, true) != -1)
                button30.Enabled = true;
        }

        //seans değiştirme'de günün seans bilgilerini çeken buton
        private void button30_Click(object sender, EventArgs e)
        {
            if (BilgiCek(tree.IsExist(tree.root, txtboxSeansDegisFilm.Text), "gün", "seans", txtboxSeansDegisGun.Text, lblSeansDegisSeans, true) != -1)
                button43.Enabled = true;
        }

        //seans değiştirme butonu
        private void button43_Click(object sender, EventArgs e)
        {
            if (txtboxEskiSeans.Text == "" || txtboxYeniSeans.Text == "")
                MessageBox.Show("Seans isimlerini giriniz.");
            else
            {
                if (tree.IsExist(tree.IsExist(tree.IsExist(tree.root, txtboxSeansDegisFilm.Text), txtboxSeansDegisGun.Text), txtboxEskiSeans.Text) == null)
                    MessageBox.Show("Belirlenen günde böyle bir seans bulunmamaktadır.");
                else
                {
                    if (!Regex.IsMatch(txtboxYeniSeans.Text.Split(".")[0], "^[0-9]*$") || !Regex.IsMatch(txtboxYeniSeans.Text.Split(".")[1], "^[0-9]*$"))
                        MessageBox.Show("Ekleyeceğiniz seansı sayı kullanarak SAAT . DAKİKA cinsinden giriniz");
                    else if (txtboxYeniSeans.Text.Split(".").Length < 2 || txtboxYeniSeans.Text.Split(".").Length > 2)
                        MessageBox.Show("Ekleyeceğiniz seansı sayı kullanarak SAAT . DAKİKA cinsinden giriniz");
                    else
                    {
                        ArrayList list = tree.IsExist(tree.IsExist(tree.IsExist(tree.root, txtboxSeansDegisFilm.Text), txtboxSeansDegisGun.Text), txtboxEskiSeans.Text).data.Get();
                        list[0] = txtboxYeniSeans.Text;

                        lblSeansDegisSeans.Text = "";
                        foreach (string a in SeanslariSirala(tree.IsExist(tree.IsExist(tree.root, txtboxSeansDegisFilm.Text), txtboxSeansDegisGun.Text)))
                            lblSeansDegisSeans.Text += $"{a}\n";

                        MessageBox.Show("Seans değiştirme işlemi başarılı !");
                    }
                }
            }
        }
    }
}
