namespace TP_Note
{
    // Génère un Ecosystème d'une taille donnée avec un nombre de Nuisibles donnés
    public interface EcosystemeGenerateur
    {
        Ecosysteme creation(uint xMax, uint yMax, uint nombreNuisible);
    }
}