/*// See https://aka.ms/new-console-template for more information
// le nombre a analyser, donne par l'uilisateur
string usernumber;
int number;
int cptr =0;
string line = "";


 // Demande du nombre a analyser
    Console.WriteLine();
    Console.Write("Veuillez entre un nombre entre 2 et 9.");
    usernumber = Console.ReadLine();
    number = Convert.ToInt32(usernumber);

for(cptr = 0; cptr < number; cptr++)

{
    line = line + usernumber;
    Console.WriteLine(line);
}

while (cptr < number)
{
    line = line + usernumber;
    Console.WriteLine(line);
    cptr++;
}*/
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenue dans le jeu Mastermind !");
        Console.WriteLine("Le code secret consiste en une séquence de couleurs.");
        Console.WriteLine("Les couleurs possibles sont : R (Rouge), B (Bleu), G (Vert), Y (Jaune), O (Orange), P (Rose), V (Violet)");
        Console.WriteLine("Entrez votre proposition en utilisant les premières lettres des couleurs (par exemple, RGBO) :");

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
            Console.Write($"Tentative {tentative}: ");
            string proposition = Console.ReadLine().ToUpper();

            if (proposition.Length != 4 || !proposition.All(char.IsLetter))
            {
                Console.WriteLine("La proposition n'est pas valide. Assurez-vous qu'elle comporte 4 lettres parmi les couleurs disponibles.");
                tentative++;
                continue;
            }

            List<char> propositionList = proposition.ToList();

            int couleursCorrectesBienPlacees = propositionList.Where((c, i) => c == codeSecret[i]).Count();

            int couleursCorrectesMalPlacees = propositionList.Intersect(codeSecret).Count() - couleursCorrectesBienPlacees;
            couleursCorrectesMalPlacees = Math.Max(couleursCorrectesMalPlacees, 0);

            Console.WriteLine($"Couleurs correctes et bien placées : {couleursCorrectesBienPlacees}");
            Console.WriteLine($"Couleurs correctes mais mal placées : {couleursCorrectesMalPlacees}");

            codeDevine = couleursCorrectesBienPlacees == 4;
            tentative++;
        }

        if (codeDevine)
        {
            Console.WriteLine("Félicitations ! Vous avez deviné le code secret !");
        }
        else
        {
            Console.WriteLine("Désolé, vous n'avez pas réussi à deviner le code secret. Il était : " + string.Join("", codeSecret));
        }

        Console.ReadKey();
    }
}




























