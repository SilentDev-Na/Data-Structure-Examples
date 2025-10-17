# StudentGradesManager

A C# console application that manages student grades per subject using **Jagged Arrays** and **BitArray**. The application displays student grades along with their pass/fail status.

> Note: This project is based on an example but has been **refactored**:
> - Added `clsStudents` class for student data and grade logic.
> - Refactored code into **reusable methods**.
> - Improved console **UI formatting** for clarity.

---

## Features

- Store student information: **ID, Name, Subject, Grade, IsActive**.
- Determine if a student **Passed/Failed** based on subject.
- Use **Jagged Arrays** for variable-length grade lists per subject.
- Use **BitArray** for efficient pass/fail storage.
- Formatted console output per subject.
- Modular and reusable code.

---

## Project Structure

- `Program.cs` - Main program logic; initializes students, prepares jagged arrays, and displays results. Most methods are here:  
  - `InitialValuesToStudents(List<clsStudents> students)`  
  - `GetSubjects(List<clsStudents> students, List<string> Subjects)`  
  - `PrepareGradesAndPassFlags(List<clsStudents> students, List<string> subjects, out int[][] jaggedGrades, out BitArray[] passFlags)`  
  - `DisplayResults(List<clsStudents> Students, List<string> Subject, int[][] jaggedGrades, BitArray[] passFlags)`  

- `clsStudents.cs` - Defines the `clsStudents` class with properties: StudentID, Name, Subject, Grade, IsActive, Passed.  

- `clsUtils.cs` - Utility class with helper method:  
  - `SetSeperator(char sep, int Length)`  

---

## Usage

1. Clone the repository.
2. Open the project in Visual Studio.
3. Build and run the application.
4. View formatted results for each subject.

**Example code snippets:**

```csharp
// Initialize students list
List<clsStudents> students = new List<clsStudents>();
InitialValuesToStudents(students);

// Get unique subjects
List<string> subjects = new List<string>();
GetSubjects(students, subjects);

// Prepare jagged arrays and pass flags
int[][] jaggedGrades;
BitArray[] passFlags;
PrepareGradesAndPassFlags(students, subjects, out jaggedGrades, out passFlags);

// Display results
DisplayResults(students, subjects, jaggedGrades, passFlags);
Methods Overview
InitialValuesToStudents(List<clsStudents> students) – Populate students list with initial data.

GetSubjects(List<clsStudents> students, List<string> Subjects) – Extract unique subjects from students.

PrepareGradesAndPassFlags(List<clsStudents> students, List<string> subjects, out int[][] jaggedGrades, out BitArray[] passFlags) – Create jagged arrays for grades and BitArray for pass/fail flags.

DisplayResults(List<clsStudents> Students, List<string> Subject, int[][] jaggedGrades, BitArray[] passFlags) – Display formatted results in console.

SetSeperator(char sep, int Length) – Print a separator line in console.

Notes
Jagged Arrays allow dynamic number of students per subject.

BitArray efficiently stores pass/fail flags.

Refactored code demonstrates clean, modular, and reusable methods.

Console output is formatted clearly per subject with columns: Subject, Name, Grade, Status.

Project Name: StudentGradesManager
