-- Company Table Seed Data
-- Generated on 2026-01-25

INSERT INTO "Companies" ("CompanyName", "CompanyNameAr", "CrNumber", "Address", "Mobile", "VatRegNumber", "BuildingNumber", "District", "City", "Country", "PostalCode", "Email", "Phone", "CreatedDate", "UpdatedDate", "DeletedDate", "CreatedBy", "UpdatedBy", "DeletedBy", "IsEnabled")
VALUES
('Test Comp', '', 22223333, '', '', '', '', '', '', '', '', '', '', '2026-01-21 15:20:30.864258+00', NULL, NULL, NULL, NULL, NULL, NULL, true);

-- Reset sequence to max ID + 1
SELECT * FROM "Companies";
