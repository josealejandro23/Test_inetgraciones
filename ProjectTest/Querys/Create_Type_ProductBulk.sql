--Definición de un tipo de datos de tabla para recibir un dataTable desde la capa de servicios, tipo Table-Valued Parameter (TVP)
CREATE TYPE dbo.ProductBulk AS TABLE
(
    Name varchar(100),
    supplierId int,
    categoryId int,
    UnitInStock int,
    QuantityPerUnit int,
    UnitPrice int
);