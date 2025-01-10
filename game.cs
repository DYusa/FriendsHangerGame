using System;
using System.Linq;

class HangmanGame
{
    // Lingo from Friends
    static string[] words = new string[] {
        "howyoudoin",      // "How you doin'?"
        "smellycat",       // "Smelly Cat"
        "wewereonabreak",  // "We were on a break!"
        "pivot",           // "Pivot!"
        "centralperk",     // "Central Perk"
        "joey",            // Joey Tribbiani
        "monica",          // Monica Geller
        "ross",            // Ross Geller
        "chandler",        // Chandler Bing
        "rachel",          // Rachel Green
        "friends",         // "Friends"
    };

    static void Main()
    {
        // Welcome message
        Console.WriteLine("Welcome to Hangman with Friends Lingo!");
        string word = GetRandomWord();
        string wordToGuess = new string('_', word.Length);
        int attempts = 6;
        bool gameOver = false;
        char[] guessedLetters = new char[word.Length];
        int guessedLetterCount = 0;

        // Game loop
        while (attempts > 0 && !gameOver)
        {
            Console.Clear();
            Console.WriteLine("Word to guess: " + wordToGuess);
            Console.WriteLine($"Attempts remaining: {attempts}");
            Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters.Where(c => c != '\0')));

            Console.WriteLine("\nEnter a letter:");
            char guess = Char.ToLower(Console.ReadKey().KeyChar);

            // Check if the guess is a valid letter
            if (!char.IsLetter(guess))
            {
                Console.WriteLine("\nInvalid input! Please enter a letter.");
                continue;
            }

            // Check if the letter was guessed before
            if (Array.Exists(guessedLetters, letter => letter == guess))
            {
                Console.WriteLine("\nYou've already guessed this letter!");
                continue;
            }

            // Update guessed letters array
            guessedLetters[guessedLetterCount++] = guess;

            // Check if the guessed letter is in the word
            if (word.Contains(guess))
            {
                Console.WriteLine("\nNice guess!");
                // Update the wordToGuess with the correct letter
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess)
                    {
                        wordToGuess = wordToGuess.Remove(i, 1).Insert(i, guess.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("\nOops! Incorrect guess.");
                attempts--;
            }

            // Check if the player has guessed the whole word
            if (!wordToGuess.Contains('_'))
            {
                gameOver = true;
                Console.WriteLine("\nCongratulations! You've guessed the word: " + word);
                Console.WriteLine("You win! How you doin'?");
            }

            // Delay for player to see the result
            System.Threading.Thread.Sleep(1000);
        }

        if (!gameOver)
        {
            Console.WriteLine("\nGame over! The word was: " + word);
            Console.WriteLine("Smelly Cat, smelly cat...");
        }
    }

    // Helper function to get a random word from the Friends lingo list
    static string GetRandomWord()
    {
        Random random = new Random();
        return words[random.Next(words.Length)];
    }
}
