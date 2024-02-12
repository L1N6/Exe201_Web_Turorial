using EXE201_Tutor_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UniversityChoice()
        {
            return View("University/Choice");
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
    }
}
