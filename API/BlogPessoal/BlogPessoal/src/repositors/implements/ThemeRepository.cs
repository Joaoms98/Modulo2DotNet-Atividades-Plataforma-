﻿using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Linq;

namespace BlogPessoal.src.repositors.implements
{
    public class ThemeRepository : ITheme
    {
        #region atributes
        private readonly AppBlogContext _context;
        #endregion atributes

        #region Constructors
        public ThemeRepository(AppBlogContext context)
        {
            _context = context;
        }
        #endregion Constructors

        #region métodos
        public void AddTheme(AddThemeDTO theme)
        {
            _context.Themes.Add(new ThemeModel
            {
                Description = theme.Description,
            });
            _context.SaveChanges();
        }

        public void DeleteTheme(int id)
        {
            _context.Themes.Remove(GetThemeById(id));
            _context.SaveChanges();
        }

        public List<ThemeModel> GetThemeByDescription(string description)
        {
            return _context.Themes
                        .Where(t => t.Description.Contains(description))
                        .ToList();
        }

        public ThemeModel GetThemeById(int id)
        {
            return _context.Themes
                        .FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTheme(UpdateThemeDTO theme)
        {
            var themeUpdate = GetThemeById(theme.Id);
            themeUpdate.Description = theme.Description;
            _context.Themes.Update(themeUpdate);
            _context.SaveChanges();
        }
    }
        #endregion métodos
}
