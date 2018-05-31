BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `calc` (
	`id_calc`	integer PRIMARY KEY AUTOINCREMENT,
	`id_user`	integer NOT NULL,
	`value_n`	integer,
	`value_rnd`	integer,
	`calc_num`	integer,
	`calc_result`	float,
	FOREIGN KEY(`id_user`) REFERENCES `auth`(`id_user`)
);
CREATE TABLE IF NOT EXISTS `auth` (
	`id_user`	integer PRIMARY KEY AUTOINCREMENT,
	`login`	text,
	`password`	text,
	`access_type`	integer,
	FOREIGN KEY(`access_type`) REFERENCES `acctype`(`id_type`)
);
INSERT INTO `auth` VALUES (1,'admin','admin',1);
INSERT INTO `auth` VALUES (2,'Lannica','qwerty',2);
CREATE TABLE IF NOT EXISTS `acctype` (
	`id_type`	integer PRIMARY KEY AUTOINCREMENT,
	`access_type`	text
);
INSERT INTO `acctype` VALUES (1,'Администратор');
INSERT INTO `acctype` VALUES (2,'Пользователь');
COMMIT;
