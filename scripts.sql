Create Table Student (
Sid Int Primary Key, 
Name Varchar(50), 
Class Int, 
Fees Money, 
Photo Varchar(100), 
Status Bit
Not Null Default 1)

select * from Student
delete from Student where Sid=105
insert into Student values (1,'Tira',5,5009,null,1),
(2,'Meet',7,4567,null,0),
(3,'Sita',4,5678,null,1)

update Student set Status=1 where Sid=105
