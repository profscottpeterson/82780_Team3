--
-- File generated with SQLiteStudio v3.2.1 on Fri Oct 26 20:01:45 2018
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: ACTIVITY
DROP TABLE IF EXISTS ACTIVITY;

CREATE TABLE ACTIVITY (
    ActivityID     INTEGER      PRIMARY KEY AUTOINCREMENT,
    Name           VARCHAR (20),
    Duration       INT,
    CaloriesBurned INT,
    Date           DATE,
    FK_UserID      INT,
    FOREIGN KEY (
        FK_UserID
    )
    REFERENCES User (UserID) 
);

INSERT INTO ACTIVITY (
                        ActivityID,
                        Name,
                        Duration,
                        CaloriesBurned,
                        Date,
                        FK_UserID
                    )
                    VALUES (
                        1,
                        'Walking',
                        60,
                        350,
                        '2018-10-11',
                        1
                    );

INSERT INTO ACTIVITY (
                        ActivityID,
                        Name,
                        Duration,
                        CaloriesBurned,
                        Date,
                        FK_UserID
                    )
                    VALUES (
                        2,
                        'Running',
                        60,
                        750,
                        '2018-10-17',
                        1
                    );

INSERT INTO ACTIVITY (
                        ActivityID,
                        Name,
                        Duration,
                        CaloriesBurned,
                        Date,
                        FK_UserID
                    )
                    VALUES (
                        3,
                        'Walking',
                        30,
                        150,
                        '2018-10-20',
                        2
                    );

INSERT INTO ACTIVITY (
                        ActivityID,
                        Name,
                        Duration,
                        CaloriesBurned,
                        Date,
                        FK_UserID
                    )
                    VALUES (
                        4,
                        'Running',
                        40,
                        400,
                        '2018-10-25',
                        3
                    );


-- Table: FOOD
DROP TABLE IF EXISTS FOOD;

CREATE TABLE FOOD (
    FoodID    INTEGER      PRIMARY KEY AUTOINCREMENT,
    Title     VARCHAR (50),
    Calories  INT,
    DateAdded DATE,
    FK_UserID INT,
    FOREIGN KEY (
        FK_UserId
    )
    REFERENCES User (UserID) 
);

INSERT INTO FOOD (
                     FoodID,
                     Title,
                     Calories,
                     DateAdded,
                     FK_UserID
                 )
                 VALUES (
                     1,
                     'Big Mac',
                     550,
                     '2018-10-20',
                     1
                 );

INSERT INTO FOOD (
                     FoodID,
                     Title,
                     Calories,
                     DateAdded,
                     FK_UserID
                 )
                 VALUES (
                     2,
                     'Easy Mac',
                     200,
                     '2018-10-20',
                     1
                 );

INSERT INTO FOOD (
                     FoodID,
                     Title,
                     Calories,
                     DateAdded,
                     FK_UserID
                 )
                 VALUES (
                     3,
                     '2 Eggs',
                     180,
                     '2018-10-21',
                     2
                 );

INSERT INTO FOOD (
                     FoodID,
                     Title,
                     Calories,
                     DateAdded,
                     FK_UserID
                 )
                 VALUES (
                     4,
                     'Yogurt',
                     90,
                    '2018-10-21',
                     1
                 );


-- Table: USER
DROP TABLE IF EXISTS USER;

CREATE TABLE USER (
    UserID          INTEGER      PRIMARY KEY AUTOINCREMENT,
    FName           VARCHAR (20),
    LName           VARCHAR (20),
    Height          INT,
    StartingWeight  INT,
    GoalWeight      INT,
    Age             INT,
    Gender          VARCHAR (10),
    RecommendIntake INT,
    ActivityLevel   VARCHAR (20),
    LastLogin       DATETIME,
    CurrentUser     BOOLEAN
);

INSERT INTO USER (
                     UserID,
                     FName,
                     LName,
                     Height,
                     StartingWeight,
                     GoalWeight,
                     Age,
                     Gender,
                     RecommendIntake,
                     ActivityLevel,
                     LastLogin,
                     CurrentUser
                 )
                 VALUES (
                     1,
                     'John',
                     'Doe',
                     70,
                     165,
                     155,
                     22,
                     'Male',
                     2000,
                     'Sendentary',
                     '2018-10-19',
                     0
                 );

INSERT INTO USER (
                     UserID,
                     FName,
                     LName,
                     Height,
                     StartingWeight,
                     GoalWeight,
                     Age,
                     Gender,
                     RecommendIntake,
                     ActivityLevel,
                     LastLogin,
                     CurrentUser
                 )
                 VALUES (
                     2,
                     'Jenny',
                     'D',
                     68,
                     145,
                     140,
                     28,
                     'Female',
                     1900,
                     'Lightly Active',
                     '2018-10-21',
                     1
                 );

INSERT INTO USER (
                     UserID,
                     FName,
                     LName,
                     Height,
                     StartingWeight,
                     GoalWeight,
                     Age,
                     Gender,
                     RecommendIntake,
                     ActivityLevel,
                     LastLogin,
                     CurrentUser
                 )
                 VALUES (
                     3,
                     'Jane',
                     'D',
                     67,
                     156,
                     140,
                     21,
                     'Male',
                     1800,
                     'Lightly Active',
                     '2018-10-20',
                     0
                 );


-- Table: WEIGHT
DROP TABLE IF EXISTS WEIGHT;

CREATE TABLE WEIGHT (
    WeightID       INTEGER PRIMARY KEY AUTOINCREMENT,
    Date           DATE,
    WeightRecorded INT,
    FK_UserID      INT,
    FOREIGN KEY (
        FK_UserID
    )
    REFERENCES User (UserID) 
);

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       1,
                       '2018-10-17',
                       150,
                       1
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       2,
                       '2018-10-20',
                       149,
                       1
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       3,
                       '2018-10-25',
                       147,
                       1
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       4,
                       '2018-10-27',
                       146,
                       1
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       5,
                      '2018-10-15',
                       148,
                       2
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       6,
                       '2018-10-20',
                       150,
                       2
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       7,
                       '2018-10-21',
                       150,
                       2
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       8,
                       '2018-10-30',
                       147,
                       2
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       9,
                       '2018-10-10',
                       145,
                       3
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       10,
                       '2018-10-20',
                       141,
                       3
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       11,
                       '2018-10-30',
                       139,
                       3
                   );

INSERT INTO WEIGHT (
                       WeightID,
                       Date,
                       WeightRecorded,
                       FK_UserID
                   )
                   VALUES (
                       12,
                       '2018-10-31',
                       140,
                       3
                   );


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
