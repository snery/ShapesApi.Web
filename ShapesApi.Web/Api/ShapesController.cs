using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShapesApi.Data;
using ShapesApi.Data.Model;

namespace ReactShapes.Web.Api
{
    [Route("api/[controller]")]    
    [ApiController]
    public class ShapesController : ControllerBase
    {
        #region Private Fields

        private readonly IRepository<Shape> _shapeRepository;
        private readonly ILogger<ShapesController> _logger;

        #endregion

        #region Constructors

        public ShapesController(IRepository<Shape> shapeRepository, ILogger<ShapesController> logger)
        {
            _shapeRepository = shapeRepository;
            _logger = logger;
        }

        #endregion

        #region Public Methods
                
        [HttpGet]
        public ActionResult<IEnumerable<Shape>> GetShapes()
        {
            try
            {
                var results = _shapeRepository.GetAll("json/shape.json");
                return results.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get shapes from API all");
                throw new Exception(ex.ToString());
            }
        }

        #endregion
    }
}
