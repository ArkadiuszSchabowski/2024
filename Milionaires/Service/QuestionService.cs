﻿using System.Collections.Generic;
using Milionaires.Models;

namespace Milionaires.Service
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        void InitializeQuestions();
    }

    public class QuestionService : IQuestionService
    {
        private List<Question> _questions = new List<Question>();

        public void InitializeQuestions()
        {
            List<(string question, string[] answers, int correctAnswerIndex, string explainAnswer, int difficulty)> questionData = new List<(string, string[], int, string, int)>
            {
                ("Jak wygląda operator inkrementacji?", new string[] { "A. ==", "B. ++", "C. --", "D. =" }, 1, "Operator inkrementacji '++' zwiększa wartość zmiennej o 1.", 1),
                ("Jak wygląda operator dekrementacji?", new string[] { "A. ==", "B. --", "C. ++", "D. =" }, 1, "Operator dekrementacji '--' zmniejsza wartość zmiennej o 1.", 1),

                ("Jak wygląda operator przypisania?", new string[] { "A. ==", "B. --", "C. =", "D. ++" }, 2, "Operator przypisania '=' służy do przypisywania wartości jednej zmiennej do drugiej.", 2),
                ("Klasa zapieczętowana, po której nie można dziedziczyć to?", new string[] { "A. Static", "B. Abstract", "C. Sealed", "D. Dynamic" }, 2, "Klasa zapieczętowana (sealed) nie może być dziedziczona.", 2),

                ("Który typ nie jest typem referencyjnym?", new string[] { "A. Boolean", "B. Lista", "C. Tablica", "D. Kolejka" }, 0, "Typ Boolean jest typem wartościowym (value type), a nie referencyjnym (reference type).", 3),
                ("Metoda, która służy do usuwania pustych znaków na początku i końcu tekstu to?", new string[] { "A. Trim", "B. Reverse", "C. Concat", "D. Replace" }, 0, "Metoda Trim usuwa puste znaki na początku i końcu tekstu.", 3),

                ("Jakie jest domyślne zachowanie modyfikatora dostępu w C# dla elementów klasy?", new string[] { "A. Internal", "B. Protected", "C. Public", "D. Private" }, 3, "Domyślnie modyfikator dostępu dla elementów klasy to 'private'.", 4),
                ("Która instrukcja jest używana do obsługi wyjątków w C#?", new string[] { "A. if-else", "B. for", "C. switch", "D. try-catch" }, 3, "Instrukcja try-catch służy do obsługi wyjątków.", 4),

                ("Który modyfikator dostępu w C# oznacza, że element jest dostępny tylko w obrębie tego samego namespace?", new string[] { "A. Internal", "B. Private", "C. Protected", "D. Public" }, 0, "Modyfikator dostępu 'internal' oznacza dostęp tylko w obrębie tego samego namespace.", 5),
                ("Co to jest delegat w C#?", new string[] { "A. Typ reprezentujący wskaźnik do metody", "B. Typ reprezentujący listę elementów", "C. Typ reprezentujący wyjątek", "D. Typ reprezentujący klasę abstrakcyjną" }, 0, "Delegat to typ reprezentujący wskaźnik do metody.", 5),

                ("Jakie jest zastosowanie kolekcji `HashSet` w języku C#?", new string[] { "A. Przechowywanie unikalnych elementów", "B. Implementacja stosu danych", "C. Przechowywanie elementów w kolejności wstawiania", "D. Przechowywanie elementów w porządku alfabetycznym" }, 0, "HashSet przechowuje unikalne elementy.", 6),
                ("W języku C#, co oznacza termin 'boxing'?", new string[] { "A. Proces konwertowania typu wartościowego na typ referencyjny", "B. Tworzenie kopii obiektu", "C. Kompilator C#", "D. Optymalizacja kodu" }, 0, "Boxing to proces konwertowania typu wartościowego na typ referencyjny.", 6),

                ("Który z poniższych operatorów w C# służy do tworzenia nowych obiektów?", new string[] { "A. +", "B. -", "C. new", "D. /" }, 2, "Operator 'new' służy do tworzenia nowych obiektów.", 7),
                ("Co oznacza słowo kluczowe 'base' w języku C#?", new string[] { "A. Deklaracje nowej klasy bazowej", "B. Tworzenie nowej instancji obiektu", "C. Wywołanie metody bazowej w klasie pochodnej", "D. Przekazanie wartości do konstruktora" }, 2, "Słowo kluczowe 'base' używane jest do wywołania metody bazowej w klasie pochodnej.", 7),

                ("Jaki jest wynik działania operatora 'is' w C#?", new string[] { "A. Porównuje dwie liczby całkowite", "B. Sprawdza, czy obiekt jest instancją określonej klasy lub interfejsu", "C. Wywołuje wyjątek w przypadku błędu", "D. Oznacza przypisanie do zmiennej" }, 1, "Operator 'is' sprawdza, czy obiekt jest instancją określonej klasy lub interfejsu.", 8),
                ("Jakie jest zastosowanie interfejsów w języku C#?", new string[] { "A. Dziedziczenie wielokrotne", "B. Wymaganie dla klas implementujących interfejs", "C. Implementacja wielu klas bazowych", "D. Tworzenie abstrakcyjnych klas" }, 1, "Interfejsy wymagają, aby klasy implementowały określone metody.", 8),

                ("Co to jest LINQ w języku C#?", new string[] { "A. Biblioteka do pracy z plikami XML", "B. Framework do tworzenia interfejsów użytkownika", "C. Technologia do zarządzania pamięcią", "D. Język zapytań do baz danych" }, 3, "LINQ to język zapytań do baz danych w języku C#.", 9),
                ("Jakie jest zastosowanie modyfikatora 'static' w języku C#?", new string[] { "A. Tworzenie instancji klasy", "B. Określanie dostępu do elementów klasy z innych przestrzeni nazw", "C. Zmniejszanie rozmiaru plików wykonywalnych", "D. Tworzenie elementów, które nie wymagają instancji klasy" }, 3, "Modyfikator 'static' oznacza, że element należy do klasy, a nie do instancji klasy.", 9),

                ("Jakie jest zastosowanie słowa kluczowego 'async' w języku C#?", new string[] { "A. Określanie klas abstrakcyjnych", "B. Określanie klasy zapieczętowanej", "C. Tworzenie asynchronicznych metod", "D. Tworzenie interfejsów" }, 2, "Słowo kluczowe 'async' oznacza, że metoda jest asynchroniczna.", 10),
                ("Jakie jest zastosowanie słowa kluczowego 'using' w języku C#?", new string[] { "A. Tworzenie pętli", "B. Określanie dostępu do elementów klasy", "C. Importowanie przestrzeni nazw", "D. Tworzenie klas generycznych" }, 2, "Słowo kluczowe 'using' jest używane do importowania przestrzeni nazw.", 10),
            };

            foreach (var data in questionData)
            {
                _questions.Add(new Question(data.question, data.answers, data.correctAnswerIndex, data.explainAnswer, data.difficulty));
            }
        }

        public List<Question> GetAll()
        {
            return _questions;
        }
    }
}