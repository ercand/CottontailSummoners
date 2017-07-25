select * from Summoner t1, Summoner t2
where (t1.ID != t2.ID and t1.IdSummoner = t2.IdSummoner)

select * from PlayerLeague t1, PlayerLeague t2
where (t1.ID != t2.ID and t1.SummonerId = t2.SummonerId)