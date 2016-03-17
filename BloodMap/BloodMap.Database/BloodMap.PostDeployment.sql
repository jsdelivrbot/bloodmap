/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--------------------------------[dbo].[L_Role]-------------------------------------------------------
-----------------------------------------------------------------------------------------------------


INSERT INTO [dbo].[L_Role]
           ([Title],[CreatedDate],[ModifiedDate])
SELECT		'Administrator',NULL,NULL
WHERE NOT EXISTS (SELECT 1 FROM DBO.L_Role WHERE L_RoleId=1)

INSERT INTO [dbo].[L_Role]
           ([Title],[CreatedDate],[ModifiedDate])
SELECT		'User',NULL,NULL
WHERE NOT EXISTS (SELECT 2 FROM DBO.L_Role WHERE L_RoleId=2)

--------------------------------[dbo].[L_BloodGroup]-------------------------------------------------
-----------------------------------------------------------------------------------------------------

INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'A+',NULL,NULL
WHERE NOT EXISTS (SELECT 1 FROM DBO.L_BloodGroup WHERE BloodGroupId=1)

INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'A-',NULL,NULL
WHERE NOT EXISTS (SELECT 2 FROM DBO.L_BloodGroup WHERE BloodGroupId=2)


INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'B+',NULL,NULL
WHERE NOT EXISTS (SELECT 3 FROM DBO.L_BloodGroup WHERE BloodGroupId=3)

INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'B-',NULL,NULL
WHERE NOT EXISTS (SELECT 4 FROM DBO.L_BloodGroup WHERE BloodGroupId=4)

INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'AB+',NULL,NULL
WHERE NOT EXISTS (SELECT 5 FROM DBO.L_BloodGroup WHERE BloodGroupId=5)


INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'AB-',NULL,NULL
WHERE NOT EXISTS (SELECT 6 FROM DBO.L_BloodGroup WHERE BloodGroupId=6)

INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'O+',NULL,NULL
WHERE NOT EXISTS (SELECT 7 FROM DBO.L_BloodGroup WHERE BloodGroupId=7)

INSERT INTO [dbo].[L_BloodGroup]
           ([GroupTitle],[CreatedDate],[ModifiedDate])
SELECT		'O-',NULL,NULL
WHERE NOT EXISTS (SELECT 8 FROM DBO.L_BloodGroup WHERE BloodGroupId=8)

GO


--INSERT INTO [dbo].[User]
--           ([FirstName],[LastName],[DOB],[Phone]
--           ,[IsDonor],[L_RoleId],[CreatedDate],[ModifiedDate]
--           ,[EmailId],[Password],[DonorId])
--     VALUES(
--			'Sagar','Raut','12/30/1990','9029200923',
--			1,1,NULL,NULL,
--			'sagarraut0007@gmail.com','1234',NULL
--		   )