using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Models.Models;
using Patient_Models.Repository.Interfaces;

namespace Excel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<Disease_Information> _disease_Information;

        public DiseaseController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _disease_Information = this._unitOfWork.GetRepo<Disease_Information>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiseases()
        {
            try
            {
                var data = await _disease_Information.GetAllPatients();
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
