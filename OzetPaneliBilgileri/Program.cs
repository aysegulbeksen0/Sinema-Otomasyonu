using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
namespace OzetPaneliBilgileri
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public class Node
        {
            public string data;
            public Node next;
            public Node(string data)
            {
                this.data = data;
                next = null;
            }
        }
        public class Queue
        {
            public Node head, tail;
            public Queue()
            {
                head = tail = null;
            }
            
            //Kuyruğun sonuna eleman ekleyen metot
            public void EnQueue(Queue queue, string data)
            {
                Node newNode = new Node(data);
                if(queue.tail == null)
                    queue.head = queue.tail = newNode;
                else
                {
                    queue.tail.next = newNode;
                    queue.tail = newNode;
                }

            }

            //kuyruğun başındaki elemanı çekip silen metot
            public string DeQueue(Queue queue)
            {
                if (queue.head == null)
                    return null;
                else
                {
                    Node temp = queue.head;
                    queue.head = queue.head.next;
                    if (queue.head == null)
                        queue.tail = null;
                    return temp.data;
                }
            }
        }
    }
}
