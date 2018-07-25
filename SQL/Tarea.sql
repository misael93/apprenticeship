-- 1. Show the first name and the email address of customer with CompanyName 'Bike World'
SELECT FirstName, EmailAddress
FROM SalesLT.Customer
WHERE CompanyName = 'Bike World'

-- 2. Show the CompanyName for all customers with an address in City 'Dallas'.
SELECT c.CompanyName
FROM SalesLT.Customer c
INNER JOIN SalesLT.CustomerAddress ca ON c.CustomerID = ca.CustomerID
INNER JOIN SalesLT.Address a ON ca.AddressID = a.AddressID
WHERE a.City = 'Dallas'

-- 3. How many items with ListPrice more than $1000 have been sold?
SELECT count(*)
FROM SalesLT.Product p
INNER JOIN SalesLT.SalesOrderDetail sod ON p.ProductID = sod.ProductID
WHERE p.ListPrice > 1000

-- 6. A "Single Item Order" is a customer order where only one item is ordered.
-- Show the SalesOrderID and the UnitPrice for every Single Item Order.
SELECT SalesOrderID, UnitPrice
FROM SalesLT.SalesOrderDetail
WHERE SalesOrderID
IN
(SELECT SalesOrderID
FROM
(SELECT COUNT(*) AS ItemsOrdered, SalesOrderID
FROM SalesLT.SalesOrderDetail
GROUP BY(SalesOrderID)) X
WHERE X.ItemsOrdered = 1)

-- 7. Where did the racing socks go?
-- List the product name and the CompanyName for all Customers who ordered ProductModel 'Racing Socks'.
SELECT p.Name, c.CompanyName
FROM SalesLT.Customer c
INNER JOIN SalesLT.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID
INNER JOIN SalesLT.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID
INNER JOIN SalesLT.Product p ON sod.ProductID = p.ProductID
INNER JOIN SalesLT.ProductModel pm ON p.ProductModelID = pm.ProductModelID
WHERE pm.Name = 'Racing Socks'

-- 8. Show the product description for culture 'fr' for product with ProductID 736.
SELECT pd.Description
FROM SalesLT.ProductDescription pd
INNER JOIN SalesLT.ProductModelProductDescription pmpd ON pd.ProductDescriptionID = pmpd.ProductDescriptionID
INNER JOIN SalesLT.ProductModel pm ON pmpd.ProductModelID = pm.ProductModelID
INNER JOIN SalesLT.Product p ON pm.ProductModelID = p.ProductModelID
WHERE pmpd.Culture = 'fr'
AND p.ProductID = 736

-- 11. For every customer with a 'Main Office' in Dallas show AddressLine1 of the 'Main Office'
-- and AddressLine1 of the 'Shipping' address - if there is no shipping address leave it blank.
-- Use one row per customer.
SELECT *
FROM SalesLT.Customer c
INNER JOIN SalesLT.CustomerAddress ca ON c.CustomerID = ca.CustomerID
INNER JOIN SalesLT.Address a ON ca.AddressID = a.AddressID
--LEFT JOIN SalesLT.SalesOrderHeader soh ON a.AddressID = soh.ShipToAddressID
WHERE ca.AddressType = 'Main Office'
AND a.City = 'Dallas'

SELECT * FROM SalesLT.SalesOrderHeader
WHERE CustomerID IN (29553, 29574, 29866, 29948, 29954)

select top 10 * from SalesLT.SalesOrderHeader