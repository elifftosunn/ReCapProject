CREATE TABLE [dbo].[Users] (
    [Id]    INT         NOT NULL,
    [FirstName] NCHAR (50)  NULL,
    [LastName]  NCHAR (50)  NULL,
    [Email]     NCHAR (150) NULL,
    [Password]  NCHAR (150) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);