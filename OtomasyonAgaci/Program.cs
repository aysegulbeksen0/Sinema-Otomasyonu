using System;
using System.Collections.Generic;
using System.Collections;
/*
 PROJE : Sinema Otomasyonu
    032290001 Ayşegül BEKŞEN
    032290007 Ahmet Eren ÜÇÜNCÜ
    032290036 Alperen TOPAK
    032290085 Enes Berke KARAOĞLAN
    032290034 Emirhan TOZLU
    032290084 Muhammed Kaan KÜÇÜK

DERS KODU : BMB2006
DOSYA ADI : 26_SinemaOtomasyonu
 */
namespace OtomasyonAgaci
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tree tree = DefaultSystem();
            Console.ReadLine();
        }

        public class Node
        {
            public readonly IData data;
            public List<Node> children = new List<Node>();
            public Node(string name, DataType type = DataType.Root,
                string puan = null, string kind = null, string promotion = null)
            {
                if (type == DataType.Film)
                    data = new FilmData(name, puan, kind, promotion);
                else if (type == DataType.Day)
                    data = new DayData(name);
                else if (type == DataType.Seans)
                    data = new SeansData(name);
                else
                    data = null;
            }
        }
        public class Tree
        {
            public Node root;
            public Tree(Node node)
            {
                root = node;
            }
            public void AddNode(Node parent, string name, DataType type = DataType.Root, string puan = null, string kind = null, string promotion = null)
            {
                Node newNode = new Node(name, type, puan, kind, promotion);
                parent.children.Add(newNode);
            }
            public void AddNodes(Node parent, params Node[] nodes)
            {
                foreach (Node a in nodes)
                    parent.children.Add(a);
            }
            public int Remove(Node parent, string name)
            {
                foreach (Node a in parent.children)
                {
                    if (a.data.Get()[0].ToString().ToLower() == name.ToLower())
                    {
                        parent.children.Remove(a);
                        return 1;
                    }
                }
                return -1;
            }
            public Node IsExist(Node parent, string name)
            {
                foreach (Node a in parent.children)
                    if (a.data.Get()[0].ToString().ToLower() == name.ToLower())
                        return a;
                return null;
            }
        }
        public enum DataType
        {
            Root,
            Film,
            Day,
            Seans
        }
        public interface IData
        {
            ArrayList Get(); 
        }
        public class FilmData : IData
        {
            ArrayList list = new ArrayList();
            public FilmData(string name, string puan, string kind, string promotion)
            {
                list.Add(name);  list.Add(puan); list.Add(kind); list.Add(promotion);
            }

            public ArrayList Get()
            {
                return list;
            }
        }
        public class DayData : IData
        {
            ArrayList list = new ArrayList();
            public DayData(string name)
            {
                list.Add(name);
            }
            public ArrayList Get()
            {
                return list;
            }
        }
        public class SeansData : IData
        {
            bool[] seats = new bool[20] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
            ArrayList list = new ArrayList();
            public SeansData(string name)
            {
                list.Add(name); list.Add(seats);
            }
            public ArrayList Get()
            {
                return list;
            }
        }
        public static Tree DefaultSystem()
        {
            //Otomasyon ağacının oluşturulması
            Node root = new Node("Otomasyon");
            Tree tree = new Tree(root);

            //Filmleri tutan düğümlerin oluşturulması
            Node film1 = new Node("Kungfu Panda 3", DataType.Film,
                "7.1",

                "Animasyon / Aksiyon / Macera / Komedi / Aile / Fantastik",

                "Po'nun uzun süredir ortalıkta görünmeyen babası birdenbire " +
                "kendini gösterir ve tekrar bir araya gelen ikili, yepyeni " +
                "panda karakterleriyle tanışmak için gizli bir panda cennetine " +
                "doğru yolculuğa çıkar. Ancak doğaüstü güçlere sahip olan kötü " +
                "kahraman Kai, tüm kung fu efendilerini bozguna uğratmak için " +
                "Çin'i istila etmeye başlar. Po ise imkansız olanı yapmak zorundadır; " +
                "yani Kung Fu Panda çetesinin son hâlini alabilmesi için eğlenmeyi " +
                "seven, sakar erkek kardeşleriyle dolu bir kasabayı eğitmelidir");

            Node film2 = new Node("Sherlock Holmes 2", DataType.Film,
                "7.4",

                "Aksiyon / Macera / Gizem",

                "Dünyanın en ünlü ve zeki dedektiflerinden Sherlock Holmes " +
                "(Robert Downey Jr.) ve 'ortağı' Dr. Watson (Jude Law) bu " +
                "sefer Londra’nın dışına çıkarak Fransa, Almanya ve İsviçre’ye " +
                "yol alacakları yeni ve tehlikeli bir maceraya sürükleniyorlar. " +
                "Onlardan hep bir adım önde olan kurnaz ve vicdansız Profesör " +
                "Moriarty (Jared Harris) ise -ki Holmes en zeki olma unvanını ona " +
                "kaptırmak üzere- büyük bir laneti değiştirecek planların peşindedir. " +
                "Kahramanlarımız ise ne olursa olsun Moriarty durdurmaya kararlı...");

            Node film3 = new Node("Arabalar 3", DataType.Film,
                "6.7",

                "Animasyon / Macera / Komedi / Aile / Spor",

                "Yeni nesil hızlı yarış arabaları tarafından gafil avlanan " +
                "efsanevi Şimşek McQueen, sevdiği sporda aniden bir kenara " +
                "itilmiştir. Oyuna geri dönmek için hevesli genç yarış teknisyeni " +
                "Cruz Ramirez'in yardımına, kazanmak için bir plana, merhum Hudson " +
                "Hornet'in verdiği ilhama ve birkaç beklenmedik numaraya ihtiyacı " +
                "vardır, işinin henüz bitmediğini kanıtlamak, Piston Kupası'nın en " +
                "büyük yarışında bu şampiyonun yüreğini sınayacaktır...");

            Node film4 = new Node("İnanılmaz Örümcek Adam 2", DataType.Film,
                "6.6",

                "Aksiyon / Macera / Fantastik / Bilim Kurgu",

                "Peter Parker'ın hayatı oldukça yoğun. Bir yandan Örümcek " +
                "Adam olarak kötü adamları yakalıyor diğer yandan ise aşkı " +
                "Gwen'le vakit geçiriyordur. Peter, Gwen'ın babasına kızından " +
                "uzak durarak onu koruyacağına dair verdiği sözü de unutmamıştır. " +
                "Fakat bu tutmakta zorlandığı bir sözdür. Kötücül Electro'nun " +
                "ortaya çıkması, eski arkadaşı Harry Osborn geri dönüşü ve Peter'ın " +
                "geçmişine dair yeni ipuçlarının ortaya çıkması Örümcek Adam'ın " +
                "hayatını değiştirecektir.");

            Node film5 = new Node("Dune Part Two", DataType.Film,
                "8.7",

                "Aksiyon / Macera / Dram",

                "İlk filmin sonunda Jamis ile yaptığı kavgadan sonra, Dük " +
                "Paul Atreides ve annesi Lady Jessica, Fremenlere katılır. " +
                "Paul'ün kaderi gerçekleşir ve Muad'Dib olur, bu sırada " +
                "vizyonlarında gördüğü korkunç ama kaçınılmaz geleceği engellemeye çalışır.");

            //Agacın köküne, child olarak filmlerin eklenmesi
            tree.AddNodes(root, film1, film2, film3, film4, film5);

            //Film 1'in günlerini tutan düğümlerin oluşturulması
            Node day1f1 = new Node("3 Nisan", DataType.Day);
            Node day2f1 = new Node("4 Nisan", DataType.Day);
            Node day3f1 = new Node("5 Nisan", DataType.Day);
            Node day4f1 = new Node("6 Nisan", DataType.Day);
            Node day5f1 = new Node("7 Nisan", DataType.Day);

            //Film 2'in günlerini tutan düğümlerin oluşturulması
            Node day1f2 = new Node("3 Nisan", DataType.Day);
            Node day2f2 = new Node("4 Nisan", DataType.Day);
            Node day3f2 = new Node("5 Nisan", DataType.Day);
            Node day4f2 = new Node("6 Nisan", DataType.Day);
            Node day5f2 = new Node("7 Nisan", DataType.Day);

            //Film 3'in günlerini tutan düğümlerin oluşturulması
            Node day1f3 = new Node("3 Nisan", DataType.Day);
            Node day2f3 = new Node("4 Nisan", DataType.Day);
            Node day3f3 = new Node("5 Nisan", DataType.Day);
            Node day4f3 = new Node("6 Nisan", DataType.Day);
            Node day5f3 = new Node("7 Nisan", DataType.Day);

            //Film 4'in günlerini tutan düğümlerin oluşturulması
            Node day1f4 = new Node("3 Nisan", DataType.Day);
            Node day2f4 = new Node("4 Nisan", DataType.Day);
            Node day3f4 = new Node("5 Nisan", DataType.Day);
            Node day4f4 = new Node("6 Nisan", DataType.Day);
            Node day5f4 = new Node("7 Nisan", DataType.Day);

            //Film 5'in günlerini tutan düğümlerin oluşturulması
            Node day1f5 = new Node("3 Nisan", DataType.Day);
            Node day2f5 = new Node("4 Nisan", DataType.Day);
            Node day3f5 = new Node("5 Nisan", DataType.Day);
            Node day4f5 = new Node("6 Nisan", DataType.Day);
            Node day5f5 = new Node("7 Nisan", DataType.Day);

            //Her filme, child olarak günlerin eklenmesi
            tree.AddNodes(root.children[0], day1f1, day2f1, day3f1, day4f1, day5f1);
            tree.AddNodes(root.children[1], day1f2, day2f2, day3f2, day4f2, day5f2);
            tree.AddNodes(root.children[2], day1f3, day2f3, day3f3, day4f3, day5f3);
            tree.AddNodes(root.children[3], day1f4, day2f4, day3f4, day4f4, day5f4);
            tree.AddNodes(root.children[4], day1f5, day2f5, day3f5, day4f5, day5f5);

            //Film 1'in 1. günü için seans düğümlerinin oluşturulması
            Node seans1f1d1 = new Node("09.40", DataType.Seans);
            Node seans3f1d1 = new Node("13.30", DataType.Seans);
            Node seans5f1d1 = new Node("16.00", DataType.Seans);

            //Film 1'in 1. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[0].children[0], seans1f1d1, seans3f1d1, seans5f1d1);

            //Film 1'in 2. günü için seans düğümlerinin oluşturulması
            Node seans1f1d2 = new Node("09.40", DataType.Seans);
            Node seans4f1d2 = new Node("14.50", DataType.Seans);
            Node seans5f1d2 = new Node("16.00", DataType.Seans);

            //Film 1'in 2. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[0].children[1], seans1f1d2, seans4f1d2, seans5f1d2);

            //Film 1'in 3. günü için seans düğümlerinin oluşturulması
            Node seans1f1d3 = new Node("09.40", DataType.Seans);
            Node seans3f1d3 = new Node("13.30", DataType.Seans);
            Node seans4f1d3 = new Node("14.50", DataType.Seans);
            Node seans5f1d3 = new Node("16.00", DataType.Seans);

            //Film 1'in 3. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[0].children[2], seans1f1d3, seans3f1d3, seans4f1d3, seans5f1d3);

            //Film 1'in 4. günü için seans düğümlerinin oluşturulması
            Node seans3f1d4 = new Node("13.30", DataType.Seans);
            Node seans5f1d4 = new Node("16.00", DataType.Seans);

            //Film 1'in 4. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[0].children[3], seans3f1d4, seans5f1d4);

            //Film 1'in 5. günü için seans düğümlerinin oluşturulması
            Node seans1f1d5 = new Node("09.40", DataType.Seans);
            Node seans3f1d5 = new Node("13.30", DataType.Seans);
            Node seans5f1d5 = new Node("16.00", DataType.Seans);

            //Film 1'in 5. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[0].children[4], seans1f1d5, seans3f1d5, seans5f1d5);

            //Film 2'in 1. günü için seans düğümlerinin oluşturulması
            Node seans2f2d1 = new Node("12.00", DataType.Seans);
            Node seans4f2d1 = new Node("14.50", DataType.Seans);

            //Film 2'in 1. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[1].children[0], seans2f2d1, seans4f2d1);

            //Film 2'in 2. günü için seans düğümlerinin oluşturulması
            Node seans1f2d2 = new Node("09.40", DataType.Seans);
            Node seans2f2d2 = new Node("12.00", DataType.Seans);
            Node seans4f2d2 = new Node("14.50", DataType.Seans);

            //Film 2'in 2. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[1].children[1], seans1f2d2, seans2f2d2, seans4f2d2);

            //Film 2'in 3. günü için seans düğümlerinin oluşturulması
            Node seans2f2d3 = new Node("12.00", DataType.Seans);
            Node seans4f2d3 = new Node("14.50", DataType.Seans);

            //Film 2'in 3. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[1].children[2], seans2f2d3, seans4f2d3);

            //Film 2'in 4. günü için seans düğümlerinin oluşturulması
            Node seans1f2d4 = new Node("09.40", DataType.Seans);
            Node seans2f2d4 = new Node("12.00", DataType.Seans);
            Node seans4f2d4 = new Node("14.50", DataType.Seans);

            //Film 2'in 4. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[1].children[3], seans1f2d4, seans2f2d4, seans4f2d4);

            //Film 2'in 5. günü için seans düğümlerinin oluşturulması
            Node seans2f2d5 = new Node("12.00", DataType.Seans);
            Node seans4f2d5 = new Node("14.50", DataType.Seans);

            //Film 2'in 5. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[1].children[4], seans2f2d5, seans4f2d5);

            //Film 3'in 1. günü için seans düğümlerinin oluşturulması
            Node seans3f3d1 = new Node("13.30", DataType.Seans);
            Node seans4f3d1 = new Node("14.50", DataType.Seans);

            //Film 3'in 1. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[2].children[0], seans3f3d1, seans4f3d1);

            //Film 3'in 2. günü için seans düğümlerinin oluşturulması
            Node seans1f3d2 = new Node("09.40", DataType.Seans);
            Node seans2f3d2 = new Node("12.00", DataType.Seans);
            Node seans3f3d2 = new Node("13.30", DataType.Seans);
            Node seans5f3d2 = new Node("16.00", DataType.Seans);

            //Film 3'in 2. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[2].children[1], seans1f3d2, seans2f3d2, seans3f3d2, seans5f3d2);

            //Film 3'in 3. günü için seans düğümlerinin oluşturulması
            Node seans3f3d3 = new Node("13.30", DataType.Seans);
            Node seans4f3d3 = new Node("14.50", DataType.Seans);
            Node seans5f3d3 = new Node("16.00", DataType.Seans);

            //Film 3'in 3. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[2].children[2], seans3f3d3, seans4f3d3, seans5f3d3);

            //Film 3'in 4. günü için seans düğümlerinin oluşturulması
            Node seans1f3d4 = new Node("09.40", DataType.Seans);
            Node seans2f3d4 = new Node("12.00", DataType.Seans);
            Node seans4f3d4 = new Node("14.50", DataType.Seans);

            //Film 3'in 4. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[2].children[3], seans1f3d4, seans2f3d4, seans4f3d4);

            //Film 3'in 5. günü için seans düğümlerinin oluşturulması
            Node seans2f3d5 = new Node("12.00", DataType.Seans);
            Node seans3f3d5 = new Node("13.30", DataType.Seans);
            Node seans4f3d5 = new Node("14.50", DataType.Seans);

            //Film 3'in 5. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[2].children[4], seans2f3d5, seans3f3d5, seans4f3d5);

            //Film 4'in 1. günü için seans düğümlerinin oluşturulması
            Node seans1f4d1 = new Node("09.40", DataType.Seans);
            Node seans2f4d1 = new Node("12.00", DataType.Seans);
            Node seans4f4d1 = new Node("14.50", DataType.Seans);

            //Film 4'in 1. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[3].children[0], seans1f4d1, seans2f4d1, seans4f4d1);

            //Film 4'in 2. günü için seans düğümlerinin oluşturulması
            Node seans3f4d2 = new Node("13.30", DataType.Seans);
            Node seans4f4d2 = new Node("14.50", DataType.Seans);
            Node seans5f4d2 = new Node("16.00", DataType.Seans);

            //Film 4'in 2. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[3].children[1], seans3f4d2, seans4f4d2, seans5f4d2);

            //Film 4'in 3. günü için seans düğümlerinin oluşturulması
            Node seans1f4d3 = new Node("09.40", DataType.Seans);
            Node seans2f4d3 = new Node("12.00", DataType.Seans);

            //Film 4'in 3. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[3].children[2], seans1f4d3, seans2f4d3);

            //Film 4'in 4. günü için seans düğümlerinin oluşturulması
            Node seans1f4d4 = new Node("09.40", DataType.Seans);
            Node seans3f4d4 = new Node("13.30", DataType.Seans);
            Node seans5f4d4 = new Node("16.00", DataType.Seans);

            //Film 4'in 4. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[3].children[3], seans1f4d4, seans3f4d4, seans5f4d4);

            //Film 4'in 5. günü için seans düğümlerinin oluşturulması
            Node seans1f4d5 = new Node("09.40", DataType.Seans);
            Node seans4f4d5 = new Node("14.50", DataType.Seans);
            Node seans5f4d5 = new Node("16.00", DataType.Seans);

            //Film 4'in 5. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[3].children[4], seans1f4d5, seans4f4d5, seans5f4d5);

            //Film 5'in 1. günü için seans düğümlerinin oluşturulması
            Node seans1f5d1 = new Node("09.40", DataType.Seans);
            Node seans3f5d1 = new Node("13.30", DataType.Seans);
            Node seans5f5d1 = new Node("16.00", DataType.Seans);

            //Film 5'in 1. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[4].children[0], seans1f5d1, seans3f5d1, seans5f5d1);

            //Film 5'in 2. günü için seans düğümlerinin oluşturulması
            Node seans2f5d2 = new Node("12.00", DataType.Seans);
            Node seans3f5d2 = new Node("13.30", DataType.Seans);

            //Film 5'in 2. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[4].children[1], seans2f5d2, seans3f5d2);

            //Film 5'in 3. günü için seans düğümlerinin oluşturulması
            Node seans1f5d3 = new Node("09.40", DataType.Seans);
            Node seans2f5d3 = new Node("12.00", DataType.Seans);
            Node seans3f5d3 = new Node("13.30", DataType.Seans);
            Node seans5f5d3 = new Node("16.00", DataType.Seans);

            //Film 5'in 3. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[4].children[2], seans1f5d3, seans2f5d3, seans3f5d3, seans5f5d3);

            //Film 5'in 4. günü için seans düğümlerinin oluşturulması
            Node seans2f5d4 = new Node("12.00", DataType.Seans);
            Node seans3f5d4 = new Node("13.30", DataType.Seans);

            //Film 5'in 4. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[4].children[3], seans2f5d4, seans3f5d4);

            //Film 5'in 5. günü için seans düğümlerinin oluşturulması
            Node seans1f5d5 = new Node("09.40", DataType.Seans);
            Node seans3f5d5 = new Node("13.30", DataType.Seans);
            Node seans5f5d5 = new Node("16.00", DataType.Seans);

            //Film 5'in 5. gününe, child olarak seansların eklenmesi
            tree.AddNodes(root.children[4].children[4], seans1f5d5, seans3f5d5, seans5f5d5);

            return tree;
        }

    }
}
