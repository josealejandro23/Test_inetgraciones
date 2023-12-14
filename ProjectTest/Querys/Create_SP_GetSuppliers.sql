--Store procedure para consultar los suppliers registrados
CREATE PROCEDURE GetSuppliers 
AS   
    SET NOCOUNT ON;  
    SELECT * 
    FROM dbo.Suppliers
GO  