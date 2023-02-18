using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson1_pw223
{
    class Program
    {
        static void startQuiz()
        {
            WriteLine("Введите количество подсказок за игру 0-6 (только одна на каждый вопрос): ");
            int numOfTries = Convert.ToInt32(ReadLine());
            string[] questions =

            {
                "Зимой и летом одним цветом?",
                "Самая высокая гора?",
                "Самая длинная река?",
                "Самый большой океан?",
                "Самая большая планета?",
                "Кто может свиснуть  на горе?"
            };
            string[][] answers = new string[6][];
            answers[0] = new string[] { "ель", "ёлка", "spruce", "iel'" }; 
            answers[1] = new string[] { "эверест", "everest", "джамалунгма"}; 
            answers[2] = new string[] { "амазонка", "amazonka" }; 
            answers[3] = new string[] { "тихий", "silent", "pacific" }; 
            answers[4] = new string[] { "jupiter", "юпитер" }; 
            answers[5] = new string[] { "рак", "cancer" };

            string[] prompts =
            {
                "This is a tree", 
                "8848m", 
                "in South America", 
                ":( n/a", 
                "the first letter is J", 
                "the same as desease"
            };
               
            string userAnswer;
            int counterOfRightAnswers = 0;
            bool[] promptToEachQuestions = {true, true, true, true, true, true}; //чтобы 1раз выходила подсказка на 1вопрос

            for (int i = 0; i < questions.Length; i++)
            {
                WriteLine(questions[i]);
                userAnswer = ReadLine();
                userAnswer.ToLower();//неважно в каком регистре будет введен ответ
                bool chekRight=false;//правильность ответа
                for (int j = 0; j < answers[i].Length; j++)
                {
                        if (userAnswer == answers[i][j])
                        {
                         counterOfRightAnswers++; 
                         chekRight = true; 
                         WriteLine("Ответ верный!");
                        }   
                }
                if (!chekRight&&numOfTries!=0&&promptToEachQuestions[i]==true)
                {
                    WriteLine($"Ответ не очень!Осталось подсказок {numOfTries-1}! Лови одну подсказку:");
                    WriteLine(prompts[i]);
                    numOfTries--;
                    promptToEachQuestions[i] = false; 
                    i--;
                }

            }
            WriteLine("Правильных ответов: " + counterOfRightAnswers);
            switch (counterOfRightAnswers)
            {
                case 0: WriteLine("Zero! U are lost for humanity!"); break;
                case 1: WriteLine("One point! U can eat with knife and fork!");break; 
                case 2: WriteLine("Two point! Yr intellect is exist"); break;
                case 3: WriteLine("Three point! U are the Gold Midle guy"); break;
                case 4: WriteLine("Four point! U are the goon one"); break;
                case 5: WriteLine("Five point! U need one step to Everest"); break;
                case 6: WriteLine("Six point! The Best of the Best Man"); break; 
            }
            WriteLine("For repeat pls press Enter");
            if (Console.ReadKey().Key == ConsoleKey.Enter) startQuiz();
        }

        static void guessNumber()
        {
            Random rand = new Random();
            int magicNumber = rand.Next(0, 100);
            int userNumber = 0;
            int count = 0;

            do
            {
                Write("Введи число: ");
                userNumber = Int32.Parse(ReadLine());
                count++;
                if (userNumber < magicNumber)
                {
                    WriteLine("Загаданное число больше!");
                }
                else if (userNumber > magicNumber)
                {
                    WriteLine("Загаданное число меньше!");
                }
                else if (userNumber == magicNumber)
                {
                    WriteLine("Ты угадал! Тебе понадобилось " + count + " попыток");
                    break;
                }
            } while (userNumber != magicNumber);
        }

        static void Main(string[] args)
        {
            do
            {
                WriteLine("\t\tМЕНЮ\n" +
                    "Для выбора игры Викторина нажмите \"1\"\n" +
                    "Для выбора игры Угадай число нажмите \"2\"\n" +
                    "Для выхода Esc...");
                ConsoleKeyInfo PressedKey = Console.ReadKey();
                WriteLine();
                if (PressedKey.KeyChar == '1') startQuiz();
                else if (PressedKey.KeyChar == '2') guessNumber();
                else if (PressedKey.KeyChar == 27) break;
                else WriteLine("Input Error!"); 
            } while (Console.ReadKey().KeyChar != 27); 
        }
    }
}