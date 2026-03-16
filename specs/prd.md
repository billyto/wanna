# Product Requirements Document: Wanna Notification Subscription API

## Overview

The Wanna Notification Subscription API enables users to subscribe to named events and receive notifications when those events are triggered. This addresses the common "Notify me when back in stock" pattern found across e-commerce and SaaS platforms.

## Problem Statement

Users often miss time-sensitive events (product restocks, sales launches, availability changes) because there is no lightweight mechanism to register interest and receive a notification at the moment the event occurs.

## Goals

- Provide a simple REST API for subscribing an email address to a named event.
- Allow event producers to trigger notifications for all active subscribers of a given event.
- Keep architecture simple (in-memory, stateless beyond a single process lifetime) for the initial version.

## Non-Goals

- Actual email delivery (out of scope for v1; the API records who would be notified).
- Persistent storage (no database in v1).
- Authentication and authorization (v1 uses open endpoints).

## Success Metrics

- Subscriptions can be created, listed, and cancelled via API.
- Triggering an event returns the list of notified emails and deactivates those subscriptions.
- All endpoints return appropriate HTTP status codes.
- Unit test coverage for the subscription service.

## Stakeholders

| Role | Name |
|------|------|
| Product Owner | Wanna Team |
| Engineering Lead | TBD |

## Timeline

| Milestone | Target |
|-----------|--------|
| v1 API (in-memory) | Sprint 1 |
| Persistent storage | Sprint 2 |
| Email delivery integration | Sprint 3 |
