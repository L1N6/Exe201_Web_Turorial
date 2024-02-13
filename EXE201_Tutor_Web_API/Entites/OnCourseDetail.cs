﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web_API.Entites
{
    public class OnCourseDetail
    {
        [Key]
        public int OnCourseDetailId { get; set; }

        public DateTime? Date { get; set; }
        public string? Status { get; set; }

        [ForeignKey("CourseraDetail")]
        public int? CourseraDetailId { get; set; }

        public virtual CourseraDetail? CourseraDetail { get; set; }

        [ForeignKey("OnCourse")]
        public int? OnCourseId { get; set; }

        public virtual OnCourse? OnCourse { get; set; }

        // Add navigation properties for related entities
        public virtual ICollection<OnMooc>? OnMoocs { get; set; }
    }
}
