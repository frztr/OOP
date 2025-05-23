create table role (
    id smallserial primary key,
    name varchar(15) not null unique
);

create table "user" (
    id bigserial primary key,
    first_name varchar(50) not null,
    last_name varchar(50) not null,
    patronymic varchar(20),
    email varchar(100) not null unique,
    phone varchar(20) not null unique,
    password_hash varchar(32) not null,
    role_id int2,
    foreign key (role_id) references role(id)
);

create table location(
id smallserial primary key,
name varchar(50) not null unique,
address varchar(100),
number_of_seats int
);

create table event_category(
id smallserial primary key,
name varchar(50) not null unique
);

create table event(
id serial primary key,
title varchar(50) not null unique,
description varchar(300) not null,
location_id int2 not null,
start_time timestamp not null,
end_time timestamp not null,
created_by bigint not null,
event_category_id int2 not null,
foreign key(location_id) references location(id),
foreign key(created_by) references "user"(id),
foreign key(event_category_id) references event_category(id)
);

create table booking_status(
id smallserial primary key,
name varchar(50) not null unique
);

create table booking(
id bigserial primary key,
user_id bigint not null,
event_id int not null,
booking_date timestamp not null,
booking_status_id int2,
number_of_seats int default 1,
foreign key (user_id) references "user"(id),
foreign key (event_id) references event(id),
foreign key (booking_status_id) references booking_status(id)
);

create table payment_method(
id smallserial primary key,
name varchar(50) not null
);

create table payment_status(
id smallserial primary key,
name varchar(50) not null
);

create table payment(
    id bigserial primary key,
booking_id bigint not null, 
amount numeric(10, 2) not null,
payment_date timestamp not null,
payment_method_id int2 not null,
status_id int2 not null,
foreign key(booking_id) references booking(id),
foreign key(payment_method_id) references payment_method(id),
foreign key(status_id) references payment_status(id)
);

create table review (
id bigserial primary key,
user_id bigint not null,
event_id int2 not null,
rating int2 not null,
comment varchar(500),
review_date timestamp,
foreign key (user_id) references "user"(id),
foreign key (event_id) references event(id)
);