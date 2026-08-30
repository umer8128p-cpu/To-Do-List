# 🎯 Page Redesign Checklist & Roadmap

This document guides the redesign of all remaining pages using the TaskFlow design system.

---

## ✅ Completed Pages

- ✅ **Dashboard** (Primary hub - fully redesigned)
- ✅ **Layout System** (Navigation, sidebar, mobile nav)
- ✅ **Design System** (CSS variables, components, colors)

---

## 📋 Remaining Pages to Redesign

### Phase 1: Authentication (High Priority)

These are user-facing entry points and critical first impressions.

#### [ ] Login Page
**Current File:** `Views/Home/login.cshtml`

**Components to Use:**
- `.card` for login form container
- `.form-group` + `.form-control` for inputs
- `.btn btn-primary` for login button
- `.btn btn-ghost` or `.btn btn-outline` for alternate actions
- `.alert` for error messages
- Gradient background or illustration

**Required Elements:**
```html
<div class="card login-card">
	<div class="section-card-header">
		<h1>Welcome Back</h1>
		<p>Sign in to your TaskFlow account</p>
	</div>

	<form class="login-form">
		<div class="form-group">
			<label class="form-label">Email Address</label>
			<input type="email" class="form-control" />
		</div>

		<div class="form-group">
			<label class="form-label">Password</label>
			<input type="password" class="form-control" />
		</div>

		<div class="form-group d-flex justify-content-between">
			<div class="checkbox">
				<input type="checkbox" id="remember" />
				<label for="remember">Remember me</label>
			</div>
			<a href="/forgot-password" class="text-primary">Forgot password?</a>
		</div>

		<button type="submit" class="btn btn-primary" style="width: 100%;">
			Sign In
		</button>

		<div class="text-center mt-3">
			<p class="text-muted">
				Don't have an account? 
				<a href="/register" class="text-primary">Create one</a>
			</p>
		</div>
	</form>
</div>
```

**Styling File:** Create `css/auth.css`

**Checklist:**
- [ ] Replace old Bootstrap styles
- [ ] Add form validation styling
- [ ] Add "forgot password" link
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Add smooth transitions
- [ ] Test error messages display

---

#### [ ] Register Page  
**Current File:** `Views/Home/register.cshtml`

**Components to Use:**
- `.card` for registration form
- `.form-group` for each field (email, name, password, confirm password)
- `.alert alert-info` for requirements note
- `.btn btn-primary` for submit
- Progress indicator (optional)

**Key Features:**
- Multi-step form (optional)
- Password strength indicator
- Email verification notice  
- Terms & conditions checkbox

**Checklist:**
- [ ] Replace old Bootstrap styles
- [ ] Add password validation feedback
- [ ] Add email format validation visual
- [ ] Test form submission
- [ ] Test mobile responsiveness
- [ ] Test dark mode
- [ ] Add smooth transitions

---

#### [ ] Forgot Password Page
**Current File:** `Views/Home/forgot-password.cshtml` (might need to create)

**Components to Use:**
- `.card` for form
- `.form-control` for email input
- `.btn btn-primary` for submit  
- `.alert alert-success` for success message
- `.alert alert-danger` for error message

**Flow:**
1. Enter email → Show success message
2. Show link to go back to login
3. Display resend option

**Checklist:**
- [ ] Create page if doesn't exist
- [ ] Add success/error message handling
- [ ] Test email input validation
- [ ] Test mobile responsiveness
- [ ] Test dark mode

---

### Phase 2: Task Management (High Priority)

Core functionality pages where users spend most time.

#### [ ] New Task / Create Task Page
**Current File:** `Views/Home/NewTask.cshtml`

**Components to Use:**
- `.section-card` for form container
- `.form-group` for each input
- `.form-select` for category dropdown
- `.task-priority` badges for priority selection
- `.btn btn-primary` for create
- `.btn btn-ghost` for cancel
- `.actions-row` for buttons

**Form Fields:**
```html
<div class="section-card">
	<div class="section-card-header">
		<h2>Create New Task</h2>
	</div>

	<form>
		<!-- Task Title -->
		<div class="form-group">
			<label class="form-label">Task Title</label>
			<input type="text" class="form-control" placeholder="What needs to be done?" />
		</div>

		<!-- Description -->
		<div class="form-group">
			<label class="form-label">Description</label>
			<textarea class="form-control" rows="4" placeholder="Add details..."></textarea>
		</div>

		<!-- Category -->
		<div class="form-group">
			<label class="form-label">Category</label>
			<select class="form-select">
				<option>Work</option>
				<option>Personal</option>
				<option>Shopping</option>
			</select>
		</div>

		<!-- Priority -->
		<div class="form-group">
			<label class="form-label">Priority</label>
			<div class="d-flex gap-2">
				<span class="task-priority low" role="button">Low</span>
				<span class="task-priority medium" role="button">Medium</span>
				<span class="task-priority high" role="button">High</span>
			</div>
		</div>

		<!-- Due Date -->
		<div class="form-group">
			<label class="form-label">Due Date</label>
			<input type="date" class="form-control" />
		</div>

		<!-- Action Buttons -->
		<div class="actions-row">
			<button class="btn btn-ghost">Cancel</button>
			<button class="btn btn-primary">Create Task</button>
		</div>
	</form>
</div>
```

**Checklist:**
- [ ] Update form styling
- [ ] Add date picker styling
- [ ] Add priority selector with radio buttons
- [ ] Test category dropdown
- [ ] Test form validation
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Add success notification on create

---

#### [ ] Edit Task Page
**Current File:** `Views/Home/editTask.cshtml`

**Similar to New Task but with:**
- Pre-filled form values
- Delete button in footer
- Change detection (warn on unsaved changes)
- History/changelog section (optional)

**Checklist:**
- [ ] Update styling to match NewTask
- [ ] Add delete confirmation modal
- [ ] Test form population
- [ ] Test unsaved changes warning
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Add success notification on save

---

#### [ ] Task Details / View Task
**Current File:** `Views/Home/Main.cshtml` (dashboard might show details)

**Components to Use:**
- `.card` for main container
- `.task-meta-item` for metadata (date, category, priority)
- `.progress-bar` for task completion
- `.actions-row` for edit/delete buttons
- `.alert` for status messages
- `.card-elevated` for subtasks section (if applicable)

**Checklist:**
- [ ] Create dedicated details page
- [ ] Display task metadata clearly
- [ ] Add edit/delete/complete actions
- [ ] Show related tasks (if applicable)
- [ ] Test all metadata displays
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

### Phase 3: Task Views (High Priority)

"All Tasks", "Today", "This Week", etc. - viewing and filtering

#### [ ] All Tasks Page
**Current File:** `Views/Home/Index.cshtml` or similar

**Components to Use:**
- `.task-list` with `.task-card` items
- `.empty-state` for no tasks
- Filter/sort buttons
- Search functionality
- Pagination

**Required Sections:**
```html
<div class="container">
	<!-- Page Header -->
	<div class="page-header">
		<div class="page-title">
			<h1><i class="bi bi-check2-square"></i> My Tasks</h1>
		</div>
		<div class="page-actions">
			<a href="/task/create" class="btn btn-primary">
				<i class="bi bi-plus-lg"></i> New Task
			</a>
		</div>
	</div>

	<!-- Filter Bar -->
	<div class="section-card" style="margin-bottom: var(--spacing-lg);">
		<div class="d-flex gap-2 flex-wrap">
			<select class="form-select" style="max-width: 150px;">
				<option>All Categories</option>
			</select>
			<select class="form-select" style="max-width: 150px;">
				<option>All Priorities</option>
			</select>
			<select class="form-select" style="max-width: 150px;">
				<option>Sort by...</option>
			</select>
		</div>
	</div>

	<!-- Task List -->
	<ul class="task-list">
		<!-- Task cards go here -->
	</ul>

	<!-- Empty State -->
	<div class="empty-state">
		<div class="empty-state-icon"><i class="bi bi-inbox"></i></div>
		<div class="empty-state-title">No tasks yet</div>
		<a href="/task/create" class="btn btn-primary">Create your first task</a>
	</div>
</div>
```

**Checklist:**
- [ ] Update task card styling
- [ ] Add filter functionality styling
- [ ] Add sort functionality
- [ ] Test empty state
- [ ] Add pagination if needed
- [ ] Add search/filter bar
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Add bulk actions (select multiple)

---

#### [ ] Today's Tasks
**Current File:** `Views/Home/todayTasks.cshtml`

**Components to Use:**
- Same as All Tasks but filtered
- Progress stats at top
- `.stat-card` showing today's progress
- Time-based grouping (Morning, Afternoon, Evening)

**Checklist:**
- [ ] Create statistics header
- [ ] Group tasks by time (optional)
- [ ] Highlight overdue tasks
- [ ] Test filter logic
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

#### [ ] Future Tasks
**Current File:** `Views/Home/futureTasks.cshtml`

**Components to Use:**
- Calendar view + list view
- `.calendar` component
- Grouped by date
- `.task-card` items

**Checklist:**
- [ ] Add calendar widget
- [ ] Display tasks by date
- [ ] Test date grouping
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

#### [ ] Completed Tasks
**Current File:** `Views/Home/completedTasks.cshtml`

**Components to Use:**
- `.task-card` with `.completed` state
- Statistics showing completion rate
- Filter by date range
- Optional: completion rate chart

**Checklist:**
- [ ] Add strikethrough styling for completed
- [ ] Show completion date/time
- [ ] Add filter by date
- [ ] Add undo complete option (if applicable)
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

#### [ ] Overdue / Pending Tasks
**Current File:** `Views/Home/pendingTasks.cshtml`

**Components to Use:**
- Highlight overdue tasks
- `.alert alert-danger` or border styling
- `.task-priority high` emphasis
- Quick action buttons (Complete, Reschedule, Delete)

**Checklist:**
- [ ] Add urgent styling
- [ ] Show days overdue
- [ ] Add quick actions
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

### Phase 4: Calendar & Analytics (Medium Priority)

Data visualization and planning views

#### [ ] Calendar View
**Current File:** Likely needs creation

**Components to Use:**
- `.calendar` component
- `.task-card` for day details
- `.stat-card` for daily stats
- Color coding by priority/category

**Checklist:**
- [ ] Implement full calendar
- [ ] Show task counts per day
- [ ] Show tasks on day click
- [ ] Add navigation (prev/next month)
- [ ] Add filter buttons
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Test different month sizes

---

#### [ ] Analytics / Reports
**Current File:** Likely needs creation

**Components to Use:**
- `.stat-card.gradient` for KPIs
- Charts/graphs (Chart.js integration)
- `.progress-bar` for metrics
- Date range selector

**Metrics to Display:**
- Total tasks created
- Completion rate
- Average completion time
- Tasks by category
- Tasks by priority
- This week vs last week

**Checklist:**
- [ ] Add dashboard cards
- [ ] Integrate chart library
- [ ] Create graphs/charts
- [ ] Add date range filter
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Test data loading
- [ ] Add error handling

---

### Phase 5: Team Features (Medium Priority)

Collaborative features for multi-user management

#### [ ] My Teams Page
**Current File:** Needs creation from Teams controller

**Components to Use:**
- Team cards (`.card`)
- Member list with avatars
- `.badge` for role/status
- Quick action buttons

**Checklist:**
- [ ] Create team cards
- [ ] Display member list
- [ ] Add leave team button
- [ ] Add team settings link
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

#### [ ] Create/Edit Team
**Current File:** `Views/Teams/newTeam.cshtml`

**Components to Use:**
- `.section-card` for form
- `.form-group` for inputs
- `.button` for create
- Member invite form

**Checklist:**
- [ ] Update form styling
- [ ] Add member invite interface
- [ ] Test member addition
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

#### [ ] Team Tasks
**Current File:** Needs creation

**Components to Use:**
- Combined view of team tasks
- Assignee/filter options
- `.task-card` with assignee avatar
- `.section-card` per team

**Checklist:**
- [ ] Display team tasks
- [ ] Add assignee filter
- [ ] Show team member avatars
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

### Phase 6: Settings & Profile (Low Priority)

User account and preference management

#### [ ] Profile Page
**Current File:** Needs creation

**Components to Use:**
- Avatar editor section
- `.form-group` for editable fields
- `.section-card` for grouped settings
- `.btn btn-primary` for save
- `.alert alert-success` for confirmation

**Settings to Include:**
- Basic info (name, email, avatar)
- Notification preferences
- Password change
- Two-factor authentication
- Account deletion

**Checklist:**
- [ ] Create profile form
- [ ] Add avatar upload
- [ ] Add password change
- [ ] Add settings sections
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Add save feedback

---

#### [ ] Settings Page
**Current File:** Needs creation

**Components to Use:**
- `.section-card` per setting group
- Toggle switches for features
- `.form-select` for preferences
- `.actions-row` for save/reset

**Settings Sections:**
- **General:** Language, timezone, theme
- **Notifications:** Email alerts, push, reminders
- **Privacy:** Public profile, sharing settings
- **Advanced:** API keys, integrations

**Checklist:**
- [ ] Create settings page
- [ ] Add toggle switches
- [ ] Add dropdown selectors
- [ ] Test theme toggle
- [ ] Test mobile responsiveness
- [ ] Add unsaved changes warning

---

#### [ ] Notifications Page
**Current File:** Needs creation

**Components to Use:**
- `.toast` + `.notification` styles combined
- `.empty-state` for no notifications
- Filter/search
- Mark as read functionality

**Checklist:**
- [ ] Display notifications list
- [ ] Add mark as read
- [ ] Add delete/clear
- [ ] Add filter by type
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

### Phase 7: Additional Pages (Low Priority)

Supporting pages and information

#### [ ] Categories Page
**Current File:** `Views/Home/category.cshtml`

**Components to Use:**
- Grid of category cards
- `.quick-link-card` style with color coding
- Task count badges
- Edit/delete actions

**Checklist:**
- [ ] Create category cards
- [ ] Add color indicators
- [ ] Add task count
- [ ] Add edit/delete buttons
- [ ] Test dark mode
- [ ] Test mobile responsiveness
- [ ] Add create new category action

---

#### [ ] Privacy / Legal Page
**Current File:** `Views/Home/Privacy.cshtml`

**Components to Use:**
- `.section-card` for content sections
- Headers for organization
- Links for navigation
- No complex components needed

**Checklist:**
- [ ] Update typography sizing
- [ ] Ensure readability
- [ ] Add table of contents
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

#### [ ] About Page
**Current File:** Needs creation

**Components to Use:**
- Hero section with gradient
- Feature cards
- Team showcase
- FAQ accordion (requires component)
- CTA buttons

**Checklist:**
- [ ] Create hero section
- [ ] Add feature cards
- [ ] Add team section
- [ ] Add FAQ section
- [ ] Test dark mode
- [ ] Test mobile responsiveness

---

#### [ ] 404 Error Page
**Current File:** `Views/Shared/Error.cshtml`

**Components to Use:**
- `.empty-state` styling for error
- `.btn btn-primary` for back button
- Large icon/illustration
- Helpful message

**Checklist:**
- [ ] Create error page
- [ ] Add back home button
- [ ] Add helpful message
- [ ] Test dark mode
- [ ] Test all screen sizes

---

## 📊 Implementation Tracking

### Completion Status Template

For each page, track:

```markdown
## Page Name
- Status: [ ] Not Started / [ ] In Progress / [ ] Complete
- Date Started: ___
- Date Completed: ___
- Issues/Notes: ___
- Dark Mode: [ ] Tested
- Mobile: [ ] Tested

Components Used:
- [ ] Component 1
- [ ] Component 2

Testing:
- [ ] Light mode
- [ ] Dark mode
- [ ] Mobile (<768px)
- [ ] Tablet (768-1024px)
- [ ] Desktop (>1024px)
- [ ] All browsers
- [ ] Form validation
- [ ] Error states
```

---

## 🚀 Recommendations

### Quick Wins (Start Here)
1. Login / Register pages - foundational pages, high impact
2. All Tasks - core functionality
3. Settings - enables personalization

### Most Used (Then Do These)
4. Today's Tasks
5. New/Edit Task
6. Dashboard enhancements

### Enhancement (Then Polish)
7. Calendar  view
8. Analytics
9. Team features

### Final Polish
10. Settings preferences
11. Profile page
12. Info pages (About, Privacy)

---

## ⚠️ Common Mistakes to Avoid

1. **Don't hardcode colors** - Use CSS variables
2. **Don't ignore dark mode** - Test every new page
3. **Don't forget mobile** - Test on actual devices or emulator
4. **Don't repeat code** - Use component classes
5. **Don't break existing functionality** - Keep backend logic intact
6. **Don't add new dependencies** - Use existing libraries (Bootstrap Icons)
7. **Don't ignore accessibility** - Use semantic HTML and ARIA labels
8. **Don't skip testing** - Test before considering complete

---

## ✅ Quality Checklist Template

Use this for every page:

```
Page: _________________
Date: _________________

Visual:
- [ ] Consistent with brand colors
- [ ] Proper spacing and alignment
- [ ] Icons display correctly
- [ ] Fonts render properly
- [ ] Images/illustrations optimized

Functionality:
- [ ] All buttons work
- [ ] Forms validate
- [ ] Navigation works
- [ ] Dropdowns function
- [ ] Search/filters work

Responsive:
- [ ] Mobile layout works
- [ ] Tablet layout works
- [ ] Desktop layout works
- [ ] No horizontal scroll
- [ ] Touch targets sized properly

Dark Mode:
- [ ] All colors visible
- [ ] Text readable
- [ ] Contrast acceptable
- [ ] No color issues

Performance:
- [ ] Page loads quickly
- [ ] Animations smooth
- [ ] No console errors
- [ ] Images optimized

Accessibility:
- [ ] Keyboard navigation works
- [ ] Screen reader compatible
- [ ] Focus states visible
- [ ] Color not only indicator

Approved By: ___________
Date: _________________
```

---

## 📞 Questions / Support

Refer to:
- `DESIGN_SYSTEM.md` - Full documentation
- `QUICK_REFERENCE.md` - Common patterns
- CSS files - Component definitions
- Bootstrap Icons: https://icons.getbootstrap.com/

---

**Last Updated:** January 2026  
**Version:** 1.0  
**Status:** Ready for Implementation  

Start with Phase 1 (Authentication) for best results!
