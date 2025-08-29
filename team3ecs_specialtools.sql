CREATE DATABASE  IF NOT EXISTS `team3ecs` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `team3ecs`;
-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: team3ecs
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `specialtools`
--

DROP TABLE IF EXISTS `specialtools`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `specialtools` (
  `SToolID` char(36) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  `Remarks` varchar(250) DEFAULT NULL,
  `CalDate` datetime DEFAULT NULL,
  `CalDue` datetime DEFAULT NULL,
  `Included` varchar(1000) DEFAULT NULL,
  `CertRequired` tinyint(1) DEFAULT NULL,
  `InDate` datetime DEFAULT NULL,
  `OutDate` datetime DEFAULT NULL,
  `Status` enum('In','Out','Missing','OutForService') DEFAULT NULL,
  PRIMARY KEY (`SToolID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specialtools`
--

/*!40000 ALTER TABLE `specialtools` DISABLE KEYS */;
INSERT INTO `specialtools` VALUES ('b5ed9a70-8415-11f0-9b07-94bb4370fbe7','Digital Multimeter','Electronic','Voltage/current measurements','2025-08-28 09:48:42','2026-08-28 09:48:42','Meter, Probes, Case',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5edb412-8415-11f0-9b07-94bb4370fbe7','Thermal Camera','Imaging','Check hotspots','2025-08-28 09:48:42','2026-02-28 09:48:42','Camera, Lens, Case',1,'2025-08-28 09:48:42','2025-08-28 09:48:42','OutForService'),('b5edb5e0-8415-11f0-9b07-94bb4370fbe7','Pressure Gauge','Mechanical','Calibrate monthly','2025-08-28 09:48:42','2025-11-28 09:48:42','Gauge, Hose, Case',0,'2025-08-28 09:48:42','2025-08-28 09:48:42','Out'),('b5edb69f-8415-11f0-9b07-94bb4370fbe7','Sound Level Meter','Electronic','Noise measurements','2025-08-28 09:48:42','2026-08-28 09:48:42','Meter, Tripod, Case',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5edb7d7-8415-11f0-9b07-94bb4370fbe7','Gas Detector','General','Safety','2025-08-28 09:48:42','2026-02-28 09:48:42','Detector,Battery,Case',1,NULL,'2025-07-31 09:48:43','Missing'),('b5edb916-8415-11f0-9b07-94bb4370fbe7','Moisture Meter','Electronic','For wood and concrete','2025-08-28 09:48:42','2026-08-28 09:48:42','Meter, Probes, Case',0,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5edba54-8415-11f0-9b07-94bb4370fbe7','Laser Distance Meter','Electronic','Measure distances','2025-08-28 09:48:42','2026-08-28 09:48:42','Meter, Battery, Case',0,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5edbbe0-8415-11f0-9b07-94bb4370fbe7','Vibration Meter','Electronic','Machines monitoring','2025-08-28 09:48:42','2026-08-28 09:48:42','Meter, Tripod, Case',1,'2025-08-28 09:48:42','2025-08-28 09:48:42','OutForService'),('b5edbcc9-8415-11f0-9b07-94bb4370fbe7','Torque Wrench','Mechanical','Calibrate bolts','2025-08-28 09:48:42','2026-02-28 09:48:42','Wrench, Calibration Weights, Case',0,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5edbd6b-8415-11f0-9b07-94bb4370fbe7','Data Logger','Electronic','Monitor equipment','2025-08-28 09:48:42','2026-08-28 09:48:42','Logger, Cables, Case',1,'2025-08-28 09:48:42','2025-08-28 09:48:42','Out');
/*!40000 ALTER TABLE `specialtools` ENABLE KEYS */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-28 16:04:25
