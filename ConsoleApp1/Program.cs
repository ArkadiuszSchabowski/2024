using System;
using System.Threading;
using System.Media;

class Program
{
    static void Main()
    {
        int czasDoRuszenia = 60; // czas w sekundach do ruszenia
        string sciezkaDoDzwieku = "sciezka/do/pliku/dzwiekowego.wav"; // dostosuj ścieżkę do swojego pliku dźwiękowego

        Console.WriteLine("Aplikacja Tibia Run Counter");
        Console.WriteLine($"Uruchamiam licznik czasu dla run, sygnał co {czasDoRuszenia} sekund.");

        // Uruchom wątek licznika czasu
        Thread licznikWatek = new Thread(() => LicznikCzasu(czasDoRuszenia, sciezkaDoDzwieku));
        licznikWatek.Start();

        // Oczekuj na naciśnięcie klawisza Enter, aby zakończyć program
        Console.WriteLine("Naciśnij Enter, aby zakończyć licznik czasu.");
        Console.ReadLine();
    }

    static void LicznikCzasu(int czasDoRuszenia, string sciezkaDoDzwieku)
    {
        while (true)
        {
            Thread.Sleep(czasDoRuszenia * 1000); // zamień sekundy na milisekundy
            OdtwarzajDzwiek(sciezkaDoDzwieku);
        }
    }

    static void OdtwarzajDzwiek(string sciezkaDoDzwieku)
    {
        try
        {
            SoundPlayer player = new SoundPlayer(sciezkaDoDzwieku);
            player.Play();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nie udało się odtworzyć dźwięku: {ex.Message}");
        }
    }
}
