# Add migration
Add-Migration InitialCreate -OutputDir "Data/Migrations"

# Applay migration
Update-Database

# Remove migration
Remove-Migration