using System.Collections.Generic;
/*
 PROJE : Sinema Otomasyonu
    032290001 Ayşegül BEKŞEN
    032290007 Ahmet Eren ÜÇÜNCÜ
    032290036 Alperen TOPAK
    032290085 Enes Berke KARAOĞLAN
    032290034 Emirhan TOZLU
    032290084 Muhammed Kaan KÜÇÜK

DERS KODU : BMB2006
DOSYA ADI : 26_SinemaOtomasyonu*/
namespace FilmBilgileri
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
        public class Node
        {
            public string name, puan, kind, promotion;
            public Node before, after;
            public Node(string name, string puan, string kind, string promotion)
            {
                this.name = name;
                this.puan = puan;
                this.kind = kind;
                this.promotion = promotion;
                before = after = null;
            }
        }
        public class LinkedList
        {
            public Node head, tail;
            public LinkedList()
            {
                head = tail = null;
            }
            public void AddLast(LinkedList list, string name, string puan, string kind, string promotion)
            {
                Node newNode = new Node(name, puan, kind, promotion);
                if (list.tail == null)
                {
                    list.head = list.tail = newNode;
                    newNode.after = newNode.before = newNode;
                }
                else
                {
                    list.tail.after = newNode;
                    newNode.before = list.tail;
                    list.tail = newNode;
                    list.tail.after = list.head;
                    list.head.before = list.tail;
                }
            }
            public int Count(LinkedList list)
            {
                int count = 1;
                Node temp = list.head.after;
                while (temp != list.head)
                {
                    count++;
                    temp = temp.after;
                }
                return count;
            }
        }
        public static LinkedList DefaultSystem()
        {
            LinkedList list = new LinkedList();
            OtomasyonAgaci.Program.Tree tree = OtomasyonAgaci.Program.DefaultSystem();

            foreach (OtomasyonAgaci.Program.Node a in tree.root.children)
                list.AddLast(list, a.data.Get()[0].ToString(), a.data.Get()[1].ToString(), a.data.Get()[2].ToString(), a.data.Get()[3].ToString());

            return list;
        }
    }


}
