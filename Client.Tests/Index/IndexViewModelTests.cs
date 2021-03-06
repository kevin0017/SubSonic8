﻿using Client.Tests.Framework.ViewModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Subsonic8.Index;

namespace Client.Tests.Index
{
    [TestClass]
    public class IndexViewModelTests : ViewModelBaseTests<IndexViewModel>
    {
        protected override IndexViewModel Subject { get; set; }

        [TestMethod]
        public void CtorShouldSetMenuItems()
        {
            Subject.MenuItems.Should().BeEmpty();
        }
    }
}