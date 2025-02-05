USE [ContactsAPI]
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd', N'admin@mail.com', N'ADMIN@MAIL.COM', N'admin@mail.com', N'ADMIN@MAIL.COM', 0, N'AQAAAAEAACcQAAAAEH65qaZcf3Z3uAvRg4sQpp32NWCjeo1LROxtBZJGfoRIqSetIbWYE2Zq6qSdUBszxQ==', N'RXYF7S6HSX2BIDQEETWGO3RBKOMOS3IN', N'216219d1-00ae-4bb4-b26f-b1e1a0d156a9', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'2401d3e7-3bed-ed43-fe6f-004239eb5d25', N'Elton', N'Graham', N'Pharetra Nam Ac Consulting', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'001490c3-24eb-8715-68a6-053f82cef7d8', N'Yvonne', N'Cole', N'Interdum Libero Consulting', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'10c8e024-b6af-495c-5aef-05d9b605876c', N'Beau', N'Giles', N'Etiam Institute', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab', N'Ignacia', N'Bryant', N'Id Magna Company', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'de9daa88-897d-409f-0111-0d01f6ec3c65', N'Asher', N'Wallace', N'Orci Quis Foundation', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3', N'Cassady', N'Morrison', N'Augue Malesuada LLC', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'6b5640b1-4ab6-0ed2-948e-16b1fb367a49', N'Kieran', N'Chan', N'Eleifend Vitae Erat PC', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'acd98244-fc16-687a-ae2e-1a4230822b87', N'Deacon', N'Calderon', N'Ligula Consectetuer Rhoncus Industries', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'7e9fb41c-8367-8578-ec8b-1c08e346fb07', N'Alana', N'Brock', N'Consectetuer Cursus Et Consulting', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [CompanyName], [OwnerUserId]) VALUES (N'e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b', N'Cassady', N'Carrillo', N'Sagittis Semper PC', N'11b733e0-0053-4fa9-b53b-5cdf5cc4e8fd')
GO
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('986422D9-646A-8EAF-E405-838C81B2ADE9','2401d3e7-3bed-ed43-fe6f-004239eb5d25',2,'(540) 263-6560');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('8A1FD89A-32E6-C1E7-55B1-7B9F92BA73D1','001490c3-24eb-8715-68a6-053f82cef7d8',2,'(682) 983-6769');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('67B243AF-7183-5E3E-956E-75734FE67F75','10c8e024-b6af-495c-5aef-05d9b605876c',1,'(365) 933-7568');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('8F4813A3-FB3A-08D7-50BF-14D2C95719AA','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',1,'(941) 859-9617');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D5E2E99E-D49D-39F4-E4EE-3B55AD81886D','de9daa88-897d-409f-0111-0d01f6ec3c65',1,'(175) 394-7725');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('37012C81-16D3-2CC2-1346-9E71CAF45EAD','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',2,'(477) 709-1060');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('59D93FB3-874E-02E9-A794-1D28371A28D2','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',2,'(174) 937-8789');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('1E1CDC20-EEF7-19C5-79E4-70560CD10886','acd98244-fc16-687a-ae2e-1a4230822b87',1,'(692) 972-3941');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('F5ECC38D-423C-AB59-4F2A-2F589A148C2C','7e9fb41c-8367-8578-ec8b-1c08e346fb07',0,'(122) 105-2539');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('B96C4973-062F-EAC2-81FA-152F3172D624','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',1,'(755) 466-7224');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('62E820BF-5252-2772-CE5C-B1E12B4FF42E','2401d3e7-3bed-ed43-fe6f-004239eb5d25',2,'(663) 202-9856');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D4B03593-907A-97E2-22B7-BC7F80084B50','001490c3-24eb-8715-68a6-053f82cef7d8',1,'(229) 373-7078');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('E0B02FA7-9E11-3610-4450-93DE0B4F792E','10c8e024-b6af-495c-5aef-05d9b605876c',1,'(112) 797-0153');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D544F31E-702E-E90D-8ABE-7830D7DD961E','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',1,'(972) 301-9159');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('DE61C614-C997-21DE-CBA2-0F9497A2F1F9','de9daa88-897d-409f-0111-0d01f6ec3c65',1,'(120) 417-9797');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('39CE242B-C3DD-9383-24FD-F1C94C4F0C61','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',1,'(127) 322-2933');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('BCE9F489-04DC-339D-A3F4-BA1D07728C92','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',2,'(862) 175-1854');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('71B3ECC8-7B2A-AD49-A721-08E58B63FFE5','acd98244-fc16-687a-ae2e-1a4230822b87',1,'(176) 401-2835');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('4C4FA00D-F198-37C5-DC10-179CEF8C9E8A','7e9fb41c-8367-8578-ec8b-1c08e346fb07',2,'(207) 895-4518');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('DE24201E-F9D5-879A-2280-C6B69C529213','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',0,'(748) 138-8235');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('99E59B21-B74C-0BA7-BB5C-76C90E4EE01D','2401d3e7-3bed-ed43-fe6f-004239eb5d25',0,'(905) 155-2351');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('BA429846-40B0-3A67-91E0-5FB0A38A9199','001490c3-24eb-8715-68a6-053f82cef7d8',0,'(168) 233-4814');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('43C6CDE0-8E4A-9D18-4821-74E6586EC6AF','10c8e024-b6af-495c-5aef-05d9b605876c',0,'(131) 468-0336');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('E00F9ECA-AD16-7CAE-0BD8-6990D2870409','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',0,'(376) 141-9770');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('1FE8AC1B-5CE1-16A5-C8A3-49DF6128E91B','de9daa88-897d-409f-0111-0d01f6ec3c65',1,'(142) 379-4715');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('FCE4A741-3F83-FD24-98F0-8B8A52006ACC','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',1,'(573) 598-4277');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('EBE44515-D609-0AC6-2D5B-9CF46E2A3E70','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',2,'(654) 636-2286');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('1BB8A187-DB37-6841-61F5-D24CC7703EA3','acd98244-fc16-687a-ae2e-1a4230822b87',0,'(306) 893-1036');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('65EBD3D8-C22D-5A43-AE2B-8DF9F99AEC55','7e9fb41c-8367-8578-ec8b-1c08e346fb07',1,'(819) 365-1514');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('48E2F855-7AAC-1745-3CF0-A12BF922E289','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',1,'(753) 867-1932');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('AD2E2397-AA92-7524-DD38-56627179DAE9','2401d3e7-3bed-ed43-fe6f-004239eb5d25',0,'(845) 854-5965');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D9F373E7-1C53-97E4-FE02-18A38F28C8F2','001490c3-24eb-8715-68a6-053f82cef7d8',0,'(293) 379-5439');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('CC9E8CA9-2966-993E-C74A-2DDE7C19F9A3','10c8e024-b6af-495c-5aef-05d9b605876c',2,'(108) 387-0514');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('BC7889A3-DEA3-E147-9618-118B20ED58E0','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',0,'(409) 493-4043');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('F14B7595-0A0E-937E-B76D-4004C0250FF4','de9daa88-897d-409f-0111-0d01f6ec3c65',2,'(861) 279-4585');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('3219945B-88DF-3E73-3A20-D622808F62C1','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',2,'(689) 509-5112');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('350B32E1-0E0C-1E9C-5661-A1EF0313F3BA','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',2,'(664) 855-7514');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('04A29227-D7AA-5B14-B4C3-1F060CCAE654','acd98244-fc16-687a-ae2e-1a4230822b87',1,'(460) 667-0427');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('719D5C14-E0A6-F448-FE6D-C77531FBC414','7e9fb41c-8367-8578-ec8b-1c08e346fb07',1,'(826) 310-6515');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('76E5A2E7-337E-FA6F-B1DE-F1202013AAEA','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',0,'(800) 757-4745');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('F2F89716-D5E2-BA21-9A18-CCE877356878','2401d3e7-3bed-ed43-fe6f-004239eb5d25',0,'(993) 345-4833');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('B0609E7A-BE25-D69D-E42C-65AEE46CC838','001490c3-24eb-8715-68a6-053f82cef7d8',1,'(747) 717-7226');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('EE1D5914-31E1-FABF-3E98-8EC9248DD5E1','10c8e024-b6af-495c-5aef-05d9b605876c',2,'(808) 108-6885');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('6A9E4217-10C4-20E1-D5AF-35BCA1EE9D94','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',2,'(132) 328-6981');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('A1F4C543-503A-B3DA-B0C0-DBFD7BF4940A','de9daa88-897d-409f-0111-0d01f6ec3c65',2,'(484) 796-4426');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('61EF14AB-4A29-182F-5725-FCF0ED42524F','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',2,'(919) 667-7968');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('4A985C75-CA0B-2E6E-451D-F5E22A48430F','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',0,'(826) 514-3778');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('88FBEC16-360E-97BC-F452-DF9D7E148C94','acd98244-fc16-687a-ae2e-1a4230822b87',0,'(326) 922-7637');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('968C5CF9-E1C2-F4F4-2112-251BD6B7F0D3','7e9fb41c-8367-8578-ec8b-1c08e346fb07',1,'(824) 790-2600');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('AA2E97C1-C772-34AA-CE69-6AA19DB87C96','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',2,'(395) 789-9364');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('4F317272-B676-4630-CE55-CA535DF98241','2401d3e7-3bed-ed43-fe6f-004239eb5d25',2,'(529) 195-1795');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('58AA1EFC-A02E-7FD1-20AE-D4FB6B6A1FDF','001490c3-24eb-8715-68a6-053f82cef7d8',1,'(879) 532-8298');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('4F88C6B5-4D4A-05AA-C178-6C694EC2B019','10c8e024-b6af-495c-5aef-05d9b605876c',0,'(503) 586-3402');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('9CBCEBF0-0288-B396-D69F-58C1093EE926','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',0,'(689) 516-2562');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('4957B4FE-A576-5343-C04F-EC9DE50C780B','de9daa88-897d-409f-0111-0d01f6ec3c65',2,'(567) 207-8813');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('6D9378F5-031E-6A9C-D520-C9D0DF4303F6','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',2,'(621) 139-2631');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('B46ECB1B-E336-541C-46B8-76D8EBE85711','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',1,'(211) 166-3212');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('26439EC4-F90A-BBCD-1B64-5AFADF8DE1F4','acd98244-fc16-687a-ae2e-1a4230822b87',2,'(396) 282-8485');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('C4A31756-03A0-A856-0E7C-A86D4D19B5A0','7e9fb41c-8367-8578-ec8b-1c08e346fb07',0,'(687) 858-0689');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('86E551ED-708D-6242-0392-623021A269E5','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',0,'(363) 127-0024');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('54F65D60-E1FE-7D80-63B6-CE8E9BA5448E','2401d3e7-3bed-ed43-fe6f-004239eb5d25',0,'(569) 224-4042');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('778C9F6D-FA19-130C-621C-66403E2F5ED6','001490c3-24eb-8715-68a6-053f82cef7d8',1,'(173) 657-6261');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('308B9FB7-8D5D-F62C-95CD-9854C14F573A','10c8e024-b6af-495c-5aef-05d9b605876c',1,'(643) 669-7632');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D4077E8D-068D-B0D2-2BBE-578A83C83CCD','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',1,'(103) 955-2683');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('E8D4C936-5029-DA8C-2565-18BACB181051','de9daa88-897d-409f-0111-0d01f6ec3c65',2,'(235) 816-5933');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('91D216B6-638E-8DB6-8D22-2BD2ABA9E656','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',0,'(855) 896-2607');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('5B48621C-95B9-E303-A740-BF46EB599EBE','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',0,'(406) 564-4391');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('5934A7B7-5E14-A383-BA92-6370A8BD008F','acd98244-fc16-687a-ae2e-1a4230822b87',0,'(729) 923-3889');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('3AA3069D-881B-4CB5-06A8-6CBF8D3A4A3B','7e9fb41c-8367-8578-ec8b-1c08e346fb07',2,'(333) 932-6571');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('03701007-E150-1A3C-1119-159111CA22B7','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',1,'(813) 525-4520');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('ECF486A9-72C2-9A29-B934-FF5BA1A22827','2401d3e7-3bed-ed43-fe6f-004239eb5d25',0,'(102) 766-0542');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('97AB86A3-CAF6-A018-4DBA-68A21BBD81F3','001490c3-24eb-8715-68a6-053f82cef7d8',1,'(551) 222-0146');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('FE19994B-182F-5384-FB31-B1299E1C1A65','10c8e024-b6af-495c-5aef-05d9b605876c',0,'(283) 880-3814');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('32811900-0E8B-2E86-BF71-95C8BFF1B7AB','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',0,'(775) 886-3805');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('252CF134-8632-EB09-25ED-336FDE14198A','de9daa88-897d-409f-0111-0d01f6ec3c65',1,'(888) 887-4173');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('BF14CEF0-3EEC-DDC6-F934-AF0D2ECD7B0F','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',2,'(266) 228-9821');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D2AA0376-1BDC-FA7E-4435-0CBDCCAF7092','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',1,'(128) 801-0779');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('E9DDDC55-5159-9461-8150-B85163BC252F','acd98244-fc16-687a-ae2e-1a4230822b87',1,'(652) 680-5625');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('0091DFAA-EF3E-20FE-ACF2-371E4E637F39','7e9fb41c-8367-8578-ec8b-1c08e346fb07',2,'(698) 657-4320');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('9AB9A284-F104-D163-FD4D-6634F43EB2FA','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',2,'(101) 470-5260');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('01D3BB38-7FE0-AE4D-FBD6-A79A30E1CCDF','2401d3e7-3bed-ed43-fe6f-004239eb5d25',0,'(537) 935-5472');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('C6173413-9D1C-03FC-4461-B99035F3D72E','001490c3-24eb-8715-68a6-053f82cef7d8',1,'(528) 732-7014');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D0B5642A-62AD-EA1D-03B5-FC8E92711C44','10c8e024-b6af-495c-5aef-05d9b605876c',2,'(416) 791-9174');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('A3FEE9F9-488C-2A00-B8FC-49A06C28648F','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',1,'(495) 453-8335');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D4D391DF-68CE-2110-7496-0D3D940268AB','de9daa88-897d-409f-0111-0d01f6ec3c65',0,'(613) 801-2359');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D1FA9E64-33ED-2D30-5B95-4E60D8628B9F','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',0,'(614) 904-6129');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('B3B7FDF5-818D-C992-0BFD-0137B4545F45','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',0,'(190) 408-0138');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('5DF56ECA-DF63-1FEA-3003-6D0DEC24C927','acd98244-fc16-687a-ae2e-1a4230822b87',1,'(518) 341-4009');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('F181F11F-5F86-A6DF-66F6-082A40D856A8','7e9fb41c-8367-8578-ec8b-1c08e346fb07',1,'(336) 958-4212');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('D12699A0-9ACF-0C71-EE0E-1570DDEA636F','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',2,'(468) 198-9088');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('FD8F19CA-1CAF-2383-2790-0728474A6A4D','2401d3e7-3bed-ed43-fe6f-004239eb5d25',0,'(292) 861-8221');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('9F5E9290-6118-3B2E-00F9-F08C1344E7B9','001490c3-24eb-8715-68a6-053f82cef7d8',0,'(874) 323-0534');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('0B7AB0EB-5FF7-74EB-997C-1AB9DD3DB0EF','10c8e024-b6af-495c-5aef-05d9b605876c',0,'(875) 435-8951');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('02DFD479-043D-AF95-2E8E-2E4D817A7CC2','6e87ffaa-1fb3-aef9-b139-0ce6bb27a5ab',1,'(801) 840-7626');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('2BCA3541-06C4-D3F7-BD12-5A35AD30FA9D','de9daa88-897d-409f-0111-0d01f6ec3c65',2,'(484) 167-7532');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('1717D12B-21DD-D028-7F82-83FE9406B1AD','0b3ba2e1-1f0d-bec3-fa52-15d10ecea3c3',1,'(379) 795-8650');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('ED90BF28-CCA9-1592-ADDE-D2F0B27C297C','6b5640b1-4ab6-0ed2-948e-16b1fb367a49',2,'(629) 689-4606');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('F1545812-6AF0-9695-3508-D58F2AFEDB34','acd98244-fc16-687a-ae2e-1a4230822b87',0,'(888) 934-8234');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('2A64752A-14CE-67E0-2BDC-27C5C8E9DC7C','7e9fb41c-8367-8578-ec8b-1c08e346fb07',2,'(211) 499-6400');
INSERT INTO ContactInfos([Id],[ContactId],[Type],[Content]) VALUES('91ED4958-5EBC-4A22-88A7-3F50202804BF','e6bf1952-0051-f4df-1a0a-1c0e8a0c9b2b',1,'(116) 619-6543');
GO