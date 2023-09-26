using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lab4
{
    [Route("Library")]
    public class LibraryController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LibraryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Greeting()
        {
            return Ok("Hi, you're in the library!!!");
        }

        [HttpGet("Books")]
        public IActionResult GetBooks()
        {
            var books = _configuration.GetSection("Library:Books").Get<List<string>>();
            if (books != null && books.Count > 0) 
            {
                var booksWithNumbers = books.Select((book, index) => $"{index + 1}. {book}");
                string booksList = string.Join("\n", booksWithNumbers);
                return Ok($"The list of books:\n{booksList}");
            }
            else
            {
                return Ok("The list of books is empty");
            }
        }

        [HttpGet("Profile/{id:int?}")]
        public IActionResult UserProfile(int? id)
        {
            if (id.HasValue && id >= 0 && id <= 5)
            {
                string sectionName = $"Library:Users:{id}";

                string name = _configuration[$"{sectionName}:name"];
                string surname = _configuration[$"{sectionName}:surname"];
                string age = _configuration[$"{sectionName}:age"];
                string hobby = _configuration[$"{sectionName}:hobby"];

                return Ok($"Info about user with ID {id}:\nName: {name}\nSurname: {surname}\nAge: {age}\nHobby: {hobby}");
            }
            else
            {
                string currentUserId = "0";

                string sectionName = $"Library:Users:{currentUserId}";

                string name = _configuration[$"{sectionName}:name"];
                string surname = _configuration[$"{sectionName}:surname"];
                string age = _configuration[$"{sectionName}:age"];
                string hobby = _configuration[$"{sectionName}:hobby"];

                return Ok($"Information about the user himself:\nName: {name}\nSurname: {surname}\nAge: {age}\nHobby: {hobby}");
            }
        }

    }
}
