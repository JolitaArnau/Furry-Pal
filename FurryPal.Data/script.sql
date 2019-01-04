IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [Addresses] (
        [Id] nvarchar(450) NOT NULL,
        [ZipCode] nvarchar(max) NULL,
        [CountryName] nvarchar(max) NULL,
        [CityName] nvarchar(max) NULL,
        [ProvinceName] nvarchar(max) NULL,
        [StreetName] nvarchar(max) NULL,
        [HouseNumber] int NOT NULL,
        CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [Categories] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [Sales] (
        [Id] nvarchar(450) NOT NULL,
        [Type] nvarchar(max) NULL,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [AddressId] nvarchar(450) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUsers_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [Manufacturers] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [AddressId] nvarchar(450) NULL,
        CONSTRAINT [PK_Manufacturers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Manufacturers_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [ProductPurchases] (
        [Id] nvarchar(450) NOT NULL,
        [CustomerId] nvarchar(450) NULL,
        [OrderDate] datetime2 NOT NULL,
        [TotalOrderPrice] decimal(18, 2) NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_Purchases] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Purchases_AspNetUsers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [SubscriptionPurchases] (
        [Id] nvarchar(450) NOT NULL,
        [CustomerId] nvarchar(450) NULL,
        [InitialOrderDate] datetime2 NOT NULL,
        [ReorderInterval] int NOT NULL,
        [NextReorderDispatchDate] datetime2 NOT NULL,
        [TotalOrderPrice] decimal(18, 2) NOT NULL,
        CONSTRAINT [PK_SubscriptionPurchases] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubscriptionPurchases_AspNetUsers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE TABLE [Products] (
        [Id] nvarchar(450) NOT NULL,
        [ProductCode] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [CategoryId] nvarchar(450) NULL,
        [Price] decimal(18, 2) NOT NULL,
        [ManufacturerId] nvarchar(450) NULL,
        [StockQuantity] int NOT NULL,
        [PurchaseId] nvarchar(450) NULL,
        [SaleId] nvarchar(450) NULL,
        [SubscriptionPurchaseId] nvarchar(450) NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_Manufacturers_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_Purchases_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [ProductPurchases] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_Sales_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [Sales] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_SubscriptionPurchases_SubscriptionPurchaseId] FOREIGN KEY ([SubscriptionPurchaseId]) REFERENCES [SubscriptionPurchases] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUsers_AddressId] ON [AspNetUsers] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Manufacturers_AddressId] ON [Manufacturers] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Products_ManufacturerId] ON [Products] ([ManufacturerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Products_PurchaseId] ON [Products] ([PurchaseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Products_SaleId] ON [Products] ([SaleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Products_SubscriptionPurchaseId] ON [Products] ([SubscriptionPurchaseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Purchases_CustomerId] ON [ProductPurchases] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_SubscriptionPurchases_CustomerId] ON [SubscriptionPurchases] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115153437_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181115153437_InitialCreate', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Sales_SaleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_SubscriptionPurchases_SubscriptionPurchaseId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [SubscriptionPurchases] DROP CONSTRAINT [FK_SubscriptionPurchases_AspNetUsers_CustomerId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [SubscriptionPurchases] DROP CONSTRAINT [PK_SubscriptionPurchases];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [Sales] DROP CONSTRAINT [PK_Sales];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    EXEC sp_rename N'[SubscriptionPurchases]', N'SubscribedPurchases';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    EXEC sp_rename N'[Sales]', N'OnSale';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    EXEC sp_rename N'[SubscribedPurchases].[IX_SubscriptionPurchases_CustomerId]', N'IX_SubscribedPurchases_CustomerId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    EXEC sp_rename N'[OnSale].[Type]', N'Name', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [Manufacturers] ADD [PhoneNumber] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [OnSale] ADD [Description] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [SubscribedPurchases] ADD CONSTRAINT [PK_SubscribedPurchases] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [OnSale] ADD CONSTRAINT [PK_OnSale] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE TABLE [Receipts] (
        [Id] nvarchar(450) NOT NULL,
        [PurchaseId] nvarchar(450) NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Receipts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Receipts_Purchases_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [ProductPurchases] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Receipts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE TABLE [Reviews] (
        [Id] nvarchar(450) NOT NULL,
        [Title] nvarchar(max) NULL,
        [Content] nvarchar(max) NULL,
        [ProductId] nvarchar(450) NULL,
        CONSTRAINT [PK_Reviews] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE TABLE [ProductReviews] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] nvarchar(450) NULL,
        [ReviewId] nvarchar(450) NULL,
        CONSTRAINT [PK_ProductReviews] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductReviews_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ProductReviews_Reviews_ReviewId] FOREIGN KEY ([ReviewId]) REFERENCES [Reviews] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE INDEX [IX_ProductReviews_ProductId] ON [ProductReviews] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE INDEX [IX_ProductReviews_ReviewId] ON [ProductReviews] ([ReviewId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE INDEX [IX_Receipts_PurchaseId] ON [Receipts] ([PurchaseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE INDEX [IX_Receipts_UserId] ON [Receipts] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    CREATE INDEX [IX_Reviews_ProductId] ON [Reviews] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_OnSale_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [OnSale] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_SubscribedPurchases_SubscriptionPurchaseId] FOREIGN KEY ([SubscriptionPurchaseId]) REFERENCES [SubscribedPurchases] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    ALTER TABLE [SubscribedPurchases] ADD CONSTRAINT [FK_SubscribedPurchases_AspNetUsers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116134941_AddedReviewReceiptAndProductReviewEntities')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181116134941_AddedReviewReceiptAndProductReviewEntities', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116161454_AddedPropertiesToUser')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Addresses]') AND [c].[name] = N'ProvinceName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Addresses] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Addresses] DROP COLUMN [ProvinceName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116161454_AddedPropertiesToUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116161454_AddedPropertiesToUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181116161454_AddedPropertiesToUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181116161454_AddedPropertiesToUser', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    ALTER TABLE [Manufacturers] DROP CONSTRAINT [FK_Manufacturers_Addresses_AddressId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Categories_CategoryId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    DROP INDEX [IX_Manufacturers_AddressId] ON [Manufacturers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    ALTER TABLE [Categories] DROP CONSTRAINT [PK_Categories];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Manufacturers]') AND [c].[name] = N'AddressId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Manufacturers] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Manufacturers] DROP COLUMN [AddressId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    EXEC sp_rename N'[Categories]', N'Category';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    ALTER TABLE [Category] ADD CONSTRAINT [PK_Category] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123093748_RemovedAddressFromManufacturer')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181123093748_RemovedAddressFromManufacturer', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123102411_EditedTableNameForCategoryToBeCategies')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Category_CategoryId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123102411_EditedTableNameForCategoryToBeCategies')
BEGIN
    ALTER TABLE [Category] DROP CONSTRAINT [PK_Category];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123102411_EditedTableNameForCategoryToBeCategies')
BEGIN
    EXEC sp_rename N'[Category]', N'Categories';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123102411_EditedTableNameForCategoryToBeCategies')
BEGIN
    ALTER TABLE [Categories] ADD CONSTRAINT [PK_Categories] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123102411_EditedTableNameForCategoryToBeCategies')
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181123102411_EditedTableNameForCategoryToBeCategies')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181123102411_EditedTableNameForCategoryToBeCategies', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181204120106_AddedImageUrlPropToProductModel')
BEGIN
    ALTER TABLE [Products] ADD [ImageUrl] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181204120106_AddedImageUrlPropToProductModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181204120106_AddedImageUrlPropToProductModel', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181211085901_AddedSubCategoriesAndKeywords')
BEGIN
    CREATE TABLE [Keyword] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [ProductId] nvarchar(450) NULL,
        CONSTRAINT [PK_Keyword] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Keyword_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181211085901_AddedSubCategoriesAndKeywords')
BEGIN
    CREATE TABLE [SubCategories] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [CategoryId] nvarchar(450) NULL,
        CONSTRAINT [PK_SubCategories] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181211085901_AddedSubCategoriesAndKeywords')
BEGIN
    CREATE INDEX [IX_Keyword_ProductId] ON [Keyword] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181211085901_AddedSubCategoriesAndKeywords')
BEGIN
    CREATE INDEX [IX_SubCategories_CategoryId] ON [SubCategories] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181211085901_AddedSubCategoriesAndKeywords')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181211085901_AddedSubCategoriesAndKeywords', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181213084259_AddedKeyWordsDbSet')
BEGIN
    ALTER TABLE [Keyword] DROP CONSTRAINT [FK_Keyword_Products_ProductId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181213084259_AddedKeyWordsDbSet')
BEGIN
    ALTER TABLE [Keyword] DROP CONSTRAINT [PK_Keyword];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181213084259_AddedKeyWordsDbSet')
BEGIN
    EXEC sp_rename N'[Keyword]', N'Keywords';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181213084259_AddedKeyWordsDbSet')
BEGIN
    EXEC sp_rename N'[Keywords].[IX_Keyword_ProductId]', N'IX_Keywords_ProductId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181213084259_AddedKeyWordsDbSet')
BEGIN
    ALTER TABLE [Keywords] ADD CONSTRAINT [PK_Keywords] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181213084259_AddedKeyWordsDbSet')
BEGIN
    ALTER TABLE [Keywords] ADD CONSTRAINT [FK_Keywords_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181213084259_AddedKeyWordsDbSet')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181213084259_AddedKeyWordsDbSet', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181217104201_AddedNewPropertyForEntityProduct')
BEGIN
    DROP TABLE [SubCategories];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181217104201_AddedNewPropertyForEntityProduct')
BEGIN
    ALTER TABLE [Products] ADD [IsAvailableForAutoShipping] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181217104201_AddedNewPropertyForEntityProduct')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181217104201_AddedNewPropertyForEntityProduct', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181221091308_AddedShoppingCartItemEntity')
BEGIN
    CREATE TABLE [ShoppingCartItems] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] nvarchar(450) NULL,
        [Quantity] int NOT NULL,
        [ShoppingCartId] nvarchar(max) NULL,
        CONSTRAINT [PK_ShoppingCartItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181221091308_AddedShoppingCartItemEntity')
BEGIN
    CREATE INDEX [IX_ShoppingCartItems_ProductId] ON [ShoppingCartItems] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181221091308_AddedShoppingCartItemEntity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181221091308_AddedShoppingCartItemEntity', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [ProductPurchases] DROP CONSTRAINT [FK_ProductPurchases_AspNetUsers_CustomerId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [ProductsPurchases] DROP CONSTRAINT [FK_ProductsPurchases_ProductPurchases_PurchaseId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [Receipts] DROP CONSTRAINT [FK_Receipts_ProductPurchases_PurchaseId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [ProductPurchases] DROP CONSTRAINT [PK_ProductPurchases];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    EXEC sp_rename N'[ProductPurchases]', N'Purchases';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    EXEC sp_rename N'[Purchases].[IX_ProductPurchases_CustomerId]', N'IX_Purchases_CustomerId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [ProductsPurchases] ADD [UserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [Purchases] ADD CONSTRAINT [PK_Purchases] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    CREATE INDEX [IX_ProductsPurchases_UserId] ON [ProductsPurchases] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [ProductsPurchases] ADD CONSTRAINT [FK_ProductsPurchases_Purchases_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [Purchases] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [ProductsPurchases] ADD CONSTRAINT [FK_ProductsPurchases_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [Purchases] ADD CONSTRAINT [FK_Purchases_AspNetUsers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    ALTER TABLE [Receipts] ADD CONSTRAINT [FK_Receipts_Purchases_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [Purchases] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190103142804_AddMappingTablePurchase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190103142804_AddMappingTablePurchase', N'2.1.4-rtm-31024');
END;

GO

