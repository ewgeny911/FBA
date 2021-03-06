USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [dbo].[eo_ObjectName]    Script Date: 03.07.2018 11:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Function [dbo].[eo_ObjectName](@EntityID int, @ObjectID int)
Returns varchar(200) As
begin
  if @EntityID = 1
    Return dbo.EON_enEntity(@ObjectID)
  if @EntityID = 2
    Return dbo.EON_enTable(@ObjectID)
  if @EntityID = 3
    Return dbo.EON_enAttribute(@ObjectID)
  if @EntityID = 4
    Return dbo.EON_enMethod(@ObjectID)
  if @EntityID = 5
    Return dbo.EON_enView(@ObjectID)
  if @EntityID = 6
    Return dbo.EON_enObjectType(@ObjectID)
  if @EntityID = 7
    Return dbo.EON_enSoftElement(@ObjectID)
  if @EntityID = 8
    Return dbo.EON_enUnit(@ObjectID)
  if @EntityID = 9
    Return dbo.EON_enSubSystem(@ObjectID)
  if @EntityID = 10
    Return dbo.EON_enSoftForm(@ObjectID)
  if @EntityID = 11
    Return dbo.EON_enSoftReport(@ObjectID)
  if @EntityID = 12
    Return dbo.EON_enSoftDataModule(@ObjectID)
  if @EntityID = 13
    Return dbo.EON_enScriptUnit(@ObjectID)
  if @EntityID = 14
    Return dbo.EON_enSubSystemContents(@ObjectID)
  if @EntityID = 15
    Return dbo.EON_enViewTable(@ObjectID)
  if @EntityID = 16
    Return dbo.EON_enViewArray(@ObjectID)
  if @EntityID = 1032
    Return dbo.EON_enUnitTemplate(@ObjectID)
  if @EntityID = 1089
    Return dbo.EON_ApplicationUser(@ObjectID)
  if @EntityID = 1168
    Return dbo.EON_ApplicationUserGroup(@ObjectID)
  if @EntityID = 1169
    Return dbo.EON_RelGroupUser(@ObjectID)
  if @EntityID = 1171
    Return dbo.EON_RightAction(@ObjectID)
  if @EntityID = 1173
    Return dbo.EON_enUserSettings(@ObjectID)
  if @EntityID = 1174
    Return dbo.EON_enUserSettingsValue(@ObjectID)
  if @EntityID = 1216
    Return dbo.EON_RightTypeGroup(@ObjectID)
  if @EntityID = 1217
    Return dbo.EON_RightType(@ObjectID)
  if @EntityID = 1219
    Return dbo.EON_enAttributeType(@ObjectID)
  if @EntityID = 1220
    Return dbo.EON_enAttributeKind(@ObjectID)
  if @EntityID = 1231
    Return dbo.EON_enRelUserView(@ObjectID)
  if @EntityID = 1232
    Return dbo.EON_enObjectLock(@ObjectID)
  if @EntityID = 1381
    Return dbo.EON_enMethodUnit(@ObjectID)
  if @EntityID = 1415
    Return dbo.EON_enStoredProc(@ObjectID)
  if @EntityID = 1444
    Return dbo.EON_RightGroup(@ObjectID)
  if @EntityID = 1445
    Return dbo.EON_AdmSetup(@ObjectID)
  if @EntityID = 1447
    Return dbo.EON_enLog(@ObjectID)
  if @EntityID = 1448
    Return dbo.EON_AppUserHistory(@ObjectID)
  if @EntityID = 1449
    Return dbo.EON_AppUserGroupHistory(@ObjectID)
  if @EntityID = 1450
    Return dbo.EON_RelGroupUserHistory(@ObjectID)
  if @EntityID = 1451
    Return dbo.EON_RightActionHistory(@ObjectID)
  if @EntityID = 1452
    Return dbo.EON_enAppUserStatus(@ObjectID)
  if @EntityID = 1453
    Return dbo.EON_enAppUserPriority(@ObjectID)
  if @EntityID = 1459
    Return dbo.EON_enSysRight(@ObjectID)
  if @EntityID = 1462
    Return dbo.EON_enUnitChangeHistory(@ObjectID)
  if @EntityID = 1480
    Return dbo.EON_enInvalidMultiLookup(@ObjectID)
  if @EntityID = 1499
    Return dbo.EON_enSolution(@ObjectID)
  if @EntityID = 1500
    Return dbo.EON_enSolutionStuff(@ObjectID)
  if @EntityID = 1501
    Return dbo.EON_enAttrList(@ObjectID)
  if @EntityID = 1560
    Return dbo.EON_Face(@ObjectID)
  if @EntityID = 1561
    Return dbo.EON_FacePerson(@ObjectID)
  if @EntityID = 1562
    Return dbo.EON_FaceJuridical(@ObjectID)
  if @EntityID = 1563
    Return dbo.EON_Document(@ObjectID)
  if @EntityID = 1564
    Return dbo.EON_Bank(@ObjectID)
  if @EntityID = 1565
    Return dbo.EON_Fund(@ObjectID)
  if @EntityID = 1566
    Return dbo.EON_Nationality(@ObjectID)
  if @EntityID = 1567
    Return dbo.EON_PassportType(@ObjectID)
  if @EntityID = 1568
    Return dbo.EON_BankProperty(@ObjectID)
  if @EntityID = 1569
    Return dbo.EON_Graduate(@ObjectID)
  if @EntityID = 1570
    Return dbo.EON_Education(@ObjectID)
  if @EntityID = 1571
    Return dbo.EON_JuridicalOrgStatus(@ObjectID)
  if @EntityID = 1572
    Return dbo.EON_IndustryBranch(@ObjectID)
  if @EntityID = 1573
    Return dbo.EON_MiscRef(@ObjectID)
  if @EntityID = 1574
    Return dbo.EON_Kladr(@ObjectID)
  if @EntityID = 1575
    Return dbo.EON_Country(@ObjectID)
  if @EntityID = 1576
    Return dbo.EON_Military(@ObjectID)
  if @EntityID = 1577
    Return dbo.EON_Street(@ObjectID)
  if @EntityID = 1578
    Return dbo.EON_Address(@ObjectID)
  if @EntityID = 1579
    Return dbo.EON_CourseType(@ObjectID)
  if @EntityID = 1580
    Return dbo.EON_RelDocDoc(@ObjectID)
  if @EntityID = 1581
    Return dbo.EON_RelDocServObject(@ObjectID)
  if @EntityID = 1582
    Return dbo.EON_AccountChart(@ObjectID)
  if @EntityID = 1583
    Return dbo.EON_Account(@ObjectID)
  if @EntityID = 1584
    Return dbo.EON_AccountConsolidate(@ObjectID)
  if @EntityID = 1585
    Return dbo.EON_Trans(@ObjectID)
  if @EntityID = 1586
    Return dbo.EON_Course(@ObjectID)
  if @EntityID = 1587
    Return dbo.EON_AccountType(@ObjectID)
  if @EntityID = 1588
    Return dbo.EON_AccountTypeContents(@ObjectID)
  if @EntityID = 1589
    Return dbo.EON_RelTransObject(@ObjectID)
  if @EntityID = 1590
    Return dbo.EON_ComplexTrans(@ObjectID)
  if @EntityID = 1591
    Return dbo.EON_RelComplexTransTemplTransTemp(@ObjectID)
  if @EntityID = 1592
    Return dbo.EON_ForeignLanguage(@ObjectID)
  if @EntityID = 1593
    Return dbo.EON_ForeingLanguageExperienceDegree(@ObjectID)
  if @EntityID = 1594
    Return dbo.EON_RelationshipDegree(@ObjectID)
  if @EntityID = 1595
    Return dbo.EON_ForeignLanguageExperience(@ObjectID)
  if @EntityID = 1596
    Return dbo.EON_Relative(@ObjectID)
  if @EntityID = 1597
    Return dbo.EON_FamilyStatus(@ObjectID)
  if @EntityID = 1599
    Return dbo.EON_RepTempl(@ObjectID)
  if @EntityID = 1601
    Return dbo.EON_Report(@ObjectID)
  if @EntityID = 1602
    Return dbo.EON_PassportFace(@ObjectID)
  if @EntityID = 1603
    Return dbo.EON_ClosePeriodTrans(@ObjectID)
  if @EntityID = 1604
    Return dbo.EON_AdressType(@ObjectID)
  if @EntityID = 1605
    Return dbo.EON_CourseCalcType(@ObjectID)
  if @EntityID = 1606
    Return dbo.EON_doma(@ObjectID)
  if @EntityID = 1607
    Return dbo.EON_flat(@ObjectID)
  if @EntityID = 1608
    Return dbo.EON_Citizenship(@ObjectID)
  if @EntityID = 1609
    Return dbo.EON_ExtDataFace(@ObjectID)
  if @EntityID = 1610
    Return dbo.EON_ExtDateType(@ObjectID)
  if @EntityID = 1611
    Return dbo.EON_MilitaryType(@ObjectID)
  if @EntityID = 1612
    Return dbo.EON_OrgStructure(@ObjectID)
  if @EntityID = 1614
    Return dbo.EON_RelTemplObjectAttr(@ObjectID)
  if @EntityID = 1615
    Return dbo.EON_RelTemplObjectType(@ObjectID)
  if @EntityID = 1616
    Return dbo.EON_Employee(@ObjectID)
  if @EntityID = 1617
    Return dbo.EON_Staff(@ObjectID)
  if @EntityID = 1618
    Return dbo.EON_RelConstitutors(@ObjectID)
  if @EntityID = 1619
    Return dbo.EON_IncreaseQualificationType(@ObjectID)
  if @EntityID = 1620
    Return dbo.EON_DecisionCommisionType(@ObjectID)
  if @EntityID = 1621
    Return dbo.EON_Area(@ObjectID)
  if @EntityID = 1622
    Return dbo.EON_ObjectTemplate(@ObjectID)
  if @EntityID = 1623
    Return dbo.EON_TransTemplate(@ObjectID)
  if @EntityID = 1624
    Return dbo.EON_ComplexTransTemplate(@ObjectID)
  if @EntityID = 1625
    Return dbo.EON_CodeCost(@ObjectID)
  if @EntityID = 1626
    Return dbo.EON_enLogActionType(@ObjectID)
  if @EntityID = 1627
    Return dbo.EON_enLogAction(@ObjectID)
  if @EntityID = 1628
    Return dbo.EON_enLcl(@ObjectID)
  if @EntityID = 1631
    Return dbo.EON_PriceList(@ObjectID)
  if @EntityID = 1632
    Return dbo.EON_Filial(@ObjectID)
  if @EntityID = 1633
    Return dbo.EON_FaceContact(@ObjectID)
  if @EntityID = 1634
    Return dbo.EON_PriceListContent(@ObjectID)
  if @EntityID = 1636
    Return dbo.EON_UniServices(@ObjectID)
  if @EntityID = 1638
    Return dbo.EON_MKB(@ObjectID)
  if @EntityID = 1639
    Return dbo.EON_MethodCalc(@ObjectID)
  if @EntityID = 1640
    Return dbo.EON_AdditionAgreement(@ObjectID)
  if @EntityID = 1641
    Return dbo.EON_Status(@ObjectID)
  if @EntityID = 1642
    Return dbo.EON_StatusObject(@ObjectID)
  if @EntityID = 1643
    Return dbo.EON_DepartFaceJuridical(@ObjectID)
  if @EntityID = 1644
    Return dbo.EON_FilialContent(@ObjectID)
  if @EntityID = 1645
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1646
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1647
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1648
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1653
    Return dbo.EON_FaceJuridicalSimpleRefBook_Ward(@ObjectID)
  if @EntityID = 1654
    Return dbo.EON_FaceJuridicalSimpleRefBook_Doctor(@ObjectID)
  if @EntityID = 1655
    Return dbo.EON_LicenseContractLPU(@ObjectID)
  if @EntityID = 1656
    Return dbo.EON_LicenseContractLPU_Attachment(@ObjectID)
  if @EntityID = 1657
    Return dbo.EON_InsProgram(@ObjectID)
  if @EntityID = 1658
    Return dbo.EON_InsProgramContent(@ObjectID)
  if @EntityID = 1659
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1660
    Return dbo.EON_Rel_USUByLicense(@ObjectID)
  if @EntityID = 1661
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1662
    Return dbo.EON_Rel_Contract_Program(@ObjectID)
  if @EntityID = 1663
    Return dbo.EON_Variant(@ObjectID)
  if @EntityID = 1664
    Return dbo.EON_VariantContent(@ObjectID)
  if @EntityID = 1665
    Return dbo.EON_Rel_MethodCalcAvansType(@ObjectID)
  if @EntityID = 1666
    Return dbo.EON_Rel_Contract_ProgramContent(@ObjectID)
  if @EntityID = 1670
    Return dbo.EON_InsType(@ObjectID)
  if @EntityID = 1672
    Return dbo.EON_DocumentCurator(@ObjectID)
  if @EntityID = 1679
    Return dbo.EON_Agent(@ObjectID)
  if @EntityID = 1680
    Return dbo.EON_AgentInsContract(@ObjectID)
  if @EntityID = 1682
    Return dbo.EON_AgentDocumentRDSO(@ObjectID)
  if @EntityID = 1683
    Return dbo.EON_DocFolder(@ObjectID)
  if @EntityID = 1684
    Return dbo.EON_AutoNumber(@ObjectID)
  if @EntityID = 1688
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1689
    Return dbo.EON_InsPolicy(@ObjectID)
  if @EntityID = 1690
    Return dbo.EON_RelContFace(@ObjectID)
  if @EntityID = 1692
    Return dbo.EON_PaysheetComissFee(@ObjectID)
  if @EntityID = 1693
    Return dbo.EON_AgentComissInsContract(@ObjectID)
  if @EntityID = 1694
    Return dbo.EON_ContractIns(@ObjectID)
  if @EntityID = 1695
    Return dbo.EON_ContractVariant(@ObjectID)
  if @EntityID = 1696
    Return dbo.EON_LPU(@ObjectID)
  if @EntityID = 1697
    Return dbo.EON_ContractLPU(@ObjectID)
  if @EntityID = 1698
    Return dbo.EON_AgentDocument(@ObjectID)
  if @EntityID = 1699
    Return dbo.EON_VariantProgram(@ObjectID)
  if @EntityID = 1700
    Return dbo.EON_VariantProgramContent(@ObjectID)
  if @EntityID = 1704
    Return dbo.EON_ContractVariantContent(@ObjectID)
  if @EntityID = 1705
    Return dbo.EON_ContractVariantProgram(@ObjectID)
  if @EntityID = 1706
    Return dbo.EON_ContractVariantProgramContent(@ObjectID)
  if @EntityID = 1708
    Return dbo.EON_DocIncPayment(@ObjectID)
  if @EntityID = 1709
    Return dbo.EON_PaymentOfDoc(@ObjectID)
  if @EntityID = 1710
    Return dbo.EON_PaymentCategory(@ObjectID)
  if @EntityID = 1711
    Return dbo.EON_FaceVariant(@ObjectID)
  if @EntityID = 1712
    Return dbo.EON_Rel_Contract_Program_LPU(@ObjectID)
  if @EntityID = 1713
    Return dbo.EON_Payment(@ObjectID)
  if @EntityID = 1714
    Return dbo.EON_RelPayObject(@ObjectID)
  if @EntityID = 1715
    Return dbo.EON_PayEntity(@ObjectID)
  if @EntityID = 1716
    Return dbo.EON_PaymentDoc(@ObjectID)
  if @EntityID = 1717
    Return dbo.EON_PayOrder(@ObjectID)
  if @EntityID = 1718
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1719
    Return dbo.EON_KindObject(@ObjectID)
  if @EntityID = 1720
    Return dbo.EON_KindDocument(@ObjectID)
  if @EntityID = 1721
    Return dbo.EON_ServicesRendered(@ObjectID)
  if @EntityID = 1722
    Return dbo.EON_BillLPU(@ObjectID)
  if @EntityID = 1723
    Return dbo.EON_DocToAllowance(@ObjectID)
  if @EntityID = 1724
    Return dbo.EON_Invoice(@ObjectID)
  if @EntityID = 1725
    Return dbo.EON_ActEngagement(@ObjectID)
  if @EntityID = 1726
    Return dbo.EON_ServiceList(@ObjectID)
  if @EntityID = 1727
    Return dbo.EON_InsAct(@ObjectID)
  if @EntityID = 1728
    Return dbo.EON_InsCase(@ObjectID)
  if @EntityID = 1729
    Return dbo.EON_Errors(@ObjectID)
  if @EntityID = 1730
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1731
    Return dbo.EON_Loss(@ObjectID)
  if @EntityID = 1732
    Return dbo.EON_LossHistory(@ObjectID)
  if @EntityID = 1733
    Return dbo.EON_DocOutPayment(@ObjectID)
  if @EntityID = 1734
    Return dbo.EON_LogBook(@ObjectID)
  if @EntityID = 1739
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1740
    Return dbo.EON_LogBookHospitalHistory(@ObjectID)
  if @EntityID = 1743
    Return dbo.EON_GarantLetter(@ObjectID)
  if @EntityID = 1744
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1745
    Return dbo.EON_LogBookRequest(@ObjectID)
  if @EntityID = 1746
    Return dbo.EON_LogBookInformation(@ObjectID)
  if @EntityID = 1747
    Return dbo.EON_LogBookAppeal(@ObjectID)
  if @EntityID = 1748
    Return dbo.EON_LogBookHospital(@ObjectID)
  if @EntityID = 1749
    Return dbo.EON_LogBookSMP(@ObjectID)
  if @EntityID = 1750
    Return dbo.EON_LogBookService(@ObjectID)
  if @EntityID = 1751
    Return dbo.EON_ActCheckBalance(@ObjectID)
  if @EntityID = 1752
    Return dbo.EON_LogStatus(@ObjectID)
  if @EntityID = 1753
    Return dbo.EON_Calendar(@ObjectID)
  if @EntityID = 1754
    Return dbo.EON_CalendarContent(@ObjectID)
  if @EntityID = 1755
    Return dbo.EON_TypeMedicalAid(@ObjectID)
  if @EntityID = 1756
    Return dbo.EON_ContractProgram(@ObjectID)
  if @EntityID = 1757
    Return dbo.EON_ContractProgramContent(@ObjectID)
  if @EntityID = 1758
    Return dbo.EON_SupervisoryConsole(@ObjectID)
  if @EntityID = 1759
    Return dbo.EON_ContractLimit(@ObjectID)
  if @EntityID = 1760
    Return dbo.EON_RelPaymentPayment(@ObjectID)
  if @EntityID = 1761
    Return dbo.EON_VariantProgramPercent(@ObjectID)
  if @EntityID = 1762
    Return dbo.EON_ContractVariantProgramPercent(@ObjectID)
  if @EntityID = 1763
    Return dbo.EON_BillLPUContent(@ObjectID)
  if @EntityID = 1764
    Return dbo.EON_InsActContent(@ObjectID)
  if @EntityID = 1765
    Return dbo.EON_ActCheckBalanceContent(@ObjectID)
  if @EntityID = 1766
    Return dbo.EON_PassCardLPU(@ObjectID)
  if @EntityID = 1767
    Return dbo.EON_BSOStatus(@ObjectID)
  if @EntityID = 1768
    Return dbo.EON_FormRigidAccount(@ObjectID)
  if @EntityID = 1770
    Return dbo.EON_Period(@ObjectID)
  if @EntityID = 1771
    Return dbo.EON_FinancePeriod(@ObjectID)
  if @EntityID = 1772
    Return dbo.EON_InsAccGroupType(@ObjectID)
  if @EntityID = 1773
    Return dbo.EON_RelInsAccGroupInsType(@ObjectID)
  if @EntityID = 1774
    Return dbo.EON_InsAccGroup(@ObjectID)
  if @EntityID = 1775
    Return dbo.EON_InsReserveContents(@ObjectID)
  if @EntityID = 1776
    Return dbo.EON_InsRC_RZNU(@ObjectID)
  if @EntityID = 1777
    Return dbo.EON_InsRC_RNP(@ObjectID)
  if @EntityID = 1778
    Return dbo.EON_InsRC_RNP_1_24(@ObjectID)
  if @EntityID = 1779
    Return dbo.EON_InsRC_RNP_1_8(@ObjectID)
  if @EntityID = 1780
    Return dbo.EON_InsRC_RNP_ProRata(@ObjectID)
  if @EntityID = 1781
    Return dbo.EON_InsRC_RPNU_ZSP(@ObjectID)
  if @EntityID = 1782
    Return dbo.EON_InsRC_RPNU_Totals(@ObjectID)
  if @EntityID = 1783
    Return dbo.EON_InsRC_RPNU_Loss(@ObjectID)
  if @EntityID = 1784
    Return dbo.EON_InsReserve(@ObjectID)
  if @EntityID = 1785
    Return dbo.EON_InsReserveRZNU(@ObjectID)
  if @EntityID = 1786
    Return dbo.EON_InsReserveRNP(@ObjectID)
  if @EntityID = 1787
    Return dbo.EON_InsReserveRPNU(@ObjectID)
  if @EntityID = 1788
    Return dbo.EON_SimpleRefBook(@ObjectID)
  if @EntityID = 1789
    Return dbo.EON_FaceJuridicalSimpleRefBook_Diagnostic(@ObjectID)
  if @EntityID = 1790
    Return dbo.EON_CanalSale(@ObjectID)
  if @EntityID = 1791
    Return dbo.EON_Aviso(@ObjectID)
  if @EntityID = 1792
    Return dbo.EON_AvisoContent(@ObjectID)
  if @EntityID = 1793
    Return dbo.EON_enDeletedUnit(@ObjectID)
  if @EntityID = 1794
    Return dbo.EON_enSolutionStuffDBStruct(@ObjectID)
  if @EntityID = 1795
    Return dbo.EON_enSolutionStuffObject(@ObjectID)
  if @EntityID = 1796
    Return dbo.EON_enSolutionStuffSQLScript(@ObjectID)
  if @EntityID = 1797
    Return dbo.EON_enLogFilter(@ObjectID)
  if @EntityID = 1798
    Return dbo.EON_enClosePeriod(@ObjectID)
  if @EntityID = 1799
    Return dbo.EON_enAllowUserClosePeriod(@ObjectID)
  if @EntityID = 1800
    Return dbo.EON_enLogArchive(@ObjectID)
  if @EntityID = 1801
    Return dbo.EON_enFilterSettings(@ObjectID)
  if @EntityID = 1802
    Return dbo.EON_enImage(@ObjectID)
  if @EntityID = 1803
    Return dbo.EON_LogBookDoctor(@ObjectID)
  if @EntityID = 1804
    Return dbo.EON_enTask(@ObjectID)
  if @EntityID = 1805
    Return dbo.EON_enImportTask(@ObjectID)
  if @EntityID = 1806
    Return dbo.EON_enImportLog(@ObjectID)
  if @EntityID = 1807
    Return dbo.EON_enExportOption(@ObjectID)
  if @EntityID = 1808
    Return dbo.EON_InsProduct(@ObjectID)
  if @EntityID = 1809
    Return dbo.EON_ContractCreditPeriod(@ObjectID)
  if @EntityID = 1810
    Return dbo.EON_RelFaceVariantCreditPeriod(@ObjectID)
  if @EntityID = 1811
    Return dbo.EON_ContractAgeCoefficient(@ObjectID)
  if @EntityID = 1812
    Return dbo.EON_RelVariantProgramCreditPeriod(@ObjectID)
  if @EntityID = 1813
    Return dbo.EON_LPUUnitLetter(@ObjectID)
  if @EntityID = 1814
    Return dbo.EON_DefaultImport(@ObjectID)
  if @EntityID = 1815
    Return dbo.EON_DefaultImportContent(@ObjectID)
  if @EntityID = 1816
    Return dbo.EON_ContractLPUText(@ObjectID)
  if @EntityID = 1817
    Return dbo.EON_ExchangeRule(@ObjectID)
  if @EntityID = 1818
    Return dbo.EON_ExchangeRuleContent(@ObjectID)
  if @EntityID = 1819
    Return dbo.EON_InterSystem(@ObjectID)
  if @EntityID = 1881
    Return dbo.EON_VZRProduct(@ObjectID)  
  if @EntityID = 1884
    Return dbo.EON_VZRProgramType(@ObjectID)
  Return Null
end

