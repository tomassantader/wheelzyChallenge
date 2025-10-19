USE [wheelzyDb]
GO

INSERT INTO ZipCodes (ZIP_CODE, AREA_NAME, IS_ACTIVE)
VALUES
(90001, 'Los Angeles, CA', 1),
(33101, 'Miami, FL', 1),
(75201, 'Dallas, TX', 1),
(60601, 'Chicago, IL', 1),
(98101, 'Seattle, WA', 0);
GO

INSERT INTO Buyers (FULLNAME, IS_ACTIVE)
VALUES
('John Smith', 1),
('Maria Gonzalez', 1),
('David Johnson', 1),
('Laura Pérez', 0),
('Michael Brown', 1);
GO

INSERT INTO Cars (MAKE, MODEL, SUBMODEL, YEAR, ID_ZIP_CODE, IS_ACTIVE)
VALUES
('Toyota', 'Camry', 'LE', '2018-01-01', 90001, 1),
('Honda', 'Civic', 'EX', '2019-01-01', 33101, 1),
('Ford', 'F-150', 'XL', '2020-01-01', 75201, 1),
('Chevrolet', 'Malibu', 'LT', '2017-01-01', 60601, 1),
('Tesla', 'Model 3', 'Standard', '2021-01-01', 90001, 1),
('Nissan', 'Altima', 'S', '2016-01-01', 33101, 0);
GO

INSERT INTO Quotes (ID_BUYER, ID_ZIP_CODE, AMOUNT, IS_CURRENT, IS_ACTIVE)
VALUES
(1, 90001, 12500.50, 1, 1),
(2, 33101, 9800.00, 1, 1),
(3, 75201, 15000.75, 0, 1),
(4, 60601, 8700.00, 1, 1),
(5, 90001, 22000.00, 0, 1),
(1, 75201, 11900.00, 1, 1);
GO

INSERT INTO States ([DESCRIPTION])
VALUES
('Pending'),
('Accepted'),
('Picked Up'),
('Closed'),
('Canceled');
GO

INSERT INTO Orders (ID_QUOTE, [ID_STATUS], CREATED_DATE, IS_ACTIVE)
VALUES
(1, 1, '2024-05-10', 1),
(2, 2, '2024-05-15', 1),
(3, 5, '2024-05-18', 0),
(4, 1, '2024-06-01', 1),
(5, 3, '2024-06-12', 1),
(6, 4, '2024-07-03', 1);
GO

INSERT INTO OrdersDetail (ID_ORDER, ID_CAR, PICKED_UP_DATE)
VALUES
(1, 1, NULL),
(2, 2, NULL),
(3, 1, NULL),
(4, 4, NULL),
(5, 5, '2025-06-28'),
(5, 3, NULL),
(6, 6, '2024-07-05');
GO


INSERT INTO OrdersHistory (ID_ORDER_DETAIL, [ID_STATUS], UPDATE_DATE)
VALUES
(1, 1, '2024-05-10'),
(2, 1, '2024-05-10'),
(2, 2, '2024-05-15'),
(3, 1, '2024-05-18'),
(3, 5, '2024-05-20'),
(4, 1, '2024-06-01'),
(5, 1, '2024-06-12'),
(6, 1, '2024-06-12'),
(5, 2, '2024-06-18'),
(6, 2, '2024-06-18'),
(5, 3, '2025-06-28'),
(7, 1, '2024-07-03'),
(7, 2, '2024-07-04'),
(7, 3, '2025-07-05');
GO
