using EXE201_Tutor_Web.Models;
using EXE201_Tutor_Web.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MailKit;
using EXE201_Tutor_Web_API.Services.MailService;

namespace EXE201_Tutor_Web.Controllers
{
    public class CourseController : Controller
    {

        public readonly Exe201_Tutor_Context _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ISendMailService _mailService;
        public CourseController(Exe201_Tutor_Context context, IWebHostEnvironment hostingEnvironment, ISendMailService mailService)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
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

        public IActionResult UniversityEnglishCourseSchedule()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/Schedule");
        }

        //FirstWeek
        public IActionResult UniversityEnglishCourseFirstWeek()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/FirstWeek/Index");
        }
        public IActionResult UniversityEnglishCourseFirstWeekVideo()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/FirstWeek/Video/Index");
        }

        public IActionResult UniversityEnglishCourseFirstWeekLessonVideo(string videoName)
        {
            TempData["LayoutType"] = "Layout_2";
            ViewData["VideoName"] = videoName;
            return View("University/English/FirstWeek/Video/LessonVideo");
        }

        public IActionResult UniversityEnglishCourseFirstWeekDocument()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/FirstWeek/Document/Index");
        }
        public IActionResult UniversityEnglishCourseFirstWeekQuiz()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/FirstWeek/Quiz/Index");
        }
        //SecondWeek
        public IActionResult UniversityEnglishCourseSecondWeek()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/SecondWeek/Index");
        }
        public IActionResult UniversityEnglishCourseSecondWeekVideo()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/SecondWeek/Video/Index");
        }

        public IActionResult UniversityEnglishCourseSecondWeekLessonVideo(string videoName)
        {
            TempData["LayoutType"] = "Layout_2";
            ViewData["VideoName"] = videoName;
            return View("University/English/SecondWeek/Video/LessonVideo");
        }

        public IActionResult UniversityEnglishCourseSecondWeekDocument()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/SecondWeek/Document/Index");
        }
        public IActionResult UniversityEnglishCourseSecondWeekQuiz()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/SecondWeek/Quiz/Index");
        }
        //ThirdWeek
        public IActionResult UniversityEnglishCourseThirdWeek()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/ThirdWeek/Index");
        }
        public IActionResult UniversityEnglishCourseThirdWeekVideo()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/ThirdWeek/Video/Index");
        }

        public IActionResult UniversityEnglishCourseThirdWeekLessonVideo(string videoName)
        {
            TempData["LayoutType"] = "Layout_2";
            ViewData["VideoName"] = videoName;
            return View("University/English/ThirdWeek/Video/LessonVideo");
        }

        public IActionResult UniversityEnglishCourseThirdWeekDocument()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/ThirdWeek/Document/Index");
        }
        public IActionResult UniversityEnglishCourseThirdWeekQuiz()
        {
            TempData["LayoutType"] = "Layout_2";
            return View("University/English/ThirdWeek/Quiz/Index");
        }

        //FourthWeek
        public IActionResult UniversityEnglishCourseFourthWeek()
        {
            TempData["LayoutType"] = "Layout_2";
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
