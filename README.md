# CCIS Events Attendance App

Final Requirement for Database Fundamental (Laboratory)

## Set Up Instructions

Install XAMPP and whatever this page tells you to
```
https://blogs.oracle.com/opal/post/installing-xampp-on-windows-for-php-and-oracle-database
```

Edit "D:\xampp\php\php.ini" and uncomment the line "extension=oci8_19"

Open FundaDBFinalReq/htdocs and place its contents (Database.php) into your XAMPP htdocs folder.

Then, get your local IP address by opening your terminal and typing

```
ipconfig
```
Get your IP address which should look like this:
```
192.168.XX.XX
```
Next, in the DatabaseHandler.cs file, replace the xamppIP with your IP address.

Finally, you may run the program in VS2022.
