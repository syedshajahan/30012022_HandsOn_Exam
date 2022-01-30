
CREATE PROCEDURE uspAddReview
(@book_isbn INT, @rating INT, @review VARCHAR(200))
AS 
BEGIN
	BEGIN TRY
	
		IF @book_isbn IS NOT NULL and @rating IS NOT NULL and @review IS NOT NULL
		BEGIN
		INSERT INTO Reviews VALUES(@book_isbn,@rating,@review)
		RETURN 1
		END
		ELSE
		RETURN -2
	END TRY
	BEGIN CATCH
		RETURN -99
    END CATCH
END




DECLARE @return int 
EXEC @return=dbo.uspAddReview @book_isbn =55201,@rating = 0,@review='Best book i have ever read';
SELECT @return


Select * from Reviews;


CREATE PROCEDURE uspAddBooks
(@book_ISBN VARCHAR(20), @title VARCHAR(100), @edition INT,@author VARCHAR(50))
AS 
BEGIN
	BEGIN TRY
	DECLARE @authorname VARCHAR(50);
	DECLARE @author_id INT;
		IF @title IS NOT NULL and @book_ISBN IS NOT NULL and @edition IS NOT NULL and @author IS NOT NULL
		BEGIN
			select @authorname = author_name from Authors where author_name LIKE '%'+@author+'%'
			IF @authorname IS NOT NULL
				BEGIN
					SELECT @author_id=author_id from Authors where author_name = @authorname
					INSERT INTO Books VALUES(@book_ISBN,@title,@edition,@author_id)
				END
			ELSE
				BEGIN
					INSERT INTO Authors VALUES(@author)
					SELECT @author_id = IDENT_CURRENT('Authors')
					INSERT INTO Books VALUES(@book_ISBN,@title,@edition,@author_id)
				END
			RETURN 1
		 END
		ELSE
			RETURN -1
	END TRY
	BEGIN CATCH
		RETURN -99
    END CATCH
END


DECLARE @return int 
EXEC @return=dbo.uspAddBooks @book_ISBN=8882,@title='Test book',@edition=2,@author='YYYY';
SELECT @return

Select * from Books;
Select * from Authors;
