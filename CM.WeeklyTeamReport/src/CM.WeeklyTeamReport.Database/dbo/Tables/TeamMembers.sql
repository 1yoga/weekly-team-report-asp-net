CREATE TABLE [dbo].[TeamMembers] (
    [TeamMemberId] INT           IDENTITY (1, 1) NOT NULL,
    [CompanyId]    INT           NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [Email]        NVARCHAR (50) NULL,
    CONSTRAINT [PK_TeamMemberId] PRIMARY KEY CLUSTERED ([TeamMemberId] ASC),
    CONSTRAINT [Email_Validate] CHECK ([Email] like '%_@__%.__%'),
    CONSTRAINT [FK_TeamMembers_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);

