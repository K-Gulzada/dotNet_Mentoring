using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Api;
using BrainstormSessions.Controllers;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using Moq;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using Xunit;

using FluentAssertions;
using Serilog.Events;

namespace BrainstormSessions.Test.UnitTests
{
    public class LoggingTests
    {
        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());

            using (TestCorrelator.CreateContext())
            {
                using (var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext()
                            .CreateLogger())
                {
                    Log.Logger = logger;
                    var controller = new HomeController(mockRepo.Object);

                    // Act
                    var result = await controller.Index();

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    logEvents.Should()
                        .Satisfy(logEvent =>
                            logEvent.Level == LogEventLevel.Information);
                }
            }
        }

        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();

            using (TestCorrelator.CreateContext())
            {
                using (var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext()
                            .CreateLogger())
                {
                    Log.Logger = logger;

                    // Act
                    var result = await controller.Index(newSession);

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    logEvents.Should()
                        .Satisfy(logEvent =>
                            logEvent.Level == LogEventLevel.Warning);
                }
            }
        }

        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            // Arrange & Act
            var mockRepo = new Mock<IBrainstormSessionRepository>();

            var controller = new IdeasController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            using (TestCorrelator.CreateContext())
            {
                using (var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext()
                            .CreateLogger())
                {
                    Log.Logger = logger;

                    // Act
                    var result = await controller.CreateActionResult(model: null);

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    logEvents.Should()
                        .Satisfy(logEvent =>
                            logEvent.Level == LogEventLevel.Error);
                }
            }
        }

        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            // Arrange
            int testSessionId = 1;
            int actualCountOfDebegLevelEvents = 2;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            var controller = new SessionController(mockRepo.Object);

            using (TestCorrelator.CreateContext())
            {
                using (var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext().MinimumLevel.Debug()
                            .CreateLogger())
                {
                    Log.Logger = logger;

                    // Act
                    var result = await controller.Index(testSessionId);

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    int expectedCountOfDebegLevelEvents =
                        logEvents.Count(logEvent =>
                            logEvent.Level == LogEventLevel.Debug);

                    expectedCountOfDebegLevelEvents.Should()
                        .Be(actualCountOfDebegLevelEvents);
                }
            }
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession> {

                new BrainstormSession()
                {
                    DateCreated = new DateTime(2016, 7, 2),
                    Id = 1,
                    Name = "Test One"
                },
                new BrainstormSession()
                {
                    DateCreated = new DateTime(2016, 7, 1),
                    Id = 2,
                    Name = "Test Two"
                }
            };

            return sessions;
        }
    }
}
