using LibraryApi.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BookController:Controller
    {

        LibraryDataContext Context;

        public BookController(LibraryDataContext context)
        {
            Context = context;
        }

        [HttpGet("/books")]
        public IActionResult GetAllBooks()
        {
            return Ok(Context.Books.ToList());
        }
    }
}
