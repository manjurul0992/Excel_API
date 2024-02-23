using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Models.Models;
using Patient_Models.Repository.Interfaces;

namespace Excel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<NCD> _nCD;
        public NCDController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _nCD = this._unitOfWork.GetRepo<NCD>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNCDs()
        {
            try
            {
                var data = await _nCD.GetAllPatients();
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

