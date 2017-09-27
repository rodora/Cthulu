using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RTDDE.AssetBundleDecoder
{
    class Program
    {
        static void Main(string[] args) {
            var isDecode = false;
            while (true) {
                Console.Write("Select operation：(E)ncrypt,(D)ecrypt：");
                var key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.E) {
                    isDecode = false;
                    if (Directory.Exists("AssetBundle_Decode") == false) {
                        Console.WriteLine("Folder AssetBundle_Decode is missing!");
                    }
                    else {
                        break;
                    }
                }
                else if (key.Key == ConsoleKey.D) {
                    isDecode = true;
                    if (Directory.Exists("AssetBundle") == false) {
                        Console.WriteLine("Folder AssetBundle is missing!");
                    }
                    else {
                        break;
                    }
                }
            }
            Console.WriteLine("Input UserID in KeychainService.xml(ex:101000111):");
            var userid = Console.ReadLine().Trim();
            Console.WriteLine($@"Input KEY_UUID in KeychainService.xml(ex:{Guid.NewGuid().ToString().ToLower()}):");
            var uuid = Console.ReadLine().Trim();
            if (isDecode) {
                var decodeFolder = "AssetBundle_Decode_" + userid;
                if (Directory.Exists(decodeFolder) == false) {
                    Directory.CreateDirectory(decodeFolder);
                }
                foreach (var fileInfo in new DirectoryInfo("AssetBundle").EnumerateFiles()) {
                    var fileData = File.ReadAllBytes(fileInfo.FullName);
                    var decryptData = CompositeBinaryData(fileData, userid, uuid);
                    File.WriteAllBytes(decodeFolder + Path.DirectorySeparatorChar + fileInfo.Name, decryptData);
                    Console.WriteLine(fileInfo.Name);
                }
                Console.WriteLine("FIN");
            }
            else {
                if (Directory.Exists("AssetBundle_Encode") == false) {
                    Directory.CreateDirectory("AssetBundle_Encode");
                }
                foreach (var fileInfo in new DirectoryInfo("AssetBundle_Decode").EnumerateFiles()) {
                    var fileData = File.ReadAllBytes(fileInfo.FullName);
                    var encryptData = EncryptionBinaryData(fileData, userid, uuid);
                    File.WriteAllBytes("AssetBundle_Encode\\" + fileInfo.Name, encryptData);
                    Console.WriteLine(fileInfo.Name);
                }
                Console.WriteLine("FIN");
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }


        public static byte[] EncryptionBinaryData(byte[] data, string userId, string uuid) {
            if (data == null) {
                return null;
            }
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.KeySize = 128;
            rijndaelManaged.BlockSize = 128;
            string password = uint.Parse(userId).ToString();
            string keyChainItem = uuid;
            byte[] bytes = Encoding.Unicode.GetBytes(keyChainItem);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, bytes);
            rfc2898DeriveBytes.IterationCount = 1000;
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
            ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor();
            byte[] array = cryptoTransform.TransformFinalBlock(data, 0, data.Length);
            cryptoTransform.Dispose();
            if (array != null) {
            }
            return array;
        }

        public static byte[] CompositeBinaryData(byte[] data, string userId, string uuid) {
            if (data == null) {
                return null;
            }
            byte[] array = null;
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.KeySize = 128;
            rijndaelManaged.BlockSize = 128;
            string password = uint.Parse(userId).ToString();
            string keyChainItem = uuid;
            byte[] bytes = Encoding.Unicode.GetBytes(keyChainItem);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, bytes);
            rfc2898DeriveBytes.IterationCount = 1000;
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
            ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor();
            try {
                array = cryptoTransform.TransformFinalBlock(data, 0, data.Length);
            }
            catch (Exception var_7_AD) {
                return null;
            }
            cryptoTransform.Dispose();
            if (array != null) {
            }
            return array;
        }
    }
}
