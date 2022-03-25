## Reverse Database MYSQL

1. Tambahkan package baru untuk koneksi ke database yaitu EF/EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore

2. Tambahkan package kedua provider database pake mysql
dotnet add package Pomelo.EntityFrameworkCore.MySql

3. Reverse engineering untuk database/EF dengan menambahkan package build design
dotnet add package Microsoft.EntityFrameworkCore.Design

4. Siapkan connection string
server=localhost;user=root;password=root123;database=kamlinkodb

5. jalankan command untuk reverse
dotnet ef dbcontext scaffold "server=localhost;user=root;password=root123;database=kamlinkodb" Pomelo.EntityFrameworkCore.MySql --context-dir Datas --output-dir "Datas/Entities"
