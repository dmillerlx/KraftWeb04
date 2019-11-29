IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129044639_First')
BEGIN
    CREATE TABLE [TodoItem] (
        [Id] bigint NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [IsComplete] bit NOT NULL,
        CONSTRAINT [PK_TodoItem] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129044639_First')
BEGIN
    CREATE TABLE [Transactions] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [StockSymbol] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [TransactionType] nvarchar(1) NOT NULL,
        [Quantity] int NOT NULL,
        [DateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129044639_First')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191129044639_First', N'3.0.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129044812_Second')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191129044812_Second', N'3.0.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129045632_third')
BEGIN
    DROP TABLE [TodoItem];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129045632_third')
BEGIN
    CREATE TABLE [DailyGainsLosses] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [StockSymbol] nvarchar(max) NULL,
        [TotalPaid] decimal(18,2) NOT NULL,
        [TotalValue] decimal(18,2) NOT NULL,
        [DateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_DailyGainsLosses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129045632_third')
BEGIN
    CREATE TABLE [Holdings] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [StockSymbol] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_Holdings] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129045632_third')
BEGIN
    CREATE TABLE [Notifications] (
        [Id] int NOT NULL IDENTITY,
        [UserID] int NOT NULL,
        [NotificationType] nvarchar(1) NOT NULL,
        [Message] nvarchar(max) NULL,
        [DateTime] datetime2 NOT NULL,
        [Delivered] bit NOT NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129045632_third')
BEGIN
    CREATE TABLE [StockPrice] (
        [Id] int NOT NULL IDENTITY,
        [StockSymbol] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [DateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_StockPrice] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129045632_third')
BEGIN
    CREATE TABLE [StockWatch] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [StockSymbol] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [Days] int NOT NULL,
        [NotificationType] nvarchar(1) NOT NULL,
        [StartDate] datetime2 NOT NULL,
        CONSTRAINT [PK_StockWatch] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191129045632_third')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191129045632_third', N'3.0.1');
END;

GO

