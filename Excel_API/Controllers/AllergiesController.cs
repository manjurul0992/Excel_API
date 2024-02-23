using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Models.Models;
using Patient_Models.Repository.Interfaces;

namespace Excel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<Allergies> _allergies;

        public AllergiesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _allergies = unitOfWork.GetRepo<Allergies>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllergies()
        {
            try
            {
                var data = await _allergies.GetAllPatients();
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
