# MVCAppCRUDUsingModel

#Database Script

CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  StoredProcedure [dbo].[AddStudentDetails]    Script Date: 2/18/2022 3:15:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddStudentDetails]  
(  
   @Name varchar (50),  
   @City varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Insert into Student values(@Name,@City,@Address)  
End 
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentById]    Script Date: 2/18/2022 3:15:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteStudentById]  
(  
   @ID int  
)  
as   
begin  
   Delete from Student where Id=@ID  
End 
GO
/****** Object:  StoredProcedure [dbo].[GetStudents]    Script Date: 2/18/2022 3:15:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetStudents]  
as  
begin  
   select *from Student  
End 
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentDetails]    Script Date: 2/18/2022 3:15:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateStudentDetails]  
(  
   @ID int,  
   @Name varchar (50),  
   @City varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Update Student   
   set Name=@Name,  
   City=@City,  
   Address=@Address  
   where Id=@ID  
End 
 
GO
