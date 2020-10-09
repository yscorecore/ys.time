﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Knife.Test;

namespace YS.Time.Impl.SqlServer.UnitTest
{
    [TestClass]
    public class TestEnvironment
    {
        [AssemblyInitialize()]
        public static void Setup(TestContext _)
        {
            var availablePort = Utility.GetAvailableTcpPort(1433);
            var password = Utility.NewPassword();
            StartContainer(availablePort, password);
            SetConnectionString(availablePort, password);
        }

        [AssemblyCleanup()]
        public static void TearDown()
        {
            DockerCompose.Down();
        }
        private static void SetConnectionString(uint port, string password)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = $"127.0.0.1,{port}",
                InitialCatalog = "tempdb",
                UserID = "sa",
                Password = password
            };
            Environment.SetEnvironmentVariable("ConnectionStrings__TimeContext", sqlConnectionStringBuilder.ConnectionString);
        }
        private static void StartContainer(uint port, string password)
        {
            DockerCompose.Up(new Dictionary<string, object>
            {
                ["SQLSERVER_PORT"] = port,
                ["SA_PASSWORD"] = password
            });
        }


    }
}
