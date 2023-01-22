namespace Movies.Controllers
{
    using Database;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MoviesController : Controller
    {
        private readonly MySqlDbContext _context;
        public MoviesController(MySqlDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name!.Contains(searchString));
            }
            var filteredMovies = await movies.ToListAsync();
            ViewData["movies"] = filteredMovies;
            return View();
        }
        // [HttpGet]
        public IActionResult Movie()
        { 
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetMovieById(string id)
        {
            var movies = from m in _context.Movie
                         where m.Id.Equals(id)
                         select m;
            ViewData["movies"] = await movies.ToListAsync();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AddNewMovie()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitAddNewMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _context.Movie.AddAsync(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie is not null)
            {
                _context.Movie.Remove(movie);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}