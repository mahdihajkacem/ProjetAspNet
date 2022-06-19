namespace GestionFormation.Models
{
    public class Formation
    {
        public int FormationID { get; set; }
        public string FormationName { get; set; }
        public string FormationAdress { get; set; }
        public ICollection<Participants> Participants { get; set; }

    }
}
