﻿using EXE201_Tutor_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MailKit;
using EXE201_Tutor_Web_API.Services.MailService;
using EXE201_Tutor_Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web.Controllers
{
    public class CourseController : Controller
    {

        public readonly EXE_DataBaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ISendMailService _mailService;
        public CourseController(EXE_DataBaseContext context, IWebHostEnvironment hostingEnvironment, ISendMailService mailService)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            List<Coursera> courseras = _context.Courseras.ToList();
            TempData["ListCoursera"] = courseras;
            return View();
        }

        public IActionResult UniversityChoice()
        {
            return View("University/Choice");
        }

        public IActionResult SearchPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchProcess()
        {
            return View("SearchPage");
        }


        public IActionResult UniversityOnlineTutorRegister()
        {
            return View("University/OnlineTutorRegister");
        }

        public IActionResult UniversityCourseList()
        {
            return View("University/CourseList");
        }

        [HttpGet]
        public IActionResult UniversityEnglishCourseSchedule(int courseraId)
        {
            TempData["LayoutType"] = "Layout_2";
            Coursera coursera = _context.Courseras
                        .Include(c => c.CourseraDetails)
                        .FirstOrDefault(c => c.CourseraId == courseraId);
            TempData["Coursera"] = coursera;
            return View("University/English/Schedule");
        }

        //FirstWeek
        public IActionResult UniversityEnglishCourseFirstWeek(int courseraId)
        {
            TempData["LayoutType"] = "Layout_2";
            Coursera coursera = _context.Courseras
                         .Include(c => c.CourseraDetails)
                         .FirstOrDefault(c => c.CourseraId == courseraId);
            int courseraDetailId = coursera.CourseraDetails.Where(cd => cd.CodeName.Equals("TUAN1")).FirstOrDefault().CourseraDetailId;
            TempData["CourseraId"] = courseraId;
            TempData["CourseraDetailId"] = courseraDetailId;
            return View("University/English/FirstWeek/Index");
        }
        public IActionResult UniversityEnglishCourseFirstWeekVideo(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/FirstWeek/Video/Index");
        }

        public IActionResult UniversityEnglishCourseFirstWeekLessonVideo(int courseDetailId, int courseraId, string videoName)
        {
            TempData["LayoutType"] = "Layout_2";
            ViewData["VideoName"] = videoName;
            TempData["CourseraId"] = courseraId;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/FirstWeek/Video/LessonVideo");
        }

        public IActionResult UniversityEnglishCourseFirstWeekDocument(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/FirstWeek/Document/Index");
        }
        public IActionResult UniversityEnglishCourseFirstWeekQuiz(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/FirstWeek/Quiz/Index");
        }
        // Tuần 2
        public IActionResult UniversityEnglishCourseSecondWeek(int courseraId)
        {
            TempData["LayoutType"] = "Layout_2";
            Coursera coursera = _context.Courseras
                         .Include(c => c.CourseraDetails)
                         .FirstOrDefault(c => c.CourseraId == courseraId);
            int courseraDetailId = coursera.CourseraDetails.Where(cd => cd.CodeName.Equals("TUAN2")).FirstOrDefault().CourseraDetailId;
            Console.WriteLine();
            TempData["CourseraId"] = courseraId;
            TempData["CourseraDetailId"] = courseraDetailId;
            return View("University/English/SecondWeek/Index");
        }

        public IActionResult UniversityEnglishCourseSecondWeekVideo(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/SecondWeek/Video/Index");
        }

        public IActionResult UniversityEnglishCourseSecondWeekLessonVideo(int courseDetailId, int courseraId, string videoName)
        {
            TempData["LayoutType"] = "Layout_2";
            ViewData["VideoName"] = videoName;
            TempData["CourseraId"] = courseraId;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/SecondWeek/Video/LessonVideo");
        }

        public IActionResult UniversityEnglishCourseSecondWeekDocument(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/SecondWeek/Document/Index");
        }

        public IActionResult UniversityEnglishCourseSecondWeekQuiz(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/SecondWeek/Quiz/Index");
        }

        // Tuần 3
        public IActionResult UniversityEnglishCourseThirdWeek(int courseraId)
        {
            TempData["LayoutType"] = "Layout_2";
            Coursera coursera = _context.Courseras
                         .Include(c => c.CourseraDetails)
                         .FirstOrDefault(c => c.CourseraId == courseraId);
            int courseraDetailId = coursera.CourseraDetails.Where(cd => cd.CodeName.Equals("TUAN3")).FirstOrDefault().CourseraDetailId;
            TempData["CourseraId"] = courseraId;
            TempData["CourseraDetailId"] = courseraDetailId;
            return View("University/English/ThirdWeek/Index");
        }

        public IActionResult UniversityEnglishCourseThirdWeekVideo(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/ThirdWeek/Video/Index");
        }

        public IActionResult UniversityEnglishCourseThirdWeekLessonVideo(string videoName)
        {
            TempData["LayoutType"] = "Layout_2";
            ViewData["VideoName"] = videoName;
            return View("University/English/ThirdWeek/Video/LessonVideo");
        }

        public IActionResult UniversityEnglishCourseThirdWeekDocument(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/ThirdWeek/Document/Index");
        }

        public IActionResult UniversityEnglishCourseThirdWeekQuiz(int courseDetailId, string codeName)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals(codeName)).FirstOrDefault();
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/ThirdWeek/Quiz/Index");
        }


        //FourthWeek
        public IActionResult UniversityEnglishCourseFourthWeek(int courseraId)
        {
            TempData["LayoutType"] = "Layout_2";
            Coursera coursera = _context.Courseras
                         .Include(c => c.CourseraDetails)
                         .FirstOrDefault(c => c.CourseraId == courseraId);
            int courseraDetailId = coursera.CourseraDetails.Where(cd => cd.CodeName.Equals("TUAN4")).FirstOrDefault().CourseraDetailId;
            TempData["CourseraId"] = courseraId;
            TempData["CourseraDetailId"] = courseraDetailId;
            return View("University/English/FourthWeek/Index");
        }
        public IActionResult UniversityEnglishCourseFourthWeekAssignment()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/FourthWeek/Assignment/Index");
        }
        public IActionResult UniversityEnglishCourseFourthWeekDiscussion()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/FourthWeek/Discussion/Index");
        }
        public IActionResult UniversityEnglishCourseFourthWeekAssignmentSubmit(IFormFile docxFile)
        {
            if (docxFile != null && docxFile.Length > 0)
            {
                try
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "doc");

                    string uniqueFileName = docxFile.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        docxFile.CopyTo(fileStream);
                    }
                    MailContent content = new MailContent
                    {
                        To = "quanglinhta186@gmail.com",
                        Subject = "Assigment Submit",
                        Body = GenerateEmailBody("English", "Fourth Week", "Assignment", "Discuss the impact of technology on modern education"),
                        fileName = uniqueFileName
                    };
                    _mailService.SendMail(content);
                }
                catch (Exception ex)
                {

                }
            }
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/FourthWeek/Assignment/Index");
        }

        private string GenerateEmailBody(string courseName, string week, string assignmentType, string assignmentTopic)
        {
            string body = $@"
            <p><strong>Xin chào,</strong></p>
            <p>Dưới đây là thông tin về bài tập của khoá học {courseName}, tuần {week}.</p>
            <p>Loại bài tập: {assignmentType}</p>
            <p>Chủ đề bài tập: {assignmentTopic}</p>
            <p>Vui lòng xem tệp đính kèm để tham khảo chi tiết.</p>
            <p>Trân trọng,</p>";

            return body;
        }
    }
}
