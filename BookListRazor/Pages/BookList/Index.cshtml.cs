using BookListRazor.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> books { get; set; }
        public async Task OnGet()
        {
           books= await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book=await _db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

              _db.Book.Remove(book);
             await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
