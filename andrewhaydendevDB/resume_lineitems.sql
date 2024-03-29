﻿CREATE TABLE `resume_lineitems` (
	`ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
	`ResumeID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
	`Text` TEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`Order` INT(11) NOT NULL DEFAULT '0',
	PRIMARY KEY (`ID`) USING BTREE,
	INDEX `FK_Resume_LineItems_Resume` (`ResumeID`) USING BTREE,
	CONSTRAINT `FK_Resume_LineItems_Resume` FOREIGN KEY (`ResumeID`) REFERENCES `resume` (`ID`) ON UPDATE RESTRICT ON DELETE RESTRICT
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
AUTO_INCREMENT=19
;
