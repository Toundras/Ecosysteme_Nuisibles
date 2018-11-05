using System;
using System.Collections.Generic;

namespace TP_Note
{
    // Ecosystème composé uniquement de Rat et de Pigeon
    public sealed class CitadinEcosystemeGenerateur : EcosystemeGenerateur
    {
        public Ecosysteme creation(uint xMax, uint yMax, uint nombreNuisible)
        {
            var nuisibles = new List<Nuisible>();

            Random aleatoire = new Random();
            
            for (int i = 0; i < nombreNuisible; i++)
            {
                uint x = (uint)aleatoire.Next(0, (int)xMax);
                uint y = (uint)aleatoire.Next(0, (int)yMax);
                
                switch (aleatoire.Next(0, 2))
                {
                    case 0:
                        nuisibles.Add(new Pigeon(x,y));
                        break;
                    case 1:
                        nuisibles.Add(new Rat(x,y));
                        break;
                }
            }
            
            return new Ecosysteme(xMax, yMax, nuisibles);
        }
    }
}