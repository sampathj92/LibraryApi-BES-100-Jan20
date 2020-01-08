﻿using LibraryApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class DemoController : Controller
    {
        IGenerateIds idGenerator;

        public DemoController (IGenerateIds idGenerator)
        {
            this.idGenerator = idGenerator;
        }

        [HttpGet("/beerme/{qty:int}")]
        public IActionResult getBeer(int qty)
        {
            return Ok($"Giving you {qty} beers");
        }

        [HttpGet("blogs/{year:int:min(2015)}/{month:int:range(1,12)}/{day:int:range(1,31)}")]
        public IActionResult GetPostsFor(int year, int month, int day)
        {
            return Ok($"Getting blog posts for {year}/{month}/{day}");
        }

        [HttpGet("/magazines")]
        public IActionResult GetMagazines([FromQuery] string topic)
        {
            return Ok($"Giving you magazines for {topic}");
        }

        [HttpGet("/whoami")]
        public IActionResult WhoAmi([FromHeader(Name = "User-Agent")] string ua)
        {
            return Ok($"I see you are running {ua}");
        }

        [HttpPost("/courseenrollments")]
        public IActionResult EnrollForCourse([FromBody] EnrollmentRequest enrollment)
        {
            var response = new EnrollmentResponse
            {
                CourseId = enrollment.CourseId,
                Insturctor = enrollment.Instructor,
                EnrollmentId = idGenerator.GetEnrollmentId()
            };
            return Ok(response);
        }
    }

    public class EnrollmentRequest
    {
        public string CourseId { get; set; }
        public string Instructor { get; set; }
    }

    public class EnrollmentResponse
    {
        public string CourseId { get; set; }

        public string Insturctor { get; set; }

        public Guid EnrollmentId { get; set; }
    }

}
