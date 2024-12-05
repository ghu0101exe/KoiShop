Create database KoiFishShop;
use koifishshop;

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Password VARCHAR(255),
    Phone varchar(12),
    Address VARCHAR(255)
);

CREATE TABLE Staff (
    StaffID INT PRIMARY KEY,
    StaffName VARCHAR(100),
    password VARCHAR(100)
);


CREATE TABLE Fish (
    KoiID INT PRIMARY KEY,
    Origin VARCHAR(100),
    Gender VARCHAR(10),
    Age INT,
    Size FLOAT,
    Breed VARCHAR(50),
    FoodAmountPerDay FLOAT,
    Image varchar(500),
    Price varchar(100)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    StaffID INT,
    OrderDate DATE,
    Status VARCHAR(50),
    PaymentMethod VARCHAR(50),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);

CREATE TABLE OrderDetail (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    KoiID INT,
    PromotionID INT,
    Quantity INT,
    SalePrice DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (KoiID) REFERENCES Fish(KoiID)
);

CREATE TABLE Consignment (
    ConsignmentID INT PRIMARY KEY,
    CustomerID INT,
    KoiID INT,
    StartDate DATE,
    EndDate DATE,
    Status VARCHAR(50),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (KoiID) REFERENCES Fish(KoiID)
);

CREATE TABLE Promotion (
    PromotionID INT PRIMARY KEY,
    DiscountPercent INT,
    Description VARCHAR(255)
);

CREATE TABLE RatingFeedback (
    FeedbackID INT PRIMARY KEY,
    CustomerID INT,
    KoiID INT,
    Rating INT,
    Comment TEXT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (KoiID) REFERENCES Fish(KoiID)
);

CREATE TABLE BlogPosts (
    BlogID INT PRIMARY KEY,
    CustomerID INT,
    Title VARCHAR(255),
    Content TEXT,
    AuthorID INT,
    PostDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Staff(StaffID)
);

CREATE TABLE News (
    NewsID INT PRIMARY KEY,
    CustomerID INT,
    Title VARCHAR(255),
    Content TEXT,
    AuthorID INT,
    PublishDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Staff(StaffID)
);

CREATE TABLE FAQ (
    FAQID INT PRIMARY KEY,
    Question TEXT,
    Answer TEXT
);