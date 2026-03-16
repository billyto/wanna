# SPEC2CLOUD Repository - Complete Exploration Summary

## Executive Overview

**Spec2Cloud** is an AI-powered development framework that transforms software development using specialized GitHub Copilot agents. It provides structured workflows for building applications from product ideas through to Azure deployment, supporting both greenfield (new) and brownfield (existing) projects.

The framework emphasizes **specifications as the source of truth**, where PRDs, FRDs, and ADRs drive all development activities rather than manual coding.

---

## 1. README.md - Main Repository Overview

### Key Points:
- **Purpose**: Preconfigured development environment for spec2cloud workflows
- **Two Directions**:
  - **Greenfield**: Build new applications from product ideas
  - **Brownfield**: Reverse engineer existing codebases into documentation

### Three Installation Options:
1. **Use as Template** - GitHub template repository
2. **VSCode Extension** - Install via extension (TODO)
3. **APM CLI** - Package manager installation (TODO)
4. **Manual Script** - One-line install or manual download

### Installation Command:
```bash
curl -fsSL https://raw.githubusercontent.com/EmeaAppGbb/spec2cloud/main/scripts/quick-install.sh | bash
```

### What Gets Installed:
- ✅ 10 specialized AI agents
- ✅ 12 workflow prompts
- ✅ MCP server configuration (optional)
- ✅ Dev container setup (optional)
- ✅ APM configuration (optional)

### Documentation Structure:
- `docs/index.md` - Documentation index
- `docs/shells.md` - Shell baseline templates
- `docs/architecture.md` - System architecture
- `docs/workflows.md` - Workflow documentation
- `docs/specs-structure.md` - Generated specs layout
- `docs/apm.md` - Standards management with APM
- `docs/examples.md` - Usage examples
- `docs/benefits.md` - Key benefits
- `docs/getting-started.md` - Getting started guide

---

## 2. SPEC2CLOUD.md - Framework Overview (YAML Frontmatter)

This is a template file with metadata for the spec2cloud project:
- Title, description, authors
- Category: "AI Apps & Agents"
- Services: Microsoft Foundry
- Languages: (to be filled)
- Frameworks: (to be filled)

---

## 3. INTEGRATION.md - Complete Integration Guide

### Installation Methods:

#### Method 1: Quick Install (Recommended)
```bash
# Full installation
curl -fsSL https://raw.githubusercontent.com/EmeaAppGbb/spec2cloud/main/scripts/quick-install.sh | bash

# Minimal installation
curl -fsSL https://raw.githubusercontent.com/EmeaAppGbb/spec2cloud/main/scripts/quick-install.sh | bash -s -- --minimal

# Install to specific directory
curl -fsSL https://raw.githubusercontent.com/EmeaAppGbb/spec2cloud/main/scripts/quick-install.sh | bash -s -- --target /path/to/project
```

#### Method 2: Manual Download
```bash
curl -L https://github.com/EmeaAppGbb/spec2cloud/releases/latest/download/spec2cloud-full-latest.zip -o spec2cloud.zip
unzip spec2cloud.zip -d spec2cloud
cd spec2cloud
./scripts/install.sh --full  # Linux/Mac
.\scripts\install.ps1 -Full  # Windows
```

### Installation Options:

| Flag | Description |
|------|-------------|
| `--full` / `-Full` | Install all components |
| `--agents-only` / `-AgentsOnly` | Agents and prompts only |
| `--merge` / `-Merge` | Merge with existing files (default) |
| `--force` / `-Force` | Overwrite without prompting |
| `--no-color` / `-NoColor` | Disable colored output |

### What Gets Installed:

```
your-project/
├── .github/
│   ├── agents/              # 10 specialized AI agents
│   │   ├── architect.agent.md
│   │   ├── azure.agent.md
│   │   ├── dev.agent.md
│   │   ├── devlead.agent.md
│   │   ├── extender.agent.md
│   │   ├── modernizer.agent.md
│   │   ├── planner.agent.md
│   │   ├── pm.agent.md
│   │   ├── spec2cloud.agent.md
│   │   └── tech-analyst.agent.md
│   └── prompts/             # 12 workflow prompts
│       ├── adr.prompt.md
│       ├── bootstrap-agents.prompt.md
│       ├── delegate.prompt.md
│       ├── deploy.prompt.md
│       ├── extend.prompt.md
│       ├── frd.prompt.md
│       ├── generate-agents.prompt.md
│       ├── implement.prompt.md
│       ├── modernize.prompt.md
│       ├── plan.prompt.md
│       ├── prd.prompt.md
│       └── rev-eng.prompt.md
├── .vscode/
│   └── mcp.json             # MCP server configuration (full install)
├── .devcontainer/
│   └── devcontainer.json    # Dev container config (full install)
├── specs/                   # Documentation will be generated here
│   ├── features/
│   ├── tasks/
│   └── docs/
└── apm.yml                  # APM configuration (full install)
```

### Integration Scenarios:

1. **New Project** - Start with spec2cloud
2. **Existing Codebase** - Reverse engineer with brownfield workflows
3. **Active Project** - Non-destructive merge with existing files

### Configuration Handling:

- **MCP**: Existing config saved as `mcp.json.spec2cloud`
- **Dev Container**: Existing config saved as `devcontainer.json.spec2cloud`
- **APM**: Skips if `apm.yml` already exists

### Verification After Installation:

```bash
# Check file structure
tree .github/

# Count installed components
find .github/agents -name "*.agent.md" | wc -l   # Should be 10
find .github/prompts -name "*.prompt.md" | wc -l  # Should be 12

# Open in VS Code
code .

# Verify agents: @spec2cloud, @pm, @devlead, @architect, @planner, @dev, @azure, @tech-analyst, @modernizer, @extender
# Verify prompts: /prd, /frd, /plan, /implement, /deploy, /delegate, /rev-eng, /modernize, /extend, /adr, etc.
```

### Greenfield Workflows:

1. **`/prd`** - Create Product Requirements Document
2. **`/frd`** - Create Feature Requirements Documents
3. **`/generate-agents`** - Generate Agent Guidelines (Optional)
4. **`/plan`** - Create Technical Task Breakdown
5. **`/implement`** - Implement Features Locally OR **`/delegate`** - Create GitHub Issues
6. **`/deploy`** - Deploy to Azure

### Brownfield Workflows:

1. **`/rev-eng`** - Reverse Engineer Codebase
2. **`/modernize`** (Optional) - Create Modernization Plan
3. **`/plan`** (Optional) - Implement Modernization
4. **`/deploy`** (Optional) - Deploy to Azure

### Troubleshooting:

- **Agents Not Showing**: Reload VS Code window
- **MCP Servers Not Loading**: Check configuration and required tools (Docker, uvx, Node.js)
- **Permission Denied**: `chmod +x scripts/install.sh`
- **APM Not Found**: `pip install git+https://github.com/danielmeppiel/apm.git`

---

## 4. apm.yml - APM Configuration

```yaml
name: spec2cloud
version: 1.0.0
description: AI-powered Azure development workflow - from spec to cloud

author: EmeaAppGbb
license: MIT

dependencies:
  apm:
    - EmeaAppGbb/spec2cloud-guidelines
    - EmeaAppGbb/spec2cloud-guidelines-backend
    - EmeaAppGbb/spec2cloud-guidelines-frontend

# Workflow shortcuts
scripts:
  prd: "copilot --allow-tool -p .github/prompts/prd.prompt.md"
  frd: "copilot --allow-tool -p .github/prompts/frd.prompt.md"
  plan: "copilot --allow-tool -p .github/prompts/plan.prompt.md"
  implement: "copilot --allow-tool -p .github/prompts/implement.prompt.md"
  delegate: "copilot --allow-tool -p .github/prompts/delegate.prompt.md"
  deploy: "copilot --allow-tool -p .github/prompts/deploy.prompt.md"
```

---

## 5. docs/ Directory - Complete Documentation Structure

### Files in docs/:
1. **index.md** - Documentation index
2. **PRIMER.md** - Comprehensive primer on spec2cloud
3. **getting-started.md** - Getting started guide
4. **shells.md** - Shell baseline templates
5. **architecture.md** - System architecture
6. **workflows.md** - Detailed workflow documentation
7. **specs-structure.md** - Generated documentation structure
8. **apm.md** - APM standards management
9. **examples.md** - Usage examples
10. **benefits.md** - Key benefits
11. **contributing.md** - Contributing guide
12. **README.md** - Docs folder readme

### Key Documentation Highlights:

#### PRIMER.md - Core Philosophy
- **Specs as Source of Truth**: PRD → FRDs → ADRs → AGENTS.md
- **Three Flows**:
  1. Greenfield Flow (idea to cloud)
  2. Greenfield with Shell (shell + agents)
  3. Brownfield Flow (existing code)

- **Layer Model**:
  - Templates (ready-to-use projects)
  - Shells (technical bootstrapping)
  - Spec2Cloud Base (core patterns)

#### specs-structure.md - Generated Documentation Layout
```
specs/
├── prd.md              # Product Requirements Document
├── features/           # Feature Requirements Documents
├── tasks/              # Technical Task Specifications
│   ├── modernization/  # Modernization-specific tasks
│   └── testing/        # Testing and validation tasks
├── modernize/          # Modernization strategy and plans
│   ├── assessment/     # Analysis reports
│   ├── strategy/       # Modernization strategies
│   ├── plans/          # Detailed implementation plans
│   └── risk-management/
└── docs/               # Technical Documentation
    ├── architecture/
    ├── technology/
    └── infrastructure/
```

#### architecture.md - System Components

**Dev Container**:
- Python 3.12, Node.js, TypeScript
- Azure CLI & azd, Docker-in-Docker
- VS Code extensions: Copilot, Azure Pack, AI Studio

**MCP Servers**:
- context7 - Library/framework documentation
- github - Repository operations
- microsoft.docs.mcp - Microsoft/Azure docs
- playwright - Browser automation
- deepwiki - Repository context

#### workflows.md - Workflow Details

**Greenfield**: User idea → PRD → FRDs → Plan → Implement/Delegate → Deploy → Production

**Brownfield**: Existing code → Rev-Eng → Modernize/Extend → Plan → Deploy → Evolved App

---

## 6. templates/ Directory - Templates and Release Info

### Files:
1. **apm.yml.template** - Template for projects to customize APM configuration
2. **RELEASE_README.md** - Release documentation template

### apm.yml.template Content:
Template for new projects showing:
- How to configure APM dependencies
- Available standard packages:
  - `danielmeppiel/azure-standards` (core)
  - `danielmeppiel/python-backend` (optional)
  - `danielmeppiel/react-frontend` (optional)
  - `danielmeppiel/dotnet-standards` (optional)
- Workflow script shortcuts for all major commands
- Post-edit instructions: `apm install`, `apm compile`

---

## 7. scripts/ Directory - Installation Scripts

### Files:
1. **install.sh** - Bash installation script for Linux/Mac
2. **install.ps1** - PowerShell installation script for Windows
3. **quick-install.sh** - One-liner quick install script

### Script Features:
- Color-coded output
- Option parsing (--full, --agents-only, --merge, --force)
- Installation progress tracking
- Verification of existing files
- Conflict handling with .spec2cloud backups
- Support for both full and minimal installations

---

## 8. specs/ Directory Status

**STATUS**: Does NOT exist yet. This directory is created and populated when users run the spec2cloud workflows (/prd, /frd, /plan, etc.).

---

## 9. Key Agents (10 Total)

All located in `.github/agents/`:

1. **spec2cloud.agent.md** (24.8 KB)
   - Orchestrator — Routes requests to specialized agents
   - Model: Claude Opus 4.6
   - Main entry point for users

2. **pm.agent.md** (4.3 KB)
   - Product Manager — Creates PRD and FRDs
   - Model: Claude Opus 4.6

3. **devlead.agent.md** (12.3 KB)
   - Dev Lead — Reviews specs for technical completeness
   - Model: Claude Opus 4.6

4. **architect.agent.md** (4.5 KB)
   - Architect — Creates ADRs and manages guidelines
   - Model: Claude Opus 4.6

5. **planner.agent.md** (5.0 KB)
   - Planner — Creates implementation plans and Mermaid diagrams
   - Model: Claude Opus 4.6

6. **dev.agent.md** (5.7 KB)
   - Developer — Implements features and manages standards
   - Model: Claude Opus 4.6

7. **azure.agent.md** (6.7 KB)
   - Azure Specialist — Deploys with IaC and CI/CD
   - Model: Claude Opus 4.6

8. **tech-analyst.agent.md** (7.2 KB)
   - Reverse Engineer — Analyzes existing codebases
   - Model: Claude Opus 4.6

9. **modernizer.agent.md** (12.4 KB)
   - Modernization Strategist — Creates upgrade roadmaps
   - Model: Claude Opus 4.6

10. **extender.agent.md** (7.4 KB)
    - Feature Extension Specialist — Plans new feature additions
    - Model: Claude Sonnet 4.5

---

## 10. Key Prompts (12 Total)

All located in `.github/prompts/`:

1. **prd.prompt.md** (1.1 KB) - Create Product Requirements Document
2. **frd.prompt.md** (926 B) - Create Feature Requirements Documents
3. **plan.prompt.md** (3.7 KB) - Create Technical Task Breakdown
4. **implement.prompt.md** (4.6 KB) - Implement Features Locally
5. **delegate.prompt.md** (2.1 KB) - Delegate to GitHub Copilot Coding Agent
6. **deploy.prompt.md** (2.6 KB) - Deploy to Azure
7. **rev-eng.prompt.md** (11.6 KB) - Reverse Engineer Codebase
8. **modernize.prompt.md** (23.2 KB) - Create Modernization Plan
9. **extend.prompt.md** (12.8 KB) - Plan New Feature Extensions
10. **generate-agents.prompt.md** (1.9 KB) - Generate Agent Guidelines
11. **bootstrap-agents.prompt.md** (133 B) - Bootstrap Agent Configurations
12. **adr.prompt.md** (6.0 KB) - Create Architecture Decision Records

---

## 11. Key Framework Concepts

### Specifications as Source of Truth
- **PRD** (Product Requirements Document) - What to build and why
- **FRDs** (Feature Requirements Documents) - Individual feature specs
- **ADRs** (Architecture Decision Records) - Key technical decisions
- **AGENTS.md** - Project-specific coding guidelines
- **Tasks** - Actionable implementation items

### The Three Flows

#### 1. Greenfield Flow
```
Idea → PRD → FRDs → Plan → Implement/Delegate → Deploy → Production
```

#### 2. Greenfield with Shell
```
Choose Shell → Clone → PRD/FRDs → Agents Implement → Deploy
```

#### 3. Brownfield Flow
```
Existing Code → Reverse Engineer → (Modernize OR Extend) → Plan → Deploy
```

### Technology Foundation
- **GitHub Copilot** - AI-powered development
- **Copilot Agents** - Custom role-based agents
- **VS Code** - Primary IDE
- **MCP (Model Context Protocol)** - Extended capabilities
- **Azure** - Cloud deployment target
- **Azure Dev CLI (azd)** - Infrastructure provisioning
- **Bicep** - Infrastructure as Code
- **.NET Aspire** - Local development orchestration

---

## 12. APM (Agent Package Manager)

**APM** manages engineering standards for spec2cloud projects:

### Key Features:
- ✅ Zero-config setup - `apm install`
- ✅ Semantic versioning
- ✅ Automatic AGENTS.md generation
- ✅ Mix any standards packages
- ✅ One-command updates

### Built-in Standards:
- **azure-standards** - General engineering, documentation, agent-first patterns, CI/CD, security

### Adding Standards:
```yaml
dependencies:
  apm:
    - EmeaAppGbb/azure-standards@1.0.0
    - EmeaAppGbb/python-backend@1.0.0
    - EmeaAppGbb/react-frontend@1.0.0
```

### Workflow:
```bash
apm install  # Install packages
apm compile  # Generate AGENTS.md
```

---

## 13. Available Shells

Referenced in docs:
1. **shell-dotnet** - .NET + Aspire (without agents)
2. **agentic-shell-dotnet** - .NET + Aspire + AI agents (RECOMMENDED)
3. **agentic-shell-python** - Python + AI agents

All available at: https://github.com/EmeaAppGbb/

---

## 14. Project Artifacts Generated

When users run spec2cloud workflows, the following are created:

```
project/
├── specs/
│   ├── prd.md                         # Product vision
│   ├── features/
│   │   ├── feature-1.md               # Feature specs
│   │   └── feature-2.md
│   ├── adr/
│   │   ├── 0001-database-choice.md    # Design decisions
│   │   └── 0002-auth-strategy.md
│   ├── tasks/                         # Implementation tasks
│   │   ├── task-1.md
│   │   ├── modernization/             # Modernization tasks
│   │   └── testing/                   # Test tasks
│   ├── modernize/                     # Modernization plans (brownfield)
│   │   ├── assessment/
│   │   ├── strategy/
│   │   ├── plans/
│   │   └── risk-management/
│   └── docs/                          # Technical documentation
│       ├── architecture/
│       ├── technology/
│       └── infrastructure/
├── AGENTS.md                          # Coding guidelines
└── infra/                             # Infrastructure as Code (Bicep)
```

---

## 15. Community & Resources

- **GitHub Repository**: https://github.com/EmeaAppGbb/spec2cloud
- **Template Gallery**: https://aka.ms/spec2cloud
- **VS Code Extension**: spec2cloud-toolkit
- **APM Documentation**: https://github.com/danielmeppiel/apm
- **Example Templates**: spec2cloud-marketing-agents

---

## 16. License & Support

- **License**: MIT (see LICENSE.md)
- **Support**: GitHub Issues and Discussions
- **Contributing**: Open to contributions for agents, prompts, and MCP servers

---

## Summary: Project Context

Spec2Cloud is a **comprehensive AI-driven development framework** that:

1. **Transforms development workflows** - From manual coding to specification-driven AI development
2. **Provides specialized agents** - 10 agents with specific roles (PM, DevLead, Dev, Azure, etc.)
3. **Supports multiple scenarios**:
   - Greenfield: Build new apps from ideas
   - Brownfield: Document and modernize existing code
4. **Uses specifications as source of truth** - PRD → FRDs → ADRs → Code
5. **Manages standards with APM** - Consolidate engineering best practices
6. **Deploys to Azure** - Complete IaC and CI/CD generation
7. **Integrates with GitHub Copilot** - Custom agents and workflows

The repository is a **template and configuration package** that can be installed into any project (new or existing) to enable AI-powered development with standardized workflows.

