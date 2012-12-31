﻿//-------------------------------------------------------------------------------
// <copyright file="EventScopeFactoryTest.cs" company="Appccelerate">
//   Copyright (c) 2008-2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.ScopingEventBroker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Appccelerate.EventBroker;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;
    using Xunit.Extensions;

    public class EventScopeFactoryTest
    {
        [Theory]
        [ClassData(typeof(EventScopeFactoriesAndTheirScopes))]
        public void CreateHandlerDecorator_ShouldCreateDefaultDecorator(IEventScopeFactory factory, Type scopeType)
        {
            IHandler decorator = factory.CreateHandlerDecorator(A.Fake<IHandler>());

            decorator.Should().BeOfType<ScopingHandlerDecorator>();
        }

        [Theory]
        [ClassData(typeof(EventScopeFactoriesAndTheirScopes))]
        public void CreateScopeHolder_ShouldCreateScopeHolderOfType(IEventScopeFactory factory, Type scopeType)
        {
            IEventScopeHolder scopeHolder = factory.CreateScopeHolder();

            scopeHolder.GetType().Should().Be(scopeType);
        }

        [Theory]
        [ClassData(typeof(EventScopeFactoriesAndTheirScopes))]
        public void CreateScopeContext_ShouldCreateScopeHolderOfType(IEventScopeFactory factory, Type scopeType)
        {
            IEventScopeContext scopeContext = factory.CreateScopeContext();

            scopeContext.GetType().Should().Be(scopeType);
        }

        [Theory]
        [ClassData(typeof(EventScopeFactoriesAndTheirScopes))]
        public void ScopeHolderAndScopeContext_ShouldBeSameInstance(IEventScopeFactory factory, Type scopeType)
        {
            var scopeContext = factory.CreateScopeContext();
            var scopeHolder = factory.CreateScopeHolder();

            scopeContext.Should().BeSameAs(scopeHolder);
        }

        [Theory]
        [ClassData(typeof(EventScopeFactoriesAndTheirScopes))]
        public void CreateScope_ShoudlCreateDefaultEventScope(IEventScopeFactory factory, Type scopeType)
        {
            IEventScope eventScope = factory.CreateScope();

            eventScope.Should().BeOfType<EventScope>();
        }

        private class EventScopeFactoriesAndTheirScopes : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new PerCallEventScopeFactory(), typeof(PerCallEventScopeContext) };
                yield return new object[] { new PerThreadEventScopeFactory(), typeof(PerThreadEventScopeContext) };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}