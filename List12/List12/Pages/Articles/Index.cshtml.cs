﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using List12.Data;

namespace List12.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly List12.Data.MyDbContext _context;

        public IndexModel(List12.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article
                .Include(a => a.Category).ToListAsync();
        }
    }
}