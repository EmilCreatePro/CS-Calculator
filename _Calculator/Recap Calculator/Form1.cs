using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Recap_Calculator
{
    public partial class Form1 : Form
    {

        double rez = 0; // acesta va retine si afisa rezultaul final
        string operatii = ""; // acesta va retine ce operatie folosesc(ex: adunare, scadere...)
        bool esteOperator = false; // acesta ne va indica daca un operator este folosit (daca da atunci textBoxRez se sterge)
        double valoare = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
           Button button = (Button)sender; // se acca butonul pt a-i folosi textul pt inserarea dateloreseaz

            if ((textBoxRez.Text == "0") || (esteOperator)) textBoxRez.Clear(); // se sterge daca se introduc valori noi

            esteOperator = false; // operatorul nu mai este folosit

            if(button.Text==",")  // daca este tastat butonul "," pt a se introduce valori zecimale
            {
                if (!textBoxRez.Text.Contains(","))    // se verifica daca a fost deja introdus virgula pt numarul zecimal
                    textBoxRez.Text = textBoxRez.Text + button.Text; // daca nu a fost introdusa deja o virgula, se introduce acum
            }
            else textBoxRez.Text = textBoxRez.Text + button.Text; // daca nu a fost apasat "," nu e nevoie de verificari
            //valoare = Convert.ToDouble(button.Text);
            
        }

       
        
        private void operatii_click(object sender, EventArgs e)
        {
            Button button = (Button) sender;    // se acca butonul pt a-i folosi textul pt inserarea dateloreseaz
            operatii = button.Text; // variabila operatii prelueaza valoarea semnului apasat
            esteOperator = true; // operator a fost folosit
            rez = Convert.ToDouble(textBoxRez.Text);    // rez preia valoarea din textBoxRez si valabil oricand deaorece acolo va fi afisat mereu rezultaul final
            if (operatii== "√" || operatii =="lg") // daca operatia este "√" sau "lg" se va afisa operatia ce are loc in label corespunzator
                    label1.Text = operatii +" " + rez;
            else label1.Text = rez + " " + operatii;
        
        }

        private void button17_Click(object sender, EventArgs e) // sterge tot
        {
            textBoxRez.Text = "0";
            rez = 0;
            label1.Text = " ";
        }

        private void sterge(object sender, EventArgs e)
        {
            double del = Convert.ToDouble(textBoxRez.Text);
            if (del == Math.Floor(del))
            {
                del /= 10;
                del = Math.Floor(del);
                textBoxRez.Text = Convert.ToString(del);
            }
            else { del = Math.Floor(del); textBoxRez.Text = Convert.ToString(del); }
        }
        
        private void button18_Click(object sender, EventArgs e) // rezultaul ramane dar se sterge nr introdus
        {
            textBoxRez.Text = "0";
        }

        private void button19_Click(object sender, EventArgs e) // calculul efectiv pentru rezultat
        {
            switch (operatii)
            {
                case "+":
                    {
                        textBoxRez.Text = (rez + Convert.ToDouble(textBoxRez.Text)).ToString();
                        break;
                    }
                case "-":
                    {
                        textBoxRez.Text = (rez - Convert.ToDouble(textBoxRez.Text)).ToString();
                        break;
                    }
                case "/":
                    {
                        textBoxRez.Text = (rez / Convert.ToDouble(textBoxRez.Text)).ToString();
                        break;
                    }
                case "X":
                    {
                        textBoxRez.Text = (rez * Convert.ToDouble(textBoxRez.Text)).ToString();
                        break;
                    }
                case "√":
                    {
                        textBoxRez.Text = (Math.Sqrt(rez)).ToString();
                        break;
                    }
                case "^":
                    {
                        rez = Math.Pow(rez, Convert.ToDouble(textBoxRez.Text));
                        textBoxRez.Text = rez.ToString();
                        break;
                    }
                case "%":
                    {
                        textBoxRez.Text = (rez % Convert.ToDouble(textBoxRez.Text)).ToString();
                        break;
                    }

                case "!":
                    {
                        double fact = 1;
                        for (double i = 1; i <= rez; i++)
                            fact = fact * i;
                        rez = fact;
                            textBoxRez.Text = rez.ToString();
                        break;
                    }

                case "lg":
                    {
                        textBoxRez.Text = (Math.Log10(Convert.ToDouble(textBoxRez.Text))).ToString();
                        break;
                    }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




    }
}
