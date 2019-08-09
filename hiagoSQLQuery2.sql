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
	@Time varchar(100),
	@Estado char(2),
	@Cores varchar(50)
)

as 

begin

    Update Times set Time = @Time,
	Estado = @Estado , Cores = @Cores
	where TimeId = @TimeId

end

	exec AtualizarTime @TimeId = 1, @Time = 'a', @Estado = 'JH',  @Cores = 'Cor'

	=================

	CREATE PROCEDURE IncluirTime
	(
		@Time varchar(100),
		@Estado char(2),
		@Cores varchar(50)
	)

	as
	 
	begin

		Insert Into Times values (@Time, @Estado, @Cores)

	end

		exec IncluirTime @Time = 'J', @Estado = 'i', @Cores = 'k'


		=================

		CREATE PROCEDURE ObterTimes

		as
		begin
			Select TimeId, Time, Estado, Cores From Times
		end
