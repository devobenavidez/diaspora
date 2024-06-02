#!/bin/bash
set -e

# Configuración de la base de datos desde variables de entorno o argumentos
DB_HOST="${DB_HOST}"
DB_USER="${DB_USER}"
DB_PASSWORD="${DB_PASSWORD}"
DB_NAME="${DB_NAME}"

echo "Iniciando migraciones"

# Verificar que todas las variables necesarias estén configuradas
if [ -z "$DB_HOST" ] || [ -z "$DB_USER" ] || [ -z "$DB_PASSWORD" ] || [ -z "$DB_NAME" ]; then
    echo "Falta la configuración de la base de datos. Por favor, asegúrate de que todas las variables de entorno y argumentos están configurados."
    exit 1
fi

echo "Configuración de la base de datos:"
echo "Host: $DB_HOST"
echo "Usuario: $DB_USER"
echo "Base de Datos: $DB_NAME"

# Directorio de migraciones
MIGRATIONS_DIR="./Migrations"
echo "Directorio de migraciones: $MIGRATIONS_DIR"

# Función para comprobar si una migración ya ha sido aplicada
migration_applied() {
    local filename=$1
    local result=$(mysql -h $DB_HOST -u $DB_USER -p$DB_PASSWORD -D $DB_NAME -ss -e "SELECT COUNT(*) FROM migrations WHERE filename='$filename';")
    [[ "$result" -gt 0 ]]
}

echo "Comprobando migraciones aplicadas..."

# Asegurarse de que la tabla de migraciones exista
echo "Creando tabla de migraciones si no existe..."
mysql -h $DB_HOST -u $DB_USER -p$DB_PASSWORD -D $DB_NAME <<EOF
CREATE TABLE IF NOT EXISTS migrations (
    id INT AUTO_INCREMENT PRIMARY KEY,
    filename VARCHAR(255) NOT NULL,
    applied_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
EOF
echo "Tabla de migraciones creada"

# Aplicar migraciones
for migration in $(ls $MIGRATIONS_DIR/*.sql | sort); do
    migration_file=$(basename $migration)
    if migration_applied "$migration_file"; then
        echo "Migración ya aplicada: $migration_file"
    else
        echo "Ejecutando migración: $migration_file"
        mysql -h $DB_HOST -u $DB_USER -p$DB_PASSWORD -D $DB_NAME < "$migration"
        mysql -h $DB_HOST -u $DB_USER -p$DB_PASSWORD -D $DB_NAME -e "INSERT INTO migrations (filename) VALUES ('$migration_file');"
    fi
done

echo "Migraciones completadas"
