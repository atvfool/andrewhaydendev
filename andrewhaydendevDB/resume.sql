CREATE TABLE `resume` (
	`ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
	`IsEducation` BIT(1) NOT NULL DEFAULT b'0',
	`Header` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`Years` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`Name` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`CityState` VARCHAR(150) NOT NULL COLLATE 'latin1_swedish_ci',
	`Active` BIT(1) NOT NULL DEFAULT b'1',
	`Order` INT(11) NULL DEFAULT NULL,
	PRIMARY KEY (`ID`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
AUTO_INCREMENT=6
;
