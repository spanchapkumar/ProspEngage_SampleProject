/*User Table */

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(10),
    FirstName NVARCHAR(50),
    MiddleName NVARCHAR(50) NULL,
    LastName NVARCHAR(50),
    Phone NVARCHAR(15) NULL,
    Email NVARCHAR(100) UNIQUE CHECK (Email LIKE '%@kalpita.com'),
    RoleId INT FOREIGN KEY REFERENCES RoleMaster(RoleId),
    ProfileId INT FOREIGN KEY REFERENCES ProfileMaster(ProfileId),
    CreatedOn DATETIME DEFAULT GETDATE(),
    CreatedBy VARCHAR(50),
    ModifiedOn DATETIME NULL,
    ModifiedBy VARCHAR(50) NULL,
    IsActive BIT DEFAULT 0
);
