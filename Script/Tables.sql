CREATE TABLE [User] (Id INT IDENTITY PRIMARY KEY NOT NULL
				    ,[Name] VARCHAR(100) NOT NULL
				    ,[Login] VARCHAR(45) NOT NULL
				    ,[Password] VARCHAR(45) NOT NULL
				    ,CpfCnpj varchar(14) NOT NULL
					,RegistrationDate DATETIME NOT NULL
					,UpdateDate DATETIME NULL
					,IsActive BIT NOT NULL
					,IsExcluded BIT NOT NULL
					,[Role] VARCHAR(100))



CREATE TABLE WorkoutType(Id INT IDENTITY PRIMARY KEY NOT NULL
                        ,[Description] VARCHAR(100) NOT NULL
						,RegistrationDate DATETIME NOT NULL
						,UpdateDate	DATETIME NULL						
						,IsActive BIT NOT NULL
						,IsExcluded BIT NOT NULL)



CREATE TABLE Workout(Id INT IDENTITY PRIMARY KEY
                    ,IdWorkoutType INT NOT NULL
					,CONSTRAINT FK_WORKOUTTYPE_WORKOUT_FK FOREIGN KEY (IdWorkoutType) 
					 REFERENCES WorkoutType(ID)
                    ,[Description] VARCHAR(100) NOT NULL
					,RegistrationDate DATETIME NOT NULL
					,UpdateDate DATETIME NULL
					,ApplicationDate DATETIME NOT NULL
					,IsActive BIT NOT NULL
					,IsExcluded BIT NOT NULL)


CREATE TABLE MovementType(Id INT IDENTITY PRIMARY KEY NOT NULL
                         ,[Description] VARCHAR(100) NOT NULL
						 ,RegistrationDate DATETIME NOT NULL
						 ,UpdateDate DATETIME NULL
						 ,IsActive BIT NOT NULL
						 ,IsExcluded BIT NOT NULL)

CREATE TABLE Movement(Id INT IDENTITY PRIMARY KEY NOT NULL
                     ,IdMovementType INT NOT NULL
					 ,CONSTRAINT FK_MOVEMENTTYPE_MOVEMENT FOREIGN KEY(IdMovementType)
					  REFERENCES MovementType(Id)
					 ,[Description] VARCHAR(100) NOT NULL
					 ,RegistrationDate DATETIME NOT NULL
					 ,UpdateDate DATETIME NULL
					 ,IsActive BIT NOT NULL
					 ,IsExcluded BIT NOT NULL)

CREATE TABLE WorkoutMovements(Id INT IDENTITY PRIMARY KEY NOT NULL
                             ,IdWorkout  INT NOT NULL
							 ,CONSTRAINT FK_WORKOUT_WORKOUTMOVEMENTS FOREIGN KEY(IdWorkout)
							  REFERENCES Workout (Id)
							 ,IdMovement INT NOT NULL
							 ,CONSTRAINT FK_MOVEMENT_WORKOUTMOVEMENTS FOREIGN KEY (IdMovement)
							  REFERENCES Movement(Id)
							 ,RegistrationDate DATETIME NOT NULL
							 ,UpdateDate DATETIME NULL)

CREATE TABLE WorkoutPlan(Id INT IDENTITY PRIMARY KEY NOT NULL
                        ,IdWorkout INT NOT NULL
						,CONSTRAINT FK_WORKOUT_WORKOUTPLAN FOREIGN KEY(IdWorkout)
						 REFERENCES Workout(Id)
						,[Description] VARCHAR(100) NOT NULL
						,BeginPeriod DATETIME NULL
						,EndPeriod DATETIME NULL
						,RegistrationDate DATETIME NOT NULL
						,UpdateDate DATETIME NULL
						,IsActive BIT NOT NULL
						,IsExcluded BIT NOT NULL)

CREATE TABLE WorkoutUserPlan(Id INT IDENTITY PRIMARY KEY NOT NULL
                            ,IdWorkoutPlan INT NOT NULL
							,CONSTRAINT FK_WORKOUTPLAN_WORKOUTUSERPLAN FOREIGN KEY(IdWorkoutPlan)
							 REFERENCES WorkoutPlan(Id)
							,IdUser INT NOT NULL
							,CONSTRAINT FK_USER_WORKOUTUSERPLAN FOREIGN KEY(IdUser)
							 REFERENCES [User](Id)
							,RegistrationDate DATETIME NOT NULL)

CREATE TABLE LogMovements(Id INT IDENTITY PRIMARY KEY NOT NULL
                         ,IdWorkout INT NOT NULL
						 ,CONSTRAINT FK_WORKOUT_LOGMOVEMENTS FOREIGN KEY (IdWorkout)
						  REFERENCES Workout(id)
						 ,IdMovement INT NOT NULL
						 ,CONSTRAINT FK_MOVEMENT_LOGMOVEMENTS FOREIGN KEY (IdMovement)
						  REFERENCES Movement(Id)
						 ,RegistrationDate DATETIME NOT NULL)














					