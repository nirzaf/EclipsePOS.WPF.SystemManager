use [master]
GO

create database [possite]

go

use [possite]


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO



/* Drop tables */


if OBJECT_ID('dbo.stock_balance', 'U') IS NOT NULL
	DROP TABLE dbo.stock_balance
go


if OBJECT_ID('dbo.trans_stock', 'U') IS NOT NULL
	DROP TABLE dbo.trans_stock
go




if OBJECT_ID('dbo.trans_bank', 'U') IS NOT NULL
	DROP TABLE dbo.trans_bank
go


if OBJECT_ID('dbo.trans_tax', 'U') IS NOT NULL
	DROP TABLE dbo.trans_tax
go


if OBJECT_ID('dbo.trans_customer', 'U') IS NOT NULL
	DROP TABLE dbo.trans_customer
go


if OBJECT_ID('dbo.trans_exception', 'U') IS NOT NULL
	DROP TABLE dbo.trans_exception
go


if OBJECT_ID('dbo.trans_tender', 'U') IS NOT NULL
	DROP TABLE dbo.trans_tender
go


if OBJECT_ID('dbo.trans_promotion', 'U') IS NOT NULL
	DROP TABLE dbo.trans_promotion
go


if OBJECT_ID('dbo.trans_item', 'U') IS NOT NULL
	DROP TABLE dbo.trans_item
go


if OBJECT_ID('dbo.trans_count', 'U') IS NOT NULL
	DROP TABLE dbo.trans_count
go


if OBJECT_ID('dbo.trans', 'U') IS NOT NULL
	DROP TABLE dbo.trans
go


if OBJECT_ID('dbo.station_trans_upload', 'U') IS NOT NULL
	DROP TABLE dbo.station_trans_upload
go


if OBJECT_ID('dbo.station_session', 'U') IS NOT NULL
	DROP TABLE dbo.station_session
go


if OBJECT_ID('dbo.station_total', 'U') IS NOT NULL
	DROP TABLE dbo.station_total
go


if OBJECT_ID('dbo.station_close', 'U') IS NOT NULL
	DROP TABLE dbo.station_close
go


if OBJECT_ID('dbo.station_close_detail', 'U') IS NOT NULL
	DROP TABLE dbo.station_close_detail
go


if OBJECT_ID('dbo.station_balance_detail', 'U') IS NOT NULL
	DROP TABLE dbo.station_balance_detail
go

if OBJECT_ID('dbo.station_session', 'U') IS NOT NULL
	DROP TABLE dbo.station_session
go



if OBJECT_ID('dbo.input_filter_field', 'U') IS NOT NULL
	DROP TABLE dbo.input_filter_field
go


if OBJECT_ID('dbo.input_filter', 'U') IS NOT NULL
	DROP TABLE dbo.input_filter
go

if OBJECT_ID('dbo.dialog_event', 'U') IS NOT NULL
	DROP TABLE dbo.dialog_event
go


if OBJECT_ID('dbo.dialog', 'U') IS NOT NULL
	DROP TABLE dbo.dialog
go

if OBJECT_ID('dbo.pos_param', 'U') IS NOT NULL
	DROP TABLE dbo.pos_param
go

if OBJECT_ID('dbo.plu', 'U') IS NOT NULL
	DROP TABLE dbo.plu
go


if OBJECT_ID('dbo.item', 'U') IS NOT NULL
	DROP TABLE dbo.item
go

if OBJECT_ID('dbo.department', 'U') IS NOT NULL
	DROP TABLE dbo.department
go

if OBJECT_ID('dbo.item_group', 'U') IS NOT NULL
	DROP TABLE dbo.item_group
go

if OBJECT_ID('dbo.employee', 'U') IS NOT NULL
	DROP TABLE dbo.employee
go

if OBJECT_ID('dbo.employee_role_event', 'U') IS NOT NULL
	DROP TABLE dbo.employee_role_event
go

if OBJECT_ID('dbo.employee_roles', 'U') IS NOT NULL
	DROP TABLE dbo.employee_roles
go

if OBJECT_ID('dbo.customer', 'U') IS NOT NULL
	DROP TABLE dbo.customer
go

if OBJECT_ID('dbo.currency_denomination', 'U') IS NOT NULL
	DROP TABLE dbo.currency_denomination
go


if OBJECT_ID('dbo.currency', 'U') IS NOT NULL
	DROP TABLE dbo.currency
go

if OBJECT_ID('dbo.currency_code', 'U') IS NOT NULL
	DROP TABLE dbo.currency_code
go


if OBJECT_ID('dbo.media', 'U') IS NOT NULL
	DROP TABLE dbo.media
go


if OBJECT_ID('dbo.promotion_map', 'U') IS NOT NULL
	DROP TABLE dbo.promotion_map
go

if OBJECT_ID('dbo.promotion', 'U') IS NOT NULL
	DROP TABLE dbo.promotion
go

if OBJECT_ID('dbo.pos_key', 'U') IS NOT NULL
	DROP TABLE dbo.pos_key
go


if OBJECT_ID('dbo.tax', 'U') IS NOT NULL
	DROP TABLE dbo.tax
go

if OBJECT_ID('dbo.tax_group', 'U') IS NOT NULL
	DROP TABLE dbo.tax_group
go


if OBJECT_ID('dbo.table_group', 'U') IS NOT NULL
	DROP TABLE dbo.table_group
go

if OBJECT_ID('dbo.table_details', 'U') IS NOT NULL
	DROP TABLE dbo.table_details
go



if OBJECT_ID('dbo.sub', 'U') IS NOT NULL
	DROP TABLE dbo.sub
go

if OBJECT_ID('dbo.sub_map', 'U') IS NOT NULL
	DROP TABLE dbo.sub_map
go

if OBJECT_ID('dbo.pos', 'U') IS NOT NULL
	DROP TABLE dbo.pos
go

if OBJECT_ID('dbo.retail_store', 'U') IS NOT NULL
	DROP TABLE dbo.retail_store
go

if OBJECT_ID('dbo.menu_config', 'U') IS NOT NULL
	DROP TABLE dbo.menu_config
go

if OBJECT_ID('dbo.menu_panels', 'U') IS NOT NULL
	DROP TABLE dbo.menu_panels
go

if OBJECT_ID('dbo.sub_map', 'U') IS NOT NULL
	DROP TABLE dbo.sub_map
go

if OBJECT_ID('dbo.ItemGroup', 'U') IS NOT NULL
	DROP TABLE dbo.ItemGroup
go

if OBJECT_ID('dbo.employee_role_event', 'U') IS NOT NULL
	DROP TABLE dbo.employee_role_event
go

if OBJECT_ID('dbo.employee_roles', 'U') IS NOT NULL
	DROP TABLE dbo.employee_roles
go

if OBJECT_ID('dbo.menu_root', 'U') IS NOT NULL
	DROP TABLE dbo.menu_root
go

if OBJECT_ID('dbo.pos_balance_detail', 'U') IS NOT NULL
	DROP TABLE dbo.pos_balance_detail
go

if OBJECT_ID('dbo.pos_close', 'U') IS NOT NULL
	DROP TABLE dbo.pos_close
go

if OBJECT_ID('dbo.pos_close_detail', 'U') IS NOT NULL
	DROP TABLE dbo.pos_close_detail
go

if OBJECT_ID('dbo.pos_total', 'U') IS NOT NULL
	DROP TABLE dbo.pos_total
go

if OBJECT_ID('dbo.pos_trans_upload', 'U') IS NOT NULL
	DROP TABLE dbo.pos_trans_upload
go


if OBJECT_ID('dbo.pos_session', 'U') IS NOT NULL
	DROP TABLE dbo.pos_session
go

if OBJECT_ID('dbo.reason_code', 'U') IS NOT NULL
	DROP TABLE dbo.reason_code
go

if OBJECT_ID('dbo.reason_code_category', 'U') IS NOT NULL
	DROP TABLE dbo.reason_code_category
go

if OBJECT_ID('dbo.trans_time_punch', 'U') IS NOT NULL
	DROP TABLE dbo.trans_time_punch
go

if OBJECT_ID('dbo.trans_total', 'U') IS NOT NULL
	DROP TABLE dbo.trans_total
go


if OBJECT_ID('dbo.trans_text', 'U') IS NOT NULL
	DROP TABLE dbo.trans_text
go



if OBJECT_ID('dbo.total', 'U') IS NOT NULL
	DROP TABLE dbo.total
go



if OBJECT_ID('dbo.pos_config', 'U') IS NOT NULL
	DROP TABLE dbo.pos_config
go



if OBJECT_ID('dbo.organization', 'U') IS NOT NULL
	DROP TABLE dbo.organization
go

if OBJECT_ID('dbo.help', 'U') IS NOT NULL
	DROP TABLE dbo.help
go


/* ------------------ Organizations ---------------------*/



Create table organization
(

organization_no		varchar(6)  not null,
organization_name	varchar(60) not null,
address1			varchar(60) not null,
address2			varchar(60),
address3			varchar(60),
address4			varchar(60),
city				varchar(30),
state				varchar(30),
postal_code			varchar(20),
country				varchar(30),
phone				varchar(30),
fax					varchar(30),
contact				varchar(60),
home_currency		varchar(3) not null,
tax_number			varchar(40),
pos_shipment_code_length	smallint,
pos_shipment_prefix			varchar(6),
pos_shipment_next_number	bigint,
CONSTRAINT pk_organization PRIMARY KEY CLUSTERED (organization_no)

)

GO



/* RetailStore */



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'retail_store')
	BEGIN
		PRINT 'Dropping Table retail_store'
		DROP  Table retail_store
	END
GO

/******************************************************************************
**		File: 
**		Name: Table_Name
**		Desc: 
**
**		This template can be customized:
**              
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

PRINT 'Creating Table retail_store'
GO
CREATE TABLE retail_store
(
store_no			varchar(6) not null,
organization_no		varchar(6) not null references Organization(organization_no),
store_name			varchar(60) not null,
address1			varchar(60) not null,
address2			varchar(60) not null, 	
address3			varchar(60) not null,
address4			varchar(60),
city				varchar(30),
state				varchar(30),
zip					varchar(20),
country				varchar(30),
phone				varchar(30), 
fax					varchar(30),
contact				varchar(60),
email				varchar(50),
last_trans_no		bigint,
customer_tax_id			varchar(50),
						  
constraint pk_retail_store primary key ( organization_no, store_no)
)

GO










/* ---------------------- employee_roles	---------------------- */


create table employee_roles
(
role_id varchar(12) not null,
role_name varchar (100) not null,
organization_no varchar(6)  not null references Organization(organization_no),
constraint pk_employees_roles primary key ( organization_no, role_id)
)

go



/* ----------------- employee_role_event ----------------------- */


create table employee_role_event
(
role_event_id integer not null,
role_event_name varchar (100) not null,
role_id varchar(12) not null,
organization_no varchar(6)  not null references Organization(organization_no),
constraint pk_employees_event primary key ( organization_no, role_id, role_event_id)


)

go



/* ------------------ Employee -------------------------------- */

create table employee
(
organization_no varchar(6) not null references Organization(organization_no),							
employee_no varchar(20),
logon_no varchar(32) not null,
logon_pass varchar(32) not null,
role_id varchar(12)  not null,
fname varchar (32),
lname varchar(32),
mi char(1),
ssn char(9),
sal_grade integer,
constraint employeeKey primary key (organization_no, logon_no) 

)

go




/*------------------ Subscriber --------------------*/

create table sub
(	
subscriber_id integer identity primary key,
subscriber_name varchar(32) not null,
subscriber_pass varchar(32) not null
)
go




/* ---------------- Subscriber map---------------------*/

create table sub_map 
(	
subscriber_id integer not null,
organization_id integer not null,
subscriber_priv integer not null
)
go




/* -------------- Item group ------------------------ */

create table ItemGroup
(
organization_no VARCHAR(6) not null references organization(organization_no),
group_id varchar(5) not null,
group_name varchar (30)not null,
constraint item_group_key primary key (organization_no, group_id)
)
GO


/* --------------- Department ----------------------- */ 

create table department
(
organization_no varchar(6) not null references organization(organization_no),	
department_id varchar(5) not null,
department_name varchar(30) not null,
constraint department__key primary key (organization_no, department_id)
)

GO

 
/* ----------------- Item ---------------------------- */

create table item
(
organization_no varchar(6) references organization(organization_no),			
sku varchar (24) not null,				
short_desc varchar (60) not null,
amount decimal(15,2),			
dept varchar(5),
item_group varchar(5),			
tax_group_id varchar(12),			
pricing_opt smallint,			
active_date datetime,			
deactive_date datetime,			
tax_inclusive smallint,		
tax_exempt smallint,
catogory varchar(6),		
shipping_uom varchar(10),
plu varchar(24) null,
plucal as (
				case
					when plu is null then sku else null 
				end
			) Persisted
constraint item_key primary key (organization_no, sku),
constraint uniq_plu_nulls unique (organization_no, plu, plucal)
)

GO







/* ------------------- PosConfig ------------------ */


create table pos_config
(
config_no int  primary key,
name varchar(50) not null unique,
)


GO





/* ------------------ Pos_param ------------------------ */

create table pos_param
(
config_no integer not null references pos_config(config_no),
param_type integer,
param_catogory integer,
help_id integer,
param_name varchar (30),
param_value varchar (100),
Remarks varchar(100),
Constraint pk_pos_param primary key  (config_no, param_name)
)



/* ------------------ currency_code ------------------------ */

create table currency_code
(
currency_code varchar(3) not null,
currency_name varchar(60) not null,
symbol		  varchar (4) not null,
decimals		smallint not null,
symbol_position	smallint not null,
thousand_seperator varchar (1) not null,
decimal_seperator varchar (1) not null,
negative_display smallint not null,
pos_key_number int not null,
constraint currency_code_key primary key (currency_code),
constraint  currency_code_access_key unique(pos_key_number)
)

go


/* ------------------ currency ------------------------ */


create table currency
(
home_currency varchar(3) not null,
source_currency varchar(3) not null,
rate_date datetime not null,
conversion_rate decimal(15,7) not null,
spread decimal(15,7),
date_match datetime,
rate_operator smallint,
constraint pk_currency primary key (home_currency, source_currency, rate_date)
)


go




/* ------------------ Customer ------------------------ */

create table customer
(
organization_no varchar(6) not null references Organization(organization_no),
tax_id varchar(50) not null,
customer_search_key varchar (20) not null,
customer_first_name varchar (60) not null,
customer_last_name varchar(60),
addr1 varchar(60) not null,
addr2 varchar(60) not null,
postel_code varchar(50),
city varchar(50),
region varchar(50),
country varchar(50),
phone varchar(30),
alt_phone varchar(30),			
fax varchar (30),
email varchar (60),
card varchar(60),
notes varchar(100),
max_debt decimal(15,2),
current_debt decimal(15,2),
creation_date datetime,
status int,
customer_account_set varchar(6),		
price_list_code		varchar(6),
terms_code varchar(6),
rate_type	varchar(2),
tax_group_code varchar(12),
constraint customer_key  primary key (organization_no, tax_id)
)


go



/* ----------------- Surcharge ---------------------------- */


create table surcharge
(
organization_no varchar(6) references organization(organization_no),			
surcharge_code varchar (6) not null,				
surcharge_desc varchar (60) not null,
amount decimal(15,2),			
method smallint,
surcharge_account varchar(45),			
tax_group_id varchar(12),			
tax_inclusive smallint,		
tax_exempt smallint,
surcharge_key_id smallint,
constraint surcharge_key primary key (organization_no, surcharge_code),
constraint  surcharge_access_key unique(organization_no, surcharge_key_id)
)

GO




------------------------ done ----------------------




 


create table dialog
(
dialog_id integer not null primary key,
dialog_type integer,
dialog_name nvarchar (50) not null
)

 go



create table dialog_event (
						dialog_event_id int identity primary key,
						dialog_id int references dialog(dialog_id),
						dialog_seq int,
						dialog_desc nvarchar (50),
						state int,
						event_required int,
						event_enabled int,
						event_class nvarchar (100)
)


 go




create table input_filter (
	filter_id integer,
	filter_type integer,
	filter_sub_type integer,
	filter_name varchar (50),
	display_name varchar (50),
	regex varchar (32),
	check_digit_class varchar (100),
	filter_class varchar (100))

 go



create table input_filter_field (
	filter_id integer,
	sequence_no integer,
	name varchar (32))


 go











-------------- done --------------------------------------












/* 21 POS	*/

create table pos
(	
pos_no int not null,
organization_no varchar(6) not null references Organization(organization_no),
store_no varchar(6) not null,
num_drawers integer,
short_desc varchar(32) not null,
create_date datetime,
modify_date datetime,
constraint pk_pos primary key (organization_no, store_no, pos_no)

)
				  
GO




/* 22 POS balance detail	*/

 create table pos_balance_detail (
								 pos_balance_id integer not null,
								 media_type integer,
								 media_amount decimal(15,2) )



   go



/* 23 POS Close	*/

 create table pos_close (
						pos_balance_id integer not null,
						pos_transport_id integer not null,
						site_id integer not null,
						pos_no integer not null,
						create_date timestamp)

   go



/* 24 POS close detail	*/

 create table pos_close_detail (
						   pos_balance_id integer not null,
							   currency_type integer,
							   denomination integer,
							   denom_count integer)

   go






/*----------------------- menu panels ---------------------*/

create table menu_panels
(
config_no int not null references pos_config(config_no),
panel_id int not null,
panel_name varchar(100) not null,
panel_class_name varchar(500) not null,
constraint menukey primary key (config_no, panel_id)	
)
 
GO





/* ------------------ POS key ------------------------*/

create table pos_key 
(
key_id integer identity primary key,
config_no int references pos_config(config_no),
panel_id int not null,
key_text varchar(100) not null,
key_type integer,
key_val integer,
key_code integer,
device_type integer,
x_loc integer not null,
y_loc integer not null,
key_height integer,
key_width integer,
fg_color integer,
bg_color integer,
attr integer,
flags varchar(100),
logout_disable integer,
key_class varchar(100) not null,
param varchar(100),
image varchar(100)
)

go




/* 30  POS session	*/

 create table pos_session (
						  
						 site_id integer not null,
						  pos_no integer not null,
						  session_type integer not null,
						  status integer,
						  start_date datetime,
						  end_date datetime)
   go







/* 32 POS trans upload	*/

 create table pos_trans_upload
 (
	organization_no varchar(6) not null references Organization(organization_no),
	upload_session_no varchar(22) not null,
	fiscal_year varchar(4),
	fiscal_period int,
	remarks varchar(60),
	subscriber_name varchar(32),
	creation_date datetime, 
	status smallint
	constraint pk_pos_trans_upload primary key (organization_no, upload_session_no)  
)

   go



/* --------------------- Promotion ---------------------*/ 

create table promotion
(
organization_no varchar(6) not null references organization(organization_no),						
promotion_no int not null,
promotion_type int,
promotion_val1 int,
promotion_val2 int,
promotion_val3 int,
promotion_val4 int,
promotion_val5 int,
promotion_dval1 decimal(15,2),
promotion_dval2 decimal(15,2),
promotion_dval3 decimal(15,2),
promotion_dval4 decimal(15,2),
promotion_dval5 decimal(15,2),
print_before_item int,
valid_date_from datetime,
valid_date_to datetime,
promotion_string varchar (100),
promotion_class varchar (100),
constraint promotionkey primary key (organization_no, promotion_no)
)

go



/* -------------34 Promotion map ---------------*/

create table promotion_map
(
organization_no varchar(6) not null references organization(organization_no),						
promotion_no int not null,
promotion_map varchar(20) not null,
map_type int,
constraint promotionMapKey primary key (organization_no, promotion_map, promotion_no)
)



go



/* 35 Reason codes	*/

 create table reason_code_category (
					   category_id integer,
					   category_desc varchar (100))

   go





/* 36 */
 create table reason_code (
					   reason_code_id integer,
					   category_id integer,
					   reason_code integer,
					   code_desc varchar (100))

   go




 
/* ---------------- Tax group ---------------------*/

create table tax_group
(	
tax_group_id varchar(12) not null,
organization_no varchar(6) not null references Organization(organization_no),
tax_group_name varchar(60) not null,
constraint tax_group_key primary key (organization_no, tax_group_id)  
)

go


/*---------------------- Tax -----------------------*/

create table tax
(	
tax_id int not null,
tax_group_id varchar(12) not null,
organization_no varchar(6) not null references organization(organization_no),
tax_type int,
short_desc varchar(32) not null,
rate decimal(15,5)  not null, 
alt_rate decimal(15,5), 
constraint taxKey primary key (organization_no, tax_group_id, tax_id)	
)
go


/*----------------------- table group ---------------------*/

create table table_group
(
organization_no varchar(6) not null references organization(organization_no),
store_no varchar(6) not null,
table_group_no int not null,
table_group_name  varchar(100) not null,
constraint tableGroupKey primary key (organization_no, store_no, table_group_no)	
)
 
GO



/*----------------------- table ---------------------*/

create table table_details
(
organization_no varchar(6) not null references organization(organization_no),
store_no varchar(6) not null,
table_group_no int not null,
table_no int not null identity,
table_name varchar(3) not null,
display_row_no int not null,
display_column_no int not null,
number_of_guests int null,
picture_name varchar(100) null,
constraint tableKey primary key (organization_no, store_no, table_group_no, table_no)	
)
 
GO








/*------------------- POS total	----------------------*/


create table pos_total
(
total_name int not null,
sequence_no int not null,
organization_no varchar(6) not null references Organization(organization_no),
store_no varchar(6) not null ,
pos_no int,
emp_id int,
drawer_no int,
constraint pos_total_key primary key (organization_no, store_no, pos_no, total_name, sequence_no),
start_date datetime,
end_date datetime
)

go





/*------------------------ Total --------------------*/

create table total
(
total_name int not null,
sequence_no integer not null,
organization_no varchar(6) not null references Organization(organization_no),
store_no varchar(6) not null,
pos_no int,
total_type int,
total_count int,
total_amount decimal(15,2),
constraint total_key primary key (organization_no, store_no, pos_no, total_name, sequence_no, total_type),
)
go






/* transactions	*/

create table trans (
trans_no int not null,
store_no varchar(6) not null,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
drawer_no integer,
config_no int, 
trans_type int not null,
state int,
reason_code int,
customer_tax_id varchar (50),
start_time datetime,
complete_time datetime,
employee_login_no varchar(32) not null,
carry_out int,
training_mode int,
table_name varchar(3) null,
archive_date datetime,
upload_session_no varchar(22),
replication_date datetime,
constraint trans_key1 primary key (organization_no, store_no, pos_no, trans_no)	
)


go

 


/* Bank transactions	*/

 create table trans_bank (
						 	trans_no integer not null,
						 	seq_no integer,
						 	store_no varchar(6) not null,
							organization_no varchar(6) not null references Organization(organization_no),
							pos_no int not null,
						 	pay_type integer,
						 	deposit_no integer,
						 	state integer,
						 	drawer_no integer,
						 	bank_desc varchar (100),
							locale_language varchar (2),
							locale_country varchar (2),
						 	amount decimal(15,2),
						 	constraint trans_bank_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no )						

					 	)
						 	
   go



/* Trans count	*/

 create table trans_count (
						 	trans_no integer not null,
						 	seq_no integer,
						 	store_no varchar(6) not null,
							organization_no varchar(6) not null references Organization(organization_no),
							pos_no int not null,
							currency_denom_id integer,
						 	amount decimal(15,2),
						 	constraint trans_count_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no )						
						 )



go


/* Trans Customer	*/

create table trans_customer
(
trans_no integer not null,
store_no varchar(6) not null,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
total_type integer,
tax_id varchar(50),
constraint trans_customer_key1 primary key (organization_no, store_no, pos_no, trans_no, tax_id )						
)

go


/* Trans exception	*/

 create table trans_exception (
					 		trans_no integer not null,
						 	seq_no integer,
						 	store_no int not null,
							organization_no varchar(6) not null references Organization(organization_no),
							pos_no int not null,
							type integer,
						 	reason_code integer,
						 	amount decimal(15,2),
						 	constraint trans_exception_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no )						
 						 	)

go



/* Trans item	*/

 create table trans_item (
						 trans_no int not null,
						 seq_no int not null,
						 store_no varchar(6) not null,
						 organization_no varchar(6) not null references Organization(organization_no),
						 pos_no int not null,
						 line_no int not null,
						 sku varchar (24),
						 sku_link varchar (24),
						 quantity decimal(15,3),
						 amount decimal(15,2),
						 ext_amount decimal(15,2),
						 weight decimal(15,3),
						 item_desc varchar (60),
						 state int,
						 reason_code int,
						 tax_exempt int,
						 tax_incl int,
						 var_amount decimal(15,3),
						 constraint trans_item_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no )						
						 )

   go









/* Trans promotion	*/

create table trans_promotion (
trans_no int not null,
seq_no int,
store_no varchar(6) not null ,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
line_no int not null,
promotion_no int,
promotion_type int,
promotion_amount decimal(15,2),
promotion_quantity decimal(15,3),
reason_code int,
promotion_data varchar(100),
promotion_desc varchar(100),
state int,
constraint trans_promotion_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no )						
)

go




/* Trans tax	*/


create table trans_tax (
trans_no int not null,
seq_no integer,
line_no int not null,
store_no varchar(6) not null ,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
tax_id integer,
tax_desc varchar(30),
rate decimal(15,5),
taxable_amount decimal(15,2),
tax_amount decimal(15,2),
state int,
constraint trans_tax_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no )						

)


   go


/* Trans surcharge	*/

 create table trans_surcharge (
						 trans_no int not null,
						 seq_no int not null,
						 store_no varchar(6) not null,
						 organization_no varchar(6) not null references Organization(organization_no),
						 pos_no int not null,
						 line_no int not null,
						 surchage_code varchar (6),
						 amount decimal(19,3),
						 surchage_account varchar(24),
						 surchage_desc varchar (60),
						 state int,
						 reason_code int,
						 tax_exempt int,
						 tax_incl int,
						 var_amount decimal(19,3),
						 constraint trans_surcharge_key primary key (organization_no, store_no, pos_no, trans_no, seq_no )						
						 )

   go




/* Trans tender	*/


create table trans_tender
(
trans_no int not null,
seq_no int,
store_no varchar(6) not null ,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
tendertype int,
amount decimal(15,2),
change_amt decimal(15,2),
tender_desc varchar(100),
change_desc varchar(100),
locale_language varchar (2),
locale_country varchar (2),
data_capture varchar (100),
state int,
constraint trans_tender_key1 primary key (organization_no, pos_no, store_no, trans_no, seq_no )						
)


go








/* trans total	*/

 create table trans_total (
						  trans_no int not null,
						  seq_no int,
						  store_no varchar(6) not null ,
						  organization_no varchar(6) not null references Organization(organization_no),
					      pos_no int not null,
						  total_type int,
						  amount decimal(15,2),
						  total_desc varchar (100),
						  constraint trans_total_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no )						
						)


  go


/* Trans tax	*/


create table trans_text (
trans_no int not null,
seq_no int,
line_no integer,
store_no varchar(6) not null ,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
text_line_no integer,
extended_text varchar(60),
constraint trans_text_key1 primary key (organization_no, store_no, pos_no, trans_no, seq_no, line_no, text_line_no )						

)

go




 

/* Accpac shipments data import tables */

CREATE TABLE [dbo].[Shipments](
	[SHIUNIQ] [float] not NULL Primary key,
	[SHINUMBER] [varchar](22) NULL,
	[ORDNUMBER] [varchar](22) NULL,
	[DAYENDNUM] [float] NULL,
	[CUSTOMER] [varchar](12) NULL,
	[CUSTGROUP] [varchar](6) NULL,
	[BILNAME] [varchar](60) NULL,
	[BILADDR1] [varchar](60) NULL,
	[BILADDR2] [varchar](60) NULL,
	[BILADDR3] [varchar](60) NULL,
	[BILADDR4] [varchar](60) NULL,
	[BILCITY] [varchar](30) NULL,
	[BILSTATE] [varchar](30) NULL,
	[BILZIP] [varchar](20) NULL,
	[BILCOUNTRY] [varchar](30) NULL,
	[BILPHONE] [varchar](30) NULL,
	[BILFAX] [varchar](30) NULL,
	[BILCONTACT] [varchar](60) NULL,
	[BILEMAIL] [varchar](50) NULL,
	[BILPHONEC] [varchar](30) NULL,
	[BILFAXC] [varchar](30) NULL,
	[BILEMAILC] [varchar](50) NULL,
	[SHIPTO] [varchar](6) NULL,
	[SHPNAME] [varchar](60) NULL,
	[SHPADDR1] [varchar](60) NULL,
	[SHPADDR2] [varchar](60) NULL,
	[SHPADDR3] [varchar](60) NULL,
	[SHPADDR4] [varchar](60) NULL,
	[SHPCITY] [varchar](30) NULL,
	[SHPSTATE] [varchar](30) NULL,
	[SHPZIP] [varchar](20) NULL,
	[SHPCOUNTRY] [varchar](30) NULL,
	[SHPPHONE] [varchar](30) NULL,
	[SHPFAX] [varchar](30) NULL,
	[SHPCONTACT] [varchar](60) NULL,
	[SHPEMAIL] [varchar](50) NULL,
	[SHPPHONEC] [varchar](30) NULL,
	[SHPFAXC] [varchar](30) NULL,
	[SHPEMAILC] [varchar](50) NULL,
	[CUSTDISC] [int] NULL,
	[PRICELIST] [varchar](6) NULL,
	[PONUMBER] [varchar](22) NULL,
	[TERRITORY] [varchar](6) NULL,
	[TERMS] [varchar](6) NULL,
	[REFERENCE] [varchar](60) NULL,
	[SHIDATE] [datetime] NULL,
	[EXPDATE] [datetime] NULL,
	[SHIPVIA] [varchar](6) NULL,
	[VIADESC] [varchar](60) NULL,
	[SHIFISCYR] [varchar](4) NULL,
	[SHIFISCPER] [int] NULL,
	[LASTINVNUM] [varchar](22) NULL,
	[NUMINVOICE] [int] NULL,
	[FOB] [varchar](60) NULL,
	[TEMPLATE] [varchar](6) NULL,
	[LOCATION] [varchar](6) NULL,
	[DESC] [varchar](60) NULL,
	[COMMENT] [varchar](250) NULL,
	[OVERCREDIT] [bit] NULL,
	[APPROVELMT] [float] NULL,
	[APPROVEBY] [varchar](8) NULL,
	[PRINTSTAT] [int] NULL,
	[LASTPOST] [datetime] NULL,
	[SHIPLABEL] [bit] NULL,
	[LBLPRINTED] [bit] NULL,
	[SHHOMECURR] [varchar](3) NULL,
	[SHRATETYPE] [varchar](2) NULL,
	[SHSOURCURR] [varchar](3) NULL,
	[SHRATEDATE] [datetime] NULL,
	[SHRATE] [float] NULL,
	[SHSPREAD] [float] NULL,
	[SHDATEMTCH] [int] NULL,
	[SHRATEREP] [int] NULL,
	[SHRATEOVER] [bit] NULL,
	[SHITOTAL] [float] NULL,
	[SHIMTOTAL] [float] NULL,
	[SHILINES] [int] NULL,
	[NUMLABELS] [int] NULL,
	[SHIPAYTOT] [float] NULL,
	[SHIPYDSTOT] [float] NULL,
	[SALESPER1] [varchar](8) NULL,
	[SALESPER2] [varchar](8) NULL,
	[SALESPER3] [varchar](8) NULL,
	[SALESPER4] [varchar](8) NULL,
	[SALESPER5] [varchar](8) NULL,
	[SALESPLT1] [float] NULL,
	[SALESPLT2] [float] NULL,
	[SALESPLT3] [float] NULL,
	[SALESPLT4] [float] NULL,
	[SALESPLT5] [float] NULL,
	[RECALCTAX] [bit] NULL,
	[TAXOVERRD] [bit] NULL,
	[TAXGROUP] [varchar](12) NULL,
	[TAUTH1] [varchar](12) NULL,
	[TAUTH2] [varchar](12) NULL,
	[TAUTH3] [varchar](12) NULL,
	[TAUTH4] [varchar](12) NULL,
	[TAUTH5] [varchar](12) NULL,
	[TCLASS1] [int] NULL,
	[TCLASS2] [int] NULL,
	[TCLASS3] [int] NULL,
	[TCLASS4] [int] NULL,
	[TCLASS5] [int] NULL,
	[TBASE1] [float] NULL,
	[TBASE2] [float] NULL,
	[TBASE3] [float] NULL,
	[TBASE4] [float] NULL,
	[TBASE5] [float] NULL,
	[TEAMOUNT1] [float] NULL,
	[TEAMOUNT2] [float] NULL,
	[TEAMOUNT3] [float] NULL,
	[TEAMOUNT4] [float] NULL,
	[TEAMOUNT5] [float] NULL,
	[TIAMOUNT1] [float] NULL,
	[TIAMOUNT2] [float] NULL,
	[TIAMOUNT3] [float] NULL,
	[TIAMOUNT4] [float] NULL,
	[TIAMOUNT5] [float] NULL,
	[TEXEMPT1] [varchar](20) NULL,
	[TEXEMPT2] [varchar](20) NULL,
	[TEXEMPT3] [varchar](20) NULL,
	[TEXEMPT4] [varchar](20) NULL,
	[TEXEMPT5] [varchar](20) NULL,
	[COMPLETE] [int] NULL,
	[COMPDATE] [datetime] NULL,
	[SHIWEIGHT] [float] NULL,
	[NEXTDTLNUM] [int] NULL,
	[SDISONMISC] [bit] NULL,
	[NOSHIPLINE] [int] NULL,
	[NOMISCLINE] [int] NULL,
	[SHINETNOTX] [float] NULL,
	[SHIITAXTOT] [float] NULL,
	[SHIITMTOT] [float] NULL,
	[SHIDISCBAS] [float] NULL,
	[SHIDISCPER] [float] NULL,
	[SHIDISCAMT] [float] NULL,
	[SHIMISC] [float] NULL,
	[SHISUBTOT] [float] NULL,
	[SHINET] [float] NULL,
	[SHIETAXTOT] [float] NULL,
	[SHINETWTX] [float] NULL,
	[ORDDATE] [datetime] NULL,
	[ORHOMECURR] [varchar](3) NULL,
	[ORRATETYPE] [varchar](2) NULL,
	[ORSOURCURR] [varchar](3) NULL,
	[ORRATEDATE] [datetime] NULL,
	[ORRATE] [float] NULL,
	[ORSPREAD] [float] NULL,
	[ORDATEMTCH] [int] NULL,
	[ORRATEREP] [int] NULL,
	[ORRATEOVER] [bit] NULL,
	[AUTOTAXCAL] [bit] NULL,
	[MULTIORD] [bit] NULL,
	[ORDS] [int] NULL,
	[SHIPTRACK] [varchar](36) NULL,
	[NUMSHPMENT] [int] NULL,
	[VALUES] [int] NULL,
	[ORDUNIQ] [float] NULL,
	[ITEMDISTOT] [float] NULL,
	[MISCDISTOT] [float] NULL,
	[STRMETHOD] [int] NULL,
	[STRCURRNCY] [varchar](3) NULL,
	[STRRATTYPE] [varchar](2) NULL,
	[STRRATDATE] [datetime] NULL,
	[STRRATE] [float] NULL,
	[STRSPREAD] [float] NULL,
	[STRDATMTCH] [int] NULL,
	[STRRATEOP] [int] NULL,
	[STRRATOVER] [bit] NULL,
	[STREAMNT1] [float] NULL,
	[STREAMNT2] [float] NULL,
	[STREAMNT3] [float] NULL,
	[STREAMNT4] [float] NULL,
	[STREAMNT5] [float] NULL,
	[STRIAMNT1] [float] NULL,
	[STRIAMNT2] [float] NULL,
	[STRIAMNT3] [float] NULL,
	[STRIAMNT4] [float] NULL,
	[STRIAMNT5] [float] NULL,
	[OTRCURRNCY] [varchar](3) NULL,
	[OTRRATTYPE] [varchar](2) NULL,
	[OTRRATDATE] [datetime] NULL,
	[OTRRATE] [float] NULL,
	[OTRSPREAD] [float] NULL,
	[OTRDATMTCH] [int] NULL,
	[OTRRATEOP] [int] NULL,
	[OTRRATOVER] [bit] NULL,
	[DISAMTOVER] [bit] NULL,
	[SHNOPREPAY] [int] NULL,
	[JOBLINES] [int] NULL,
	[LNINVABLE] [int] NULL,
	[HASRTG] [bit] NULL,
	[RTGTERMS] [varchar](6) NULL,
	[RTGAMOUNT] [float] NULL,
	[RTGPERCENT] [float] NULL,
	[RTGRATE] [int] NULL,
	[RTGTXBASE1] [float] NULL,
	[RTGTXBASE2] [float] NULL,
	[RTGTXBASE3] [float] NULL,
	[RTGTXBASE4] [float] NULL,
	[RTGTXBASE5] [float] NULL,
	[RTGTXAMT1] [float] NULL,
	[RTGTXAMT2] [float] NULL,
	[RTGTXAMT3] [float] NULL,
	[RTGTXAMT4] [float] NULL,
	[RTGTXAMT5] [float] NULL,
	[CUSACCTSET] [varchar](6) NULL,
	[ENTEREDBY] [varchar](8) NULL,
	[DATEBUS] [datetime] NULL,
	[OPPOLINES] [int] NULL,
	[PCODDESC] [varchar](60) NULL,
	[TERMDESC] [varchar](60) NULL,
	[TXGRPDESC] [varchar](60) NULL,
	[LOCDESC] [varchar](60) NULL,
	[SALES1NAME] [varchar](60) NULL,
	[SALES2NAME] [varchar](60) NULL,
	[SALES3NAME] [varchar](60) NULL,
	[SALES4NAME] [varchar](60) NULL,
	[SALES5NAME] [varchar](60) NULL,
	[TAUTH1DESC] [varchar](60) NULL,
	[TAUTH2DESC] [varchar](60) NULL,
	[TAUTH3DESC] [varchar](60) NULL,
	[TAUTH4DESC] [varchar](60) NULL,
	[TAUTH5DESC] [varchar](60) NULL,
	[TCLAS1DESC] [varchar](60) NULL,
	[TCLAS2DESC] [varchar](60) NULL,
	[TCLAS3DESC] [varchar](60) NULL,
	[TCLAS4DESC] [varchar](60) NULL,
	[TCLAS5DESC] [varchar](60) NULL,
	[SHSRCDESC] [varchar](60) NULL,
	[SHHOMDESC] [varchar](60) NULL,
	[SHRTTYDESC] [varchar](60) NULL,
	[ORSRCDESC] [varchar](60) NULL,
	[ORHOMDESC] [varchar](60) NULL,
	[ORRTTYDESC] [varchar](60) NULL,
	[TAMOUNT1] [float] NULL,
	[TAMOUNT2] [float] NULL,
	[TAMOUNT3] [float] NULL,
	[TAMOUNT4] [float] NULL,
	[TAMOUNT5] [float] NULL,
	[POSTSEQNUM] [int] NULL,
	[INVUNIQ] [float] NULL,
	[INVDATE] [datetime] NULL,
	[INHOMECURR] [varchar](3) NULL,
	[INRATETYPE] [varchar](2) NULL,
	[INSOURCURR] [varchar](3) NULL,
	[INRATEDATE] [datetime] NULL,
	[INRATE] [float] NULL,
	[INSPREAD] [float] NULL,
	[INDATEMTCH] [int] NULL,
	[INRATEREP] [int] NULL,
	[INRATEOVER] [bit] NULL,
	[INSRCDESC] [varchar](60) NULL,
	[INHOMDESC] [varchar](60) NULL,
	[INRTTYDESC] [varchar](60) NULL,
	[FROMORDER] [bit] NULL,
	[PROCESSCMD] [int] NULL,
	[OECOMMAND] [int] NULL,
	[EDAPRVLMT] [float] NULL,
	[SWCHKLIMC] [bit] NULL,
	[SWCHKODUEC] [bit] NULL,
	[SWCHKLIMA] [bit] NULL,
	[SWCHKODUEA] [bit] NULL,
	[SWOVERLIMC] [bit] NULL,
	[SWOVERDUEC] [bit] NULL,
	[SWOVERLIMA] [bit] NULL,
	[SWOVERDUEA] [bit] NULL,
	[AMTLIMITC] [float] NULL,
	[AMTBALCUST] [float] NULL,
	[OVDUEDAYSC] [int] NULL,
	[OVDUELMTC] [float] NULL,
	[OVDUEBALC] [float] NULL,
	[AMTLIMITA] [float] NULL,
	[AMTBALACCT] [float] NULL,
	[OVDUEDAYSA] [int] NULL,
	[OVDUELMTA] [float] NULL,
	[OVDUEBALA] [float] NULL,
	[SWARPEND] [bit] NULL,
	[SWOEPEND] [bit] NULL,
	[SWXXPEND] [bit] NULL,
	[AMTARPEND] [float] NULL,
	[AMTOEPEND] [float] NULL,
	[AMTXXPEND] [float] NULL,
	[AMTTOTCUST] [float] NULL,
	[AMTTOTACCT] [float] NULL,
	[AMTLEFTC] [float] NULL,
	[AMTLEFTA] [float] NULL,
	[AMTOVERC] [float] NULL,
	[AMTOVERA] [float] NULL,
	[AMTLASTIVT] [float] NULL,
	[DATELASTIV] [datetime] NULL,
	[AMTLASTPYT] [float] NULL,
	[DATELASTPA] [datetime] NULL,
	[DTLDISCTOT] [float] NULL,
	[DTLDISCPER] [float] NULL,
	[SHINTDTDIS] [float] NULL,
	[STRAMOUNT1] [float] NULL,
	[STRAMOUNT2] [float] NULL,
	[STRAMOUNT3] [float] NULL,
	[STRAMOUNT4] [float] NULL,
	[STRAMOUNT5] [float] NULL,
	[STRETOTAL] [float] NULL,
	[STRITOTAL] [float] NULL,
	[STRTOTAL] [float] NULL,
	[ITRCURRNCY] [varchar](3) NULL,
	[ITRRATTYPE] [varchar](2) NULL,
	[ITRRATDATE] [datetime] NULL,
	[ITRRATE] [float] NULL,
	[ITRSPREAD] [float] NULL,
	[ITRDATMTCH] [int] NULL,
	[ITRRATEOP] [int] NULL,
	[ITRRATOVER] [bit] NULL,
	[OTRCURDESC] [varchar](60) NULL,
	[STRCURDESC] [varchar](60) NULL,
	[ITRCURDESC] [varchar](60) NULL,
	[OTRRTYDESC] [varchar](60) NULL,
	[STRRTYDESC] [varchar](60) NULL,
	[ITRRTYDESC] [varchar](60) NULL,
	[REBATCHNUM] [float] NULL,
	[BANKCODE] [varchar](8) NULL,
	[BANKRECTYP] [varchar](12) NULL,
	[CHECKDATE] [datetime] NULL,
	[CHKFISCYR] [varchar](4) NULL,
	[CHKFISCPER] [int] NULL,
	[CHECKNUM] [varchar](24) NULL,
	[APPLYTO] [int] NULL,
	[PAYMENT] [float] NULL,
	[PAYDISC] [float] NULL,
	[BANKPAYMNT] [float] NULL,
	[PENDPREPAY] [float] NULL,
	[PAHOMECURR] [varchar](3) NULL,
	[PARATETYPE] [varchar](2) NULL,
	[PASOURCURR] [varchar](3) NULL,
	[PARATEDATE] [datetime] NULL,
	[PARATE] [float] NULL,
	[PASPREAD] [float] NULL,
	[PADATEMTCH] [int] NULL,
	[PARATEREP] [int] NULL,
	[PAYMTYPE] [int] NULL,
	[SHIPAYMENT] [float] NULL,
	[SHIAMTDUE] [float] NULL,
	[AMTDUENODS] [float] NULL,
	[HASJOB] [bit] NULL,
	[NONINVABLE] [bit] NULL,
	[RTGTERMDSC] [varchar](60) NULL,
	[CUSACTDESC] [varchar](60) NULL,
	[INVDATEBUS] [datetime] NULL,
	[ORDPAYTOT] [float] NULL,
	[PAYDISTTOT] [float] NULL,
	[UNAPPLDPAY] [float] NULL,
	[RTXAMTTOT] [float] NULL
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Shipment_Details](
	[SHIUNIQ] [float] NULL,
	[LINENUM] [int] NULL,
	[LINETYPE] [int] NULL,
	[ITEM] [varchar](24) NULL,
	[MISCCHARGE] [varchar](6) NULL,
	[DESC] [varchar](60) NULL,
	[ACCTSET] [varchar](6) NULL,
	[USERCOSTMD] [bit] NULL,
	[PRICELIST] [varchar](6) NULL,
	[CATEGORY] [varchar](6) NULL,
	[LOCATION] [varchar](6) NULL,
	[PICKSEQ] [varchar](10) NULL,
	[EXPDATE] [datetime] NULL,
	[STOCKITEM] [bit] NULL,
	[ORDQTYORD] [float] NULL,
	[ORDQTYBKOR] [float] NULL,
	[ORDQTYCOMM] [float] NULL,
	[ORDQTYTCOM] [float] NULL,
	[ORDQTYSTD] [float] NULL,
	[ORDUNIT] [varchar](10) NULL,
	[ORDUNITCON] [float] NULL,
	[QTYORDERED] [float] NULL,
	[QTYSHIPPED] [float] NULL,
	[QTYBACKORD] [float] NULL,
	[QTYCOMMIT] [float] NULL,
	[QTYTRUECOM] [float] NULL,
	[SHIUNIT] [varchar](10) NULL,
	[UNITCONV] [float] NULL,
	[UNITPRICE] [float] NULL,
	[PRICEOVER] [bit] NULL,
	[UNITCOST] [float] NULL,
	[MOSTREC] [float] NULL,
	[STDCOST] [float] NULL,
	[COST1] [float] NULL,
	[COST2] [float] NULL,
	[AVGCOST] [float] NULL,
	[LASTCOST] [float] NULL,
	[UNITPRCDEC] [int] NULL,
	[PRICEUNIT] [varchar](10) NULL,
	[PRIUNTPRC] [float] NULL,
	[PRIUNTCONV] [float] NULL,
	[PRIPERCENT] [float] NULL,
	[PRIAMOUNT] [float] NULL,
	[BASEUNIT] [varchar](10) NULL,
	[PRIBASPRC] [float] NULL,
	[PRIBASCONV] [float] NULL,
	[COSTUNIT] [varchar](10) NULL,
	[COSUNTCST] [float] NULL,
	[COSUNTCONV] [float] NULL,
	[EXTSHIMISC] [float] NULL,
	[SHIDISC] [float] NULL,
	[EXTSCOST] [float] NULL,
	[EXTOVER] [bit] NULL,
	[UNITWEIGHT] [float] NULL,
	[EXTWEIGHT] [float] NULL,
	[COMPLETE] [int] NULL,
	[FINISHORD] [bit] NULL,
	[ADDTOILOC] [bit] NULL,
	[SALESLOST] [float] NULL,
	[TAUTH1] [varchar](12) NULL,
	[TAUTH2] [varchar](12) NULL,
	[TAUTH3] [varchar](12) NULL,
	[TAUTH4] [varchar](12) NULL,
	[TAUTH5] [varchar](12) NULL,
	[TCLASS1] [int] NULL,
	[TCLASS2] [int] NULL,
	[TCLASS3] [int] NULL,
	[TCLASS4] [int] NULL,
	[TCLASS5] [int] NULL,
	[TINCLUDED1] [bit] NULL,
	[TINCLUDED2] [bit] NULL,
	[TINCLUDED3] [bit] NULL,
	[TINCLUDED4] [bit] NULL,
	[TINCLUDED5] [bit] NULL,
	[TBASE1] [float] NULL,
	[TBASE2] [float] NULL,
	[TBASE3] [float] NULL,
	[TBASE4] [float] NULL,
	[TBASE5] [float] NULL,
	[TAMOUNT1] [float] NULL,
	[TAMOUNT2] [float] NULL,
	[TAMOUNT3] [float] NULL,
	[TAMOUNT4] [float] NULL,
	[TAMOUNT5] [float] NULL,
	[TRATE1] [float] NULL,
	[TRATE2] [float] NULL,
	[TRATE3] [float] NULL,
	[TRATE4] [float] NULL,
	[TRATE5] [float] NULL,
	[DETAILNUM] [int] NULL,
	[COMMINST] [bit] NULL,
	[GLNONSTKCR] [varchar](45) NULL,
	[ORDNUMBER] [varchar](22) NULL,
	[ORDDTLNUM] [int] NULL,
	[INDBTABLE] [bit] NULL,
	[REFRESH] [bit] NULL,
	[SHIPTRACK] [varchar](36) NULL,
	[SHIPVIA] [varchar](6) NULL,
	[VIADESC] [varchar](60) NULL,
	[DISCPER] [float] NULL,
	[MANITEMNO] [varchar](24) NULL,
	[CUSTITEMNO] [varchar](24) NULL,
	[VALUES] [int] NULL,
	[DDTLTYPE] [int] NULL,
	[DDTLNO] [varchar](6) NULL,
	[BUILDQTY] [float] NULL,
	[BUILDUNIT] [varchar](10) NULL,
	[BLDUNTCONV] [float] NULL,
	[NEXTCMPNUM] [int] NULL,
	[EPOSPROMID] [int] NULL,
	[BASEWUNIT] [varchar](10) NULL,
	[WEIGHTUNIT] [varchar](10) NULL,
	[WEIGHTCONV] [float] NULL,
	[PRWGHTUNIT] [varchar](10) NULL,
	[PRWGHTCONV] [float] NULL,
	[PRIBASWCNV] [float] NULL,
	[DEFUWEIGHT] [float] NULL,
	[DEFEXTWGHT] [float] NULL,
	[PRPRICEBY] [int] NULL,
	[CAPPROVEBY] [varchar](8) NULL,
	[HDRDISC] [float] NULL,
	[STRAMOUNT1] [float] NULL,
	[STRAMOUNT2] [float] NULL,
	[STRAMOUNT3] [float] NULL,
	[STRAMOUNT4] [float] NULL,
	[STRAMOUNT5] [float] NULL,
	[PSPRINTED] [bit] NULL,
	[COG] [float] NULL,
	[JOBRELATED] [bit] NULL,
	[CONTRACT] [varchar](16) NULL,
	[PROJECT] [varchar](16) NULL,
	[CCATEGORY] [varchar](16) NULL,
	[COSTCLASS] [int] NULL,
	[PROJSTYLE] [int] NULL,
	[PROJTYPE] [int] NULL,
	[REVREC] [int] NULL,
	[BILLTYPE] [int] NULL,
	[REVBILL] [varchar](45) NULL,
	[COGSWIP] [varchar](45) NULL,
	[RTGAMOUNT] [float] NULL,
	[RTGPERCENT] [float] NULL,
	[RTGDAYS] [int] NULL,
	[RTGAMTOVR] [bit] NULL,
	[RTGTXBASE1] [float] NULL,
	[RTGTXBASE2] [float] NULL,
	[RTGTXBASE3] [float] NULL,
	[RTGTXBASE4] [float] NULL,
	[RTGTXBASE5] [float] NULL,
	[RTGTXAMT1] [float] NULL,
	[RTGTXAMT2] [float] NULL,
	[RTGTXAMT3] [float] NULL,
	[RTGTXAMT4] [float] NULL,
	[RTGTXAMT5] [float] NULL,
	[PMTRANSNBR] [int] NULL,
	[PRICEOPT] [int] NULL,
	[ARITEMNO] [varchar](16) NULL,
	[ARUNIT] [varchar](10) NULL,
	[PAYMNTDIST] [float] NULL,
	[SERIALQTY] [int] NULL,
	[LOTQTY] [float] NULL,
	[SLITEM] [int] NULL,
	[COMPANYID] [int] NULL,
	[OPPOID] [int] NULL,
	[EXTSMOSTRE] [float] NULL,
	[EXTSSTDCOS] [float] NULL,
	[EXTSCOST1] [float] NULL,
	[EXTSCOST2] [float] NULL,
	[EXTSAVGCST] [float] NULL,
	[EXTSLSTCST] [float] NULL,
	[PCODDESC] [varchar](60) NULL,
	[CATGDESC] [varchar](60) NULL,
	[LOCDESC] [varchar](60) NULL,
	[TAUTH1DESC] [varchar](60) NULL,
	[TAUTH2DESC] [varchar](60) NULL,
	[TAUTH3DESC] [varchar](60) NULL,
	[TAUTH4DESC] [varchar](60) NULL,
	[TAUTH5DESC] [varchar](60) NULL,
	[TCLAS1DESC] [varchar](60) NULL,
	[TCLAS2DESC] [varchar](60) NULL,
	[TCLAS3DESC] [varchar](60) NULL,
	[TCLAS4DESC] [varchar](60) NULL,
	[TCLAS5DESC] [varchar](60) NULL,
	[GLNONSTKCD] [varchar](60) NULL,
	[EDCSHIMISC] [float] NULL,
	[ACTION] [int] NULL,
	[IPCID] [int] NULL,
	[FPOPSNQO] [bit] NULL,
	[FPOPSNQS] [bit] NULL,
	[POPUPSN] [int] NULL,
	[CLOSESN] [bit] NULL,
	[LTSETID] [int] NULL,
	[FPOPLTQO] [bit] NULL,
	[FPOPLTQS] [bit] NULL,
	[POPUPLT] [int] NULL,
	[CLOSELT] [bit] NULL,
	[ORDUNIQ] [float] NULL,
	[SERIALITEM] [bit] NULL,
	[UNFMTITEM] [varchar](24) NULL,
	[ORDLINENUM] [int] NULL,
	[PROCESSCMD] [int] NULL,
	[WUOMDESC] [varchar](60) NULL,
	[EXTNETPRI] [float] NULL,
	[DISSHIMISC] [float] NULL,
	[TAXTOTAL] [float] NULL,
	[STRTOTAL] [float] NULL,
	[LVL1NAME] [varchar](30) NULL,
	[LVL2NAME] [varchar](30) NULL,
	[LVL3NAME] [varchar](30) NULL,
	[UFMTCONTNO] [varchar](16) NULL,
	[NETPRIWTX] [float] NULL,
	[SHIDUE] [float] NULL,
	[XGENALCQTY] [float] NULL,
	[XLOTMAKQTY] [float] NULL,
	[XPERLOTQTY] [float] NULL,
	[SALLOCFROM] [varchar](40) NULL,
	[LALLOCFROM] [varchar](40) NULL,
	[METERHWND] [int] NULL
) ON [PRIMARY]



CREATE TABLE [dbo].[Shipment_Optional_Fields](
	[SHIUNIQ] [float] NULL,
	[OPTFIELD] [varchar](12) NULL,
	[VALUE] [varchar](60) NULL,
	[TYPE] [int] NULL,
	[LENGTH] [int] NULL,
	[DECIMALS] [int] NULL,
	[ALLOWNULL] [bit] NULL,
	[VALIDATE] [bit] NULL,
	[SWSET] [int] NULL,
	[VALINDEX] [int] NULL,
	[VALIFTEXT] [varchar](60) NULL,
	[VALIFMONEY] [float] NULL,
	[VALIFNUM] [float] NULL,
	[VALIFLONG] [int] NULL,
	[VALIFBOOL] [bit] NULL,
	[VALIFDATE] [datetime] NULL,
	[VALIFTIME] [datetime] NULL,
	[FDESC] [varchar](60) NULL,
	[VDESC] [varchar](60) NULL
) ON [PRIMARY]

go

CREATE TABLE [dbo].[Shipment_Detail_Serial_Numbers](
	[SHIUNIQ] [float] NULL,
	[LINENUM] [int] NULL,
	[SERIALNUMF] [varchar](40) NULL,
	[DETAILNUM] [int] NULL,
	[COST] [float] NULL,
	[QTY] [int] NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Shipment_Detail_Optional_Fields](
	[SHIUNIQ] [float] NULL,
	[LINENUM] [int] NULL,
	[OPTFIELD] [varchar](12) NULL,
	[VALUE] [varchar](60) NULL,
	[TYPE] [int] NULL,
	[LENGTH] [int] NULL,
	[DECIMALS] [int] NULL,
	[ALLOWNULL] [bit] NULL,
	[VALIDATE] [bit] NULL,
	[SWSET] [int] NULL,
	[VALINDEX] [int] NULL,
	[VALIFTEXT] [varchar](60) NULL,
	[VALIFMONEY] [float] NULL,
	[VALIFNUM] [float] NULL,
	[VALIFLONG] [int] NULL,
	[VALIFBOOL] [bit] NULL,
	[VALIFDATE] [datetime] NULL,
	[VALIFTIME] [datetime] NULL,
	[FDESC] [varchar](60) NULL,
	[VDESC] [varchar](60) NULL
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Shipment_Detail_Lot_Numbers](
	[SHIUNIQ] [float] NULL,
	[LINENUM] [int] NULL,
	[LOTNUMF] [varchar](40) NULL,
	[DETAILNUM] [int] NULL,
	[EXPIRYDATE] [datetime] NULL,
	[STKQTY] [float] NULL,
	[QTY] [float] NULL,
	[COST] [float] NULL
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Shipment_Comments_Instructions](
	[SHIUNIQ] [float] NULL,
	[UNIQUIFIER] [int] NULL,
	[DETAILNUM] [int] NULL,
	[COINTYPE] [int] NULL,
	[COIN] [varchar](80) NULL
) ON [PRIMARY]

GO


create table stock_balance
(
organization_no varchar(6) references organization(organization_no),			
store_no varchar(6) not null,				
sku varchar(24) not null,
quantity_on_hand decimal(15,3),			
cost decimal(15,2),
mininum_quantity decimal(15,3),			
maximum_quantity decimal(15,3),			
constraint  stock_balance_access_key unique(organization_no, store_no, sku )
)

GO

create table trans_stock
(
organization_no varchar(6) references organization(organization_no),			
store_no varchar(6) not null,				
sku varchar (24) not null,
quantity decimal(15,3) not null,
transaction_type smallint,
reference_number varchar(20) not null,			
transaction_time datetime,
constraint  trans_stock_access_key unique(organization_no, store_no, sku, reference_number)
)

GO




/* 3 Add_Dialog */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Dialog')
	BEGIN
		PRINT 'Dropping Procedure Add_Dialog'
		DROP  Procedure  Add_Dialog
	END

GO

PRINT 'Creating Procedure Add_Dialog'
GO
CREATE Procedure Add_Dialog
	@dialog_id int,
--	@config_no int,
	@help_id int,
--	@dialog_type int,
	@dialog_name varchar(50) 
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

insert into Dialog values
(
	@dialog_id,
--	@config_no,
	@help_id,
--	@dialog_type,
	@dialog_name 
)

return

GO




/* 4 Add_DialogEvent */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_DialogEvent')
	BEGIN
		PRINT 'Dropping Procedure Add_DialogEvent'
		DROP  Procedure  Add_DialogEvent
	END

GO

PRINT 'Creating Procedure Add_DialogEvent'

GO

CREATE Procedure Add_DialogEvent
	--@dialog_event_id int,
	@dialog_id int,
	@dialog_seq int,
	-- @help_id int,
	@dialog_desc varchar(50),
	@state int,
	@event_enabled int,
	@event_required int,
	@event_class varchar(100) 
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

insert into dialog_event values
(
--	@dialog_event_id,
	@dialog_id,
	@dialog_seq,
--	@help_id,
	@dialog_desc,
	@state,
	@event_enabled,
	@event_required,
	@event_class 
)

return


GO



/* Add_InputFilter */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Input_Filter')
	BEGIN
		PRINT 'Dropping Procedure Add_Input_Filter'
		DROP  Procedure  Add_Input_Filter
	END

GO

PRINT 'Creating Procedure Add_Input_Filter'
GO
CREATE Procedure Add_Input_Filter
	/* Param List */
	@filter_id int,
	@filter_type int,
	@filter_sub_type int,
	@filter_name varchar(50),
	@display_name varchar(50),
	@regex varchar(32),
	@check_digit_class varchar(100),
	@filter_class varchar(100)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into input_filter values
(
	@filter_id,
	@filter_type,
	@filter_sub_type,
	@filter_name,
	@display_name,
	@regex,
	@check_digit_class,
	@filter_class 
)
GO



/* Add_InputFilterField.sql */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Input_Filter_Field')
	BEGIN
		PRINT 'Dropping Procedure Add_Input_Filter_Field'
		DROP  Procedure  Add_Input_Filter_Field
	END

GO

PRINT 'Creating Procedure Add_Input_Filter_Field'
GO
CREATE Procedure Add_Input_Filter_Field
	/* Param List */
	@filter_id int,
	@sequence_no int,
	@name varchar(32)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into input_filter_field values 
(
@filter_id,
@sequence_no,
@name
)

GO











/* Add_PosParam */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_pos_param')
	BEGIN
		PRINT 'Dropping Procedure Add_pos_param'
		DROP  Procedure  Add_pos_param
	END

GO

PRINT 'Creating Procedure Add_pos_param'
GO
CREATE Procedure Add_pos_param
	/* Param List */
	@config_no int,
	@param_type int,
	@param_catogory int,
	@help_id int,
	@param_name varchar(30),
	@param_value varchar(100),
	@remarks varchar(100)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into pos_param values(
@config_no,
@param_type,
@param_catogory,
@help_id,
@param_name,
@param_value,
@remarks
)

GO

 

/* Add_Promotion */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Promotion')
	BEGIN
		PRINT 'Dropping Procedure Add_Promotion'
		DROP  Procedure  Add_Promotion
	END

GO

PRINT 'Creating Procedure Add_Promotion'
GO
CREATE Procedure Add_Promotion
	/* Param List */
	@organization_no varchar(6),
	@promotion_no int,
	@promotion_type int,
	@promotion_val1 int,
	@promotion_val2 int,
	@promotion_val3 int,
	@promotion_val4 int,
	@promotion_val5 int,
	@promotion_dval1 decimal(15,2),
	@promotion_dval2 decimal(15,2),
	@promotion_dval3 decimal(15,2),
	@promotion_dval4 decimal(15,2),
	@promotion_dval5 decimal(15,2),
	@print_before_item int,
	@valid_date_from datetime,
	@valid_date_to datetime,
	@promotion_string varchar(100),
	@promotion_class varchar(100)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into promotion values
(
@organization_no,
@promotion_no,
@promotion_type,
@promotion_val1,
@promotion_val2,
@promotion_val3,
@promotion_val4,
@promotion_val5,
@promotion_dval1,
@promotion_dval2,
@promotion_dval3,
@promotion_dval4,
@promotion_dval5,
@print_before_item,
@valid_date_from,
@valid_date_to,
@promotion_string,
@promotion_class
)



GO







/* Add Sub */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Sub')
	BEGIN
		PRINT 'Dropping Procedure Add_Sub'
		DROP  Procedure  Add_Sub
	END

GO

PRINT 'Creating Procedure Add_Sub'
GO
CREATE Procedure Add_Sub
	@subscriber_id int output,
	@subscriber_name varchar(32), 
	@subscriber_pass varchar(32)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into sub values
(
	@subscriber_name,
	@subscriber_pass
)


select @subscriber_id = max(subscriber_id) from sub

go




/* Load Sub by OrganizationId */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Sub_By_OrganizationId')
	BEGIN
		PRINT 'Dropping Procedure Load_Sub_By_OrganizationId'
		DROP  Procedure  Load_Sub_By_OrganizationId
	END

GO

PRINT 'Creating Procedure Load_Sub_By_OrganizationId'
GO
CREATE Procedure Load_Sub_By_OrganizationId
	@organization_id varchar(6)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select *  from sub as A, sub_map as B  where
A.subscriber_id = B.subscriber_id and B.organization_id = @organization_id 

go



/* Load All Sub */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_All_Sub')
	BEGIN
		PRINT 'Dropping Procedure Load_All_Sub'
		DROP  Procedure  Load_All_Sub
	END

GO

PRINT 'Creating Procedure Load_All_Sub'
GO
CREATE Procedure Load_All_Sub
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select *  from sub 
go






/* Add_sub_map */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Sub_Map')
	BEGIN
		PRINT 'Dropping Procedure Add_Sub_Map'
		DROP  Procedure  Add_Sub_Map
	END

GO

PRINT 'Creating Procedure Add_Sub_Map'
GO
CREATE Procedure Add_Sub_Map
	/* Param List */
	@subscriber_id int,
	@organization_id varchar(6),
	@subscriber_priv int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into sub_map
values
(
@subscriber_id,
@organization_id,
@subscriber_priv
)


GO





/* Add sub menus */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_SubMenu')
	BEGIN
		PRINT 'Dropping Procedure Add_SubMenu'
		DROP  Procedure  Add_SubMenu
	END

GO

PRINT 'Creating Procedure Add_SubMenu'
GO
CREATE Procedure Add_SubMenu
	@sub_menu_id	int,
	@menu_id		int,		
	@sub_menu_name	varchar(100) 
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

begin

	insert into sub_menu values
	(
		@sub_menu_id,
		@menu_id,
		@sub_menu_name
	)

return

end


GO








/* Add_total */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Total')
	BEGIN
		PRINT 'Dropping Procedure Add_Total'
		DROP  Procedure  Add_Total
	END

GO

PRINT 'Creating Procedure Add_Total'
GO
CREATE Procedure Add_Total
	/* Param List */
	@total_name int,
	@sequence_no int,
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_type int,
	@total_count int,
	@total_amount decimal(15,2)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
/** declare @count int

--select @count = count(total_id)  from total
--set @total_id = @count+1 **/

insert into total
values
(
@total_name,
@sequence_no,
@organization_no,
@store_no,
@pos_no,
@total_type,
@total_count,
@total_amount
)


GO





/* Add_trans */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans')
	BEGIN
		PRINT 'Dropping Procedure Add_Trans'
		DROP  Procedure  Add_Trans
	END

GO

PRINT 'Creating Procedure Add_Trans'
GO
CREATE Procedure Add_Trans
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@drawer_no int,
	@config_no int,
	@trans_type int,
	@state int,
	@reason_code int,
	@customer_tax_id varchar(50),
	@start_time datetime,
	@complete_time datetime,
	@employee_login_no varchar(32),
	@carry_out int,
	@training_mode int,
	@table_name varchar(3),
	@archive_date datetime,
	@upload_session_no varchar(22),
	@replication_date datetime
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into trans values
(
	@trans_no,
	@store_no,
	@organization_no,
	@pos_no,
	@drawer_no,
	@config_no,
	@trans_type,
	@state,
	@reason_code,
	@customer_tax_id,
	@start_time,
	@complete_time,
	@employee_login_no,
	@carry_out,
	@training_mode,
	@table_name,
	@archive_date,
	@upload_session_no,
	@replication_date
)



GO




/* Add_trans_promotion */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans_Promotion')
	BEGIN
		PRINT 'Dropping Procedure Add_Trans_Promotion'
		DROP  Procedure  Add_Trans_Promotion
	END

GO

PRINT 'Creating Procedure Add_Trans_Promotion'
GO
CREATE Procedure Add_Trans_Promotion
	/* Param List */
	@trans_no int,
	@seq_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@line_no int,
	@promotion_no int,
	@promotion_type int,
	@promotion_amount decimal(15,2),
	@promotion_quantity decimal(15,3),
	@reason_code int,
	@promotion_data varchar(100),
	@promotion_desc varchar(100),
	@state int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into trans_promotion values
(
@trans_no,
@seq_no,
@store_no,
@organization_no,
@pos_no,	
@line_no,
@promotion_no,
@promotion_type,
@promotion_amount,
@promotion_quantity,
@reason_code,
@promotion_data,
@promotion_desc,
@state
)
GO

 

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_TransBank')
	BEGIN
		PRINT 'Dropping Procedure Add_TransBank'
		DROP  Procedure  Add_TransBank
	END

GO

PRINT 'Creating Procedure Add_TransBank'
GO
CREATE Procedure Add_TransBank
	/* Param List */
	@trans_no int,
	@seq_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@pay_type int,
	@deposit_no int,
	@state int,
	@drawer_no int,
	@bank_desc varchar(100),
	@locale_language varchar(2),
	@locale_country varchar(2),
	@amount decimal(15,2) 
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into trans_bank values
(
@trans_no,
@seq_no,
@store_no,
@organization_no,
@pos_no,
@pay_type,
@deposit_no,
@state,
@drawer_no,
@bank_desc,
@locale_language,
@locale_country,
@amount 
)
GO


/* Add Trans Item */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans_item')
	BEGIN
		PRINT 'Dropping Procedure Add_Trans_item'
		DROP  Procedure  Add_Trans_item
	END

GO

PRINT 'Creating Procedure Add_Trans_item'
GO
CREATE Procedure Add_Trans_item
	/* Param List */
	@trans_no int,
	@seq_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@line_no int,
	@sku varchar(24),
	@sku_link varchar(24),
	@quantity decimal(15,3),
	@amount decimal(15,2),
	@ext_amount decimal(15,2),
	@weight decimal(15,2),
	@item_desc varchar(100),
	@state int,
	@reason_code int,
	@tax_exempt int,
	@tax_incl int,
	@var_amount decimal(15,2)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into trans_item values
(
@trans_no,
@seq_no,
@store_no,
@organization_no,
@pos_no,
@line_no,
@sku,
@sku_link,
@quantity,
@amount,
@ext_amount,
@weight,
@item_desc,
@state,
@reason_code,
@tax_exempt,
@tax_incl,
@var_amount
)

GO


/* Add_TransTax */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_TransTax')
	BEGIN
		PRINT 'Dropping Procedure Add_TransTax'
		DROP  Procedure  Add_TransTax
	END

GO

PRINT 'Creating Procedure Add_TransTax'
GO
CREATE Procedure Add_TransTax
	/* Param List */
	@trans_no int,
	@seq_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@line_no int,
	@tax_id int,
	@tax_desc varchar(30),
	@rate decimal(15,2),
	@taxable_amount decimal(15,2),
	@tax_amount decimal(15,2),
	@state int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into trans_tax
values
(
@trans_no,
@seq_no,
@line_no,
@store_no,
@organization_no,
@pos_no,
@tax_id,
@tax_desc,
@rate,
@taxable_amount,
@tax_amount,
@state
)


GO

 



/* Add TransTender */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans_tender')
	BEGIN
		PRINT 'Dropping Add_Trans_tender'
		DROP  Procedure Add_Trans_tender
	END
 
GO

PRINT 'Creating Procedure Add_Trans_tender'
GO
CREATE Procedure Add_Trans_tender
	/* Param List */
	@trans_no int,
	@seq_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@tendertype int,
	@amount decimal(15,2),
	@change_amount decimal(15,2),
	@tender_desc varchar(100),
	@change_desc varchar(100),
	@locale_language varchar(2),
	@locale_country varchar(2),
	@data_capture varchar(100),
	@state int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

insert into trans_tender values
(
@trans_no,
@seq_no,
@store_no,
@organization_no,
@pos_no,
@tendertype,
@amount,
@change_amount,
@tender_desc,
@change_desc,
@locale_language,
@locale_country,
@data_capture,
@state
)



GO






/* Load All items by SKU */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_All_Items')
	BEGIN
		PRINT 'Dropping Procedure Load_All_Items'
		DROP  Procedure  Load_All_Items
	END

GO

PRINT 'Creating Procedure Load_All_Items'
GO
CREATE Procedure Load_All_Items
	/* Param List */
	@sku varchar(24),
	@organization_no varchar(6)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from item
where sku like  @sku and organization_no = @organization_no



GO


/*Load BOMao */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_BoMap_By_Parent')
	BEGIN
		PRINT 'Dropping Procedure Load_BoMap_By_Parent'
		DROP  Procedure  Load_BoMap_By_Parent
	END

GO

PRINT 'Creating Procedure Load_BoMap_By_Parent'
GO
CREATE Procedure Load_BoMap_By_Parent
	/* Param List */
	@parent_bo_id int,
	@pobj_type int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

Select * from bo_map where parent_bo_id = @parent_bo_id
and pobj_type = @pobj_type

GO






/* Load Bu_by_BUid */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Bu_By_Buid')
	BEGIN
		PRINT 'Dropping Procedure Load_Bu_By_Buid'
		DROP  Procedure  Load_Bu_By_Buid
	END

GO

PRINT 'Creating Procedure Load_Bu_By_Buid'
GO
CREATE Procedure Load_Bu_By_Buid
	/* Param List */
	@bu_id int,
	@bu_desc varchar(32) output,
	@create_date datetime output 
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select 
@bu_id = bu_id,
@bu_desc = bu_desc,
@create_date = create_date
from bu 
where bu_id = @bu_id


return 


GO



/* Load Currency code*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_CurrencyCode_By_Pos_Key')
	BEGIN
		PRINT 'Dropping Procedure Load_CurrencyCode_By_Pos_Key'
		DROP  Procedure  Load_CurrencyCode_By_Pos_Key
	END

GO

PRINT 'Creating Procedure Load_CurrencyCode_By_Pos_Key'
GO
CREATE Procedure Load_CurrencyCode_By_Pos_Key
	/* Param List */

	@currency_code varchar(3) output,
	@currency_name varchar(60) output,
	@symbol varchar(4) output,
	@decimals int output,
	@symbol_position int output,
	@thousand_seperator varchar(1) output,
	@decimal_seperator varchar(1) output,
	@negative_display int output,
	@pos_key_number int
	AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
  

select
@currency_code  = currency_code,
@currency_name = currency_name,
@symbol  = symbol,
@decimals = decimals,
@symbol_position  = symbol_position,
@thousand_seperator  = thousand_seperator,
@decimal_seperator = decimal_seperator,
@negative_display = negative_display,
@pos_key_number  = pos_key_number
from currency_code where  pos_key_number  = @pos_key_number

GO





/* Load Currency */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Currency_By_Currency_code_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Currency_By_Currency_code_id'
		DROP  Procedure  Load_Currency_By_Currency_code_id
	END

GO

PRINT 'Creating Procedure Load_Currency_By_Currency_code_id'
GO
CREATE Procedure Load_Currency_By_Currency_code_id
	/* Param List */

	@home_currency varchar(3),
	@source_currency varchar(3),
	@rate_date datetime,
	@conversion_rate decimal(15,7) output,
	@spread decimal(15,7) output,
	@date_match datetime output,
	@rate_operator smallint output
	AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
  

select
@conversion_rate = conversion_rate,
@spread  = spread,
@date_match  = date_match,
@rate_operator = rate_operator
from currency where  home_currency = @home_currency and @source_currency=source_currency
and [dbo].[ufn_GetDateOnly](rate_date) <= @rate_date

GO



/* Load dialog by config no */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog'
		DROP  Procedure  Load_Dialog
	END

GO

PRINT 'Creating Procedure Load_Dialog'
GO
CREATE Procedure Load_Dialog
	--@config_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from dialog 

--return

GO




/* Load dialog by dialog name */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog_By_DialogName')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog_By_DialogName'
		DROP  Procedure  Load_Dialog_By_DialogName
	END

GO

PRINT 'Creating Procedure Load_Dialog_By_DialogName'
GO
CREATE Procedure Load_Dialog_By_DialogName
	@dialog_id int output,
--	@config_no int,
--	@help_id	int output,
	@dialog_type int output,
	@dialog_name varchar(50) /* Param List */
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select 
	@dialog_id = dialog_id,
--	@config_no = config_no,
--	@help_id = help_id,
	@dialog_type = dialog_type,
	@dialog_name =	dialog_name	
	from dialog 
where dialog_name = @dialog_name 


GO


/* Load Dialog Events */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_DialogEvent_By_DialogID')
	BEGIN
		PRINT 'Dropping Procedure Load_DialogEvent_By_DialogID'
		DROP  Procedure  Load_DialogEvent_By_DialogID
	END

GO

PRINT 'Creating Procedure Load_DialogEvent_By_DialogID'
GO
CREATE Procedure Load_DialogEvent_By_DialogID
	@dialog_id int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from dialog_event where dialog_id = @dialog_id
order by dialog_id, dialog_seq

--return
 
GO


  
/* Load Employee logon */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Employee_by_Logon')
	BEGIN
		PRINT 'Dropping Procedure Stored_Procedure_Name'
		DROP  Procedure  Load_Employee_by_Logon
	END

GO

PRINT 'Creating Procedure Load_Employee_by_Logon'
GO


/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
Create Proc Load_Employee_by_Logon 
(
@organization_no varchar(6),
@employee_no varchar(20) output,
@logon_no 		varchar(32) ,
@logon_pass	 	varchar(32) output,
@role_id		varchar(12)  output,
@fname 			varchar(40) output,
@lname			varchar(40) output,
@mi     	   	varchar(10) output,
@ssn 			varchar(10) output,
@sal_grade		int output
)

as 

begin

	select 
	@employee_no = employee_no,
	@logon_no = logon_no,
	@logon_pass = logon_pass,
	@role_id = role_id,
	@fname =	fname,
	@lname = lname,
	@mi = mi,
	@ssn = ssn,
	@sal_grade = sal_grade	
	from employee 
where logon_no = @logon_no	and organization_no = @organization_no

return 

end





GO




/* Load input filter */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Input_Filter_By_Filter_Type')
	BEGIN
		PRINT 'Dropping Procedure Load_Input_Filter_By_Filter_Type'
		DROP  Procedure  Load_Input_Filter_By_Filter_Type
	END

GO

PRINT 'Creating Procedure Load_Input_Filter_By_Filter_Type'
GO
CREATE Procedure Load_Input_Filter_By_Filter_Type
	/* Param List */
	@filter_type int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from input_filter where filter_type = @filter_type

GO



/* Load Input filter field */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Input_Filter_Field_By_Filter_Id')
	BEGIN
		PRINT 'Dropping Procedure Load_Input_Filter_Field_By_Filter_Id'
		DROP  Procedure  Load_Input_Filter_Field_By_Filter_Id
	END

GO

PRINT 'Creating Procedure Load_Input_Filter_Field_By_Filter_Id'
GO
CREATE Procedure Load_Input_Filter_Field_By_Filter_Id
	/* Param List */
	@filter_id int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from input_filter_field where filter_id = @filter_id


GO


/* Load items by description */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Item_By_Desc')
	BEGIN
		PRINT 'Dropping Procedure Load_Item_By_Desc'
		DROP  Procedure  Load_Item_By_Desc
	END

GO

PRINT 'Creating Procedure Load_Item_By_Desc'
GO
CREATE Procedure Load_Item_By_Desc
	/* Param List */
	@short_desc varchar(60),
	@organization_no varchar(6)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from item
where short_desc like  @short_desc
and organization_no = @organization_no
order by short_desc


GO



/* Load Items by PLU */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Item_By_Plu')
	BEGIN
		PRINT 'Dropping Procedure Load_Item_By_Plu'
		DROP  Procedure  Load_Item_By_Plu
	END

GO

PRINT 'Creating Procedure Load_Item_By_Plu'
GO
CREATE Procedure Load_Item_By_Plu
	/* Param List */
	@organization_no varchar(6),
	@sku	 		varchar(24) output,
	@short_desc		varchar(60) output,
	@amount			decimal(15,2) output,
	@dept			varchar(5) output,
	@item_group		varchar(5) output,
	@tax_group_id 		varchar(12) output,
	@pricing_opt	smallint output,
	@active_date	datetime output, 
	@deactive_date	datetime output,
	@tax_inclusive	smallint output,
	@tax_exempt		smallint output,
	@catogory		varchar(6) output,
	@shipping_uom	VARCHAR(10) output,
	@plu			varchar(24)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

begin


select 
	@organization_no = organization_no,
	@sku = item.sku,
	@short_desc = short_desc,
	@amount = amount,
	@dept = dept,
	@item_group = item_group,
	@tax_group_id = tax_group_id,
	@pricing_opt = pricing_opt,
	@active_date = active_date, 
	@deactive_date = deactive_date,
	@tax_inclusive = tax_inclusive,
	@tax_exempt = tax_exempt,
	@catogory = catogory,
	@shipping_uom = shipping_uom,
	@plu = plu
from  item
where plu = @plu 
and organization_no = @organization_no
order by short_desc

return

end


GO



/* Load Item by SKU */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Item_By_SKU')
	BEGIN
		PRINT 'Dropping Procedure Load_Item_By_SKU'
		DROP  Procedure  Load_Item_By_SKU
	END

GO

PRINT 'Creating Procedure Load_Item_By_SKU'
GO
CREATE Procedure Load_Item_By_SKU
	@organization_no 		varchar(6),
	@sku	 				varchar(24),
	@short_desc				varchar(60) output,
	@amount					decimal(15,2) output,
	@dept					varchar(5) output,
	@item_group				varchar(5) output,
	@tax_group_id 			varchar(12) output,
	@pricing_opt			smallint output,
	@active_date			datetime output, 
	@deactive_date			datetime output,
	@tax_inclusive			smallint output,
	@tax_exempt				smallint output,
	@catogory				varchar(6) output,
	@shipping_uom			varchar(10) output,
	@plu					varchar(24) output
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

begin


select 
	@organization_no = organization_no,
	@sku = sku,
	@short_desc = short_desc,
	@amount = amount,
	@dept = dept,
	@item_group = item_group,
	@tax_group_id = tax_group_id,
	@pricing_opt = pricing_opt,
	@active_date = active_date, 
	@deactive_date = deactive_date,
	@tax_inclusive = tax_inclusive,
	@tax_exempt = tax_exempt,
	@catogory = catogory,
	@shipping_uom = shipping_uom,
	@plu   = plu
from  item
where sku = @sku
and organization_no = @organization_no


return

end

GO



/* Load Menu Config by Menu Id */
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Menu_Config_By_Menu_Id')
	BEGIN
		PRINT 'Dropping Procedure Load_Menu_Config_By_Menu_Id'
		DROP  Procedure  Load_Menu_Config_By_Menu_Id
	END

GO

PRINT 'Creating Procedure Load_Menu_Config_By_Menu_Id'
GO
CREATE Procedure Load_Menu_Config_By_Menu_Id
	/* Param List */
	@config_no int,
	@menu_id int 
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
begin 

select * from
menu_config
where 
config_no = @config_no and
menu_id = @menu_id  

return

end

GO




/* Load Menu Panels */
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Menu_Panels_By_Config_no')
	BEGIN
		PRINT 'Dropping Procedure Stored_Procedure_Name'
		DROP  Procedure  Load_Menu_Panels_By_Config_no
	END

GO

PRINT 'Creating Procedure Load_Menu_Panels_By_Config_no'
GO
CREATE Procedure Load_Menu_Panels_By_Config_no
	/* Param List */
	@config_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/


select * 
from 
menu_panels
where config_no = @config_no

return

GO




/*Load Menus by Config no */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Menus_By_Config_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Menus_By_Config_No'
		DROP  Procedure  Load_Menus_By_Config_No
	END

GO

PRINT 'Creating Procedure Load_Menus_By_Config_No'
GO
CREATE Procedure Load_Menus_By_Config_No
	@config_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select *
from menu_root
where config_no = @config_no


GO




/* Load Pos Config By Config Name */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Pos_Config_By_Config_Name')
	BEGIN
		PRINT 'Dropping Procedure Load_Pos_Config_By_Config_Name'
		DROP  Procedure  Load_Pos_Config_By_Config_Name
	END

GO

PRINT 'Creating Procedure Load_Pos_Config_By_Config_Name'
GO
CREATE Procedure Load_Pos_Config_By_Config_Name
	/* Param List */
	@config_no int output,
	@name varchar(50)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select
@config_no = config_no,
@name = name
from pos_config
where name = @name


GO




/* Load Pos Param */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_pos_param')
	BEGIN
		PRINT 'Dropping Procedure Load_pos_param'
		DROP  Procedure  Load_pos_param
	END

GO

PRINT 'Creating Procedure Load_pos_param'
GO
CREATE Procedure Load_pos_param
	/* Param List */
	@config_no int,
	@param_type int output,
	@param_catogory int output,
	@help_id int output,
	@param_name varchar(30),
	@param_value varchar(100) output,
	@remarks varchar(100) output
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select 
@config_no = config_no,
@param_type = param_type,
@param_catogory = param_catogory,
@help_id = help_id,
@param_name = param_name,
@param_value = param_value,
@remarks = remarks
from pos_param
where 
param_name = @param_name and config_no = @config_no


GO



/* Load pos param by config no */
 
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_pos_param_by_config_no')
	BEGIN
		PRINT 'Dropping Procedure Load_pos_param_by_config_no'
		DROP  Procedure  Load_pos_param_by_config_no
	END

GO

PRINT 'Creating Procedure Load_pos_param_by_config_no'
GO
CREATE Procedure Load_pos_param_by_config_no
	/* Param List */
	@config_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select *
from pos_param
where config_no = @config_no


GO






/* Load pos Total */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Pos_Total')
	BEGIN
		PRINT 'Dropping Procedure Load_Pos_Total'
		DROP  Procedure  Load_Pos_Total
	END

GO

PRINT 'Creating Procedure Load_Pos_Total'
GO
CREATE Procedure Load_Pos_Total
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_name int,
	@sequence_no int output,
	@emp_id int output,
	@drawer_no int output,
	@start_date datetime output,
	@end_date datetime output
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select 
@sequence_no = sequence_no,
@emp_id = emp_id,
@drawer_no = drawer_no,
@start_date = start_date,
@end_date = end_date
from pos_total
where store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no
and total_name = @total_name
and end_date = 0



GO






/* Load Pos Config */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PosConfig_by_Name')
	BEGIN
		PRINT 'Dropping Procedure Load_PosConfig_by_Name'
		DROP  Procedure Load_PosConfig_by_Name  
	END

GO

PRINT 'Creating Procedure Load_PosConfig_by_Name'
GO
CREATE Procedure Load_PosConfig_by_Name
	/* Param List */
	@config_no int output,
	@name varchar(50),
	@retail_store_group_id int output
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select config_no=@config_no, name = @name, retail_store_group_id = @retail_store_group_id 
from pos_config
where @name = name

GO

/* Load posConfig by ConfigNo */



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PosConfig_by_ConfigNo')
	BEGIN
		PRINT 'Dropping Procedure Load_PosConfig_by_ConfigNo'
		DROP  Procedure Load_PosConfig_by_ConfigNo  
	END

GO

PRINT 'Creating Procedure Load_PosConfig_by_ConfigNo'
GO
CREATE Procedure Load_PosConfig_by_ConfigNo
	/* Param List */
	@config_no int,
	@name varchar(50)output
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select config_no=@config_no, name = @name
from pos_config
where @config_no = config_no

GO




/* Load Pos Key */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PosKey_By_Panel_id')
	BEGIN
		PRINT 'Dropping Procedure Load_PosKey_By_Panel_id'
		DROP  Procedure  Load_PosKey_By_Panel_id
	END

GO

PRINT 'Creating Procedure Load_PosKey_By_Panel_id'
GO
CREATE Procedure Load_PosKey_By_Panel_id
@config_no int,
@panel_id	int

AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/



begin

select *
from pos_key 
where panel_id  = @panel_id	and config_no = @config_no

return 

end


GO




/* Load Promotion by Promotion number */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Promotion_By_Promotion_No')
	BEGIN
		PRINT 'Dropping Load_Promotion_By_Promotion_No'
		DROP  Procedure  Load_Promotion_By_Promotion_No
	END

GO

PRINT 'Creating Procedure Load_Promotion_By_Promotion_No'
GO
CREATE Procedure Load_Promotion_By_Promotion_No
	/* Param List */
	@organization_no varchar(6),
	@promotion_no int,
	@promotion_type int output,
	@promotion_val1 int output,
	@promotion_val2 int output,
	@promotion_val3 int output,
	@promotion_val4 int output,
	@promotion_val5 int output,
	@promotion_dval1 decimal(15,2) output,
	@promotion_dval2 decimal(15,2) output,
	@promotion_dval3 decimal(15,2) output,
	@promotion_dval4 decimal(15,2)  output,
	@promotion_dval5 decimal(15,2) output,
	@print_before_item int output,
	@valid_date_from datetime output,
	@valid_date_to datetime output,
	@promotion_string varchar(100) output,
	@promotion_class varchar(100) output
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select 

	@organization_no = organization_no,
	@promotion_no = promotion_no,
	@promotion_type = promotion_type,
	@promotion_val1 = promotion_val1,
	@promotion_val2  = promotion_val2,
	@promotion_val3  = promotion_val3,
	@promotion_val4  = promotion_val4,
	@promotion_val5 = promotion_val5,
	@promotion_dval1 = promotion_dval1,
	@promotion_dval2 = promotion_dval2,
	@promotion_dval3 = promotion_dval3,
	@promotion_dval4 = promotion_dval4,
	@promotion_dval5 = promotion_dval5,
	@print_before_item = print_before_item,
	@valid_date_from = valid_date_from,
	@valid_date_to  = valid_date_to,
	@promotion_string = promotion_string,
	@promotion_class  = promotion_class
	
from promotion where @promotion_no = promotion_no and @organization_no=organization_no	

GO



/* Load Promotion Map */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PromotionMap_By_Map')
	BEGIN
		PRINT 'Dropping Procedure Load_PromotionMap_By_Map'
		DROP  Procedure  Load_PromotionMap_By_Map
	END

GO

PRINT 'Creating Procedure Load_PromotionMap_By_Map'
GO
CREATE Procedure Load_PromotionMap_By_Map
	/* Param List */
	@organization_no varchar(6),
	@promotion_map varchar(20)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select * from promotion_map where promotion_map = @promotion_map and organization_no = @organization_no



GO






/* Load Retail Store by Retail Store Id */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Retail_Store_By_Retail_Store_no')
	BEGIN
		PRINT 'Dropping Procedure Load_RetailStore_By_Retail_Store_no'
		DROP  Procedure  Load_Retail_Store_By_Retail_Store_no
	END

GO

PRINT 'Creating Procedure Load_Retail_Store_By_Retail_Store_no'

GO

CREATE Procedure Load_Retail_Store_By_Retail_Store_no
	/* Param List */ 
	@store_no varchar(6),
	@organization_no varchar(6),
	@store_name varchar(60) output,
	@address1	varchar(60)	output,					
	@address2	varchar(60)	output,
	@address3	varchar(60)	output,
	@address4	varchar(60)	output,
	@city		varchar(30)	output,
	@state		varchar(30) output,
	@zip		varchar(20) output,
	@country	varchar(30) output,
	@phone		varchar(30)	output,
	@fax		varchar(30)	output,
	@contact	varchar(60)	output,
	@email		varchar(50) output,
	@customer_tax_id	varchar(50) output,
	@last_trans_no	int		output
AS
/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select 
	@store_no = store_no,
	@store_name = store_name,
	@address1 = address1,
	@address2 = address2,
	@address3 = address3,
	@address4 = address4,
	@city = city,
	@state = state,
	@zip = zip,
	@country = country,
	@phone = phone,
	@fax = fax,
	@contact = contact,
	@email = email,
	@customer_tax_id = customer_tax_id,
	@last_trans_no = last_trans_no	
	from retail_store 
where store_no = @store_no 
and organization_no = @organization_no

return

GO
 




/* Save Retail Store */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Save_Retail_Store_By_Retail_store_no')
	BEGIN
		PRINT 'Dropping Procedure Save_Retail_Store_By_Retail_store_no'
		DROP  Procedure  Save_Retail_Store_By_Retail_store_no
	END

GO

PRINT 'Creating Procedure Save_Retail_Store_By_Retail_store_no'
GO
CREATE Procedure Save_Retail_Store_By_Retail_store_no
	/* Param List */
	@store_no varchar(6),
	@organization_no varchar(6),
	@last_trans_no	int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
update retail_store
set  
last_trans_no = @last_trans_no	
where store_no = @store_no
and organization_no = @organization_no



GO




/* Load subsriber by subscriber name */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Sub_By_Subscriber_Name')
	BEGIN
		PRINT 'Dropping Procedure Load_Sub_By_Subscriber_Name'
		DROP  Procedure  Load_Sub_By_Subscriber_Name
	END

GO

PRINT 'Creating Procedure Load_Sub_By_Subscriber_Name'
GO
CREATE Procedure Load_Sub_By_Subscriber_Name
	/* Param List */
	@subscriber_id int output,
	@subscriber_name varchar(32),
	@subscriber_pass varchar(32) output
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select 
@subscriber_id = subscriber_id,
@subscriber_name = subscriber_name,
@subscriber_pass = subscriber_pass 
from sub
where 
@subscriber_name = subscriber_name



GO



/*Load sub map by Subscriber */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Sub_Map_By_Subsriberid')
	BEGIN
		PRINT 'Dropping Procedure Load_Sub_Map_By_Subsriberid'
		DROP  Procedure  Load_Sub_Map_By_Subsriberid
	END

GO

PRINT 'Creating Procedure Load_Sub_Map_By_Subsriberid'
GO
CREATE Procedure Load_Sub_Map_By_Subsriberid
	/* Param List */
	@subscriber_id int
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from sub_map where subscriber_id = @subscriber_id


GO


/*Load sub menu by menuid */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_SubMenu_By_MenuID')
	BEGIN
		PRINT 'Dropping Procedure Load_SubMenu_By_MenuID'
		DROP  Procedure  Load_SubMenu_By_MenuID
	END

GO

PRINT 'Creating Procedure Load_SubMenu_By_MenuID'
GO
CREATE Procedure Load_SubMenu_By_MenuID
	@menu_id		int		
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
-- begin

	select 
		* 
	from sub_menu
	where menu_id = @menu_id
	
	
-- return
-- end 
GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Tax_By_Tax_Group_Id')
	BEGIN
		PRINT 'Dropping Procedure Load_Tax_By_Tax_Group_Id'
		DROP  Procedure  Load_Tax_By_Tax_Group_Id
	END

GO

PRINT 'Creating Procedure Load_Tax_By_Tax_Group_Id'
GO
CREATE Procedure Load_Tax_By_Tax_Group_Id
	/* Param List */
	@tax_group_id varchar(12),
	@organization_no varchar(6)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select * from tax
where tax_group_id = @tax_group_id and organization_no = @organization_no

GO




/* Load Tax group by config no */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Tax_Group_By_Organization_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Tax_Group_By_Organization_id'
		DROP  Procedure  Load_Tax_Group_By_Organization_id
	END

GO

PRINT 'Creating Procedure Load_Tax_Group_By_Organization_id'
GO
CREATE Procedure Load_Tax_Group_By_Organization_id
	/* Param List */
	@organization_no varchar(6)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from tax_group
where organization_no = @organization_no


GO





/* Load totals by total id*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Total_By_Total_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Total_By_Total_id'
		DROP  Procedure  Load_Total_By_Total_id
	END

GO

PRINT 'Creating Procedure Load_Total_By_Total_id'
GO
CREATE Procedure Load_Total_By_Total_id
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@sequence_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from total
where sequence_no = @sequence_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no


GO








/* Load trans bank by trans id */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Bank_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Bank_By_Trans_no'
		DROP  Procedure  Load_Trans_Bank_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_Trans_Bank_By_Trans_no'
GO
CREATE Procedure Load_Trans_Bank_By_Trans_no
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select * from trans_bank where trans_no = @trans_no 
and store_no = @store_no and organization_no = @organization_no and pos_no = @pos_no


GO



/* Load Trans by Trans no */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_By_Trans_no'
		DROP  Procedure  Load_Trans_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_Trans_By_Trans_no'
GO
CREATE Procedure Load_Trans_By_Trans_no
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int output,
	@drawer_no int output,
	@config_no int output,
	@trans_type int output,
	@state int output,
	@reason_code int output,
	@customer_tax_id varchar(50) output,
	@start_time datetime output,
	@complete_time datetime output,
	@employee_login_no varchar(32) output,
	@carry_out int output,
	@training_mode int output,
	@table_name varchar(3) output,
	@archive_date datetime output,
	@upload_session_no varchar(22) output,
	@replication_date datetime output
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select
	@trans_no = trans_no,
	@store_no  = store_no,
	@organization_no = organization_no,
	@pos_no = pos_no,
	@drawer_no =  drawer_no,
	@config_no = config_no,
	@trans_type =  trans_type,
	@state = state,
	@reason_code = reason_code,
	@customer_tax_id = customer_tax_id,
	@start_time = start_time,
	@complete_time = complete_time,
	@employee_login_no  = employee_login_no,
	@carry_out = carry_out,
	@training_mode = training_mode,
	@table_name = table_name,
	@archive_date = archive_date,
	@upload_session_no = upload_session_no,
	@replication_date = replication_date

from trans
where trans_no = @trans_no
and store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no


GO



/* Load Trans by State */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_By_State')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_By_State'
		DROP  Procedure  Load_Trans_By_State
	END

GO

PRINT 'Creating Procedure Load_Trans_By_State'
GO
CREATE Procedure Load_Trans_By_State
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@state int 
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from trans
where state = @state
and store_no = @store_no
and organization_no = @organization_no


GO


/* Load Trans by Table and State */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_By_Table_And_State')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_By_Table_And_State'
		DROP  Procedure  Load_Trans_By_Table_And_State
	END

GO

PRINT 'Creating Procedure Load_Trans_By_Table_And_State'
GO
CREATE Procedure Load_Trans_By_Table_And_State
	/* Param List */
		
	@trans_no int output,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int output,
	@drawer_no int output,
	@config_no int output,
	@trans_type int output,
	@state int,
	@reason_code int output,
	@customer_tax_id varchar(50) output,
	@start_time datetime output,
	@complete_time datetime output,
	@employee_login_no varchar(32)  output,
	@carry_out int output,
	@training_mode int output,
	@table_name varchar(3),
	@archive_date datetime output,
	@upload_session_no varchar(22) output,
	@replication_date datetime output
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select
	@trans_no = trans_no,
	@store_no  = store_no,
	@organization_no = organization_no,
	@pos_no = pos_no,
	@drawer_no =  drawer_no,
	@config_no = config_no,
	@trans_type =  trans_type,
	@state = state,
	@reason_code = reason_code,
	@customer_tax_id = customer_tax_id,
	@start_time = start_time,
	@complete_time = complete_time,
	@employee_login_no  = employee_login_no,
	@carry_out = carry_out,
	@training_mode = training_mode,
	@table_name = table_name,
	@archive_date = archive_date,
	@upload_session_no = upload_session_no,
	@replication_date = replication_date
from trans
where state = @state
and store_no = @store_no
and organization_no = @organization_no
and table_name = @table_name

GO




/* Load Trans Promotion by Trans id */ 

 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Promotion_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Promotion_By_Trans_no'
		DROP  Procedure  Load_Trans_Promotion_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_Trans_Promotion_By_Trans_no'
GO
CREATE Procedure Load_Trans_Promotion_By_Trans_no
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from trans_promotion where trans_no = @trans_no and store_no = @store_no
and organization_no = @organization_no and pos_no = @pos_no


GO




/* Load Trans Tax */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Tax_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Tax_By_Trans_no'
		DROP  Procedure  Load_Trans_Tax_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_Trans_Tax_By_Trans_no'
GO
CREATE Procedure Load_Trans_Tax_By_Trans_no
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@pos_no int,
	@organization_no varchar(6)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from trans_tax where trans_no = @trans_no and store_no = @store_no
and organization_no = @organization_no and pos_no = @pos_no

GO





/* Update_Trans_Tax */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_TransTax')
	BEGIN
		PRINT 'Dropping Procedure Update_TransTax'
		DROP  Procedure  Update_TransTax
	END

GO

PRINT 'Creating Procedure Update_TransTax'
GO
CREATE Procedure Update_TransTax
	/* Param List */
	@trans_no int,
	@seq_no int,
	@store_no varchar(6),
	@pos_no int,
	@organization_no varchar(6),
	@taxable_amount decimal(20,2),
	@tax_amount decimal(10,2),
	@state int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

update trans_tax
set 
taxable_amount = @taxable_amount,
tax_amount = @tax_amount,
state = @state
where trans_no = @trans_no and seq_no = @seq_no and store_no = @store_no and
organization_no = @organization_no and pos_no = @pos_no

GO




/* Load Trans Tender */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Tender_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Tender_By_Trans_no'
		DROP  Procedure  Load_Trans_Tender_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_Trans_Tender_By_Trans_no'
GO
CREATE Procedure Load_Trans_Tender_By_Trans_no
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select * from trans_tender where trans_no = @trans_no
and store_no = @store_no and organization_no = @organization_no and pos_no = @pos_no 


GO

 

/* Load Trans Item */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_TransItem_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_TransItem_By_Trans_no'
		DROP  Procedure  Load_TransItem_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_TransItem_By_Trans_no'
GO
CREATE Procedure Load_TransItem_By_Trans_no
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select * from trans_item
where trans_no = @trans_no and store_no = @store_no and organization_no = @organization_no and pos_no = @pos_no



GO


/* Add Trans Text */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_trans_text')
	BEGIN
		PRINT 'Dropping Procedure Add_trans_text'
		DROP  Procedure  Add_trans_text
	END

GO

PRINT 'Creating Procedure Add_trans_text'
GO
CREATE Procedure Add_trans_text
	/* Param List */
	@trans_no int,
	@seq_no int,
	@line_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@text_line_no int,
	@extended_text varchar(60)
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into trans_text values
(
@trans_no,
@seq_no,
@line_no,
@store_no,
@organization_no,
@pos_no,
@text_line_no,
@extended_text
)

GO



/* Load Trans Text */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_text_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_text_By_Trans_no'
		DROP  Procedure  Load_Trans_text_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_Trans_text_By_Trans_no'
GO
CREATE Procedure Load_Trans_text_By_Trans_no
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select * from trans_text
where trans_no = @trans_no and store_no = @store_no
and organization_no = @organization_no and pos_no = @pos_no


GO








/* Update Total */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Total')
	BEGIN
		PRINT 'Dropping Procedure Update_Total'
		DROP  Procedure  Update_Total
	END

GO

PRINT 'Creating Procedure Update_Total'
GO
CREATE Procedure Update_Total
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_name int,
	@total_type int,
	@total_amount decimal(15,2)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

declare  @seq int
declare  @totalid int
declare @count int


select  @seq = sequence_no from pos_total where store_no = @store_no and organization_no = @organization_no and end_date = 0 and total_name = @total_name

    if (@seq is not null) 

    	begin
    	
      		select @count = total_count  from total where sequence_no = @seq and  store_no = @store_no and organization_no = @organization_no and total_type = @total_type and total_name = @total_name
      		
      		if ( @count is not null ) 
      			begin
      			
        			update total set total_count = total_count + 1, total_amount = total_amount + @total_amount  where sequence_no = @seq and store_no = @store_no and organization_no = @organization_no and total_type = @total_type and total_name = @total_name
        		
      			end
      		else
      			begin
        		
        			insert into total values (@total_name, @seq, @organization_no, @store_no, @pos_no, @total_type, 1, @total_amount)
        			
      			end
        
   		end
   		
    else
    	
    	begin
    		
			select @seq =  MAX(sequence_no) from pos_total where store_no = @store_no and organization_no = @organization_no and total_name = @total_name
			if (@seq is null)
				begin
					set @seq =1
				end
			else
				begin
					set @seq = @seq+1
				end
			insert into pos_total values (@total_name, @seq, @organization_no, @store_no, @pos_no, 0, 0, GetDate(), 0)
      		insert into total values (@total_name, @seq, @organization_no, @store_no, @pos_no,  @total_type, 1, @total_amount) 
       	
       	end






GO






/* Update total amount count */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_total_Amount_Count')
	BEGIN
		PRINT 'Dropping Procedure Update_total_Amount_Count'
		DROP  Procedure  Update_total_Amount_Count
	END

GO

PRINT 'Creating Procedure Update_total_Amount_Count'
GO
CREATE Procedure Update_total_Amount_Count
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_name int,
	@total_type int,
	@total_count int,
	@total_amount decimal(15,2)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
declare @seq int
declare @count int

  begin

    select @seq = sequence_no from pos_total where store_no = @store_no and organization_no = @organization_no and end_date = 0 and total_name = @total_name
    
    if (@seq is not null) 
   
    begin
    
      select @count = total_count  from total where sequence_no = @seq and  store_no = @store_no and organization_no = @organization_no and total_type = @total_type  and total_name = @total_name
    
      if (@count > 0)
            
      begin
      
        update total set total_count = total_count + @total_count,  total_amount = total_amount + @total_amount where sequence_no = @seq and store_no = @store_no and organization_no = @organization_no and total_type = @total_type and total_name = @total_name
        
        --update total set total_amount = total_amount + @total_amount where pos_total_id = @postotalid and total_type = @total_type
      
      end
      
      else
      
      begin
      
        insert into total values ( @total_name, @seq, @organization_no, @store_no, @pos_no, @total_type, @total_count, @total_amount)
      
      end
      
      return
      
    end

    else

    begin
    
      select @seq =  MAX(sequence_no) from pos_total where store_no = @store_no and organization_no = @organization_no and total_name = @total_name
	  if (@seq is null)
				begin
					set @seq =1
				end
			else
				begin
					set @seq = @seq+1
				end
	  insert into pos_total values (@total_name, @seq, @organization_no, @store_no, @pos_no, 0, 0, GetDate(), 0)
      insert into total values (@total_name, @seq, @organization_no, @store_no, @pos_no,  @total_type, @total_count, @total_amount)
      
      return
          
    end
    
  end 




GO



/* Update pos total end date */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_pos_total_end_date')
	BEGIN
		PRINT 'Dropping Procedure Update_pos_total_end_date'
		DROP  Procedure  Update_pos_total_end_date
	END

GO

PRINT 'Creating Procedure Update_pos_total_end_date'
GO
CREATE Procedure Update_pos_total_end_date
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_name int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

update pos_total set end_date = GetDate()
where organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and total_name = @total_name
and end_date = 0 



GO










/* Update trans state */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Trans_State')
	BEGIN
		PRINT 'Dropping Procedure Update_Trans_State'
		DROP  Procedure  Update_Trans_State
	END

GO

PRINT 'Creating Procedure Update_Trans_State'
GO
CREATE Procedure Update_Trans_State
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@state int 
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
Update trans set state = @state
where trans_no = @trans_no
and store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no

GO



/* Update Trans state and Type */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Trans_State_and_Type')
	BEGIN
		PRINT 'Dropping Procedure Update_Trans_State_and_Type'
		DROP  Procedure  Update_Trans_State_and_Type
	END

GO

PRINT 'Creating Procedure Update_Trans_State_and_Type'
GO
CREATE Procedure Update_Trans_State_and_Type
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@state int, 
	@trans_type int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

Update trans set state = @state, trans_type = @trans_type
where trans_no = @trans_no
and store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no




GO


/* Update trans customer */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Trans_Customer')
	BEGIN
		PRINT 'Dropping Procedure Update_Trans_Customer'
		DROP  Procedure  Update_Trans_Customer
	END

GO

PRINT 'Creating Procedure Update_Trans_Customer'
GO
CREATE Procedure Update_Trans_Customer
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@customer_tax_id varchar(50) 
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
Update trans set customer_tax_id = @customer_tax_id
where trans_no = @trans_no
and store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no

GO









/*
** Organization
*/




/* Load Organization */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Organization_By_Organization_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Organization'
		DROP  Procedure  Load_Organization_by_Organization_no
	END

GO

PRINT 'Creating Procedure Load_Organization_By_Organization_No'
GO
CREATE Procedure Load_Organization_By_Organization_No
	/* Param List */
@organization_no		varchar(6),
@organization_name	varchar(60) output,
@address1			varchar(60) output,
@address2			varchar(60) output,
@address3			varchar(60) output,
@address4			varchar(60) output,
@city				varchar(30) output,
@state				varchar(30) output,
@postal_code			varchar(20) output,
@country				varchar(30) output,
@phone				varchar(30) output,
@fax					varchar(30) output,
@contact				varchar(60) output,
@home_currency		varchar(3)  output,
@tax_number			varchar(40) output,
@pos_shipment_code_length		smallint	output,
@pos_shipment_prefix			varchar(6)	output,
@pos_shipment_next_number		bigint		output
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select 
@organization_no = organization_no,
@organization_name = organization_name,
@address1 = address1,
@address2 = address2,
@address3 = address3,
@address4 = address4,
@city	= city,
@state	= state,
@postal_code = postal_code,
@country	 = country,
@phone	= phone,
@fax		= fax,
@contact	= contact,
@home_currency = home_currency,
@tax_number	= tax_number,
@pos_shipment_code_length = pos_shipment_code_length,
@pos_shipment_prefix = pos_shipment_prefix,
@pos_shipment_next_number = pos_shipment_next_number
from organization where organization_no = @organization_no

GO









/* Dialogs */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog'
		DROP  Procedure  Load_Dialog
	END

GO

PRINT 'Creating Procedure Load_Dialog'
GO
CREATE Procedure Load_Dialog
	--@config_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from dialog 
--return

GO






IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog_By_DialogName')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog_By_DialogName'
		DROP  Procedure  Load_Dialog_By_DialogName
	END

GO

PRINT 'Creating Procedure Load_Dialog_By_DialogName'
GO
CREATE Procedure Load_Dialog_By_DialogName
	@dialog_id int output,
--	@config_no int,
--	@help_id	int output,
	@dialog_type int output,
	@dialog_name varchar(50) /* Param List */
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select 
	@dialog_id = dialog_id,
--	@config_no = config_no,
--	@help_id = help_id,
	@dialog_type = dialog_type,
	@dialog_name =	dialog_name	
	from dialog 
where dialog_name = @dialog_name 


GO






IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_DialogEvent_By_DialogID')
	BEGIN
		PRINT 'Dropping Procedure Load_DialogEvent_By_DialogID'
		DROP  Procedure  Load_DialogEvent_By_DialogID
	END

GO

PRINT 'Creating Procedure Load_DialogEvent_By_DialogID'
GO
CREATE Procedure Load_DialogEvent_By_DialogID
	@dialog_id int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from dialog_event where dialog_id = @dialog_id  
order by dialog_id, dialog_seq

 
GO





IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Employee_Role_Event')
	BEGIN
		PRINT 'Dropping Procedure Load_Employee_Role_Event'
		DROP  Procedure  Load_Employee_Role_Event
	END

GO


PRINT 'Creating Procedure Load_Employee_Role_Event'
GO

CREATE Procedure Load_Employee_Role_Event
	@role_id varchar(12),
	@organization_no varchar(6)
AS
/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------						-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------	--------		-------------------------------------------
**    
*******************************************************************************/
select * from employee_role_event
where role_id = @role_id and organization_no = @organization_no
GO


/* table Group */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Table_Group_By_Strore_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Table_Group_By_Strore_No'
		DROP  Procedure  Load_Table_Group_By_Strore_No
	END

GO

PRINT 'Creating Procedure Load_Table_Group_By_Strore_No'
GO
CREATE Procedure Load_Table_Group_By_Strore_No
	@organization_no varchar(6),
	@store_no varchar(6)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from table_group 
where organization_no = @organization_no  
and store_no = @store_no

 
GO


/* table_details */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Table_Details_By_Table_Group_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Table_Details_By_Table_Group_No'
		DROP  Procedure  Load_Table_Details_By_Table_Group_No
	END

GO

PRINT 'Creating Procedure Load_Table_Details_By_Table_Group_No'
GO
CREATE Procedure Load_Table_Details_By_Table_Group_No
	@organization_no varchar(6),
	@store_no varchar(6),
	@table_group_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from table_details 
where organization_no = @organization_no  
and store_no = @store_no
and table_group_no = @table_group_no

 
GO



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_customer_by_tax_id')
	BEGIN
		PRINT 'Dropping Procedure Load_customer_by_tax_id'
		DROP  Procedure  Load_customer_by_tax_id
	END

GO

CREATE PROCEDURE Load_customer_by_tax_id 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@tax_id varchar(50),
 	@customer_search_key varchar(20) output,
    @customer_first_name varchar(60) output,
    @customer_last_name varchar(60) output,
    @addr1 varchar(60) output,
    @addr2 varchar(60) output,
    @postel_code varchar(50) output,
    @city varchar(50) output,
    @region varchar(50) output,
    @country varchar(50) output,
    @phone varchar(30) output,
    @alt_phone varchar(30) output,
    @fax varchar(30) output,
    @email varchar(60) output,
    @card varchar(60) output,
    @notes varchar(100) output,
    @max_debt decimal output,
    @current_debt decimal output,
    @creation_date datetime output,
    @status int output,
	@customer_account_set varchar(6) output,
	@price_list_code varchar(6) output,
	@terms_code varchar(6) output,
	@rate_type varchar(2) output,
	@tax_group_code varchar(12) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select 
@organization_no = organization_no, 
@tax_id = tax_id,
@customer_search_key  = customer_search_key,
@customer_first_name = customer_first_name,
@customer_last_name = customer_last_name, 
@addr1  = addr1,
@addr2  = addr2,
@postel_code  = postel_code,
@city = city,
@region = region,
@country = country,
@phone  = phone,
@alt_phone  = alt_phone,
@fax  = fax,
@email = email,
@card = card,
@notes = notes,
@max_debt = max_debt,
@current_debt = current_debt,
@creation_date = creation_date,
@status = status,
@customer_account_set = customer_account_set,
@price_list_code = price_list_code,
@terms_code = terms_code,
@rate_type = rate_type,
@tax_group_code = tax_group_code	
from customer
where tax_id = @tax_id
and organization_no = @organization_no
and status =1

END


GO


-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_customer_by_search_key')
	BEGIN
		PRINT 'Dropping Procedure Load_customer_by_search_key'
		DROP  Procedure  Load_customer_by_search_key
	END

GO

CREATE PROCEDURE Load_customer_by_search_key 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@customer_search_key varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select *  
from customer
where customer_search_key like @customer_search_key
and organization_no = @organization_no
and status =1

END


GO




-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_customer_current_debt')
	BEGIN
		PRINT 'Dropping Procedure Update_customer_current_debt'
		DROP  Procedure  Update_customer_current_debt
	END

GO

CREATE PROCEDURE Update_customer_current_debt 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@tax_id varchar(20),
	@current_debt decimal(15,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update customer  
set current_debt = @current_debt
where tax_id = @tax_id
and organization_no = @organization_no
and status =1

END


GO




-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_item_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_item_state'
		DROP  Procedure  Update_trans_item_state
	END

GO

CREATE PROCEDURE Update_trans_item_state 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@seq_no int,
	@store_no varchar(6),
	@pos_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_item  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and seq_no = @seq_no

END


GO



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_tax_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_tax_state'
		DROP  Procedure  Update_trans_tax_state
	END

GO

CREATE PROCEDURE Update_trans_tax_state 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@seq_no int,
	@store_no varchar(6),
	@pos_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_tax  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and seq_no = @seq_no

END


GO



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_promotion_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_promotion_state'
		DROP  Procedure  Update_trans_promotion_state
	END

GO

CREATE PROCEDURE Update_trans_promotion_state 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@seq_no int,
	@store_no varchar(6),
	@pos_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_promotion  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and seq_no = @seq_no

END


GO


-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_tender_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_tender_state'
		DROP  Procedure  Update_trans_tender_state
	END

GO

CREATE PROCEDURE Update_trans_tender_state 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@seq_no int,
	@store_no varchar(6),
	@pos_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_tender  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and seq_no = @seq_no

END


GO



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_item_amounts')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_item_amounts'
		DROP  Procedure  Update_trans_item_amounts
	END

GO

CREATE PROCEDURE Update_trans_item_amounts 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@seq_no int,
	@store_no varchar(6),
	@pos_no int,
	@trans_no int,
	@amount decimal(15,2), 
	@ext_amount decimal(15,2)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_item  
set amount = @amount, ext_amount = @ext_amount
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and seq_no = @seq_no
and state = 1

END


GO





IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Tran_Tax_By_Trans_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Tran_Tax_By_Trans_No'
		DROP  Procedure  Load_Tran_Tax_By_Trans_No
	END

GO


CREATE Procedure [dbo].[Load_Tran_Tax_By_Trans_No]
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@trans_no int,
	@line_no int
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from trans_tax
where organization_no = @organization_no  
and store_no = @store_no
and pos_no = @pos_no
and trans_no = @trans_no
and line_no = @line_no
and state = 2

 
go



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_trans_for_Accpac_Shipment_Import')
	BEGIN
		PRINT 'Dropping Procedure Load_trans_for_Accpac_Shipment_Import'
		DROP  Procedure  Load_trans_for_Accpac_Shipment_Import
	END

GO

PRINT 'Creating Procedure Load_trans_for_Accpac_Shipment_Import'

GO
-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE Load_trans_for_Accpac_Shipment_Import 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(12), 
	@upload_session_no varchar(22)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	select  trans_item.trans_no, trans_item.line_no as sales_line, trans_item.seq_no, 
    trans_item.sku, item_desc, trans_item.quantity, 
	trans_item.amount, trans_item.ext_amount, trans_promotion.promotion_amount, 
	cast( [dbo].[ufn_GetDateOnly](start_time) as varchar(12 ) ) as sales_date,
	trans.store_no,	trans.customer_tax_id, trans.pos_no,
	item.catogory, item.shipping_uom,
	customer.customer_first_name, customer.customer_last_name, customer.addr1,
	customer.addr2, customer.postel_code, customer.city, customer.region,
	customer.country, customer.customer_account_set, customer.price_list_code,
	customer.terms_code, customer.rate_type, customer.tax_group_code
    from trans_item join trans 
    on (trans_item.trans_no = trans.trans_no and 
    trans_item.organization_no = trans.organization_no and 
    trans_item.store_no = trans.store_no and
	trans_item.pos_no = trans.pos_no ) 
    left outer join trans_promotion 
    on (trans_item.organization_no = trans_promotion.organization_no and trans_item.store_no = trans_promotion.store_no and trans_item.trans_no = trans_promotion.trans_no and trans_item.line_no = trans_promotion.line_no and trans_item.pos_no = trans_promotion.pos_no ) 
    left outer join retail_store on 
    (trans.store_no=retail_store.store_no and trans.organization_no = retail_store.organization_no ) 
    left outer join item on
	(trans_item.organization_no = item.organization_no and trans_item.sku = item.sku )
	left outer join customer on
	(trans.organization_no = customer.organization_no and trans.customer_tax_id = customer.tax_id)
	where trans.state = 2 
    and trans_item.state = 2 
	and trans.organization_no = @organization_no 
    and trans.upload_session_no = @upload_session_no 
    order by store_no, sales_date, trans.customer_tax_id, trans_item.trans_no, trans_item.line_no 
	



END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_retail_store_customer')
	BEGIN
		PRINT 'Dropping Procedure Load_retail_store_customer'
		DROP  Procedure  Load_retail_store_customer
	END

GO

PRINT 'Creating Procedure Load_retail_store_customer'

GO
-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE Load_retail_store_customer 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(12), 
	@store_no varchar(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here

	select * from retail_store 
	left outer join  customer
	on( retail_store.organization_no = customer.organization_no and
	retail_store.customer_tax_id = customer.tax_id)
	where retail_store.organization_no = @organization_no 
    and retail_store.store_no = @store_no 
   
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_By_Upload_Session_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_By_Upload_Session_No'
		DROP  Procedure  Load_Trans_By_Upload_Session_No
	END

GO


CREATE Procedure [dbo].[Load_Trans_By_Upload_Session_No]
	@organization_no varchar(6),
	@upload_session_no varchar(22)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

select * from trans
where organization_no = @organization_no  
and upload_session_no = @upload_session_no
 
go




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_surcharge_by_surcharge_key')
	BEGIN
		PRINT 'Dropping Procedure Load_surcharge_by_surcharge_key'
		DROP  Procedure  Load_surcharge_by_surcharge_key
	END

GO

PRINT 'Creating Procedure Load_surcharge_by_surcharge_key'

GO
-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE Load_surcharge_by_surcharge_key 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@surcharge_code varchar(6) output,
	@surcharge_desc varchar(60) output,
	@amount decimal(15,2) output,
	@method smallint output,
	@surcharge_account varchar(45) output,
	@tax_group_id varchar(12) output,
	@tax_inclusive smallint output,
	@tax_exempt smallint output,
	@surcharge_key_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here

select 
@organization_no = organization_no, 
@surcharge_code =surcharge_code,
@surcharge_desc =surcharge_desc,
@amount = amount,
@method  = method,
@surcharge_account  = surcharge_account,
@tax_group_id  = tax_group_id,
@tax_inclusive = tax_inclusive,
@tax_exempt  = tax_exempt,
@surcharge_key_id  = surcharge_key_id
from surcharge 
where organization_no = @organization_no 
and surcharge_key_id = @surcharge_key_id 
   
END
GO




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_surcharge_by_surcharge_code')
	BEGIN
		PRINT 'Dropping Procedure Load_surcharge_by_surcharge_code'
		DROP  Procedure  Load_surcharge_by_surcharge_code
	END

GO

PRINT 'Creating Procedure Load_surcharge_by_surcharge_code'
GO


-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Load_surcharge_by_surcharge_code] 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@surcharge_code varchar(6),
	@surcharge_desc varchar(60) output,
	@amount decimal(15,2) output,
	@method smallint output,
	@surcharge_account varchar(45) output,
	@tax_group_id varchar(12) output,
	@tax_inclusive smallint output,
	@tax_exempt smallint output,
	@surcharge_key_id int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here

select 
@organization_no = organization_no, 
@surcharge_code =surcharge_code,
@surcharge_desc =surcharge_desc,
@amount = amount,
@method  = method,
@surcharge_account  = surcharge_account,
@tax_group_id  = tax_group_id,
@tax_inclusive = tax_inclusive,
@tax_exempt  = tax_exempt,
@surcharge_key_id  = surcharge_key_id
from surcharge 
where organization_no = @organization_no 
and surcharge_code = @surcharge_code 
   
END


go




/* Update stock balance */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_stock_balance')
	BEGIN
		PRINT 'Dropping Procedure Update_stock_balance'
		DROP  Procedure  Update_stock_balance
	END

GO

PRINT 'Creating Procedure Update_stock_balance'
GO
CREATE Procedure Update_stock_balance
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@sku varchar(24),
	@quantity decimal(15,3)
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
BEGIN
  begin try
	insert into stock_balance 
	values (@organization_no, @store_no, @sku, @quantity, 0, 0, 0 )
    
  end try	
  begin catch 	
	
	update stock_balance set quantity_on_hand = quantity_on_hand + @quantity 
	where organization_no = @organization_no and store_no = @store_no and sku = @sku
 
  end catch 

END


GO



/* Add Trans Stock */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_trans_stock')
	BEGIN
		PRINT 'Dropping Procedure Add_trans_stock'
		DROP  Procedure  Add_trans_stock
	END

GO

PRINT 'Creating Procedure Add_trans_stock'
GO
CREATE Procedure Add_trans_stock
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@sku varchar(24),
	@quantity decimal(15,3),
	@transaction_type smallint,
	@reference_number varchar(20),
	@transaction_time datetime
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
BEGIN
  	insert into trans_stock 
	values (@organization_no, @store_no, @sku, @quantity, @transaction_type, @reference_number, @transaction_time )
END    
GO










/****** Object:  UserDefinedFunction [dbo].[ufn_GetDateOnly]    Script Date: 06/21/2009 15:01:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ufn_GetDateOnly]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ufn_GetDateOnly]

go


CREATE FUNCTION [dbo].[ufn_GetDateOnly] ( @pInputDate    DATETIME )
RETURNS DATETIME
BEGIN

    RETURN CAST(YEAR(@pInputDate) AS VARCHAR(4)) + '/' +
           CAST(MONTH(@pInputDate) AS VARCHAR(2)) + '/' +
           CAST(DAY(@pInputDate) AS VARCHAR(2))

END
GO



/****** Object:  UserDefinedFunction [dbo].[ufn_Addition]    Script Date: 06/21/2009 15:03:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ufn_Addition]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ufn_Addition]

go



CREATE FUNCTION [dbo].[ufn_Addition](@Number1 Decimal(15,2), @Number2 Decimal(15,2))
RETURNS Decimal(15,2)
BEGIN
    --DECLARE @Result Decimal(15,2)
	if ( @Number1 IS NULL )	SET @Number1 = 0.0
 
	If (@Number2 IS NULL) set @Number2 = 0.0
    RETURN @Number1+@Number2
END


GO

 



print('ok1')
go

delete from menu_panels where config_no =  1
go

delete from pos_param 
go

delete from dialog_event 
go

delete from dialog 
go




delete from pos_config 
go

delete from pos

go

delete from currency_code
go

delete from currency
go


print 'delete OK'
go





insert into dialog values (1601,  1, 'Logon') 
go

insert into dialog_event values ( 1601, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1601, 3,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.NewLogon') 
go
insert into dialog_event values ( 1601, 4,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.LogOn') 
go



insert into dialog values (1602,  1, 'ManagerRequired') 
go


insert into dialog_event values ( 1602, 1,  null, 1005, 1, 1, 'EclipsePos.Apps.PosEvents.Error') 
go
insert into dialog_event values ( 1602, 2,  null, 29,   1, 1, 'EclipsePos.Apps.PosEvents.UserValidation') 
go
insert into dialog_event values ( 1602, 4,  null, 30,   1, 1, null) 
go
insert into dialog_event values ( 1602, 4,  null, 70,   1, 1, null) 
go



insert into dialog values (1603,   1, 'CashTender') 
go


insert into dialog_event values ( 1603, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1603, 2,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1603, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1603, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values ( 1603, 5,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjTender')
go
insert into dialog_event values ( 1603, 6,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.AutoRoundingAdjustment')
go
insert into dialog_event values ( 1603, 7,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


insert into dialog values (1604,  1, 'CheckTender') 
go



insert into dialog_event values (  1604, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1604, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1604, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1604, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1604, 6, null, 5, 1, 1, 'EclipsePos.Apps.EJournal.EjCheckTender')  
go
insert into dialog_event values (  1604, 7,  null, 2, 1, 1, null) 
go
insert into dialog_event values (  1604, 8,  null, 1, 1, 1, null) 
go
insert into dialog_event values (  1604, 9,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


insert into dialog values (1605,  1, 'CreditTender') 
go



insert into dialog_event values (  1605, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1605, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1605, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1605, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1605, 6,  null, 8, 1, 1, 'EclipsePos.Apps.EJournal.EjCCTender') 
go
insert into dialog_event values (  1605, 7,  null, 7, 1, 1, null) 
go
insert into dialog_event values (  1605, 10,  null, 11, 1, 1, null) 
go
insert into dialog_event values (  1605, 11,  null, 1, 1, 1, null) 
go
insert into dialog_event values (  1605, 12,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go




insert into dialog values (1606,  1, 'AltCurrTender') 
go



insert into dialog_event values (  1606, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1606, 2,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1606, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1606, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1606, 5,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjAltCurrTender') 
go



insert into dialog values (1607,  1, 'RecallEj') 
go


insert into dialog_event values (  1607, 1,  null, 5, 1, 1, 'EclipsePos.Apps.PosEvents.RecallEj') 
go
insert into dialog_event values (  1607, 2,  null, 2, 1, 1, null) 
go
insert into dialog_event values (  1607, 3,  null, 1, 1, 1, null) 
go



insert into dialog values (1608, 1, 'PaidIn') 
go


insert into dialog_event values (  1608, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1608, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1608, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1608, 5, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go
insert into dialog_event values (  1608, 6, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go

insert into dialog values (1609,  1, 'PaidOut') 
go


insert into dialog_event values (  1609, 1, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1609, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1609, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1609, 5,  null, 2, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go
insert into dialog_event values (  1609, 6, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go




insert into dialog values (1611, 1, 'PettyCash') 
go


insert into dialog_event values (  1611, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1611, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1611, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1611, 5,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go


insert into dialog values (1612, 1, 'UnLock') 
go



insert into dialog_event values (  1612, 1,  null, 2, 1, 1, 'EclipsePos.Apps.PosEvents.UnLock') 
go
insert into dialog_event values (  1612, 2,  null, 0, 1, 1, null) 
go



insert into dialog values (1613, 1, 'Customer') 
go



insert into dialog_event values (  1613, 1,  null, 2, 1, 1, 'EclipsePos.Apps.EJournal.EjCustomer') 
go
insert into dialog_event values (  1613, 2,  null, 1, 1, 1, null) 
go



insert into dialog values (1614, 1, 'DebtTender') 
go


insert into dialog_event values (  1614, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1614, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1614, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1614, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1614, 6,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjDebtTender') 
go
insert into dialog_event values (  1614, 7,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go



insert into dialog values (1615, 1, 'ReceiveOnAccount') 
go


insert into dialog_event values (  1615, 1,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjReceiveOnAccount') 
go
insert into dialog_event values (  1615, 2, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (  1615, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go



insert into dialog values (1616,  1, 'DebitCardTender') 
go


insert into dialog_event values (  1616, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1616, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1616, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1616, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1616, 6, null, 5, 1, 1, 'EclipsePos.Apps.EJournal.EjDebitCardTender')  
go
insert into dialog_event values (  1616, 7,  null, 2, 1, 1, null) 
go
insert into dialog_event values (  1616, 8,  null, 1, 1, 1, null) 
go
insert into dialog_event values (  1616, 9,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


INSERT INTO currency_code VALUES (  'ATS',  'Austrian Schilling',												 'AtS',	2,	1,	',',	'.',	3,  1)

go
          
INSERT INTO currency_code VALUES ('AUD',		'Australian Dollars',                                          	'$',   	2,	1,	',',	'.',	3,	2)

go

INSERT INTO currency_code VALUES ('BEF',		'Belgian Franc',                                               	'BeF', 	2,	1,	',',	'.',	3,	3)

go

INSERT INTO currency_code VALUES ('CAD',		'Canadian Dollars',                                            	'$',   	2,	1,	',',	'.',	3,	4)

go

INSERT INTO currency_code VALUES ('CHF',		'Swiss Francs',                                                	'SwF', 	2,	1,	',',	'.',	3,	5)

go

INSERT INTO currency_code VALUES ('CNY',		'Peoples Rep of China Renminbi' ,                             	'RMB', 	2,	1,	',',	'.',	3,	6)

go

INSERT INTO currency_code VALUES ('DEM',		'Deutsche Mark',                                               	'DM',  	2,	3,	',',	'.',	1,	7)
go

INSERT INTO currency_code VALUES ('ESP',		'Spanish Peseta',                                              	'Pta', 	2,	1,	',',	'.',	3,	8)
go
INSERT INTO currency_code VALUES ('EUR',		'Euro',                                                        	'€',   	2,	1,	',',	'.',	3,	9)
go
INSERT INTO currency_code VALUES ('FIM',		'Finnish Markka',                                              	'FiM', 	2,	1,	',',	'.',	3,	10)
go
INSERT INTO currency_code VALUES ('FJD',		'Fijian Dollars',                                              	'$',   	2,	2,	',',	'.',	3,	11)
go
INSERT INTO currency_code VALUES ('FRF',		'French Francs' ,                                              	'F',   	2,	1,	',',	'.',	3,	12)
go
INSERT INTO currency_code VALUES ('GBP',		'Pound Sterling',                                              	'£',   	2,	1,	',',	'.',	3,	13)
go
INSERT INTO currency_code VALUES ('GRD',		'Greek Drachma' ,                                              	'Dr',  	2,	1,	',',	'.',	3,	14)
go
INSERT INTO currency_code VALUES ('HKD',		'Hong Kong Dollars',                                           	'$',   	2,	1,	',',	'.',	3,	15)
go
INSERT INTO currency_code VALUES ('IDR',		'Indonesian Rupiah',                                           	'Rp.', 	0,	1,	'.',	',',	3,	16)
go
INSERT INTO currency_code VALUES ('IEP',		'Irish Punt',                                                  	'Ir£', 	2,	1,	',',	'.',	3,	17)
go
INSERT INTO currency_code VALUES ('ITL',		'Italian Lira',                                                	'L.',  	0,	1,	'.',	',',	3,	18)
go
INSERT INTO currency_code VALUES ('JPY',		'Japanese Yen',                                                	'¥',   	0,	1,	',',	'.',	3,	19)
go
INSERT INTO currency_code VALUES ('KIP',		'Laos Kip',                                                    	'KIP', 	2,	3,	',',	'.',	3,	20)
go
INSERT INTO currency_code VALUES ('LUF',		'Luxembourg Franc',                                            	'LuF', 	2,	1,	',',	'.',	3,	21)
go
INSERT INTO currency_code VALUES ('MXP',		'Mexican Pesos' ,                                              	'$',   	0,	1,	',',	'.',	3,	22)
go
INSERT INTO currency_code VALUES ('MYR',		'Malaysian Ringgit',                                           	'RM',  	2,	1,	',',	'.',	3,	23)
go
INSERT INTO currency_code VALUES ('NLG',		'Netherland Guilders',                                         	'f.',  	2,	1,	',',	'.',	3,	24)
go
INSERT INTO currency_code VALUES ('NTD',		'New Taiwan Dollar',                                           	'NT$', 	0,	1,	',',	'.',	2,	25)
go
INSERT INTO currency_code VALUES ('NZD',		'New Zealand Dollars' ,                                        	'$',   	2,	2,	',',	'.',	3,	26)		
go
INSERT INTO currency_code VALUES ('PGK',		'Papua New Guinea Kina',                                       	'K',   	2,	2,	',',	'.',	3,	27)
go
INSERT INTO currency_code VALUES ('PTE',		'Portuguese Escudo',                                           	'Esc.',	2,	1,	',',	'.',	3,	28)
go
INSERT INTO currency_code VALUES ('SGD',		'Singapore Dollars',                                           	'S$',  	2,	2,	',',	'.',	3,	29)
go
INSERT INTO currency_code VALUES ('SLR',		'Sri Lankan Rupees',                                           	'Rs.', 	2,	1,	',',	'.',	3,	30)
go
INSERT INTO currency_code VALUES ('THB',		'Thai Baht'        ,                                           	'ß',   	2,	3,	',',	'.',	3,	31)
go
INSERT INTO currency_code VALUES ('USD',		'U.S. Dollars'     ,                                           	'$ ',  	2,	1,	',',	'.',	3,	32)
go
INSERT INTO currency_code VALUES ('VND',		'Viet Nam Dong'    ,                                           	'VND', 	0,	1,	',',	'.',	3,	33)
go
INSERT INTO currency_code VALUES ('ZAR',		'South African Rand',                                          	'R',   	2,	2,	' ',	'.',	3,	34)
go


INSERT INTO pos_config
           ([config_no]
			,[name]
           )
  VALUES
           (1
			,'Retail'
           )

go



 -- Panel Classes
 
 insert into menu_panels values ( 1, 90, 'Common tasks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 1, 91, 'Discounts', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 1, 92, 'Miscellaneous', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 1, 93, 'Tender', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 1, 94, 'Manager tasks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 1, 95, 'Item Lookup', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 1, 96, 'Alt Currency', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 1, 97, 'Exit/Tools', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

 insert into menu_panels values ( 1, 991, 'Panel navigator', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
 go

insert into menu_panels values ( 1, 992, 'Cash Bills and Coins', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

insert into menu_panels values ( 1, 993, 'Card Types', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go



 
 
-- Navigator

insert into pos_key values (1, 991,	'Common Tasks',		1,   90 ,   112,	3,	20,		8,	48,		118,		90,		192,	90,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Common tasks', 'F1')
go
	  				
insert into pos_key values (1, 991,	'Discounts',		1,   91,   113,	3,	140,	8,  48,		118,		91,		192,	91,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Discounts', 'F2')
go

insert into pos_key values (1, 991,	'Miscellaneous',		1,   92,   114,	3,	260,	8,  48,		118,		93,		192,	92,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Miscellaneous', 'F3')
go

insert into pos_key values (1, 991,	'Tender',			1,   93,   115,	3,	380,	8,  48,		118,		94,		192,	93,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Tender', 'F4')
go

insert into pos_key values (1, 991,	'Manager',			1,   94,   116,	3,	500,	8,  48,		118,		95,		192,	94,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Manager', 'F5')
go

insert into pos_key values (1, 991,	'Search Items',		1,   95,   117,	3,	620,	8,  48,		118,		96,		192,	95,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Search Items', 'F7')
go

insert into pos_key values (1, 991,	'Alt Currency',		1,   96,   118,	3,	740,	8,  48,		118,		97,		192,	96,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Alt Currency', 'F8')
go
														  				
insert into pos_key values (1, 991,	'Exit',				1,   97,   119,	3,	860,	8,  48,		118,		98,		192,	97,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Exit', 'F9')
go

														  				
														  				
														  				
														  				
														  				
														  				



-- Common Tasks

insert into pos_key values (1, 90,	'Ctrl',		1,   3, 1001,		3,	170,		40,			48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Quantity','Quantity','F1')
go

insert into pos_key values (1, 90,	'Ctrl',		1,   0, 1002,		3,	170,		89,			48, 56,	91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Subtotal','Subtotal','F2')
go

insert into pos_key values (1, 90,	'Ctrl',		1,   1, 1003,		3,	170,		138,		48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Total','Total','F3')
go

insert into pos_key values (1, 90,	'Ctrl',		1,   0, 1004,		3,	170,		187,		48, 56, 93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ItemVoid','Void Item','F4')
go

insert into pos_key values (1, 90,	'Ctrl',		1,   0, 1005,		3, 170,			236,		48, 56, 94,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale','Void Sale','F5')
go

insert into pos_key values (1, 90,	'Ctrl',		1,   0, 1006,		3,  170,		285,		48, 56, 95,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.SaveEj', 'Save Invoice','F6')
go

insert into pos_key values (1, 90,	'Ctrl',		1,   0, 1007,		3,  170,		334,		48, 56, 96,	192,	131190,	null,1,'EclipsePos.Apps.PosEvents.RecallEj', 'Recall Invoice','F7')
go
insert into pos_key values (1, 90,	'Ctrl',		1,   0, 1008,		3, 170,			432,		48, 56, 97,	192,	131191,	null,1, 'EclipsePos.Apps.PosEvents.ReturnSale','Return Sale','F8')
go
insert into pos_key values (1, 90,	'Ctrl',		1,   0, 1009,		3, 170,			481,		48, 56, 98,	192,	131192,	null,1, 'EclipsePos.Apps.PosEvents.Customer','Customer','F9')
go





-- Discounts 

insert into pos_key values (1, 91,		'Ctrl',		1,   1,	1011,		3,  170,	40,			48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc. 10%','F1')
go

insert into pos_key values (1, 91,		'Ctrl',		1,   2,	1012,		3,  170,	89,			48, 56,	91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 20%','F2')
go

insert into pos_key values (1, 91,		'Ctrl',		1,   3,	1013,		3,  170,	138,		48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 30%','F3')
go

insert into pos_key values (1, 91,		'Ctrl',		1,   4,	1014,		3,  170,	187,		48, 56,	93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 40%','F4')
go

insert into pos_key values (1, 91,		'Ctrl',		1,   5,	1015,		3,  170,	236,		48, 56,	94,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 50%','F5')
go



-- Miscellaneous
insert into pos_key values (1, 92,		'Ctrl',		1,   0,		1021,		3,	170,	40,			48,  56,    95,	0,		131184,		null,	1,	'EclipsePos.Apps.PosEvents.PriceOverride', 'Change Price','F1')
go

insert into pos_key values (1, 92,		'Ctrl',		1,	 1,		1022,		3,  170,	89,			48, 56,		91,	50,		131185,		null,	1, 'EclipsePos.Apps.PosEvents.ExecScript', 'Calculator','F2')
go
insert into pos_key values (1, 92,		'Ctrl',		1,	 2,		1023,		3,  170,	138,		48, 56,		91,	50,		131186,		null,	1, 'EclipsePos.Apps.PosEvents.ExecScript', 'Notepad','F3')
go
insert into pos_key values (1, 92,		'Ctrl',		1,   0,		1024,		3, 170,		138,		48, 56,		93,	192,	131187,		null,	1, 'EclipsePos.Apps.PosEvents.ReceiveOnAccount','Receive On Acc','F4')
go





-- Tender
insert into pos_key values (1, 93,		'Ctrl' ,	1,  -1,  1031,		3, 170,			40,		48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.CashTender','Cash ','F1')
go

insert into pos_key values (1, 93,		'Ctrl',		1,   0,  1032,		3, 170,			89,		48, 56, 91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.CheckTender','Check ','F2')
go

insert into pos_key values (1, 93,		'Ctrl',		1,   0,  1033,		3, 170,			138,	48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.CreditTender','Credit Card ','F3')
go

insert into pos_key values (1, 93,		'Ctrl',		1,   0,  1034,		3, 170,			138,	48, 56,	93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.DebtTender','Debt','F4')
go



				 							 		  			


-- Manager
insert into pos_key values (1, 94,	'Ctrl',		1,   0,  1041,		3,  170,		40,		48, 56,		90,	100,	131184,		null,1,'EclipsePos.Apps.PosEvents.PaidIn', 'Paid In','F1')
go

insert into pos_key values (1, 94,	'Ctrl',		1,   0,  1042,		3,  170,		89,		48, 56,		91,	100,	131185,		null,1,'EclipsePos.Apps.PosEvents.PaidOut', 'Paid Out','F2')
go

insert into pos_key values (1, 94,	'Ctrl',		1,   0,	 1043,		3, 170,			138,	48, 56,		92,	50,		131186,		null,1, 'EclipsePos.Apps.PosEvents.TrainingMode', 'Training Mode','F3')
go
     				  		  		
insert into pos_key values (1, 94,	'Ctrl',		1,   1,	 1044,		3,	170,		187,	48,  56,	93,	25,		131187,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'X-Report','F4')
go

insert into pos_key values (1, 94,	'Ctrl',		1,   2,	 1045,		3,	170,		236,	48,  56,    94,	0,		131188,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'Z-Report','F5')
go







-- Exit
insert into pos_key values (1, 97,		'Ctrl',		1,   0,	1051,		3, 170,			89,			48, 56,0,	0,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Lock','Lock','F1')
go

insert into pos_key values (1, 97,		'Ctrl',		1,   2,	 1052,		3,  170,		40,			48, 56,90,0, 131185,null,1, 'EclipsePos.Apps.PosEvents.LogOff', 'Log Off','F2')
go

insert into pos_key values (1, 97,		'Ctrl',		1,  -1,	 1053,		3,  170,		89,			48, 56,91,50, 131186,null,1, 'EclipsePos.Apps.PosEvents.Exit', 'Shutdown','F3')
go

insert into pos_key values (1, 97,		'Ctrl',		1,   1,	 1054,		3,  170,		89,			48, 56,91,50, 131187,null,1, 'EclipsePos.Apps.PosEvents.SystemManager', 'System Manager','F4')
go






-- Item
insert into pos_key values (1, 95,	'Ctrl',		1,   1,		1061,		3, 170,			40,		48, 56,90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','Description ','F1')
go

insert into pos_key values (1, 95,	'Ctrl',		1,   2,		1062,		3, 170,			89,		48, 56,91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','SKU ','F2')
go

insert into pos_key values (1, 95,	'Ctrl',		1,   3,		1063,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','Department','F3')
go
   
insert into pos_key values (1, 95,	'Ctrl',		1,   4,		1064,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','Item Group','F4')
go
  													  		  



		  			
-- Alternate currency entry
insert into pos_key values (1, 96,	'Ctrl' ,		1,   1,		1071,	3,	 170,	40,   48,  56, 90,	0, 131184,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'US Dollar','F1')
go

insert into pos_key values (1, 96,	'Ctrl',			1,   2,		1072,	3,	170,	89,   48,  56, 91,	0, 131185,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Euro','F2')
go

insert into pos_key values (1, 96,	'Ctrl',			1,   3,		1073,	3,	170,	138,  48,  56, 92,	0, 131186,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Sterling Pound','F3')
go

insert into pos_key values (1, 96,	'Ctrl',			1,   4,		1074,	3,	170,	187,  48,  56, 93,	0, 131187,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Aust. Dollar','F4')
go

insert into pos_key values (1, 96,	'Ctrl',			1,   5,		1075,	3,	170,	236,  48,  56, 94,	25, 131188,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'HK Dollar','F5')
go

insert into pos_key values (1, 96,	'Ctrl',			1,   6,		1076,	3,	170,	285,  48,  56, 95,	25, 131189,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Yen','F6')
go
   													  				


-- Cash tender Notes/Coins
insert into pos_key values (1, 992,	'Ctrl' ,		1,   10000,		1091,	3,	 170,	40,   48,  56, 90,	0, 131184,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '100.00','F1')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   5000,		1092,	3,	170,	89,   48,  56, 91,	0, 131185,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '50.00','F2')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   1000,		1093,	3,	170,	138,  48,  56, 92,	0, 131186,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '10.00','F3')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   500,		1094,	3,	170,	187,  48,  56, 93,	0, 131187,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '5.00','F4')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   200,		1095,	3,	170,	236,  48,  56, 94,	0, 131188,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '2.00','F5')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   100,		1096,	3,	170,	285,  48,  56, 95,	0, 131189,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '1.00','F6')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   50,		1097,	3,	170,	334,  48,  56, 96,	0, 131190,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.50','F7')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   20,		1098,	3,	170,	383,  48,  56, 97,	0, 131191,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.20','F8')
go

insert into pos_key values (1, 992,	'Ctrl',			1,   10,		1099,	3,	170,	432,  48,  56, 98,	0, 131192,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.10','F9')
go



-- Credit card types
insert into pos_key values (1, 993,	'Ctrl' ,		1,   0,		1101,	3,	 170,	40,   48,  56, 90,	0, 131184, 'Visa.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'VISA','F1')
go

insert into pos_key values (1, 993,	'Ctrl',			1,   0,		1102,	3,	170,	89,   48,  56, 91,	0, 131185, 'MasterCard.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'MASTER','F2')
go

insert into pos_key values (1, 993,	'Ctrl',			1,   0,		1103,	3,	170,	138,  48,  56, 92,	0, 131186, 'Amex.gif',	 1,	'EclipsePos.Apps.PosEvents.MediaText', 'AMEX','F3')
go

insert into pos_key values (1, 993,	'Ctrl',			1,   0,		1104,	3,	170,	187,  48,  56, 93,	0, 131187, 'Discover.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'DISCOVER','F4')
go

insert into pos_key values (1, 993,	'Ctrl',			1,   0,		1105,	3,	170,	236,  48,  56, 94,	0, 131188,	null,	1,	'EclipsePos.Apps.PosEvents.MediaText', 'NETS','F5')
go




Print('Creating pos_param')
go

-- Line display
insert into pos_param values (1, 3, 1, 1, 'CustWelcome', 'Welcome', null) 
go



-- Customer receipt print
insert into pos_param values ( 1, 3, 2, 1, 'ReceiptTopMOD1', 'Biz Reg. No. 2567891555 W', null) 
go
insert into pos_param values ( 1, 3, 2, 2, 'ReceiptTopMOD2', 'GST Reg. No. ME-845234-7', null) 
go
insert into pos_param values ( 1, 3, 2, 3, 'ReceiptTopMOD3', '*** Enjoy 5% cash rebates ***', null) 
go
insert into pos_param values ( 1, 3, 2, 4, 'ReceiptTopMOD4', 'When you use POSB Everyday credit card', null) 
go
insert into pos_param values ( 1, 3, 2, 5, 'ReceiptBottomMOD', 'Thank you for shopping', null) 
go
insert into pos_param values ( 1, 3, 2, 6, 'TrxNo', 'TRX: ', null) 
go
insert into pos_param values ( 1, 3, 2, 7, 'PosNo', 'POS: ', null) 
go
insert into pos_param values ( 1, 3, 2, 12, 'ReceiptLogo', 'sample2.bmp', null) 
go
insert into pos_param values ( 1, 3, 2, 13, 'TaxIncludedText', 'GST    7%', null) 
go
insert into pos_param values ( 1, 3, 2, 14, 'TotalItemCountText', 'Item count', null) 
go
insert into pos_param values ( 1, 3, 2, 15, 'ConvertedAltCurrency', 'Converted total', null) 
go
insert into pos_param values ( 1, 3, 2, 16, 'AltCurrencyDescription', 'Alternate Currency Tender', null) 
go
insert into pos_param values ( 1, 3, 2, 17, 'Total', 'TOTAL', null) 
go
insert into pos_param values ( 1, 3, 2, 18, 'BalanceDue', 'Balance Due', null) 
go
insert into pos_param values ( 1, 3, 2, 19, 'CashTender', 'Cash Tender', null) 
go
insert into pos_param values ( 1, 3, 2, 20, 'CheckTender', 'Check Tender', null) 
go
insert into pos_param values ( 1, 3, 2, 21, 'CreditTender', 'Credit Card Tender', null)
go
insert into pos_param values ( 1, 3, 2, 22, 'Change', 'Change Due', null) 
go
insert into pos_param values ( 1, 3, 2, 23, 'TableText', 'Table No.', null) 
go
insert into pos_param values ( 1, 3, 2, 24, 'DebitCardTender', 'Debit Card Tender', null)
go
insert into pos_param values ( 1, 3, 2, 25, 'VoidSaleText', 'Void Sales', null)
go
insert into pos_param values ( 1, 1, 2, 26, 'LogoBitmapWidth', '200', null)
go


-- POS Workbench settings

insert into pos_param values ( 1, 3, 3, 1, 'TotalTax', 'Total Tax', null) 
go
insert into pos_param values ( 1, 3, 3, 2, 'SubTotal', 'SUBTOTAL', null) 
go
insert into pos_param values ( 1, 3, 3, 3, 'Discount', 'Discount', null) 
go
insert into pos_param values ( 1, 3, 3, 4, 'Markout', 'Markout', null) 
go
insert into pos_param values ( 1, 3, 3, 5, 'CashBack', 'Cash Back', null) 
go
insert into pos_param values ( 1, 3, 3, 6, 'PosTag', 'Register', null) 
go
insert into pos_param values ( 1, 3, 3, 7, 'EmpTag', 'Employee', null) 
go
insert into pos_param values ( 1, 3, 3, 8, 'DateTag', 'Time/Date', null) 
go
insert into pos_param values ( 1, 3, 3, 9, 'TrxTag', 'Transaction', null) 
go
insert into pos_param values ( 1, 3, 3, 10, 'QtyHeader', 'Qty', null) 
go
insert into pos_param values ( 1, 3, 3, 11, 'ItemHeader', 'Item', null) 
go
insert into pos_param values ( 1, 3, 3, 12, 'DescHeader', 'Description', null) 
go
insert into pos_param values ( 1, 3, 3, 13, 'PriceHeader', 'Price', null) 
go
insert into pos_param values ( 1, 3, 3, 14, 'ValueHeader', 'Value', null) 
go
insert into pos_param values ( 1, 3, 3, 15, 'SubtotalTag', 'Subtotal', null) 
go
insert into pos_param values ( 1, 3, 3, 16, 'TotalTaxTag', 'Tax', null) 
go
insert into pos_param values ( 1, 3, 3, 17, 'GrandTotal', 'Total', null) 
go
insert into pos_param values ( 1, 3, 3, 18, 'TenderedTag', 'Tendered', null) 
go
insert into pos_param values ( 1, 3, 3, 19, 'LineNumberHeader', 'Ln', null) 
go




-- POS Workbench operator prompt text
insert into pos_param values ( 1, 3, 4, 1, 'CloseDrawer', 'Close Cash Drawer', null) 
go
insert into pos_param values ( 1, 3, 4, 2, 'InsertCheck', 'Insert check', null) 
go
insert into pos_param values ( 1, 3, 4, 3, 'InsertValidation', 'Insert Validation', null) 
go
insert into pos_param values ( 1, 3, 4, 4, 'InsertCCValidation', 'Insert credit card receipt', null) 
go
insert into pos_param values ( 1, 3, 4, 5, 'BadName', 'Bad user ID, press clear', null) 
go
insert into pos_param values ( 1, 3, 4, 6, 'BadPass', 'Invalid password, press clear', null) 
go
insert into pos_param values ( 1, 3, 4, 7, 'InvalidCustomer', 'Invalid customer number, press clear', null) 
go
insert into pos_param values ( 1, 3, 4, 8, 'TooMany', 'Too many logon attempts, press clear', null) 
go
insert into pos_param values ( 1, 3, 4, 9, 'GoodLogin', 'Logon successful', null) 
go
insert into pos_param values ( 1, 3, 4, 10, 'OkText', 'OK', null) 
go
insert into pos_param values ( 1, 3, 4, 11, 'CancelText', 'Cancel', null) 
go
insert into pos_param values ( 1, 3, 4, 12, 'ClearText', 'Clear', null) 
go
insert into pos_param values ( 1, 3, 4, 13, 'InvalidInput', 'Invalid Input, press clear', null) 
go
insert into pos_param values ( 1, 3, 4, 14, 'PromptOpenAmount', 'Enter open amount: ', null) 
go
insert into pos_param values ( 1, 3, 4, 15, 'PromptAmount', 'Enter amount: ', null) 
go
insert into pos_param values ( 1, 3, 4, 16, 'PromptCashBack', 'Cash back amount:', null) 
go
insert into pos_param values ( 1, 3, 4, 17, 'ConfirmOpenAmount', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 1, 3, 4, 18, 'RegOpen', 'Register Open', null) 
go
insert into pos_param values ( 1, 3, 4, 19, 'ReturnSale', 'Return Sale', null) 
go
insert into pos_param values ( 1, 3, 4, 20, 'TotalRequired', 'Total Required, press clear', null) 
go
insert into pos_param values ( 1, 3, 4, 21, 'InsufficientFunds', 'Insufficient Funds, press clear', null) 
go
insert into pos_param values ( 1, 3, 4, 23, 'MgrIntervention', 'Manager intervention required', null) 
go
insert into pos_param values ( 1, 3, 4, 24, 'EnterUser', 'Enter User ID: ', null) 
go
insert into pos_param values ( 1, 3, 4, 25, 'EnterPass', 'Enter Password: ', null) 
go
insert into pos_param values ( 1, 3, 4, 26, 'PromptDrawerNo', 'Enter drawer number: ', null) 
go
insert into pos_param values ( 1, 3, 4, 27, 'ConfirmDrawerNo', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 1, 3, 4, 28, 'BadDrawerNo', 'Invalid drawer number', null) 
go
insert into pos_param values ( 1, 3, 4, 29, 'BadCheckNo', 'Invalid check number', null) 
go
insert into pos_param values ( 1, 3, 4, 30, 'BadCCNo', 'Invalid credit card', null) 
go
insert into pos_param values ( 1, 3, 4, 31, 'BadExpr', 'Bad expiration date', null) 
go
insert into pos_param values ( 1, 3, 4, 32, 'PromptCustomer', 'Enter Customer Number: ', null) 
go
insert into pos_param values ( 1, 3, 4, 33, 'VoidSale', 'Sale Voided, press enter', null) 
go
insert into pos_param values ( 1, 3, 4, 35, 'AltCurrTenderPrompt', 'Enter alternate currency amount: ', null) 
go
insert into pos_param values ( 1, 3, 4, 37, 'TenderTotal', 'Amount Tendered', null) 
go
insert into pos_param values ( 1, 3, 4, 38, 'TerminalLocked', 'Terminal locked, press enter', null) 
go
insert into pos_param values ( 1, 3, 4, 39, 'EnterItem', 'Enter item', null) 
go
insert into pos_param values ( 1, 3, 4, 40, 'EnterWeight', 'Enter weight', null) 
go
insert into pos_param values ( 1, 3, 4, 41, 'Pause', 'Press enter to continue...', null) 
go
insert into pos_param values ( 1, 3, 4, 42, 'CloseCash', 'Close cash drawer.', null) 
go
insert into pos_param values ( 1, 3, 4, 43, 'RecallFailed', 'Transaction not found', null) 
go
insert into pos_param values ( 1, 3, 4, 44, 'CashLimitExceeded', 'Cash in drawer limit exceeded', null) 
go
insert into pos_param values ( 1, 3, 4, 45, 'EnterNewPrice', 'Enter new price:', null) 
go
insert into pos_param values ( 1, 3, 4, 46, 'PosPrinterFailed', 'PRINTER FAILURE', null) 
go
insert into pos_param values ( 1, 3, 4, 47, 'PosPrinterError', 'Printer Error' , null) 
go
insert into pos_param values ( 1, 3, 4, 48, 'CashDrawerError', 'Cash Drawer Error', null) 
go
insert into pos_param values ( 1, 3, 4, 49, 'PosLineDisplayError', 'Line Display Error', null) 
go
insert into pos_param values ( 1, 3, 4, 50, 'ShutdownKeyNotAllowed', 'Shutdown Key Not Allowed', null) 
go
insert into pos_param values ( 1, 4, 4, 51, 'NavigateButtons', 'true', null) 
go
insert into pos_param values ( 1, 3, 4, 52, 'OperReceiptFont', 'Lucida Sans Typewriter Regular', null) 
go
insert into pos_param values ( 1, 3, 4, 53, 'HeaderFont', 'Courier', null) 
go
insert into pos_param values ( 1, 3, 4, 54, 'HeaderTitleFont', 'Helvetica', null) 
go
insert into pos_param values ( 1, 1, 4, 55, 'OperReceiptFontSize', '15', null) 
go
insert into pos_param values ( 1, 1, 4, 56, 'HeaderFontSize', '12', null) 
go
insert into pos_param values ( 1, 1, 4, 57, 'HeaderTitleFontSize', '14', null) 
go
insert into pos_param values ( 1, 3, 4, 58, 'PromptPosNo', 'Enter POS Number: ', null) 
go
insert into pos_param values ( 1, 3, 4, 59, 'PromptTransNo', 'Enter Transaction Number:', null) 
go
insert into pos_param values ( 1, 3, 4, 60, 'NoSaleCount', 'No sale transactions', null) 
go
insert into pos_param values ( 1, 3, 4, 61, 'TransNo', 'TRANS#', null) 
go
insert into pos_param values ( 1, 3, 4, 62, 'TransType', 'TRANS TYPE', null) 
go
insert into pos_param values ( 1, 3, 4, 63, 'OperLogon', 'Operator logon', null) 
go
insert into pos_param values ( 1, 3, 4, 64, 'OperLogoff', 'Operator logoff', null) 
go
insert into pos_param values ( 1, 3, 4, 65, 'BankTrans', 'Bank transaction', null) 
go
insert into pos_param values ( 1, 3, 4, 66, 'PromptCheckNo', 'Enter check number:', null) 
go
insert into pos_param values ( 1, 3, 4, 67, 'PromptCCNo', 'Enter credit card number:', null) 
go
insert into pos_param values ( 1, 3, 4, 68, 'PromptCCExpr', 'Enter expiration data:', null) 
go
insert into pos_param values ( 1, 3, 4, 69, 'Confirm', 'Press enter', null) 
go
insert into pos_param values ( 1, 3, 4, 85, 'OverMeiaLimit', 'Over Media Limit', null) 
go
insert into pos_param values ( 1, 3, 4, 86, 'UnderMediaLimit', 'Under Media Limit', null) 
go
insert into pos_param values ( 1, 3, 4, 87, 'ReturnSalePrompt', 'Return Sale', null) 
go
insert into pos_param values ( 1, 3, 4, 89, 'SalePrompt', 'Sales Transaction', null) 
go
insert into pos_param values ( 1, 3, 4, 90, 'DineInPrompt', 'Dine In', null) 
go
insert into pos_param values ( 1, 3, 4, 91, 'CarryOutPrompt', 'Take Away', null) 
go
insert into pos_param values ( 1, 3, 4, 92, 'InsufficientUserAuthority', 'Insufficient User Authority', null) 
go
insert into pos_param values ( 1, 3, 4, 93, 'TableNumberPrompt', 'Enter Table no', null) 
go
insert into pos_param values ( 1, 3, 4, 94, 'PromptItemPrice', 'Enter Item Price', null) 
go
insert into pos_param values ( 1, 3, 4, 95, 'PriceChangeNotAllowed', 'Price change not allowed', null) 
go
insert into pos_param values ( 1, 3, 4, 96, 'SelectCustomer', 'Select customer and try again', null) 
go
insert into pos_param values ( 1, 3, 4, 97, 'InsufficientCreditLimit', 'Insufficient credit limit', null) 
go
insert into pos_param values ( 1, 3, 4, 98, 'DebtTender', 'Debt Tender', null) 
go
insert into pos_param values ( 1, 3, 4, 99, 'InvalidFunction', 'Invalid operation', null) 
go
insert into pos_param values ( 1, 3, 4, 100, 'PromptCardName', 'Enter card name and Press Enter', null) 
go
insert into pos_param values ( 1, 3, 4, 101, 'PromptEnterLineNumber', 'Enter Line no.', null) 
go














-- Terminal reports
insert into pos_param values ( 1, 3, 5, 1, 'NonTaxCount', 'Non-Tax transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 2, 'NonTaxAmount', 'Non-Tax amount', null) 
go
insert into pos_param values ( 1, 3, 5, 3, 'TaxCount', 'Tax transactions ', null) 
go
insert into pos_param values ( 1, 3, 5, 4, 'TaxAmount', 'Tax amount ', null) 
go
insert into pos_param values ( 1, 3, 5, 5, 'VoidCount', 'Void transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 6, 'VoidAmount', 'Void amount', null) 
go
insert into pos_param values ( 1, 3, 5, 7, 'ReturnCount', 'Return transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 8, 'ReturnAmount', 'Return amount', null) 
go
insert into pos_param values ( 1, 3, 5, 9, 'CouponCount', 'Coupon transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 10, 'CouponAmount', 'Coupon amount', null) 
go
insert into pos_param values ( 1, 3, 5, 11, 'CreditCount', 'Credit transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 12, 'CreditAmount', 'Credit amount', null) 
go
insert into pos_param values ( 1, 3, 5, 13, 'CheckCount', 'Check transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 14, 'CheckAmount', 'Check amount', null) 
go
insert into pos_param values ( 1, 3, 5, 15, 'RecdOnAcctCount', 'Received on account transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 16, 'RecdOnAcctAmount', 'Received on account amount', null) 
go
insert into pos_param values ( 1, 3, 5, 17, 'PaidInCount', 'Paid in transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 18, 'PaidInAmount', 'Paid in Amount', null) 
go
insert into pos_param values ( 1, 3, 5, 19, 'PaidOutCount', 'Paid out transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 20, 'PaidOutAmount', 'Paid out Amount', null) 
go
insert into pos_param values ( 1, 3, 5, 21, 'CashSalesCount', 'Cash sales transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 22, 'CashSalesAmount', 'Cash sales Amount', null) 
go
insert into pos_param values ( 1, 3, 5, 23, 'CashInDrCount', 'Cash transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 24, 'CashInDrAmount', 'Cash in drawer Amount', null) 
go
insert into pos_param values ( 1, 3, 5, 25, 'LoanCount', 'Loan transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 26, 'LoanAmount', 'Loans amount', null) 
go
insert into pos_param values ( 1, 3, 5, 27, 'PickupCount', 'Pickup transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 28, 'PickupAmount', 'Pickup amount', null) 
go
insert into pos_param values ( 1, 3, 5, 29, 'CashBackCount', 'Cash back transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 30, 'CashBackAmount', 'Cash back Amount', null) 
go
insert into pos_param values ( 1, 3, 5, 31, 'DailyXHeader', 'X-Daily Report', null) 
go
insert into pos_param values ( 1, 3, 5, 32, 'DailyZHeader', 'Z-Daily Report', null)
go
insert into pos_param values ( 1, 3, 5, 33, 'WeeklyXHeader', 'X-Weekly Report', null)
go
insert into pos_param values ( 1, 3, 5, 34, 'WeeklyZHeader', 'Z-Weekly Report', null) 
go
insert into pos_param values ( 1, 3, 5, 35, 'MonthlyXHeader', 'X-Monthly Report', null) 
go
insert into pos_param values ( 1, 3, 5, 36, 'MonthlyZHeader', 'Z-Monthly Report', null) 
go
insert into pos_param values ( 1, 3, 5, 37, 'YearlyXHeader', 'X-Yearly Report', null) 
go
insert into pos_param values ( 1, 3, 5, 38, 'YearlyZHeader', 'Z-Yearly Report', null) 
go
insert into pos_param values ( 1, 3, 5, 39, 'SequenceNo', 'Sequence no', null) 
go
insert into pos_param values ( 1, 3, 5, 40, 'StartDate', 'Start date :', null) 
go
insert into pos_param values ( 1, 3, 5, 41, 'DebtCount', 'Debt transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 42, 'DebtAmount', 'Debt Amount', null) 
go
insert into pos_param values ( 1, 3, 5, 43, 'DebitCardCount', 'Debit card transactions', null) 
go
insert into pos_param values ( 1, 3, 5, 44, 'DebitCardAmount', 'Debit card Amount', null) 
go





-- Micellanious 

insert into pos_param values ( 1, 1, 6, 1, 'CashPickup', '10000.0', null) 
go
insert into pos_param values ( 1, 1, 6, 2, 'MaximumPluLength', '13', null) 
go
insert into pos_param values ( 1, 4, 6, 3, 'PromptForCashBack', 'TRUE', null) 
go
insert into pos_param values ( 1, 4, 6, 4, 'PromptForTableNo', 'FALSE', null) 
go
insert into pos_param values ( 1, 1, 6, 5, 'HomeLeftPanelNo', '90', null) 
go
insert into pos_param values ( 1, 1, 6, 6, 'CashMediaPanelNo', '992', null) 
go
insert into pos_param values ( 1, 1, 6, 7, 'CreditMediaPanelNo', '993', null) 
go
insert into pos_param values ( 1, 1, 6, 8, 'ItemWidth%', '25', null) 
go
insert into pos_param values ( 1, 1, 6, 9, 'DescriptionWidth%', '40', null) 
go
insert into pos_param values ( 1, 1, 6, 10, 'QuantityWidth%', '10', null) 
go
insert into pos_param values ( 1, 1, 6, 11, 'PriceWidth%', '10', null) 
go
insert into pos_param values ( 1, 1, 6, 12, 'AmountWidth%', '15', null) 
go
insert into pos_param values ( 1, 1, 6, 13, 'DefaultTransactionType', '1', null) 
go
insert into pos_param values ( 1, 4, 6, 14, 'ApplyRoundingToCashTender', 'TRUE', null) 
go
insert into pos_param values ( 1, 1, 6, 15, 'AutoRoundDownPromotionNo', '999', null) 
go
insert into pos_param values ( 1, 1, 6, 16, 'LineNumberWidth%', '5', null) 
go







insert into sub values('admin', '21232F297A57A5A743894A0E4A801FC3')
go


insert into input_filter values (1, 1, 1, 'Visa', 'Visa', '^;(4\d{15})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (1, 1, 'AccountNum')
go

insert into input_filter_field values (1, 2, 'ExprYear')
go

insert into input_filter_field values (1, 3, 'ExprMonth')
go

insert into input_filter values (2, 1, 1, 'MC', 'MC', '^;(5\d{15})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (2, 1, 'AccountNum')
go

insert into input_filter_field values (2, 2, 'ExprYear')
go

insert into input_filter_field values (2, 3, 'ExprMonth')
go

insert into input_filter values (3, 1, 1, 'Amex', 'AMEX', '^;(3\d{14})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (3, 1, 'AccountNum')
go
insert into input_filter_field values (3, 2, 'ExprYear')
go

insert into input_filter_field values (3, 3, 'ExprMonth')
go


insert into input_filter values (4, 1, 1, 'Costco', 'Costco', '^(;7\d{15})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (4, 1, 'AccountNum')
go

insert into input_filter_field values (4, 2, 'ExprYear')
go
insert into input_filter_field values (4, 3, 'ExprMonth')
go

insert into input_filter values (5, 1, 1, 'Discover', 'Discover', '^;(6\d{15})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (5, 1, 'AccountNum')
go

insert into input_filter_field values (5, 2, 'ExprYear')
go

insert into input_filter_field values (5, 3, 'ExprMonth')
go

insert into input_filter values (6, 1, 1, 'Diners Club', 'Diners Club', '^;(3\d{13})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (6, 1, 'AccountNum')
go

insert into input_filter_field values (6, 2, 'ExprYear')
go

insert into input_filter_field values (6, 3, 'ExprMonth')
go

insert into input_filter values (7, 1, 1, 'JCB', 'JCB', '^;(35\d{14})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (7, 1, 'AccountNum')
go

insert into input_filter_field values (7, 2, 'ExprYear')
go

insert into input_filter_field values (7, 3, 'ExprMonth')
go

insert into input_filter values (8, 1, 1, 'HSBC', 'HSBC', '^(5\d{17})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (8, 1, 'AccountNum')
go

insert into input_filter_field values (8, 2, 'ExprYear')
go

insert into input_filter_field values (8, 3, 'ExprMonth')
go

insert into input_filter values (9, 1, 1, 'NETS-DBS', 'NETS-DBS', '^(4\d{15})=(\d{2})(\d{2})', null, null )
go

insert into input_filter_field values (9, 1, 'AccountNum')
go

insert into input_filter_field values (9, 2, 'ExprYear')
go
 
insert into input_filter_field values (9, 3, 'ExprMonth')
go





INSERT INTO pos_config
           ([config_no]
			,[name]
           )
  VALUES
           (2
			,'Restaurant'
           )

go




Print('Creating pos_param')
go

-- Line display
insert into pos_param values (2, 3, 1, 1, 'CustWelcome', 'Welcome', null) 
go



-- Customer receipt print
insert into pos_param values ( 2, 3, 2, 1, 'ReceiptTopMOD1', 'Biz Reg. No. 2567891555 W', null) 
go
insert into pos_param values ( 2, 3, 2, 2, 'ReceiptTopMOD2', 'GST Reg. No. ME-845234-7', null) 
go
insert into pos_param values ( 2, 3, 2, 3, 'ReceiptTopMOD3', '*** Enjoy 5% cash rebates ***', null) 
go
insert into pos_param values ( 2, 3, 2, 4, 'ReceiptTopMOD4', 'When you use POSB Everyday credit card', null) 
go
insert into pos_param values ( 2, 3, 2, 5, 'ReceiptBottomMOD', 'Thank you for shopping', null) 
go
insert into pos_param values ( 2, 3, 2, 6, 'TrxNo', 'TRX: ', null) 
go
insert into pos_param values ( 2, 3, 2, 7, 'PosNo', 'POS: ', null) 
go
insert into pos_param values ( 2, 3, 2, 12, 'ReceiptLogo', 'sample2.bmp', null) 
go
insert into pos_param values ( 2, 3, 2, 13, 'TaxIncludedText', 'GST    7%', null) 
go
insert into pos_param values ( 2, 3, 2, 14, 'TotalItemCountText', 'Item count', null) 
go
insert into pos_param values ( 2, 3, 2, 15, 'ConvertedAltCurrency', 'Converted total', null) 
go
insert into pos_param values ( 2, 3, 2, 16, 'AltCurrencyDescription', 'Alternate Currency Tender', null) 
go
insert into pos_param values ( 2, 3, 2, 17, 'Total', 'TOTAL', null) 
go
insert into pos_param values ( 2, 3, 2, 18, 'BalanceDue', 'Balance Due', null) 
go
insert into pos_param values ( 2, 3, 2, 19, 'CashTender', 'Cash Tender', null) 
go
insert into pos_param values ( 2, 3, 2, 20, 'CheckTender', 'Check Tender', null) 
go
insert into pos_param values ( 2, 3, 2, 21, 'CreditTender', 'Credit Card Tender', null)
go
insert into pos_param values ( 2, 3, 2, 22, 'Change', 'Change Due', null) 
go
insert into pos_param values ( 2, 3, 2, 23, 'TableText', 'Table No.', null) 
go
insert into pos_param values ( 2, 3, 2, 24, 'DebitCardTender', 'Debit Card Tender', null)
go
insert into pos_param values ( 2, 3, 2, 25, 'VoidSaleText', 'Void Sales', null)
go
insert into pos_param values ( 2, 1, 2, 26, 'LogoBitmapWidth', '200', null)
go








Print (' OK ----------------' )
go



-- POS Workbench settings

insert into pos_param values ( 2, 3, 3, 1, 'TotalTax', 'Total Tax', null) 
go
insert into pos_param values ( 2, 3, 3, 2, 'SubTotal', 'SUBTOTAL', null) 
go
insert into pos_param values ( 2, 3, 3, 3, 'Discount', 'Discount', null) 
go
insert into pos_param values ( 2, 3, 3, 4, 'Markout', 'Markout', null) 
go
insert into pos_param values ( 2, 3, 3, 5, 'CashBack', 'Cash Back', null) 
go
insert into pos_param values ( 2, 3, 3, 6, 'PosTag', 'Register', null) 
go
insert into pos_param values ( 2, 3, 3, 7, 'EmpTag', 'Employee', null) 
go
insert into pos_param values ( 2, 3, 3, 8, 'DateTag', 'Time/Date', null) 
go
insert into pos_param values ( 2, 3, 3, 9, 'TrxTag', 'Transaction', null) 
go
insert into pos_param values ( 2, 3, 3, 10, 'QtyHeader', 'Qty', null) 
go
insert into pos_param values ( 2, 3, 3, 11, 'ItemHeader', 'Item', null) 
go
insert into pos_param values ( 2, 3, 3, 12, 'DescHeader', 'Description', null) 
go
insert into pos_param values ( 2, 3, 3, 13, 'PriceHeader', 'Price', null) 
go
insert into pos_param values ( 2, 3, 3, 14, 'ValueHeader', 'Value', null) 
go
insert into pos_param values ( 2, 3, 3, 15, 'SubtotalTag', 'Subtotal', null) 
go
insert into pos_param values ( 2, 3, 3, 16, 'TotalTaxTag', 'Tax', null) 
go
insert into pos_param values ( 2, 3, 3, 17, 'GrandTotal', 'Total', null) 
go
insert into pos_param values ( 2, 3, 3, 18, 'TenderedTag', 'Tendered', null) 
go
insert into pos_param values ( 2, 3, 3, 19, 'LineNumberHeader', 'Ln', null) 
go










-- POS Workbench operator prompt text
insert into pos_param values ( 2, 3, 4, 1, 'CloseDrawer', 'Close Cash Drawer', null) 
go
insert into pos_param values ( 2, 3, 4, 2, 'InsertCheck', 'Insert check', null) 
go
insert into pos_param values ( 2, 3, 4, 3, 'InsertValidation', 'Insert Validation', null) 
go
insert into pos_param values ( 2, 3, 4, 4, 'InsertCCValidation', 'Insert credit card receipt', null) 
go
insert into pos_param values ( 2, 3, 4, 5, 'BadName', 'Bad user ID, press clear', null) 
go
insert into pos_param values ( 2, 3, 4, 6, 'BadPass', 'Invalid password, press clear', null) 
go
insert into pos_param values ( 2, 3, 4, 7, 'InvalidCustomer', 'Invalid customer number, press clear', null) 
go
insert into pos_param values ( 2, 3, 4, 8, 'TooMany', 'Too many logon attempts, press clear', null) 
go
insert into pos_param values ( 2, 3, 4, 9, 'GoodLogin', 'Logon successful', null) 
go
insert into pos_param values ( 2, 3, 4, 10, 'OkText', 'OK', null) 
go
insert into pos_param values ( 2, 3, 4, 11, 'CancelText', 'Cancel', null) 
go
insert into pos_param values ( 2, 3, 4, 12, 'ClearText', 'Clear', null) 
go
insert into pos_param values ( 2, 3, 4, 13, 'InvalidInput', 'Invalid Input, press clear', null) 
go
insert into pos_param values ( 2, 3, 4, 14, 'PromptOpenAmount', 'Enter open amount: ', null) 
go
insert into pos_param values ( 2, 3, 4, 15, 'PromptAmount', 'Enter amount: ', null) 
go
insert into pos_param values ( 2, 3, 4, 16, 'PromptCashBack', 'Cash back amount:', null) 
go
insert into pos_param values ( 2, 3, 4, 17, 'ConfirmOpenAmount', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 2, 3, 4, 18, 'RegOpen', 'Register Open', null) 
go
insert into pos_param values ( 2, 3, 4, 19, 'ReturnSale', 'Return Sale', null) 
go
insert into pos_param values ( 2, 3, 4, 20, 'TotalRequired', 'Total Required, press clear', null) 
go
insert into pos_param values ( 2, 3, 4, 21, 'InsufficientFunds', 'Insufficient Funds, press clear', null) 
go
insert into pos_param values ( 2, 3, 4, 23, 'MgrIntervention', 'Manager intervention required', null) 
go
insert into pos_param values ( 2, 3, 4, 24, 'EnterUser', 'Enter User ID: ', null) 
go
insert into pos_param values ( 2, 3, 4, 25, 'EnterPass', 'Enter Password: ', null) 
go
insert into pos_param values ( 2, 3, 4, 26, 'PromptDrawerNo', 'Enter drawer number: ', null) 
go
insert into pos_param values ( 2, 3, 4, 27, 'ConfirmDrawerNo', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 2, 3, 4, 28, 'BadDrawerNo', 'Invalid drawer number', null) 
go
insert into pos_param values ( 2, 3, 4, 29, 'BadCheckNo', 'Invalid check number', null) 
go
insert into pos_param values ( 2, 3, 4, 30, 'BadCCNo', 'Invalid credit card', null) 
go
insert into pos_param values ( 2, 3, 4, 31, 'BadExpr', 'Bad expiration date', null) 
go
insert into pos_param values ( 2, 3, 4, 32, 'PromptCustomer', 'Enter Customer Number: ', null) 
go
insert into pos_param values ( 2, 3, 4, 33, 'VoidSale', 'Sale Voided, press enter', null) 
go
insert into pos_param values ( 2, 3, 4, 35, 'AltCurrTenderPrompt', 'Enter alternate currency amount: ', null) 
go
insert into pos_param values ( 2, 3, 4, 37, 'TenderTotal', 'Amount Tendered', null) 
go
insert into pos_param values ( 2, 3, 4, 38, 'TerminalLocked', 'Terminal locked, press enter', null) 
go
insert into pos_param values ( 2, 3, 4, 39, 'EnterItem', 'Enter item', null) 
go
insert into pos_param values ( 2, 3, 4, 40, 'EnterWeight', 'Enter weight', null) 
go
insert into pos_param values ( 2, 3, 4, 41, 'Pause', 'Press enter to continue...', null) 
go
insert into pos_param values ( 2, 3, 4, 42, 'CloseCash', 'Close cash drawer.', null) 
go

insert into pos_param values ( 2, 3, 4, 43, 'RecallFailed', 'Transaction not found', null) 
go
insert into pos_param values ( 2, 3, 4, 44, 'CashLimitExceeded', 'Cash in drawer limit exceeded', null) 
go
insert into pos_param values ( 2, 3, 4, 45, 'EnterNewPrice', 'Enter new price:', null) 
go
insert into pos_param values ( 2, 3, 4, 46, 'PosPrinterFailed', 'PRINTER FAILURE', null) 
go
insert into pos_param values ( 2, 3, 4, 47, 'PosPrinterError', 'Printer Error', null) 
go
insert into pos_param values ( 2, 3, 4, 48, 'CashDrawerError', 'Cash Drawer Error', null) 
go
insert into pos_param values ( 2, 3, 4, 49, 'PosLineDisplayError', 'Line Display Error', null) 
go
insert into pos_param values ( 2, 3, 4, 50, 'ShutdownKeyNotAllowed', 'Shutdown Key Not Allowed', null) 
go
insert into pos_param values ( 2, 4, 4, 51, 'NavigateButtons', 'true', null) 
go
insert into pos_param values ( 2, 3, 4, 52, 'OperReceiptFont', 'Lucida Sans Typewriter Regular', null) 
go
insert into pos_param values ( 2, 3, 4, 53, 'HeaderFont', 'Courier', null) 
go
insert into pos_param values ( 2, 3, 4, 54, 'HeaderTitleFont', 'Helvetica', null) 
go
insert into pos_param values ( 2, 1, 4, 55, 'OperReceiptFontSize', '15', null) 
go
insert into pos_param values ( 2, 1, 4, 56, 'HeaderFontSize', '12', null) 
go
insert into pos_param values ( 2, 1, 4, 57, 'HeaderTitleFontSize', '14', null) 
go
insert into pos_param values ( 2, 3, 4, 58, 'PromptPosNo', 'Enter POS Number: ', null) 
go
insert into pos_param values ( 2, 3, 4, 59, 'PromptTransNo', 'Enter Transaction Number:', null) 
go
insert into pos_param values ( 2, 3, 4, 60, 'NoSaleCount', 'No sale transactions', null) 
go
insert into pos_param values ( 2, 3, 4, 61, 'TransNo', 'TRANS#', null) 
go
insert into pos_param values ( 2, 3, 4, 62, 'TransType', 'TRANS TYPE', null) 
go
insert into pos_param values ( 2, 3, 4, 63, 'OperLogon', 'Operator logon', null) 
go
insert into pos_param values ( 2, 3, 4, 64, 'OperLogoff', 'Operator logoff', null) 
go
insert into pos_param values ( 2, 3, 4, 65, 'BankTrans', 'Bank transaction', null) 
go
insert into pos_param values ( 2, 3, 4, 66, 'PromptCheckNo', 'Enter check number:', null) 
go
insert into pos_param values ( 2, 3, 4, 67, 'PromptCCNo', 'Enter credit card number:', null) 
go
insert into pos_param values ( 2, 3, 4, 68, 'PromptCCExpr', 'Enter expiration data:', null) 
go
insert into pos_param values ( 2, 3, 4, 69, 'Confirm', 'Press enter', null) 
go
insert into pos_param values ( 2, 3, 4, 85, 'OverMeiaLimit', 'Over Media Limit', null) 
go
insert into pos_param values ( 2, 3, 4, 86, 'UnderMediaLimit', 'Under Media Limit', null) 
go
insert into pos_param values ( 2, 3, 4, 87, 'ReturnSalePrompt', 'Return Sale', null) 
go
insert into pos_param values ( 2, 3, 4, 89, 'SalePrompt', 'Sales Transaction', null) 
go
insert into pos_param values ( 2, 3, 4, 90, 'DineInPrompt', 'Dine In', null) 
go
insert into pos_param values ( 2, 3, 4, 91, 'CarryOutPrompt', 'Take Away', null) 
go
insert into pos_param values ( 2, 3, 4, 92, 'InsufficientUserAuthority', 'Insufficient User Authority', null) 
go
insert into pos_param values ( 2, 3, 4, 93, 'TableNumberPrompt', 'Enter Table no', null) 
go
insert into pos_param values ( 2, 3, 4, 94, 'PromptItemPrice', 'Enter Item Price', null) 
go
insert into pos_param values ( 2, 3, 4, 95, 'PriceChangeNotAllowed', 'Price change not allowed', null) 
go
insert into pos_param values ( 2, 3, 4, 96, 'SelectCustomer', 'Select customer and try again', null) 
go
insert into pos_param values ( 2, 3, 4, 97, 'InsufficientCreditLimit', 'Insufficient credit limit', null) 
go
insert into pos_param values ( 2, 3, 4, 98, 'DebtTender', 'Debt Tender', null) 
go
insert into pos_param values ( 2, 3, 4, 99, 'InvalidFunction', 'Invalid operation', null) 
go
insert into pos_param values ( 2, 3, 4, 100, 'PromptCardName', 'Enter card name and Press Enter', null) 
go
insert into pos_param values ( 2, 3, 4, 101, 'PromptEnterLineNumber', 'Enter Line no.', null) 
go







-- Terminal reports
insert into pos_param values ( 2, 3, 5, 1, 'NonTaxCount', 'Non-tax transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 2, 'NonTaxAmount', 'Non-tax amount', null) 
go
insert into pos_param values ( 2, 3, 5, 3, 'TaxCount', 'Tax transactions ', null) 
go
insert into pos_param values ( 2, 3, 5, 4, 'TaxAmount', 'Tax amount ', null) 
go
insert into pos_param values ( 2, 3, 5, 5, 'VoidCount', 'Void transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 6, 'VoidAmount', 'Void amount', null) 
go
insert into pos_param values ( 2, 3, 5, 7, 'ReturnCount', 'Return transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 8, 'ReturnAmount', 'Return amount', null) 
go
insert into pos_param values ( 2, 3, 5, 9, 'CouponCount', 'Coupon transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 10, 'CouponAmount', 'Coupon amount', null) 
go
insert into pos_param values ( 2, 3, 5, 11, 'CreditCount', 'Credit transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 12, 'CreditAmount', 'Credit amount', null) 
go
insert into pos_param values ( 2, 3, 5, 13, 'CheckCount', 'Check transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 14, 'CheckAmount', 'Check amount', null) 
go
insert into pos_param values ( 2, 3, 5, 15, 'RecdOnAcctCount', 'Received on account transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 16, 'RecdOnAcctAmount', 'Received on account amount', null) 
go
insert into pos_param values ( 2, 3, 5, 17, 'PaidInCount', 'Paid in transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 18, 'PaidInAmount', 'Paid in amount', null) 
go
insert into pos_param values ( 2, 3, 5, 19, 'PaidOutCount', 'Paid out transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 20, 'PaidOutAmount', 'Paid out amount', null) 
go
insert into pos_param values ( 2, 3, 5, 21, 'CashSalesCount', 'Cash sales transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 22, 'CashSalesAmount', 'Cash sales amount', null) 
go
insert into pos_param values ( 2, 3, 5, 23, 'CashInDrCount', 'Cash transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 24, 'CashInDrAmount', 'Cash in drawer amount', null) 
go
insert into pos_param values ( 2, 3, 5, 25, 'LoanCount', 'Loan transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 26, 'LoanAmount', 'Loans amount', null) 
go
insert into pos_param values ( 2, 3, 5, 27, 'PickupCount', 'Pickup transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 28, 'PickupAmount', 'Pickup amount', null) 
go
insert into pos_param values ( 2, 3, 5, 29, 'CashBackCount', 'Cash back transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 30, 'CashBackAmount', 'Cash back amount', null) 
go

insert into pos_param values ( 2, 3, 5, 31, 'DailyXHeader', 'X-Daily Report', null) 
go
insert into pos_param values ( 2, 3, 5, 32, 'DailyZHeader', 'Z-Daily Report', null)
go

insert into pos_param values ( 2, 3, 5, 33, 'WeeklyXHeader', 'X-Weekly Report', null)
go

insert into pos_param values ( 2, 3, 5, 34, 'WeeklyZHeader', 'Z-Weekly Report', null)
go

insert into pos_param values ( 2, 3, 5, 35, 'MonthlyXHeader', 'X-Monthly Report', null) 
go

insert into pos_param values ( 2, 3, 5, 36, 'MonthlyZHeader', 'Z-Monthly Report', null) 
go
insert into pos_param values ( 2, 3, 5, 37, 'YearlyXHeader', 'X-Yearly Report', null) 
go
insert into pos_param values ( 2, 3, 5, 38, 'YearlyZHeader', 'Z-Yearly Report', null) 
go
insert into pos_param values ( 2, 3, 5, 39, 'SequenceNo', 'Sequence no', null) 
go
insert into pos_param values ( 2, 3, 5, 40, 'StartDate', 'Start date :', null) 
go
insert into pos_param values ( 2, 3, 5, 41, 'DebtCount', 'Debt transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 42, 'DebtAmount', 'Debt Amount', null) 
go
insert into pos_param values ( 2, 3, 5, 43, 'DebitCardCount', 'Debit card transactions', null) 
go
insert into pos_param values ( 2, 3, 5, 44, 'DebitCardAmount', 'Debit card Amount', null) 
go




-- Micellanious 
insert into pos_param values ( 2, 1, 6, 1, 'CashPickup', '10000.0', null) 
go
insert into pos_param values ( 2, 1, 6, 2, 'MaximumPluLength', '13', null) 
go
insert into pos_param values ( 2, 4, 6, 3, 'PromptForCashBack', 'TRUE', null) 
go
insert into pos_param values ( 2, 4, 6, 4, 'PromptForTableNo', 'TRUE', null) 
go
insert into pos_param values ( 2, 1, 6, 5, 'HomeLeftPanelNo', '90', null) 
go
insert into pos_param values ( 2, 1, 6, 6, 'CashMediaPanelNo', '992', null) 
go
insert into pos_param values ( 2, 1, 6, 7, 'CreditMediaPanelNo', '993', null) 
go
insert into pos_param values ( 2, 1, 6, 8, 'ItemWidth%', '25', null) 
go
insert into pos_param values ( 2, 1, 6, 9, 'DescriptionWidth%', '40', null) 
go
insert into pos_param values ( 2, 1, 6, 10, 'QuantityWidth%', '10', null) 
go
insert into pos_param values ( 2, 1, 6, 11, 'PriceWidth%', '10', null) 
go
insert into pos_param values ( 2, 1, 6, 12, 'AmountWidth%', '15', null) 
go
insert into pos_param values ( 2, 1, 6, 13, 'DefaultTransactionType', '8', null) 
go
insert into pos_param values ( 2, 4, 6, 14, 'ApplyRoundingToCashTender', 'TRUE', null) 
go
insert into pos_param values ( 2, 1, 6, 15, 'AutoRoundDownPromotionNo', '999', null) 
go
insert into pos_param values ( 2, 1, 6, 16, 'LineNumberWidth%', '5', null) 
go




-- Panels 
 
 insert into menu_panels values ( 2, 90, 'Common', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 91, 'Promo/Exit/Other', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 92, 'Manager', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 93, 'Settle', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 94, 'Food Menu', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 95, 'Drinks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 96, 'Bar', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 97,  'Search Search', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 2, 201, 'COFFEE DOCK', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 202, 'TEA DOCK', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 203, 'SOFT DRINKS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 204, 'FRUIT JUICES', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 

 insert into menu_panels values ( 2, 401, 'CLASSIC MARTINIS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 402, 'PREMIUM COCKTAILS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 403, 'SHOOTERS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 404, 'DIGESTIVE', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 405, 'HOUSEPOUR SPIRITS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 406, 'WHITE WINE', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 407, 'RED WINE', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 408, 'CHAMPAGNE', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 409, 'BEERS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go


 insert into menu_panels values ( 2, 301, 'SALADS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 302, 'APPETIZERS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 303, 'PASTAS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 304, 'SECOND PLATES', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
insert into menu_panels values  ( 2, 305, 'DESSERTS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 306, 'PIZZAS', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 



insert into menu_panels values ( 2, 991, 'Panel navigator', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
 go
insert into menu_panels values ( 2, 992, 'Cash Bills and Coins', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

insert into menu_panels values ( 2, 993, 'Card Types', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

 


 
 
-- Navigator

insert into pos_key values (2, 991,	'Common',		1,   90 ,   112,3,	20,		8,	48,		118,		90,		192,	90,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Common', 'F1')
go
						  				
insert into pos_key values (2, 991,	'Promo/Exit/Other',	1,   91,   113,	3,	140,	8,  48,		118,		91,		192,	91,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Promo/Exit/Other', 'F2')
go

insert into pos_key values (2, 991,	'Manager',		1,   92,   114,	3,	260,	8,  48,		118,		93,		192,	92,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Manager', 'F3')
go

insert into pos_key values (2, 991,	'Settle',		1,   93,   115,	3,	380,	8,  48,		118,		94,		192,	93,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Settle', 'F4')
go

insert into pos_key values (2, 991,	'Food Menu',	1,   94,   116,	3,	500,	8,  48,		118,		95,		192,	94,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Food Menu', 'F5')
go

insert into pos_key values (2, 991,	'Drinks',		1,   95,   117,	3,	620,	8,  48,		118,		96,		192,	95,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Drinks', 'F6')
go

insert into pos_key values (2, 991,	'Bar',			1,   96,   118,	3,	740,	8,  48,		118,		97,		192,	96,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Bar', 'F7')
go
														  				
insert into pos_key values (2, 991,	'Item search',	1,   97,   119,	3,	860,	8,  48,		118,		98,		192,	97,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Item search', 'F8')
go

														  				
														  				


-- Common Tasks
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1001,		3,	170,		40,			48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Quantity','Quantity','F1')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1002,		3,  170,		89,			48, 56,	91,	192,	131185,	null,1,'EclipsePos.Apps.PosEvents.SelectTable','Select Table', 'F2')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1003,		3,	170,		138,		48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.OpenOrdersList','Open Orders','F3')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1004,		3,	170,		187,		48, 56,	93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ItemVoid','Void Item','F4')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1005,		3,	170,		236,		48, 56, 94,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale','Void Order','F5')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1006,		3, 170,			285,		48, 56, 95,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.SaveEj','Save Order','F6')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   25, 1007,		3,  170,		334,		48, 56, 96,	192,	131190,	null,1, 'EclipsePos.Apps.PosEvents.AddSurcharge', 'Service Charge','F7')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1008,		3, 170,			432,		48, 56, 97,	192,	131191,	null,1, 'EclipsePos.Apps.PosEvents.PrintOrderTicket','Print Order','F8')
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1009,		3, 170,			481,		48, 56, 98,	192,	131192,	null,1, 'EclipsePos.Apps.PosEvents.ToggleDineInOut','Dine In/Take Away','F9')
go


-- Exit/Other 
insert into pos_key values (2, 91,		'Ctrl',		1,   1,	1011,		3,  170,	40,			48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Discount','Item Disc 10%','F1')
go
insert into pos_key values (2, 91,		'Ctrl',		1,   2,	1012,		3,  170,	89,			48, 56,	91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Discount','Item Disc 20%','F2')
go
insert into pos_key values (2, 91,		'Ctrl',		1,   3,	1013,		3,  170,	138,		48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Discount','Order Disc 10%','F3')

insert into pos_key values (2, 91,		'Ctrl',		1,   4, 1014,		3, 170,		187,		48, 56, 93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Discount','Order Disc 15%','F4')
go
insert into pos_key values (2, 91,	'	Ctrl',		1,   5, 1015,		3, 170,		236,		48, 56, 94,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Discount','Order Disc 20%','F5')
go
insert into pos_key values (2, 91,		'Ctrl',		1,   0,	1016,		3, 170,		285,		48, 56,	0,	0,		131189,	null,1, 'EclipsePos.Apps.PosEvents.FreeText','Free Text','F6')
go
insert into pos_key values (2, 91,		'Ctrl',		1,   2,	 1017,		3,  170,	334,		48, 56,90,0,		131190,	null,1, 'EclipsePos.Apps.PosEvents.MergeOrder', 'Combine Order','F7')
go
insert into pos_key values (2, 91,		'Ctrl',		1,  -1,	 1018,		3,  170,	432,		48, 56,91,50,		131191,	null,1, 'EclipsePos.Apps.PosEvents.LogOff', 'Log Off','F8')
go
insert into pos_key values (2, 91,		'Ctrl',		1,  -1,	 1019,		3,  170,	481,		48, 56,91,50,		131192,	null,1, 'EclipsePos.Apps.PosEvents.Exit', 'Shutdown','F9')
go



-- Manager
insert into pos_key values (2, 92,	'Ctrl',		1,   0,  1041,		3,  170,		40,		48, 56,		90,	100,	131184,		null,1,'EclipsePos.Apps.PosEvents.PaidIn', 'Paid In','F1')
go
insert into pos_key values (2, 92,	'Ctrl',		1,   0,  1042,		3,  170,		89,		48, 56,		91,	100,	131185,		null,1,'EclipsePos.Apps.PosEvents.PaidOut', 'Paid Out','F2')
go
insert into pos_key values (2, 92,	'Ctrl',		1,   0,	 1043,		3, 170,			138,	48, 56,		92,	50,		131186,		null,1, 'EclipsePos.Apps.PosEvents.TrainingMode', 'Training Mode','F3')
go
insert into pos_key values (2, 92,	'Ctrl',		1,   1,	 1044,		3,	170,		187,	48,  56,	93,	25,		131187,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'X-Report','F4')
go
insert into pos_key values (2, 92,	'Ctrl',		1,   2,	 1045,		3,	170,		236,	48,  56,    94,	0,		131188,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'Z-Report','F5')
go
insert into pos_key values (2, 92,	'Ctrl',		1,   2,	 1046,		3,	170,		285,	48,  56,    94,	0,		131189,		null,	1,	'EclipsePos.Apps.PosEvents.PriceOverride', 'Change Price','F6')
go
insert into pos_key values (2, 92,	'Ctrl',		1,   2,	 1047,		3,	170,		334,	48,  56,    94,	0,		131190,		null,	1,	'EclipsePos.Apps.PosEvents.ReturnSale', 'Return Sale','F7')
go
insert into pos_key values (2, 92,	'Ctrl',		1,   2,	 1048,		3,	170,		432,	48,  56,    94,	0,		131191,		null,	1,	'EclipsePos.Apps.PosEvents.SystemManager', 'System Mgr','F8')
go







-- Tender
insert into pos_key values (2, 93,		'Ctrl' ,	1,   0,  1031,		3, 170,			40,		48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.CashTender','Cash ','F1')
go
insert into pos_key values (2, 93,		'Ctrl',		1,   0,  1032,		3, 170,			89,		48, 56, 91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.CheckTender','Check ','F2')
go
insert into pos_key values (2, 93,		'Ctrl',		1,   0,  1033,		3, 170,			138,	48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.CreditTender','Credit Card ','F3')
go
insert into pos_key values (2, 93,		'Ctrl',		1,   0,  1034,		3, 170,			187,	48, 56,	92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.DebtTender','Debt','F4')
go


				 							 		  			


-- Food Menu
insert into pos_key values (2, 94,	'Ctrl',		1,   301,	 1051,		3,  170,		40,		48, 56,		90,	100,	131184,		null,1,'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'SALADS','F1')
go
insert into pos_key values (2, 94,	'Ctrl',		1,   302,	 1052,		3,  170,		89,		48, 56,		91,	100,	131185,		null,1,'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'APPETIZERS','F2')
go
insert into pos_key values (2, 94,	'Ctrl',		1,   303,	 1053,		3,	170,		138,	48, 56,		92,	50,		131186,		null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'PASTAS','F3')
go
insert into pos_key values (2, 94,	'Ctrl',		1,   304,	 1054,		3,	170,		187,	48,  56,	93,	25,		131187,		null,1,	'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'SECOND PLATES','F4')
go
insert into pos_key values (2, 94,	'Ctrl',		1,   305,	 1055,		3,	170,		236,	48,  56,    94,	0,		131188,		null,1,	'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'DESSERTS','F5')
go
insert into pos_key values (2, 94,	'Ctrl',		1,   306,	 1056,		3,	170,		236,	48,  56,    94,	0,		131189,		null,1,	'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'PIZZAS','F6')
go





-- Drinks
insert into pos_key values (2, 95,	'Ctrl',		1,   201,		1061,		3, 170,			40,		48, 56,90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','COFEE DOCK','F1')
go
insert into pos_key values (2, 95,	'Ctrl',		1,   202,		1062,		3, 170,			89,		48, 56,91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','TEA DOCK','F2')
go
insert into pos_key values (2, 95,	'Ctrl',		1,   203,		1063,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','SOfT DRINKS','F3')
go
insert into pos_key values (2, 95,	'Ctrl',		1,   204,		1064,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'FRUIT JUICES', 'F4')
go


-- Bar
insert into pos_key values (2, 96,	'Ctrl',		1,   401,		1081,		3, 170,			40,		48, 56,90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','CLASSIC MARTINIS','F1')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   402,		1082,		3, 170,			89,		48, 56,91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','PREMIUM COCKTAILS','F2')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   403,		1083,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','SHOOTERS','F3')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   404,		1084,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'DIGESTIVE', 'F4')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   405,		1085,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','HOUSEPOUR SPIRITS','F5')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   406,		1086,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'WHITE WINE', 'F6')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   407,		1087,		3, 170,			138,	48, 56,92,	192,	131190,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'RED WINE', 'F7')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   408,		1088,		3, 170,			138,	48, 56,92,	192,	131191,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'CHAMPAGNE', 'F8')
go
insert into pos_key values (2, 96,	'Ctrl',		1,   409,		1088,		3, 170,			138,	48, 56,92,	192,	131192,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'BEERS', 'F9')
go



-- Item search
insert into pos_key values (2, 97,	'Ctrl',		1,   1,		1091,		3, 170,			40,		48, 56,90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','Description ','F1')
go
insert into pos_key values (2, 97,	'Ctrl',		1,   2,		1092,		3, 170,			89,		48, 56,91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','SKU ','F2')
go
insert into pos_key values (2, 97,	'Ctrl',		1,   3,		1093,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','Department','F3')
go
insert into pos_key values (2, 97,	'Ctrl',		1,   4,		1094,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ItemsMenu','Item Group','F4')
go




									  		  




-- Cash tender Notes/Coins
insert into pos_key values (2, 992,	'Ctrl' ,		1,   10000,		1021,	3,	 170,	40,   48,  56, 90,	0, 131184,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '100.00','F1')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   5000,		1022,	3,	170,	89,   48,  56, 91,	0, 131185,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '50.00','F2')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   1000,		1023,	3,	170,	138,  48,  56, 92,	0, 131186,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '10.00','F3')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   500,		1024,	3,	170,	187,  48,  56, 93,	0, 131187,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '5.00','F4')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   200,		1025,	3,	170,	236,  48,  56, 94,	0, 131188,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '2.00','F5')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   100,		1026,	3,	170,	285,  48,  56, 95,	0, 131189,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '1.00','F6')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   50,		1027,	3,	170,	334,  48,  56, 96,	0, 131190,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.50','F7')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   20,		1028,	3,	170,	383,  48,  56, 97,	0, 131191,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.20','F8')
go

insert into pos_key values (2, 992,	'Ctrl',			1,   10,		1029,	3,	170,	432,  48,  56, 98,	0, 131192,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.10','F9')
go



-- Credit card types
insert into pos_key values (2, 993,	'Ctrl' ,		1,   0,		2081,	3,	 170,	40,   48,  56, 90,	0, 131184,	'Visa.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'VISA','F1')
go

insert into pos_key values (2, 993,	'Ctrl',			1,   0,		2082,	3,	170,	89,   48,  56, 91,	0, 131185,	'MasterCard.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'MASTER','F2')
go

insert into pos_key values (2, 993,	'Ctrl',			1,   0,		2083,	3,	170,	138,  48,  56, 92,	0, 131186,	'Amex.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'AMEX','F3')
go

insert into pos_key values (2, 993,	'Ctrl',			1,   0,		2084,	3,	170,	187,  48,  56, 93,	0, 131187,	'Discover.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'DISCOVER','F4')
go

insert into pos_key values (2, 993,	'Ctrl',			1,   0,		2085,	3,	170,	236,  48,  56, 94,	0, 131188,	null,	1,	'EclipsePos.Apps.PosEvents.MediaText', 'NETS','F5')
go


-- demo_data



delete from promotion where organization_no = '1'
go

delete from customer where organization_no ='1'
go


delete from tax where organization_no ='1'
go

delete from tax_group  where organization_no ='1'
go


delete from employee where organization_no ='1'
go

delete from employee_role_event 
go

delete from employee_roles where organization_no ='1'
go

delete from pos where organization_no ='1'
go

delete from retail_store where organization_no ='1'
go



delete from organization where organization_no ='1'
go


print 'Delete complete'

go




-- Organization

insert into organization values ( '1', 'Eclipse Retail', 'Deport road', 
 'Singapore', ' ', ' ', 'Singapore', ' ', '102111', 'Singapore',
 '89988888', '09881111', 'Mr. XYZ', 'SGD', '200333737838G',  22, null, 0 )   

go









-- employee roles



INSERT INTO employee_roles
           ([role_id]
			,[role_name]
           ,[organization_no])
     VALUES
           (
			'1001'
			,'Manager'
			,'1'
			)

go




insert into employee_role_event values (1,   'VoidSale', '1001', '1')
go
insert into employee_role_event values (2,   'PaidIn', '1001', '1' )
go
insert into employee_role_event values (3,   'PaidOut', '1001', '1' )
go
insert into employee_role_event values (4,   'TrainingMode', '1001', '1' )
go
insert into employee_role_event values (5,   'TerminalReports', '1001', '1')
go
insert into employee_role_event values (6,   'VoidItemLine', '1001', '1')
go
insert into employee_role_event values (7,   'Store', '1001', '1')
go
insert into employee_role_event values (8,   'Recall', '1001', '1')
go
insert into employee_role_event values (9,   'Shutdown', '1001', '1' )
go
insert into employee_role_event values (10,   'LogOff', '1001', '1')
go
insert into employee_role_event values (11,  'ReturnSale', '1001', '1')
go
insert into employee_role_event values (12,   'Discount', '1001', '1')
go
insert into employee_role_event values (13,   'Promotion', '1001', '1')
go
insert into employee_role_event values (14,   'Customer', '1001', '1')
go
insert into employee_role_event values (15,   'SystemManager', '1001', '1')
go
insert into employee_role_event values (16,   'ChangePrice', '1001', '1')
go
insert into employee_role_event values (17,   'ShutDown', '1001', '1')
go
insert into employee_role_event values (18,   'CreditTender', '1001','1' )
go
insert into employee_role_event values (19,  'AltCurrencyTender', '1001', '1' )
go
insert into employee_role_event values (20,  'CheckTender',  '1001', '1')
go
insert into employee_role_event values (21,  'DebtTender',  '1001', '1')
go




 



-- employee

INSERT INTO employee
           ([organization_no]
           ,[employee_no]
           ,[logon_no]
           ,[logon_pass]
           ,[role_id]
           ,[fname]
           ,[lname]
           ,[mi]
           ,[ssn]
           ,[sal_grade])
     VALUES
           ('1'
           ,'Eclipse100'
           ,'100'
           ,'F899139DF5E1059396431415E770C6DD'
           ,'1001'
           ,'Eclipse'
           ,'ES'
           ,null
           ,null
           ,0)
 
go




INSERT INTO Retail_Store
           
     VALUES
  
			('2'
			,'1'
		   ,'Eclipse Retail'
           ,'<--- address 1---------->'
           ,'<----address 2---------->'
           ,'<----address 3---------->'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
			,''
			,''
			,''
           ,10
			,null 
			)


GO




INSERT INTO tax_group VALUES('7','1','Zero' )
go





insert into tax values ( 1, '7', '1', 0, 'GST 0%', 0.0, 0.0) 
go











INSERT into pos VALUES( 105, '1', 2, 0, 'Station A', '8-12-08', '8-12-08' )

go

INSERT into pos VALUES( 110, '1', 2, 0, 'Station B', '8-12-08', '8-12-08' )

go




delete from item where organization_no=1
go



INSERT INTO ITEM VALUES('1', '201' ,'Alain Delon L/S' ,18.00,  null, null, 7, '1', null, null, 1, 0, null, null, '201')
go

INSERT INTO ITEM VALUES('1', '202' ,'KAO Lavnus dry-scalp 200M' ,1.90,  null, null, 7, '1', null, null, 1, 0, null, null,  '202')
go

INSERT INTO ITEM VALUES('1', '203' ,'Cherry house baby wear' ,2.90,  null, null, 7, '1', null, null, 1, 0, null, null,  '203')
go

INSERT INTO ITEM VALUES('1', '204' ,'Canon bedsheet Q' ,13.90,  null, null, 7, '1', null, null, 1, 0, null, null,  '204')
go

INSERT INTO ITEM VALUES('1', '205' ,'40X70CM Cotton rug' ,4.00,  null, null, 7, '1', null, null, 1, 0, null, null,  '205')
go

INSERT INTO ITEM VALUES('1', '206' ,'Follow-me T/Brush 3/S' , 3.40,  null, null, 7, '1', null, null, 1, 0,  null, null, '206')
go

INSERT INTO ITEM VALUES('1', '207' ,'Square bowl 18CM' , 13.90,  null, null, 7, '1', null, null, 1, 0, null, null,  '207')
go



-- Promotions

insert into promotion values ( '1', 101, 1,   3, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Group Discount',	'EclipsePos.Apps.Operators.GroupDiscount' )
go

insert into promotion values ( '1', 201, 1,   3, 0, 0, 0, 0,   10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', '3 for $10',	'EclipsePos.Apps.Operators.NForX' )
go

insert into promotion values ( '1', 1, 1,   1, 0, 0, 0, 0,    10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '1', 2, 1,   1, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '1', 3, 1,   1, 0, 0, 0, 0,    30.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '1', 4, 1,   1, 0, 0, 0, 0,    40.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '1', 5, 1,   1, 0, 0, 0, 0,    50.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go







-- ---------------------------------------------------------//
-- Organization = 12
-- RetaiStore = 20
-- Pos = 110
-- Config_no = 2
-- ---------------------------------------------------------//

delete from customer where organization_no = '12'
go


delete from item where organization_no = '12'
go




Print 'Detlete stage 1 OK'
go



delete from promotion where organization_no ='12'
go


delete from pos where organization_no = '12'
go

delete from retail_store where organization_no = '12'
go

delete from tax where organization_no = '12'
go

delete from tax_group where organization_no = '12'
go

delete from employee where organization_no = '12'
go


delete from employee_roles where organization_no = '12'
go

delete from pos where organization_no = '12'
go


delete from table_details where organization_no = '12'
go

delete from table_group where organization_no = '12'
go

delete from organization where organization_no = '12'
go


print 'delete stage 2 OK'
go


insert into organization values ( '12', 'Eclipse Restaurant', 'Deport road', 
 'Singapore', ' ', ' ', 'Singapore', ' ', '102111', 'Singapore',
 '89988888', '09881111', 'Mr. XYZ', 'SGD', '200333737838G',   22, null, 0)   

go



-- employee roles



INSERT INTO employee_roles
           ([role_id]
			,[role_name]
           ,[organization_no])
     VALUES
           (
			'1025'
			,'Returant Manager'
			,'12'
			)

go



insert into employee_role_event values (1,   'VoidSale', '1025', '12')
go
insert into employee_role_event values (2,   'PaidIn', '1025', '12' )
go
insert into employee_role_event values (3,   'PaidOut', '1025', '12' )
go
insert into employee_role_event values (4,   'TrainingMode', '1025', '12' )
go
insert into employee_role_event values (5,   'TerminalReports', '1025', '12')
go
insert into employee_role_event values (6,   'VoidItemLine', '1025', '12')
go
insert into employee_role_event values (7,   'Store', '1025', '12')
go
insert into employee_role_event values (8,   'Recall', '1025', '12')
go
insert into employee_role_event values (9,   'Shutdown', '1025', '12' )
go
insert into employee_role_event values (10,   'LogOff', '1025', '12')
go
insert into employee_role_event values (11,  'ReturnSale', '1025', '12')
go
insert into employee_role_event values (12,   'Discount', '1025', '12')
go
insert into employee_role_event values (13,   'Promotion', '1025', '12')
go
insert into employee_role_event values (14,   'Customer', '1025', '12')
go
insert into employee_role_event values (15,   'SystemManager', '1025', '12')
go
insert into employee_role_event values (16,   'ChangePrice', '1025', '12')
go
insert into employee_role_event values (17,   'ShutDown', '1025', '12')
go
insert into employee_role_event values (18,   'CreditTender', '1025','12' )
go
insert into employee_role_event values (19,  'AltCurrencyTender', '1025', '12' )
go
insert into employee_role_event values (20,  'CheckTender',  '1025', '12')
go
insert into employee_role_event values (21,  'DebtTender',  '1025', '12')
go






-- employee
--insert into employee values (100, 101, 1, 'Eclipse', 'ES', null, null, 0 )
--go 
INSERT INTO employee
           ([organization_no]
           ,[employee_no]
           ,[logon_no]
           ,[logon_pass]
           ,[role_id]
           ,[fname]
           ,[lname]
           ,[mi]
           ,[ssn]
           ,[sal_grade])
     VALUES
           ('12'
           ,'Eclipse100'
           ,'200'
           ,'3644A684F98EA8FE223C713B77189A77'
           ,'1025'
           ,'Eclipse'
           ,'ES'
           ,null
           ,null
           ,0)
 
go




INSERT INTO Retail_Store
           
     VALUES
           ('20'
			,'12'
		   ,'Eclipse Restaurant'
           ,'<--- address 1---------->'
           ,'<----address 2---------->'
           ,'<----address 3---------->'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
			,''
			,''
			,''
           ,0
		   ,null
			)


GO



INSERT INTO tax_group  VALUES ('20' ,'12','Zero GST')
go



insert into tax values ( 1, '20', '12', 1, 'GST 0%', 0.0, 0.0) 





INSERT into pos VALUES( 125, '12', 20, 0, 'Counter 01', '8-12-08', '8-12-08' )

go

INSERT into pos VALUES( 130, '12', 20, 0, 'Counter 02', '8-12-08', '8-12-08' )

go


insert into table_group values( '12', 20, 1, 'Main Dining Room')
go
insert into table_group values( '12', 20, 2, 'Banquet room')
go
insert into table_group values( '12', 20, 3, 'Patio')
go

insert into table_details values( '12', 20, 1, 'M1', 0, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M2', 0, 2, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M3', 0, 3, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M4', 0, 4, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M5', 0, 5, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M6', 0, 6, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M7', 0, 7, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M8', 0, 8, 4, '..\..\Images\A6.ico')
go

insert into table_details values( '12', 20, 1, 'M11', 1, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M12', 2, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M13', 3, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M14', 4, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M15', 5, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M16', 6, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '12', 20, 1, 'M17', 7, 1, 4, '..\..\Images\A6.ico')
go


insert into table_details values( '12', 20, 1, 'M21', 2, 3, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M22', 2, 5, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M23', 2, 7, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M24', 4, 3, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M25', 4, 5, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M26', 4, 7, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M27', 6, 3, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M28', 6, 5, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 1, 'M29', 6, 7, 7, '..\..\Images\A7.ico')
go




insert into table_details values( '12', 20, 3, 'B1', 1, 2, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B2', 2, 2, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B3', 3, 2, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B4', 4, 2, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B5', 5, 2, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B6', 6, 2, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B7', 7, 2, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B8', 7, 3, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B9', 7, 4, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B10', 7, 5, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B11', 6, 5, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B12', 5, 5, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B13', 4, 5, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B14', 3, 5, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B15', 2, 5, 4, '..\..\Images\A4.ico')
go
insert into table_details values( '12', 20, 3, 'B16', 1, 5, 4, '..\..\Images\A4.ico')
go




insert into table_details values( '12', 20, 2, 'P1', 1, 5, 4, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 2, 'P2', 2, 5, 4, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 2, 'P3', 3, 5, 4, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 2, 'P4', 4, 5, 4, '..\..\Images\A7.ico')
go
insert into table_details values( '12', 20, 2, 'P5', 5, 5, 4, '..\..\Images\A7.ico')
go







-- Coffee Dock I
insert into pos_key values (2, 201,	'Ctrl',		1,   51,		2001,		3, 170,			40,		48, 56,90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Coffee ','F1')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   52,		2002,		3, 170,			89,		48, 56,91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Expresso','F2')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   53,		2003,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Double Expresso','F3')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   54,		2004,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Decaf Expresso plus','F4')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   55,		2005,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Cappucino','F5')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   56,		2006,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Cappucino Double','F6')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   57,		2007,		3, 170,			138,	48, 56,92,	192,	131190,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Café Latte','F7')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   58,		2008,		3, 170,			138,	48, 56,92,	192,	131191,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Macchiato','F8')
go
insert into pos_key values (2, 201,	'Ctrl',		1,   59,		2009,		3, 170,			138,	48, 56,92,	192,	131192,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Americano','F9')
go



														  				


-- Tea Dock
insert into pos_key values (2, 202,	'Ctrl',		1,   101,		2021,		3, 170,			138,	48, 56,92,	192,	131184,	'\\Pictures\burger2', 1, 'EclipsePos.Apps.PosEvents.Plu', 'English Breakfast', 'F1')
go
insert into pos_key values (2, 202,	'Ctrl',		1,   102,		2022,		3, 170,			138,	48, 56,92,	192,	131185,	'\\Pictures\\Food - Burger 1.bmp', 1, 'EclipsePos.Apps.PosEvents.Plu','Chamomile','F2')
go
insert into pos_key values (2, 202,	'Ctrl',		1,   103,		2023,		3, 170,			138,	48, 56,92,	192,	131186,	null, 1, 'EclipsePos.Apps.PosEvents.Plu', 'Earl Grey', 'F3')
go
insert into pos_key values (2, 202,	'Ctrl',		1,   104,		2024,		3, 170,			138,	48, 56,92,	192,	131187,	null, 1, 'EclipsePos.Apps.PosEvents.Plu', 'Jasmine', 'F3')
go
insert into pos_key values (2, 202,	'Ctrl',		1,   105,		2025,		3, 170,			138,	48, 56,92,	192,	131188,	null, 1, 'EclipsePos.Apps.PosEvents.Plu', 'Peppermint', 'F3')
go
insert into pos_key values (2, 202,	'Ctrl',		1,   106,		2026,		3, 170,			138,	48, 56,92,	192,	131189,	null, 1, 'EclipsePos.Apps.PosEvents.Plu', 'Hot Chocolate', 'F3')
go





-- Soft Driks  
insert into pos_key values (2, 203,	'Ctrl',		1,   151,		2031,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Ginger Ale', 'F1')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   152,		2032,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Coke Light','F2')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   153,		2033,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Coke', 'F3')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   154,		2034,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Sprite', 'F4')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   155,		2035,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Ice Lemon Tea', 'F5')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   156,		2036,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'S P A Rossa', 'F6')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   157,		2037,		3, 170,			138,	48, 56,92,	192,	131190,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'S P Limonata', 'F7')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   158,		2038,		3, 170,			138,	48, 56,92,	192,	131191,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Sparkling Water', 'F8')
go
insert into pos_key values (2, 203,	'Ctrl',		1,   159,		2039,		3, 170,			138,	48, 56,92,	192,	131192,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Chinotto', 'F9')
go




-- Fruit Juices  
insert into pos_key values (2, 204,	'Ctrl',		1,   201,		2041,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Orange Juice', 'F1')
go
insert into pos_key values (2, 204,	'Ctrl',		1,   202,		2042,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Apple Juice','F2')
go
insert into pos_key values (2, 204,	'Ctrl',		1,   203,		2043,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Cranberry Juice','F3')
go
insert into pos_key values (2, 204,	'Ctrl',		1,   204,		2044,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Pineapple Juice','F4')
go
insert into pos_key values (2, 204,	'Ctrl',		1,   205,		2045,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Lime Juice','F5')
go
   

-- Salads  
insert into pos_key values (2, 301,	'Ctrl',		1,   1001,		2051,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Grilled Octopus', 'F1')
go
insert into pos_key values (2, 301,	'Ctrl',		1,   1002,		2052,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Rocket','F2')
go
insert into pos_key values (2, 301,	'Ctrl',		1,   1003,		2053,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Caprese','F3')
go
insert into pos_key values (2, 301,	'Ctrl',		1,   1004,		2054,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Mixed','F4')
go
   

--Appertizes
insert into pos_key values (2, 302,	'Ctrl',		1,   1051,		2061,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Gamberi Il Siciliano', 'F1')
go
insert into pos_key values (2, 302,	'Ctrl',		1,   1052,		2062,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Antipasto di Affettati','F2')
go
insert into pos_key values (2, 302,	'Ctrl',		1,   1053,		2063,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Beef Carpaccio','F3')
go
insert into pos_key values (2, 302,	'Ctrl',		1,   1054,		2064,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Calamari Fritti','F4')
go
insert into pos_key values (2, 302,	'Ctrl',		1,   1055,		2065,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Eggplant Parmiggiano','F5')
go
insert into pos_key values (2, 302,	'Ctrl',		1,   1056,		2066,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Prosciutto e Melone','F6')
go

--Pastas
insert into pos_key values (2, 303,	'Ctrl',		1,   1101,		2071,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Aglio Olio', 'F1')
go
insert into pos_key values (2, 303,	'Ctrl',		1,   1102,		2072,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Risotto Porchini','F2')
go
insert into pos_key values (2, 303,	'Ctrl',		1,   1103,		2073,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Lasagna','F3')
go
insert into pos_key values (2, 303,	'Ctrl',		1,   1104,		2074,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Bolognese','F4')
go
insert into pos_key values (2, 303,	'Ctrl',		1,   1105,		2075,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Risotto Frutti Di Mare','F5')
go
insert into pos_key values (2, 303,	'Ctrl',		1,   1106,		2076,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Cartocchio Allo Scoglio','F6')
go


--Second plates
insert into pos_key values (2, 304,	'Ctrl',		1,   1151,		2071,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Fileto ai Ferri', 'F1')
go
insert into pos_key values (2, 304,	'Ctrl',		1,   1152,		2072,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Costolette Di Agnello','F2')
go
insert into pos_key values (2, 304,	'Ctrl',		1,   1153,		2073,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Catch of the Day','F3')
go
insert into pos_key values (2, 304,	'Ctrl',		1,   1154,		2074,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Granchio Il Siciliano','F4')
go
insert into pos_key values (2, 304,	'Ctrl',		1,   1155,		2075,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Pollo Alla Milenese','F5')
go
insert into pos_key values (2, 304,	'Ctrl',		1,   1156,		2076,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Grilled Seafood','F6')
go

--Deserts
insert into pos_key values (2, 305,	'Ctrl',		1,   1201,		2081,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Tiramisu', 'F1')
go
insert into pos_key values (2, 305,	'Ctrl',		1,   1202,		2082,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Lava Cake','F2')
go
insert into pos_key values (2, 305,	'Ctrl',		1,   1203,		2083,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Pannacotta','F3')
go
insert into pos_key values (2, 305,	'Ctrl',		1,   1204,		2084,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Crème Caramel','F4')
go
insert into pos_key values (2, 305,	'Ctrl',		1,   1205,		2085,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Stracciatella','F5')
go
insert into pos_key values (2, 305,	'Ctrl',		1,   1206,		2086,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Spanish Sundae','F6')
go

--Pizzas
insert into pos_key values (2, 306,	'Ctrl',		1,   1301,		3001,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Margherita', 'F1')
go
insert into pos_key values (2, 306,	'Ctrl',		1,   1302,		3002,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Bolognese','F2')
go
insert into pos_key values (2, 306,	'Ctrl',		1,   1303,		3003,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Peperoni','F3')
go
insert into pos_key values (2, 306,	'Ctrl',		1,   1304,		3004,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Il Siciliano','F4')
go
insert into pos_key values (2, 306,	'Ctrl',		1,   1305,		3005,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Hawaiian','F5')
go
insert into pos_key values (2, 306,	'Ctrl',		1,   1306,		3006,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Vegetarian','F6')
go


--Classic Martinis
insert into pos_key values (2, 401,	'Ctrl',		1,   501,		3011,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Lychee Martini', 'F1')
go
insert into pos_key values (2, 401,	'Ctrl',		1,   502,		3012,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Dirty Martini','F2')
go
insert into pos_key values (2, 401,	'Ctrl',		1,   503,		3013,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Dry Martini','F3')
go
insert into pos_key values (2, 401,	'Ctrl',		1,   504,		3014,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Espresso Martini','F4')
go
insert into pos_key values (2, 401,	'Ctrl',		1,   505,		3015,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Chocolate Martini','F5')
go
insert into pos_key values (2, 401,	'Ctrl',		1,   506,		3016,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Apple Martini','F6')
go


--PREMIUM COCKTAILS
insert into pos_key values (2, 402,	'Ctrl',		1,   551,		3021,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Mojito', 'F1')
go
insert into pos_key values (2, 402,	'Ctrl',		1,   552,		3022,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Singapore Sling','F2')
go
insert into pos_key values (2, 402,	'Ctrl',		1,   553,		3023,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Tequila Sunrise','F3')
go
insert into pos_key values (2, 402,	'Ctrl',		1,   554,		3024,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Long Island Tea','F4')
go
insert into pos_key values (2, 402,	'Ctrl',		1,   555,		3025,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Caipihrovska','F5')
go
insert into pos_key values (2, 402,	'Ctrl',		1,   556,		3026,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Caipirinha','F6')
go


--SHOOTERS
insert into pos_key values (2, 403,	'Ctrl',		1,   601,		3031,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Mini Mary', 'F1')
go
insert into pos_key values (2, 403,	'Ctrl',		1,   602,		3032,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','B52','F2')
go
insert into pos_key values (2, 403,	'Ctrl',		1,   603,		3033,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Apple Sourz','F3')
go
insert into pos_key values (2, 403,	'Ctrl',		1,   604,		3034,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Baileys Irish Cream','F4')
go
insert into pos_key values (2, 403,	'Ctrl',		1,   605,		3035,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Jagermeister','F5')
go
insert into pos_key values (2, 403,	'Ctrl',		1,   606,		3036,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Limoncello','F6')
go

--DIGESTIVE
insert into pos_key values (2, 404,	'Ctrl',		1,   651,		3041,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Ramazotti', 'F1')
go
insert into pos_key values (2, 404,	'Ctrl',		1,   652,		3042,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Averna','F2')
go
insert into pos_key values (2, 404,	'Ctrl',		1,   653,		3043,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Amaro Montenegro','F3')
go

--HOUSEPOUR SPIRITS
insert into pos_key values (2, 405,	'Ctrl',		1,   701,		3051,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Gin', 'F1')
go
insert into pos_key values (2, 405,	'Ctrl',		1,   702,		3052,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Vodka','F2')
go
insert into pos_key values (2, 405,	'Ctrl',		1,   703,		3053,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Rum','F3')
go
insert into pos_key values (2, 405,	'Ctrl',		1,   704,		3054,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Tequila','F4')
go
insert into pos_key values (2, 405,	'Ctrl',		1,   705,		3055,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Bourbon','F5')
go
insert into pos_key values (2, 405,	'Ctrl',		1,   706,		3056,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Whisky','F6')
go

	
--WHITE WINE
insert into pos_key values (2, 406,	'Ctrl',		1,   751,		3061,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Moscato DAsti Spumante', 'F1')
go
insert into pos_key values (2, 406,	'Ctrl',		1,   752,		3062,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','2009 Noe Orvieto','F2')
go
insert into pos_key values (2, 406,	'Ctrl',		1,   753,		3063,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','2008/09 Calanchi Di Vaiano','F3')
go
insert into pos_key values (2, 406,	'Ctrl',		1,   754,		3064,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','2009 Soave Classico','F4')
go
insert into pos_key values (2, 406,	'Ctrl',		1,   755,		3065,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','2009 Le Monde','F5')
go
insert into pos_key values (2, 406,	'Ctrl',		1,   756,		3066,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','2009 Franz Haas Manna','F6')
go


--RED WINE
insert into pos_key values (2, 407,	'Ctrl',		1,   801,		3071,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', '2006 Villa Tirrena', 'F1')
go
insert into pos_key values (2, 407,	'Ctrl',		1,   802,		3072,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Vignamaggio Chianti Classico','F2')
go
insert into pos_key values (2, 407,	'Ctrl',		1,   803,		3073,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Al Passo','F3')
go
insert into pos_key values (2, 407,	'Ctrl',		1,   804,		3074,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Vignamaggio Chianti','F4')
go
insert into pos_key values (2, 407,	'Ctrl',		1,   805,		3075,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Brunello di Montalcino','F5')
go
insert into pos_key values (2, 407,	'Ctrl',		1,   806,		3076,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','CentAre Rosso','F6')
go


--CHAMPAGNE
insert into pos_key values (2, 408,	'Ctrl',		1,   851,		3081,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Zefiro Prosecco Brut', 'F1')
go
insert into pos_key values (2, 408,	'Ctrl',		1,   852,		3082,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','La Carte Blanche Brut','F2')
go


-- BEERS
insert into pos_key values (2, 409,	'Ctrl',		1,   901,		3091,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Heineken', 'F1')
go
insert into pos_key values (2, 409,	'Ctrl',		1,   902,		3092,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Carlsberg','F2')
go
insert into pos_key values (2, 409,	'Ctrl',		1,   903,		3093,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Peroni','F3')
go
insert into pos_key values (2, 409,	'Ctrl',		1,   904,		3094,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Hoegaarden','F4')
go
insert into pos_key values (2, 409,	'Ctrl',		1,   905,		3095,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Stella Artois','F5')
go
insert into pos_key values (2, 409,	'Ctrl',		1,   906,		3096,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Corona Extra','F6')
go






-- Coffee
INSERT INTO ITEM VALUES('12', '51' ,'Coffee' , 4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

INSERT INTO ITEM VALUES('12', '52' ,'Expresso' ,4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

INSERT INTO ITEM VALUES('12', '53' ,'Double Expresso' ,4.00,  null, null, 20, '1', null, null, 1, 0, null, null,  null)
go
INSERT INTO ITEM VALUES('12', '54' ,'Decaf Expresso' , 4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

INSERT INTO ITEM VALUES('12', '55' ,'Cappucino' ,4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

INSERT INTO ITEM VALUES('12', '56' ,'Cappucino Double' ,4.0,  null, null, 20, '1', null, null, 1, 0, null, null,  null)
go

INSERT INTO ITEM VALUES('12', '57' ,'Café Latte' , 4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

INSERT INTO ITEM VALUES('12', '58' ,'Macchiato' ,4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

INSERT INTO ITEM VALUES('12', '59' ,'Americano' ,4.0,  null, null, 20, '1', null, null, 1, 0, null, null,  null)
go
INSERT INTO ITEM VALUES('12', '60' ,'Iced Coffee' ,4.0,  null, null, 20, '1', null, null, 1, 0, null, null,  null)
go
INSERT INTO ITEM VALUES('12', '61' ,'Iced Latte' ,4.0,  null, null, 20, '1', null, null, 1, 0, null, null,  null)
go



--Tea
INSERT INTO ITEM VALUES('12', '101' ,'English Breakfast' , 4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '102' ,'Chamomile' ,4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '103' ,'Earl Grey' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '104' ,'Jasmine' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '105' ,'Peppermint' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '106' ,'Hot Chocolate' ,5.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--Soft Drinks
INSERT INTO ITEM VALUES('12', '151' ,'Ginger Ale' , 4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '152' ,'Coke Light' ,4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '153' ,'Coke' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '154' ,'Sprite' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '155' ,'Ice Lemon Tea' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '156' ,'San Pellegrino Arranciata Rossa' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '157' ,'San Pelegrino Limonata' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '158' ,'Sparkling Water' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '159' ,'Chinotto' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go



--Fruit Juices
INSERT INTO ITEM VALUES('12', '201' ,'Orange Juice' , 4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '202' ,'Apple Juice' ,4.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '203' ,'Cranberry Juice' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '204' ,'Pineapple Juice' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '205' ,'Lime Juice' ,4.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--Martinis
INSERT INTO ITEM VALUES('12', '501' ,'Lychee Martini' , 14.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '502' ,'Dirty Martini' ,14.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '503' ,'Dry Martini' ,13.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '504' ,'Espresso Martini' ,14.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '505' ,'Chocolate Martini' ,13.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '506' ,'Apple Martini' ,14.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go



--PREMIUM COCKTAILS
INSERT INTO ITEM VALUES('12', '551' ,'Mojito' , 13.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '552' ,'Singapore Sling' ,16.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '553' ,'Tequila Sunrise' ,14.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '554' ,'Long Island Tea' ,14.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '555' ,'Caipihrovska' ,13.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '556' ,'Caipirinha' ,16.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--SHOOTERS
INSERT INTO ITEM VALUES('12', '601' ,'Mini Mary' , 8.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '602' ,'B52' ,8.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '603' ,'Apple Sourz' ,5.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '604' ,'Baileys Irish Cream' ,7.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '605' ,'Jagermeister' ,6.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '606' ,'Limoncello' ,5.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--DIGESTIVE
INSERT INTO ITEM VALUES('12', '651' ,'Ramazotti' , 6.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '652' ,'Averna' ,5.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '653' ,'Amaro Montenegro' ,6.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--HOUSEPOUR SPIRITS
INSERT INTO ITEM VALUES('12', '701' ,'Gin' , 9.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '702' ,'Vodka' ,9.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '703' ,'Rum' ,9.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '704' ,'Tequila' ,9.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '705' ,'Bourbon' ,9.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '706' ,'Whisky' ,9.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

--WHITE WINE
INSERT INTO ITEM VALUES('12', '751' ,'Moscato DAsti Spumante' , 48.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '752' ,'2009 Noe Orvieto' ,58.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '753' ,'2008/09 Calanchi Di Vaiano' ,68.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '754' ,'2009 Soave Classico' ,58.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '755' ,'2009 Le Monde' ,79.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '756' ,'2009 Franz Haas Manna' ,109.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

--RED WINE
INSERT INTO ITEM VALUES('12', '801' ,'2006 Villa Tirrenae' , 68.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '802' ,'2007 Vignamaggio Chianti Classico' ,68.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '803' ,'2007 Al Passo' ,68.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '804' ,'2007 Vignamaggio Chianti Riserva Monna Lisa' ,98.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '805' ,'2005 Brunello di Montalcino' ,179.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '806' ,'2008 CentAre Rosso' ,58.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

--CHAMPAGNE
INSERT INTO ITEM VALUES('12', '851' ,'Zefiro Prosecco Brut' ,58.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '852' ,'La Carte Blanche Brut' ,58.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

--BEERS
INSERT INTO ITEM VALUES('12', '901' ,'Heineken' , 8.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '902' ,'Carlsberg' ,8.00,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '903' ,'Peroni' ,8.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '904' ,'Hoegaarden' ,8.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '905' ,'Stella Artois' ,9.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '906' ,'Corona Extra' ,8.0,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--SALADS
INSERT INTO ITEM VALUES('12', '1001' ,'Grilled Octopus Salad' , 16.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1002' ,'Rocket Salad' ,12.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1003' ,'Caprese Salad' ,13.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1004' ,'Mixed Salad' ,10.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)


-- APPETIZERS
INSERT INTO ITEM VALUES('12', '1051' ,'Gamberi Il Siciliano' , 17.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1052' ,'Antipasto di Affettati' ,26.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1053' ,'Beef Carpaccio' ,16.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1054' ,'Calamari Fritti' ,15.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1055' ,'Eggplant Parmiggiano' ,11.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1056' ,'Prosciutto e Melone' ,12.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go

-- PSSTAS
INSERT INTO ITEM VALUES('12', '1101' ,'Aglio Olio' , 12.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1102' ,'Risotto Porchini' ,15.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1103' ,'Lasagna' ,14.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1104' ,'Bolognese' ,16.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1105' ,'Risotto Frutti Di Mare' ,16.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1106' ,'Cartocchio Allo Scoglio' ,24.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go




--SECOND PLATES
INSERT INTO ITEM VALUES('12', '1151' ,'Fileto ai Ferri' , 26.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1152' ,'Costolette Di Agnello' ,32.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1153' ,'Catch of the Day' ,28.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1154' ,'Granchio Il Siciliano' ,29.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1155' ,'Pollo Alla Milenese' ,20.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1156' ,'Grilled Seafood' ,32.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--DESERTS
INSERT INTO ITEM VALUES('12', '1201' ,'Tiramisu' , 8.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1202' ,'Lava Cake' ,8.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1203' ,'Pannacotta' ,7.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1204' ,'Crème Caramel' ,7.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1205' ,'Stracciatella' ,9.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1206' ,'Spanish Sundae' ,9.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go


--PIZZAS
INSERT INTO ITEM VALUES('12', '1301' ,'Margherita' , 15.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1302' ,'Bolognese' ,16.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1303' ,'Peperoni' ,18.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1304' ,'Il Siciliano' ,18.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1305' ,'Hawaiian' ,20.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go
INSERT INTO ITEM VALUES('12', '1306' ,'Vegetarian' ,18.88,  null, null, 20, '1', null, null, 1, 0,  null, null, null)
go



-- Promotions
insert into promotion values ( '12',	101,	1,   3, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Group Discount',	'EclipsePos.Apps.Operators.GroupDiscount' )
go
insert into promotion values ( '12',	201,	1,   3, 0, 0, 0, 0,   10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', '3 for $10',	'EclipsePos.Apps.Operators.NForX' )
go
insert into promotion values ( '12',	1,		1,   1, 0, 0, 0, 0,    10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '12',	2,		1,   1, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '12',	3,		2,   1, 0, 0, 0, 0,    10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '12',	4,		2,   1, 0, 0, 0, 0,    15.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Order discount',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '12',	5,		2,   1, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Order discount',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '12',	999,	1,   1, 0, 0, 0, 0,    0.05,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Rounding Adjustment',	'EclipsePos.Apps.Operators.RoundDownToFactorN' )
go


-- Sercharge
INSERT INTO surcharge VALUES ('12',	'SUR10',	'Service charge',	10.00,	0,	' ',	'10',	0,	0,	25)
go

























