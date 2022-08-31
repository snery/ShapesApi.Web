namespace ShapesApi.Data
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll(string filePath);
    }
}
