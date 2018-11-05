using System;

namespace TP_Note
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EcosystemeGenerateur ecosystemeGenerateur = new AleatoireEcosystemeGenerateur();
            // Définie la taille de l'Ecosystème et le nombre de Nuisibles générés
            Ecosysteme ecosysteme = ecosystemeGenerateur.creation(5, 5, 10);

            // Tant qu'il existe des Nuisibles Vivants dans l'Ecosystème, on affiche leur caractéristiques pour chaque cycle
            while (ecosysteme.estVivant())
            {
                ecosysteme.cycle();
                Console.WriteLine("=============================================");
            }
        }
    }
}