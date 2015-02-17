using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebM.Models;
using WebM.Models.Gateway;

namespace WebM.Controllers
{
    public class TreatmentController : Controller
    {
        private CenterGatewayDB db = new CenterGatewayDB();
        private TreatmentGatewayDB treatmentGateway = new TreatmentGatewayDB();

        // GET: /Treatment/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Treatment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // GET: /Treatment/Create
        public ActionResult Create()
        {
            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Nmae");
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "GenericName");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
            return View();
        }

        // POST: /Treatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrescriptionId,Date,VoterId,Observation,Dose,BeforeAfter,QuantityGiven,Note,PatientId,DoctorId,DiseaseId,MedicineId")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name", prescription.DiseaseId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Nmae", prescription.DoctorId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "GenericName", prescription.MedicineId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", prescription.PatientId);
            return View(prescription);
        }

        // GET: /Treatment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name", prescription.DiseaseId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Nmae", prescription.DoctorId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "GenericName", prescription.MedicineId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", prescription.PatientId);
            return View(prescription);
        }

        // POST: /Treatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrescriptionId,Date,VoterId,Observation,Dose,BeforeAfter,QuantityGiven,Note,PatientId,DoctorId,DiseaseId,MedicineId")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name", prescription.DiseaseId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Nmae", prescription.DoctorId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "GenericName", prescription.MedicineId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", prescription.PatientId);
            return View(prescription);
        }

        // GET: /Treatment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: /Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescriptions.Find(id);
            db.Prescriptions.Remove(prescription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetVoter(string voterId)
        {
            string uri = "http://nerdcastlebd.com/web_service/voterdb/index.php/voters/voter/" + voterId + "";

            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes("voter");
            Patient aPatient = new Patient();
            foreach (XmlNode node in nodes)
            {
                var selectSingleNode1 = node.SelectSingleNode("id");
                if (selectSingleNode1 != null)
                    aPatient.VoterId = Convert.ToInt64(selectSingleNode1.InnerText);
                else
                {
                    aPatient.VoterId = 0;
                }

                var xmlNode = node.SelectSingleNode("name");
                if (xmlNode != null)
                    aPatient.Name = xmlNode.InnerText;

                var singleNode = node.SelectSingleNode("address");
                if (singleNode != null)
                    aPatient.Address = singleNode.InnerText;

                var selectSingleNode = node.SelectSingleNode("date_of_birth");
                if (selectSingleNode != null)
                    aPatient.DateOfBirth = Convert.ToDateTime(selectSingleNode.InnerText);
            }

            int countService = db.Patients.Where(x => x.VoterId == aPatient.VoterId).ToList().Count;
            aPatient.ServiceCount = countService;
            List<Patient> aList = new List<Patient>();

            var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
            var dob = float.Parse(aPatient.DateOfBirth.ToString("yyyy.MMdd"));
            aPatient.Age = (int)(now - dob);


            aPatient.CenterId = Convert.ToInt32(Session["CenterId"].ToString());



            aPatient.DistrictId = treatmentGateway.GetDistrictId(aPatient.CenterId);


            if (aPatient.VoterId > 0)
            {
                aList.Add(aPatient);

                db.Patients.Add(aPatient);
                db.SaveChanges();
            }


            return Json(aList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FindThanas(string districtId)
        {
            int id = Convert.ToInt32(districtId);

            var thanas = db.Thanas.Where(x => x.DistrictId == id).ToList();
            return Json(thanas, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMedicines()
        {
            var medicines = db.Medicines.ToList();
            return Json(medicines, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDiseases()
        {
            var diseases = db.Diseases.ToList();
            return Json(diseases, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDoctors()
        {
            var doctors = db.Doctors.ToList();
            return Json(doctors, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDoses()
        {
            object[] dose = new object[4];

            dose[0] = new { Id = 1, Value = "1" };
            dose[1] = new { Id = 2, Value = "1+1" };
            dose[2] = new { Id = 3, Value = "1+1+1" };
            dose[3] = new { Id = 4, Value = "1+1+1+1" };

            var doses = dose.ToList();
            return Json(doses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GivePrescription(List<Prescription> prescriptions)
        {
            int CenterId = Convert.ToInt32(Session["CenterId"].ToString());
            foreach (Prescription aPrescription in prescriptions)
            {
                treatmentGateway.AddPrescription(aPrescription);
                treatmentGateway.ReduceMedicineStock(aPrescription.QuantityGiven, aPrescription.MedicineId, CenterId);

            }

            return View("Create");
        }
        public ActionResult ConvertDate(string date)
        {

            object[] dateObjects = new object[1];

            dateObjects[0] = new { Id = 1, Value = Convert.ToString(Convert.ToDateTime(date)) };

            var fullDate = dateObjects.ToList();
            return Json(fullDate, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ShowAllHistory(string VoterId, string patientName, string patientAddress)
        {
            ViewBag.VoterId = VoterId;
            ViewBag.PatientName = patientName;
            ViewBag.PatientAddress = patientAddress;

            HistoryGateway aHistoryGateway = new HistoryGateway();
            List<PatientHistory> patientHistories = aHistoryGateway.GetAllPatientHistories(Convert.ToInt64(VoterId));

            return View(patientHistories);
        }
    }
}

