modelBuilder.Entity<Employee>().HasData(
    // Management
    new Employee { Id = 1, EmployeeNumber = "0001", FullName = "Linda Jenkins", Email = "lindajenkins@acme.com", Role = EmployeeRole.CEO, IsTeamLead = true },
    new Employee { Id = 2, EmployeeNumber = "0002", FullName = "Milton Coleman", Email = "miltoncoleman@amce.com", Cellphone = "+27 55 937 274", Role = EmployeeRole.Manager, IsTeamLead = true },
    new Employee { Id = 3, EmployeeNumber = "0003", FullName = "Colin Horton", Email = "colinhorton@amce.com", Cellphone = "+27 20 915 7545", Role = EmployeeRole.Manager, IsTeamLead = true, ManagerId = 2 },

    // Dev Team
    new Employee { Id = 4, EmployeeNumber = "2005", FullName = "Ella Jefferson", Email = "ellajefferson@acme.com", Cellphone = "+27 55 979 367", Role = EmployeeRole.Employee, ManagerId = 3 },
    new Employee { Id = 5, EmployeeNumber = "2006", FullName = "Earl Craig", Email = "earlcraig@acme.com", Cellphone = "+27 20 916 5608", Role = EmployeeRole.Employee, ManagerId = 3 },
    new Employee { Id = 6, EmployeeNumber = "2008", FullName = "Marsha Murphy", Email = "marshamurphy@acme.com", Cellphone = "+36 55 949 891", Role = EmployeeRole.Employee, ManagerId = 3 },
    new Employee { Id = 7, EmployeeNumber = "2009", FullName = "Luis Ortega", Email = "luisortega@acme.com", Cellphone = "+27 20 917 1339", Role = EmployeeRole.Employee, ManagerId = 3 },
    new Employee { Id = 8, EmployeeNumber = "2010", FullName = "Faye Dennis", Email = "fayedennis@acme.com", Role = EmployeeRole.Employee, ManagerId = 3 },
    new Employee { Id = 9, EmployeeNumber = "2012", FullName = "Amy Burns", Email = "amyburns@acme.com", Cellphone = "+27 20 914 1775", Role = EmployeeRole.Employee, ManagerId = 3 },
    new Employee { Id = 10, EmployeeNumber = "2013", FullName = "Darrel Weber", Email = "darrelweber@acme.com", Cellphone = "+27 55 615 463", Role = EmployeeRole.Employee, ManagerId = 3 },

    // Support Team
    new Employee { Id = 11, EmployeeNumber = "1005", FullName = "Charlotte Osborne", Email = "charlotteosborne@acme.com", Cellphone = "+27 55 760 177", Role = EmployeeRole.Support, ManagerId = 2 },
    new Employee { Id = 12, EmployeeNumber = "1006", FullName = "Marie Walters", Email = "mariewalters@acme.com", Cellphone = "+27 20 918 6908", Role = EmployeeRole.Support, ManagerId = 2 },
    new Employee { Id = 13, EmployeeNumber = "1008", FullName = "Leonard Gill", Email = "leonardgill@acme.com", Cellphone = "+27 55 525 585", Role = EmployeeRole.Support, ManagerId = 2 },
    new Employee { Id = 14, EmployeeNumber = "1009", FullName = "Enrique Thomas", Email = "enriquethomas@acme.com", Cellphone = "+27 20 916 1335", Role = EmployeeRole.Support, ManagerId = 2 },
    new Employee { Id = 15, EmployeeNumber = "1010", FullName = "Omar Dunn", Email = "omardunn@acme.com", Role = EmployeeRole.Support, ManagerId = 2 },
    new Employee { Id = 16, EmployeeNumber = "1012", FullName = "Dewey George", Email = "deweygeorge@acme.com", Cellphone = "+27 55 260 127", Role = EmployeeRole.Support, ManagerId = 2 },
    new Employee { Id = 17, EmployeeNumber = "1013", FullName = "Rudy Lewis", Email = "rudylewis@acme.com", Role = EmployeeRole.Support, ManagerId = 2 },
    new Employee { Id = 18, EmployeeNumber = "1015", FullName = "Neal French", Email = "nealfrench@acme.com", Cellphone = "+27 20 919 4882", Role = EmployeeRole.Support, ManagerId = 2 }
);
