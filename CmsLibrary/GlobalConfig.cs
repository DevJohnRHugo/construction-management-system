﻿using CmsLibrary.Business_Layer.Login;
using CmsLibrary.BusinessLogic.Login;
using CmsLibrary.DataAccess;
using CmsLibrary.DataAccess.CostMonitoring;
using CmsLibrary.DataAccess.CostMonitoring.ProjectSelection;
using CmsLibrary.DataAccess.Login;
using CmsLibrary.Interface.CostMonitoring.ProjectSelection;
using CmsLibrary.Interface.Login;
using CmsLibrary.Interface.Login.SpEvents;
using CmsLibrary.Interface.SpParameters;
using CmsLibrary.Model.SpEvents;
using CmsLibrary.Model.SpParameters;
using System.Configuration;
using System.Windows.Forms;

namespace CmsLibrary {
    /// <summary>
    /// Configures the Access to the sql database and all methods
    /// </summary>
    public static class GlobalConfig {
        /// <summary>
        /// Static access to IAccountLoginConnection interface methods and its dependencies for Admin account login
        /// </summary>
        public static IAdminLoginConnection LoginAdminConnection {
            get; private set;
        }

        /// <summary>
        /// Static access to IUserLoginConnection interface methods and its dependencies for User account login
        /// </summary>
        public static IUserLoginConnection LoginUserConnection {
            get; private set;
        }

        /// <summary>
        /// Static access to IAccountLoginConnection interface global methods and its dependencies for in general or global functionality in login
        /// </summary>
        public static IAccountLoginConnection LoginGlobalConnection {
            get; private set;
        }

        /// <summary>
        /// Static access to IAccessCodesProcess interface methods and its dependencies for the accessibility codes of each accounts in login
        /// </summary>
        public static IAccessCodesProcess LoginCodes {
            get; private set;
        }

        /// <summary>
        /// Static access to IValidateInputProcess interface methods and its dependencies for validating the account credentials for login
        /// </summary>
        public static IValidateInputProcess LoginValidation {
            get; private set;
        }

        /// <summary>
        /// Static access to ICostMonitoringConnection interface methods and its dependencies for cost monitoring
        /// </summary>
        public static ICostMonitoringConnection Cost {
            get; private set;
        }

        /// <summary>
        /// Static access to IProjectsConnection interface methods and its dependencies for configuring projects and sub projects
        /// </summary>
        public static IProjectsMainConnection MainProjectConfig {
            get; private set;
        }

        public static IProjectsSubConnection SubProjectConfig {
            get; private set;
        }

        public static IProjectsConnection ProjectsGlobalConfig {
            get; private set;
        }

      

        /// <summary>
        /// Static access to ISpEvents interface methods and its dependencies 
        /// </summary>
        public static ILoginSpEvents LoginSpEvents {
            get; private set;
        }

        public static IProjecsSpEvents ProjectsSpEvents {
            get; private set;
        }

        public static IProjectsSpParamName ProjectsSpParamName {
            get; private set;
        }


        /// <summary>
        /// Initializing the instance of the classes that implements methods
        /// </summary>
        public static void InitializeConnections( ) {
           
            AccountGlobalSqlConnector sql = new AccountGlobalSqlConnector( );
            LoginGlobalConnection = sql;

            AdminSqlConnector adminSql = new AdminSqlConnector( );
            LoginAdminConnection = adminSql;

            UserSqlConnector userSql = new UserSqlConnector( );
            LoginUserConnection = userSql;

            AccessCodesValue code = new AccessCodesValue( );
            LoginCodes = code;

            ValidationResult valid = new ValidationResult( );
            LoginValidation = valid;

            BillMatConnector bm = new BillMatConnector( );
            Cost = bm;

            JournalConnector journal = new JournalConnector( );
            Cost = journal;

            LoginSpEventsModel loginEvents = new LoginSpEventsModel( );
            LoginSpEvents = loginEvents;

            ProjectsSpEventsModel projectsEvents = new ProjectsSpEventsModel( );
            ProjectsSpEvents = projectsEvents;

            ProjectsMainSqlConnector project = new ProjectsMainSqlConnector( );
            MainProjectConfig = project;

            ProjectsSubSqlConnector subProject = new ProjectsSubSqlConnector( );
            SubProjectConfig = subProject;

            ProjectsGlobalSqlConnector GlobalProject = new ProjectsGlobalSqlConnector( );
            ProjectsGlobalConfig = GlobalProject;

            ProjectsSpParamNameModel spParamName = new ProjectsSpParamNameModel( );
            ProjectsSpParamName = spParamName;
          
        }

        /// <summary>
        /// Static connection string in app.config file
        /// </summary>
        private static string ConnectionString = " SERVER=" + SystemInformation.ComputerName + ConfigurationManager.ConnectionStrings[ "connection" ].ConnectionString;

        /// <summary>
        /// Returning the connection string
        /// </summary>
        public static string ConnString {
            get {
                return ConnectionString;
            }
        }
    }
}
