# 🎨 TaskFlow - Visual Design Guide

## Color Palette

### Primary Colors
```
Indigo     Blue       Purple
#6366f1    #3b82f6    #8b5cf6
●●●●●●●●● ●●●●●●●●● ●●●●●●●●●
```

### Semantic Colors
```
Success    Warning    Danger     Info
#10b981    #f59e0b    #ef4444    #06b6d4
●●●●●●●●● ●●●●●●●●● ●●●●●●●●● ●●●●●●●●●
```

### Neutral Palette
```
Gray-50    Gray-100   Gray-200   Gray-300   Gray-400   Gray-500
#f9fafb    #f3f4f6    #e5e7eb    #d1d5db    #9ca3af    #6b7280
●●●●●●●●● ●●●●●●●●● ●●●●●●●●● ●●●●●●●●● ●●●●●●●●● ●●●●●●●●●

Gray-600   Gray-700   Gray-800   Gray-900
#4b5563    #374151    #1f2937    #111827
●●●●●●●●● ●●●●●●●●● ●●●●●●●●● ●●●●●●●●●
```

---

## Typography Scale

```
Font: -apple-system, BlinkMacSystemFont, 'Segoe UI', 'Roboto'

Display    | 48px | Font Weight: Bold
H1         | 36px | Font Weight: Bold
H2         | 30px | Font Weight: Bold
H3         | 24px | Font Weight: Bold
H4         | 20px | Font Weight: Bold
H5         | 18px | Font Weight: Bold
H6         | 16px | Font Weight: Bold (Uppercase)

Body       | 16px | Font Weight: Normal
Small      | 14px | Font Weight: Normal
X-Small    | 12px | Font Weight: Normal
```

---

## Spacing Scale

```
4px    xs  [████]
8px    sm  [████████]
16px   md  [████████████████]
24px   lg  [████████████████████████]
32px   xl  [████████████████████████████████]
48px   2xl [████████████████████████████████████████████████]
64px   3xl [████████████████████████████████████████████████████████████████]
```

---

## Border Radius Guide

```
6px   sm   [Subtle curves - inputs, small buttons]
12px  md   [Standard - cards, most components]
16px  lg   [Prominent - larger cards, popovers]
24px  xl   [Large cards, sections]
32px  2xl  [Extra emphasis - featured items]
9999px full [Circles, fully rounded buttons]
```

---

## Shadow Depth

```
xs  [Minimal depth for subtle floating effects]
sm  [Card shadows, small hover effects]
md  [Elevated cards, stronger hover]
lg  [Popovers, large components]
xl  [Modals, important overlays]
2xl [Deep drop shadows, maximum emphasis]
```

---

## Component Examples

### Button Variants

```
┌─────────────┐  ┌─────────────┐  ┌─────────────┐
│   Primary   │  │  Secondary  │  │   Outline   │
│ (Indigo BG) │  │  (Blue BG)   │  │  (No fill)  │
└─────────────┘  └─────────────┘  └─────────────┘

┌─────────────┐  ┌─────────────┐  ┌─────────────┐
│   Success   │  │   Danger    │  │    Ghost    │
│ (Green BG)  │  │  (Red BG)    │  │  (Bg only)  │
└─────────────┘  └─────────────┘  └─────────────┘
```

### Button States

```
Normal     Hover      Active     Disabled
────────   ────────   ────────   ────────
   ┃         ┃▲        ┃▼        ┃  ✗
  ┗━┛      ┏━━┓      ┗━━┛      ┗━━┛
		   Shadow    Press     Faded
```

### Card Variations

```
Basic Card          Elevated Card       Glassmorphism Card
┌──────────────┐   ┌──────────────┐   ┌─  ─ ──────────────┐
│              │   │     ∑∑∑      │   │ ▨ (frozen glass) │
│   Content    │   │  ∑∑∑  ∑∑∑    │   │ ▨   effect      │
│              │   │ ∑∑∑ Content  │   │ ▨                │
└──────────────┘   │  ∑∑∑  ∑∑∑    │   └─  ─ ──────────────┘
				   └──────────────┘
```

### Task Card Anatomy

```
┌─ Task Card ──────────────────────────────────────────┐
│                                                      │
│ ☑ Design new dashboard interface                   │
│ └─ Create mockups and wireframes for the update... │
│                                                      │
│ tomorrow  |  HIGH  |  Work                       ✎ ⭐
│                                                      │
└──────────────────────────────────────────────────────┘
 ↑          ↑                                         ↑
 Checkbox   Meta-information         Action buttons
			(date, priority, tag)     (Edit, Delete)
```

---

## Responsive Layouts

### 4 Column Grid (Desktop)

```
┌────┬────┬────┬────┐
│ 🎯 │ 📊 │ ⭐ │ 🔥 │  Desktop (>1024px)
├────┼────┼────┼────┤
│         Card         │
└─────────────────────┘
```

### 2 Column Grid (Tablet)

```
┌──────┬──────┐
│  🎯  │  📊  │  Tablet (768-1024px)
├──────┼──────┤
│  ⭐  │  🔥  │
├────────────┤
│   Card     │
└────────────┘
```

### 1 Column Grid (Mobile)

```
┌────────────┐
│    🎯     │  Mobile (<768px)
├────────────┤
│    📊     │
├────────────┤
│   Card     │
└────────────┘
```

---

## Navigation Structures

### Desktop Navigation

```
┌────────────────────────────────────────────┐
│ Logo  Search  🌙  🔔  👤  User Name  ▼    │  Navbar (64px)
├──────────────────────────────────────────────
│ Dashboard │                                  │
│ Today     │     MAIN CONTENT                │
│ Calendar  │                                  │
│           │                                  │
│ My Tasks  │     [Task Cards]                │
│ Inbox    │     [Task Cards]                │
│ Completed │     [Dashboard Widgets]        │
│           │                                  │
│ Settings  │                                  │
└───────────────────────────────────────────────
```

### Mobile Navigation

```
┌──────────────────────┐
│ ☰  Logo  🌙  🔔  👤 │  Navbar (64px)
├──────────────────────┤
│                      │
│  MAIN CONTENT        │
│  (full width)        │
│                      │
│                      │
│                      │
├──────────────────────┤
│ 🏠 | 📅 | ⚡ | ⚙️   │  Bottom Nav (80px)
└──────────────────────┘
	  ╭─────╮
	  │  ➕ │  FAB
	  ╰─────╯
```

---

## Animation Examples

### Entrance Animations
```
Fade In          Slide Up         Slide Left
─────────        ────────         ────────
░░░░░░░          △△△△△△△          ◄◄◄◄◄◄◄
░░░░░░░  ─→      ▲▲▲▲▲▲▲  ─→      ◄◄◄◄◄◄◄  ─→
░░░░░░░          ─────        ────────
```

### Interaction Animations
```
Button Hover       Card Hover      Scroll Animation
────────────       ──────────      ─────────────
[Button]      →    [Card] ┃    →   [Content]
			 ▲           └─ dx         ↓ ▼
		   scale        elevation   parallax
		   blur         rotate      fade
```

---

## Dark Mode Transformation

### Light Mode
```
Background:  #fafbfc  →  #0f1419
Text:        #111827  →  #f0f4f8
Border:      #e5e7eb  →  #2d3652
Card:        #ffffff  →  #1a1f2e

Card remains readable, all text accessible,
contrast maintained at 4.5:1+ ratio
```

### Visual Comparison
```
Light Theme              Dark Theme
────────────────────    ────────────────────
White Cards             Dark Gray Cards
Dark Text               Light Text
Light Background        Dark Background
Subtle Shadows          Visible Shadows
```

---

## Priority Indicators

```
High Priority       Medium Priority     Low Priority
───────────────     ───────────────     ───────────
RED Badge           AMBER Badge         GREEN Badge
████████████        ▓▓▓▓▓▓▓▓▓▓▓▓        ▒▒▒▒▒▒▒▒▒▒▒▒
Urgent Task         Standard Task       Flexible Task
```

---

## Status Indicators

```
Completed Task          Pending Task           Overdue Task
──────────────────      ───────────────        ───────────
✓ Strikethrough Text    ⏳ Normal Text          ⚠️ Highlighted
Gray Text              Normal Color           Red/Bold
Reduced Opacity        Regular Opacity        High Contrast
0.6 Opacity            1.0 Opacity           1.0 Opacity
```

---

## Form Styling

### Input States

```
Default          Focused         Error           Disabled
───────          ───────         ────────        ────────
[Input Box]      [Input Box]     [Input Box]     [Input Box]
Plain Border     Blue Border     Red Border      Gray Border
Gray Text        Dark Text       Red Text        Gray Text
				 Blue Shadow     Red Shadow      No Shadow
```

### Form Layout

```
┌─ Form Group ─────────────────────────────┐
│                                           │
│ Label Text                                │
│ [Input field with placeholder...]        │
│ Helper text or error message (optional)  │
│                                           │
└─────────────────────────────────────────┘
```

---

## Progress & Metrics

### Progress Bar States

```
0%       25%      50%      75%      100%
───      ──▌      ──┤      ──────   ──────
Empty    Loading  Mid      Almost   Complete
░░░░     ███░░░░  ██████░░  ██████▓▓  ██████
```

### Stat Card Layouts

```
Regular Card            Gradient Card
──────────────────      ──────────────────
[Icon] 12 Tasks         [Icon] 28 Tasks
Metric Label            Metric Label
┌──────────────────┐    ╔══════════════════╗
│ Current value    │    ║ Featured Value   ║
│ with context     │    ║ with gradient BG ║
└──────────────────┘    ╚══════════════════╝
```

---

## Empty States

```
┌─ Empty State ─────────────────────┐
│                                   │
│           📭 (Icon)                │
│                                   │
│      No Tasks Yet                 │
│    Create your first task         │
│                                   │
│      [➕ Create Now]              │
│                                   │
└───────────────────────────────────┘
```

---

## Modal Anatomy

```
╔═══════════════════════════════════╗
║ Modal Title                     ✕ ║  Header
╠═══════════════════════════════════╣
║                                   ║
║       Modal Content Here          ║  Body
║                                   ║
╠═══════════════════════════════════╣
║  [Cancel Button]  [Confirm Button]║  Footer
╚═══════════════════════════════════╝
```

---

## Calendar Component

```
		January 2026
	◀ Su Mo Tu We Th Fr Sa ▶
	   29 30  1  2  3  4  5
		6  7  8  9 10 11 12
	   13 14 15 16 17 18 19
	   20 21 22 23 24 25 26
	   27 28 29 30 31

Legend:
[29] = Other month (grayed)
[ 1] = Regular day
[10] = Today (blue highlight)
[25] = Selected (light blue)
[15] = Event day (underlined)
```

---

## Z-Index Hierarchy

```
Level 80  ┌─ Notifications (toast, alerts) ──┐
Level 70  ├─ Tooltips ───────────────────────┤
Level 60  ├─ Popovers ───────────────────────┤
Level 50  ├─ Modals ─────────────────────────┤
Level 40  ├─ Modal Backdrop (overlay) ──────┤
Level 30  ├─ Fixed elements (navbar, sidebar)┤
Level 20  ├─ Sticky elements ────────────────┤
Level 10  ├─ Dropdowns, fixed dropdowns ────┤
Level 0   └─ Default content ───────────────┘
```

---

## Spacing Relationships

```
Component Spacing Guide:
┌─────────────────────────────────────┐
│ ▲ spacing-2xl (48px)                │
│ ☐ Section Title                     │
│ ▼ spacing-lg (24px)                 │
│                                     │
│ ┌─ spacing-lg (24px) ──────────────┐│
│ │ ▲ spacing-md (16px)              ││
│ │ Card                             ││
│ │ ▼ spacing-md (16px)              ││
│ └───────────────────────────────────┘
│                                     │
│ ▲ spacing-lg (24px)                 │
│                                     │
│ ┌─ Another Card ────────────────────┐│
│ │                                   ││
│ └───────────────────────────────────┘
└─────────────────────────────────────┘
```

---

## Consistency Checklist

When creating new components, verify:

```
☐ Colors use CSS variables (var(--color-*))
☐ Spacing uses scale (var(--spacing-*))
☐ Font sizes from typography scale
☐ Border radius from radius scale
☐ Shadows from shadow system
☐ Transitions use timing function
☐ Mobile version designed
☐ Dark mode tested
☐ Hover states included
☐ Focus states visible (accessibility)
☐ Disabled state styled
☐ Loading state shown
☐ Error state handled
```

---

## Design Principles

### 1. **Hierarchy**
- Size, color, and position guide attention
- Most important content is most prominent

### 2. **Consistency**
- Repeated patterns create familiarity
- Same actions look the same everywhere

### 3. **Contrast**
- Text vs background ratio ≥ 4.5:1
- Interactive elements stand out

### 4. **Spacing**
- Breathing room between elements
- Grouped elements closer than unrelated

### 5. **Feedback**
- Every action has visual response
- Transitions smooth and deliberate

### 6. **Simplicity**
- Remove unnecessary elements
- Progressive disclosure for complex

### 7. **Accessibility**
- Accessible to all users
- Not just color-dependent
- Keyboard navigation works

---

## Quick Reference Colors

```
Use For        Color              Hex
───────────────────────────────────────────
Primary CTA    Indigo             #6366f1
Secondary CTA  Blue               #3b82f6
Success/Check  Green              #10b981
Warning/Alert  Amber              #f59e0b
Error/Delete   Red                #ef4444
Info           Cyan               #06b6d4
Text Primary   Dark Gray          #111827
Text Secondary Medium Gray        #6b7280
Text Tertiary  Light Gray         #9ca3af
Background     Near White         #fafbfc
Surface        White              #ffffff
Border         Light Gray         #e5e7eb
```

---

**This visual guide complements the CSS Design System**

For detailed implementation, see:
- DESIGN_SYSTEM.md
- QUICK_REFERENCE.md
- CSS files in wwwroot/css/

All colors, spacing, and components are fully documented! 🎨
