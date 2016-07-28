CREATE PROCEDURE saveDetails
	@Id nvarchar,
	@EmployeeRank nvarchar,
	@FavouriteColour nvarchar
AS
BEGIN
	SELECT * FROM AspNetUsers
	UPDATE AspNetUsers SET EmployeeRank = @EmployeeRank, FavouriteColour = @FavouriteColour
	WHERE Id = @Id
END
