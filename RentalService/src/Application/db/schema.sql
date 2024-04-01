
    drop table if exists delivery_drivers cascade

    drop table if exists deliveries cascade

    drop table if exists motorcycles cascade

    drop table if exists orders cascade

    drop table if exists rentals cascade

    drop table if exists rental_plans cascade

    create table delivery_drivers (
        Id uuid not null,
       modified_at timestamp not null,
       name varchar(255) not null,
       cnpj varchar(255) not null,
       birthdate timestamp not null,
       cnh_number varchar(255),
       cnh_image_url varchar(255),
       cnh_type varchar(255),
       primary key (Id),
      unique (cnpj),
      unique (cnh_number)
    )

    create table deliveries (
        Id uuid not null,
       modified_at timestamp not null,
       notification_date timestamp not null,
       avaliable boolean not null,
       order_id uuid not null,
       delivery_status varchar(255) not null,
       delivery_driver_id uuid,
       primary key (Id)
    )

    create table motorcycles (
        Id uuid not null,
       modified_at timestamp not null,
       year int2 not null,
       model varchar(255) not null,
       plate varchar(255) not null,
       primary key (Id),
      unique (plate)
    )

    create table orders (
        Id uuid not null,
       modified_at timestamp not null,
       creation_date timestamp not null,
       delivery_fee float8 not null,
       delivered_by uuid,
       order_status varchar(255) not null,
       primary key (Id)
    )

    create table rentals (
        Id uuid not null,
       modified_at timestamp not null,
       delivery_driver_id uuid not null,
       motorcycle_id uuid not null,
       rental_plan_id uuid not null,
       start_date timestamp not null,
       end_date timestamp,
       forecast_end_date timestamp not null,
       days int2 not null,
       price_per_day float8 not null,
       primary key (Id)
    )

    create table rental_plans (
        Id uuid not null,
       modified_at timestamp not null,
       Days int2 not null,
       Price float8 not null,
       PaymentFine float8 not null,
       primary key (Id)
    )

    alter table deliveries 
        add constraint fk_delivery_driver_id 
        foreign key (delivery_driver_id) 
        references delivery_drivers
