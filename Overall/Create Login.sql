USE SellGoldProducts;
GO

-- Cria o login no servidor
CREATE LOGIN SellGoldProductsAdmin
WITH PASSWORD = 'Pr0ducts@2025!',
     CHECK_POLICY = OFF;
GO

-- Cria o usuário dentro da base
CREATE USER SellGoldProductsAdmin FOR LOGIN SellGoldProductsAdmin;
GO

-- Concede permissão de administrador (db_owner)
ALTER ROLE db_owner ADD MEMBER SellGoldProductsAdmin;
GO

USE SellGoldSuppliers;
GO

-- Cria o login no servidor
CREATE LOGIN SellGoldSuppliersAdmin
WITH PASSWORD = 'Suppl!ers@2025!',
     CHECK_POLICY = OFF;
GO

-- Cria o usuário dentro da base
CREATE USER SellGoldSuppliersAdmin FOR LOGIN SellGoldSuppliersAdmin;
GO

-- Concede permissão de administrador (db_owner)
ALTER ROLE db_owner ADD MEMBER SellGoldSuppliersAdmin;
GO