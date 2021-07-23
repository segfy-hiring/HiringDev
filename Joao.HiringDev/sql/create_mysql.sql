create database db_hiring_dev;

use db_hiring_dev;

create table VideosYoutube 
(
	Id varchar(255),
	Title varchar(1000),
    Description varchar(2000),
    ChannelId varchar(255),
    ChannelTitle varchar(1000),
	PublishedAtRaw varchar(25),
    LiveBroadcastContent varchar(255),
    ETag varchar(1000),
    ThumbnailUrlVideoImage varchar(1000)
) CHARACTER SET utf8 COLLATE utf8_unicode_ci;

create table CanaisYoutube 
(
	Id varchar(255),
	Title varchar(1000),
    Description varchar(2000),
    ChannelId varchar(255),
    ChannelTitle varchar(1000),
	PublishedAtRaw varchar(25),
    LiveBroadcastContent varchar(255),
    ETag varchar(1000),
    ThumbnailUrlVideoImage varchar(1000)
) CHARACTER SET utf8 COLLATE utf8_unicode_ci ;

-- drop table CanaisYoutube;
-- drop table VideosYoutube;

select * from CanaisYoutube;
select * from VideosYoutube;