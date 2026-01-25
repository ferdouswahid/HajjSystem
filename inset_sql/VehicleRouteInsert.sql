-- VehicleRoute Table Seed Data
-- Generated on 2026-01-22

INSERT INTO "VehicleRoutes" ("Name", "Details", "CreatedDate", "UpdatedDate", "DeletedDate", "CreatedBy", "UpdatedBy", "DeletedBy", "IsEnabled", "CompanyId") 
VALUES 
('Jeddha Airport to Hotel', 'vxvxvxv', '2026-01-21 15:32:47.924157+00', NULL, NULL, NULL, NULL, NULL, true, 1),
('Hotel to Mina', NULL, '2026-01-21 15:33:21.383161+00', NULL, NULL, NULL, NULL, NULL, true, 1),
('Mina to Arafa', NULL, '2026-01-21 15:33:31.718823+00', NULL, NULL, NULL, NULL, NULL, true, 1),
('Arafa to Mozdalifa', NULL, '2026-01-21 15:33:44.043112+00', NULL, NULL, NULL, NULL, NULL, true, 1);

-- 
SELECT * FROM "VehicleRoutes"
