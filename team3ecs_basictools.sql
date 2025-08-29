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
-- Table structure for table `basictools`
--

DROP TABLE IF EXISTS `basictools`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basictools` (
  `ToolID` char(36) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Included` varchar(1000) DEFAULT NULL,
  `Remarks` varchar(1000) DEFAULT NULL,
  `InDate` datetime DEFAULT NULL,
  `OutDate` datetime DEFAULT NULL,
  `Status` enum('In','Out','Missing','OutForService') DEFAULT NULL,
  PRIMARY KEY (`ToolID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basictools`
--

/*!40000 ALTER TABLE `basictools` DISABLE KEYS */;
INSERT INTO `basictools` VALUES ('b5eca0e5-8415-11f0-9b07-94bb4370fbe7','Hammer','','Standard hammer','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5eca7b2-8415-11f0-9b07-94bb4370fbe7','Screwdriver Set','Flathead, Philips, Case','Includes flathead and Philips','2025-08-28 09:48:42','2025-08-28 09:48:42','Out'),('b5eca9e5-8415-11f0-9b07-94bb4370fbe7','Wrench Set','Metric Wrenches, SAE Wrenches, Case','Metric and SAE sizes','2025-08-28 09:48:42','0001-01-01 00:00:00','OutForService'),('b5ecaaac-8415-11f0-9b07-94bb4370fbe7','Pliers','','Standard pliers','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecab48-8415-11f0-9b07-94bb4370fbe7','Tape Measure','Tape, Case','25ft','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecabdf-8415-11f0-9b07-94bb4370fbe7','Level','24-inch Level, Carry Bag','24-inch','2025-08-28 09:48:42','2025-08-28 09:48:42','Out'),('b5ecac70-8415-11f0-9b07-94bb4370fbe7','Chisel','Wood Chisel, Handle','Wood chisel','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecacfa-8415-11f0-9b07-94bb4370fbe7','Handsaw','Crosscut Saw, Blade Cover','Crosscut saw','2025-08-28 09:48:42','2025-08-28 09:48:42','Out'),('b5ecad89-8415-11f0-9b07-94bb4370fbe7','Utility Knife','Knife, Extra Blades','Retractable','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecae25-8415-11f0-9b07-94bb4370fbe7','Clamp','C-Clamp, Screws','C-clamp','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecaeaf-8415-11f0-9b07-94bb4370fbe7','Crowbar','Crowbar, Grip','16-inch','2025-08-28 09:48:42','2025-08-28 09:48:42','Out'),('b5ecaf3a-8415-11f0-9b07-94bb4370fbe7','Wire Cutter','','Electrical','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb054-8415-11f0-9b07-94bb4370fbe7','Hex Key Set','Metric Keys, SAE Keys','Metric/SAE','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb10e-8415-11f0-9b07-94bb4370fbe7','Socket Set','Sockets, Ratchet, Extensions','1/4\" and 3/8\"','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb199-8415-11f0-9b07-94bb4370fbe7','Adjustable Wrench','','12-inch','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb40e-8415-11f0-9b07-94bb4370fbe7','Gloves','Pair of Gloves','Safety','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb4e1-8415-11f0-9b07-94bb4370fbe7','Safety Glasses','Glasses, Case','Eye protection','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb57b-8415-11f0-9b07-94bb4370fbe7','Tape','','Electrical tape','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb604-8415-11f0-9b07-94bb4370fbe7','Marker','','Permanent marker','2025-08-28 09:48:42','0001-01-01 00:00:00','In'),('b5ecb68c-8415-11f0-9b07-94bb4370fbe7','Brush','','Paint brush','2025-08-28 09:48:42','0001-01-01 00:00:00','In');
/*!40000 ALTER TABLE `basictools` ENABLE KEYS */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-28 16:04:25
