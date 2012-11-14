﻿using Client.Common.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Client.Common.Tests.Results
{
    [TestClass]
    public class GetMusicDirectoryResultTests
    {
        private IGetMusicDirectoryResult _subject;

        [TestInitialize]
        public void TestInitialize()
        {
            _subject = new GetMusicDirectoryResult(new SubsonicServiceConfiguration { ServiceUrl = "{0}{1}{2}"  }, 42);
        }

        [TestMethod]
        public void ViewNameShouldBegetMusicDirectory()
        {
            _subject.ViewName.Should().Be("getMusicDirectory.view");
        }

        [TestMethod]
        public void RequestUrlShouldBeCorrect()
        {
            _subject.RequestUrl.Should().EndWith("&id=42", "you need to append the id");
        }
    }
}