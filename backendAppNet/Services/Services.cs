using backendAppNet.DataAccess;
using backendAppNet.Models.DataModels;
using backendAppNet.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendAppNet.Services
{
    public class Services : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<User>> GetUser(string email)
        {
            var user = await _context.Users.FindAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsAdult()
        {
            return await _context.Students.Where(x => x.Dob <= DateTime.Now.AddYears(-18)).ToListAsync();
        }


        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsForCourse()
        {
            return await _context.Students.Where(x => x.Courses.Count() > 0 ).ToListAsync();
        }


        public async Task<ActionResult<IEnumerable<Courses>>> GetCoursesLevelForStudents(Levels level)
        {
            return await _context.Courses.Where(x => x.Level == level && x.Students.Count() > 0).ToListAsync();
        }


        public async Task<ActionResult<IEnumerable<Courses>>> GetCoursesLevelForCategory(Levels level, int IdCategory)
        {                           ;
            return await _context.Courses.Where(x => x.Level == level && x.Categories.Any(x => x.Id== IdCategory)).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Courses>>> GetCoursesNoStudents()
        {
            return await _context.Courses.Where(x => x.Students.Count() == 0).ToListAsync();
        }
    }
}
