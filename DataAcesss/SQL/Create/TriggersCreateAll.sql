create trigger tr_Bets_Insert
on Bets
for insert
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Insert', 'Bets', '', '', '', I.UserId, I.BetId
from inserted As I
end;
GO

create trigger tr_Bets_Delete
on Bets
for delete
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Delete', 'Bets', '', '', '', D.UserId, D.BetId
from deleted As D
end;
GO

create trigger tr_Bets_Update
on Bets
for update
as
begin

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Bets', 'BetType', D.BetType, I.BetType, I.UserId, D.BetId
from inserted As I
Inner join deleted As D
On I.BetId = D.BetId
where I.BetType <> D.BetType

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Bets', 'BetCoeficient', D.BetCoeficient, I.BetCoeficient, I.UserId, D.BetId
from inserted As I
Inner join deleted As D
On I.BetId = D.BetId
where I.BetCoeficient <> D.BetCoeficient

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Bets', 'IsWinningBet', D.IsWinningBet, I.IsWinningBet, I.UserId, D.BetId
from inserted As I
Inner join deleted As D
On I.BetId = D.BetId
where I.IsWinningBet <> D.IsWinningBet
end;
GO

create trigger tr_Countries_Insert
on Countries
for insert
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Insert', 'Countries', '', '', '', I.UserId, I.CountryId
from inserted As I
end;
GO

create trigger tr_Countries_Delete
on Countries
for delete
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Delete', 'Countries', '', '', '', D.UserId, D.CountryId
from deleted As D
end;
GO

create trigger tr_Countries_Update
on Countries
for update
as
begin

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Countries', 'CountryName', D.CountryName, I.CountryName, I.UserId, D.CountryId
from inserted As I
Inner join deleted As D
On I.CountryId = D.CountryId
where I.CountryName <> D.CountryName

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Countries', 'CountryCoeficient', D.CountryCoeficient, I.CountryCoeficient, I.UserId, D.CountryId
from inserted As I
Inner join deleted As D
On I.CountryId = D.CountryId
where I.CountryCoeficient <> D.CountryCoeficient

end;
GO

create trigger tr_CountryBets_Insert
on CountryBets
for insert
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Insert', 'CountryBets', '', '', '', I.UserId, I.CountryBetId
from inserted As I
end;
GO

create trigger tr_CountryBets_Delete
on CountryBets
for delete
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Delete', 'CountryBets', '', '', '', D.UserId, D.CountryBetId
from deleted As D
end;
GO

create trigger tr_CountryBets_Update
on CountryBets
for update
as
begin

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'CountryBets', 'CountryId', D.CountryId, I.CountryId, I.UserId, D.CountryBetId
from inserted As I
Inner join deleted As D
On I.CountryBetId = D.CountryBetId
where I.CountryId <> D.CountryId

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'CountryBets', 'CountryCoeficient', D.CountryCoeficient, I.CountryCoeficient, I.UserId, D.CountryBetId
from inserted As I
Inner join deleted As D
On I.CountryBetId = D.CountryBetId
where I.CountryCoeficient <> D.CountryCoeficient

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'CountryBets', 'IsWinningBet', D.IsWinningBet, I.IsWinningBet, I.UserId, D.CountryBetId
from inserted As I
Inner join deleted As D
On I.CountryBetId = D.CountryBetId
where I.IsWinningBet <> D.IsWinningBet

end;
GO

create trigger tr_Matches_Insert
on Matches
for insert
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Insert', 'Matches', '', '', '', I.UserId, I.MatchId
from inserted As I
end;
GO

create trigger tr_Matches_Delete
on Matches
for delete
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Delete', 'Matches', '', '', '', D.UserId, D.MatchId
from deleted As D
end;
GO

create trigger tr_Matches_Update
on Matches
for update
as
begin

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Matches', 'HomeTeam', D.HomeTeam, I.HomeTeam, I.UserId, D.MatchId
from inserted As I
Inner join deleted As D
On I.MatchId = D.MatchId
where I.HomeTeam <> D.HomeTeam

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Matches', 'AwayTeam', D.AwayTeam, I.AwayTeam, I.UserId, D.MatchId
from inserted As I
Inner join deleted As D
On I.MatchId = D.MatchId
where I.AwayTeam <> D.AwayTeam

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Matches', 'MatchDateTime', D.MatchDateTime, I.MatchDateTime, I.UserId, D.MatchId
from inserted As I
Inner join deleted As D
On I.MatchId = D.MatchId
where I.MatchDateTime <> D.MatchDateTime

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Matches', 'HomeCoeficient', D.HomeCoeficient, I.HomeCoeficient, I.UserId, D.MatchId
from inserted As I
Inner join deleted As D
On I.MatchId = D.MatchId
where I.HomeCoeficient <> D.HomeCoeficient

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Matches', 'DrawCoeficient', D.DrawCoeficient, I.DrawCoeficient, I.UserId, D.MatchId
from inserted As I
Inner join deleted As D
On I.MatchId = D.MatchId
where I.DrawCoeficient <> D.DrawCoeficient

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Matches', 'AwayCoeficient', D.AwayCoeficient, I.AwayCoeficient, I.UserId, D.MatchId
from inserted As I
Inner join deleted As D
On I.MatchId = D.MatchId
where I.AwayCoeficient <> D.AwayCoeficient

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Matches', 'Result', D.Result, I.Result, I.UserId, D.MatchId
from inserted As I
Inner join deleted As D
On I.MatchId = D.MatchId
where I.Result <> D.Result

end;
GO

create trigger tr_Clans_Insert
on Clans
for insert
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Insert', 'Clans', '', '', '', I.UserId, I.ClanId
from inserted As I
end;
GO

create trigger tr_Clans_Delete
on Clans
for delete
as
begin
Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId)
Select 'Delete', 'Clans', '', '', '', D.UserId, D.ClanId
from deleted As D
end;
GO

create trigger tr_Clans_Update
on Clans
for update
as
begin

Insert into EventLogs (EventType, TableName, TableField, OldValue, NewValue, UserId, RowId) 
Select 'Update', 'Clans', 'ClanName', D.ClanName, I.ClanName, I.UserId, D.ClanId
from inserted As I
Inner join deleted As D
On I.ClanId = D.ClanId
where I.ClanName <> D.ClanName

end;
GO