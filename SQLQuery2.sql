CREATE TABLE [dbo].[Customer] (
    [Id]          INT   NOT NULL,
    [UserId]      INT        NULL,
    [CompanyName] NCHAR (50) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);