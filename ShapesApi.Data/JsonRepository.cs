using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ShapesApi.Data
{
    public class JsonRepository<T> : IRepository<T> where T : class
    {
        #region Private Fields

        private readonly ILogger<JsonRepository<T>> _logger;

        #endregion

        #region Constructors

        public JsonRepository(ILogger<JsonRepository<T>> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Public Methods

        public IEnumerable<T> GetAll(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var json = reader.ReadToEnd();
                    var results = JsonSerializer.Deserialize<IEnumerable<T>>(json);
                    return results;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Failed to read results from {filePath}");
                return Enumerable.Empty<T>();
            }
        }

        #endregion
    }
}
