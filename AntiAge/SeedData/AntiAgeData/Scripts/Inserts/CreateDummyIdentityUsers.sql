USE [AntiAge]
GO

-- Turn on IDENTITY_INSERT to allow manual insertion into the identity column
SET IDENTITY_INSERT dbo.AspNetUsers ON;
GO


-- Insert 10 dummy users
INSERT INTO dbo.AspNetUsers
           ([Id], [FirstName], [LastName], [DateOfBirth], [Gender], [HeightCm], 
            [CreatedAt], [LastLogin], [UserName], [NormalizedUserName], 
            [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], 
            [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], 
            [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], 
            [LockoutEnabled], [AccessFailedCount])
     VALUES
           (1, 'John', 'Doe', '1990-01-01', 'Male', 180, GETDATE(), GETDATE(), 
            'johndoe@example.com', 'JOHNDOE@EXAMPLE.COM', 
            'johndoe@example.com', 'JOHNDOE@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_1', 'concurrency_stamp_1', 
            '123-456-7890', 0, 0, NULL, 0, 0),
           
           (2, 'Jane', 'Smith', '1985-05-15', 'Female', 165, GETDATE(), GETDATE(), 
            'janesmith@example.com', 'JANESMITH@EXAMPLE.COM', 
            'janesmith@example.com', 'JANESMITH@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_2', 'concurrency_stamp_2', 
            '987-654-3210', 0, 0, NULL, 0, 0),
           
           (3, 'Alice', 'Johnson', '1992-07-22', 'Female', 170, GETDATE(), GETDATE(), 
            'alicej@example.com', 'ALICEJ@EXAMPLE.COM', 
            'alicej@example.com', 'ALICEJ@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_3', 'concurrency_stamp_3', 
            '555-123-4567', 0, 0, NULL, 0, 0),
           
           (4, 'Bob', 'Williams', '1988-09-30', 'Male', 175, GETDATE(), GETDATE(), 
            'bobwilliams@example.com', 'BOBWILLIAMS@EXAMPLE.COM', 
            'bobwilliams@example.com', 'BOBWILLIAMS@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_4', 'concurrency_stamp_4', 
            '555-234-5678', 0, 0, NULL, 0, 0),
           
           (5, 'Charlie', 'Brown', '1995-11-10', 'Male', 185, GETDATE(), GETDATE(), 
            'charlieb@example.com', 'CHARLIEB@EXAMPLE.COM', 
            'charlieb@example.com', 'CHARLIEB@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_5', 'concurrency_stamp_5', 
            '555-345-6789', 0, 0, NULL, 0, 0),
           
           (6, 'David', 'Davis', '1980-03-25', 'Male', 168, GETDATE(), GETDATE(), 
            'daviddavis@example.com', 'DAVIDDAVIS@EXAMPLE.COM', 
            'daviddavis@example.com', 'DAVIDDAVIS@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_6', 'concurrency_stamp_6', 
            '555-456-7890', 0, 0, NULL, 0, 0),
           
           (7, 'Emily', 'Taylor', '1993-06-17', 'Female', 160, GETDATE(), GETDATE(), 
            'emilytaylor@example.com', 'EMILYTAYLOR@EXAMPLE.COM', 
            'emilytaylor@example.com', 'EMILYTAYLOR@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_7', 'concurrency_stamp_7', 
            '555-567-8901', 0, 0, NULL, 0, 0),
           
           (8, 'Frank', 'Moore', '1978-12-01', 'Male', 172, GETDATE(), GETDATE(), 
            'frankmoore@example.com', 'FRANKMOORE@EXAMPLE.COM', 
            'frankmoore@example.com', 'FRANKMOORE@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_8', 'concurrency_stamp_8', 
            '555-678-9012', 0, 0, NULL, 0, 0),
           
           (9, 'Grace', 'Anderson', '1998-04-10', 'Female', 155, GETDATE(), GETDATE(), 
            'graceanderson@example.com', 'GRACEANDERSON@EXAMPLE.COM', 
            'graceanderson@example.com', 'GRACEANDERSON@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_9', 'concurrency_stamp_9', 
            '555-789-0123', 0, 0, NULL, 0, 0),
           
           (10, 'Hannah', 'Thomas', '1990-02-20', 'Female', 162, GETDATE(), GETDATE(), 
            'hannahthomas@example.com', 'HANNAHTHOMAS@EXAMPLE.COM', 
            'hannahthomas@example.com', 'HANNAHTHOMAS@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_10', 'concurrency_stamp_10', 
            '555-890-1234', 0, 0, NULL, 0, 0),

			(11, 'Ivy', 'White', '1991-04-25', 'Female', 160, GETDATE(), GETDATE(), 
            'ivywhite@example.com', 'IVYWHITE@EXAMPLE.COM', 
            'ivywhite@example.com', 'IVYWHITE@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_11', 'concurrency_stamp_11', 
            '555-123-1111', 0, 0, NULL, 0, 0),
           
           (12, 'Jack', 'Martinez', '1994-12-05', 'Male', 178, GETDATE(), GETDATE(), 
            'jackmartinez@example.com', 'JACKMARTINEZ@EXAMPLE.COM', 
            'jackmartinez@example.com', 'JACKMARTINEZ@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_12', 'concurrency_stamp_12', 
            '555-234-2222', 0, 0, NULL, 0, 0),
           
           (13, 'Kim', 'Harris', '1987-02-14', 'Female', 168, GETDATE(), GETDATE(), 
            'kimharris@example.com', 'KIMHARRIS@EXAMPLE.COM', 
            'kimharris@example.com', 'KIMHARRIS@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_13', 'concurrency_stamp_13', 
            '555-345-3333', 0, 0, NULL, 0, 0),
           
           (14, 'Leo', 'Clark', '1992-06-18', 'Male', 181, GETDATE(), GETDATE(), 
            'leoclark@example.com', 'LEOCLARK@EXAMPLE.COM', 
            'leoclark@example.com', 'LEOCLARK@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_14', 'concurrency_stamp_14', 
            '555-456-4444', 0, 0, NULL, 0, 0),
           
           (15, 'Mia', 'Lewis', '1996-09-03', 'Female', 172, GETDATE(), GETDATE(), 
            'mialewis@example.com', 'MIALEWIS@EXAMPLE.COM', 
            'mialewis@example.com', 'MIALEWIS@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_15', 'concurrency_stamp_15', 
            '555-567-5555', 0, 0, NULL, 0, 0),
           
           (16, 'Nathan', 'Walker', '1983-11-30', 'Male', 185, GETDATE(), GETDATE(), 
            'nathanwalker@example.com', 'NATHANWALKER@EXAMPLE.COM', 
            'nathanwalker@example.com', 'NATHANWALKER@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_16', 'concurrency_stamp_16', 
            '555-678-6666', 0, 0, NULL, 0, 0),
           
           (17, 'Olivia', 'Young', '1994-08-14', 'Female', 163, GETDATE(), GETDATE(), 
            'oliviayoung@example.com', 'OLIVIAYOUNG@EXAMPLE.COM', 
            'oliviayoung@example.com', 'OLIVIAYOUNG@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_17', 'concurrency_stamp_17', 
            '555-789-7777', 0, 0, NULL, 0, 0),
           
           (18, 'Paul', 'Allen', '1990-05-10', 'Male', 176, GETDATE(), GETDATE(), 
            'paulallen@example.com', 'PAULLEN@EXAMPLE.COM', 
            'paulallen@example.com', 'PAULLEN@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_18', 'concurrency_stamp_18', 
            '555-890-8888', 0, 0, NULL, 0, 0),
           
           (19, 'Quinn', 'King', '1984-01-17', 'Female', 158, GETDATE(), GETDATE(), 
            'quinnking@example.com', 'QUINNKING@EXAMPLE.COM', 
            'quinnking@example.com', 'QUINNKING@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_19', 'concurrency_stamp_19', 
            '555-901-9999', 0, 0, NULL, 0, 0),
           
           (20, 'Riley', 'Scott', '1992-10-28', 'Male', 174, GETDATE(), GETDATE(), 
            'rileyscott@example.com', 'RILEYSCOTT@EXAMPLE.COM', 
            'rileyscott@example.com', 'RILEYSCOTT@EXAMPLE.COM', 1, 
            'hashed_password_here', 'security_stamp_20', 'concurrency_stamp_20', 
            '555-012-0000', 0, 0, NULL, 0, 0);

SET IDENTITY_INSERT dbo.AspNetUsers OFF;
GO