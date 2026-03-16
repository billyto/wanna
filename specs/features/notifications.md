# Feature: Notification Subscriptions

## Summary

Allow users to subscribe to named events by email and be notified when those events are triggered.

## User Stories

### US-01 — Subscribe to an event
**As a** user,  
**I want to** register my email for a specific event name,  
**So that** I am notified when that event occurs.

**Acceptance Criteria:**
- `POST /api/subscriptions` with `{ email, eventName }` creates a subscription.
- Returns `201 Created` with the new subscription object including a unique `id`.
- Duplicate email/event combinations are allowed (idempotency handled in v2).

### US-02 — List subscriptions
**As an** operator,  
**I want to** view all active subscriptions, optionally filtered by event name,  
**So that** I can audit who is waiting for a notification.

**Acceptance Criteria:**
- `GET /api/subscriptions` returns all active subscriptions.
- `GET /api/subscriptions?eventName=restock` filters by event name (case-insensitive).
- Returns `200 OK` with an array (possibly empty).

### US-03 — Unsubscribe
**As a** user,  
**I want to** cancel my subscription,  
**So that** I no longer receive notifications for that event.

**Acceptance Criteria:**
- `DELETE /api/subscriptions/{id}` deactivates the subscription.
- Returns `204 No Content` on success.
- Returns `404 Not Found` if the id does not exist.

### US-04 — Trigger an event
**As an** event producer,  
**I want to** trigger a named event,  
**So that** all subscribers are notified and their subscriptions are deactivated.

**Acceptance Criteria:**
- `POST /api/notifications/trigger/{eventName}` triggers the event.
- Returns `200 OK` with `{ eventName, notifiedCount, notifiedEmails, triggeredAt }`.
- Subscribers are deactivated (one-time notification model).
- Event name matching is case-insensitive.

## API Endpoints

| Method | Path | Description |
|--------|------|-------------|
| `GET` | `/api/subscriptions` | List active subscriptions |
| `POST` | `/api/subscriptions` | Create a subscription |
| `DELETE` | `/api/subscriptions/{id}` | Cancel a subscription |
| `POST` | `/api/notifications/trigger/{eventName}` | Trigger event and notify subscribers |

## Data Model

### Subscription
| Field | Type | Description |
|-------|------|-------------|
| `id` | `Guid` | Unique identifier |
| `email` | `string` | Subscriber email address |
| `eventName` | `string` | Name of the event to subscribe to |
| `createdAt` | `DateTime` | UTC creation timestamp |
| `isActive` | `bool` | Whether the subscription is active |

### NotificationResult
| Field | Type | Description |
|-------|------|-------------|
| `eventName` | `string` | The triggered event name |
| `notifiedCount` | `int` | Number of subscribers notified |
| `notifiedEmails` | `string[]` | Emails of notified subscribers |
| `triggeredAt` | `DateTime` | UTC timestamp of the trigger |

## Technical Notes

- v1 uses in-memory storage (`ConcurrentDictionary`) — data is lost on restart.
- Swagger/OpenAPI UI is available at `/swagger` in development.
- No authentication in v1.
