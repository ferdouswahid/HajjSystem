-- UserRole Table Seed Data
-- Generated on 2026-01-22

INSERT INTO "UserRoles" ("UserId", "RoleId") 
VALUES 
(1, 2),
(2, 5);

-- Reset sequence to max ID + 1
SELECT setval(pg_get_serial_sequence('"UserRoles"', 'Id'), (SELECT MAX("Id") FROM "UserRoles"));
