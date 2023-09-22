///**************************************************************************************
///ETML
///Auteur : Omar Egal Ahmed
///Date : 01.09.2023
///Description : Création d'un programme du jeu Mastermind en C#. 
///**************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        static List<char> GenerateSecretCode()
        {
            // Génère un code secret aléatoire (4 couleurs).
            Random random = new Random();
            return Enumerable.Range(0, 4)
                .Select(_ => "RBGYOPV"[random.Next(7)])
                .ToList();
        }


        static bool IsValid(string proposition)
        {
            // Vérifie si la proposition est valide.
            return proposition.Length == 4 && proposition.All(char.IsLetter);
        }


        static int CountCorrectlyPlacedColors(List<char> proposition, List<char> secret)
        {
            // Compte les couleurs correctes bien placées.
            return proposition.Where((c, i) => c == secret[i]).Count();
        }


        static int CountMisplacedColors(List<char> proposition, List<char> secret)
        {
            // Compte les couleurs correctes mais mal placées.
            return proposition.Intersect(secret).Count() - CountCorrectlyPlacedColors(proposition, secret);
        }


        static void PrintFeedback(int correctlyPlaced, int misplaced)
        {
            // Affiche les résultats de la tentative.
            Console.WriteLine($"Couleurs correctes et bien placées : {correctlyPlaced}");
            Console.WriteLine($"Couleurs correctes mais mal placées : {misplaced}");
        }


        static void PrintResult(bool codeGuessed, List<char> secret)
        {
            // Affiche le résultat final.
            if (codeGuessed)
            {
                Console.WriteLine("");
                Console.WriteLine("Félicitations ! Vous avez deviné le code secret !");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Désolé, vous n'avez pas réussi à deviner le code secret. Il était : " + string.Join("", secret));
            }
        }


        do
        {
            Console.WriteLine("Bienvenue dans le jeu Mastermind !");
            Console.WriteLine("");
            Console.WriteLine("Le code secret consiste en une séquence de couleurs.");
            Console.WriteLine("");
            Console.WriteLine("Les couleurs possibles sont : R (Rouge), B (Bleu), G (Vert), Y (Jaune), O (Orange), P (Rose), V (Violet)");
            Console.WriteLine("");
            Console.WriteLine("Entrez votre proposition en utilisant les premières lettres des couleurs.");
            Console.WriteLine("");
            Console.WriteLine("Voici un exemple, (RGBO) :");

            // Générez un code secret aléatoire (4 couleurs).
            List<char> codeSecret = GenerateSecretCode();

            int tentative = 1;
            bool codeDevine = false;

            while (tentative <= 10 && !codeDevine)
            {
                Console.WriteLine("");
                Console.Write($"Tentative {tentative}: ");
                string proposition = Console.ReadLine().ToUpper();  // Convertir en majuscules pour simplifier la comparaison.

                if (!IsValid(proposition))
                {
                    Console.WriteLine("");
                    Console.WriteLine("La proposition n'est pas valide. Assurez-vous qu'elle comporte 4 lettres parmi les couleurs disponibles.");
                    tentative++;
                    continue;
                }

                List<char> propositionList = proposition.ToList();

                int couleursCorrectesBienPlacees = CountCorrectlyPlacedColors(propositionList, codeSecret);

                int couleursCorrectesMalPlacees = CountMisplacedColors(propositionList, codeSecret);
                couleursCorrectesMalPlacees = Math.Max(couleursCorrectesMalPlacees, 0);

                PrintFeedback(couleursCorrectesBienPlacees, couleursCorrectesMalPlacees);

                codeDevine = couleursCorrectesBienPlacees == 4;
                tentative++;
            }

            PrintResult(codeDevine, codeSecret);

            Console.WriteLine("Voulez-vous ré-essayer ? [o/O]");
        } while (Console.ReadLine().ToUpper() == "O");
    }

}





























