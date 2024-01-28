using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Milionaires.Database;
using Milionaires.Database.Entities;
using Milionaires.Models;

namespace Milionaires.Service
{
    public interface IGameService
    {
        Score CreateRecord(Score score);
        List<Question> GetAllQuestions();
        ScoreQuery GetAllScores(ScoreDto scoreDto);
    }

    public class GameService : IGameService
    {
        private readonly MyDbContext _context;
        private readonly List<Question> _questions;
        private readonly List<Score> _scores;

        public GameService(MyDbContext context)
        {
            _context = context;

            _scores = new List<Score> {
                new Score { Id = 1, Name = "Ania", Result = 500, Date = new DateTime(2024, 1, 1) },
                new Score { Id = 2, Name = "Maciek", Result = 500, Date = new DateTime(2024, 1, 9) },
                new Score { Id = 3, Name = "Lena", Result = 500, Date = new DateTime(2024, 1, 8) },
                new Score { Id = 4, Name = "Piotr", Result = 500, Date = new DateTime(2024, 1, 1) },
                new Score { Id = 5, Name = "Zofia", Result = 500, Date = new DateTime(2024, 1, 6) },
                new Score { Id = 6, Name = "Kamil", Result = 500, Date = new DateTime(2024, 1, 9) },
                new Score { Id = 7, Name = "Magda", Result = 500, Date = new DateTime(2024, 1, 11) },
                new Score { Id = 8, Name = "Łukasz", Result = 500, Date = new DateTime(2024, 1, 4) },
                new Score { Id = 9, Name = "Aleksandra", Result = 2000, Date = new DateTime(2024, 1, 15) },
                new Score { Id = 10, Name = "Adam", Result = 2000, Date = new DateTime(2024, 1, 1) },
                new Score { Id = 11, Name = "Monika", Result = 2000, Date = new DateTime(2024, 1, 7) },
                new Score { Id = 12, Name = "Bartosz", Result = 5000, Date = new DateTime(2024, 1, 18) },
                new Score { Id = 13, Name = "Natalia", Result = 5000, Date = new DateTime(2024, 1, 9) },
                new Score { Id = 14, Name = "Krzysztof", Result = 5000, Date = new DateTime(2024, 1, 20) },
                new Score { Id = 15, Name = "Joanna", Result = 5000, Date = new DateTime(2024, 1, 21) },
                new Score { Id = 16, Name = "Dominik", Result = 5000, Date = new DateTime(2024, 1, 12) },
                new Score { Id = 17, Name = "Weronika", Result = 5000, Date = new DateTime(2024, 1, 3) },
                new Score { Id = 18, Name = "Marcin", Result = 10000, Date = new DateTime(2024, 1, 24) },
                new Score { Id = 19, Name = "Karolina", Result = 10000, Date = new DateTime(2024, 1, 25) },
                new Score { Id = 20, Name = "Dawid", Result = 10000, Date = new DateTime(2024, 1, 6) },
                new Score { Id = 21, Name = "Marta", Result = 10000, Date = new DateTime(2024, 1, 27) },
                new Score { Id = 22, Name = "Artur", Result = 40000, Date = new DateTime(2024, 1, 28) },
                new Score { Id = 23, Name = "Patrycja", Result = 40000, Date = new DateTime(2024, 1, 29) },
                new Score { Id = 24, Name = "Tomasz", Result = 40000, Date = new DateTime(2024, 1, 30) },
                new Score { Id = 25, Name = "Kinga", Result = 75000, Date = new DateTime(2024, 1, 31) },
                new Score { Id = 26, Name = "Adrian", Result = 75000, Date = new DateTime(2024, 1, 1) },
                new Score { Id = 27, Name = "Karol", Result = 150000, Date = new DateTime(2024, 1, 2) },
                new Score { Id = 28, Name = "Justyna", Result = 150000, Date = new DateTime(2024, 1, 10) },
                new Score { Id = 29, Name = "Rafał", Result = 250000, Date = new DateTime(2024, 1, 14) },
                new Score { Id = 30, Name = "Szymon", Result = 500000, Date = new DateTime(2024, 1, 25) },
            };

            if (!_context.Scores.Any())
            {
                _context.Scores.AddRange(_scores);
                _context.SaveChanges();
            }

            _questions = new List<Question>
            {
                new Question("Jak wygląda operator inkrementacji?", new[] { "A. ==", "B. ++", "C. --", "D. =" }, 1, "Operator inkrementacji '++' zwiększa wartość zmiennej o 1.", 1),
                new Question("Jak wygląda operator dekrementacji?", new[] { "A. ==", "B. --", "C. ++", "D. =" }, 1, "Operator dekrementacji '--' zmniejsza wartość zmiennej o 1.", 1),
                new Question("Jak wygląda operator przypisania?", new[] { "A. ==", "B. --", "C. =", "D. ++" }, 2, "Operator przypisania '=' służy do przypisywania wartości jednej zmiennej do drugiej.", 2),
                new Question("Klasa zapieczętowana, po której nie można dziedziczyć to?", new[] { "A. Static", "B. Abstract", "C. Sealed", "D. Dynamic" }, 2, "Klasa zapieczętowana (sealed) nie może być dziedziczona.", 2),
                new Question("Który typ nie jest typem referencyjnym?", new[] { "A. Boolean", "B. Lista", "C. Tablica", "D. Kolejka" }, 0, "Typ Boolean jest typem wartościowym (value type), a nie referencyjnym (reference type).", 3),
                new Question("Metoda, która służy do usuwania pustych znaków na początku i końcu tekstu to?", new[] { "A. Trim", "B. Reverse", "C. Concat", "D. Replace" }, 0, "Metoda Trim usuwa puste znaki na początku i końcu tekstu.", 3),
                new Question("Jakie jest domyślne zachowanie modyfikatora dostępu w C# dla elementów klasy?", new[] { "A. Internal", "B. Protected", "C. Public", "D. Private" }, 3, "Domyślnie modyfikator dostępu dla elementów klasy to 'private'.", 4),
                new Question("Która instrukcja jest używana do obsługi wyjątków w C#?", new[] { "A. if-else", "B. for", "C. switch", "D. try-catch" }, 3, "Instrukcja try-catch służy do obsługi wyjątków.", 4),
                new Question("Który modyfikator dostępu w C# oznacza, że element jest dostępny tylko w obrębie tego samego namespace?", new[] { "A. Internal", "B. Private", "C. Protected", "D. Public" }, 0, "Modyfikator dostępu 'internal' oznacza dostęp tylko w obrębie tego samego namespace.", 5),
                new Question("Co to jest delegat w C#?", new[] { "A. Typ reprezentujący wskaźnik do metody", "B. Typ reprezentujący listę elementów", "C. Typ reprezentujący wyjątek", "D. Typ reprezentujący klasę abstrakcyjną" }, 0, "Delegat to typ reprezentujący wskaźnik do metody.", 5),
                new Question("Jakie jest zastosowanie kolekcji `HashSet` w języku C#?", new[] { "A. Przechowywanie unikalnych elementów", "B. Implementacja stosu danych", "C. Przechowywanie elementów w kolejności wstawiania", "D. Przechowywanie elementów w porządku alfabetycznym" }, 0, "HashSet przechowuje unikalne elementy.", 6),
                new Question("W języku C#, co oznacza termin 'boxing'?", new[] { "A. Proces konwertowania typu wartościowego na typ referencyjny", "B. Tworzenie kopii obiektu", "C. Kompilator C#", "D. Optymalizacja kodu" }, 0, "Boxing to proces konwertowania typu wartościowego na typ referencyjny.", 6),
                new Question("Który z poniższych operatorów w C# służy do tworzenia nowych obiektów?", new[] { "A. +", "B. -", "C. new", "D. /" }, 2, "Operator 'new' służy do tworzenia nowych obiektów.", 7),
                new Question("Co oznacza słowo kluczowe 'base' w języku C#?", new[] { "A. Deklaracje nowej klasy bazowej", "B. Tworzenie nowej instancji obiektu", "C. Wywołanie metody bazowej w klasie pochodnej", "D. Przekazanie wartości do konstruktora" }, 2, "Słowo kluczowe 'base' używane jest do wywołania metody bazowej w klasie pochodnej.", 7),
                new Question("Jaki jest wynik działania operatora 'is' w C#?", new[] { "A. Porównuje dwie liczby całkowite", "B. Sprawdza, czy obiekt jest instancją określonej klasy lub interfejsu", "C. Wywołuje wyjątek w przypadku błędu", "D. Oznacza przypisanie do zmiennej" }, 1, "Operator 'is' sprawdza, czy obiekt jest instancją określonej klasy lub interfejsu.", 8),
                new Question("Jakie jest zastosowanie interfejsów w języku C#?", new[] { "A. Dziedziczenie wielokrotne", "B. Wymaganie dla klas implementujących interfejs", "C. Implementacja wielu klas bazowych", "D. Tworzenie abstrakcyjnych klas" }, 1, "Interfejsy wymagają, aby klasy implementowały określone metody.", 8),
                new Question("Co to jest LINQ w języku C#?", new[] { "A. Biblioteka do pracy z plikami XML", "B. Framework do tworzenia interfejsów użytkownika", "C. Technologia do zarządzania pamięcią", "D. Język zapytań do baz danych" }, 3, "LINQ to język zapytań do baz danych w języku C#.", 9),
                new Question("Jakie jest zastosowanie modyfikatora 'static' w języku C#?", new[] { "A. Tworzenie instancji klasy", "B. Określanie dostępu do elementów klasy z innych przestrzeni nazw", "C. Zmniejszanie rozmiaru plików wykonywalnych", "D. Tworzenie elementów, które nie wymagają instancji klasy" }, 3, "Modyfikator 'static' oznacza, że element należy do klasy, a nie do instancji klasy.", 9),
                new Question("Jakie jest zastosowanie słowa kluczowego 'async' w języku C#?", new[] { "A. Określanie klas abstrakcyjnych", "B. Określanie klasy zapieczętowanej", "C. Tworzenie asynchronicznych metod", "D. Tworzenie interfejsów" }, 2, "Słowo kluczowe 'async' oznacza, że metoda jest asynchroniczna.", 10),
                new Question("Jakie jest zastosowanie słowa kluczowego 'using' w języku C#?", new[] { "A. Tworzenie pętli", "B. Określanie dostępu do elementów klasy", "C. Importowanie przestrzeni nazw", "D. Tworzenie klas generycznych" }, 2, "Słowo kluczowe 'using' jest używane do importowania przestrzeni nazw.", 10),
            };
        }

        public Score CreateRecord(Score score)
        {
            if(score.Name == "")
            {
                score.Name = "Anonim";
            }

            if(score.Name.Length > 25)
            {
                throw new InvalidOperationException("Twój nick jest za długi - operacja zapisu nie powiodła się!");
            }
            if(score.Result != 500 && score.Result != 2000 && score.Result != 5000 && score.Result != 10000 && score.Result != 40000 && score.Result != 75000 && score.Result != 150000 && score.Result != 250000 && score.Result != 500000 && score.Result != 1000000)
            {
                throw new InvalidOperationException("Wprowadzony wynik nie jest prawidłowy. Dozwolone wartości to: 500, 2000, 5000, 10000, 40000, 75000, 150000, 250000, 500000, 1000000.");
            }
            score.Date = DateTime.Now;
            _context.Scores.Add(score);
            _context.SaveChanges();
            return score;
        }

        public List<Question> GetAllQuestions()
        {
            return _questions;
        }

        public ScoreQuery GetAllScores(ScoreDto scoreDto)
        {
            int AvailableScores = 100;

            List<Score> baseQuery = _context.Scores.ToList();

            List<Score> scores = _context.Scores
                .OrderByDescending(x => x.Result)
                .Skip(scoreDto.PageSize * (scoreDto.PageNumber - 1))
                .Take(scoreDto.PageSize)
                .ToList();


            ScoreQuery query = new ScoreQuery(new ScoreDto
            {
                PageNumber = scoreDto.PageNumber,
                PageSize = scoreDto.PageSize,
            });

            query.ListScores = scores;
            query.TotalCount = baseQuery.Count();
            query.TotalPages = AvailableScores / query.PageSize;
            query.ItemsFrom = query.PageSize * (query.PageNumber - 1) + 1;
            query.ItemsTo = query.ItemsFrom + query.PageSize - 1;

            return query;
        }
    }
}
