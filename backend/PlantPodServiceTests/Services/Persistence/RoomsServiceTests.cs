using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using PlantPodService.Services;
using PlantPodService.Services.Persistence;
using System;
using System.Collections.Immutable;
using Sensor = PlantPodService.ViewModel.Sensor;

namespace PlantPodServiceTests.Services.Persistence
{
    [TestFixture]
    class RoomsServiceTests
    {
        protected IRoomsService Sut = new RoomsService();

        [Test]
        public void GetSensorIds_ShouldReturnCorrectId()
        {
            var result = Sut.GetSensorIds();

            result.Should().BeEquivalentTo(new [] {Guid.Parse("196db225-e5ef-4636-b967-c214a0ddb73f")}.ToImmutableArray());
        }
    }
}
