using System;
using System.Collections.Generic;
using static Final_Project.Program;
using System.Xml.Linq;
namespace Final_Project
{
    class Program
    {
        static Patient[] patients_arr = new Patient[100];
        static int patientCount = 0;


        static Doctors[] doctors_arr = new Doctors[30];
        static int doctorCount = 0;

        static Nurses[] nurses_arr = new Nurses[50];
        static int nurseCount = 0;

        static Admins[] admins_arr = new Admins[10];
        static int adminCount = 0;


        static int lastPatientID = 0;

        static int lastDoctorID = 0;
        static int lastNurseID = 0;
        static int lastAdminID = 0;


        static void Main(string[] args)
        {
           while (true)
            {

                Console.WriteLine("Welcome to Hospital Management System");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1. To Patient Management");
                Console.WriteLine("2. To Staff Management");
                Console.WriteLine("0. To EXIT");

                string choice;
                do
                {
                    Console.WriteLine("Choose from 0 to 2");
                    choice = Console.ReadLine();
                    if (choice != "0" && choice != "1" && choice != "2" )
                    { 
                        Console.WriteLine("Please, Choose from 0 To 5");   
                    }

                } while (choice != "0" && choice != "1" && choice != "2");

                switch(choice)
                {
                    case "1":
                        PatientMenu();
                        break;

                    case "2":
                        StaffMenu();
                        break;

                   
                    case "0":
                        Console.WriteLine("Program Exiting...");
                        return;


                }

            }
         
        }

        static void PatientMenu()
        {
            
            Console.WriteLine("----- Patient Management -----");
            Console.WriteLine("1. Add New Patient");
            Console.WriteLine("2. View Patient Details");
            Console.WriteLine("3. Update Patient Information");
            Console.WriteLine("4. Delete Patient");
            Console.Write("Enter your choice: ");
            string choice=Console.ReadLine(); 
            switch(choice)
            {
                case "1": AddNewPatient(); break;
                case "2": ViewPatientDetails(); break;
                case "3": UpdatePatientInfo(); break;
                case "4": DeletePatient(); break;
                default: Console.WriteLine("invalid input"); break;
            }
        }


        static void AddNewPatient()
        {
            if (patientCount < patients_arr.Length)
            {
                Patient patient = new Patient();
                lastPatientID++;  
                patient.Set_ID(lastPatientID);

                Console.WriteLine("Enter Name :");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Age :");
                int age = int.Parse(Console.ReadLine());
                
                patient.Set_Name(name);
                patient.Set_Age(age);

                patients_arr[patientCount] = patient;
                patientCount++;
                Console.WriteLine("Patient added successfully with ID: " + lastPatientID);
            }

            else Console.WriteLine("Beds are full, Can't add more patients.");
        }

        static void ViewPatientDetails()
        {
            Console.WriteLine("U will view details by ID(1) or Name(2)?");
            int choice = int.Parse(Console.ReadLine());
            if(choice==1)
            {
                Console.WriteLine("Enter your ID:");
                int Search_ID = int.Parse(Console.ReadLine());
                for(int i=0;i<patientCount;i++)
                {
                    if (patients_arr[i].Get_ID() ==Search_ID)
                    {
                        Console.WriteLine("Patient found with:");
                        Console.WriteLine("ID: " + patients_arr[i].Get_ID());
                        Console.WriteLine("Name: " + patients_arr[i].Get_Name());
                        Console.WriteLine("Age: " + patients_arr[i].Get_Age());
                        return;
                    }
                }
                    Console.WriteLine("Patient Not Found!");



            }
            else if(choice==2)
            {
                Console.WriteLine("Enter your Name:");
                string Search_Name = Console.ReadLine();
                for (int i = 0; i < patientCount; i++)
                {
                    if (patients_arr[i].Get_Name() == Search_Name)
                    {
                        Console.WriteLine("Patient found with:");
                        Console.WriteLine("Name: " + patients_arr[i].Get_Name());
                        Console.WriteLine("ID: " + patients_arr[i].Get_ID());
                        Console.WriteLine("Age: " + patients_arr[i].Get_Age());
                        return;
                    }
                }

                Console.WriteLine("Patient Not Found!");
            }
        }

        static void UpdatePatientInfo()
        {
            Console.WriteLine("Enter the ID of the Patient you want to update:");
            int searchID = int.Parse(Console.ReadLine());
            for(int i=0;i<patientCount;i++)
            {
                if (patients_arr[i].Get_ID()==searchID)
                {
                    Console.WriteLine("Enter New Name:");
                    string new_Name = Console.ReadLine();
                    patients_arr[i].Set_Name(new_Name);

                    Console.WriteLine("Enter New Age:");
                    int new_Age = int.Parse(Console.ReadLine());
                    patients_arr[i].Set_Age(new_Age);

                    Console.WriteLine("Patient INFO Updated Successfully!");
                    return;
                }
            }

            Console.WriteLine("Patient with this ID was not found.");

        }
        static void DeletePatient()
        {
            Console.WriteLine("Enter the ID of the patient you want to delete:");
            int searchID = int.Parse(Console.ReadLine());
            for (int i=0; i<patientCount; i++)
            {
                if (patients_arr[i].Get_ID() == searchID)
                {
                    for (int j=i; j<patientCount-1; j++)
                    {
                        patients_arr[j]=patients_arr[j+1]; 
                    }
                    patients_arr[patientCount-1] = null;
                    patientCount--;
                    Console.WriteLine("Patient INFO Deleted Successfully!");
                    return;

                }
            }

            Console.WriteLine("Patient with this ID was not found.");
        }


        static void StaffMenu()
        {
            
            Console.WriteLine("----- Staff Management -----");
            Console.WriteLine("1. Add New Staff Member");
            Console.WriteLine("2. View Staff Details");
            Console.WriteLine("3. Update Staff Information");
            Console.WriteLine("4. Remove Staff Member");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddNewStaffMember(); break;
                case "2": ViewStaffDetails(); break;
                case "3": UpdateStaffInfo(); break;
                case "4": RemoveStaffMember(); break;
                default: Console.WriteLine("invalid input"); break;
            }
        }

        static void AddNewStaffMember()
        {
            Console.WriteLine("Choose the type:");
            Console.WriteLine("1. Doctor");
            Console.WriteLine("2. Nurse");
            Console.WriteLine("3. Admin");

            string Choice_Type = Console.ReadLine();

            Console.Write("Enter Name: ");
            string s_name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int s_age = int.Parse(Console.ReadLine());

            if (Choice_Type == "1")
            {
                if (doctorCount < doctors_arr.Length)
                {
                    Doctors doctor = new Doctors();
                    lastDoctorID++;
                    doctor.Set_sID(lastDoctorID);

                    doctor.Set_sName(s_name);
                    doctor.Set_sAge(s_age);

                    doctors_arr[doctorCount] = doctor;
                    doctorCount++;
                    Console.WriteLine("Doctor added successfully!");
                }
                else Console.WriteLine("Hospital is full of Doctors!");
            }

            else if (Choice_Type == "2")
            {
                if (nurseCount < nurses_arr.Length)
                {
                    Nurses nurse = new Nurses();

                    lastNurseID++;
                    nurse.Set_sID(lastNurseID);

                    nurse.Set_sName(s_name);
                    nurse.Set_sAge(s_age);

                    nurses_arr[nurseCount] = nurse;
                    nurseCount++;
                    Console.WriteLine("Nurse added successfully!");
                }
                else Console.WriteLine("Hospital is full of Nurses!");
            }

            else if (Choice_Type == "3")
            {
                if (adminCount < admins_arr.Length)
                {
                    Admins admin = new Admins();

                    lastAdminID++;
                    admin.Set_sID(lastAdminID);

                    admin.Set_sName(s_name);
                    admin.Set_sAge(s_age);
                    admins_arr[adminCount] = admin;
                    adminCount++;
                    Console.WriteLine("Admin added successfully!");
                }

                else Console.WriteLine("Hospital is full of Admins!");
            }

            else Console.WriteLine("U entered an invalid input!");
        }

        static void ViewStaffDetails()
        {
            Console.WriteLine("Choose staff type to view:");
            Console.WriteLine("1. Doctors");
            Console.WriteLine("2. Nurses");
            Console.WriteLine("3. Admins");
            string typeChoice = Console.ReadLine();

            if (typeChoice == "1")
            {
                if (doctorCount == 0)
                {
                    Console.WriteLine("No doctors found.");
                }
                else
                {
                    Console.WriteLine("List of Doctors:");
                    for (int i = 0; i < doctorCount; i++)
                    {
                        doctors_arr[i].DisplayInfo();
                    }
                }
            }

            if (typeChoice == "2")
            {
                if (nurseCount == 0)
                {
                    Console.WriteLine("No nurses found.");
                }
                else
                {
                    Console.WriteLine("List of Nurses:");
                    for (int i = 0; i < nurseCount; i++)
                    {
                        nurses_arr[i].DisplayInfo();
                    }
                }
            }

            if (typeChoice == "3")
            {
                if (adminCount == 0)
                {
                    Console.WriteLine("No admins found.");
                }
                else
                {
                    Console.WriteLine("List of Adminss:");
                    for (int i = 0; i < adminCount; i++)
                    {
                        admins_arr[i].DisplayInfo();
                    }
                }
            }
        }

        static void UpdateStaffInfo()
        {
            Console.WriteLine("Choose staff type to update:");
            Console.WriteLine("1. Doctors");
            Console.WriteLine("2. Nurses");
            Console.WriteLine("3. Admins");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter the ID of the staff member to update: ");
            int searchID = int.Parse(Console.ReadLine());

            if (typeChoice == "1")
            {
                for (int i = 0; i < doctorCount; i++)
                {
                    if (doctors_arr[i].Get_sID() == searchID)
                    {
                        Console.Write("Enter new name: ");
                        string new_dName = Console.ReadLine();

                        Console.Write("Enter new age: ");
                        int new_dAge = int.Parse(Console.ReadLine());

                        doctors_arr[i].Set_sName(new_dName);
                        doctors_arr[i].Set_sAge(new_dAge);

                        Console.WriteLine("Doctor information updated successfully!");
                        return;
                    }
                }

                Console.WriteLine("Doctor not found!");
            }

            if (typeChoice == "2")
            {
                for (int i = 0; i < nurseCount; i++)
                {
                    if (nurses_arr[i].Get_sID() == searchID)
                    {
                        Console.Write("Enter new name: ");
                        string new_nName = Console.ReadLine();

                        Console.Write("Enter new age: ");
                        int new_nAge = int.Parse(Console.ReadLine());

                        nurses_arr[i].Set_sName(new_nName);
                        nurses_arr[i].Set_sAge(new_nAge);

                        Console.WriteLine("Nurse information updated successfully!");
                        return;
                    }
                }

                Console.WriteLine("Nurse not found!");
            }

            if (typeChoice == "3")
            {
                for (int i = 0; i < adminCount; i++)
                {
                    if (admins_arr[i].Get_sID() == searchID)
                    {
                        Console.Write("Enter new name: ");
                        string new_aName = Console.ReadLine();

                        Console.Write("Enter new age: ");
                        int new_aAge = int.Parse(Console.ReadLine());

                        admins_arr[i].Set_sName(new_aName);
                        admins_arr[i].Set_sAge(new_aAge);

                        Console.WriteLine("Admin information updated successfully!");
                        return;
                    }
                }

                Console.WriteLine("Admin not found!");
            }
        }

        static void RemoveStaffMember()
        {
            Console.WriteLine("Choose staff type to remove:");
            Console.WriteLine("1. Doctors");
            Console.WriteLine("2. Nurses");
            Console.WriteLine("3. Admins");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter the ID of the staff member to remove: ");
            int searchID = int.Parse(Console.ReadLine());

            if (typeChoice == "1")
            {
                for (int i = 0; i < doctorCount; i++)
                {
                    if (doctors_arr[i].Get_sID() == searchID)
                    {
                        for (int j = i; j < doctorCount - 1; j++)
                        {
                            doctors_arr[j] = doctors_arr[j + 1];
                        }

                        doctors_arr[doctorCount - 1] = null;
                        doctorCount--;

                        Console.WriteLine("Doctor removed successfully!");
                        return;
                    }
                }

                Console.WriteLine("Doctor not found!");
            }

            if (typeChoice == "2")
            {
                for (int i = 0; i < nurseCount; i++)
                {
                    if (nurses_arr[i].Get_sID() == searchID)
                    {
                        for (int j = i; j < nurseCount - 1; j++)
                        {
                            nurses_arr[j] = nurses_arr[j + 1];
                        }

                        nurses_arr[nurseCount - 1] = null;
                        nurseCount--;

                        Console.WriteLine("Nurse removed successfully!");
                        return;
                    }
                }

                Console.WriteLine("Nurse not found!");
            }

            if (typeChoice == "3")
            {
                for (int i = 0; i < adminCount; i++)
                {
                    if (admins_arr[i].Get_sID() == searchID)
                    {
                        for (int j = i; j < adminCount - 1; j++)
                        {
                            admins_arr[j] = admins_arr[j + 1];
                        }

                        admins_arr[adminCount - 1] = null;
                        adminCount--;

                        Console.WriteLine("Admin removed successfully!");
                        return;
                    }
                }

                Console.WriteLine("Admin not found!");
            }
        }



       public class Patient
        {
            private int ID ;
           private string Name;
           private int Age;

          public int Get_ID()
            {
                return ID;
            }
          public void Set_ID(int id)
            {
                ID = id;
            }

            public string Get_Name() { return Name; }
            public void Set_Name(string name) { Name = name; }

            public int Get_Age() { return Age; }
            public void Set_Age(int age) { Age = age; }
        }




        public class Staff
        {
            private int sID;
            private string sName;
            private int sAge;

            public int Get_sID() { return sID; }
            public void Set_sID(int s_id) { sID = s_id; }

            public string Get_sName() { return sName; }
            public void Set_sName(string s_name) { sName = s_name; }

            public int Get_sAge() { return sAge; }
            public void Set_sAge(int s_age) { sAge = s_age; }
           public virtual void DisplayInfo()
           {
              Console.WriteLine("ID   : " + Get_sID());
              Console.WriteLine("Name : " + Get_sName());
              Console.WriteLine("Age  : " + Get_sAge());
           }
        }


        public class Doctors: Staff
        {
            public override void DisplayInfo()
            {
                Console.WriteLine("Doctor Information:");
                base.DisplayInfo();
            }

        }

        public class Nurses: Staff
        {
            public override void DisplayInfo()
            {
                Console.WriteLine("Nurse Information:");
                base.DisplayInfo();
            }

        }

        public class Admins : Staff
        {
            public override void DisplayInfo()
            {
                Console.WriteLine("Admin Information:");
                base.DisplayInfo();
            }

        }

    }
}