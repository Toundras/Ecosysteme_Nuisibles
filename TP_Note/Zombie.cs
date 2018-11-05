namespace TP_Note
{
    public class Zombie : Nuisible
    {
        // Vitesse de déplacement
        public static readonly uint Vitesse = 1;
        
        public Zombie(uint x, uint y, string Type) : base(Type, x, y, Vitesse, Nuisible.Etat.Zombie) {}
    }
}