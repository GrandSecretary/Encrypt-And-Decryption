using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    internal class Program
    {
        /// <summary>
        /// показує масив з даних
        /// </summary>
        /// <param name="array">Масив, який треба показати</param>
        static void ShowArray(string[] array)
        {
            foreach(var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// S-блокове шифрування
        /// </summary>
        /// <param name="binary">Масив бітів, які треба зашифрувати</param>
        /// <returns>Зашифрований масив бітів</returns>
        static string[] S_BlockEncryption(string[] binary)
        {
            string[] tetrads = new string[binary.Length * 2]; //оголошення масив тетрадів
            //розбиття блоки бітів у тетради по 4 біти
            for (int i = 0, j = 0; i < binary.Length; i++, j+=2)
            {
                tetrads[j] = binary[i].Substring(0, binary[i].Length / 2);
                tetrads[j + 1] = binary[i].Substring(binary[i].Length / 2);
            }
            //оголошення нового масиву шифрованих тетрадів
            string[] newTetrads = new string[tetrads.Length]; 

            for (int i = 0; i < tetrads.Length; i++)//процес S-блокового шифрування
            {
                switch (tetrads[i])
                {
                    case "0000": newTetrads[i] = "1010"; break;
                    case "0001": newTetrads[i] = "0100"; break;
                    case "0010": newTetrads[i] = "0111"; break;
                    case "0011": newTetrads[i] = "0011"; break;
                    case "0100": newTetrads[i] = "1101"; break;
                    case "0101": newTetrads[i] = "1011"; break;
                    case "0110": newTetrads[i] = "1111"; break;
                    case "0111": newTetrads[i] = "1110"; break;
                    case "1000": newTetrads[i] = "0110"; break;
                    case "1001": newTetrads[i] = "1000"; break;
                    case "1010": newTetrads[i] = "0010"; break;
                    case "1011": newTetrads[i] = "0000"; break;
                    case "1100": newTetrads[i] = "0101"; break;
                    case "1101": newTetrads[i] = "0001"; break;
                    case "1110": newTetrads[i] = "1001"; break;
                    case "1111": newTetrads[i] = "1100"; break;

                }
            }
            //оголошення нового масиву бінарних бітів в текстовому представленні
            string[] newBinary = new string[binary.Length];
            //об'єдання тетрадів в 8 бітні блоки 
            for (int i = 0, j = 0; i < binary.Length; i++, j += 2)
            {
                newBinary[i] = newTetrads[j] + newTetrads[j + 1];
            }

            return newBinary;
        }
        /// <summary>
        /// P-блокове шифрування
        /// </summary>
        /// <param name="binary">Масив бітів, які треба зашифрувати</param>
        /// <returns>Зашифрований масив бітів</returns>
        static string[] P_BlockEncryption(string[] binary)
        {
            //оголошення нового масиву бінарних бітів в текстовому представленні 
            string[] newBinary = new string[binary.Length];

            //процес P-блокового шифрування
            for (int i = 0; i < binary.Length; i++)
            {
                char[] bits = new char[8];
                for (int j = 0; j < binary[i].Length; j++)
                {
                    
                    switch (j)
                    {
                        case 0: bits[1] = binary[i][j]; break;
                        case 1: bits[7] = binary[i][j]; break;
                        case 2: bits[2] = binary[i][j]; break;
                        case 3: bits[5] = binary[i][j]; break;
                        case 4: bits[0] = binary[i][j]; break;
                        case 5: bits[3] = binary[i][j]; break;
                        case 6: bits[6] = binary[i][j]; break;
                        case 7: bits[4] = binary[i][j]; break;
                    }
                    
                }
                newBinary[i] = new string(bits);
            }
            
            return newBinary;
        }
        /// <summary>
        /// P-блокове дешифрування
        /// </summary>
        /// <param name="binary">Масив бітів, які треба дешифрувати</param>
        /// <returns>Дешифрований масив бітів</returns>
        static string[] P_BlockDecryption(string[] binary)
        {
            //оголошення нового масиву бінарних бітів в текстовому представленні
            string[] newBinaty = new string[binary.Length];

            //процес P-блокового дешифрування
            for (int i = 0; i < binary.Length; i++)
            {
                char[] bits = new char[8];
                for (int j = 0; j < binary[i].Length; j++)
                {

                    switch (j)
                    {
                        case 0: bits[4] = binary[i][j]; break;
                        case 1: bits[0] = binary[i][j]; break;
                        case 2: bits[2] = binary[i][j]; break;
                        case 3: bits[5] = binary[i][j]; break;
                        case 4: bits[7] = binary[i][j]; break;
                        case 5: bits[3] = binary[i][j]; break;
                        case 6: bits[6] = binary[i][j]; break;
                        case 7: bits[1] = binary[i][j]; break;
                    }

                }
                newBinaty[i] = new string(bits);
            }

            return newBinaty;
        }
        /// <summary>
        /// S-блокове дешифрування
        /// </summary>
        /// <param name="binary">Масив бітів, які треба дешифрувати</param>
        /// <returns>Дешифрований масив бітів</returns>
        static string[] S_BlockDecryption(string[] binary)
        {
            string[] tetrads = new string[binary.Length * 2];//оголошення масив тетрадів
            //розбиття блоки бітів у тетради по 4 біти

            for (int i = 0, j = 0; i < binary.Length; i++, j += 2)
            {
                tetrads[j] = binary[i].Substring(0, binary[i].Length / 2);
                tetrads[j + 1] = binary[i].Substring(binary[i].Length / 2);
            }
            //оголошення нового масиву шифрованих тетрадів
            string[] newTetrads = new string[tetrads.Length];

            for (int i = 0; i < tetrads.Length; i++)//процес S-блокового шифрування
            {
                switch (tetrads[i])
                {
                    case "0000": newTetrads[i] = "1011"; break;
                    case "0001": newTetrads[i] = "1101"; break;
                    case "0010": newTetrads[i] = "1010"; break;
                    case "0011": newTetrads[i] = "0011"; break;
                    case "0100": newTetrads[i] = "0001"; break;
                    case "0101": newTetrads[i] = "1100"; break;
                    case "0110": newTetrads[i] = "1000"; break;
                    case "0111": newTetrads[i] = "0010"; break;
                    case "1000": newTetrads[i] = "1001"; break;
                    case "1001": newTetrads[i] = "1110"; break;
                    case "1010": newTetrads[i] = "0000"; break;
                    case "1011": newTetrads[i] = "0101"; break;
                    case "1100": newTetrads[i] = "1111"; break;
                    case "1101": newTetrads[i] = "0100"; break;
                    case "1110": newTetrads[i] = "0111"; break;
                    case "1111": newTetrads[i] = "0110"; break;

                }
            }
            //оголошення нового масиву бінарних бітів в текстовому представленні
            string[] newBinary = new string[binary.Length];
            //об'єдання тетрадів в 8 бітні блоки 
            for (int i = 0, j = 0; i < binary.Length; i++, j += 2)
            {
                newBinary[i] = newTetrads[j] + newTetrads[j + 1];
            }

            return newBinary;
        }
        
        static void Main(string[] args)
        {
            

            Console.Write("Enter the text you want to encrypt: ");
            string text = Console.ReadLine();
            
            //отримання байтів з тексту
            byte[] bytes = Encoding.UTF8.GetBytes(text); 
            
            //масив бітів в текстовому представленні
            string[] binaryCodes = new string[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                //конвертація байту в послідовність бітів
                binaryCodes[i] = Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }

            binaryCodes = S_BlockEncryption(binaryCodes);
            
            binaryCodes = P_BlockEncryption(binaryCodes);
            Console.Write("Encrypted bits: "); ShowArray(binaryCodes);

            // Об'єднання двійкових кодів в одну строку
            string binaryString = string.Join("", binaryCodes);

            // Перетворення двійкової строки в масив байтів
            bytes = new byte[binaryString.Length / 8];
            for (int i = 0; i < bytes.Length; i++)
            {
                string binaryByte = binaryString.Substring(i * 8, 8);
                bytes[i] = Convert.ToByte(binaryByte, 2);
            }
            
            //перетворення масиву з байтів в шифр-текст
            string encryptedText = Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Ciphertext: " + encryptedText);

            binaryCodes = P_BlockDecryption(binaryCodes);

            binaryCodes = S_BlockDecryption(binaryCodes);

            Console.Write("Decrypted bits: "); ShowArray(binaryCodes);
            // Об'єднання двійкових кодів в одну строку
            binaryString = string.Join("", binaryCodes);

            // Перетворення двійкової строки в масив байтів
            bytes = new byte[binaryString.Length / 8];
            for (int i = 0; i < bytes.Length; i++)
            {
                string binaryByte = binaryString.Substring(i * 8, 8);
                bytes[i] = Convert.ToByte(binaryByte, 2);
            }

            //перетворення масиву з байтів у відкритий текст
            encryptedText = Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Plain text: " + encryptedText);
        }
    }
}
