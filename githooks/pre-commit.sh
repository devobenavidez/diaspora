#!/bin/bash
# Detener el commit si hay fallas

# Ejecutar linting
echo "Running lint checks..."
dotnet format --check
if [ $? -ne 0 ]; then
  echo "Linting failed. Commit aborted."
  exit 1
fi

# Ejecutar tests
echo "Running tests..."
dotnet test Diaspora.Test
if [ $? -ne 0 ]; then
  echo "Tests failed. Commit aborted."
  exit 1
fi

echo "All checks passed. Committing..."