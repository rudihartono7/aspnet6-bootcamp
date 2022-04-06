## Reverse Database MYSQL
1. Install .net cli dan ef cli

2. Tambahkan package baru untuk koneksi ke database yaitu EF/EntityFrameworkCore
`dotnet add package Microsoft.EntityFrameworkCore`

3. Tambahkan package kedua provider database pake mysql
`dotnet add package Pomelo.EntityFrameworkCore.MySql`

4. Reverse engineering untuk database/EF dengan menambahkan package build design
`dotnet add package Microsoft.EntityFrameworkCore.Design`

5. Siapkan connection string
`server=localhost;user=root;password=root123;database=kamlinkodb`

6. jalankan command untuk reverse
`dotnet ef dbcontext scaffold "server=localhost;user=root;password=root123;database=kamlinkodb" Pomelo.EntityFrameworkCore.MySql --context-dir Datas --output-dir "Datas/Entities" --force`



## Code First
1. Install .net cli dan ef cli

2. Tambahkan package baru untuk koneksi ke database yaitu EF/EntityFrameworkCore
`dotnet add package Microsoft.EntityFrameworkCore`

3. Tambahkan package kedua provider database pake mysql
`dotnet add package Pomelo.EntityFrameworkCore.MySql`

4. Reverse engineering untuk database/EF dengan menambahkan package build design
`dotnet add package Microsoft.EntityFrameworkCore.Design`

5. run command add initial migrations
`dotnet ef migrations add "AlterTableAdmin01" -o "Datas/Migrations"`

6. apply migration ke database
`dotnet ef database update`

more information about ef code first:
https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx