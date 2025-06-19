# Oracle University Management

A secure internal data management system for university operations, built on Oracle Database with enterprise-level access control mechanisms.

## 🔧 Technologies Used
- **Database**: Oracle 21c XE (Multitenant architecture)
- **Frontend**: C# WinForms (.NET Framework)
- **Security Features**:
  - Role-Based Access Control (RBAC)
  - Virtual Private Database (VPD)
  - Oracle Label Security (OLS)
  - Standard & Fine-Grained Auditing
- **Backup**: Data Pump & RMAN

## 📌 Key Features

### 🔐 User and Role Management (Subsystem 1)
- Create, edit, and delete users/roles
- Assign privileges to users and roles (e.g. `SELECT`, `INSERT`, `UPDATE`)
- Support for `WITH GRANT OPTION` and `WITH ADMIN OPTION`
- View and revoke existing permissions

### 📁 Internal Data Security (Subsystem 2)
- **RBAC**: 
  - Control access to `NHANVIEN` and `MOMON` tables based on job roles
  - Custom views for each role (e.g. staff, manager, academic affairs)
- **VPD**: 
  - Row-level access control for `SINHVIEN` and `DANGKY`
  - Students can only access their own records
- **OLS**: 
  - Confidential notifications filtered by clearance (e.g. faculty, staff, student)
- **Audit**: 
  - Log suspicious or unauthorized activity at table/row level
  - Fine-grained tracking for salary, grade changes, etc.

### 💾 Backup & Recovery
- `expdp`/`impdp` scripts for schema-level backup
- `RMAN` for full PDB-level backup and point-in-time recovery
- Supports scheduled automatic backups via Task Scheduler

## 🚀 How to Run

1. Execute the scripts in the `/scripts/` folder in the following order:
   - `database.sql` → `role_user.sql` → `RBAC.sql` → `VPD.sql` → `OLS.sql` → `Audit.sql`
2. Open `OUM.sln` in Visual Studio
3. Build (F7) and Run (Ctrl + F5)

## 📽️ Demo Videos
- [Subsystem 1 - User & Role Management](https://youtu.be/vrjW904iQ4g?si=FvGPawCB-b1GemwF)
- [Subsystem 2 - Secure Data Access](https://youtu.be/TASTmHk53Xg?si=qNbxphPqmHKwsDcX)

---

