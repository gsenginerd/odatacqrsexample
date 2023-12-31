CREATE
DATABASE ODATA_EXAMPLE COLLATE SQL_LATIN1_GENERAL_CP1_CI_AS
GO

GRANT CONNECT ON DATABASE :: ODATA_EXAMPLE TO DBO
GO

GRANT VIEW ANY COLUMN ENCRYPTION KEY DEFINITION, VIEW ANY COLUMN MASTER KEY DEFINITION ON DATABASE :: ODATA_EXAMPLE TO [PUBLIC]
GO

CREATE TABLE DBO.EMPLOYEE
(
    EMPLOYEE_ID INT IDENTITY
        CONSTRAINT PK_EMPLOYEE
        PRIMARY KEY,
    FIRST_NAME  VARCHAR(200),
    LAST_NAME   VARCHAR(200),
    SALARY      DECIMAL(18, 2),
    JOB_ROLE    VARCHAR(50)
)
    GO

CREATE TABLE DBO.EMPLOYEE_ADDRESS
(
    ADDRESS_ID   INT IDENTITY
        CONSTRAINT PK_EMPLOYEE_ADDRESS
        PRIMARY KEY,
    HOUSE_NUMBER VARCHAR(255),
    CITY         VARCHAR(50),
    STATE        VARCHAR(50),
    COUNTRY      VARCHAR(50),
    EMPLOYEE_ID  INT
        CONSTRAINT FK_EMPLOYEE_ADDRESS_EMPLOYEE
            REFERENCES DBO.EMPLOYEE
)
    GO