# Copilot Instructions for UltrakULL

## Commit Messages (CRITICAL)

**Always generate commit messages in English only.** Do NOT generate commits in Russian or any other language.

### Format: Conventional Commits
Use this format: `<type>(<scope>): <subject>`

**Types** (choose one):
- `feat` - new feature
- `fix` - bug fix
- `refactor` - code refactoring
- `docs` - documentation changes
- `chore` - build, dependencies, tooling
- `test` - tests
- `perf` - performance optimization
- `style` - code style (formatting, semicolons, etc.)
- `ci` - CI/CD configuration

**Scope** (affected module):
- `LanguageManager` - localization system
- `AudioSwapper` - audio dubbing
- `TexturePatcher` - texture replacement
- `Main` - core initialization
- `HarmonyPatches` - Harmony patches
- `SubtitledSources` - subtitle and audio sources

**Subject** (description):
- Max 50 characters
- Start with lowercase letter
- No period at the end
- Be specific and concise

### Good Examples
- `feat(LanguageManager): add automatic key synchronization for missing translations`
- `fix(AudioSwapper): resolve null reference when loading custom audio files`
- `refactor(TexturePatcher): optimize texture lookup with caching mechanism`
- `docs(Core): update localization setup guide in README`
- `chore(deps): update Newtonsoft.Json to 13.0.2`

### Bad Examples (DO NOT CREATE)
- ✗ `Добавлена функция локализации` (Russian - FORBIDDEN)
- ✗ `updated stuff` (too vague)
- ✗ `Fix bug` (type should be lowercase)
- ✗ `feat: modified LanguageManager and AudioSwapper and TexturePatcher` (scope missing, too many modules)

## Analysis Precision

When generating commit messages, analyze the actual code changes:
1. Identify which file(s) were modified
2. Determine the exact type of change
3. Pick the most specific scope
4. Write a clear, technical subject line
5. Do NOT generalize or guess - read the code diff carefully
