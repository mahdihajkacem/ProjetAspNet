using System.ComponentModel.DataAnnotations;

namespace GestionFormation.Models
{
    public class Participants
    {
        public int ParticipantsId { get; set; }
        [Required]
        public string ParticipantsName { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int FormationID { get; set; }
        public Formation Formation { get; set; }

    }
}
