using System;
using System.Collections.Generic;


namespace Practic2.Cesar
{
    class Program
    {
        static bool Choise(string choise)
        {
            if (choise == "1" || choise.ToLower() == "зашифровать")
            { return true; }
            else
                return false;
        }
        static int Encryption(int shift, char symbol, int countalf)
        {
            return symbol + shift - countalf;
        }
        static int Decryption(int shift, char symbol, int countalf)
        {
            return symbol - shift + countalf;
        }
        static bool IsLowerCaseLetter(char symbol)
        {
            if (symbol.ToString() == symbol.ToString().ToLower())
            { return true; }
            return false;
        }

        static int DefineLanguage(char symbol)
        {
            int alphabetRus = 32;
            int alphabetEng = 26;
            int alphabetNum = 10;
            int sign = 0;
            if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
            { return alphabetEng; }
            else if ((symbol >= 'А' && symbol <= 'Я') || (symbol >= 'а' && symbol <= 'я'))
            { return alphabetRus; }
            else if (symbol >= '0' && symbol <= '9')
            { return alphabetNum; }
            else
                return sign;
        }

        static char DefineLastLetter(int language, bool register)
        {
            if (language == 26 && register == false)
            { return 'Z'; }
            else if (language == 26)
            { return 'z'; }
            else if (language == 32 && register == false)
            { return 'Я'; }
            else if (language == 32)
            { return 'я'; }
            else
            { return '9'; }
        }
        static char DefineFirstLetter(int language, bool register)
        {
            if (language == 26 && register == false)
            { return 'A'; }
            else if (language == 26)
            { return 'a'; }
            else if (language == 32 && register == false)
            { return 'А'; }
            else if (language == 32)
            { return 'а'; }
            else
            { return '0'; }
        }

        static string CipherCoding(string originalText, int shift, bool choise)
        {
            List<char> cipher = new List<char>();
            foreach (char symbol in originalText)
            {
                if (symbol == ' ')
                {
                    cipher.Add(' ');
                    continue;
                }
                bool register = IsLowerCaseLetter(symbol);
                int language = DefineLanguage(symbol);
                if (language == 0)
                { continue; }
                if (choise)
                {
                    if (symbol + shift > DefineLastLetter(language, register))
                    { cipher.Add((char)Encryption(shift, symbol, language)); }
                    else
                    { cipher.Add((char)(symbol + shift)); }
                }
                else
                {
                    if (symbol - shift < DefineFirstLetter(language, register))
                    { cipher.Add((char)Decryption(shift, symbol, language)); }
                    else
                    { cipher.Add((char)(symbol - shift)); }
                }
            }
            return string.Join("", cipher.ToArray());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Что вы хотите сделать? зашифровать(1)/дешифровать(0)");
            string choise = Console.ReadLine();
            Console.WriteLine("Введите текст, который хотите зашифровать.");
            string originalText = Console.ReadLine();
            Console.WriteLine("Введите сдвиг.");
            int shift = int.Parse(Console.ReadLine());
            Console.WriteLine(CipherCoding(originalText, shift, Choise(choise)));
            Console.ReadLine();
        }
    }
}

