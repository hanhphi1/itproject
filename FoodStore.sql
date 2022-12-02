create database FoodStore
go
use  FoodStore
go
-- tablefood -- Bảng thức ăn
-- table -- Bàn ăn
-- FoodCatagory -- Danh sách thực phẩm
-- Account -- Tài khoản
-- Bill -- Hóa đơn
-- Bill infor -- Hóa đơn từng cái
create table Tablefood -- Bàn ăn
(
	ID int identity primary key,
	Name Nvarchar(100) not null default N'Chưa đặt tên',
	Status Nvarchar(100) not null default N'Trống'
)
go
Create table Account
(
	UserName nvarchar(100) primary key,
	DisplayName nvarchar(100) not null,
	PassWord Nvarchar(1000) not null,
	TypeofAccount int not null default 0,
)
go
Create table FoodCategory
(
	ID int identity primary key,
	Name nvarchar(100) not null default N'Chưa đặt tên'
	CONSTRAINT unique_categoryname UNIQUE (Name)
)
go
Create table food -- Thức ăn
(
	ID int identity primary key,
	Name nvarchar(100) not null default N'Chưa đặt tên',
	IDCategory int not null,
	price float not null default 0

	Foreign Key (IDCategory) references FoodCategory(id)
	CONSTRAINT unique_foodname UNIQUE (Name)
	CONSTRAINT check_price CHECK (price >= 0)
)

--ALTER TABLE food
--ADD CONSTRAINT check_price CHECK (price >= 0);

go
Create table Bill
(
	ID int identity primary key,
	DateCheckIn Date not null default GetDate(),
	DateCheckOut Date,
	idTable int not null,
	Staff Nvarchar(100) not null,
	discount int not null default 0,
	status int not null default 0 -- 1: tính tiền rồi , 0: chưa

	Foreign Key (idtable) references Tablefood(id)
)
Go
Create table BillInfor
(
	ID int identity primary key,
	idbill int not null,
	idfood int not null,
	count int not null default 0

	Foreign key (idbill) references Bill(id),
	Foreign key (idfood) references Food(id)
)

GO
Create table ChiPhi
(
	ID int identity primary key,
	MonthChiPhi Date not null unique default GetDate(),
	Price float not null default 0
)
go

Insert into Account (UserName,DisplayName,PassWord,TypeofAccount) 
values (N'admin',N'Nguyễn Trung Nguyên',N'admin',1)
Insert into Account (UserName,DisplayName,PassWord,TypeofAccount) 
values (N'nhanvien1',N'Nguyễn Văn A',N'nhanvien1',0)
Insert into Account (UserName,DisplayName,PassWord,TypeofAccount) 
values (N'nhanvien2',N'Trần Thị B',N'nhanvien2',0)
--select * from account


go
--select * from tablefood
go
Declare @i int = 1
while @i<=20
begin
	insert into tablefood(name) values (N'Bàn '+ cast(@i as nvarchar(50)))
	set @i = @i+1
end
go
--Select * from tablefood
--Delete tablefood where ID > 2
--update tablefood set status = N'Trống' where id = 10

--DBCC CHECKIDENT(tablefood, RESEED, 0)

--Select * from Billinfor
--Select * from Bill
--Select * from Tablefood
--Select * from Food
--Select * From FoodCategory
--Update tablefood set status = N'Có người' where id = 2
Go
--Chủ đề:
Insert into FoodCategory(name) values (N'Khai vị')
Insert into FoodCategory(name) values (N'Đồ nướng')
Insert into FoodCategory(name) values (N'Lẩu')
Insert into FoodCategory(name) values (N'Cơm chiên')
Insert into FoodCategory(name) values (N'Thức uống')
go

--SET IDENTITY_INSERT food ON;
--Insert into food (ID,Name,IDCategory,price)
--values (1,N'Cà phê đen',1,20000)
--Insert into food (ID,Name,IDCategory,price)
--values (2,N'Cà phê sữa',2,25000)
--SET IDENTITY_INSERT food off;


-- Món ăn:
------Hải sản:
go
Insert into Food(name,idCategory,price) values (N'Rau trộn',1,10000)
Insert into Food(name,idCategory,price) values (N'Kim chi cải thảo',1,10000)
Insert into Food(name,idCategory,price) values (N'Khoai tây chiên',1,25000)
Insert into Food(name,idCategory,price) values (N'Bắp xào',1,25000)
Insert into Food(name,idCategory,price) values (N'Kimbap',1,35000)
Insert into Food(name,idCategory,price) values (N'Chân gà ngâm xả tắc',1,35000)
------Đồ nướng:
Insert into Food(name,idCategory,price) values (N'Thịt cừu nướng',2,119000)
Insert into Food(name,idCategory,price) values (N'Bò Mỹ nướng',2,129000)
Insert into Food(name,idCategory,price) values (N'Ba chỉ nướng',2,89000)
Insert into Food(name,idCategory,price) values (N'Sườn heo nướng',2,89000)
Insert into Food(name,idCategory,price) values (N'Mực + bạch tuột muối ớt',2,79000)
Insert into Food(name,idCategory,price) values (N'Tôm sú',2,79000)
Insert into Food(name,idCategory,price) values (N'Ngao nướng mỡ hành',2,59000)
------Lẩu:
Insert into Food(name,idCategory,price) values (N'Lẩu riêu cua bò',3,15900)
Insert into Food(name,idCategory,price) values (N'Lẩu kimchi bò',3,159000)
Insert into Food(name,idCategory,price) values (N'Lẩu gà lá giang',3,159000)
Insert into Food(name,idCategory,price) values (N'Lẩu ếch măng cay',3,1590000)
Insert into Food(name,idCategory,price) values (N'Lẩu Thái hải sản',3,200000)
------Cơm chiên:
Insert into Food(name,idCategory,price) values (N'Cơm chiên muối ớt xanh',4,59000)
Insert into Food(name,idCategory,price) values (N'Cơm chiên bò',4,89000)
Insert into Food(name,idCategory,price) values (N'Cơm chiên hải sản',4,89000)
Insert into Food(name,idCategory,price) values (N'Cơm chiên dương châu',4,59000)
Insert into Food(name,idCategory,price) values (N'Cơm chiên trứng',4,59000)
------Thức uống:
Insert into Food(name,idCategory,price) values (N'Bia tươi Czech',5,19000)
Insert into Food(name,idCategory,price) values (N'Rượu Soju',5,89000)
Insert into Food(name,idCategory,price) values (N'Tiger bạc',5,28000)
Insert into Food(name,idCategory,price) values (N'Vodka',5,245000)
Insert into Food(name,idCategory,price) values (N'Nước hoa quả',5,40000)
--thêm Bill:
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,1,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),Getdate(),4,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,5,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),Getdate(),6,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,7,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),Getdate(),9,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,10,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),Getdate(),11,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,15,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,16,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,17,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),Getdate(),18,0)
--Insert into Bill(Datecheckin,datecheckout,idtable,status) values (Getdate(),null,19,0)
--go
--delete bill
--DBCC CHECKIDENT(Bill, RESEED, 0)


--thêm BillInfor:
--Insert into BillInfor(idbill,idfood,count) values (1,1,1)
--Insert into BillInfor(idbill,idfood,count) values (2,3,7)
--Insert into BillInfor(idbill,idfood,count) values (3,4,4)
--Insert into BillInfor(idbill,idfood,count) values (4,1,2)
--Insert into BillInfor(idbill,idfood,count) values (5,1,1)
--Insert into BillInfor(idbill,idfood,count) values (9,1,1)
--Insert into BillInfor(idbill,idfood,count) values (6,9,2)
--Insert into BillInfor(idbill,idfood,count) values (7,4,1)
--Insert into BillInfor(idbill,idfood,count) values (8,3,5)
--Insert into BillInfor(idbill,idfood,count) values (10,15,2)
--Insert into BillInfor(idbill,idfood,count) values (11,14,1)
--Insert into BillInfor(idbill,idfood,count) values (12,16,2)
--Insert into BillInfor(idbill,idfood,count) values (12,13,2)
--Insert into BillInfor(idbill,idfood,count) values (1,17,2)
--Insert into BillInfor(idbill,idfood,count) values (2,13,1)
--Insert into BillInfor(idbill,idfood,count) values (3,24,5)
--Insert into BillInfor(idbill,idfood,count) values (4,8,2)
--Insert into BillInfor(idbill,idfood,count) values (5,11,1)
--Insert into BillInfor(idbill,idfood,count) values (9,14,1)
--Insert into BillInfor(idbill,idfood,count) values (6,21,2)
--Insert into BillInfor(idbill,idfood,count) values (7,22,1)
--Insert into BillInfor(idbill,idfood,count) values (8,16,5)
--Insert into BillInfor(idbill,idfood,count) values (10,19,2)
--Insert into BillInfor(idbill,idfood,count) values (11,20,1)
--Insert into BillInfor(idbill,idfood,count) values (12,10,2)
--Insert into BillInfor(idbill,idfood,count) values (9,15,2)
Go
--Delete Bill where id>=1
--Delete BillInfor where id>=1
--Delete Food where id>=1
--Delete FoodCategory where id>=1
--DBCC CHECKIDENT(Bill, RESEED, 0)
--DBCC CHECKIDENT(BillInfor, RESEED, 0)
--DBCC CHECKIDENT(Food, RESEED, 0)
--DBCC CHECKIDENT(FoodCategory, RESEED, 0)


--Select f.name, bi.count,f.price,f.price*bi.count as TotalPrice from Billinfor as bi,bill as b,food as f
--where bi.idbill = b.id and bi.idfood = f.id and b.idtable = 5
go

--Add TotalPrice
go
alter table Bill Add TotalPrice float default 0
go
ALTER TABLE Bill
ADD CONSTRAINT check_Totalprice CHECK (TotalPrice >= 0);
go
update Bill set TotalPrice = 0
go
--Select * from Bill
update Bill set Discount = 0
go


--Stored Proceture
Create Proc USP_Bill
@idtable int
as
begin
	Insert into Bill(Datecheckin,datecheckout,idtable,status,discount) 
	values (Getdate(),null,@idtable,0,0)
end
go

create Proc USP_InsertBill
@idtable int, @staff nvarchar(100)
as
begin
	Insert into Bill(Datecheckin,datecheckout,idtable,Staff,status, discount) 
	values (Getdate(),null, @idtable , @staff, 0, 0)
end
go

go
--Create Proc USP_InsertBillInfo
--@idbill int , @idfood int , @count int
--as
--begin
--	Insert BillInfor(idbill,idfood,count) 
--	values (@idbill,@idfood,@count)
--end
--go
go
Create Proc USP_InsertBillInfo
@idbill int , @idfood int , @count int
as
begin
	Declare @CheckBill int
	Declare @CurrentFood int = 1
	Select @CheckBill = id,@Currentfood = count 
	from BillInfor 
	where idbill = @idbill and idfood = @idfood
	if(@checkBill > 0) -- Thức ăn đã có trong bill.Chúng ta sẽ cập nhật nó.
	Begin
		Declare @newCount int = @currentfood + @count
		if(@newCount >0 )
			Update BillInfor Set count = @currentfood + @count where idfood = @idfood
		else
			delete BillInfor where idbill = @idbill and idfood = @idfood
	end
	else -- Thức ăn chưa có trong bill. Chúng ta sẽ thêm thức ăn
	Begin
		if(@count>0)
		begin
		Insert BillInfor(idbill,idfood,count) 
		values (@idbill,@idfood,@count)
		end
		else
		return
	end
	
end
go

--go
--alter Proc USP_GetListBillByDate
--@DateCheckIn date, @DateCheckOut date
--as
--begin
--	Select t.name as N'Bàn ăn', b.DateCheckIn as N'Thời gian vào', b.DateCheckOut as N'Thời gian ra', b.TotalPrice as N'Tổng tiền', b.discount as N'Giảm giá'
--	from Bill as b, tablefood as t , Account as a
--	where DateCheckIn >= @DateCheckIn and DateCheckOut <= @DateCheckOut and b.status = 1 
--	and t.id = b.idtable
--end
--go

go
Create Proc USP_GetListBillByDate
@DateCheckIn date, @DateCheckOut date
as
begin
	Select t.name as N'Bàn ăn', b.Staff as N'Nhân viên', b.DateCheckIn as N'Thời gian vào', b.DateCheckOut as N'Thời gian ra', b.TotalPrice as N'Tổng tiền', b.discount as N'Giảm giá'
	from Bill as b, tablefood as t
	where DateCheckIn >= @DateCheckIn and DateCheckOut <= @DateCheckOut and b.status = 1 
	and t.id = b.idtable
end
go

go
Create Proc USP_GetListBillByDateNV
@DateCheckIn date, @DateCheckOut date, @TenNV Nvarchar(100)
as
begin
	Select t.name as N'Bàn ăn', b.Staff as N'Nhân viên', b.DateCheckIn as N'Thời gian vào', b.DateCheckOut as N'Thời gian ra', b.TotalPrice as N'Tổng tiền', b.discount as N'Giảm giá'
	from Bill as b, tablefood as t
	where DateCheckIn >= @DateCheckIn and DateCheckOut <= @DateCheckOut and b.status = 1 
	and t.id = b.idtable and b.Staff = @TenNV
end
go


go
Create Proc USP_GetChiPhiByDate
@DateForm date, @DateTo date
as
begin
	Select * From ChiPhi
	where MonthChiPhi >= @DateForm and MonthChiPhi <= @DateTo
end
go


go
Create Proc USP_UpdateAccount
@username Nvarchar(100), @displayname Nvarchar(100), @password Nvarchar(100) , @newpassword Nvarchar(100)
as
begin
	declare @Check int = 0
	select @check = count(*) from Account where username = @username and password = @password
	if(@check = 1)
	begin
		if(@newpassword = null or @newpassword = '')
		begin
			update account set displayname = @displayname where username = @username
		end
		else
		begin
			update account set displayname = @displayname , password = @newpassword where username = @username
		end
	end
end
go

-- Create Trigger
go
Create Trigger UTG_UpdateBillInfor
On BillInfor For Insert, Update
As
Begin
	Declare @idBill int
	Select @idBill = idbill from Inserted
	Declare @idTable int
	Select @idTable = idtable from Bill where id = @idBill
	Update TableFood Set status = N'Có người' where id = @idTable
end
go
Create Trigger UTG_UpdateBill
On Bill for Update
as
begin
	Declare @idBill int
	select @idBill = id from Inserted
	Declare @idTable int
	Select @idTable = idtable from Bill where id = @idBill
	Declare @count int =0;
	Select @count = Count(*) from Bill where idTable = @idTable and status = 0
	if(@count = 0)
		Update TableFood Set status = N'Trống' where id = @idTable
end
go


Create Trigger UTG_DeleteBillInfor
on BillInfor for delete
as
begin
	Declare @id int
	Declare @idBill int
	Select @id = id , @idbill = idbill from Deleted
	Declare @idtable int
	Select @idtable = idtable from Bill
	Declare @count int = 0
	Select @count = Count(*) from BillInfor as bi, Bill as b where bi.idbill = b.id and @idbill = b.id  and status = 0
	if(@count = 0)
		Update TableFood set status = N'Trống' where id = @idtable
end
go

--Delete BillInfor
--Delete Bill
--Select * from BillInfor
--Select * from Bill


--Create View
--Select food have price at least 1.000.000đ
  go
  CREATE VIEW view_foodatleast AS
  SELECT *
  FROM food
  WHERE price >= 1000000;
  go
  --SELECT * FROM view_foodatleast

  --Create Function
  go
  create function GetBillByDate(@DayCheckIn DateTime, @DayCheckOut DateTime) 
  Returns table
  as
  return (Select t.name as N'Bàn ăn', b.DateCheckIn as N'Thời gian vào', b.DateCheckOut as N'Thời gian ra', b.TotalPrice as N'Tổng tiền', b.discount as N'Giảm giá'
	from Bill as b, tablefood as t 
	where DateCheckIn >= @DayCheckIn and DateCheckOut <= @DayCheckOut and b.status = 1 
	and t.id = b.idtable)
go
 --Select dbo.GetBillByDate(GETDATE(),GETDATE())
 go
	create function GetFoodByID(@id int) 
  Returns table
  as
  return (Select * from Food
	where id = @id)
go
	--Select dbo.GetFoodByID(10)



--Create Transaction
--Begin Transaction 
--UPDATE dbo.Bill SET status = 1, DateCheckOut = Getdate(), Discount = 20 , TotalPrice = 5000000 WHERE id = 32
--UPDATE dbo.Bill SET status = 1, DateCheckOut = Getdate(), Discount = 20 , TotalPrice = 5000000 WHERE id = 31
--RollBack
--Select * from Bill
--Select t.name , b.DateCheckIn , b.DateCheckOut, b.TotalPrice
--from Bill as b, tablefood as t 
--where DateCheckIn >= '20210701' and DateCheckOut <= '20210731' and b.status = 1 
--and t.id = b.idtable

--Create Login, user
--go
--Create login admin with password = 'admin'
--go
--go
--Create login nhanvien1 with password = 'nhanvien1'
--go
--go
--Create login nhanvien2 with password = 'nhanvien2'
--go
--create user admin for login admin
--go
--create user nhanvien1 for login nhanvien1
--go
--create user nhanvien2 for login nhanvien2

----Role Server
--go
----Admin
--EXEC sp_addsrvrolemember admin, 'SecurityAdmin'
--EXEC sp_addsrvrolemember admin, 'DBCreator'
--EXEC sp_addsrvrolemember admin, 'ProcessAdmin'
--go
----Nhanvien1
--EXEC sp_addsrvrolemember nhanvien1, 'SecurityAdmin'
--go
----Nhanvien2
--EXEC sp_addsrvrolemember nhanvien2, 'SecurityAdmin'
--go
----Role Database
----admin
--EXEC sp_addrolemember 'db_datawriter', 'admin'
--EXEC sp_addrolemember 'db_datareader', 'admin'
--EXEC sp_addrolemember 'db_securityadmin', 'admin'
--EXEC sp_addrolemember 'db_owner', 'admin'
--go
----nhanvien1:
--EXEC sp_addrolemember 'db_datareader', 'nhanvien1'
--EXEC sp_addrolemember 'db_securityadmin', 'nhanvien1'
--go
----nhanvien2:
--EXEC sp_addrolemember 'db_datareader', 'nhanvien2'
--EXEC sp_addrolemember 'db_securityadmin', 'nhanvien2'
----Select * from Account where username = 'admin'

----Cấp quyền
--go
--Grant insert,delete,update,select on Bill to nhanvien1
--Grant insert,delete,update,select on BillInfor to nhanvien1
--Grant insert,delete,update,select on TableFood to nhanvien1
--GRANT EXECUTE ON USP_Bill TO nhanvien1;  
--GRANT EXECUTE ON USP_GETLISTBILLBYDATE TO nhanvien1
--Grant EXECUTE on USP_InsertBill to nhanvien1
--Grant EXECUTE on USP_InsertBillInfo to nhanvien1
--Grant EXECUTE on USP_UpdateAccount to nhanvien1
--Grant insert,delete,update,select on Bill to nhanvien2
--Grant insert,delete,update,select on BillInfor to nhanvien2
--Grant insert,delete,update,select on TableFood to nhanvien2
--GRANT EXECUTE ON USP_Bill TO nhanvien2  
--GRANT EXECUTE ON USP_GETLISTBILLBYDATE TO nhanvien2
--Grant EXECUTE on USP_InsertBill to nhanvien2
--Grant EXECUTE on USP_InsertBillInfo to nhanvien2
--Grant EXECUTE on USP_UpdateAccount to nhanvien2
--go

--drop proc USP_UpdateAccount

--Select * from Food
--Select ID, Name as N'Tên thức ăn' , IDCategory , Price as N'Giá' from Food

--go

--Select * from Billinfor
--Select * from Bill
--go


--Select * from Bill
--Select * from BillInfor
--Select * from Account

--Select * from Foodcategory where id = 26
--Select * from Food where idcategory = 13
--Select * from Bill

--Delete Billinfor where idfood = @id
--Delete Food where idcategory = 13
--Delete FoodCategory where id = 13
--Delete Billinfor
--Delete Bill
--Select * from billInfor
--Select idBill from billinfor where idfood = 60
--Select * from Bill where id = 11
--Select idBill from billinfor where idfood = 59

go

--create PROC [dbo].[USP_TAOLOGIN]
-- @LGNAME VARCHAR(50),
-- @PASS VARCHAR(50),
-- @USERNAME VARCHAR(50),
-- @ROLE VARCHAR(50)
--AS
-- DECLARE @RET INT
-- EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'CoffeeShop'
-- IF (@RET =1) -- LOGIN NAME BI TRUNG
--	RETURN 1
-- EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
-- IF (@RET =1) -- USER NAME BI TRUNG
-- BEGIN
--	EXEC SP_DROPLOGIN @LGNAME
--	RETURN 2
-- END

-- --EXEC sp_addrolemember @ROLE, @USERNAME
-- IF (@ROLE= 'ADMIN') --THUOC ADMIN
-- BEGIN
--	EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
--	EXEC sp_addsrvrolemember @LGNAME, 'DBCreator'
--	EXEC sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
--	EXEC sp_addsrvrolemember 'ADMIN', @USERNAME
-- END
-- IF (@ROLE= 'NHANVIEN1') --THUOC NHANVIEN1
-- BEGIN
--	EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
--	EXEC sp_addsrvrolemember 'NHANVIEN1', @USERNAME
-- END
-- ELSE -- THUOC NHOM NHANVIEN2
-- BEGIN 
--	EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
--	EXEC sp_addsrvrolemember 'NHANVIEN2', @USERNAME
-- END
--RETURN 0 -- THANH CONG


--CREATE PROC [dbo].[USP_XoaLogin]
-- @LGNAME VARCHAR(50),
-- @USRNAME VARCHAR(50)

--AS
--EXEC SP_DROPUSER @USRNAME
-- EXEC SP_DROPLOGIN @LGNAME
--exec USP_InsertBill 5
--Exec USP_GetListBillByDate GetDate , GetDate