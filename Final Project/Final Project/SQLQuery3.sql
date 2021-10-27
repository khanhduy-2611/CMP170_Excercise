/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [TeacherID]
      ,[firstname]
      ,[lastname]
      ,[email]
      ,[gender]
      ,[Class]
  FROM [Teacher_EFCore].[dbo].[Teachers]