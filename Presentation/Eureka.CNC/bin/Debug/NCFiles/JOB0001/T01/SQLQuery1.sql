USE [DEV]
GO

/****** Object:  Table [dbo].[mfg_job_tasks]    Script Date: 10/1/2019 9:31:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mfg_job_tasks](
	[task_id] [int] IDENTITY(1,1) NOT NULL,
	[task_seq] [int] NULL,
	[job_id] [int] NOT NULL,
	[task_number] [nvarchar](25) NOT NULL,
	[task_name] [nvarchar](20) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[manager] [nvarchar](240) NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[deleted_flag] [int] NULL,
	[last_update_date] [datetime] NULL,
	[last_updated_by] [int] NULL,
	[creation_date] [datetime] NULL,
	[created_by] [int] NULL,
	[project_id] [int] NULL,
	[project_number] [nvarchar](25) NULL,
	[cost_id] [int] NULL,
	[cost_code] [nvarchar](10) NULL,
	[error_text] [nvarchar](2000) NULL,
	[source_org_id] [int] NULL,
	[source_project_id] [int] NULL,
	[source_task_id] [int] NULL,
	[source_cost_id] [int] NULL,
	[ready_flag] [int] NOT NULL,
	[mc_process_flag] [int] NOT NULL,
	[mc_pick_flag] [int] NULL,
	[mc_load_flag] [int] NULL,
	[mc_finish_flag] [int] NULL
) ON [PRIMARY]
GO


