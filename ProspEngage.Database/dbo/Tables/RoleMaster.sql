/*Role Master Table */

CREATE TABLE RoleMaster (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50),
    CreatedOn DATETIME DEFAULT GETDATE(),
    CreatedBy VARCHAR(50),
    ModifiedOn DATETIME NULL,
    ModifiedBy VARCHAR(50) NULL,
    IsActive BIT DEFAULT 1
);

