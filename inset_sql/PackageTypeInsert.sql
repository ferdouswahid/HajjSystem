-- PackageType Table Seed Data
-- Generated on 2026-01-22

INSERT INTO "PackageTypes" ("Name", "Detail", "CompanyId", "CreatedDate", "UpdatedDate", "DeletedDate", "CreatedBy", "UpdatedBy", "DeletedBy", "IsEnabled") 
VALUES 
('Economy', 'ksdjksjdss', 1, '2026-01-22 11:44:53.609098+00', NULL, NULL, NULL, NULL, NULL, true),
('VIP', 'vvvvvvv', 1, '2026-01-22 11:45:09.040809+00', NULL, NULL, NULL, NULL, NULL, true),
('VVIP', 'vpppp', 1, '2026-01-22 11:45:20.814042+00', NULL, NULL, NULL, NULL, NULL, true);

-- Reset sequence to max ID + 1
SELECT * FROM "PackageTypes";
