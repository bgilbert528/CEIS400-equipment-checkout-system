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
-- Table structure for table `vehicles`
--

DROP TABLE IF EXISTS `vehicles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicles` (
  `VehicleID` char(36) NOT NULL,
  `Make` varchar(45) DEFAULT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `Year` year DEFAULT NULL,
  `SerialNum` varchar(100) DEFAULT NULL,
  `Remarks` varchar(250) DEFAULT NULL,
  `CertRequired` tinyint DEFAULT NULL,
  `InDate` datetime DEFAULT NULL,
  `OutDate` datetime DEFAULT NULL,
  `Status` enum('In','Out','Missing','OutForService') DEFAULT NULL,
  PRIMARY KEY (`VehicleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicles`
--

/*!40000 ALTER TABLE `vehicles` DISABLE KEYS */;
INSERT INTO `vehicles` VALUES ('b5ee7b11-8415-11f0-9b07-94bb4370fbe7','Ford','Transit',2020,'SN10001','Delivery van',1,NULL,NULL,'Missing'),('b5ee8032-8415-11f0-9b07-94bb4370fbe7','Toyota','Hilux',2018,'SN10002','Pickup truck',1,'2025-08-28 09:48:42','2025-08-28 09:48:42','OutForService'),('b5ee8181-8415-11f0-9b07-94bb4370fbe7','Chevy','Express',2019,'SN10003','Service van',1,'2025-08-28 09:48:42','2025-08-28 09:48:42','Out'),('b5ee82cc-8415-11f0-9b07-94bb4370fbe7','Mercedes','Sprinter',2021,'SN10004','Cargo van',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ee83fc-8415-11f0-9b07-94bb4370fbe7','Ford','F-150',2017,'SN10005','Pickup',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ee8586-8415-11f0-9b07-94bb4370fbe7','Ram','1500',2019,'SN10006','Pickup',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ee862e-8415-11f0-9b07-94bb4370fbe7','Nissan','NV200',2020,'SN10007','Van',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ee86b3-8415-11f0-9b07-94bb4370fbe7','Volkswagen','Crafter',2018,'SN10008','Cargo van',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ee873e-8415-11f0-9b07-94bb4370fbe7','Toyota','Tacoma',2021,'SN10009','Pickup',1,'2025-08-28 09:48:42','2025-08-28 09:48:42','Out'),('b5ee87c5-8415-11f0-9b07-94bb4370fbe7','Ford','Transit Connect',2019,'SN10010','Delivery van',1,'2025-08-28 09:48:42','0001-01-01 00:00:00','In');
/*!40000 ALTER TABLE `vehicles` ENABLE KEYS */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-28 16:04:25
