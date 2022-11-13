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

--Final select
Select 
CAST(ROW_NUMBER() over (order by TotalCoeficient desc) As Int) As Position,
UserId, 
UserName, 
ClanName, 
TotalCoeficient
from #AggregateCoeficients
order by Position
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
order by MatchDateTime
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


--Final select
Select 
(ClanName + ' - ') + Cast(Count(distinct UserId) As varchar) + ' igrača' As ClanName,
AVG(TotalCoeficient) As AvgCoeficient
from #ClanStats
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

Select 
(ClanName + ' - ') + Cast(Count(distinct UserId) As varchar) + ' igrača' As ClanName,
Cast(Count(*) As Int) As WinningBetsCount
from #LeaderBoard
group by ClanName
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
(Select Count(*) from Bets As B where B.UserId = U.Id) As TotalBetCount,
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
MatchDateTime datetime,
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
	@UserName varchar(450),
	@LogType varchar(50),
	@Message varchar(MAX)
)
AS
INSERT INTO AuditLogs
(
	UserName,
	LogType,
	Message
)
VALUES
(
	@UserName,
	@LogType,
	@Message
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
End;
GO