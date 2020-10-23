using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace projectsp
{
    class projectstored
    {
        SqlMethods sql = new SqlMethods();
        public bool InsertNewBank(string bankname="-1")
        {
            return (bool) sql.sqlExecute("InsertNewBank", "'"+bankname+"','0'");
        }
        public bool InsertNewBranch(string branchname="-1",string bankname="-1",string phone1=" ",string phone2=" ",string fax=" ",string address=" ",string notes=" ")
        {
            return (bool) sql.sqlExecute("InsertNewBranch", "'" + branchname + "','" + bankname + "','" + phone1 + "','" + phone2 + "','" + fax+ "','" + address + "','" + notes + "','0'");
        }
        public bool InsertNewCar(string carname = "-1")
        {
            return (bool)sql.sqlExecute("InsertNewCar", "'" + carname + "','0'");
        }
        
        public bool InsertNewCustomerGroup(string groupname = "-1")
        {
            return (bool)sql.sqlExecute("InsertNewCustomerGroupID", "'" + groupname + "','0'");
        }

        public bool InsertNewDelegate(string delegatename = "-1", int ratio = -1, string government = " ", string country = " ", string phone = " ", string mobile = " ", double salary=-1,string notes=" ")
        {

            return (bool)sql.sqlExecute("InsertNewDelegate", "'" + delegatename + "'," + ratio + ",'" + government + "','" + country + "','" + phone + "','" + mobile + "'," + salary+ ",'" + notes + "','0'");
        }
        public bool InsertNewDepartment(string departmentname = "-1", string mainmanagmentname = "-1")
        {
            return (bool)sql.sqlExecute("InsertNewDepartment", "'" + departmentname + "','" + mainmanagmentname + "','0'");
        }

        public bool InsertNewExpense(string expensename = "-1")
        {
            return (bool)sql.sqlExecute("InsertNewExpense", "'" + expensename + "','0'");
        }

        public bool InsertNewGroup(string name = "-1")
        {
            return (bool)sql.sqlExecute("InsertNewGroup", "'" + name + "','0'");
        }
        public bool InsertNewItemGroup(string name = "-1",string description=" ",int maingroupid=-1)
        {
            return (bool)sql.sqlExecute("InsertNewItemGroup", "'" + name + "','" + description + "','" + maingroupid + "','0'");
        }
        public bool InsertNewJopTitle(string name = "-1")
        {
            return (bool)sql.sqlExecute("InsertNewJopTitle", "'" + name + "','0'");
        }
        public bool InsertNewManagement(string name = "-1",string managername="-1")
        {
            return (bool)sql.sqlExecute("InsertNewManagement", "'" + name + "','" + managername + "','0'");
        }
        public bool InsertNewSubUnit(double value = 1,string unitname=" ")
        {
            return (bool)sql.sqlExecute("InsertNewSubUnit", "'" + value + "','" + unitname + "','0'");
        }
        public bool InsertNewUnit(string name = "-1")
        {
            return (bool)sql.sqlExecute("InsertNewUnit", "'" + name + "','0'");
        }
        public int InsertNewUser(string username = "-1", string password = "-1", string code = " ", string phone = " " ,string address = " ", string notes = " ")
        {
            return (int)sql.sqlExecute("InsertNewUser", "'" + username + "','" + password + "','" + code + "','" + phone + "','" + address + "','" + notes + "','0'");
        }
        public bool InsertNewVendor(string code = "-1", string name = "-1",  string government = " ", string country = " ",string address=" ", string phone = " ",string fax=" ", string mobile = " ", string zip = " ", string delegatename = " ", string email = " ", double limitedcredit = 0, string notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewVendor", "'" + code + "','" + name + "','" + government + "','" + country + "','" + address + "','" + phone + "','" + fax + "','" + mobile + "','" + zip + "','" + delegatename + "','" + email + "'," + limitedcredit + ",'" + notes + "','0'");
        }
        public void DeleteBank(string name)
        {
            sql.sqlExecute("UpdateBankState", "'" + name + "',1");
        }

        public void DeleteBranch(string branchname,string bankname)
        {
            sql.sqlExecute("UpdateBranchState", "'" + branchname + "','"+bankname+ "',1");
        }

        public void DeleteCar(string name)
        {
            sql.sqlExecute("UpdateCarState", "'" + name + "',1");
        }

        public void DeleteCustomerGroup(int id)
        {
            sql.sqlExecute("UpdateCustomerGroupState", "'" + id + "',1");
        }

        public void DeleteDelegate(string name)
        {
            sql.sqlExecute("UpdateDelegateState", "'" + name + "',1");
        }

        public void DeleteExpenseType(string name)
        {
            sql.sqlExecute("UpdateExpenseTypeState", "'" + name + "',1");
        }

        public void DeleteItemGroup(string itemname,string maingroupname)
        {
            sql.sqlExecute("UpdateItemGroupState", "'" + itemname + "','"+maingroupname+"',1");
        }

        public void DeleteJobtitle(string name)
        {
            sql.sqlExecute("UpdateJobtitleState", "'" + name + "',1");
        }

        public void DeleteMainDepartment(string name)
        {
            sql.sqlExecute("UpdateMainDepartmentState", "'" + name + "',1");
        }

        public void DeleteMainGroup(string name)
        {
            sql.sqlExecute("UpdateMainGroupState", "'" + name + "',1");
        }

        public void DeleteMainManagement(string name)
        {
            sql.sqlExecute("UpdateMainManagementState", "'" + name + "',1");
        }

        public void DeleteMainUnit(string name)
        {
            sql.sqlExecute("UpdateMainUnitState", "'" + name + "',1");
        }

        public void DeleteSubUnit(string name)
        {
            sql.sqlExecute("UpdateSubUnitState", "'" + name + "',1");
        }

        public void DeleteUser(string name)
        {
            sql.sqlExecute("UpdateUserState", "'" + name + "',1");
        }

        public void DeleteVendor(int id)
        {
            sql.sqlExecute("UpdateVendorState", "'" + id + "',1");
        }

      
        //13 october update user table
        public DataTable GetTableAttributes(string tablename=" ")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("select * from getTableAttributes('" + tablename + "')"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool UpdateUser(int id=-1,string username = "-1", string password = "-1", string code = " ", string phone = " ", string address = " ", string notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateUser", "'"+id+"','" + username + "','" + password + "','" + code + "','" + phone + "','" + address + "','" + notes + "','0'");
        }

        public DataTable GetUser(string key="1",string value="1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'UsersView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        //27 october update get first layer




        public bool UpdateBank(int id = -1, string bankname = "-1")
        {
            return (bool)sql.sqlExecute("UpdateBank", "'" + id + "','" + bankname + "','0'");
        }
        public bool UpdateBranch(int id = -1, string branchname = "-1", string bankname = "-1", string phone1 = " ", string phone2 = " ", string fax = " ", string address = " ", string notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateBranch", "'" + id + "','" + branchname + "','" + bankname + "','" + phone1 + "','" + phone2 + "','" + fax + "','" + address + "','" + notes + "','0'");
        }
        public bool UpdateCar(int id = -1, string carname = "-1")
        {
            return (bool)sql.sqlExecute("UpdateCar", "'"+id+"','" + carname + "','0'");
        }

        public bool UpdateCustomerGroup(int id = -1, string groupname = "-1")
        {
            return (bool)sql.sqlExecute("UpdateCustomerGroupID", "'" + id + "','" + groupname + "','0'");
        }

        public bool UpdateDelegate(int id = -1, string delegatename = "-1", int ratio = -1, string government = " ", string country = " ", string phone = " ", string mobile = " ", double salary = -1, string notes = " ")
        {

            return (bool)sql.sqlExecute("UpdateDelegate", "'" + id + "','" + delegatename + "'," + ratio + ",'" + government + "','" + country + "','" + phone + "','" + mobile + "'," + salary + ",'" + notes + "','0'");
        }
        public bool UpdateDepartment(int id = -1,string departmentname = "-1", string mainmanagmentname = "-1")
        {
            return (bool)sql.sqlExecute("UpdateDepartment", "'" + id + "','" + departmentname + "','" + mainmanagmentname + "','0'");
        }

        public bool UpdateExpense(int id = -1,string expensename = "-1")
        {
            return (bool)sql.sqlExecute("UpdateExpense", "'" + id + "','" + expensename + "','0'");
        }

        public bool UpdateGroup(int id = -1,string name = "-1")
        {
            return (bool)sql.sqlExecute("UpdateGroup", "'" + id + "','" + name + "','0'");
        }
        public bool UpdateItemGroup(int id = -1,string name = "-1", string description = " ", string maingroupname = "-1")
        {
            return (bool)sql.sqlExecute("UpdateItemGroup", "'" + id + "','" + name + "','" + description + "','" + maingroupname + "','0'");
        }
        public bool UpdateJopTitle(int id = -1,string name = "-1")
        {
            return (bool)sql.sqlExecute("UpdateJopTitle", "'" + id + "','" + name + "','0'");
        }
        public bool UpdateManagement(int id = -1,string name = "-1", string managername = "-1")
        {
            return (bool)sql.sqlExecute("UpdateManagement", "'" + id + "','" + name + "','" + managername + "','0'");
        }
        public bool UpdateSubUnit(int id = -1, double value = 1, string unitname = " ")
        {
            return (bool)sql.sqlExecute("UpdateSubUnit", "'" + id + "','" + value + "','" + unitname + "','0'");
        }
        public bool UpdateUnit(int id = -1,string name = "-1")
        {
            return (bool)sql.sqlExecute("UpdateUnit", "'" + id + "','" + name + "','0'");
        }
        public bool UpdateVendor(int id = -1,string code = "-1", string name = "-1", string government = " ", string country = " ", string address = " ", string phone = " ", string fax = " ", string mobile = " ", string zip = " ", string delegatename = " ", string email = " ", double limitedcredit = 0, string notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateVendor", "'" + id + "','" + code + "','" + name + "','" + government + "','" + country + "','" + address + "','" + phone + "','" + fax + "','" + mobile + "','" + zip + "','" + delegatename + "','" + email + "'," + limitedcredit + ",'" + notes + "','0'");
        }

        public DataTable GetBank(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'BanksView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetBranches(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'BranchesView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetCars(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'CarsView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetCustomerGroups(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'CustomerGroupsView','" + key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetDelegate(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'DelegatesView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetExpenseType(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ExpensesTypesView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetItemGroup(string key = "1", string value = "1")  
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ItemGroupsView','"+key+"','"+value+"'"));

            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetJopTitles(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'JopTitlesView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetMainDepartment(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'MainDepartmentsView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetMainGroup(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'MainGroupsView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetMainManagement(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'MainManagementsView','" + key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetSubUnit(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'SubUnitsView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetUnit(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'UnitsView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public DataTable GetVendor(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'VendorsView','"+key+"','"+value+"'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        // 7 january 2019 update second layer 

        public DataTable GetCustomers(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'CustomersView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewCustomer(int customercode = -1, string name = " ", string country = "-1", string city = " ", string address = " ", string phone = " ", string email = " ", int fax = -1, int postalcode = -1, int credit = -1, int customergroupid = -1, int delegateid = -1, string notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewCustomer", "'" + customercode + "','" + name + "','" + country + "','" + city + "','" + address + "','" + phone + "','" + email + "','" + fax + "','" + postalcode + "','" + credit + "','" + customergroupid + "','" + delegateid + "','" + notes + "','0'");
        }
        public bool UpdateCustomer(int id = -1, int customercode = -1, string name = " ", string country = "-1", string city = " ", string address = " ", string phone = " ", string email = " ", int fax = -1, int postalcode = -1, int credit = -1, int customergroupid = -1, int delegateid = -1, string notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateCustomer", "'" + id + "','" + customercode + "','" + name + "','" + country + "','" + city + "','" + address + "','" + phone + "','" + email + "','" + fax + "','" + postalcode + "','" + credit + "','" + customergroupid + "','" + delegateid + "','" + notes + "','0'");
        }

        public DataTable GetVendorPayments(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'VendorsPaymentsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        
        // need to fixed in database  vendorpayments
        public bool InsertNewVendorPayments(int vendorid=-1,double amount = -1, string notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewVendorPayment", "'" + vendorid + "','" + amount + "','" + notes + "','0'");
        }
        public bool UpdateVendorPayments(int id = -1, int vendorid=-1, double amount = -1,  string notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateVendorPayment", "'" + id + "','" + vendorid + "','" + amount + "','" + notes + "','0'");
        }
        //
        public DataTable GetBondData(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'BondsDataView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewBondData(string BondType=" ",string bondto = " ", int vendorid = -1,int customerid=-1,double amount=-1, string notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewBondData", "'" + BondType + "','" + bondto + "','" + vendorid + "','" + customerid + "','" + amount + "','" + notes + "','0'");
        }
        public bool UpdateBondData(int id = -1, string BondType = " ", string bondto = " ", int vendorid = -1, int customerid = -1, double amount = -1,string bonddate="01-01-2019", string notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateBondData" , "'" + id + "','" + BondType + "','" + bondto + "','" + vendorid + "','" + customerid + "','" + amount + "','" + bonddate + "','" + notes + "','0'");
        }
        //----------------------
        public DataTable GetAccountTree(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'AccountTreesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetAccountTreeGroups(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'AccountsTreesGroupsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetAccountTreeAndGroups(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("select * from AccountTreesAndGroupsView"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewAccountTree(string name = " ", int treeid=-1)
        {
            return (bool)sql.sqlExecute("InsertNewAccountTree", "'" + name + "','" + treeid + "','0'");
        }
        public bool UpdateAccountTree   (int id = -1, string name = " ", int treeid = -1)
        {
            return (bool)sql.sqlExecute("UpdateAccountTree", "'" + id + "','" + name + "','" + treeid + "','0'");
        }
        
        public DataTable GetEmployees(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'EmployeesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetEmployeesHoliday(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'EmployeeHolidaysView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetEmployeesFinance(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'FinancesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        /* public bool InsertNewEmployee(string name = " ", int code = -1,string birthdate=" ",bool gender=false,string mobile=" ",string phone=" ",int deptid=-1,int insurancenumber=-1, string address = " ",int maxsickholiday=-1,int maxemergencyholiday=-1,int maxannualholiday=-1,int maxsalery=-1,int FixedRenumeration=-1,float other=-1, float workingtax = -1, float insurance = -1, float companiesinsurance = -1,int additionalhours=-1,string notes=" ")
         {
             return (bool)sql.sqlExecute("InsertNewEmployee", "'" + name + "','" + code + "','" + birthdate + "','" + gender + "','" + mobile + "','" + phone + "','" + deptid + "','" + insurancenumber + "','" + address + "','" + maxsickholiday + "','" + maxemergencyholiday + "','" + maxannualholiday + "','" + maxsalery + "','" + FixedRenumeration + "','" + other + "','" + workingtax + "','" + insurance + "','" + companiesinsurance + "','" + notes + "','0'");
         }
         public bool UpdateEmployee(int id = -1, string name = " ", int code = -1, string birthdate = "01-01-2019", bool gender = false, string mobile = " ", string phone = " ", int deptid = -1, int insurancenumber = -1, string address = " ", int maxsickholiday = -1, int maxemergencyholiday = -1, int maxannualholiday = -1, int maxsalery = -1, int FixedRenumeration = -1, float other = -1, float workingtax = -1, float insurance = -1, float companiesinsurance = -1, int additionalhours = -1, string notes = " ")
         {
             return (bool)sql.sqlExecute("UpdateEmployee", "'" + id + "','" + name + "','" + code + "','" + birthdate + "','" + gender + "','" + mobile + "','" + phone + "','" + deptid + "','" + insurancenumber + "','" + address + "','" + maxsickholiday + "','" + maxemergencyholiday + "','" + maxannualholiday + "','" + maxsalery + "','" + FixedRenumeration + "','" + other + "','" + workingtax + "','" + insurance + "','" + companiesinsurance + "','" + notes + "','0'");
         }*/
        public bool InsertNewEmployee(string EmployeeName = " ", int EmployeeCode = -1, string BirthDate = " ", bool Gender =false, string Email = " ", string Phone = " ", string Mobile = " ", int DeptID = -1, int InssuranceNo = -1, string Address = " ", int MaxSickHoliday = -1, int MaxEmergencyHoliday = -1, int MaxAnnualHoliday = -1, int MainSalary = -1, float FixedRenumeration = -1, float Other = -1, float WorkingTax = -1, float Insurance = -1, float CompaniesInsurance = -1, int AdditionalHours = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewEmployee", "'" + EmployeeName + "','" + EmployeeCode + "','" +  BirthDate + "','" + Gender + "','" + Email + "','" + Phone + "','" + Mobile + "','" + DeptID + "','" + InssuranceNo + "','" + Address + "','" + MaxSickHoliday + "','" + MaxEmergencyHoliday + "','" + MaxAnnualHoliday + "','" + MainSalary + "','" + FixedRenumeration + "','" + Other + "','" + WorkingTax + "','" + Insurance + "','" + CompaniesInsurance + "','" + AdditionalHours + "','" + Notes + "','0'");
        }
        public bool UpdateEmployee(int id = -1, string EmployeeName = " ", int EmployeeCode = -1, string BirthDate = " ", bool Gender =false, string Email = " ", string Phone = " ", string Mobile = " ", int DeptID = -1, int InssuranceNo = -1, string Address = " ", int MaxSickHoliday = -1, int MaxEmergencyHoliday = -1, int MaxAnnualHoliday = -1, int MainSalary = -1, float FixedRenumeration = -1, float Other = -1, float WorkingTax = -1, float Insurance = -1, float CompaniesInsurance = -1, int AdditionalHours = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateEmployee", "'" + id + "','" + EmployeeName + "','" + EmployeeCode + "','" + BirthDate + "','" + Gender + "','" + Email + "','" + Phone + "','" + Mobile + "','" + DeptID + "','" + InssuranceNo + "','" + Address + "','" + MaxSickHoliday + "','" + MaxEmergencyHoliday + "','" + MaxAnnualHoliday + "','" + MainSalary + "','" + FixedRenumeration + "','" + Other + "','" + WorkingTax + "','" + Insurance + "','" + CompaniesInsurance + "','" + AdditionalHours + "','" + Notes + "','0'");
        }
        //BanksAccountsView
        public DataTable GetBanksAccounts(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'BanksAccountsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        
        public bool InsertNewBankAccount(int accountno = -1, int branchid = -1, int currency = -1, string notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewBankAccount", "'" + accountno + "','" + branchid + "','" + currency + "','" + notes + "','0'");
        }
        public bool UpdateBankAccount(int id = -1, int accountno = -1, int branchid = -1, int currency = -1, string notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateBankAccount", "'" + id + "','" + accountno + "','" + branchid + "','" + currency + "','" + notes + "','0'");
        }
        //banking transaction


        public DataTable GetBankTransactions(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'BanksTransactionsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewBankTransaction(int BankAccountID = -1, int Value = -1, int ContractNo = -1, string TransactionType = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewBankTransaction", "'" + BankAccountID + "','" + Value + "','" + ContractNo + "','" + TransactionType + "','" + Notes + "','0'");
        }
        public bool UpdateBankTransaction(int id = -1, int BankAccountID = -1, int Value = -1, int ContractNo = -1, string TransactionType = " ", string Notes = " ")
        {
            return(bool)sql.sqlExecute("UpdateBankTransaction", "'" + id + "','" + BankAccountID + "','" + Value + "','" + ContractNo + "','" + TransactionType + "','" + Notes + "','0'");
        }

        //balance data
        public DataTable GetBalancesData(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'BalancesDataView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewBalanceData(string BalanceType = " ", double Value = -1)
        {
            return (bool)sql.sqlExecute("InsertNewBalanceData", "'" + BalanceType + "','" + Value + "','0'");
        }
        public bool UpdateBalanceData(int id = -1, string BalanceType = " ", double Value = -1)
        {
            return (bool)sql.sqlExecute("UpdateBalanceData", "'" + id + "','" + BalanceType + "','" + Value + "','0'");
        }
        //begging balance data
        //BegingBalancesView
        public DataTable GetBegingBalances(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'BegingBalancesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewBegingBalance(string BalanceTo = " ", int VendorID = -1, int CustomerID = -1, string MovementType = " ", double Value = -1)
        {
            return (bool)sql.sqlExecute("InsertNewBegingBalance", "'" + BalanceTo + "','" + VendorID + "','" + CustomerID + "','" + MovementType + "','" + Value + "','0'");
        }
        public bool UpdateBegingBalance(int id = -1, string BalanceTo = " ", int VendorID = -1, int CustomerID = -1, string MovementType = " ", double Value = -1)
        {
            return (bool)sql.sqlExecute("UpdateBegingBalance", "'" + id + "','" + BalanceTo + "','" + VendorID + "','" + CustomerID + "','" + MovementType + "','" + Value + "','0'");
        }
        //EstimatedBudgetsView
        public DataTable GetEstimatedBudgets(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'EstimatedBudgetsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewEstimatedBudget(int Year = -1, double Purchase = -1, double Income = -1, double Sales = -1, double Expenses = -1, double Profit = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewEstimatedBudget", "'" + Year + "','" + Purchase + "','" + Income + "','" + Sales + "','" + Expenses + "','" + Profit + "','" + Notes + "','0'");
        }
        public bool UpdateEstimatedBudget(int id = -1, int Year = -1, double Purchase = -1, double Income = -1, double Sales = -1, double Expenses = -1, double Profit = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateEstimatedBudget", "'" + id + "','" + Year + "','" + Purchase + "','" + Income + "','" + Sales + "','" + Expenses + "','" + Profit + "','" + Notes + "','0'");
        }
        //ExpensesDataView

        public DataTable GetExpensesData(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ExpensesDataView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewExpenseData(int ExpenseTypeID = -1, int CarID = -1, int Value = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewExpenseData", "'" + ExpenseTypeID + "','" + CarID + "','" + Value + "','" + Notes + "','0'");
        }
        public bool UpdateExpenseData(int id = -1, int ExpenseTypeID = -1, int CarID = -1, int Value = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateExpenseData", "'" + id + "','" + ExpenseTypeID + "','" + CarID + "','" + Value + "','" + Notes + "','0'");
        }
        //JounralsView
        public DataTable GetJounrals(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'JounralsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewJournal( string Type = " ", string To = " ", double Amount = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewJournal", "'" + Type + "','" + To + "','" + Amount + "','" + Notes + "','0'");
        }
        public bool UpdateJournal(int id = -1,  string Type = " ", string To = " ", double Amount = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateJournal", "'" + id + "','" + Type + "','" + To + "','" + Amount + "','" + Notes + "','0'");
        }
        //13-2 2nd level delete
        public void DeleteCustomer(int id)
        {
            sql.sqlExecute("UpdateCustomerState", "'" + id + "',1");
        }
        public void DeleteVendorPayment(int id)
        {
            sql.sqlExecute("UpdateVendorPaymentState", "'" + id + "',1");
        }
        public void DeleteBondData(int id)
        {
            sql.sqlExecute("UpdateBondDataState", "'" + id + "',1");
        }
        public void DeleteAccountTree(int id)
        {
            sql.sqlExecute("UpdateAccountTreeState", "'" + id + "',1");
        }
        public void DeleteEmployee(int id)
        {
            sql.sqlExecute("UpdateEmployeeState", "'" + id + "',1");
        }
        public void DeleteBankAccount(int id)
        {
            sql.sqlExecute("UpdateBankAccountState", "'" + id + "',1");
        }
        public void DeleteBankTransaction(int id)
        {
            sql.sqlExecute("UpdateBankTransactionState", "'" + id + "',1");
        }
        public void DeleteBalanceData(int id)
        {
            sql.sqlExecute("UpdateBalanceDataState", "'" + id + "',1");
        }
        public void DeleteBegingBalance(int id)
        {
            sql.sqlExecute("UpdateBegingBalanceState", "'" + id + "',1");
        }
        public void DeleteEstimatedBudget(int id)
        {
            sql.sqlExecute("UpdateEstimatedBudgetState", "'" + id + "'");
        }
        public void DeleteExpenseData(int id)
        {
            sql.sqlExecute("UpdateExpenseDataState", "'" + id + "',1");
        }
        public void DeleteJounral(int id)
        {
            sql.sqlExecute("UpdateJournalState", "'" + id + "',1");
        }
        //update level 3  27/3/2019
        public bool InsertNewAttendance(int EmployeeID = -1, string Time = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewAttendance", "'" + EmployeeID + "','" + Time + "','" + Notes + "','0'");
        }
        //public bool UpdateAttendance(int id = -1, int EmployeeID = -1, string Time = " ", string Notes = " ")
        //{
        //    return (bool)sql.sqlExecute("UpdateAttendance", "'" + id + "','" + EmployeeID + "','" + Time + "','" + Notes + "','0'");
        //}
        //public void DeleteAttendance(int id)
        //{
        //    sql.sqlExecute("UpdateAttendanceState", "'" + id + "',1");
        //}
        //public DataTable GetAttendances(string key = "1", string value = "1")
        //{
        //    SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'AttendancesView','" + key + "','" + value + "'"));
        //    DataTable Dt = new DataTable();
        //    check.Fill(Dt);
        //    return Dt;
        //}
        public int InsertNewConversion(int FromStoreID = -1, int ToStoreID = -1, string Notes = " ")
        {
            return (int)sql.sqlExecute("InsertNewConversion", "'" + FromStoreID + "','" + ToStoreID + "','" + Notes + "','0'");
        }
        public void ExecConversionProcess(int ConvID=-1)
        {
           sql.sqlExecute("ExecConversionProcess", "'" + ConvID + "'");

        }
        public bool UpdateConversion(int id = -1, int FromStoreID = -1, int ToStoreID = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateConversion", "'" + id + "','" + FromStoreID + "','" + ToStoreID + "','" + Notes + "','0'");
        }
        public void DeleteConversion(int id)
        {
            sql.sqlExecute("UpdateConversionState", "'" + id + "',1");
        }
        public DataTable GetConversions(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ConversionsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewConversionDetail(int ConversionID = -1, int ItemID = -1, int Quantity = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewConversionDetail", "'" + ConversionID + "','" + ItemID + "','" + Quantity + "','" + Notes + "','0'");
        }
        public bool UpdateConversionDetail(int id = -1, int ConversionID = -1, int ItemID = -1, int Quantity = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateConversionDetail", "'" + id + "','" + ConversionID + "','" + ItemID + "','" + Quantity + "','" + Notes + "','0'");
        }
        public void DeleteConversionDetail(int id)
        {
            sql.sqlExecute("UpdateConversionDetailState", "'" + id + "',1");
        }
        public DataTable GetConversionsDetails(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ConversionsDetailsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewDeparture(int EmployeeID = -1, string Time = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewDeparture", "'" + EmployeeID + "','" + Time + "','" + Notes + "','0'");
        }
        public int InsertNewSaleInvoice(int CustomerID = -1, int DelegateID = -1, int StoreID = -1, double Discount = -1, double Tax = -1, double Added = -1, double Total = -1, double TotalNet = -1)
        {
            return (int)sql.sqlExecute("InsertNewSaleInvoice", "'" + CustomerID + "','" + DelegateID + "','" + StoreID + "','" + Discount + "','" + Tax + "','" + Added + "','" + Total + "','" + TotalNet + "','0'");
        }
        public bool InsertNewSaleInvoiceDetail(int InvoiceID = -1, int ItemID = -1, int Quantity = -1, int UnitPrice = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewSaleInvoiceDetail", "'" + InvoiceID + "','" + ItemID + "','" + Quantity + "','" + UnitPrice + "','" + Notes + "','0'");
        }
        //public bool UpdateDeparture(int id = -1, int EmployeeID = -1, string Time = " ", string Notes = " ")
        //{
        //    return (bool)sql.sqlExecute("UpdateDeparture", "'" + id + "','" + EmployeeID + "','" + Time + "','" + Notes + "','0'");
        //}
        //public void DeleteDeparture(int id)
        //{
        //    sql.sqlExecute("UpdateDepartureState", "'" + id + "',1");
        //}
        public DataTable GetDepartures(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'DeparturesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewInstallment(int CustomerID = -1, double MainMoney = -1, double Profit = -1, int InstallmentNumbers = -1, double AdvanceMoney = -1, string InstallmentStartDate = " ", string PaymentType = " ", string Purpose = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewInstallment", "'" + CustomerID + "','" + MainMoney + "','" + Profit + "','" + InstallmentNumbers + "','" + AdvanceMoney + "','" + InstallmentStartDate + "','" + PaymentType + "','" + Purpose + "','" + Notes + "','0'");
        }
        public bool UpdateInstallment(int id = -1, int CustomerID = -1, double MainMoney = -1, double Profit = -1, int InstallmentNumbers = -1, double AdvanceMoney = -1, string  InstallmentStartDate = " ", string PaymentType = " ", string Purpose = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateInstallment", "'" + id + "','" + CustomerID + "','" + MainMoney + "','" + Profit + "','" + InstallmentNumbers + "','" + AdvanceMoney + "','" + InstallmentStartDate + "','" + PaymentType + "','" + Purpose + "','" + Notes + "','0'");
        }
        public void DeleteInstallment(int id)
        {
            sql.sqlExecute("UpdateInstallmentState", "'" + id + "',1");
        }
        public DataTable GetInstallements(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'InstallmentsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewItem(string ItemName = " ", int ItemGroupID = -1, int UnitID = -1, double RedialLimit = -1, double PurchasePrice = -1, double ProfitRatio = -1, double SellingPrice = -1, double WholesalePrice = -1, string Color = " ", double BeggingBalance = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewItem", "'" + ItemName + "','" + ItemGroupID + "','" + UnitID + "','" + RedialLimit + "','" + PurchasePrice + "','" + ProfitRatio + "','" + SellingPrice + "','" + WholesalePrice + "','" + Color + "','" + BeggingBalance + "','" + Notes + "','0'");
        }
        public bool UpdateItem(int id = -1, string ItemName = " ", int ItemGroupID = -1, int UnitID = -1, double RedialLimit = -1, double PurchasePrice = -1, double ProfitRatio = -1, double SellingPrice = -1, double WholesalePrice = -1, string Color = " ", double BeggingBalance = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateItem", "'" + id + "','" + ItemName + "','" + ItemGroupID + "','" + UnitID + "','" + RedialLimit + "','" + PurchasePrice + "','" + ProfitRatio + "','" + SellingPrice + "','" + WholesalePrice + "','" + Color + "','" + BeggingBalance + "','" + Notes + "','0'");
        }
        public void DeleteItem(int id)
        {
            sql.sqlExecute("UpdateItemState", "'" + id + "',1");
        }
        public DataTable GetItems(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ItemsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewMaintenance(int CustomerID = -1, int EmployeeID = -1, double Cost = -1, string Phone = " ", string DeleiverDate = " ", string HardwareDesc = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewMaintenance", "'" + CustomerID + "','" + EmployeeID + "','" + Cost + "','" + Phone + "','" + DeleiverDate + "','" + HardwareDesc + "','" + Notes + "','0'");
        }
        public bool UpdateMaintenance(int id = -1, int CustomerID = -1, int EmployeeID = -1, double Cost = -1, string Phone = " ", string DeleiverDate = " ", string HardwareDesc = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateMaintenance", "'" + id + "','" + CustomerID + "','" + EmployeeID + "','" + Cost + "','" + Phone + "','" + DeleiverDate + "','" + HardwareDesc + "','" + Notes + "','0'");
        }
        public void DeleteMaintenance(int id)
        {
            sql.sqlExecute("UpdateMaintenanceState", "'" + id + "',1");
        }
        public DataTable GetMaintenances(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'MaintenancesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewOrderData(string SerialNo = " ", int StoreID = -1, string OrderType = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewOrder", "'" + SerialNo + "','" + StoreID + "','" + OrderType + "','" + Notes + "','0'");
        }
        public bool UpdateOrderData(int id = -1, string SerialNo = " ", int StoreID = -1, string OrderType = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateOrderData", "'" + id + "','" + SerialNo + "','" + StoreID + "','" + OrderType + "','" + Notes + "','0'");
        }
        public void DeleteOrderData(int id)
        {
            sql.sqlExecute("UpdateOrderDataState", "'" + id + "',1");
        }
        public DataTable GetOrdersData(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'OrdersDataView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewOrderDetail(int OrderID = -1, int ItemID = -1, int Quantity = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewOrderDetail", "'" + OrderID + "','" + ItemID + "','" + Quantity + "','" + Notes + "','0'");
        }
      /*  public bool UpdateOrderDetail(int id = -1, int OrderID = -1, int ItemID = -1, int Quantity = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateOrderDetail", "'" + id + "','" + OrderID + "','" + ItemID + "','" + Quantity + "','" + Notes + "','0'");
        }
        public void DeleteOrderDetail(int id)
        {
            sql.sqlExecute("UpdateOrderDetailState", "'" + id + "',1");
        }*/
        public DataTable GetOrdersDetails(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'OrdersDetailsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewOverTime(string EmployeeName = " ", string Date = " ", int hours = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewOverTime", "'" + EmployeeName + "','" + Date + "','" + hours + "','" + Notes + "','0'");
        }
        /*public bool UpdateOverTime(int id = -1, string EmployeeName = " ", string Date = " ", int hours = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateOverTime", "'" + id + "','" + EmployeeName + "','" + Date + "','" + hours + "','" + Notes + "','0'");
        }
        public void DeleteOverTime(int id)
        {
            sql.sqlExecute("UpdateOverTimeState", "'" + id + "',1");
        }*/
        public DataTable GetOverTimes(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'OverTimesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

      
        public int InsertNewPurchaseInvoice(int StoreID = -1, int VendorID = -1, double Discount = -1, double Tax = -1, double Added = -1,double Total=-1,double TotalNet=-1)
        {
            return (int)sql.sqlExecute("InsertNewPurchaseInvoice", "'" + StoreID + "','" + VendorID + "','" + Discount + "','" + Tax + "','" + Added + "','" + Total + "','" + TotalNet + "','0'");
        }
        public int getQuantityByStoreID(int StoreID = -1, int ItemID = -1)
        {
            return (int)sql.sqlExecute("getQuantityByStoreID", "'" + StoreID + "','" + ItemID + "'");
        }

        public bool InsertNewPurchaseInvoiceDetail(int InvoiceID = -1, int ItemID = -1, int Quantity = -1, int UnitPrice = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewPurchaseInvoiceDetail", "'" + InvoiceID + "','" + ItemID + "','" + Quantity + "','" + UnitPrice + "','" + Notes + "','0'");
        }

        public bool InsertNewStoreDetail(int StoreID = -1, int ItemID = -1, int Quantity = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewStoreDetail", "'" + StoreID + "','" + ItemID + "','" + Quantity + "','" + Notes + "','0'");
        }

        public DataTable GetPurchaseInvoices(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'PurchaseInvoicesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewReceivingCustody(int EmployeeID = -1, int ItemID = -1, string Date = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewReceivingCustody", "'" + EmployeeID + "','" + ItemID + "','" + Date + "','" + Notes + "','0'");
        }
        public bool UpdateReceivingCustody(int id = -1, int EmployeeID = -1, int ItemID = -1, string Date = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateReceivingCustody", "'" + id + "','" + EmployeeID + "','" + ItemID + "','" + Date + "','" + Notes + "','0'");
        }
        public void DeleteReceivingCustody(int id)
        {
            sql.sqlExecute("UpdateReceivingCustodyState", "'" + id + "',1");
        }
        public DataTable GetReceivingCustodies(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ReceivingCustodiesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewReturnPurchaseInvoice(int InvoiceID = -1, int VendorID = -1, int StoreID = -1, int ItemID = -1, int Quantity = -1, int UnitPrice = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewReturnPurchaseInvoice", "'" + InvoiceID + "','" + VendorID + "','" + StoreID + "','" + ItemID + "','" + Quantity + "','" + UnitPrice + "','" + Notes + "','0'");
        }
        /*public bool UpdateReturnPurchaseInvoice(int id = -1, int InvoiceID = -1, int VendorID = -1, int StoreID = -1, int ItemID = -1, int Quantity = -1, int UnitPrice = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateReturnPurchaseInvoice", "'" + id + "','" + InvoiceID + "','" + VendorID + "','" + StoreID + "','" + ItemID + "','" + Quantity + "','" + UnitPrice + "','" + Notes + "','0'");
        }
        public void DeleteReturnPurchaseInvoice(int id)
        {
            sql.sqlExecute("UpdateReturnPurchaseInvoiceState", "'" + id + "',1");
        }*/
        public DataTable GetReturnPurchaseInvoices(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ReturnPurchaseInvoicesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewReturnSaleInvoice(int InvoiceID = -1, int VendorID = -1, int StoreID = -1, int ItemID = -1, int Quantity = -1, int UnitPrice = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewReturnSaleInvoice", "'" + InvoiceID + "','" + VendorID + "','" + StoreID + "','" + ItemID + "','" + Quantity + "','" + UnitPrice + "','" + Notes + "','0'");
        }
        /*public bool UpdateReturnSaleInvoice(int id = -1, int InvoiceID = -1, int VendorID = -1, int StoreID = -1, int ItemID = -1, int Quantity = -1, int UnitPrice = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateReturnSaleInvoice", "'" + id + "','" + InvoiceID + "','" + VendorID + "','" + StoreID + "','" + ItemID + "','" + Quantity + "','" + UnitPrice + "','" + Notes + "','0'");
        }
        public void DeleteReturnSaleInvoice(int id)
        {
            sql.sqlExecute("UpdateReturnSaleInvoiceState", "'" + id + "',1");
        }*/
        public DataTable GetReturnSaleInvoices(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'ReturnSaleInvoicesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
     
       /* public bool UpdateSaleInvoice(int id = -1, int SerialNo = -1, int CustomerID = -1, int DelegateID = -1, int StoreID = -1, int ItemID = -1, int Quantity = -1, int UnitPrice = -1)
        {
            return (bool)sql.sqlExecute("UpdateSaleInvoice", "'" + id + "','" + SerialNo + "','" + CustomerID + "','" + DelegateID + "','" + StoreID + "','" + ItemID + "','" + Quantity + "','" + UnitPrice + "','0'");
        }
        public void DeleteSaleInvoice(int id)
        {
            sql.sqlExecute("UpdateSaleInvoiceState", "'" + id + "',1");
        }*/
        public DataTable GetSaleInvoices(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'SaleInvoicesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewSkill(int EmployeeID = -1, string Skills = " ", int Level = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewSkill", "'" + EmployeeID + "','" + Skills + "','" + Level + "','" + Notes + "','0'");
        }
        public bool UpdateSkill(int id = -1, int EmployeeID = -1, string Skills = " ", int Level = -1, string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateSkill", "'" + id + "','" + EmployeeID + "','" + Skills + "','" + Level + "','" + Notes + "','0'");
        }
        public void DeleteSkill(int id)
        {
            sql.sqlExecute("UpdateSkillState", "'" + id + "',1");
        }
        public DataTable GetSkills(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'SkillsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewStore(string StoreName = " ", int EmployeeID = -1, string Phone = " ", string Address = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewStore", "'" + StoreName + "','" + EmployeeID + "','" + Phone + "','" + Address + "','" + Notes + "','0'");
        }
        public bool UpdateStoreData(int id = -1, string StoreName = " ", int EmployeeID = -1, string Phone = " ", string Address = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateStoreData", "'" + id + "','" + StoreName + "','" + EmployeeID + "','" + Phone + "','" + Address + "','" + Notes + "','0'");
        }
        public void DeleteStore(int id)
        {
            sql.sqlExecute("UpdateStoreState", "'" + id + "',1");
        }
        public DataTable GetStoresData(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'StoresDataView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
      
        public DataTable GetStoreDetails(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'StoreDetailsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewVacation(int VacationTypeID = -1, int EmployeeID = -1, string FromDate = " ", string ToDate = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewVacation", "'" + VacationTypeID + "','" + EmployeeID + "','" + FromDate + "','" + ToDate + "','" + Notes + "','0'");
        }
        //public bool UpdateVacation(int id = -1, int VacationTypeID = -1, int EmployeeID = -1, string FromDate = " ", string ToDate = " ", string Notes = " ")
        //{
        //    return (bool)sql.sqlExecute("UpdateVacation", "'" + id + "','" + VacationTypeID + "','" + EmployeeID + "','" + FromDate + "','" + ToDate + "','" + Notes + "','0'");
        //}
        public void DeleteVacation(int id)
        {
            sql.sqlExecute("UpdateVacationState", "'" + id + "',1");
        }
        public DataTable GetVacations(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'VacationsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public DataTable GetVacationTypes(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'VacationsTypesView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewWarning(int EmployeeID = -1, string WarningType = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("InsertNewWarning", "'" + EmployeeID + "','" + WarningType + "','" + Notes + "','0'");
        }
        public bool UpdateWarning(int id = -1, int EmployeeID = -1, string WarningType = " ", string Notes = " ")
        {
            return (bool)sql.sqlExecute("UpdateWarning", "'" + id + "','" + EmployeeID + "','" + WarningType + "','" + Notes + "','0'");
        }
        public void DeleteWarning(int id)
        {
            sql.sqlExecute("UpdateWarningState", "'" + id + "',1");
        }
        public DataTable GetWarnings(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("getData 'WarningsView','" + key + "','" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }
        public bool InsertNewPriveledge(int UserID = -1, int PriveledgeID=-1)
        {
            return (bool)sql.sqlExecute("InsertNewPrivilege", "'" + UserID + "','" + PriveledgeID + "'");
        }
        public int CheckLogin(string user=" ",string pass="0" )
        {
            return (int)sql.sqlExecute("select [dbo].[CheckLogin1] ('" + user + "','" + pass + "')");
        }
        public void DeletePrivilege(int id)
        {
            sql.sqlExecute("DeletePrivilege", "'" + id + "'");
        }
        public DataTable GetPrivilege(string key = "1", string value = "1")
        {
            SqlDataAdapter check = new SqlDataAdapter(sql.command("select * from [dbo].[Privileges] where " + key + " = '" + value + "'"));
            DataTable Dt = new DataTable();
            check.Fill(Dt);
            return Dt;
        }

        public void fillcombo(System.Windows.Forms.ComboBox cm, DataTable dt1, string displaymember, string valuemember, string firstrow)
        {

            DataRow dr1 = dt1.NewRow();
            dr1[displaymember] = firstrow;
            dr1[valuemember] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            cm.DataSource = dt1;
            cm.DisplayMember = displaymember;
            cm.ValueMember = valuemember;
            //cm.BindingContext = this.BindingContext;
        }


    }
}
