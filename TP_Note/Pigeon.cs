namespace TP_Note
{
    public class Pigeon : Nuisible
    {
        // Vitesse de déplacement
        public static readonly uint Vitesse = 3;
        
        public Pigeon(uint x, uint y) : base("Pigeon", x, y, Vitesse, Nuisible.Etat.Vivant)
        {
            
        }
    }
}