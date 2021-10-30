using Microsoft.AspNetCore.Mvc;
using StudentManagementWithWS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementWithWS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ITeacherService m_studentService;
        public StudentsController(ITeacherService studentService)
        {
            m_studentService = studentService;
        }
        [HttpGet]
        public IActionResult SearchTeacher(string keyword, string hutechClass)
        {
            return Ok(m_studentService.SearchTeacher(keyword, hutechClass));
        }
        [HttpGet("{id}")]
        public IActionResult LoadTeacherById(int id)
        {
            return Ok(m_studentService.LoadTeacherById(id));
        }
        [HttpPost]
        public IActionResult UpdateOrCreateTeacher(Teacher student)
        {
            m_studentService.UpdateOrCreateTeacher(student);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacherById(int id)
        {
            m_studentService.DeleteTeacherById(id);
            return Ok();
        }
    }
}