
    drop table if exists motorcycles cascade

    create table motorcycles (
        Id uuid not null,
       modified_at timestamp not null,
       year int2 not null,
       model varchar(255) not null,
       plate varchar(255) not null,
       primary key (Id),
      unique (plate)
    )
