CREATE PROCEDURE [dbo].[usp_find_sales_record]
    @Id INT
AS
BEGIN
    SELECT (
        Id, 
        ProductName, 
        Quantity, 
        Price, 
        SaleDate, 
        Overseer
    )
    FROM [dbo].[SalesRecord]
    WHERE Id = @Id;
END;
RETURN 0;
;
