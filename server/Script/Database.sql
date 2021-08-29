CREATE TABLE subscriptions (
    id uuid NOT NULL,
    youtubeid varchar(80) NULL,
    type text NULL,
    title varchar(200) NOT NULL,
    description varchar(800) NOT NULL,
    publishedat timestamp NULL,
    defaultthumbnail varchar(100) NULL,
    mediumthumbnail varchar(100) NULL,
    highthumbnail varchar(100) NULL,
    CONSTRAINT pk_subscriptions PRIMARY KEY (id)
);


