using CompanyStructure;
using CompanyStructure.Models;
using CompanyStructure.Services;
using System.Text.Json;
using System;

AddData.AddDataToDb();

var structureService = new StructureService();
var tree = structureService.GetCompanyStructure();
var jsonTree = JsonSerializer.Serialize(tree);
var smallTree = structureService.GetDivisionsOnly();
jsonTree = JsonSerializer.Serialize(smallTree);
//var usersList = structureService.GetDivisionPersonalById(Guid.Parse("5C8CB6DA-9BB8-441D-A81B-D07DC3997C40"));
//structureService.AddUserInStaff("5F164CC6-04BE-4743-87D9-8D7D4A3ED299", usersList[0].Id);
//structureService.AddUserInStaff("9B5968D9-DCDB-4CE4-BFCC-7DD9C6D38255", usersList[0].Id);


