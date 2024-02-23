using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Models.Models;
using Patient_Models.Repository.Implementation;
using Patient_Models.Repository.Interfaces;
using Patient_Models.ViewModels;

namespace Excel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<Patients_Information> _patients_Information;
        private readonly IGenericRepo<NCD_Details> _nCD_Details;
        private readonly IGenericRepo<Allergies_Details> _allergies_Details;
        public PatientController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _patients_Information = unitOfWork.GetRepo<Patients_Information>();
            _nCD_Details = unitOfWork.GetRepo<NCD_Details>();
            _allergies_Details = unitOfWork.GetRepo<Allergies_Details>();
        }
        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatientData()
        {
            try
            {
                var data = await _patients_Information.GetAllPatients();
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //for ncd name and allergy name get attemt

        //public async Task<IActionResult> GetAllPatientData()
        //{
        //    try
        //    {
        //        var data = await patientRepo.GetAllData()
        //            .Include(p => p.Disease)
        //            .Include(p => p.NCD_Details)
        //            .Include(p => p.Allergies_Details)
        //            .ToListAsync();

        //        return Ok(data);
        //    }
        //    catch (Exception)
        //    {
        //        // Handle exception appropriately
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}



        [HttpGet("GetPatientById/{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var data = await _patients_Information.GetPatientById(x => x.PatientId == id);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("InsertPatient")]
        public async Task<IActionResult> InsertPatient(PatientInputModel data)
        {
            //insert into tblPatient
            Patients_Information patient = new Patients_Information
            {
                PatientName = data.PatientName,
                Epilepsy = data.Epilepsy,
                DiseaseId = data.DiseaseId
            };

            await _patients_Information.InsertPatient(patient);
            await _unitOfWork.CompleteAsync();

            //insert into tblNCD_Details
            foreach (int ncdId in data.NCD_Ids)
            {
                NCD_Details ncd_details = new NCD_Details
                {
                    NCD_Id = ncdId,
                    PatientId = patient.PatientId
                };
                await _nCD_Details.InsertPatient(ncd_details);
                await _unitOfWork.CompleteAsync();
            }

            //insert into tblAllergy_Details
            foreach (int allergyId in data.Allergy_Ids)
            {
                Allergies_Details allergies_Details = new Allergies_Details
                {
                    AllergyId = allergyId,
                    PatientId = patient.PatientId
                };
                await _allergies_Details.InsertPatient(allergies_Details);
                await _unitOfWork.CompleteAsync();
            }

            return Ok();
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(PatientInputModel data)
        {
            // update tblPatient

            Patients_Information patient = new Patients_Information
            {
                PatientId = data.PatientId,
                PatientName = data.PatientName,
                DiseaseId = data.DiseaseId,
                Epilepsy = data.Epilepsy
            };
            await _patients_Information.InsertPatient(patient);
            await _unitOfWork.CompleteAsync();

            // find out existing data and delete them.

            var existing_NCD_Details = await _nCD_Details.GetAllPatientById(x => x.PatientId == data.PatientId);

            var existing_Allergies_Details = await _allergies_Details.GetAllPatientById(x => x.PatientId == data.PatientId);

            await _nCD_Details.DeletePatient(existing_NCD_Details);
            await _allergies_Details.DeletePatient(existing_Allergies_Details);

            await _unitOfWork.CompleteAsync();

            // update tblNCD_Details

            foreach (int ncdId in data.NCD_Ids)
            {
                NCD_Details ncd_details = new NCD_Details
                {
                    NCD_Id = ncdId,
                    PatientId = data.PatientId
                };
                await _nCD_Details.InsertPatient(ncd_details);
                await _unitOfWork.CompleteAsync();
            }

            // update tblAllergies_Details

            foreach (int allergyId in data.Allergy_Ids)
            {
                Allergies_Details allergies_Details = new Allergies_Details
                {
                    AllergyId = allergyId,
                    PatientId = data.PatientId
                };
                await _allergies_Details.InsertPatient(allergies_Details);
                await _unitOfWork.CompleteAsync();
            }

            return Ok();
        }

        [HttpDelete("DeletePatient/{patientId}")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            var dataToDelete = await _patients_Information.GetPatientById(x => x.PatientId == patientId);

            if (dataToDelete != null)
            {
                await _patients_Information.DeletePatient(dataToDelete);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
