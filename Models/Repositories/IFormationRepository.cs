namespace GestionFormation.Models.Repositories
{
    public interface IFormationRepository
    {
        IList<Formation> GetAll();
        Formation GetById(int id);
        void Add(Formation s);
        void Edit(Formation s);
        void Delete(Formation s);
        double ParticipantsAgeAverage(int FormationId);
        int ParticipantsCount(int FormationId);

    }
}
