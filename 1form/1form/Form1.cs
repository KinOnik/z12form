using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        class myStr
        {
            private StringBuilder Line;
            private int n;

            public myStr(string bufstr, int bufN)
            {
                Line = new StringBuilder(bufstr);
                if (Line.Length < bufN)
                {
                    n = Line.Length;
                }
                else
                {
                    n = bufN;
                }
                Line.Remove(n, Line.Length - n);
            }
            public myStr(string bufstr)
            {
                Line = new StringBuilder(bufstr);
                n = Line.Length;

                Line.Remove(n, Line.Length - n);
            }
            public int countSpace()
            {
                int buf = 0;
                for (int i = 0; i < n; i++)
                {
                    if (Line[i] == ' ')
                    {
                        buf++;
                    }
                }
                return buf;
            }
            public void goToUpper()
            {
                Line.Replace(Line.ToString(), Line.ToString().ToUpper());
            }
            public void deleteSymbol()
            {
                char[] buf = { '.', ',', '!', '?', ':', ';', '\\', '\'', '\"', '(', ')', '&', '*', '`', '[', ']', '{', '}', '|', '`' };
                for (int i = 0; i < buf.Length; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Line[j] == buf[i])
                        {
                            Line.Remove(j, 1);
                            n--;
                        }
                    }
                }
            }


            public int N
            {
                get
                {
                    return Line.Length;
                }
            }

            public string Lines
            {
                get
                {
                    return Line.ToString();
                }
                set
                {
                    Line = new StringBuilder(value);
                    n = Line.Length;
                }
            }





            //12:
            //a) индексатор
            public char this[int index]
            {
                get
                {
                    return Line[index];
                }
            }

            //b перегрузки
            //операции унарного + (-): преобразующей строку к строчным(прописным) 
            public static string operator +(myStr str)
            {
                return str.Line.ToString().ToLower();
            }
            public static string operator -(myStr str)
            {
                return str.Line.ToString().ToUpper();
            }

            // констант true и false: обращение к экземпляру класса дает значение true, если строка не пустая, иначе false
            public static bool operator true(myStr str)
            {
                if (str.Line.Length != 0)
                    return true;
                return false;
            }
            public static bool operator false(myStr str)
            {
                if (str.Line.Length == 0)
                    return true;
                return false;
            }

            //операции &: возвращает значение true, если строковые поля двух объектов посимвольно равны(без учета регистра), иначе false
            public static bool operator &(myStr str1, myStr str2)
            {
                return str1.Line.ToString().ToLower().Equals(str2.Line.ToString().ToLower());
            }

            //преобразования класса-строка в тип string (и наоборот)
            public static explicit operator string(myStr str)
            {
                return str.Line.ToString();
            }

            public static explicit operator myStr(string str)
            {
                return new myStr(str);
            }


            //вывод, для проверки строки
            public string printMyStr()
            {
                return ($"\n\t{Line.ToString()}\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myStr strInd = new myStr("текст для индексов");
            richTextBox1.Text = ($"\tОбращение к элементам по индексам (2, 7, 12) в строке \"{strInd.Lines}\": \n\t\t({strInd[2]}, {strInd[7]}, {strInd[12]})\n");

            myStr strPLUS = new myStr("БОЛЬШОЙ ТЕКСТ (ПРИВОД К строчным) +");
            richTextBox1.Text +=($"\n\tСтрока до изменения: {strPLUS.Lines}\n\tСтрока после изменения: {+strPLUS}\n");

            myStr strMINUS = new myStr("маленький текст (привод к ПРОПИСНЫМ) -");
            richTextBox1.Text +=($"\n\tСтрока до изменения: {strMINUS.Lines}\n\tСтрока после изменения: {-strMINUS}\n");

            myStr strnull = new myStr("");
            if (strnull)
            {
                richTextBox1.Text +=("\n\tСтрока strnull не пустая.\n");
            }
            else
            {
                richTextBox1.Text +=("\n\tСтрока strnull пустая.\n");
            }

            myStr strNOnull = new myStr("Не пустая");
            if (strNOnull)
            {
                richTextBox1.Text +=("\n\tСтрока strNOnull не пустая.\n");
            }
            else
            {
                richTextBox1.Text +=("\n\tСтрока strNOnull пустая.\n");
            }


            myStr str1 = new myStr("Строка для сравнений");
            myStr str2 = new myStr("Строка для сравнений");
            myStr str3 = new myStr("Строка для сравнений версия 2");
            myStr str4 = new myStr("Строка ДЛЯ СРАВНЕНИЙ версия 2");

            richTextBox1.Text +=($"\n\t \"{str1.Lines}\" & \"{str2.Lines}\" = {str1 & str2}\n");
            richTextBox1.Text +=($"\n\t \"{str1.Lines}\" & \"{str3.Lines}\" = {str1 & str3}\n");
            richTextBox1.Text +=($"\n\t \"{str3.Lines}\" & \"{str4.Lines}\" = {str3 & str4}\n");


            myStr strReturn = new myStr("Из myStr в string");
            string stringReturnStr = (string)strReturn;

            richTextBox1.Text +=($"\n\t myStr преобразованный в string: {stringReturnStr}\n");


            string myStrReturn = "Из string в myStr";
            myStr strReturnMyStr = (myStr)myStrReturn;
            richTextBox1.Text +=($"\n\t string преобразованный в myStr: {strReturnMyStr.Lines}\n");

        }
    }
}