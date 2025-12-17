-- Listar todas as tabelas
SELECT name AS NomeTabela
FROM sys.tables;

-- Listar colunas de todas as tabelas
SELECT t.name AS Tabela, c.name AS Coluna, ty.name AS Tipo
FROM sys.tables t
JOIN sys.columns c ON t.object_id = c.object_id
JOIN sys.types ty ON c.user_type_id = ty.user_type_id
ORDER BY t.name, c.column_id;
