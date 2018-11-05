namespace TP_Note
{
    public class Rat : Nuisible
    {
        // Vitesse de déplacement
        public static readonly uint Vitesse = 2;
        
        public Rat(uint x, uint y) : base("Rat", x, y, Vitesse, Nuisible.Etat.Vivant)
        {
            
        }
    }
}