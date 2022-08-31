using Microsoft.AspNetCore.Mvc;
using ShapesApi.Data;
using ShapesApi.Data.Model;

namespace ReactShapes.Web.Api
{
    [Route("api/[controller]")]    
    [ApiController]
    public class ColorsController : ControllerBase
    {
        #region Private Fields

        private readonly IRepository<Color> _colorRepository;
        private readonly ILogger<ColorsController> _logger;

        #endregion

        #region Constructors

        public ColorsController(IRepository<Color> shapeRepository, ILogger<ColorsController> logger)
        {
            _colorRepository = shapeRepository;
            _logger = logger;
        }

        #endregion

        #region Public Methods
                
        [HttpGet]
        public ActionResult<IEnumerable<Color>> GetShapes()
        {
            try
            {
                var results = _colorRepository.GetAll("json/color.json");
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
