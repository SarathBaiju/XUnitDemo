namespace XUnitDemo.Repository
{
    public class PeopleData
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
    public interface IPeopleRepository
    {
        IEnumerable<PeopleData> GetAll();
    }

    public class PeopleRepository : IPeopleRepository
    {
        public IEnumerable<PeopleData> GetAll()
        {
            return Enumerable.Empty<PeopleData>();
        }
    }
}
