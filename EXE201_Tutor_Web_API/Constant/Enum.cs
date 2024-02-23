using System.ComponentModel;

namespace EXE201_Tutor_Web_API.Constant
{
    public class Enum
    {
        public enum MessageCode
        {
            [Description("Is Valid")]
            IsValid = 100,

            [Description("Successfully")]
            Success = 200,

            [Description("No Content")]
            NoContent = 204,

            [Description("Not Valid")]
            NotValid = 400,

            [Description("Not Found")]
            NotFound = 404,

            [Description("Unexpected")]
            Exeption = 500,
        }

        public enum SendMailResult
        {
            Success,
            Failed
        }
        public enum MoocDetailType
        {
            [Description("Quiz")]
            IsQuiz = 1,

            [Description("Document")]
            IsDocument = 2,

            [Description("Video")]
            IsVideo = 3,

          
        }



    }
}
