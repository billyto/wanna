# SPEC2CLOUD - Quick Reference Guide

## What is Spec2Cloud?
An AI-powered development framework using specialized GitHub Copilot agents to transform software development from product ideas through Azure deployment.

---

## Core Files You Need to Know

| File/Directory | Purpose |
|---|---|
| `README.md` | Main overview, installation options, quick start |
| `INTEGRATION.md` | Detailed installation guide, integration scenarios, troubleshooting |
| `SPEC2CLOUD.md` | Metadata template (YAML frontmatter) |
| `apm.yml` | APM package manager configuration |
| `scripts/` | Installation scripts (install.sh, install.ps1, quick-install.sh) |
| `docs/` | Complete documentation (12 markdown files) |
| `templates/` | Configuration templates (apm.yml.template, RELEASE_README.md) |
| `.github/agents/` | 10 specialized AI agents |
| `.github/prompts/` | 12 workflow prompts |
| `specs/` | **Does NOT exist yet** — created when workflows run |

---

## 10 Specialized Agents (`.github/agents/`)

| # | Agent | Role | Model |
|---|---|---|---|
| 1 | `@spec2cloud` | Orchestrator — routes to specialists | Claude Opus 4.6 |
| 2 | `@pm` | Product Manager — PRD/FRD creation | Claude Opus 4.6 |
| 3 | `@devlead` | Dev Lead — technical review | Claude Opus 4.6 |
| 4 | `@architect` | Architect — ADRs, guidelines, AGENTS.md | Claude Opus 4.6 |
| 5 | `@planner` | Planner — research, planning (no code) | Claude Opus 4.6 |
| 6 | `@dev` | Developer — implementation | Claude Opus 4.6 |
| 7 | `@azure` | Azure Specialist — deployment | Claude Opus 4.6 |
| 8 | `@tech-analyst` | Reverse Engineer — analyzes code | Claude Opus 4.6 |
| 9 | `@modernizer` | Modernization Strategist — upgrade plans | Claude Opus 4.6 |
| 10 | `@extender` | Feature Extension Specialist | Claude Sonnet 4.5 |

---

## 12 Workflow Prompts (`.github/prompts/`)

### Greenfield Workflows (New Projects)
| Prompt | Purpose |
|---|---|
| `/prd` | Create Product Requirements Document |
| `/frd` | Break PRD into Feature Requirements Documents |
| `/generate-agents` | Generate AGENTS.md from standards |
| `/plan` | Create Technical Task Breakdown |
| `/implement` | Implement features locally |
| `/delegate` | Create GitHub issues for Copilot Coding Agent |
| `/deploy` | Deploy to Azure with IaC + CI/CD |

### Brownfield Workflows (Existing Code)
| Prompt | Purpose |
|---|---|
| `/rev-eng` | Reverse engineer codebase into specs |
| `/modernize` | Create modernization plan |
| `/extend` | Plan new feature extensions |
| `/plan` | Implement tasks from specs |

### Special Prompts
| Prompt | Purpose |
|---|---|
| `/adr` | Create Architecture Decision Records |
| `/bootstrap-agents` | Bootstrap agent configurations |

---

## Installation: Quick Start

### One-Liner (Recommended)
```bash
curl -fsSL https://raw.githubusercontent.com/EmeaAppGbb/spec2cloud/main/scripts/quick-install.sh | bash
```

### Manual Steps
```bash
# Download
curl -L https://github.com/EmeaAppGbb/spec2cloud/releases/latest/download/spec2cloud-full-latest.zip -o spec2cloud.zip
unzip spec2cloud.zip -d spec2cloud
cd spec2cloud

# Install
./scripts/install.sh --full        # Linux/Mac
.\scripts\install.ps1 -Full        # Windows
```

### Installation Modes
- `--full` — Everything (agents, prompts, MCP, dev container, APM)
- `--agents-only` — Agents and prompts only
- `--merge` — Merge with existing files (default)
- `--force` — Overwrite without prompting

---

## Greenfield Workflow: New Project

```
1. /prd                 → PM creates Product Requirements Document
2. /frd                 → PM breaks into Feature Requirements Documents
3. /generate-agents     → Dev Lead creates AGENTS.md from standards
4. /plan                → Dev creates technical task breakdown
5. /implement OR /delegate → Dev implements or creates GitHub issues
6. /deploy              → Azure agent deploys to Azure
```

**Result**: Fully deployed application on Azure with complete documentation

---

## Brownfield Workflow: Existing Code

```
1. /rev-eng             → Tech Analyst reverse engineers code
                           Creates: specs/docs/, specs/features/, specs/tasks/
2. Choose next step:
   - /modernize         → Create modernization plan
   - /extend            → Plan new feature extensions
3. /plan                → Dev implements tasks
4. /deploy              → Azure agent deploys to Azure
```

**Result**: Documented, modernized/extended application on Azure

---

## What Gets Generated: specs/ Directory

### When Created:
Users run spec2cloud workflows (/prd, /frd, /plan, etc.)

### Directory Structure:
```
specs/
├── prd.md                    # Product Requirements Document
├── features/                 # Feature specs
│   ├── feature-1.md
│   └── feature-2.md
├── adr/                      # Architecture Decision Records
│   └── 0001-decision.md
├── tasks/                    # Implementation tasks
│   ├── task-1.md
│   ├── modernization/        # Modernization tasks
│   └── testing/              # Test tasks
├── modernize/                # Modernization strategy (brownfield)
│   ├── assessment/
│   ├── strategy/
│   ├── plans/
│   └── risk-management/
└── docs/                     # Technical documentation
    ├── architecture/
    ├── technology/
    └── infrastructure/
```

---

## APM: Managing Engineering Standards

**APM = Agent Package Manager** for managing coding standards

### Key Features:
- ✅ Zero-config installation (`apm install`)
- ✅ Auto-generate AGENTS.md (`apm compile`)
- ✅ Mix multiple standard packages
- ✅ Semantic versioning

### Configuration (apm.yml):
```yaml
dependencies:
  apm:
    - EmeaAppGbb/azure-standards     # Core standards
    # Add tech-specific standards:
    - EmeaAppGbb/python-backend       # Python backend rules
    - EmeaAppGbb/react-frontend       # React frontend rules
    - EmeaAppGbb/dotnet-standards     # .NET rules

scripts:
  prd: "copilot --allow-tool -p .github/prompts/prd.prompt.md"
  # ... other workflow shortcuts
```

### Workflow:
```bash
apm install  # Install all dependencies
apm compile  # Generate AGENTS.md from standards
```

---

## Architecture: Key Technologies

| Technology | Purpose |
|---|---|
| **GitHub Copilot + Agents** | AI-powered development with specialized roles |
| **VS Code** | Primary development IDE |
| **MCP (Model Context Protocol)** | Extended AI capabilities |
| **Azure Dev CLI (azd)** | Infrastructure provisioning |
| **Bicep** | Infrastructure as Code |
| **.NET Aspire** | Local multi-project orchestration (in shells) |
| **Dev Container** | Consistent development environment |

---

## MCP Servers (`.vscode/mcp.json`)

Extend agent capabilities with:
- **context7** — Library & framework documentation
- **github** — Repository operations
- **microsoft.docs.mcp** — Official Microsoft/Azure docs
- **playwright** — Browser automation
- **deepwiki** — Repository deep analysis

---

## Dev Container Includes

- Python 3.12
- Node.js & TypeScript
- Azure CLI & Azure Dev CLI (azd)
- Docker-in-Docker
- VS Code extensions: Copilot Chat, Azure Pack, AI Toolkit

---

## Verification After Installation

```bash
# Should see 10 agents and 12 prompts installed:
find .github/agents -name "*.agent.md" | wc -l      # 10
find .github/prompts -name "*.prompt.md" | wc -l     # 12

# In VS Code Copilot Chat:
# Type @ → See all 10 agents
# Type / → See all 12 prompts
```

---

## Common Tasks

### Create New Application
1. `/prd` → `/frd` → `/generate-agents` → `/plan` → `/implement` → `/deploy`

### Document Existing Code
1. `/rev-eng` → Review generated specs in `specs/`

### Modernize Legacy App
1. `/rev-eng` → `/modernize` → Review plan → `/plan` → Implement → `/deploy`

### Add Features to Existing App
1. `/rev-eng` (if not done) → `/extend` → Create FRDs → `/plan` → Implement

---

## Related Resources

- **Main Repo**: https://github.com/EmeaAppGbb/spec2cloud
- **Shells**: agentic-shell-dotnet, agentic-shell-python, shell-dotnet
- **Template Gallery**: https://aka.ms/spec2cloud
- **VS Code Extension**: spec2cloud-toolkit
- **APM**: https://github.com/danielmeppiel/apm
- **Example Template**: spec2cloud-marketing-agents

---

## Documentation Files (docs/)

| File | Topic |
|---|---|
| `index.md` | Docs index |
| `PRIMER.md` | Comprehensive primer (start here!) |
| `getting-started.md` | Setup guide |
| `architecture.md` | System architecture |
| `workflows.md` | Detailed workflow documentation |
| `shells.md` | Shell baseline templates |
| `specs-structure.md` | Generated specs layout |
| `apm.md` | APM standards management |
| `examples.md` | Usage examples |
| `benefits.md` | Key benefits |
| `contributing.md` | Contributing guide |

---

## Key Concepts

### Specifications as Source of Truth
Rather than starting with code, start with:
1. **PRD** (What to build and why)
2. **FRDs** (Feature specifications)
3. **ADRs** (Architecture decisions)
4. **AGENTS.md** (Coding guidelines)

Agents generate code from these specs, maintaining consistency and traceability.

### Three-Layer Model
```
Templates (complete projects) ← Built on
    Shells (technical bootstrap) ← Built on
        Spec2Cloud Base (core patterns)
```

### Three Flows
1. **Greenfield** — Build from scratch
2. **Greenfield with Shell** — Start with template, then extend
3. **Brownfield** — Document/modernize existing code

---

## File Summary

| Path | Files | Purpose |
|---|---|---|
| `.github/agents/` | 10 `.agent.md` | Specialized AI agents |
| `.github/prompts/` | 12 `.prompt.md` | Workflow prompts |
| `scripts/` | 3 scripts | Installation automation |
| `docs/` | 12 `.md` files | Complete documentation |
| `templates/` | 2 files | Configuration templates |
| `specs/` | (doesn't exist) | Generated during workflows |
| Root | README.md, INTEGRATION.md, SPEC2CLOUD.md, apm.yml, LICENSE.md | Core configuration |

---

## License & Support

- **License**: MIT
- **Repository**: https://github.com/EmeaAppGbb/spec2cloud
- **Support**: GitHub Issues and Discussions
- **Contributing**: Open to extensions (agents, prompts, MCP servers)

