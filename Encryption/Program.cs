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
        static void ShowArray(string[] array)
        {
            foreach(var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static string[] S_BlockEncryption(string[] binary)
        {
            string[] tetrads = new string[binary.Length * 2];

            for (int i = 0, j = 0; i < binary.Length; i++, j+=2)
            {
                tetrads[j] = binary[i].Substring(0, binary[i].Length / 2);
                tetrads[j + 1] = binary[i].Substring(binary[i].Length / 2);
            }

            string[] newTetrads = new string[tetrads.Length];

            for (int i = 0; i < tetrads.Length; i++)
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

            string[] newBinary = new string[binary.Length];

            for (int i = 0, j = 0; i < binary.Length; i++, j += 2)
            {
                newBinary[i] = newTetrads[j] + newTetrads[j + 1];
            }

            return newBinary;
        }
        static string[] P_BlockEncryption(string[] binary)
        {
            string[] newBinaty = new string[binary.Length];


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
                newBinaty[i] = new string(bits);
            }
            
            return newBinaty;
        }
        static string[] P_BlockDecryption(string[] binary)
        {
            string[] newBinaty = new string[binary.Length];


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
        static string[] S_BlockDecryption(string[] binary)
        {
            string[] tetrads = new string[binary.Length * 2];

            for (int i = 0, j = 0; i < binary.Length; i++, j += 2)
            {
                tetrads[j] = binary[i].Substring(0, binary[i].Length / 2);
                tetrads[j + 1] = binary[i].Substring(binary[i].Length / 2);
            }

            string[] newTetrads = new string[tetrads.Length];

            for (int i = 0; i < tetrads.Length; i++)
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

            string[] newBinary = new string[binary.Length];

            for (int i = 0, j = 0; i < binary.Length; i++, j += 2)
            {
                newBinary[i] = newTetrads[j] + newTetrads[j + 1];
            }

            return newBinary;
        }
        static byte[] BinaryToBytes(string binaryCode)
        {
            int byteCount = binaryCode.Length / 8;
            byte[] bytes = new byte[byteCount];
            
            for(int i = 0; i< byteCount; i++)
            {
                string byteString = binaryCode.Substring(i * 8, 8);
                bytes[i] = Convert.ToByte(byteString, 2);
            }

            return bytes;
        }
        static void Main(string[] args)
        {
            

            Console.Write("Enter the text you want to encrypt: ");
            string text = Console.ReadLine();

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            string[] binaryCodes = new string[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
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

            string encryptedText = Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Ciphertext: " + encryptedText);
        }
    }
}
