using Excel_Client.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Patient_Models.Enums;
using Patient_Models.Models;
using Patient_Models.ViewModels;

namespace Excel_Client.Controllers
{
    public class PatientController : Controller
    {

        WebApi api = new WebApi();

        //public async Task<IActionResult> AllPatients()
        //{
        //    List<Patient> patientList = new List<Patient>();
        //    HttpClient client = api.Initial();
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:7086/api/Patient/GetAllPatient");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        patientList = JsonConvert.DeserializeObject<List<Patient>>(result);
        //    }
        //    return View(patientList);

        //}

        // ... (existing code)

        public async Task<IActionResult> AllPatients()
        {
            List<PatientDetailsViewModel> patientDetailsListVM = new List<PatientDetailsViewModel>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7086/api/Patient/GetAllPatient");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var patients = JsonConvert.DeserializeObject<List<Patients_InformationVM>>(result);

                foreach (var patient in patients)
                {
                    var patientDetails = new PatientDetailsViewModel
                    {
                        PatientId = patient.PatientId,
                        PatientName = patient.PatientName,
                        Epilepsy = patient.Epilepsy,
                        DiseaseId = patient.DiseaseId,
                        DiseaseName = patient.DiseaseName,
                        NCD_Ids = patient.NCD_Ids,
                        Allergy_Ids = patient.Allergy_Ids,
                        NCD_Names = await GetNCDNames(patient.NCD_Ids),
                        Allergy_Names = await GetAllergyNames(patient.Allergy_Ids)
                    };

                    patientDetailsListVM.Add(patientDetails);
                }
            }

            return View(patientDetailsListVM);
        }

        private async Task<List<string>> GetNCDNames(List<int>? ncdIds)
        {
            if (ncdIds == null || !ncdIds.Any())
            {
                return new List<string>();
            }

            var ncdList = await GetAllNCDs();

            return ncdList.Where(ncd => ncdIds.Contains(ncd.NCD_Id)).Select(ncd => ncd.NCD_Name).ToList();
        }

        private async Task<List<string>> GetAllergyNames(List<int>? allergyIds)
        {
            if (allergyIds == null || !allergyIds.Any())
            {
                return new List<string>();
            }

            var allergyList = await GetAllAllergies();

            return allergyList.Where(allergy => allergyIds.Contains(allergy.AllergyId)).Select(allergy => allergy.AllergyName).ToList();
        }





        public async Task<IEnumerable<Disease_Information>> GetAllDisease()
        {
            List<Disease_Information> diseaselist = new List<Disease_Information>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7086/api/Disease");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                diseaselist = JsonConvert.DeserializeObject<List<Disease_Information>>(result);
            }
            return diseaselist;
        }

        public async Task<IEnumerable<NCD>> GetAllNCDs()
        {
            List<NCD> ncdList = new List<NCD>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7086/api/NCD");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                ncdList = JsonConvert.DeserializeObject<List<NCD>>(result);
            }
            return ncdList;
        }

        public async Task<IEnumerable<Allergies>> GetAllAllergies()
        {
            List<Allergies> allergyList = new List<Allergies>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7086/api/Allergies");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                allergyList = JsonConvert.DeserializeObject<List<Allergies>>(result);
            }
            return allergyList;
        }
        [HttpGet]
        public async Task<IActionResult> InsertPatient()
        {
            var diseaseList = await GetAllDisease();
            ViewBag.diseases = new SelectList(diseaseList, "DiseaseId", "DiseaseName");

            var epilepsy = Enum.GetValues(typeof(Epilepsy)).Cast<Epilepsy>();
            ViewBag.epilepsy = new SelectList(epilepsy);

            var ncdList = await GetAllNCDs();
            ViewBag.ncds = ncdList;

            var allergyList = await GetAllAllergies();
            ViewBag.allergies = allergyList;

            return View();
        }

        [HttpPost]
      
        public async Task<IActionResult> InsertPatient(PatientInputModel modelData, [FromForm] List<int> NCD_Ids)
        {
            HttpClient client = api.Initial();

            var postData = client.PostAsJsonAsync<PatientInputModel>("https://localhost:7086/api/Patient/InsertPatient", modelData);

            postData.Wait();

            var result = postData.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("AllPatients");
            }

            return View();
        }

        public async Task<IActionResult> EditPatient(int id)
        {
            // Fetch patient data by id
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7086/api/Patient/GetPatientById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var patient = JsonConvert.DeserializeObject<PatientInputModel>(result);

                // Fetch additional data needed for dropdowns, similar to InsertPatient action

                return View(patient);
            }

            return RedirectToAction("AllPatients");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPatient(PatientInputModel modelData, [FromForm] List<int> NCD_Ids)
        {
            // Update patient data
            HttpClient client = api.Initial();
            var putData = client.PutAsJsonAsync<PatientInputModel>("https://localhost:7086/api/Patient/UpdatePatient", modelData);

            putData.Wait();

            var result = putData.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("AllPatients");
            }

            // Handle errors if needed
            return View(modelData);
        }
       
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = new Patients_InformationVM();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7086/api/Patient/DeletePatient/{id}");

            return RedirectToAction("AllPatients");
        }
        
    }
}

