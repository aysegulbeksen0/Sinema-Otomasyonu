using System;
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
namespace KullaniciGirisi
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
        public class Node
        {
            public string username;
            public string password;
            public Node after;
            public Node(string username, string password)
            {
                this.username = username;
                this.password = password;
                after = null;
            }
        }
        public class LinkedList
        {
            public Node head, tail;
            public LinkedList()
            {
                head = tail = null;
            }
            public void AddLast(LinkedList list, string username, string password)
            {
                Node newNode = new Node(username, password);
                if (list.tail == null)
                    list.head = list.tail = newNode; 
                else
                {
                    list.tail.after = newNode; 
                    list.tail = newNode; 
                }
            }
            public int DeleteFirst(LinkedList list)
            {
                if (list.head == null) 
                    throw new Exception("Liste zaten boş...");
                else
                {
                    list.head = list.head.after;
                    return 1;
                }
            }
            public int DeleteLast(LinkedList list)
            {
                if (list.tail == null) 
                    throw new Exception("Liste zaten boş...");
                else
                {
                    Node temp = list.head;
                    while (temp.after.after != null)
                        temp = temp.after;
                    list.tail = temp; 
                    list.tail.after = null; 
                    return 1;
                }
            }
            public int Delete(LinkedList list, string name)
            {
                Node temp = list.head; 
                if (list.head.username == name) 
                    return DeleteFirst(list);
                else if (list.tail.username == name) 
                    return DeleteLast(list);
                else
                {
                    while (temp.after != null)
                        if (temp.after.username != name)
                            temp = temp.after;
                        else
                            break;
                    if (temp.after == null) 
                        return -1;
                    else
                    {
                        temp.after = temp.after.after;
                        return 1;
                    }
                }
            }

            
            public string PrintList(LinkedList list)
            {
                string print = "";
                Node temp = list.head; 
                while (temp != null) 
                {
                    print += temp.username + "|" + temp.password + " - "; 
                    temp = temp.after; 
                }
                return print;
            }
        }
        public static LinkedList DefaultSystem()
        {
            LinkedList list = new LinkedList();
            list.AddLast(list, "admin", "0000");
            list.AddLast(list, "aysegul", "1234");
            return list;
        }
    }


}
