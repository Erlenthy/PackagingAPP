using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace PackagingAPP
{
    public partial class FileCompresser : Form
    {
        private string[] facts =
        {
            "Did you know 11% of people are left handed",
            "Did you know August has the highest percentage of births",
            "Did you know unless food is mixed with saliva you can't taste it",
            "Did you know the average person falls asleep in 7 minutes",
            "Did you know a bear has 42 teeth",
            "Did you know an ostrich's eye is bigger than its brain",
            "Did you know lemons contain more sugar than strawberries",
            "Did you know 8% of people have an extra rib",
            "Did you know 85% of plant life is found in the ocean",
            "Did you know Ralph Lauren's original name was Ralph Lifshitz",
            "Did you know rabbits like licorice",
            "Did you know the Hawaiian alphabet has 13 letters",
            "Did you know 'Topolino' is the name for Mickey Mouse Italy",
            "Did you know a lobsters blood is colorless but when exposed to oxygen it turns blue",
            "Did you know armadillos have 4 babies at a time and are all the same sex",
            "Did you know reindeer like bananas",
            "Did you know the longest recorded flight of a chicken was 13 seconds",
            "Did you know birds need gravity to swallow",
            "Did you know the most commonly used letter in the alphabet is E",
            "Did you know the 3 most common languages in the world are Mandarin Chinese, Spanish and English",
            "Did you know dreamt is the only word that ends in mt",
            "Did you know the first letters of the months July through to November spell JASON",
            "Did you know a cat has 32 muscles in each ear",
            "Did you know Perth is Australia's windiest city",
            "Did you know Elvis's middle name was Aron",
            "Did you know goldfish can see both infrared and ultraviolet light",
            "Did you know the smallest bones in the human body are found in your ear",
            "Did you know cats spend 66% of their life asleep",
            "Did you know Switzerland eats the most chocolate equating to 10 kilos per person per year",
            "Did you know money is the number one thing that couples argue about",
            "Did you know macadamia nuts are toxic to dogs",
            "Did you know when lightning strikes it can reach up to 30,000 degrees celsius (54,000 degrees fahrenheit)",
            "Did you know spiders are arachnids and not insects",
            "Did you know each time you see a full moon you always see the same side",
            "Did you know stewardesses is the longest word that is typed with only the left hand",
            "Did you know honey is the only natural food which never spoils",
            "Did you know M&M's chocolate stands for the initials for its inventors Mars and Murrie",
            "Did you know that you burn more calories eating celery than it contains (the more you eat the thinner you become)",
            "Did you know the only continent with no active volcanoes is Australia",
            "Did you know the longest street in the world is Yonge street in Toronto Canada measuring 1,896 km (1,178 miles)",







                
            // Dodaj więcej faktów do wyświetlenia

        };

        private int maxClicks = 10; // Maksymalna liczba kliknięć
        private int currentClicks = 0; // Aktualna liczba kliknięć

        private Random random = new Random();

        private Stopwatch stopwatch = new Stopwatch(); // Stopwatch do śledzenia czasu

        public FileCompresser()
        {

            InitializeComponent();
            DisplayRandomFact();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxClicks;
            stopwatch.Start();
        }

        private void DisplayRandomFact()
        {
            // Wylosuj indeks losowego faktu
            int randomIndex = random.Next(facts.Length);

            // Wyświetl wybrany fakt w Label
            factLabel.Text = facts[randomIndex];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Rozpocznij odliczanie czasu po załadowaniu formularza
            stopwatch.Start();
        }

        private void przegladajButton_Click(object sender, EventArgs e)
        {



            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Możesz ustawić początkowy katalog
                openFileDialog.Filter = "Wszystkie pliki (*.*)|*.*"; // Filtr na wszystkie pliki
                openFileDialog.FilterIndex = 1; // Indeks domyślnego filtru
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] selectedFilePaths = openFileDialog.FileNames; // Pobierz tablicę wybranych ścieżek plików


                    string sevenZipPath = Find7ZipPath();
                    if (sevenZipPath != null)
                    {
                        // Pobierz ścieżkę do folderu "Dokumenty" użytkownika
                        string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        string timestamp = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");



                        // Utwórz ścieżkę docelową (folder "SkompresowaneAPP" w folderze "Dokumenty")
                        string targetAppFolder = Path.Combine(documentsFolder, "SkompresowaneAPP");
                        string targetDataFolder = Path.Combine(targetAppFolder, $"Compressed_{timestamp}");

                        // Upewnij się, że folder docelowy istnieje lub go utwórz
                        Directory.CreateDirectory(targetAppFolder);
                        Directory.CreateDirectory(targetDataFolder);



                        string randomPassword = GenerateRandomPassword();


                        // Utwórz nazwę pliku na podstawie daty i godziny
                        string targetFileName = $"{timestamp}.zip";

                        // Pełna ścieżka do pliku docelowego
                        string targetFilePath = Path.Combine(targetAppFolder, targetDataFolder, targetFileName);

                        string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        int length = 12;
                        Random random = new Random();
                        string passwordFilePath = Path.Combine(targetDataFolder, "IAmNotAPassword.txt");
                        File.WriteAllText(passwordFilePath, randomPassword);

                        // Wywołaj 7-Zip, korzystając ze znalezionej ścieżki
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = sevenZipPath;
                        string filesToCompress = string.Join(" ", selectedFilePaths.Select(path => $"\"{path}\""));
                        psi.Arguments = $"a -p{randomPassword} -mx5 -tzip \"{targetFilePath}\" {filesToCompress}"; // -mx9 oznacza najwyższy poziom kompresji
                        psi.UseShellExecute = false;
                        psi.CreateNoWindow = true;
                        psi.RedirectStandardOutput = true;
                        psi.RedirectStandardError = true;

                        using (Process process = new Process())
                        {
                            process.StartInfo = psi;
                            process.Start();
                            process.WaitForExit();

                            if (process.ExitCode == 0)
                            {
                                MessageBox.Show($"Plik został skompresowany i zapisany jako {targetFileName} w folderze Dokumenty\\SkompresowaneAPP.");

                            }
                            else
                            {
                                MessageBox.Show("Wystąpił błąd podczas kompresji pliku.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono 7-Zip na tym komputerze. Zainstaluj 7-Zip lub podaj własną ścieżkę do programu.");
                    }
                }
                string GenerateRandomPassword()
                {
                    string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    int length = 12;
                    Random random = new Random();
                    string password = new string(Enumerable.Repeat(characters, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    return password;
                }
            }
        }



        private string Find7ZipPath()
        {
            // Standardowe lokalizacje, gdzie może znajdować się 7-Zip
            string[] possiblePaths = {
        @"C:\Program Files\7-Zip\7z.exe",
        @"C:\Program Files (x86)\7-Zip\7z.exe",
        @"C:\Program Files\7-Zip\7zFM.exe",
        @"C:\Program Files (x86)\7-Zip\7zFM.exe"
    };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    return path;
                }
            }

            return null; // Jeśli nie znaleziono 7-Zip
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            // Inkrementuj liczbę kliknięć
            currentClicks++;

            // Zaktualizuj wartość ProgressBar
            progressBar1.Value = currentClicks;

            // Sprawdź, czy osiągnięto maksymalną wartość
            if (currentClicks >= maxClicks)
            {
                // Zatrzymaj odliczanie czasu i oblicz czas spędzony w aplikacji
                stopwatch.Stop();


                // Tutaj możesz wykonać odpowiednie działania po osiągnięciu maksimum
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Wylosuj indeks losowego faktu
            int randomIndex = random.Next(facts.Length);

            // Wyświetl wybrany fakt w kontrolce Label
            factLabel.Text = facts[randomIndex];

            // Inkrementuj liczbę kliknięć
            currentClicks++;

            // Zaktualizuj wartość ProgressBar
            progressBar1.Value = currentClicks;




            // Sprawdź, czy osiągnięto maksymalną wartość
            if (currentClicks >= maxClicks)
            {
                TimeSpan elapsedTime = stopwatch.Elapsed;
                MessageBox.Show($"Did your supervisior know u spend {elapsedTime} on random facts instead of a work?");
                // Tutaj możesz wykonać odpowiednie działania po osiągnięciu maksimum
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {



            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Możesz ustawić początkowy katalog
                openFileDialog.Filter = "Wszystkie pliki (*.*)|*.*"; // Filtr na wszystkie pliki
                openFileDialog.FilterIndex = 1; // Indeks domyślnego filtru
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] selectedFilePaths = openFileDialog.FileNames; // Pobierz tablicę wybranych ścieżek plików


                    string sevenZipPath = Find7ZipPath();
                    if (sevenZipPath != null)
                    {
                        // Pobierz ścieżkę do folderu "Dokumenty" użytkownika
                        string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        string timestamp = DateTime.Now.ToString("dd_MM_yyyy");


                
                        // Utwórz ścieżkę docelową (folder "SkompresowaneAPP" w folderze "Dokumenty")
                        string targetAppFolder = Path.Combine(documentsFolder, "SkompresowaneAPP");
                        string targetDataFolder = Path.Combine(targetAppFolder, $"Compressed_{timestamp}");

                        // Upewnij się, że folder docelowy istnieje lub go utwórz
                        Directory.CreateDirectory(targetAppFolder);
                        Directory.CreateDirectory(targetDataFolder);


                        foreach (string selectedFilePath in selectedFilePaths)
                        {

                        
                                string randomPassword = GenerateRandomPassword();
                            string originalFileNameWithoutExtension = Path.GetFileNameWithoutExtension(selectedFilePath);
                            string folderName = $"{timestamp}_{originalFileNameWithoutExtension}";

                            string compressedAppFolder = Path.Combine(documentsFolder, "SkompresowaneAPP", targetDataFolder );
                            string compressedDataFolder = Path.Combine(compressedAppFolder, folderName);


                            // Utwórz nazwę pliku na podstawie daty i godziny
                            string targetFileName = $"{timestamp}_{Path.GetFileNameWithoutExtension(selectedFilePath)}.zip";
                            string passwordFilePath = Path.Combine(targetDataFolder, compressedDataFolder, $"{Path.GetFileNameWithoutExtension(selectedFilePath)}.txt");

                            Directory.CreateDirectory(compressedAppFolder);
                            Directory.CreateDirectory(compressedDataFolder);

                            // Pełna ścieżka do pliku docelowego
                            string targetFilePath = Path.Combine(targetDataFolder,compressedDataFolder, targetFileName);
                            File.WriteAllText(passwordFilePath, randomPassword);

                            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                            int length = 12;
                            Random random = new Random();
                            
                            File.WriteAllText(passwordFilePath, randomPassword);



                            // Wywołaj 7-Zip, korzystając ze znalezionej ścieżki
                            ProcessStartInfo psi = new ProcessStartInfo();
                                psi.FileName = sevenZipPath;

                                psi.Arguments = $"a -p{randomPassword} -mx5 -tzip \"{targetFilePath}\" \"{selectedFilePath}\""; // -mx9 oznacza najwyższy poziom kompresji
                                psi.UseShellExecute = false;
                                psi.CreateNoWindow = true;
                                psi.RedirectStandardOutput = true;
                                psi.RedirectStandardError = true;

                                using (Process process = new Process())
                                {
                                    process.StartInfo = psi;
                                    process.Start();
                                    process.WaitForExit();

                                    if (process.ExitCode == 0)
                                    {
                                        MessageBox.Show($"Plik został skompresowany i zapisany jako {targetFileName} w folderze Dokumenty\\SkompresowaneAPP\\{folderName}.");

                                    }
                                    else
                                    {
                                        MessageBox.Show("Wystąpił błąd podczas kompresji pliku.");
                                    }
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono 7-Zip na tym komputerze. Zainstaluj 7-Zip lub podaj własną ścieżkę do programu.");
                    }
                }
                string GenerateRandomPassword()
                {
                    string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    int length = 12;
                    Random random = new Random();
                    string password = new string(Enumerable.Repeat(characters, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    return password;
                }
            }
        }
        string GenerateRandomPassword()
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 12;
            Random random = new Random();
            string password = new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }
        
    }

}


        
        
    

