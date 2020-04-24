using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WyrazenieLambda
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int podstawa = int.Parse(Par1_TB.Text);
            int wykladnik = int.Parse(Par2_TB.Text);
            int potega(int x, int n) => (int)Math.Pow(x, n);
            wynik_LB.Text = potega(podstawa, wykladnik).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sklejTam() => Par1_TB.Text + Par2_TB.Text;
            wynik_LB.Text = sklejTam();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Func<int, int>[] potega = new Func<int, int>[10];
            int[] index = new int[potega.Length];
            for (int i = 0; i < potega.Length; i++)
            {
                index[i] = i;
            }
            for (int i = 0; i < potega.Length; i++)
            {
                potega[i] = (int x) => {
                    int n = i;
                    return (int)Math.Pow(x, n);
                };
            }
            wynik_LB.Text = potega[int.Parse(Par2_TB.Text)](int.Parse(Par1_TB.Text)).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Func<int, string, string> łańcuch = (int n, string znak) =>
            {
                string wynik = znak.ToString();
                for (int i = 1; i < n; i++)
                {
                    wynik += znak.ToString();
                }
                return wynik;
            };
            wynik_LB.Text = łańcuch(int.Parse(Par1_TB.Text), Par2_TB.Text);
        }

        public delegate int porownajLiczby(int a, int b);
        public delegate int porownajNapisy(string a, string b);

        public void sortuj(int[] tablica, porownajLiczby delegat)
        {
            int tmp;
            int n = tablica.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (delegat(tablica[i], tablica[i + 1]) < 0)
                    {
                        tmp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = tmp;
                    }
                }
                n--;
            } while (n > 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] wartosci = Par1_TB.Text.Split(' ');
            int[] kolekcja = new int[wartosci.Length];
            for (int i = 0; i < wartosci.Length; i++)
            {
                kolekcja[i] = int.Parse(wartosci[i]);
            }

            porownajLiczby por = (int x, int y) => {
                if (x > y)
                    return 1;
                else if (y > x)
                    return -1;
                else
                    return 0;
            };

            sortuj(kolekcja, por);

            wynik_LB.Text = null;
            foreach (int item in kolekcja)
            {
                wynik_LB.Text += item.ToString() + " ";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string[] wartosci = Par1_TB.Text.Split(' ');
            int[] kolekcja = new int[wartosci.Length];
            for (int i = 0; i < wartosci.Length; i++)
            {
                kolekcja[i] = int.Parse(wartosci[i]);
            }

            porownajLiczby por = (int x, int y) => {
                if (x > y)
                    return -1;
                else if (y > x)
                    return 1;
                else
                    return 0;
            };

            sortuj(kolekcja, por);

            wynik_LB.Text = null;
            foreach (int item in kolekcja)
            {
                wynik_LB.Text += item.ToString() + " ";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] wartosci = Par1_TB.Text.Split(' ');
            porownajNapisy por = (string x, string y) => {
                return x.CompareTo(y);
            };

            sortuj(wartosci, por);
            wynik_LB.Text = null;
            foreach (string item in wartosci)
            {
                wynik_LB.Text += item.ToString() + " ";
            }
        }

        public void sortuj(string[] tablica, porownajNapisy delegat)
        {
            string tmp;
            int n = tablica.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (delegat(tablica[i], tablica[i + 1]) > 0)
                    {
                        tmp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = tmp;
                    }
                }
                n--;
            } while (n > 1);
        }

        delegate string dlaLambdy();

        private dlaLambdy Lambda()
        {
            dlaLambdy pyk = () => "Hello World";
            return pyk;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dlaLambdy lambda = Lambda();
            wynik_LB.Text = lambda();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] wyrazenie = Par1_TB.Text.Split(' ');
            int[] kolekcja = new int[wyrazenie.Length];
            
            for(int i=0; i<wyrazenie.Length; i++)
            {
                kolekcja[i] = int.Parse(wyrazenie[i]);
            }
            int[] podzielonaKolekcja = new int[wyrazenie.Length];
            for (int i = 0, j = wyrazenie.Length - 1, m = 0; m<wyrazenie.Length; m++)
            {
                if (kolekcja[m] % 2 == 0)
                {
                    podzielonaKolekcja[i] = kolekcja[m];
                    i++;
                }
                else
                {
                    podzielonaKolekcja[j] = kolekcja[m];
                    j--;
                }
            }

            porownajLiczby por = (int x, int y) => {
                if (x > y)
                    return -1;
                else if (y > x)
                    return 1;
                else
                    return 0;
            };
            int indexParzystej =0;
            for (int i = 0; i < podzielonaKolekcja.Length; i++)
            {
                if (podzielonaKolekcja[i] % 2 == 0)
                {
                    indexParzystej = i;
                }
            }

            sortuj(podzielonaKolekcja, por, 0, indexParzystej);
            sortuj(podzielonaKolekcja, por, indexParzystej + 1, podzielonaKolekcja.Length-1);
            wynik_LB.Text = null;
            foreach (int item in podzielonaKolekcja)
            {
                wynik_LB.Text += item.ToString() + " ";
            }
        }

        public void sortuj(int[] tablica, porownajLiczby delegat, int startIndex, int endIndex)
        {
            int tmp;
            do
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (delegat(tablica[i], tablica[i + 1]) < 0)
                    {
                        tmp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = tmp;
                    }
                }
                endIndex--;
            } while (endIndex > startIndex);
        }
    }
}
