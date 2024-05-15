@echo off
REM Detener el commit si hay fallas

REM Ejecutar linting
echo Running lint checks...
dotnet format --check
if %ERRORLEVEL% neq 0 (
  echo Linting failed. Commit aborted.
  exit /b 1
)

REM Ejecutar tests
echo Running tests...
dotnet test Diaspora.Test
if %ERRORLEVEL% neq 0 (
  echo Tests failed. Commit aborted.
  exit /b 1
)

echo All checks passed. Committing...