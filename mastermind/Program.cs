///**************************************************************************************
///ETML
///Auteur : Omar Egal Ahmed
///Date : 01.09.2023
///Description : Création d'un programme de type jeu en C#: Mastermind. 
///**************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        do
        {
            Console.WriteLine("Bienvenue dans le jeu Mastermind !");
            Console.WriteLine();
            Console.WriteLine("Le code secret consiste en une séquence de couleurs.");
            Console.WriteLine();
            Console.WriteLine("Les couleurs possibles sont : R (Rouge), B (Bleu), G (Vert), Y (Jaune), O (Orange), P (Rose), V (Violet)");
            Console.WriteLine();
            Console.WriteLine("Entrez votre proposition en utilisant les premières lettres des couleurs.");

            // Initialisation du générateur de nombres aléatoires.
            Random random = new Random();
            List<char> secretCode = new List<char>();

            // Génération d'un code secret aléatoire (4 couleurs).
            for (int i = 0; i < 4; i++)
                secretCode.Add("RBGYOPV"[random.Next(7)]);

            int attempts = 1;
            bool codeGuessed = false;


            Console.WriteLine();
            Console.WriteLine("Désolé, vous n'avez pas réussi à deviner le code secret. Il était : " + string.Join("", secretCode));

            // La boucle principale où les joueurs font leurs tentatives.
            while (attempts <= 10 && !codeGuessed)
            {
                Console.WriteLine();
                Console.Write($"Tentative {attempts}: ");
                string guess = Console.ReadLine().ToUpper();

                // Vérification de la proposition est valide.
                if (guess.Length != 4 || !guess.All(char.IsLetter) || guess.Any(c => "RBGYOPV".IndexOf(c) == -1))
                {
                    Console.WriteLine();
                    Console.WriteLine("La proposition n'est pas valide. Assurez-vous qu'elle comporte 4 lettres parmi les couleurs disponibles (R, B, G, Y, O, P, V).");
                    attempts++;
                    continue;
                }

                int correctlyPlaced = 0;
                int misplaced = 0;

                // Création des copies de la séquence secrète et de la proposition pour éviter les modifications indésirables.
                List<char> secretCopy = new List<char>(secretCode);
                List<char> guessCopy = new List<char>(guess);

                // Vérification des couleurs correctement placées.
                for (int i = 0; i < 4; i++)
                {
                    if (guessCopy[i] == secretCopy[i])
                    {
                        correctlyPlaced++;
                        // Marquage des couleurs déjà validées.
                        secretCopy[i] = ' ';
                        guessCopy[i] = ' ';
                    }
                }

                // Vérificaton des couleurs mal placées.
                for (int i = 0; i < 4; i++)
                {
                    if (guessCopy[i] != ' ')
                    {
                        for (int j = 0; j < secretCopy.Count; j++)
                        {
                            if (guessCopy[i] == secretCopy[j])
                            {
                                misplaced++;
                                secretCopy[j] = ' ';// Marquage des couleurs déjà validées.
                                break;
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"Couleurs correctes et bien placées : {correctlyPlaced}");
                Console.WriteLine($"Couleurs correctes mais mal placées : {misplaced}");

                // Vérification si le code a été deviné.
                codeGuessed = correctlyPlaced == 4;
                attempts++;
            }

            // Affichage du résultat final.
            if (codeGuessed)
            {
                Console.WriteLine();
                Console.WriteLine("Félicitations ! Vous avez deviné le code secret !");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Désolé, vous n'avez pas réussi à deviner le code secret. Il était : " + string.Join("", secretCode));
            }

            Console.WriteLine("Voulez-vous ré-essayer ? [o/O]");
        } while (Console.ReadLine().ToUpper() == "O");
    }
}



























