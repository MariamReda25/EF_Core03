using EF_Core03.Contexts;
using EF_Core03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Operations
{
    internal static class Read
    {

        public static async Task<Course> GetCourseById(OnlineLearningPlatform dbContext,int courseId)
        {
            var course = dbContext.Courses.FindAsync( courseId).Result;
            if (course is not null) return course;

            return default;
        }
        public static async Task<Course> GetCourseByTitle(OnlineLearningPlatform dbContext,string courseTitle)
        {
            var course =await dbContext.Courses.FirstOrDefaultAsync(course=>course.Title==courseTitle);
            if (course is not null) return course;

            return default;
        }


        public static  void FilterCourse(OnlineLearningPlatform dbContext,int min,int max)
        {
            var courses = dbContext.Courses.Where(course => course.Price >= min && course.Price <= max)
                                            .OrderByDescending(course=>course.Price);

           foreach (var course in courses)
                Console.WriteLine($"Course {course.Title} with {course.Level} has Price {course.Price}");
        }

        public static void GetbyCategories(OnlineLearningPlatform dbContext,int categoryId)
        {
            var subCategories = dbContext.Categories.Where(category => category.SuperCategoryId == categoryId)
                                                    .Select(category=>category);

            if (subCategories is not null)
                foreach (var category in subCategories)
                     Console.WriteLine($"{category.Name}-{category?.SuperCatgory?.CategoryId}");


        }

        public static async Task CourseRoster(OnlineLearningPlatform dbContext,int courseId)
        {
            var studnets = dbContext.Enrollments.Where(enroll => enroll.CourseId == courseId)
                                                .Select(enroll=>enroll.EnrolledStudent.FullName);

            Console.WriteLine(studnets.Count());

            foreach (var student in studnets)
            {
               
                Console.WriteLine(student);
            }


        }

    }
}
