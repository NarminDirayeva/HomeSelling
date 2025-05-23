﻿using Microsoft.EntityFrameworkCore;
using MVCProject.DAL;

namespace MVCProject.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
      
        public LayoutService(AppDbContext context)
        {
            _context = context;
            

        }
        public async Task<Dictionary<string, string>> GetSettingsAsync()
        {
            var settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
            return settings;
        }
    }
}
