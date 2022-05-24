CREATE TABLE [dbo].[ApplicationUser] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [FirstName]            NVARCHAR (MAX)     NULL,
    [Lastname]             NVARCHAR (MAX)     NULL,
    [UserName]             NVARCHAR (MAX)     NULL,
    [NormalizedUserName]   NVARCHAR (MAX)     NULL,
    [Email]                NVARCHAR (MAX)     NULL,
    [NormalizedEmail]      NVARCHAR (MAX)     NULL,
    [EmailConfirmed]       BIT                NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NULL,
    [TwoFactorEnabled]     BIT                NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NULL,
    [AccessFailedCount]    INT                NULL,
    CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

