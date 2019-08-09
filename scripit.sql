select * from Times
==============

	CREATE PROCEDURE ExcluirTimePorId
	(
	@TimeId int
	)
as 

begin 

delete From Times Where TimeId = @TimeId

end

exec ExcluirTimePorId @TimeId = 2

==================
Create Procedure AtualizarTime
( 
    @TimeId int,
	@time N=nvarchar(100),
	@Estado char(2),
	Cores nvarchar(20),
)

as 

begin

    Update Times set Time = @Time,
	Estado = @Estado , Cores = @Cores
	where TimeId = @TimeId

end