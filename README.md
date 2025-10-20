# Challenge Wheelzy - Tomas Santander

---

## Quick Step-by-Step Guide

1. **Clone the repository:**
   ```bash
   git clone https://github.com/tomassantader/wheelzyChallenge.git
   ```

2. **Navigate to the project directory:**
   ```bash
   cd wheelzyChallenge
   ```

3. **Inspect the `/SQL` folder:**
   The `/SQL` folder contains the database creation and data insertion scripts. You should see:
   ```
   01_schema_definition.sql
   02_data_insertion.sql
   ```

4. **Prerequisites / Requirements:**
   - Microsoft SQL Server (2019+ recommended) or a compatible SQL Server instance.
   - SQL Server Management Studio (SSMS) or `sqlcmd` command-line tool.
   - .NET SDK version 8.0.x or higher (Target framework: net8.0)
   - Visual Studio 2022+ or VS Code (optional for CLI builds)

5. **Run the structure creation script (creates DB, tables, constraints)**

   **Using SSMS:**
   1. Open SSMS and connect to your server.
   2. File → Open → `01_schema_definition.sql` (or paste its contents into a New Query window).
   3. Execute the script (F5 or Execute) and wait until it finishes.
   4. Then, open `02_data_insertion.sql` and execute it to populate the database with sample data.

6. **Building the Project**

   **Restore NuGet Packages (important before building):**
   - When opening the solution, Visual Studio usually restores packages automatically.
     If not, right-click the solution → **Restore NuGet Packages**.

   **Using Visual Studio:**
   1. Open the solution `.sln` in Visual Studio.
   2. Select configuration `Debug` or `Release`.
   3. Build the solution (`Build → Build Solution` or `Ctrl+Shift+B`).
   4. Run the application to test.

   **Using .NET CLI:**
   ```bash
   dotnet restore    # Restore dependencies
   dotnet build      # Compile the project
   dotnet run        # Run the application
   ```

   **Note:** Make sure the `WheelzyDB` database is created and populated before running the project.