using EF_Core03.Contexts;
using EF_Core03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Operations
{
    internal static class Create
    {

        public static async Task AddInstructor(OnlineLearningPlatform dbContext, Instructor instructor)
        {
   

            dbContext.Instructors.Add(instructor);

            await dbContext.SaveChangesAsync();

            Console.WriteLine($"Instructor added successfully with Id {instructor.Id}");
        }

        public async static Task AddCategory(OnlineLearningPlatform dbContext,Category category)
        {
            dbContext.Categories.Add(category);

            await dbContext.SaveChangesAsync();

            Console.WriteLine($"Category is Added Sucessfully with Id {category.CategoryId}");
        }

        public static async Task AddNewCourse (OnlineLearningPlatform dbContext, Course course)
        {
            var IsExistingCategory = dbContext.Categories.Any(Category => Category.CategoryId == course.CategoryId);
            if (!IsExistingCategory)
            {
                Console.WriteLine("Invalid Course Catgeory");
                return;
            }

            dbContext.Courses.Add(course);
            await dbContext.SaveChangesAsync();

            Console.WriteLine($"Course is Added successfully with Id {course.Id}");
            
        }

        public static async Task AddStudents(OnlineLearningPlatform dbContext, params Student[] studnets)
        {
            dbContext.Students.AddRange(studnets);
            await dbContext.SaveChangesAsync();

            foreach (var student in studnets)
                Console.WriteLine($"Enrolled Student has {student.Id}");

        }



        public static async Task EnrollCourse(OnlineLearningPlatform dbContext, int studentId, int courseId)
        {
            var isPublishedCourse = dbContext.PublishedCourses.Any(course => course.PublisheCourseId == courseId);
            if (!isPublishedCourse)
            {
                Console.WriteLine("Course is not Published yet");
            }

            var isExistingStudent=dbContext.Students.Any(student => student.Id == studentId);
            if(!isExistingStudent)
            {
                Console.WriteLine("Invalid Student");
                return;
            }

            try
            {
                var Enrollment = new Enrollment()
                {
                    CourseId = courseId,
                    StudentId = studentId,
                    Status="Active"
                };

                dbContext.Enrollments.Add(Enrollment);
                await dbContext.SaveChangesAsync();

                Console.WriteLine($"Student with Id {studentId} enrolled siccessfuuly in course with Id {courseId}");
            }catch(Exception ex)
            {
                Console.WriteLine("Error: Student already Enrolled");
            }


        }
    }
}
