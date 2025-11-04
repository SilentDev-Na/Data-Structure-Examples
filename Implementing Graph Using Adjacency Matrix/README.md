# 🧩 Implementing Graph Using Adjacency Matrix

This C# project demonstrates how to implement a **Graph data structure** using an **Adjacency Matrix**.  
It supports both **Directed** and **Undirected** graphs and includes key functionalities such as adding edges, removing edges, updating weights, and tracking recent changes.

---

## 🚀 Features

- Supports **Directed** and **Undirected** graph types.  
- Add, remove, and update edges between vertices.    
- Display the **Adjacency Matrix** in a formatted table.  
- Calculate **In-Degree** and **Out-Degree** for each vertex.  
- View a history of recent graph changes (Add / Remove / Update).  
- Includes basic **error handling** for invalid inputs.

---

## 🧠 Concepts Covered

- Object-Oriented Programming (OOP)
- Collections (`List`, `Dictionary`, `Stack`)
- Structs and Enums
- Console UI formatting and utilities

---

## 📁 Project Structure

Implementing Graph Using Adjacency Matrix/
│
├── Graph Class/
│ └── Graph.cs # Core Graph class (main logic)
│
├── Utility Class/
│ └── clsUtil.cs # Helper utilities for display and formatting
│
├── Properties/
│ └── AssemblyInfo.cs # Assembly metadata
│
├── Program.cs # Main entry point (demonstration)
├── App.config # Application configuration
├── Implementing Graph Using Adjacency Matrix.csproj
└── Implementing Graph Using Adjacency Matrix.sln

---

## 🖥️ Example Output

Adjacency Matrix For Graph1 (UnDirected Graph):

mathematica
Copy code
A   B   C   D   E  
A 0 1 1 0 0  
B 1 0 1 1 0  
C 1 1 0 0 1  
D 0 1 0 0 0  
E 0 0 1 0 0  

Is there an edge between A and C: True  
Is there an edge between A and E: False  

---

## 🏷️ License
This project is licensed under the **MIT License**.
