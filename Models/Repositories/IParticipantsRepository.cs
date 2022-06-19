namespace GestionFormation.Models.Repositories
{
    public interface IParticipantsRepository
    {
        IList<Participants> GetAll();
        Participants GetById(int id);
        void Add(Participants s);
        void Edit(Participants s);
        void Delete(Participants s);
        IList<Participants> GetParticipantssByFormationID(int? FormationId);
        IList<Participants> FindByName(string name);

    }
}
