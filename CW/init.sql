create table role(
id smallserial primary key,
name varchar(30) not null unique
);

create table "user"(
id smallserial primary key,
login varchar(32) not null unique,
fio varchar(100) not null,
password_hash varchar(128) not null,
role_id smallint not null,
foreign key (role_id) references role(id)
);

create table automechanic(
user_id smallint primary key,
qualification varchar(30) not null,
foreign key (user_id) references "user"(id)
);

create table driver(
user_id smallint primary key,
driver_license bigint not null unique,
experience smallint not null,
foreign key  (user_id) references "user"(id)
);

create table manufacturer(
id smallserial primary key,
name varchar(20) not null unique
);

create table vehicle_category(
id smallserial primary key,
name varchar(25) not null unique
);

create table fuel_type(
id smallserial primary key,
name varchar(20) not null unique
);

create table vehicle_model(
id serial primary key,
name varchar(40) not null,
manufacturer_id smallint not null,
vehicle_category_id smallint not null,
power smallint not null,
fuel_type_id smallint not null,
load_capacity int not null,
foreign key (manufacturer_id) references manufacturer(id),
foreign key (vehicle_category_id) references vehicle_category(id),
foreign key (fuel_type_id) references fuel_type(id)
);

create table document_type(
id smallserial primary key,
name varchar(20) not null unique
);

create table vehicle_status(
id smallserial primary key,
name varchar(20) not null unique
);

create table vehicle(
id serial primary key,
vin_number varchar(17) not null unique,
plate_number varchar(15) not null unique,
vehiclemodel_id int4 not null,
release_year smallint not null,
registration_date date not null,
status_id smallint not null,
foreign key (vehiclemodel_id) references vehicle_model(id),
foreign key (status_id) references vehicle_status(id)
);

create table vehicle_photo(
id serial primary key,
src varchar(255) not null unique,
vehicle_id int4 not null,
foreign key (vehicle_id) references vehicle(id)
);

create table fuel_measurement_history(
id serial primary key,
volume numeric(7,3) not null,
measurement_date date not null,
vehicle_id int4 not null,
foreign key (vehicle_id) references vehicle(id)
);

create table mileage_measurement_history(
id serial primary key,
km_count numeric(9,3) not null,
measurement_date date not null,
vehicle_id int4 not null,
foreign key (vehicle_id) references vehicle(id)
);

create table repair_history(
id serial primary key,
vehicle_id int4 not null,
datetime_begin timestamp not null,
datetime_end timestamp,
completed_work varchar(2000) not null,
price numeric(9,2),
servicestation_tin_number bigint,
automechanic_id int2,
foreign key (vehicle_id) references vehicle(id),
foreign key (automechanic_id) references automechanic(user_id)
);

create table spare_part(
id serial primary key,
name varchar(100) not null unique,
count_left int4 default(0)
);

create table repair_consumed_spare_part(
id serial primary key,
repair_id int4 not null,
spare_part_id int4 not null,
part_count int4 not null,
foreign key (repair_id) references repair_history(id),
foreign key (spare_part_id) references spare_part(id)
);

create table oil_type(
id smallserial primary key,
name varchar(10) not null unique,
fuel_type_id smallint not null,
foreign key (fuel_type_id) references fuel_type(id)
);

create table refueling_history(
id serial primary key,
volume numeric(7,3) not null,
oil_type_id smallint not null,
fuelstation_tin_number bigint not null,
vehicle_id int4 not null,
price numeric(9,2) not null,
datetime timestamp not null,
driver_id smallint not null,
foreign key (oil_type_id) references oil_type(id),
foreign key (vehicle_id) references vehicle(id),
foreign key (driver_id) references driver(user_id)
);
create table maintenance_type(
id smallserial primary key,
name varchar(30) not null unique
);

create table maintenance_history(
id serial primary key,
date date not null,
vehicle_id int4 not null,
maintenance_type_id smallint not null,
completed_work varchar(2000) not null,
automechanic_id smallint not null,
foreign key (vehicle_id) references vehicle(id),
foreign key (maintenance_type_id) references maintenance_type(id),
foreign key (automechanic_id) references automechanic(user_id)
);

create table planned_maintenance_schedule(
id serial primary key,
planned_date date not null,
maintenance_type_id smallint not null,
vehicle_id int4 not null,
foreign key (maintenance_type_id) references maintenance_type(id),
foreign key (vehicle_id) references vehicle(id)
);

create table vehicle_document(
id serial primary key,
doctype_id smallint not null,
src varchar(255) not null unique,
vehicle_id int4 not null,
foreign key (vehicle_id) references vehicle(id),
foreign key (doctype_id) references document_type(id)
);