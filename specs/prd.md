# 📝 Product Requirements Document (PRD)

**Product Name:** wanna
**Version:** 1.0
**Last Updated:** 2025-01-15
**Status:** Draft

---

## 1. Purpose

People constantly think of things they "wanna" do, places they "wanna" go, and things they "wanna" have — but these wishes are scattered across notes apps, bookmarks, screenshots, and fleeting conversations. There is no single, social-first place to capture life goals and wishlist items, share them with friends, and actually make them happen together.

**wanna** is a social wishlist and bucket-list application that gives users a fun, lightweight way to capture their wants, organize them into meaningful lists, share them with friends, and collaborate on fulfilling them together. It bridges the gap between "I want to do that someday" and actually doing it — by making wishes visible, social, and actionable.

**Who it's for:**

- **Primary Persona — The Social Dreamer (ages 18–35):** Socially active individuals who love sharing experiences, planning activities with friends, and keeping track of life goals. They use social media daily and are comfortable with mobile-first apps.
- **Secondary Persona — The Thoughtful Gift-Giver (ages 25–50):** People who want to give meaningful gifts to friends and family and value knowing exactly what someone actually wants, rather than guessing.
- **Tertiary Persona — The Goal Tracker (ages 20–45):** Individuals who use lists and planning tools to organize life goals (travel, career, personal growth) and want a more engaging, visual, and social way to track progress.

---

## 2. Scope

### In Scope (v1.0)

- User registration, authentication, and profile management
- Creating, editing, and deleting personal "wanna" items (wishes/goals)
- Organizing wanna items into themed lists (e.g., "Travel Bucket List", "Birthday Wishlist", "Books to Read")
- Categorizing wanna items by type: **wanna do**, **wanna have**, **wanna go**, **wanna try**, **wanna learn**
- Adding rich details to wanna items: title, description, image/photo, link/URL, priority level, and target date
- Sharing lists with friends via link or within the app
- Social features: following friends, viewing friends' public lists, reacting to items (🔥, ❤️, 🙌)
- "Gonna do it" — a friend can claim/reserve an item on someone's wishlist (useful for gift-giving, visible only to other friends, hidden from the list owner)
- Activity feed showing friends' new wanna items, completed items, and milestones
- Marking items as "done" with optional photo/story of the experience
- Basic search and discovery of public wanna items and lists
- Push notifications for key social interactions (friend activity, item claimed, reactions)
- Responsive web application accessible on desktop and mobile browsers

### Out of Scope (v1.0)

- Native iOS and Android mobile applications (web-responsive only for v1.0)
- E-commerce integrations or in-app purchasing of wishlist items
- Payment processing or group-funding/pooling money for gifts
- AI-powered recommendation engine for suggesting wanna items
- Calendar integration or automated scheduling of activities
- Gamification features (badges, leaderboards, streaks)
- Marketplace or vendor partnerships
- Multi-language / internationalization support (English only for v1.0)
- Offline mode / progressive web app capabilities
- Third-party API integrations (Pinterest, Amazon, etc.)
- Content moderation tooling beyond basic reporting

---

## 3. Goals & Success Criteria

### Business Goals

| # | Goal | Description |
|---|------|-------------|
| BG-1 | **User Acquisition** | Attract an initial user base of early adopters who actively create and share wishlists |
| BG-2 | **Social Engagement** | Build a sticky, socially-driven experience that encourages repeat visits and organic sharing |
| BG-3 | **Platform Validation** | Validate the core product-market fit for a social wishlist concept before investing in native apps and monetization |
| BG-4 | **Foundation for Growth** | Establish a scalable, cloud-native architecture that supports future features (native apps, e-commerce, AI recommendations) |

### User Goals

| # | Goal | Description |
|---|------|-------------|
| UG-1 | **Capture wishes effortlessly** | Users can quickly add a wanna item in under 15 seconds from idea to saved entry |
| UG-2 | **Share with the right people** | Users control who sees what — public lists, friends-only lists, or private lists |
| UG-3 | **Discover what friends want** | Users can easily browse friends' lists to find gift ideas or plan shared activities |
| UG-4 | **Feel progress and accomplishment** | Users experience satisfaction when marking items as "done" and reflecting on completed wishes |

### Success Criteria & KPIs

| Metric | Target (90 days post-launch) | Measurement Method |
|--------|------------------------------|-------------------|
| Registered users | 1,000+ | User registration count |
| Monthly active users (MAU) | 40% of registered users | Users with ≥1 session/month |
| Wanna items created per active user | ≥ 5 items per user | Average items created per MAU |
| Lists shared per week | ≥ 200 shares/week | Share action count |
| Social connections per user | ≥ 3 friends per user | Average friend connections per user |
| Item completion rate | ≥ 10% of items marked "done" within 90 days | Done items / total items created |
| Session duration | ≥ 3 minutes average | Analytics tracking |
| Organic referral rate | ≥ 15% of new sign-ups from shared links | Referral attribution tracking |

---

## 4. High-Level Requirements

### Core Wanna Management

- **[REQ-1] User Accounts & Profiles:** The system must allow users to register, log in, and manage a personal profile including display name, avatar, short bio, and privacy settings.

- **[REQ-2] Wanna Item Creation:** Users must be able to create a wanna item with a title (required), and optionally add a description, image or photo, external URL/link, category (do / have / go / try / learn), priority level (low / medium / high / must), and a target date.

- **[REQ-3] List Organization:** Users must be able to create named lists to group related wanna items (e.g., "Summer 2025 Bucket List", "Gift Ideas"). A wanna item can belong to one list, and items without a list appear in a default "My Wannas" collection.

- **[REQ-4] Item Lifecycle:** Users must be able to mark wanna items as "done," optionally attaching a photo and a short reflection or story. Done items move to a "Done" section that serves as a personal achievement timeline. Users can also archive or delete items.

### Social & Sharing

- **[REQ-5] Friend Connections:** Users must be able to find and follow other users. Following is mutual (both users must accept) to establish a "friends" connection. Users can also unfollow/remove friends.

- **[REQ-6] List Visibility & Sharing:** Each list must have a visibility setting: **private** (only the owner can see it), **friends-only** (visible to connected friends), or **public** (accessible via a shareable link to anyone, even non-users). The default visibility for new lists is friends-only.

- **[REQ-7] Gift Claiming ("Gonna do it"):** On a friend's shared wishlist, a user can claim an item by tapping "Gonna do it," which reserves the item. The claim is visible to other friends viewing the list (to prevent duplicate gifts) but is hidden from the list owner to preserve the surprise.

- **[REQ-8] Social Reactions:** Users must be able to react to friends' wanna items with a predefined set of reactions (🔥 Fire, ❤️ Love, 🙌 High-five). Reaction counts are visible on the item.

- **[REQ-9] Activity Feed:** The app must display a chronological activity feed showing friends' recent actions: new wanna items added, items marked as done, new lists created, and milestone moments (e.g., "completed 10 items!").

### Discovery & Notifications

- **[REQ-10] Search & Discovery:** Users must be able to search for other users by name or username, and search public wanna items and lists by keyword. A curated "Explore" section highlights popular and trending public items.

- **[REQ-11] Notifications:** The system must send push notifications and in-app notifications for key events: friend requests, reactions on your items, a friend claiming an item on your wishlist (without revealing who), and friends completing items. Users must be able to configure notification preferences.

### Non-Functional

- **[REQ-12] Performance:** Pages and feeds must load within 2 seconds under normal conditions. Item creation must feel instantaneous (optimistic UI updates).

- **[REQ-13] Privacy & Data Protection:** User data must be handled securely. Private lists must never be exposed to unauthorized users. The gift-claiming feature must strictly enforce hidden-from-owner visibility rules. The system must comply with standard data protection practices.

- **[REQ-14] Accessibility:** The application must meet WCAG 2.1 AA accessibility standards to be usable by people with disabilities.

- **[REQ-15] Scalability:** The system must be designed to support growth from hundreds to tens of thousands of users without degradation in performance or user experience.

---

## 5. User Stories

### Account & Profile

> **US-1:** As a **new user**, I want to **sign up with my email or social login**, so that I can **quickly start creating my wanna lists without friction**.

> **US-2:** As a **registered user**, I want to **set up my profile with a display name, avatar, and short bio**, so that **my friends can recognize me and learn about my interests**.

> **US-3:** As a **registered user**, I want to **control my default privacy settings**, so that **I decide who can see my lists and activity by default**.

### Creating & Managing Wannas

> **US-4:** As a **user**, I want to **quickly add a new wanna item with just a title**, so that I can **capture a fleeting idea before I forget it**.

> **US-5:** As a **user**, I want to **enrich my wanna item with a photo, link, description, and target date**, so that I can **remember the details and context of what I want**.

> **US-6:** As a **user**, I want to **categorize my wanna items as "do", "have", "go", "try", or "learn"**, so that I can **filter and browse my wannas by type**.

> **US-7:** As a **user**, I want to **organize my wanna items into themed lists**, so that I can **keep related wishes together (e.g., travel goals separate from gift ideas)**.

> **US-8:** As a **user**, I want to **mark a wanna item as done and add a photo or short story**, so that I can **celebrate the moment and build a personal achievement timeline**.

> **US-9:** As a **user**, I want to **edit or delete any of my wanna items or lists**, so that I can **keep my wannas current as my interests change**.

### Social & Friends

> **US-10:** As a **user**, I want to **search for friends by name or username and send them a friend request**, so that I can **connect with people I know and see their wannas**.

> **US-11:** As a **user**, I want to **accept or decline incoming friend requests**, so that I can **control who is in my social circle on the app**.

> **US-12:** As a **user**, I want to **browse my friends' shared lists and wanna items**, so that I can **discover what they're interested in and find gift or activity ideas**.

> **US-13:** As a **user**, I want to **react to a friend's wanna item with an emoji reaction**, so that I can **show support and enthusiasm for their goals**.

> **US-14:** As a **user**, I want to **share one of my lists via a public link**, so that **anyone — even people without an account — can view it (e.g., sharing a birthday wishlist)**.

### Gift Claiming

> **US-15:** As a **friend viewing someone's wishlist**, I want to **claim an item by tapping "Gonna do it"**, so that **others know I'm planning to fulfill that wish and we avoid duplicate gifts**.

> **US-16:** As a **friend viewing a wishlist**, I want to **see which items have already been claimed by others**, so that I can **choose an unclaimed item to fulfill**.

> **US-17:** As a **list owner**, I want to **never see who claimed items on my wishlist**, so that **the surprise is preserved**.

### Activity & Discovery

> **US-18:** As a **user**, I want to **see an activity feed of my friends' recent wanna activity**, so that I can **stay connected to what my friends are dreaming about and accomplishing**.

> **US-19:** As a **user**, I want to **explore trending and popular public wanna items**, so that I can **get inspired and discover new ideas for my own lists**.

> **US-20:** As a **user**, I want to **receive notifications when friends interact with my items or send me requests**, so that I can **stay engaged without having to constantly check the app**.

> **US-21:** As a **user**, I want to **customize which notifications I receive**, so that I can **avoid being overwhelmed while staying informed about what matters to me**.

---

## 6. Assumptions & Constraints

### Assumptions

- **[A-1]** Users are comfortable signing up with email or existing social identity providers; a frictionless onboarding flow will drive adoption.
- **[A-2]** The primary usage will be mobile (via responsive web browser), so the UI must be designed mobile-first with touch-friendly interactions.
- **[A-3]** Most users will initially create 5–15 wanna items and 1–3 lists during their first week, with ongoing additions over time.
- **[A-4]** The social/gift-claiming features will be the primary viral growth mechanism, as users share wishlists around birthdays, holidays, and special occasions.
- **[A-5]** Users value simplicity and speed over feature richness — the MVP must prioritize a delightful, fast core experience over breadth of features.
- **[A-6]** English-speaking markets will be the initial target audience.

### Constraints

- **[C-1]** The application must be deployed on Microsoft Azure, leveraging the spec2cloud framework's Azure-native deployment capabilities.
- **[C-2]** The v1.0 release is a responsive web application only; native mobile apps are deferred to a future version.
- **[C-3]** No e-commerce or payment processing will be included in v1.0 — the product is a social experience, not a transactional platform.
- **[C-4]** The product must comply with data protection and privacy regulations applicable to user-generated content and social features (e.g., GDPR for EU users).
- **[C-5]** The system must support image uploads for wanna items and profile avatars, with reasonable file size limits to manage storage costs.
- **[C-6]** The initial launch will not include content moderation tooling beyond a basic user-reporting mechanism; community guidelines will be published and enforced manually.

---

*This is a living document. It will be updated as user research, technical discovery, and stakeholder feedback evolve the product direction.*
