using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModel;
using StudentAdminPortal.API.Repository;
using AutoMapper;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[Controller]")]
        public async Task<IActionResult> GetallStudents()
        {
            var Student=await studentRepository.GetStudentsAsync();
           return Ok( mapper.Map<List<Student>>(Student));
            //var domainModelStudents = new List<Student>();
            //foreach (var student in Student)
            //{
            //    domainModelStudents.Add(new Student()
            //    {
            //    Id= student.Id,
            //    FirstName= student.FirstName,
            //    LastName= student.LastName,
            //    DateOfBirth= student.DateOfBirth,
            //    Email= student.Email,
            //    mobile=student.mobile,
            //    ProfileImageUrl= student.ProfileImageUrl,
            //    GenderId= student.GenderId,
            //    Gender=new Gender()
            //    {
            //        Id=student.Gender.Id,
            //    Description= student.Gender.Description,
            //    },
            //    Address=new Address()
            //    {
            //        Id= student.Address.Id,
            //        PhysicalAddress= student.Address.PhysicalAddress,
            //        PostalAddress= student.Address.PostalAddress,


            //    }
            //    });
           // }
          //  return Ok(domainModelStudents);
        }
    }
}
