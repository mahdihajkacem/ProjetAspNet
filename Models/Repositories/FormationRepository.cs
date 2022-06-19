namespace GestionFormation.Models.Repositories
{
    public class FormationRepository : IFormationRepository
    {
        readonly ParticipantsContext context;
        public FormationRepository(ParticipantsContext context)
        {
            this.context = context;
        }
        public IList<Formation> GetAll()
        {
            return context.Formations.OrderBy(s => s.FormationName).ToList();
        }
        public Formation GetById(int id)
        {
            return context.Formations.Find(id);
        }
        public void Add(Formation s)
        {
            context.Formations.Add(s);
            context.SaveChanges();
        }
        public void Edit(Formation s)
        {
            Formation s1 = context.Formations.Find(s.FormationID);
            if (s1 != null)
            {
                s1.FormationName = s.FormationName;
                s1.FormationAdress = s.FormationAdress;
                context.SaveChanges();
            }
        }

        public void Delete(Formation s)
        {
            Formation s1 = context.Formations.Find(s.FormationID);
            if (s1 != null)
            {
                context.Formations.Remove(s1);
                context.SaveChanges();
            }
        }
        public double ParticipantsAgeAverage(int FormationId)
        {
            if (ParticipantsCount(FormationId) == 0)
                return 0;
            else
                return context.Participants.Where(s => s.FormationID ==
                FormationId).Average(e => e.Age);
        }
        public int ParticipantsCount(int FormationId)
        {
            return context.Participants.Where(s => s.FormationID ==
            FormationId).Count();
        }

    }
}