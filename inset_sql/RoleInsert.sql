-- Insert default roles into the Roles table
INSERT INTO "Roles" ("Name", "IsActive") VALUES 
('SyestemAdmin', true),
('Owner', true),
('Admin', true),
('Manager', true),
('Customer', true);

-- View all roles
SELECT "Id", "Name", "IsActive" FROM "Roles";

