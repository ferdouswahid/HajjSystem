-- User Table Seed Data
-- Generated on 2026-01-22

INSERT INTO "Users" ("FirstName", "MiddleName", "LastName", "Username", "Password", "CompanyId", "UserType", "Address", "City", "Country", "Passport", "PassportValidity", "Mobile", "Email", "SeasonId", "CreatedDate", "UpdatedDate", "DeletedDate", "CreatedBy", "UpdatedBy", "DeletedBy", "IsEnabled") 
VALUES 
( 'Md Ferdous', NULL, 'Wahid', 'fer.com', '$2a$11$FGtRBljvMxF9lJqKEehD2uuzCym10d.WWS3KV.PYy3PFCdq0A/oXy', 1, 1, '', '', '', '', '-infinity', '', 'shaiful.islam@banglalink.net', 1, '2026-01-21 15:20:31.044675+00', NULL, NULL, NULL, NULL, NULL, true),
( 'Md Ferdous', NULL, 'Wahid', 'fer.cus', '$2a$11$qu8MhK3eeWKpzzks7znuNuFnYeULY/aaJhMPQigVcLswkJLWpBZme', NULL, 0, '', '', '', '', '-infinity', '', 'wahid_cse@diu.edu.bd', 1, '2026-01-21 15:20:55.200097+00', NULL, NULL, NULL, NULL, NULL, true);

-- Reset sequence to max ID + 1
SELECT * FROM "Users"
