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
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `EmpID` varchar(45) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `Status` enum('Active','Terminated','Hold') DEFAULT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `PasswordSalt` varchar(200) DEFAULT NULL,
  `Role` enum('Admin','Supervisor','DeptStaff','Customer','None') NOT NULL,
  `SecondRole` enum('Admin','Supervisor','DeptStaff','Customer','None') NOT NULL,
  PRIMARY KEY (`EmpID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES ('Admin01','Test','Admin@company.com','555-324-1234','Active','Administrator','FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==','gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','Admin','Admin'),('Cust01','Test','cust01@company.com','555-789-6543','Active','Employee','FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==','gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','Customer','None'),('Cust02','Test','cust02@company.com','555-456-1236','Hold','Vendor','FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==','gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','Customer','None'),('DepStaff01','Test','staff01@company.com','555-963-8521','Active','Staff','FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==','gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','DeptStaff','DeptStaff'),('Sup01','Test','Sup@company.com','555-789-4563','Active','Supervisor','FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==','gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','Supervisor','DeptStaff'),('Sup02','Test','Sup2@company.com','555-159-7536','Active','Assistant Supervisor','FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==','gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','Supervisor','Admin');
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-28 16:04:25
