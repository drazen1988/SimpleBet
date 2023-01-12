create procedure spGetLeaderBoard
As
Begin
Create table #LeaderBoard(
 UserId nvarchar(400),
 UserName nvarchar (400),
 ClanName nvarchar(400),
 TotalCoeficient decimal (15,2)
)

-- Insert from Bets
Insert into #LeaderBoard(
UserId,
UserName,
ClanName,
TotalCoeficient
)
Select 
B.UserId, 
A.UserName, 
C.ClanName As ClanName, 
B.BetCoeficient
from Bets As B
Inner join AspNetUsers As A
on B.UserId = A.Id
Inner join Clans As C
on C.ClanId = A.ClanId
where B.IsWinningBet = 1

-- Insert from CountryBets
Insert into #LeaderBoard(
UserId,
UserName,
ClanName,
TotalCoeficient
)
Select 
C.UserId, 
A.UserName, 
Cl.ClanName As ClanName, 
C.CountryCoeficient
from CountryBets As C
Inner join AspNetUsers As A
on C.UserId = A.Id
Inner join Clans As Cl
on Cl.ClanId = A.ClanId
where C.IsWinningBet = 1


Create table #AggregateCoeficients(
 UserId nvarchar(400),
 UserName nvarchar (400),
 ClanName nvarchar(400),
 TotalCoeficient decimal (15,2)
)

Insert into #AggregateCoeficients(
UserId,
UserName,
ClanName,
TotalCoeficient
)

Select 
UserId, 
UserName, 
ClanName, 
CAST(EXP(SUM(LOG(TotalCoeficient))) As Decimal(15,2)) As TotalCoeficient
from #LeaderBoard
group by UserId, UserName, ClanName


Create table #AllUsers(
UserId nvarchar(400),
UserName nvarchar(400),
ClanName nvarchar(400),
TotalCoeficient decimal (15,2)
)

Insert into #AllUsers(
UserId,
UserName,
ClanName
)

Select
A.Id,
A.UserName,
C.ClanName
from AspNetUsers As A
Inner join Clans As C
on A.ClanId = C.ClanId

Update #AllUsers set TotalCoeficient = (Select A.TotalCoeficient from #AggregateCoeficients As A where A.UserId = #AllUsers.UserId)
Update #AllUsers set TotalCoeficient = isnull(TotalCoeficient,1)

--Final select
Select 
CAST(ROW_NUMBER() over (order by TotalCoeficient desc, UserName) As Int) As Position,
UserId, 
UserName, 
ClanName, 
TotalCoeficient
from #AllUsers
order by Position

Drop table #LeaderBoard
Drop table #AggregateCoeficients
Drop table #AllUsers
End;
GO

Create procedure spGetMatchResults
As
Begin
Select
M.MatchId,
M.MatchDateTime,
M.HomeTeam,
M.AwayTeam,
M.Result,
(Select count(*) from Bets As B where B.IsWinningBet = 1 and B.MatchId = M.MatchId) As WinnersCount
from Matches As M
where M.Result is not null
order by MatchDateTime desc
End;
GO

Create procedure spGetClanStats
As
Begin

Create table #LeaderBoard(
 UserId nvarchar(400),
 UserName nvarchar (400),
 ClanName nvarchar(400),
 TotalCoeficient decimal (15,2)
)

-- Insert from Bets
Insert into #LeaderBoard(
UserId,
UserName,
ClanName,
TotalCoeficient
)
Select 
B.UserId, 
A.UserName, 
C.ClanName As ClanName, 
B.BetCoeficient
from Bets As B
Inner join AspNetUsers As A
on B.UserId = A.Id
Inner join Clans As C
on C.ClanId = A.ClanId
where B.IsWinningBet = 1

-- Insert from CountryBets
Insert into #LeaderBoard(
UserId,
UserName,
ClanName,
TotalCoeficient
)
Select 
C.UserId, 
A.UserName, 
Cl.ClanName As ClanName, 
C.CountryCoeficient
from CountryBets As C
Inner join AspNetUsers As A
on C.UserId = A.Id
Inner join Clans As Cl
on Cl.ClanId = A.ClanId
where C.IsWinningBet = 1

Create table #ClanStats(
UserId nvarchar(400),
ClanName nvarchar(400),
TotalCoeficient decimal (15,2)
)

Insert into #ClanStats(
UserId,
ClanName,
TotalCoeficient
)

Select 
UserId,
ClanName, 
CAST(EXP(SUM(LOG(TotalCoeficient))) As Decimal(15,2)) As TotalCoeficient 
from #LeaderBoard
group by UserId, ClanName



Create table #AllUsers(
UserId nvarchar(400),
ClanName nvarchar(400),
TotalCoeficient decimal (15,2)
)

Insert into #AllUsers(
UserId,
ClanName
)

Select
A.Id,
C.ClanName
from AspNetUsers As A
Inner join Clans As C
on A.ClanId = C.ClanId

Update #AllUsers set TotalCoeficient = (Select C.TotalCoeficient from #ClanStats As C where C.UserId = #AllUsers.UserId)
Update #AllUsers set TotalCoeficient = isnull(TotalCoeficient,1)

--Final select
Select 
(ClanName + ' - ') + Cast(Count(distinct UserId) As varchar) + ' igrača' As ClanName,
AVG(TotalCoeficient) As AvgCoeficient
from #AllUsers
group by ClanName
order by AvgCoeficient desc

End;
GO

Create procedure spGetClanStatsAbs
As
Begin

Create table #LeaderBoard(
 UserId nvarchar(400),
 UserName nvarchar (400),
 ClanId int,
 ClanName nvarchar(400),
 TotalCoeficient decimal (15,2)
)

-- Insert from Bets
Insert into #LeaderBoard(
UserId,
UserName,
ClanId,
ClanName,
TotalCoeficient
)
Select 
B.UserId, 
A.UserName, 
C.ClanId,
C.ClanName As ClanName, 
B.BetCoeficient
from Bets As B
Inner join AspNetUsers As A
on B.UserId = A.Id
Inner join Clans As C
on C.ClanId = A.ClanId
where B.IsWinningBet = 1

-- Insert from CountryBets
Insert into #LeaderBoard(
UserId,
UserName,
ClanId,
ClanName,
TotalCoeficient
)
Select 
C.UserId, 
A.UserName, 
Cl.ClanId,
Cl.ClanName As ClanName, 
C.CountryCoeficient
from CountryBets As C
Inner join AspNetUsers As A
on C.UserId = A.Id
Inner join Clans As Cl
on Cl.ClanId = A.ClanId
where C.IsWinningBet = 1


Select 
(ClanName + ' - ') + Cast((Select count(A.ClanId) from AspNetUsers As A where A.ClanId = #LeaderBoard.ClanId) As varchar) + ' igrača' As ClanName,
Cast(Count(*) As Int) As WinningBetsCount,
Cast(Cast(Count(*) As decimal) / Cast((Select count(A.ClanId) from AspNetUsers As A where A.ClanId = #LeaderBoard.ClanId) As decimal) As decimal(15,2)) As WinningBetsAvg
from #LeaderBoard
group by ClanName, ClanId
order by WinningBetsAvg desc
End;
GO

Create procedure spGetUserByClan
As
Begin
Select 
C.ClanName As ClanName,
Cast(Count(*) As Int) As UsersCount,
ClanName + ': ' + Cast(Count(*) as nvarchar) As Label
from AspNetUsers As A
Inner join Clans As C
on C.ClanId = A.ClanId
group by ClanName
End;
GO

Create procedure spGetUsersPerClan
As
Begin
Select 
C.ClanId,
C.ClanName,
Count(A.Id) As UsersPerClan
from AspNetUsers As A
Right join Clans As C
on A.ClanId = C.ClanId
group by C.ClanId, C.ClanName
order by C.ClanName
End;
GO

Create procedure spGetMyStats
@UserId varchar(200)
As
Begin
Select
U.Id As UserId,
U.UserName,
C.ClanName,
(Select Count(*) from Bets As B inner join Matches As M on B.MatchId = M.MatchId where B.UserId = U.Id and M.MatchDateTime < GETDATE()) As TotalBetCount,
(Select Count(*) from Bets As B where B.UserId = U.Id and B.IsWinningBet = 1) As WinningBetCount,
(Select top 1 BetCoeficient from Bets As B where B.UserId = U.Id and B.IsWinningBet = 1 order by B.BetCoeficient desc) As BestWinningCoeficient
from AspNetUsers As U
Inner join Clans As C
On U.ClanId = C.ClanId
where U.Id = @UserId
End;
GO

Create procedure spGetWinsPerDay
As
Begin
Create table #WinsPerDay(
MatchDateTime date,
WinnersCount int
)

Insert into #WinsPerDay
(
MatchDateTime,
WinnersCount
)
Select
M.MatchDateTime,
(Select count(*) from Bets As B where B.IsWinningBet = 1 and B.MatchId = M.MatchId) As WinnersCount
from Matches As M

Select 
MatchDateTime,
sum(WinnersCount) As WinnersCount
from #WinsPerDay
group by MatchDateTime
order by MatchDateTime

drop table #WinsPerDay
End;
GO

CREATE PROCEDURE spInsertErrorLog
(
	@level varchar(20),
	@callsite varchar(MAX),
	@type varchar(MAX),
	@message varchar(MAX),
	@stackTrace varchar(MAX),
	@innerException varchar(MAX),
	@aditionalInfo varchar(MAX)
)
AS
INSERT INTO ErrorLogs
(
	[Level],
	CallSite,
	[Type],
	[Message],
	StackTrace,
	InnerException,
	AdditionalInfo
)
VALUES
(
	@level,
	@callsite,
	@type,
	@message,
	@stackTrace,
	@innerException,
	@aditionalInfo
)
GO

CREATE PROCEDURE spInsertAuditLog
(
	@UserId varchar(450),
	@LogType varchar(50),
	@Message varchar(MAX),
	@DeviceType varchar(50)
)
AS
INSERT INTO AuditLogs
(
	UserId,
	LogType,
	Message,
	DeviceType
)
VALUES
(
	@UserId,
	@LogType,
	@Message,
	@DeviceType
)
GO

Create procedure spGetMyBetList
@UserId varchar(250)
As
Begin
Select 
B.MatchId, 
M.HomeTeam,
M.AwayTeam,
M.Result,
Case when B.BetType = 1 then '1' when B.BetType = 2 then '2' when B.BetType = 3 then 'X' end As BetType, 
B.BetCoeficient, 
B.IsWinningBet,
M.MatchDateTime
from Bets As B
Inner join Matches As M
On B.MatchId = M.MatchId
where B.UserId = @UserId
order by M.MatchDateTime desc
End;
GO

Create procedure spGetUnActiveUsers
As
Begin
Select 
A.Id, 
A.FirstName, 
A.LastName, 
A.UserName, 
A.Email, 
C.ClanName, 
A.LoginNotificationDate,
Case when Exists (Select Users.Id from AspNetUsers As Users
where Users.Id in (Select L.UserId from AuditLogs As L) and Users.Id = A.Id) then 'Da' else 'Ne' end As HasLoggedIn
from AspNetUsers As A
Inner join Clans As C
On A.ClanId = C.ClanId
where A.Id not in (Select B.UserId from Bets As B)
order by C.ClanName
End;
GO

create procedure spGetLeaderBoardById
@UserId varchar(200)
As
Begin
Create table #LeaderBoard(
 UserId nvarchar(400),
 UserName nvarchar (400),
 ClanName nvarchar(400),
 TotalCoeficient decimal (15,2)
)

-- Insert from Bets
Insert into #LeaderBoard(
UserId,
UserName,
ClanName,
TotalCoeficient
)
Select 
B.UserId, 
A.UserName, 
C.ClanName As ClanName, 
B.BetCoeficient
from Bets As B
Inner join AspNetUsers As A
on B.UserId = A.Id
Inner join Clans As C
on C.ClanId = A.ClanId
where B.IsWinningBet = 1

-- Insert from CountryBets
Insert into #LeaderBoard(
UserId,
UserName,
ClanName,
TotalCoeficient
)
Select 
C.UserId, 
A.UserName, 
Cl.ClanName As ClanName, 
C.CountryCoeficient
from CountryBets As C
Inner join AspNetUsers As A
on C.UserId = A.Id
Inner join Clans As Cl
on Cl.ClanId = A.ClanId
where C.IsWinningBet = 1


Create table #AggregateCoeficients(
 UserId nvarchar(400),
 UserName nvarchar (400),
 ClanName nvarchar(400),
 TotalCoeficient decimal (15,2)
)

Insert into #AggregateCoeficients(
UserId,
UserName,
ClanName,
TotalCoeficient
)

Select 
UserId, 
UserName, 
ClanName, 
CAST(EXP(SUM(LOG(TotalCoeficient))) As Decimal(15,2)) As TotalCoeficient
from #LeaderBoard
group by UserId, UserName, ClanName


Create table #FinalRanking(
 Position int,
 UserId nvarchar(400),
 UserName nvarchar (400),
 ClanName nvarchar(400),
 TotalCoeficient decimal (15,2)
)

Insert into #FinalRanking(
Position,
UserId,
UserName,
ClanName,
TotalCoeficient)

Select 
CAST(ROW_NUMBER() over (order by TotalCoeficient desc, UserName) As Int) As Position,
UserId, 
UserName, 
ClanName, 
TotalCoeficient
from #AggregateCoeficients
order by Position

Select  
F.Position As [Value]
from #FinalRanking As F
where F.UserId = @UserId

End;
GO

Create procedure spApplicationUsage
As
Begin

Create table #ApplicationUsage(
DeviceType nvarchar(50),
NumberOfLogins int,
TotalLogins int,
DeviceRatio decimal(5,2)
)

Insert into #ApplicationUsage(
DeviceType,
NumberOfLogins,
TotalLogins
)

Select 
A.DeviceType,
(Select Count(*) from AuditLogs As AL where LogType = 'Sign in' and DeviceType is not null and A.DeviceType = Al.DeviceType) As NumberOfLogins,
(Select Count(*) from AuditLogs where LogType = 'Sign in' and DeviceType is not null) As TotalLogins
from AuditLogs As A
where A.LogType = 'Sign in' and A.DeviceType is not null
group by A.DeviceType

Update #ApplicationUsage set DeviceRatio = Cast(NumberOfLogins As Decimal) / Cast(TotalLogins As Decimal)

Select 
DeviceType,
NumberOfLogins,
TotalLogins,
DeviceRatio
from #ApplicationUsage
order by DeviceType


Drop table #ApplicationUsage
End;
GO

Create procedure spGetAllWinningBetsByUser
@UserId nvarchar(400)
As
Begin
Select
(M.HomeTeam + ' - ' + M.AwayTeam + ' (' + M.Result + ')') As WinningMatch,
(B.BetCoeficient) As WinningCoeficient
from Matches As M
Inner join Bets As B
On M.MatchId = B.MatchId
where B.IsWinningBet = 1 and B.UserId = @UserId
order by M.MatchDateTime
End;
GO