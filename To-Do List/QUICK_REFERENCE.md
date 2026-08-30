# TaskFlow Design System - Quick Reference

## 🚀 Quick Start

### Import All Styles in Layout

```html
<link rel="stylesheet" href="~/css/variables.css" />
<link rel="stylesheet" href="~/css/components.css" />
<link rel="stylesheet" href="~/css/layout.css" />
<link rel="stylesheet" href="~/css/premium-components.css" />
<link rel="stylesheet" href="~/css/dashboard.css" /> <!-- Page-specific -->
```

### Create a New Page

```html
@{ ViewData["Title"] = "Page Name"; }
<link rel="stylesheet" href="~/css/page-name.css" />

<div class="container">
	<div class="page-header">
		<div class="page-title"><h1>Title</h1></div>
		<div class="page-actions">
			<a href="#" class="btn btn-primary">Action</a>
		</div>
	</div>

	<div class="content-grid-2col">
		<div class="card">Content</div>
	</div>
</div>
```

---

## 🎨 Color Quick Reference

```
Primary:      --color-primary           #6366f1 (Indigo)
Secondary:    --color-secondary         #3b82f6 (Blue)
Success:      --color-success           #10b981 (Green)
Warning:      --color-warning           #f59e0b (Amber)
Danger:       --color-danger            #ef4444 (Red)
Info:         --color-info              #06b6d4 (Cyan)

Text:
  Primary:    --color-text-primary      Dark text
  Secondary:  --color-text-secondary    Gray text
  Tertiary:   --color-text-tertiary     Light gray text

Background:
  Default:    --color-background        Page background
  Surface:    --color-surface           Card/container background

Border:       --color-border            Default borders
```

---

## 📏 Spacing Units

```css
4px    -> var(--spacing-xs)
8px    -> var(--spacing-sm)
16px   -> var(--spacing-md)    /* Most common */
24px   -> var(--spacing-lg)    /* Cards, sections */
32px   -> var(--spacing-xl)    /* Major sections */
48px   -> var(--spacing-2xl)   /* Page sections */
64px   -> var(--spacing-3xl)   /* Large blocks */
```

**Usage:** `padding: var(--spacing-lg); margin-bottom: var(--spacing-md);`

---

## 🔘 Button Styles

```html
<button class="btn btn-primary">Primary</button>
<button class="btn btn-secondary">Secondary</button>
<button class="btn btn-outline">Outline</button>
<button class="btn btn-ghost">Ghost</button>
<button class="btn btn-success">Success</button>
<button class="btn btn-danger">Danger</button>

<!-- Sizes -->
<button class="btn btn-sm">Small</button>
<button class="btn">Normal</button>
<button class="btn btn-lg">Large</button>

<!-- Disabled -->
<button class="btn" disabled>Disabled</button>
```

---

## 🏷️ Card Component

```html
<!-- Basic Card -->
<div class="card">
	<h3>Title</h3>
	<p>Content</p>
</div>

<!-- Elevated Card -->
<div class="card card-elevated">Premium appearance</div>

<!-- Glassmorphism -->
<div class="card card-glass">Frosted glass effect</div>
```

---

## ✓ Task Card

```html
<li class="task-card">
	<input type="checkbox" class="task-checkbox" />
	<div class="task-content">
		<div class="task-title">Task Name</div>
		<div class="task-description">Optional description</div>
		<div class="task-meta">
			<span class="task-meta-item">
				<i class="bi bi-calendar"></i>
				Tomorrow
			</span>
			<span class="task-priority high">High</span>
			<span class="task-priority medium">Medium</span>
			<span class="task-priority low">Low</span>
		</div>
	</div>
	<div class="task-actions">
		<button class="task-action-btn"><i class="bi bi-pencil"></i></button>
		<button class="task-action-btn delete"><i class="bi bi-trash"></i></button>
	</div>
</li>
```

---

## 📊 Statistics Widget

```html
<!-- Gradient Card (KPI) -->
<div class="stat-card gradient">
	<div class="stat-icon"><i class="bi bi-check-circle-fill"></i></div>
	<div class="stat-value">28</div>
	<div class="stat-label">Total Tasks</div>
</div>

<!-- Regular Card -->
<div class="stat-card">
	<div class="stat-icon"><i class="bi bi-lightning"></i></div>
	<div class="stat-value">3</div>
	<div class="stat-label">Today</div>
</div>
```

---

## 📝 Form Elements

```html
<!-- Text Input -->
<div class="form-group">
	<label class="form-label">Email</label>
	<input type="email" class="form-control" placeholder="you@example.com" />
</div>

<!-- Select -->
<div class="form-group">
	<label class="form-label">Category</label>
	<select class="form-select">
		<option>Work</option>
		<option>Personal</option>
	</select>
</div>

<!-- Checkbox -->
<div class="checkbox">
	<input type="checkbox" id="agree" />
	<label for="agree">I agree to terms</label>
</div>

<!-- Radio -->
<div class="radio">
	<input type="radio" id="high" name="priority" />
	<label for="high">High Priority</label>
</div>
```

---

## 🔔 Badges & Tags

```html
<!-- Badge -->
<span class="badge">New</span>
<span class="badge badge-success">Completed</span>
<span class="badge badge-warning">Pending</span>
<span class="badge badge-danger">Blocked</span>
<span class="badge badge-info">Info</span>

<!-- Priority Tags -->
<span class="task-priority high">High</span>
<span class="task-priority medium">Medium</span>
<span class="task-priority low">Low</span>

<!-- Category Chip -->
<span class="category-chip">
	<i class="bi bi-tag"></i>
	Work
</span>
```

---

## 📈 Progress Bar

```html
<div class="progress-bar-container">
	<div class="progress-bar" style="width: 66.67%;"></div>
</div>

<!-- With Label -->
<div class="progress-label">
	<span>Tasks Completed</span>
	<span>20/28</span>
</div>
<div class="progress-bar-container">
	<div class="progress-bar" style="width: 71.43%;"></div>
</div>
```

---

## 📱 Responsive Grid Layouts

```html
<!-- Auto-responsive 1 column -->
<div class="content-grid-1col">
	<div class="card">...</div>
</div>

<!-- 2 column (responsive to 1 on mobile) -->
<div class="content-grid-2col">
	<div class="card">...</div>
	<div class="card">...</div>
</div>

<!-- 3 column grid -->
<div class="content-grid-3col">
	<div class="card">...</div>
</div>

<!-- 4 column grid -->
<div class="content-grid-4col">
	<div class="card">...</div>
</div>
```

---

## 🌓 Dark Mode

```javascript
// Toggle theme
window.toggleTheme();

// Current theme
document.documentElement.getAttribute('data-theme')
// Returns: 'light' or 'dark'

// Programmatic change
document.documentElement.setAttribute('data-theme', 'dark');
```

---

## 📱 Mobile Utilities

```html
<!-- Only show on mobile -->
<div class="d-sm-block d-lg-none">Mobile content</div>

<!-- Only show on desktop -->
<div class="d-lg-block d-sm-none">Desktop content</div>

<!-- Flex utilities -->
<div class="d-flex align-items-center justify-content-between gap-2">
	<span>Item 1</span>
	<span>Item 2</span>
</div>
```

---

## 🎭 Modal Dialog

```html
<div class="modal-overlay active">
	<div class="modal-dialog">
		<div class="modal-header">
			<h2 class="modal-title">Confirm Action</h2>
			<button class="modal-close-btn"><i class="bi bi-x"></i></button>
		</div>
		<div class="modal-body">
			Are you sure?
		</div>
		<div class="modal-footer">
			<button class="btn btn-ghost">Cancel</button>
			<button class="btn btn-primary">Confirm</button>
		</div>
	</div>
</div>
```

---

## 🍞 Toast Notifications

```html
<div class="toast-container">
	<!-- Success -->
	<div class="toast success">
		<i class="bi bi-check-circle-fill"></i>
		<div class="toast-content">
			<div class="toast-message">Successfully saved!</div>
		</div>
		<button class="toast-close">&times;</button>
	</div>

	<!-- Error -->
	<div class="toast error">
		<i class="bi bi-exclamation-circle-fill"></i>
		<div class="toast-content">
			<span class="toast-message">Error occurred!</span>
		</div>
	</div>
</div>
```

---

## 🎬 Animations

```html
<!-- Fade In -->
<div class="animate-fadeIn">Fades in on load</div>

<!-- Slide Up -->
<div class="animate-slideInUp">Slides up from bottom</div>

<!-- Slide Left -->
<div class="animate-slideInLeft">Slides in from left</div>

<!-- Pulse/Loading -->
<div class="animate-pulse">Pulses (loading effect)</div>
```

---

## 🎯 Common Patterns

### Page Layout
```html
<div class="container">
	<div class="page-header">
		<div class="page-title"><h1>Page Title</h1></div>
		<div class="page-actions">
			<a href="#" class="btn btn-primary">Action</a>
		</div>
	</div>

	<!-- Content -->
</div>
```

### Section with Header
```html
<div class="section-card">
	<div class="section-card-header">
		<div class="section-card-title">Section Title</div>
		<a href="#" class="view-all-link">View All →</a>
	</div>
	<!-- Content -->
</div>
```

### Empty State
```html
<div class="empty-state">
	<div class="empty-state-icon">
		<i class="bi bi-inbox"></i>
	</div>
	<div class="empty-state-title">No Tasks</div>
	<p class="empty-state-description">Start by creating your first task</p>
	<a href="#" class="btn btn-primary">Create Task</a>
</div>
```

### Action Buttons
```html
<div class="actions-row">
	<a href="#" class="btn btn-ghost">Cancel</a>
	<a href="#" class="btn btn-primary">Save</a>
</div>
```

---

## 🔗 Icon Libraries

**Bootstrap Icons** (included):
```html
<i class="bi bi-check"></i>
<i class="bi bi-lightning"></i>
<i class="bi bi-calendar"></i>
```

Browse: https://icons.getbootstrap.com/

---

## 💾 File Locations

| File | Purpose |
|------|---------|
| `css/variables.css` | CSS custom properties |
| `css/components.css` | Base components |
| `css/layout.css` | Layout & responsive |
| `css/premium-components.css` | Advanced components |
| `js/theme.js` | Dark/Light mode |
| `js/layout.js` | Mobile nav, sidebar |
| `Views/Shared/_Layout.cshtml` | Main layout |

---

## 🎓 Best Practices

1. **Always use CSS variables** - Never hardcode colors or spacing
2. **Follow the grid system** - Use `content-grid-Xcol` for layouts
3. **Use semantic buttons** - `btn-primary` for main actions, `btn-ghost` for secondary
4. **Consistent spacing** - `var(--spacing-lg)` for padding, not arbitrary values
5. **Responsive first** - Mobile design works, desktop enhances
6. **Test both themes** - Verify dark mode works for new components
7. **Reuse components** - Don't create duplicate styles
8. **Keep it simple** - Use existing components before creating new ones

---

## 🐛 Common Issues & Fixes

| Problem | Solution |
|---------|----------|
| Dark mode not applying | Check `data-theme` attribute on `<body>` |
| Layout broken on mobile | Verify responsive classes (`.d-sm-*`, `.d-lg-*`) |
| Colors look wrong | Use `var(--color-*)`instead of hardcoded values |
| Icons not showing | Check Bootstrap Icons CDN link & icon class name |
| Spacing inconsistent | Use spacing variables (`--spacing-*`) |
| Buttons misaligned | Use `.d-flex` & `.align-items-center` |

---

**Version:** 1.0  
**Last Updated:** January 2026  
**Target Framework:** .NET 10  

For detailed information, see **DESIGN_SYSTEM.md**
