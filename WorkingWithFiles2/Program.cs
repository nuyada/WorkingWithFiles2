using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFiles2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enret Url directory");
            string folderPath =Console.ReadLine();

            try
            {
                long size = GetFolderSize(folderPath);
                Console.WriteLine($"Size of folder '{folderPath}': {size} bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }

        static long GetFolderSize(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"Folder not found: {folderPath}");
            }

            long size = 0;

            // Перебираем все файлы в папке и добавляем их размер к общему размеру
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                size += fileInfo.Length;
            }

            // Перебираем все подпапки и рекурсивно вызываем метод GetFolderSize для них
            foreach (string subfolderPath in Directory.GetDirectories(folderPath))
            {
                size += GetFolderSize(subfolderPath);
            }

            return size;
        }
    }
}
