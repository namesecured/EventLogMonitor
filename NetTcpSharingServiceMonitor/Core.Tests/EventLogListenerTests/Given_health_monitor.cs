﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using NUnit.Framework;

using Rhino.Mocks;

using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

namespace Core.Tests.EventLogListenerTests
{
    public abstract class Given_health_monitor : TestBase
    {
        protected IHealthMonitor healthMonitor;

        protected void GivenIHaveEventProvider()
        {
            var eventProvider = MockRepository.GenerateMock<IEventProvider>();
            this.Container.RegisterInstance(typeof(IEventProvider), eventProvider);
        }

        protected void GivenIHaveEventValidator()
        {
            var eventsValidator = MockRepository.GenerateMock<IEventValidator>();
            this.Container.RegisterInstance(typeof(IEventValidator), eventsValidator);
        }

        protected void GivenIHavePoolManager()
        {
            var poolManager = MockRepository.GenerateMock<IPoolManager>();
            this.Container.RegisterInstance(typeof(IPoolManager), poolManager);
        }

        protected void GivenIHaveHealthMonitor()
        {
            this.Container.RegisterType<IHealthMonitor, HealthMonitor>();
            this.healthMonitor = this.Container.Resolve<IHealthMonitor>();
        }
    }
}
