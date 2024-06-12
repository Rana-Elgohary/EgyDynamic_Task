using EgyDynamic_Task.Models;
using EgyDynamic_Task.Repo;

namespace EgyDynamic_Task.UnitOfWork
{
    public class UOW
    {
        EgyDynamic_TaskContext DB;

        GenericRepo<الموظف> employeeRepo;
        GenericRepo<العميل> customerRepo;
        GenericRepo<مكالمه_العميل> callsRepo;

        public UOW(EgyDynamic_TaskContext db)
        { 
            DB = db; 
        }

        public GenericRepo<الموظف> EmployeeRepo
        {
            get
            {
                if (employeeRepo == null)
                {
                    employeeRepo = new GenericRepo<الموظف>(DB);
                }
                return employeeRepo;
            }
        }

        public GenericRepo<العميل> CustomerRepo
        {
            get
            {
                if (customerRepo == null)
                {
                    customerRepo = new GenericRepo<العميل>(DB);
                }
                return customerRepo;
            }
        }

        public GenericRepo<مكالمه_العميل> CallsRepo
        {
            get
            {
                if (callsRepo == null)
                {
                    callsRepo = new GenericRepo<مكالمه_العميل>(DB);
                }
                return callsRepo;
            }
        }

        public void SaveChanges()
        {
            DB.SaveChanges();
        }
    }
}
