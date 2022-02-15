using MVCAppWithDB.Models;
using MVCAppWithModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppWithModel.Controllers
{

    public class StudentController : Controller
    {

        // GET: Student/GetAllStudentDetails    
        public ActionResult GetAllStudentDetails()
        {

            StudentRepository StudentRepo = new StudentRepository();
            ModelState.Clear();
            return View(StudentRepo.GetAllStudents());
        }



        // GET: Student/AddStudent   
        public ActionResult AddStudent()
        {
            return View();
        }

        // POST: Student/AddStudent    
        [HttpPost]
        public ActionResult AddStudent(StudentModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentRepository StudentRepo = new StudentRepository();

                    if (StudentRepo.AddStudent(student))
                    {
                        ViewBag.Message = "Student details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/EditStudentDetails/5    
        public ActionResult EditStudentDetails(int id)
        {
            StudentRepository StudentRepo = new StudentRepository();

            return View(StudentRepo.GetAllStudents().Find(Student => Student.ID == id));

        }

        // POST: Student/EditStudentDetails/5    
        [HttpPost]

        public ActionResult EditStudentDetails(int id, StudentModel obj)
        {
            try
            {
                StudentRepository StudentRepo = new StudentRepository();

                StudentRepo.UpdateStudent(obj);
                return RedirectToAction("GetAllStudentDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/DeleteStudent/5    
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                StudentRepository StudentRepo = new StudentRepository();
                if (StudentRepo.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student details deleted successfully";

                }
                return RedirectToAction("GetAllStudentDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}
