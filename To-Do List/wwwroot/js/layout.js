/* ============================================================================ */
/* LAYOUT INTERACTIONS - Sidebar, Mobile Nav, and Responsive Behavior */
/* ============================================================================ */

(function () {
  'use strict';

  const SIDEBAR_COLLAPSED_KEY = 'taskflow-sidebar-collapsed';
  const MOBILE_BREAKPOINT = 768;

  /**
   * Check if device is mobile
   */
  function isMobile() {
    return window.innerWidth <= MOBILE_BREAKPOINT;
  }

  /**
   * Initialize layout based on screen size
   */
  function initializeLayout() {
    const sidebar = document.getElementById('appSidebar');
    const bottomNav = document.getElementById('bottomNav');
    const fab = document.getElementById('fabButton');

    if (isMobile()) {
      // Mobile layout
      if (sidebar) sidebar.classList.remove('visible');
      if (bottomNav) bottomNav.classList.add('active');
      if (fab) fab.classList.add('active');
    } else {
      // Desktop layout
      if (bottomNav) bottomNav.classList.remove('active');
      if (fab) fab.classList.remove('active');

      // Restore sidebar state
      const isCollapsed = localStorage.getItem(SIDEBAR_COLLAPSED_KEY) === 'true';
      if (isCollapsed && sidebar) {
        sidebar.classList.add('collapsed');
      }
    }
  }

  /**
   * Toggle sidebar visibility on mobile
   */
  function toggleSidebarMobile() {
    const sidebar = document.getElementById('appSidebar');
    if (sidebar && isMobile()) {
      sidebar.classList.toggle('visible');
    }
  }

  /**
   * Toggle sidebar collapse on desktop
   */
  function toggleSidebarCollapse() {
    const sidebar = document.getElementById('appSidebar');
    if (sidebar && !isMobile()) {
      const isCollapsed = sidebar.classList.toggle('collapsed');
      localStorage.setItem(SIDEBAR_COLLAPSED_KEY, isCollapsed);
    }
  }

  /**
   * Close sidebar overlay on mobile when clicking outside
   */
  function closeSidebarOnClickOutside(event) {
    const sidebar = document.getElementById('appSidebar');
    const sidebarToggle = document.getElementById('sidebarToggle');

    if (!isMobile()) return;

    if (
      sidebar &&
      !sidebar.contains(event.target) &&
      !sidebarToggle.contains(event.target)
    ) {
      sidebar.classList.remove('visible');
    }
  }

  /**
   * Close sidebar when clicking on a navigation link
   */
  function closeSidebarOnNavigation() {
    const links = document.querySelectorAll('.sidebar-link');
    links.forEach((link) => {
      link.addEventListener('click', function () {
        if (isMobile()) {
          const sidebar = document.getElementById('appSidebar');
          if (sidebar) {
            sidebar.classList.remove('visible');
          }
        }
      });
    });
  }

  /**
   * Handle window resize events
   */
  function handleResize() {
    initializeLayout();
  }

  /**
   * Initialize all event listeners
   */
  function initializeEventListeners() {
    // Sidebar toggle
    const sidebarToggle = document.getElementById('sidebarToggle');
    if (sidebarToggle) {
      sidebarToggle.addEventListener('click', toggleSidebarMobile);
    }

    // Sidebar collapse button
    const collapseBtn = document.getElementById('sidebarCollapseBtn');
    if (collapseBtn) {
      collapseBtn.addEventListener('click', toggleSidebarCollapse);
    }

    // Close sidebar on outside click
    document.addEventListener('click', closeSidebarOnClickOutside);

    // Close sidebar on navigation
    closeSidebarOnNavigation();

    // Handle window resize
    window.addEventListener('resize', handleResize);

    // FAB button
    const fab = document.getElementById('fabButton');
    if (fab) {
      fab.addEventListener('click', function () {
        // Trigger new task modal/form
        console.log('New task clicked');
      });
    }
  }

  // Initialize on DOM ready
  document.addEventListener('DOMContentLoaded', function () {
    initializeLayout();
    initializeEventListeners();
  });

  // Expose functions globally
  window.layoutUtils = {
    isMobile,
    toggleSidebarMobile,
    toggleSidebarCollapse,
    initializeLayout
  };
})();
