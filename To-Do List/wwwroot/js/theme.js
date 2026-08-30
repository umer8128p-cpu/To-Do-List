/* ============================================================================ */
/* THEME TOGGLE - Dark/Light Mode Support */
/* ============================================================================ */

(function () {
  'use strict';

  const THEME_KEY = 'taskflow-theme';
  const DARK_THEME = 'dark';
  const LIGHT_THEME = 'light';

  /**
   * Get saved theme preference or use system preference
   */
  function getSavedTheme() {
    const saved = localStorage.getItem(THEME_KEY);
    if (saved) {
      return saved;
    }

    // Check system preference
    if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
      return DARK_THEME;
    }

    return LIGHT_THEME;
  }

  /**
   * Apply theme to the document
   */
  function applyTheme(theme) {
    const html = document.documentElement;
    html.setAttribute('data-theme', theme);
    localStorage.setItem(THEME_KEY, theme);
    updateThemeIcon(theme);
  }

  /**
   * Update the theme toggle icon
   */
  function updateThemeIcon(theme) {
    const icon = document.querySelector('#themeToggle i');
    if (icon) {
      if (theme === DARK_THEME) {
        icon.className = 'bi bi-sun-fill';
      } else {
        icon.className = 'bi bi-moon-stars-fill';
      }
    }
  }

  /**
   * Toggle between light and dark themes
   */
  function toggleTheme() {
    const current = document.documentElement.getAttribute('data-theme');
    const newTheme = current === DARK_THEME ? LIGHT_THEME : DARK_THEME;
    applyTheme(newTheme);
  }

  // Initialize theme on page load
  document.addEventListener('DOMContentLoaded', function () {
    const theme = getSavedTheme();
    applyTheme(theme);

    // Attach theme toggle listener
    const themeToggle = document.getElementById('themeToggle');
    if (themeToggle) {
      themeToggle.addEventListener('click', toggleTheme);
    }
  });

  // Listen for system theme changes
  if (window.matchMedia) {
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (e) => {
      const newTheme = e.matches ? DARK_THEME : LIGHT_THEME;
      applyTheme(newTheme);
    });
  }

  // Expose toggle function globally
  window.toggleTheme = toggleTheme;
})();
