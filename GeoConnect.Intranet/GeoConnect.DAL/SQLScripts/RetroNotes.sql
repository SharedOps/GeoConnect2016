
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'sp_insert_tbl_Teams')AND type in (N'P', N'PC'))
DROP PROCEDURE sp_insert_tbl_Teams
GO

 CREATE PROCEDURE sp_insert_tbl_Teams
@out_error_number INT = 0 OUTPUT,
@p_Team varchar(50)  
AS
BEGIN
BEGIN TRY
	Insert into tbl_Teams (Team)
	values(@p_Team)
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'sp_update_tbl_Teams')AND type in (N'P', N'PC'))
DROP PROCEDURE sp_update_tbl_Teams
GO

 CREATE PROCEDURE sp_update_tbl_Teams
@out_error_number INT = 0 OUTPUT,
@p_Team varchar(50) ,
@w_Id int,
@w_Team varchar(50) 
AS
BEGIN
BEGIN TRY
	UPDATE [dbo].tbl_Teams SET Team=@p_Team 
	WHERE Id=@w_Id AND Team=@w_Team
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
GO
