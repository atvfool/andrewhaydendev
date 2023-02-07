CREATE TABLE `main` (
	`Name` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`Titles` VARCHAR(150) NOT NULL COLLATE 'latin1_swedish_ci',
	`Email` VARCHAR(150) NOT NULL COLLATE 'latin1_swedish_ci',
	`Phone` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`GItHubLink` VARCHAR(150) NOT NULL COLLATE 'latin1_swedish_ci',
	`LinkedInLink` VARCHAR(150) NOT NULL COLLATE 'latin1_swedish_ci',
	`AboutBlurb` TEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`AboutTitle` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`Birthday` DATETIME NOT NULL DEFAULT curdate(),
	`Website` VARCHAR(150) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`CityState` VARCHAR(150) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`AboutStrengths` TEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`FreelanceAvailable` BIT(1) NOT NULL DEFAULT b'0',
	`AboutAfterBlurb` TEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`FactsBlurb` TEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`FactsDatabases` INT(11) NOT NULL DEFAULT '0',
	`FactsProjects` INT(11) NOT NULL DEFAULT '0',
	`FactsHoursOfCode` INT(11) NOT NULL DEFAULT '0',
	`FactsRunningPCs` INT(11) NOT NULL DEFAULT '0',
	`SkillsBlurb` TEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`ResumeBlurb` TEXT NOT NULL COLLATE 'latin1_swedish_ci',
	`ProjectsBlurb` TEXT NOT NULL COLLATE 'latin1_swedish_ci'
	`ResumeLink` VARCHAR(255) NOT NULL COLLATE 'latin1_swedish_ci'
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;
