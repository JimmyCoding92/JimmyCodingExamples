CREATE DATABASE JimmyCoding; 
DROP DATABASE JimmyCoding;

Use JimmyCodingDataBase
create table FirstTable (
	id uniqueidentifier not null PRIMARY KEY,
	charColumn char(10),
	varCharColumn varchar(10),
	ncharColumn nchar(10),
	nvarcharColumn nvarchar(10),
	bitColumn bit,
	intColumn int,
	bigintColumn bigint,
	decimalColumn decimal,
	floatColumn float,
	moneyColumn money,
	datetimeColumn datetime,
	binaryColumn binary,
	imageColumn image,
	xmlColumn xml,
	rowVersionColumn rowversion,
	geoColumn geography
);

create table SecondTable (
	id uniqueidentifier not null PRIMARY KEY,
	firstTableIdReference uniqueidentifier FOREIGN KEY REFERENCES FirstTable(id)
);

drop table FirstTable
drop table SecondTable

Use WideWorldImporters
select CityName from Application.Cities

select * from Application.Cities

select distinct CityName from Application.Cities order by CityName asc

select CityName, Count(CityName) as cityCount from Application.Cities group by CityName having COUNT(CityName) > 1

select SupplierId, TransactionAmount, (select AVG(TransactionAmount) from Purchasing.SupplierTransactions) as TransactionAmount
from Purchasing.SupplierTransactions

select SupplierID, SUM(nums_order) FROM
	(select SupplierID, TransactionDate, COUNT(*) as nums_order
	from Purchasing.SupplierTransactions
	GROUP by SupplierID, TransactionDate) sub
group by SupplierID

select *
from Purchasing.SupplierTransactions
where SupplierID IN (select PersonId from Application.People where IsEmployee = 1)
