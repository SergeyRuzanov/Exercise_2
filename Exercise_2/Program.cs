using System;
using System.IO;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = Environment.CurrentDirectory + "\\INPUT.txt";
            string pathOutput = Environment.CurrentDirectory + "\\OUTPUT.txt";
            string strInput;
            string lenghtStr;

            try
            {
                using (StreamReader sr = new StreamReader(pathInput))
                {
                    lenghtStr = sr.ReadLine();
                    strInput = sr.ReadLine();
                }

                string[] masStr = strInput.Split(' ');
                int[] numInput = new int[int.Parse(lenghtStr)];

                for (int i = 0; i < masStr.Length; i++)
                {
                    numInput[i] = int.Parse(masStr[i]);
                }

                bool leftMax = false;
                bool rightMax = false;
                for (int i = 1; i < numInput.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (numInput[j] > numInput[i])
                        {
                            leftMax = true;
                            break;
                        }
                    }
                    for (int k = i + 1; k < numInput.Length; k++)
                    {
                        if (numInput[k] > numInput[i])
                        {
                            rightMax = true;
                            break;
                        }
                    }
                    if (leftMax && rightMax)
                    {
                        int[] newNumInput = new int[numInput.Length - 1];
                        for (int j = 0; j < i; j++)
                        {
                            newNumInput[j] = numInput[j];
                        }
                        for (int k = i + 1; k < numInput.Length; k++)
                        {
                            newNumInput[k - 1] = numInput[k];
                        }
                        numInput = newNumInput;
                        i--;
                    }
                    leftMax = false;
                    rightMax = false;
                }

                using (StreamWriter sw = new StreamWriter(pathOutput, false))
                {
                    sw.WriteLine(numInput.Length);
                    foreach (int num in numInput)
                    {
                        sw.Write(num + " ");
                    }
                }
                Console.WriteLine("Преобразование выполнено успешно.");
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл INPUT.txt не найден.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка преобразования. Проверьте входные данные.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
    }
}
