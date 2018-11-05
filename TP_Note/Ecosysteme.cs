using System.Collections.Generic;

namespace TP_Note
{
    public class Ecosysteme
    {
        private uint _xMax;
        private uint _yMax;
        private List<Nuisible> _nuisibles;

        public Ecosysteme(uint xMax, uint yMax, List<Nuisible> nuisibles)
        {
            _xMax = xMax;
            _yMax = yMax;
            _nuisibles = nuisibles;
        }

        // Test si un Nuisible est Vivant ou non
        public bool estVivant()
        {
            foreach (var nuisible in _nuisibles)
            {
                if (nuisible.estVivant())
                {
                    return true;
                }
            }

            return false;
        }

        // Cycle durant lequel tous les Nuisibles se déplacent
        public void cycle()
        {
            // Déplace tous les Nuisibles dans les limites de l'Ecosystème
            foreach (var nuisible in _nuisibles)
            {
                nuisible.deplacement(_xMax, _yMax);
            }
            
            // Gère les interractions entre les Nuisibles qui se sont rencontrés durant le cycle
            foreach (var nuisible in _nuisibles)
            {
                foreach (var nuisible2 in _nuisibles)
                {
                    if (nuisible != nuisible2 && nuisible.memeCase(nuisible2))
                    {
                        nuisible.interagitAvec(nuisible2);
                    }
                }
            }

            // Affiche les caractéristiques de chaque Nuisible à la fin du cycle
            foreach (var nuisible in _nuisibles)
            {
                nuisible.afficherEtat();
            }
        }
    }
}