IF DB_ID('tf_product') IS NULL
BEGIN
    CREATE DATABASE tf_product;
END

GO

USE [tf_product];

IF OBJECT_ID('Products', 'U') IS NULL
BEGIN
    CREATE TABLE [Products](
        [id]            [int] IDENTITY(1,1) NOT NULL,
        [name]          [nvarchar](100) NOT NULL,
        [price]         [float]

        CONSTRAINT PK_Product_id PRIMARY KEY CLUSTERED([id]),
        CONSTRAINT U_Product_name UNIQUE([name])
    );
END;
