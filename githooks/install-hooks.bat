@echo off
REM Verifica si el directorio .git/hooks existe
if exist ".git\hooks" (
    REM Copia el script de pre-commit al directorio de hooks de Git y asegura la extensión .bat
    copy githooks\pre-commit-w .git\hooks\pre-commit
    echo Hooks installed successfully.
) else (
    echo This directory does not appear to be a Git repository.
)