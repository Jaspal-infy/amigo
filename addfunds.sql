USE [DEC20USBATCH1MSAGROUP1DB]
GO

INSERT INTO [dbo].[UserTransaction]
           ([EmailId]
           ,[Amount]
           ,[TransactionDateTime]
           ,[PaymentTypeId]
           ,[Remarks]
           ,[Info]
           ,[StatusId]
           ,[PointsEarned]
           ,[IsRedeemed])
     VALUES
           ('gyarnley6@uiuc.edu',
           50,
           GETDATE(),
           3,
           'test',
           'test added money',
           1,
           1,
           0),
		   ('gyarnley6@uiuc.edu',
           40,
           GETDATE(),
           3,
           'test',
           'test added money',
           1,
           1,
           0),
                 ('gyarnley6@uiuc.edu',
           10,
           GETDATE(),
           5,
           'test',
           'test removed money',
           1,
           0,
           0),
             ('gyarnley6@uiuc.edu',
           15,
           GETDATE(),
           5,
           'test',
           'test removed money',
           1,
           0,
           0)
GO