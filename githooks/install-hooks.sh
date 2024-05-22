#!/bin/bash
# Verifica si el directorio .git/hooks existe
if [ -d ".git/hooks" ]; then
    # Copia el script de pre-commit al directorio de hooks de Git y le da permisos de ejecución
    cp githooks/pre-commit.sh .git/hooks/pre-commit
    chmod +x .git/hooks/pre-commit
    echo "Hooks installed successfully."
else
    echo "This directory does not appear to be a Git repository."
fi
