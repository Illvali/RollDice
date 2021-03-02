using System;

namespace Uppgift_3___Dice_Roll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dice Roll!\nWhat is your name?");
            string playerName = Console.ReadLine();
            Game game = new Game(playerName);
            bool check = true;
            game.Roller();
            while (check == true)
            {
                Console.WriteLine(game.Status());
                Console.WriteLine($"{game.Player}, you rolled... {game.NextRoll}\nIs the next roll higher(h) or lower(l)?");
                bool inputError = game.GuessChecker(Console.ReadLine());
                while(inputError is false)
                {
                    Console.WriteLine("Your input is not valid. Please, answer again");
                    //Console.WriteLine($"{game.Player}, you rolled... {game.NextRoll}\nIs the next roll higher(h) or lower(l)?");
                    inputError = game.GuessChecker(Console.ReadLine());
                }
                game.Roller();
                check = game.RollChecker();
            }
            Console.WriteLine(game.GameOver());
        }
    }
    class Game
    {
        public int Score
        { get; set; }
        public int StreakCounter
        { get; set; }
        public string Player    // property
        { get; set; }
        public int Roll    // property
        { get; set; }
        public int NextRoll    // property
        { get; set; }
        public string Guess
        { get; set; }

        public Game(string name)
        {
            Player = name;
        }

        public void Roller()
        {
            Roll = NextRoll;
            NextRoll = new Random().Next(1, 100);
        }

        public bool RollChecker()
        {
            if (Guess == "h" || Guess == "higher")
            {
                if (Roll < NextRoll)
                {
                    StreakCounter++;
                    AddScore();
                    return true;
                }
                else
                {
                    return false;
                }
            }     
            
            if(Roll > NextRoll)
            {
                StreakCounter++;
                AddScore();
                return true;
            }
            return false;
        }

        public string Status()
        {
            return $"Your score is now: {Score}";
        }

        public void AddScore()
        {
            if(StreakCounter%3 == 0)
            {
                Score += 3;
            }
            Score++;
        }

        public string GameOver()
        {
            return $"GAME OVER! You rolled {NextRoll}\nYour score: {Score}";
        }
        public bool GuessChecker(string guess)
        {
            if(guess == "higher" || guess == "h" || guess == "lower" || guess == "l")
            {
                Guess = guess;
                return true;
            }
            return false;
        }


    }
}
