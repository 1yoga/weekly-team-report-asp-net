CREATE TABLE [dbo].[WeeklyReports] (
    [WeeklyReportId]  INT            IDENTITY (1, 1) NOT NULL,
    [TeamMemberId]    INT            NOT NULL,
    [MoraleLevel]     INT            NOT NULL,
    [MoraleComment]   NVARCHAR (300) NOT NULL,
    [StressLevel]     INT            NOT NULL,
    [StressComment]   NVARCHAR (300) NOT NULL,
    [WorkloadLevel]   INT            NOT NULL,
    [WorkloadComment] NVARCHAR (300) NOT NULL,
    [WeeklyHigh]      NVARCHAR (300) NOT NULL,
    [WeeklyLow]       NVARCHAR (300) NOT NULL,
    [AnythingElse]    NVARCHAR (300) NOT NULL,
    [DateFrom]        DATE           NOT NULL,
    [DateTo]          DATE           NOT NULL,
    CONSTRAINT [PK_WeeklyReportId] PRIMARY KEY CLUSTERED ([WeeklyReportId] ASC),
    CONSTRAINT [MoraleLevel_Validate] CHECK ([MoraleLevel] like '[12345]'),
    CONSTRAINT [StressLevel_Validate] CHECK ([StressLevel] like '[12345]'),
    CONSTRAINT [WorkloadLevel_Validate] CHECK ([WorkloadLevel] like '[12345]'),
    CONSTRAINT [FK_WeeklyReports_TeamMembers] FOREIGN KEY ([TeamMemberId]) REFERENCES [dbo].[TeamMembers] ([TeamMemberId])
);

