using EXE201_Tutor_Web.Models;
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
            List<Coursera> courseras = _context.Courseras
                .Include(c => c.OnCoursera)
                .ToList();
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

        //MoocWeek
        public IActionResult UniversityEnglishCourseMoocWeek(int courseraId, string week)
        {
            TempData["LayoutType"] = "Layout_2";
            Coursera coursera;
            int courseraDetailId;
            List<Mooc> moocs;
            if (string.IsNullOrEmpty(week))
            {
                coursera = _context.Courseras
                        .Include(c => c.CourseraDetails)
                        .FirstOrDefault(c => c.CourseraId == courseraId);
                courseraDetailId = coursera.CourseraDetails.Where(cd => cd.CodeName.Equals("TUAN1")).FirstOrDefault().CourseraDetailId;
                moocs = _context.Moocs
                    .Include(m => m.MoocDetails)
                    .Where(m => m.CourseraDetailId == courseraDetailId).ToList();

                TempData["Coursera"] = coursera;
                TempData["CourseraDetailId"] = courseraDetailId;
                TempData["ListMooc"] = moocs;
                return View("University/English/MoocWeek/Index");
            }
            coursera = _context.Courseras
                        .Include(c => c.CourseraDetails)
                        .FirstOrDefault(c => c.CourseraId == courseraId);
            courseraDetailId = coursera.CourseraDetails.Where(cd => cd.CodeName.Equals(week)).FirstOrDefault().CourseraDetailId;
            moocs = _context.Moocs
               .Include(m => m.MoocDetails)
               .Where(m => m.CourseraDetailId == courseraDetailId).ToList();

            TempData["Coursera"] = coursera;
            TempData["CourseraDetailId"] = courseraDetailId;
            TempData["ListMooc"] = moocs;
            return View("University/English/MoocWeek/Index");
        }

        public IActionResult UniversityEnglishCourseMoocWeekRedirect(int courseDetailId)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc moocVideo = _context.Moocs
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals("video")).FirstOrDefault();

            if (moocVideo == null)
            {
                Mooc moocAss = _context.Moocs
                .Where(m => m.CourseraDetailId == courseDetailId && m.CodeName.Equals("ass")).FirstOrDefault();
                return UniversityEnglishCourseMoocWeekFinalTest(moocAss.MoocId);
            }
            return UniversityEnglishCourseMoocWeekPractice(moocVideo.MoocId);
        }

        public IActionResult UniversityEnglishCourseMoocWeekPractice(int moocId)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.MoocId == moocId).FirstOrDefault();
            int courseDetailId = mooc.CourseraDetail.CourseraDetailId;
            List<Mooc> moocs = _context.Moocs
               .Where(m => m.CourseraDetailId == courseDetailId).ToList();
            TempData["ListMooc"] = moocs;
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            if (mooc.CodeName.Equals("video"))
            {
                return View("University/English/MoocWeek/Video/Index");
            }
            else if (mooc.CodeName.Equals("doc"))
            {
                return View("University/English/MoocWeek/Document/Index");
            }
            else if (mooc.CodeName.Equals("ass") || mooc.CodeName.Equals("discuss"))
            {
                return UniversityEnglishCourseMoocWeekFinalTest(moocId);
            }
            return View("University/English/MoocWeek/Quiz/Index");
        }

        public IActionResult UniversityEnglishCourseMoocWeekLessonVideo(int courseDetailId, int moocId, int moocDetailId)
        {
            TempData["LayoutType"] = "Layout_2";
            List<Mooc> moocs = _context.Moocs
               .Where(m => m.CourseraDetailId == courseDetailId).ToList();
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .FirstOrDefault(m => m.MoocId == moocId);
            MoocDetail moocDetail = _context.MoocDetails.FirstOrDefault(m => m.MoocDetailId == moocDetailId);
            TempData["ListMooc"] = moocs;
            TempData["Mooc"] = mooc;
            TempData["MoocDetail"] = moocDetail;
            TempData["CourseraDetailId"] = courseDetailId;
            return View("University/English/MoocWeek/Video/LessonVideo");
        }
        public IActionResult UniversityEnglishCourseMoocWeekFinalTest(int moocId)
        {
            TempData["LayoutType"] = "Layout_2";
            Mooc mooc = _context.Moocs
                .Include(m => m.MoocDetails)
                .Include(m => m.CourseraDetail)
                .Include(m => m.OnMoocs)
                .Where(m => m.MoocId == moocId).FirstOrDefault();
            int courseDetailId = mooc.CourseraDetail.CourseraDetailId;
            List<Mooc> moocs = _context.Moocs
               .Where(m => m.CourseraDetailId == courseDetailId).ToList();
            TempData["ListMooc"] = moocs;
            TempData["Mooc"] = mooc;
            TempData["CourseraDetailId"] = courseDetailId;
            if (mooc.CodeName.Equals("ass"))
            {
                return View("University/English/MoocWeek/Assignment/Index");
            }
            return View("University/English/MoocWeek/Discussion/Index");

        }
        public IActionResult UniversityEnglishCourseAssignmentSubmit(IFormFile docxFile, string moocId)
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
            return UniversityEnglishCourseMoocWeekFinalTest(int.Parse(moocId));
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
