
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

            // Générez un code secret aléatoire (4 couleurs) avec répétition autorisée.
            Random random = new Random();
            List<char> codeSecret = new List<char>();

            for (int i = 0; i < 4; i++)
            {
                int randomNumber = random.Next(7);
                char couleur = "RBGYOPV"[randomNumber];
                codeSecret.Add(couleur);
            }

            int tentative = 1;
            bool codeDevine = false;

            while (tentative <= 10 && !codeDevine)
            {
                Console.WriteLine("");
                Console.Write($"Tentative {tentative}: ");
                string proposition = Console.ReadLine().ToUpper();  // Convertir en majuscules pour simplifier la comparaison.

                if (proposition.Length != 4 || !proposition.All(char.IsLetter))
                {
                    Console.WriteLine("");
                    Console.WriteLine("La proposition n'est pas valide. Assurez-vous qu'elle comporte 4 lettres parmi les couleurs disponibles.");
                    tentative++;
                    continue;
                }

                List<char> propositionList = proposition.ToList();
                List<char> couleursPossibles = new List<char>("RBGYOPV");

                int couleursCorrectesBienPlacees = 0;
                int couleursCorrectesMalPlacees = 0;

                for (int i = 0; i < 4; i++)
                {
                    char couleur = propositionList[i];

                    if (couleur == codeSecret[i])
                    {
                        couleursCorrectesBienPlacees++;
                    }
                    else
                    {
                        // Créez une copie de la liste des couleurs possibles.
                        List<char> couleursPossiblesCopie = new List<char>(couleursPossibles);

                        if (couleursPossiblesCopie.Contains(couleur))
                        {
                            couleursCorrectesMalPlacees++;
                            couleursPossiblesCopie.Remove(couleur);
                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine($"Couleurs correctes et bien placées : {couleursCorrectesBienPlacees}");
                Console.WriteLine($"Couleurs correctes mais mal placées : {couleursCorrectesMalPlacees}");

                codeDevine = couleursCorrectesBienPlacees == 4;
                tentative++;
            }
            Console.WriteLine("");
            if (codeDevine)
            {
                Console.WriteLine("Félicitations ! Vous avez deviné le code secret !");
            }
            else
            {
                Console.WriteLine("Désolé, vous n'avez pas réussi à deviner le code secret. Il était : " + string.Join("", codeSecret));
            }

            Console.WriteLine("Voulez-vous ré-essayer ? [o/O]");
        } while (Console.ReadLine().ToUpper() == "O");

    }
}




























