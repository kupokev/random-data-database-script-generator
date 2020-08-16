# Random Data Script Generator

This project is meant to generate scripts for building and populating the tables of a database with random data based on specifications passed in by JSON files. 
The main purpose of this tool is to allow generation of random data for testing different data scenarios without having to use live data or data that is not structured like the data set you are working with.

### JSON Template

#### Column Pattern Types
These are the types that will be able to be passed in the pattern field for a column to determine what kind of information is generated in these fields.

| Value | Data Type | Description |
|-|-|-|
|custom|(selectable)|Pattern based field |
|customer_name|nvarchar(128)| |
|customer_nunber|nvarchar(16)| |
|identity|int identity(1, 1)|This field will be automatically created if not included in the JSON.|
|invoice_number|nvarchar(16) | |
|order_number|nvarchar(16)| |
|product_name|nvarchar(64)| |
|product_number|nvarchar(16)| |
|po_number|nvarchar(32)|Purchase Order Number|
|service_code| | |
|service_name| | |


### Future Features:

1. Indexing and foreign keys
