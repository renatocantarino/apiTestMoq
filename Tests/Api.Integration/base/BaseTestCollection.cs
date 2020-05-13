using System;
using System.Collections.Generic;
using System.Text;
using Tests.Api.Integration.Base;
using Xunit;

namespace Tests.Api.Integration.Bas
{
    [CollectionDefinition("Base collection")]
    public abstract class BaseTestCollection : ICollectionFixture<BaseTestFixture>
    {
    }
}