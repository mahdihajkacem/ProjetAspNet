using Microsoft.EntityFrameworkCore;

namespace GestionFormation.Models.Repositories
{
    public class ParticipantsRepository:IParticipantsRepository
    {
        readonly ParticipantsContext context;
        public ParticipantsRepository(ParticipantsContext context)
        {
            this.context = context;
        }
        public IList<Participants> GetAll()
        {
            return context.Participants.OrderBy(x => x.ParticipantsName).Include(x
            => x.Formation).ToList();
        }
        public Participants GetById(int id)
        {
            return context.Participants.Where(x => x.ParticipantsId == id).Include(x => x.Formation).SingleOrDefault();
        }
        public void Add(Participants s)
        {
            context.Participants.Add(s);
            context.SaveChanges();
        }
        public void Edit(Participants s)
        {
            Participants s1 = context.Participants.Find(s.ParticipantsId);
            if (s1 != null)
            {
                s1.ParticipantsName = s.ParticipantsName;
                s1.Age = s.Age;
                s1.BirthDate = s.BirthDate;
                s1.FormationID = s.FormationID;
                context.SaveChanges();
            }
        }


        public void Delete(Participants s)
        {
            Participants s1 = context.Participants.Find(s.ParticipantsId);
            if (s1 != null)
            {
                context.Participants.Remove(s1);
                context.SaveChanges();
            }
        }
        public IList<Participants> GetParticipantssByFormationID(int? FormationId)
        {
            return context.Participants.Where(s =>
            s.FormationID.Equals(FormationId))
            .OrderBy(s => s.ParticipantsName)
            .Include(std => std.Formation).ToList();
        }
        public IList<Participants> FindByName(string name)
        {
            return context.Participants.Where(s =>
            s.ParticipantsName.Contains(name)).Include(std =>
            std.Formation).ToList();
        }

    }
}