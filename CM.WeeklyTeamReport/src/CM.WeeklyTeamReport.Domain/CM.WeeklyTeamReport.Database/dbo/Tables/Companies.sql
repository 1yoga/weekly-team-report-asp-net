CREATE TABLE [dbo].[Companies] (
    [CompanyId]   INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CompanyId] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);

