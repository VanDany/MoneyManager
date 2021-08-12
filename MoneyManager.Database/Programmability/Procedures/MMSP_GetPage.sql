CREATE PROCEDURE [dbo].[MMSP_GetPage]
@PageNumber INT,
@RowsOfPage INT,
@UserId INT
AS
BEGIN

SELECT T.Id, UserAccountId, DateTransact, T.[Description], ExpenseOrIncome, Amount, CategoryId FROM [Transaction] T 
INNER JOIN UserAccount U ON T.UserAccountId = U.Id WHERE U.UserId = @UserId
ORDER BY DateTransact DESC
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY

END
