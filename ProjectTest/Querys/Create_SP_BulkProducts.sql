--Store procedure para consultar los suppliers registrados
CREATE PROCEDURE BulkProducts
    @Products dbo.ProductBulk READONLY
AS
BEGIN
    -- Lógica para insertar los datos desde @Products a la tabla de productos
    INSERT INTO dbo.Products ([Name], SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock)
    SELECT Name, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitInStock
    FROM @Products;
END;