-- Insert SQL for Season table
INSERT INTO "Seasons" 
(
    "Title", 
    "StartDate", 
    "EndDate", 
    "IsCurrent", 
    "CreatedDate", 
    "UpdatedDate", 
    "DeletedDate", 
    "CreatedBy", 
    "UpdatedBy", 
    "DeletedBy", 
    "IsEnabled"
)
VALUES 
(
    'Hajj 1447H (2026)', 
    '2026-05-26', 
    '2026-07-05', 
    true, 
    NOW(), 
    NULL, 
    NULL, 
    NULL, 
    NULL, 
    NULL, 
    true
),
(
    'Hajj 1446H (2025)', 
    '2025-06-06', 
    '2025-07-15', 
    false, 
    NOW(), 
    NULL, 
    NULL, 
    NULL, 
    NULL, 
    NULL, 
    true
);