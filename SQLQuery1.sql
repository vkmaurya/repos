Create table Customer_tbl
(
C_id int primary key,
C_Name varchar(50),
C_Address varchar(max),
C_City varchar(50)
);

insert into Customer_tbl values(1,'vikash ','mohali','allahabad');
insert into Customer_tbl values(2,'maan ','mohali','allahabad');
insert into Customer_tbl values(3,'atul ','mohali','delhi');
insert into Customer_tbl values(4,'sang ','mohali','allahabad');
insert into Customer_tbl values(5,'vik ','mohali','chandighar');
insert into Customer_tbl values(6,'viki ','mohali','chandighar');

delete from Customer_tbl where C_id=6;

select * from Customer_tbl

create table Order_table
(

Ord_Id int primary key,
Ord_Item varchar(50),
ord_Quntity int,
price_of_1 int,
C_id int foreign key references Customer_tbl(C_id)
);

insert into Order_table values(111,'hardisk',2,500,3);
insert into Order_table values(112,'keybord',2,600,1);
insert into Order_table values(113,'printer',3,8000,3);
insert into Order_table values(114,'tv',1,5000,4);
insert into Order_table values(116,'USB',3,500,6);

delete from Order_table where Ord_Id=116;

select * from Customer_tbl
select * from Order_table


create table Voter_table(

Voter_Id int,
Voter_Name varchar(50),
Voter_Age int

);

select * from Voter_table

Select id as Employee_Id,Name as Employee_Name,Address as Employee_Address,Email as Employee_Email,mobile as Employee_Mobile_Number from Employee





