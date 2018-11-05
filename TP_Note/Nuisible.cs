using System;

namespace TP_Note
{
    public abstract class Nuisible
    {
        // Etats possible pour un Nuisible
        public enum Etat
        {
            Vivant, Mort, Zombie
        }

        protected string _type;
        protected Position _position;
        protected uint _vitesse;
        protected Etat _etat;
        
        public Nuisible(string type, uint x, uint y, uint vitesse, Etat etat) : this(type, new Position(x, y), vitesse, etat) {}
        
        public Nuisible(string type, Position position, uint vitesse, Etat etat)
        {
            _type = type;
            _position = position;
            _vitesse = vitesse;
            _etat = etat;
        }
        
        // Définie quand un Nuisible est considéré Vivant
        public bool estVivant()
        {
            return _etat == Etat.Vivant;
        }

        // Calcul le déplacement des Nuisibles en fonction de leur vitesse et de la taille de l'Ecosystème
        public void deplacement(uint xMax, uint yMax)
        {
            Random generateurAleatoire = new Random();

            // Si le Nuisible est mort, il ne se déplace pas
            if (_etat == Etat.Mort)
            {
                return;
            }

            // 0 = Haut, 1 = Droite, 2 = Bas et 3 = Gauche
            for (uint i = 0; i < _vitesse; i++)
            {
                var direction = generateurAleatoire.Next(0, 4);
                
                if (direction == 0 && _position.y < yMax)
                {
                    _position.y ++;
                }
                else if (direction == 1 && _position.x < xMax)
                {
                    _position.x ++;
                }
                else if (direction == 2 && _position.y > 0)
                {
                    _position.y --;
                }
                else if (direction == 3 && _position.x > 0)
                {
                    _position.x --;
                }
            }
        }

        // Définie le type d'interraction suivant les Nuisibles qui se rencontres
        public void interagitAvec(Nuisible nuisible)
        {
            // Si le Nuisible est mort, il n'y a aucune interraction
            if (nuisible._etat == Etat.Mort || _etat == Etat.Mort)
            {
                return;
            } 
            
            // Si le Nuisible est un Zombie, il transforme le Nuisible rencontré
            if (_etat == Etat.Zombie)
            {
                nuisible._etat = Etat.Zombie;
                nuisible._vitesse = Zombie.Vitesse;
            }
            // Si le nuisible est un Pigeon mutant, tue obligatoirement le Rat
            else if (nuisible._etat != Etat.Zombie && this.GetType() != nuisible.GetType() && nuisible.GetType() != typeof(Pigeon) && this.GetType() == typeof(PigeonMutant))
            {
                nuisible._etat = Etat.Mort;
            }
            // Si le Nuisible est un Rat ou un Pigeon, tue aléatoirement un des deux Nuisibles
            else if (nuisible._etat != Etat.Zombie && this.GetType() != nuisible.GetType() && nuisible.GetType() != typeof(PigeonMutant) && this.GetType() != typeof(PigeonMutant))
            {
                Random aleatoire = new Random();
                if (aleatoire.Next(0, 2) == 0)
                {
                    nuisible._etat = Etat.Mort;
                }
                else
                {
                    this._etat = Etat.Mort;
                }
            }
        }

        // Affiche les caractéristiques d'un Nuisible
        public void afficherEtat()
        {
            Console.WriteLine("Type : " + _type + ", X : " + _position.x + ", Y : " + _position.y + ", Etat : " + _etat.ToString());
        }
        
        // Test si deux Nuisibles se trouve sur la même case
        public bool memeCase(Nuisible nuisible)
        {
            return this._position.x == nuisible._position.x && this._position.y == nuisible._position.y;
        }
    }
}