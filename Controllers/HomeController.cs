using Microsoft.AspNetCore.Mvc;
using PRELIM_A2_BSIT_Cherry_Quiño.Models;
using System.Diagnostics;

namespace PRELIM_A2_BSIT_Cherry_Quiño.Controllers
{
    public class HomeController : Controller
    {
        private static List<Authors> author = new List<Authors>
        {
            new Authors { Id = 1, Name = "Avi ", AsIs = "American Author" },
            new Authors { Id = 2, Name = "Jay Asher ", AsIs = " American Author" },
            new Authors { Id = 3, Name = "Napoleon Hill", AsIs = "American Author" },
            new Authors { Id = 4, Name = "James Clear", AsIs = "American Author" },
            new Authors { Id = 5, Name = "Dan Brown", AsIs = "American Author" }

        };

        private static List<Books> books = new List<Books>
        {
             new Books { Id = 1, Title = "The Secret School",  Author = new Authors { Id = 1, Name = "Avi ", AsIs = "American Author" }, Genre = Genre.HistoricalFiction, DateLastReturned = DateTime.Now.AddDays(-1), IsAvailable = true },
             new Books { Id = 2, Title = "13 Reason Why", Author = new Authors { Id = 2, Name = "Jay Asher ", AsIs = " American Author" }, Genre = Genre.Contemporary, DateLastReturned = DateTime.Now.AddDays(-1), IsAvailable = true },
             new Books { Id = 3, Title =  " Think and Grow", Author = new Authors { Id = 3, Name = "Napoleon Hill", AsIs = "American Author" }, Genre = Genre.SelfHelp, DateLastReturned = DateTime.Now.AddDays(-1), IsAvailable = true },
             new Books { Id = 4, Title = "Atomic Habits", Author =  new Authors { Id = 4, Name = "James Clear", AsIs = "American Author" },Genre=Genre.SelfHelp, DateLastReturned = DateTime.Now.AddDays(-1), IsAvailable =true},
             new Books { Id = 5, Title = "The Da Vinci Code",  Author = new Authors { Id = 5, Name = "Dan Brown", AsIs = "American Author" }, Genre = Genre.Mystery, DateLastReturned = DateTime.Now.AddDays(-1), IsAvailable = true },

        };

        private static List<Users> users = new List<Users>
        {
            new Users
            { Id = 1,
              Name = "Borrower 1",
              BorrowedBooks = new List<Books>()

            }
        };
        public IActionResult Index()
        {
            var library = new Library
            {
                Books = books,
                Users = users,
            };

            return View(library);
        }

        public IActionResult Details(int id)
        {
            var selectedBook = books.FirstOrDefault(b => b.Id == id);
            if (selectedBook == null) return NotFound();
            return View(selectedBook);
        }

        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(Books book)
        {
            book.Id = books.Count + 1;
            book.Author = author.First();  // if Author is string
            book.DateLastReturned = DateTime.Now;
            books.Add(book);  // Add to the list
            return RedirectToAction("Index");
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(Users user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return RedirectToAction("Index");
        }
    }
}
