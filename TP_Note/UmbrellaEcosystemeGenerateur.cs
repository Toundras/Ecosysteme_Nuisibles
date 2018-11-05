using System;
using System.Collections.Generic;

namespace TP_Note
{
    // Ecosystème composé de Rat, de Pigeon et de minimum 50% de Zombie générés aléatoirement
    public sealed class UmbrellaEcosystemeGenerateur : EcosystemeGenerateur
    {
        public Ecosysteme creation(uint xMax, uint yMax, uint nombreNuisible)
        {
            var nuisibles = new List<Nuisible>();

            Random aleatoire = new Random();
            
            for (int i = 0; i < nombreNuisible; i++)
            {
                uint x = (uint)aleatoire.Next(0, (int)xMax);
                uint y = (uint)aleatoire.Next(0, (int)yMax);

                if (i < nombreNuisible / 2)
                {
                    nuisibles.Add(new Zombie(x,y));
                }
                else
                {
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
            }
            
            return new Ecosysteme(xMax, yMax, nuisibles);
        }
    }
}