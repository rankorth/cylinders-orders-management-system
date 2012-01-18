1. COMS Database Setup
- Install Microsoft SQL Server 2008 with Management Studio.
- Open Management Studio, connect to SQL Server.
- Open script "Source Code\COMS_Project\DataBase\COMS_data_14 Jan.sql"
- Change "F:\mtech_svn\COMS_Database\COMS.mdf" and "F:\mtech_svn\COMS_Database\COMS_log.ldf" to locations where you would like to place the COMS database file.
-Run the script.

2. COMS Application Setup
- Install Visual Studio 2010.
- Open "Source Code\COMS_Project\COMS\COMS.sln"
- Open "Source Code\COMS_Project\COMS\WebUI\Web.config" and change Data Source to your database server name (currently ".\SQLEXPRESS")
- Open "Source Code\COMS_Project\COMS\Workflow Management\Drawing\Drawing\App.config" and change Data Source to your database server name (currently ".\SQLEXPRESS")

3. Barcode Font Setup
- Install IDAutomationCode39 font under "Source Code\COMS_Project\".
- Restart computer.