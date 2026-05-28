using System;
using System.IO;

string[] questionsOne = new string[10]; 
string[] questionsTwo = new string[10];

questionsOne[0] = "Столица Венгрии?";
questionsOne[1] = "Сколько дней в неделе?";
questionsOne[2] = "Кто написал «Колобка»?";
questionsOne[3] = "Как называется самая большая планета солнечной системы?";
questionsOne[4] = "Какой газ нужен человеку для дыхания?";
questionsOne[5] = "Как зовут зелёного моба из Minecraft?";
questionsOne[6] = "Какая птица не умеет летать?";
questionsOne[7] = "Что показывает часы?";
questionsOne[8] = "Как называется детёныш собаки?";
questionsOne[9] = "На чём летают в космос?";

questionsTwo[0] = "Сколько месяцев в году?";
questionsTwo[1] = "Какая звезда освещает Землю?";
questionsTwo[2] = "Какое насекомое живёт в улье?";
questionsTwo[3] = "Как называется замёрзшая вода?";
questionsTwo[4] = "Какой океан самый большой?";
questionsTwo[5] = "У кого есть дом в виде панциря?";
questionsTwo[6] = "Как подругому назвать смартфон?";
questionsTwo[7] = "Что растёт на дубе?";
questionsTwo[8] = "Какой цвет получается из красного и синего?";
questionsTwo[9] = "Кто охраняет правопорядок?";

string[] playerAnswers = new string[questionsOne.Length];
string fileAnswers = "responsesPlayer.txt";

string answerPlayerOnePath = "answerPlayerOne.txt";
string answerPlayerTwoPath = "answerPlayerTwo.txt";
string[] correctAnswersPlayerOne = File.ReadAllLines(answerPlayerOnePath);
string[] correctAnswersPlayerTwo = File.ReadAllLines(answerPlayerTwoPath);

for (int i = 0; i < questionsOne.Length; i++)
{
    Console.Write(questionsOne[i] + " ");
    playerAnswers[i] = Console.ReadLine();
}

if (File.Exists(fileAnswers))
{
    File.WriteAllText(fileAnswers, string.Join("\n", playerAnswers));
}
else
{
    File.AppendAllText(fileAnswers, string.Join("\n", playerAnswers));
}

int CheckAnswers(string[] playerAnswers, string[] correctAnswers)
{
    int scoresPlayer = 0;
    foreach (string correctAnswer in correctAnswers)
    {
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            if (correctAnswer.ToLower() == playerAnswers[i].ToLower())
            {
                scoresPlayer++;
            }
        }
    }

    return scoresPlayer;
}

int scorePlayerOne = CheckAnswers(playerAnswers, correctAnswersPlayerOne);
Console.WriteLine($"Результат первого игрока: {scorePlayerOne} очков\n");


for (int i = 0; i < questionsTwo.Length; i++)
{
    Console.Write(questionsTwo[i] + " ");
    playerAnswers[i] = Console.ReadLine();
}

if (File.Exists(fileAnswers))
{
    File.WriteAllText(fileAnswers, string.Join("\n", playerAnswers));
}
else
{
    File.AppendAllText(fileAnswers, string.Join("\n", playerAnswers));
}

int scorePlayerTwo = CheckAnswers(playerAnswers, correctAnswersPlayerTwo);
Console.WriteLine($"Результат второго игрока: {scorePlayerTwo} очков\n");
Console.WriteLine("Результаты игры");

if (scorePlayerOne > scorePlayerTwo)
{
    Console.WriteLine("Игрок 1 победил!");
}
else if (scorePlayerOne < scorePlayerTwo)
{
    Console.WriteLine("Игрок 2 победил!");
}
else
{
    Console.WriteLine("Ничья!");
}