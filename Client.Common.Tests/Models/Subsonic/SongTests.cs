﻿using Client.Common.Models;
using Client.Common.Models.Subsonic;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Client.Common.Tests.Models.Subsonic
{
    [TestClass]
    public class SongTests
    {
        private Song _subject;

        [TestInitialize]
        public void TestInitialize()
        {
            _subject = new Song();
        }

        [TestMethod]
        public void InstanceShouldImplementIIdentifiableEntity()
        {
            _subject.Should().BeAssignableTo<IId>();
        }

        [TestMethod]
        public void InstanceShouldImplementINavigableEntity()
        {
            _subject.Should().BeAssignableTo<ISubsonicModel>();
        }

        [TestMethod]
        public void TypePropertyAlwaysReturnsNavigableTypeEnumAlbum()
        {
            _subject.Type.Should().Be(SubsonicModelTypeEnum.Song);
        }
    }
}
