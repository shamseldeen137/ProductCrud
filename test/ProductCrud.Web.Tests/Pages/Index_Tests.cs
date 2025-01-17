﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ProductCrud.Pages;

public class Index_Tests : ProductCrudWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
